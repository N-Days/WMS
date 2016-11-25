using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WMS.Helper;
using WMS.Common;
using WMS.Model;
using System.Data.SQLite;

namespace WMS.Controllers
{
    class Inventory_IO_Controller
    {
        private SqliteHelper _sqlite_helper => GlobalParam.DataBase;
        private OperationController _operation_controller
        {
            get;
            set;
        }
        public Inventory_IO_Controller()
        {
            _initData();
        }

        private void _initData()
        {
            _operation_controller = new OperationController();
        }

        private IEnumerable<Inventory_IO> GetGoodsIO(DataView dv)
        {
            foreach (DataRowView drv in dv)
            {
                yield return new Inventory_IO
                {
                    ID = Convert.ToInt32(drv["id"].ToString()),
                    GoodsID = Convert.ToInt32(drv["goodsId"].ToString()),
                    Price = Convert.ToDouble(drv["price"].ToString()),
                    Weight = Convert.ToDouble(drv["weight"].ToString()),
                    RecordDate = Convert.ToDateTime(drv["recordDate"].ToString()),
                    SettleMonth=drv["settleMonth"].ToString(),
                    UserID = Convert.ToInt32(drv["userid"].ToString())
                };
            }
        }

        public IEnumerable<Inventory_IO> GetGoodsIOBySettleMonth(string settlemonth)
        {
            return GetGoodsIO(_sqlite_helper.Query_DataView("select * from inventoryIO where settleMonth=@SettleMonth",
                new SQLiteParameter("@SettleMonth", settlemonth)));
        }

        private bool _insert(Inventory_IO inventory_io, User user, ref string message)
        {
            try
            {
                _sqlite_helper.Execute(inventory_io.ToInsert());
                _operation_controller.RecordOperation(user, OperationController.Action.InsertInventoryIO, inventory_io.ToString());
                message += inventory_io.GoodsID + "进出库记录新增成功,\n";
                return true;
            }
            catch (Exception e)
            {
                message += inventory_io.GoodsID + "进出库记录新增失败" + e.Message + ",\n";
                return false;
            }
        }

        private void _update(Inventory_IO inventory_io, User user, ref string message)
        {
            try
            {
                inventory_io.UserID = user.Id;
                inventory_io.RecordDate = DateTime.Now;
                _sqlite_helper.Execute(inventory_io.ToUpdate());
                message += inventory_io.GoodsID + "进出库记录更新成功,\n";
            }
            catch (Exception e)
            {
                message += inventory_io.GoodsID + "进出库记录更新失败" + e.Message + ",\n";
            }
        }

        /// <summary>
        /// 根据进出库记录ID删除记录
        /// </summary>
        /// <param name="inventory_io"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool _delete(Inventory_IO inventory_io,User user, ref string message)
        {
            try
            {
                _sqlite_helper.Execute(inventory_io.ToDelete());
                message += "删除进出库记录'" + inventory_io.ID + "'成功!";
                return true;
            }
            catch (Exception e)
            {
                message += "进出库记录'" + inventory_io.ID + "'删除失败" + e.Message + ",\n";
                return false;
            }
        }

        public bool Insert(Inventory_IO inventory_io, User user, ref string message)
        {
            _operation_controller.RecordOperation(user, OperationController.Action.DeleteInventoryIO, inventory_io.ToString());
            return _insert(inventory_io, user, ref message);
        }

        public bool Delete(Inventory_IO inventory_io, User user, ref string message)
        {
            return _delete(inventory_io,user, ref message);
        }

        public bool Delete(IEnumerable<Inventory_IO> list_inventory_io, User user, ref string message)
        {
            foreach (var inventory_io in list_inventory_io)
            {
                _delete(inventory_io, user, ref message);
            }
            return true;
        }

        public double TotalAmount_In(string settleMonth)
        {
            return GetGoodsIO(_sqlite_helper.Query_DataView("select * from inventoryIO where weight>0 and settleMonth=@SettleMonth",
                new SQLiteParameter("@SettleMonth",settleMonth))).Sum(i=>i.Price*i.Weight);
        }

        public double TotalAmount_Out(string settleMonth)
        {
            return GetGoodsIO(_sqlite_helper.Query_DataView("select * from inventoryIO where weight<0 and settleMonth=@SettleMonth",
                new SQLiteParameter("@SettleMonth", settleMonth))).Sum(i => i.Price * i.Weight);
        }
    }
}
