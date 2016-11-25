using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Helper;
using WMS.Common;
using WMS.Model;
using System.Data.SQLite;

namespace WMS.Controllers
{
    class OperationController
    {
        private const String c_insert = "insert into user_operation values(null,@UserID,@Operation,@Content,@OperaDate)";

        public OperationController()
        {
        }

        public void RecordOperation(User currentuser, string action, string content)
        {
            GlobalParam.DataBase.Execute(GetOperationCommand(currentuser, action, content));
        }

        public SQLiteCommand GetOperationCommand(User currentuser, string action, string content)
        {
            var command = new SQLiteCommand(c_insert);
            command.Parameters.AddRange(new[] {
                    new SQLiteParameter("@UserID",currentuser.Id),
                    new SQLiteParameter("@Operation",action),
                    new SQLiteParameter("@Content",content),
                    new SQLiteParameter("@OperaDate",DateTime.Now.ToString("s")),
                });
            return command;
        }

        public struct Action
        {
            public const string InsertUser = "新增用户";
            public const string DeleteUser = "删除用户";

            public const string InsertGoods = "新增货物";
            public const string UpdateGoods = "更新货物";

            public const string InsertInventory = "新增库存";
            public const string UpdateInventory = "更新库存";
            public const string CalculateInventory = "计算库存";
            public const string SettleInventory = "结算库存";

            public const string InsertInventoryIO = "新增进出库记录";
            public const string UpdateInventoryIO = "更新进出库记录";
            public const string DeleteInventoryIO = "删除进出库记录";

            public const string RunningNewMonth = "运行新月份";

        }
    }
}
