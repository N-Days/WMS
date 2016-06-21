using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WMS.Helper;
using WMS.Model;

namespace WMS.Controllers
{
    class UserController
    {
        private SqliteHelper _sqlite_helper
        {
            get;
            set;
        }

        public UserController()
        {
            _initData();
        }

        private void _initData()
        {
            _sqlite_helper = new SqliteHelper();
        }

        private IEnumerable<User> _getusers(DataView dv)
        {
            foreach (DataRow dr in dv)
                yield return new User
                {
                    Id = Convert.ToInt32(dr["id"].ToString()),
                    AccountNumber = dr["accountNumber"].ToString(),
                    Password = dr["password"].ToString(),
                    UserName = dr["userName"].ToString(),
                    EnrollDate = Convert.ToDateTime(dr["enrollDate"].ToString()),
                    UserType = Convert.ToInt32(dr["userType"].ToString()),
                    Enable = dr["enable"].ToString().Equals("1")
                };
        }

        public IEnumerable<User> GetUsers(UserType? usertype = null)
        {
            switch (usertype)
            {
                case UserType.admin:
                    {
                        return _getusers(_sqlite_helper.Query_DataView("select * from user where userType=@UserType",
                            new System.Data.SQLite.SQLiteParameter("@UserType", UserType.admin)));
                    }

                case UserType.user:
                    {
                        return _getusers(_sqlite_helper.Query_DataView("select * from user where userType=@UserType",
                            new System.Data.SQLite.SQLiteParameter("@UserType", UserType.user)));
                    }

                default:
                    {
                        return _getusers(_sqlite_helper.Query_DataView(new System.Data.SQLite.SQLiteCommand("select * from user where userType=@UserType")));
                    }
            }
        }

        public bool Insert(User currentuser, User newuser)
        {
            DataView dv_User = _sqlite_helper.Query_DataView("select * from user where accountNumber='@AccountNumber' and userName='@UserName'",
                new[]
                {
                    new System.Data.SQLite.SQLiteParameter("@AccountNumber",newuser.AccountNumber),
                    new System.Data.SQLite.SQLiteParameter("@UserName",newuser.UserName),
                });
            if (dv_User.Count == 0)
            {
                _sqlite_helper.Execute(newuser.ToInsert());
                _sqlite_helper.Execute(new OperationController().GetOperationCommand(currentuser, OperationController.Action.InsertUser, newuser.ToString()));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UserLogin(String accountname, String password,out User user)
        {
            user = GetUsers().FirstOrDefault(u => u.AccountNumber.Equals(accountname) && u.Password.Equals(password));
            return user == null ? false : true;
        }

        public enum UserType
        {
            admin = 1,
            user = 2,
        }
    }
}
