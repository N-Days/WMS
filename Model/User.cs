using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using WMS.Interface;

namespace WMS.Model
{
    public class User:IDataObject
    {
        private const String c_insert = "insert into user values(null,'@AccountNumber','@Password','@UserName','@EnrollDate',@UserType,@CreateId,@Enable)";
        private const String c_update = "";
        private const String c_delete = "";

        private int _id;
        private string _accountnumber = "";
        private string _password = "";
        private string _username = "";
        private DateTime _enrolldate;
        private int _userType;
        private int _createid;
        private bool _enable;

        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public string AccountNumber
        {
            get
            {
                return this._accountnumber;
            }
            set
            {
                this._accountnumber = value;
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }

        public DateTime EnrollDate
        {
            get
            {
                return this._enrolldate;
            }
            set
            {
                this._enrolldate = value;
            }
        }

        public int UserType
        {
            get
            {
                return this._userType;
            }
            set
            {
                this._userType = value;
            }
        }

        public int CreateId
        {
            get
            {
                return this._createid;
            }
            set
            {
                this._createid = value;
            }
        }

        public bool Enable
        {
            get
            {
                return this._enable;
            }
            set
            {
                this._enable = value;
            }
        }

        public override string ToString()
        {
            return "id:"+_id+",accountNumber:"+_accountnumber+",password:"+_password+",userName:"+_username+",enrollDate:"+_enrolldate.ToString()+",userType:"+_userType+",createId:"+_createid+",enable:"+_enable.ToString()+"";
        }

        public SQLiteCommand ToInsert()
        {
            return new SQLiteCommand(c_insert)
            {
                Parameters =
                {
                    new SQLiteParameter("@AccountNumber",AccountNumber),
                    new SQLiteParameter("@Password",Password),
                    new SQLiteParameter("@UserName",UserName),
                    new SQLiteParameter("@EnrollDate",EnrollDate.ToString("s")),
                    new SQLiteParameter("@UserType",UserType),
                    new SQLiteParameter("@CreateId",CreateId),
                    new SQLiteParameter("@Enable",Enable?1:0),
                }
            };
        }

        public SQLiteCommand ToUpdate()
        {
            throw new NotImplementedException();
        }

        public SQLiteCommand ToDelete()
        {
            throw new NotImplementedException();
        }
    }
}
