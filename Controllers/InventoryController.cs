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
    class InventoryController
    {
        private SqliteHelper _sqlite_helper => GlobalParam.DataBase;
        private OperationController _operation_controller
        {
            get;
            set;
        }
        private GoodsController _goods_controller
        {
            get; set;
        }
        private Inventory_IO_Controller _inventoryio_controller
        {
            get; set;
        }
        public InventoryController()
        {
            _initData();
        }

        private void _initData()
        {
            _operation_controller = new OperationController();
            _goods_controller = new GoodsController();
            _inventoryio_controller = new Inventory_IO_Controller();
        }

        private bool _insert(Inventory goods_Inventory, Model.User user, ref string message)
        {
            try
            {
                _sqlite_helper.Execute(goods_Inventory.ToInsert());
                _operation_controller.RecordOperation(user, OperationController.Action.InsertInventory, goods_Inventory.ToString());
                message += goods_Inventory.GoodsID + "库存记录新增成功,\n";
                return true;
            }
            catch (Exception e)
            {
                message += goods_Inventory.GoodsID + "库存记录新增失败" + e.Message + ",\n";
                return false;
            }
        }

        private bool _insert(IEnumerable<Inventory> goods_inventory_list, User user, ref string message)
        {
            try
            {
                foreach (var goods_inventory in goods_inventory_list)
                {
                    _insert(goods_inventory, user, ref message);
                }
                message += "执行完毕\n";
                return true;
            }
            catch (Exception e)
            {
                message += "执行失败" + e.Message + "\n";
                return false;
            }
        }

        private bool _update(Inventory goods_inventory, User user, ref string message)
        {
            try
            {
                _sqlite_helper.Execute(goods_inventory.ToUpdate());
                _operation_controller.RecordOperation(user, OperationController.Action.UpdateGoods, goods_inventory.ToString());
                message += goods_inventory.GoodsID + "库存记录已更新\n";
                return true;
            }
            catch (Exception e)
            {
                message += goods_inventory.GoodsID + "库存记录更新失败" + e.Message + "\n";
                return false;
            }
        }

        private void Initialize()
        {
            throw new NotImplementedException();
            //List<Model.Goods> GoodsList = new GoodsController().GetAllGoods();
            //string settlemonth = DateTime.Now.AddMonths(-1).ToString("yyyy-MM");
            //DataView dv = _sqlite_helper.Query_DataView("select * from inventory where settleMonth='" + settlemonth + "'");
            //if (dv.Count > 0) return;
            //List<string> sql_list = new List<string>();
            //try
            //{
            //    _sqlite_helper.BeginTransaction();
            //    foreach (var goods in GoodsList)
            //    {
            //        _sqlite_helper.Execute("insert into inventory values(null,'" + goods.ID + "',0.0,0.0,'" + settlemonth + "','" + DateTime.Now.ToString("s") + "','" + Status.settled + "')");
            //    }
            //}
            //finally
            //{
            //    _sqlite_helper.EndTransaction();
            //}
        }

        /// <summary>
        /// 检查是否存在运行中月份及检查库存状态
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool _checkrunningmonth(User user, ref string message)
        {
            var settlemonth_last = TimeController.GetLastSettleMonth();
            var settlemonth_running = TimeController.GetRunningMonth();

            var list_goods = new GoodsController().GetAllGoods();
            var commands = new List<SQLiteCommand>();
            var list_inventory_last = GetInventoryBySettleMonth(settlemonth_last);
            var list_inventory_current = GetInventoryBySettleMonth(settlemonth_running);

            if (string.IsNullOrEmpty(settlemonth_running))
            {
                #region 若不存在运行中月份
                settlemonth_running = TimeController.GetNextMonth(settlemonth_last);
                using (var delete = new SQLiteCommand("delete from inventory where status='running'"))
                {
                    _sqlite_helper.Execute(delete);
                }
                list_inventory_current = GetInventoryBySettleMonth(settlemonth_running);
                foreach (var goods in list_goods)
                {
                    var inventory_last = list_inventory_last.FirstOrDefault(i => i.GoodsID == goods.ID);
                    var inventory_current = list_inventory_current.FirstOrDefault(i => i.GoodsID == goods.ID);
                    if (inventory_last != null && inventory_current == null)
                    {
                        commands.Add(new Inventory
                        {
                            GoodsID = goods.ID,
                            Price = inventory_last.Price,
                            Weight = inventory_last.Weight,
                            SettleMonth = settlemonth_running,
                            CalculateDate = DateTime.Now,
                            Status = Status.running
                        }.ToInsert());
                    }
                    else if (inventory_last == null && inventory_current == null)
                    {

                        commands.Add(new Inventory
                        {
                            GoodsID = goods.ID,
                            Price = 0.0,
                            Weight = 0.0,
                            SettleMonth = settlemonth_last,
                            CalculateDate = DateTime.Now,
                            Status = Status.locked
                        }.ToInsert());
                        commands.Add(new Inventory
                        {
                            GoodsID = goods.ID,
                            Price = 0.0,
                            Weight = 0.0,
                            SettleMonth = settlemonth_running,
                            CalculateDate = DateTime.Now,
                            Status = Status.running
                        }.ToInsert());
                    }
                    else
                    {
                        //Nothing to do.
                    }
                }
                commands.Add(_operation_controller.GetOperationCommand(user, OperationController.Action.RunningNewMonth, "运行" + settlemonth_running));
                try
                {
                    commands.ForEach(i => _sqlite_helper.Execute(i));
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
                #endregion
            }
            else
            {
                #region 若存在运行中月份
                if (!TimeController.GetNextMonth(settlemonth_last).Equals(settlemonth_running))
                {
                    message += "最后一个已结算的月份'" + settlemonth_last + "'与运行中的月份'" + settlemonth_running + "'存在间隔,无法通过计算检查";
                    return false;
                }
                else
                {
                    if (list_inventory_current.Count() == list_goods.Count())
                    {
                        return true;
                    }
                    else
                    {
                        var linq = from goods in list_goods
                                   where list_inventory_current.FirstOrDefault(i => i.GoodsID == goods.ID) == null
                                   select new Inventory
                                   {
                                       GoodsID = goods.ID,
                                       Price = 0.0,
                                       Weight = 0.0,
                                       SettleMonth = settlemonth_running,
                                       CalculateDate = DateTime.Now,
                                       Status = Status.locked
                                   }.ToInsert();
                        try
                        {
                            linq.ToList().ForEach(i => _sqlite_helper.Execute(i));
                            return true;
                        }
                        catch (Exception e)
                        {
                            return false;
                        }
                    }
                }
                #endregion
            }
        }

        /// <summary>
        /// 结算当前运行中的月份
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool _settleRunningMonth(User user, ref string message)
        {
            var currentmonth = TimeController.GetRunningMonth();
            if (string.IsNullOrEmpty(currentmonth))
            {
                message += "未能找到正确的运行中月份,无法计算";
                return false;
            }
            var nextmonth = TimeController.GetNextMonth(currentmonth);

            var inventorys_current = GetInventoryBySettleMonth(currentmonth);
            var inventorys_next = GetInventoryBySettleMonth(nextmonth);
            var commands = new List<SQLiteCommand>();

            //当没找到下月库存记录时，就不需要逐个货物查找是否存在下月记录了
            if (inventorys_next == null || inventorys_next.Count() == 0)
            {
                foreach (var inventory_current in inventorys_current)
                {
                    //只有当库存记录正在运行中，才修改库存状态
                    if (inventory_current.Status == Status.running)
                    {
                        inventory_current.Status = Status.settled;
                        inventory_current.CalculateDate = DateTime.Now;
                        commands.Add(inventory_current.ToUpdate());
                    }
                    commands.Add(new Inventory
                    {
                        GoodsID = inventory_current.GoodsID,
                        Price = inventory_current.Price,
                        Weight = inventory_current.Weight,
                        SettleMonth = nextmonth,
                        CalculateDate = DateTime.Now,
                        Status = Status.running
                    }.ToInsert());
                }
            }
            else
            {
                foreach (var inventory_current in inventorys_current)
                {
                    //只有当库存记录正在运行中，才修改库存状态
                    if (inventory_current.Status == Status.running)
                    {
                        inventory_current.Status = Status.settled;
                        inventory_current.CalculateDate = DateTime.Now;
                        commands.Add(inventory_current.ToUpdate());
                    }
                    var inventory_next = inventorys_next.FirstOrDefault(i => i.GoodsID == inventory_current.GoodsID);
                    //只有不存在下月记录时插入记录
                    if (inventory_next == null)
                    {
                        commands.Add(new Inventory
                        {
                            GoodsID = inventory_current.GoodsID,
                            Price = inventory_current.Price,
                            Weight = inventory_current.Weight,
                            SettleMonth = nextmonth,
                            CalculateDate = DateTime.Now,
                            Status = Status.running
                        }.ToInsert());
                    }
                }
            }
            commands.Add(_operation_controller.GetOperationCommand(user, OperationController.Action.SettleInventory, "结算" + currentmonth + "库存"));
            try
            {
                _sqlite_helper.Execute(commands);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 计算当前运行中月份库存
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Calculate(User user, ref string message)
        {
            var currentmonth = TimeController.GetRunningMonth();
            var settlemonth = TimeController.GetLastSettleMonth();
            var inventorys_runing = GetInventoryBySettleMonth(currentmonth);
            var inventorys_settle = GetInventoryBySettleMonth(settlemonth);
            var inventoryios = _inventoryio_controller.GetGoodsIOBySettleMonth(currentmonth);
            var goods_list = _goods_controller.GetAllGoods();

            var commands = new List<SQLiteCommand>();

            foreach (var goods in goods_list)
            {
                var inventory_running = inventorys_runing.FirstOrDefault(i => i.GoodsID == goods.ID);
                var inventory_settle = inventorys_settle.FirstOrDefault(i => i.GoodsID == goods.ID);
                var inventoryios_current = inventoryios.Where(i => i.GoodsID == goods.ID);
                if (inventory_settle == null)
                {
                    #region 若不存在已结算库存
                    //增加基础库存数据
                    commands.Add(new Inventory
                    {
                        GoodsID = goods.ID,
                        Price = 0.0,
                        Weight = 0.0,
                        SettleMonth = settlemonth,
                        CalculateDate = DateTime.Now,
                        Status = Status.locked
                    }.ToInsert());

                    if (inventory_running == null)
                    {
                        //若不存在当前库存，则初始化库存记录
                        inventory_running = new Inventory
                        {
                            GoodsID = goods.ID,
                            Price = 0.0,
                            Weight = 0.0,
                            SettleMonth = currentmonth,
                            CalculateDate = DateTime.Now,
                            Status = Status.running
                        };
                    }
                    else
                    {
                        if (inventory_running.Status.Equals(Status.locked))
                            continue;
                        //若存在当前库存，则归零价格及重量
                        inventory_running.Price = 0.0;
                        inventory_running.Weight = 0.0;
                        inventory_running.CalculateDate = DateTime.Now;
                    }
                    #endregion
                }
                else
                {
                    #region 若存在已结算库存
                    if (inventory_running == null)
                    {
                        //若不存在当前库存，则初始化库存记录
                        inventory_running = new Inventory
                        {
                            GoodsID = goods.ID,
                            Price = inventory_settle.Price * inventory_settle.Weight,
                            Weight = inventory_settle.Weight,
                            SettleMonth = currentmonth,
                            CalculateDate = DateTime.Now,
                            Status = Status.running
                        };
                    }
                    else
                    {
                        if (inventory_running.Status.Equals(Status.locked))
                            continue;
                        //若存在当前库存，则归零价格及重量
                        inventory_running.Price = inventory_settle.Price * inventory_settle.Weight;
                        inventory_running.Weight = inventory_settle.Weight;
                        inventory_running.CalculateDate = DateTime.Now;
                    }
                    #endregion
                }

                //计算进出库记录，将库存记录价格临时当作价格缓存
                foreach (var inventoryio in inventoryios_current.Where(i => i.Weight > 0))
                {
                    inventory_running.Weight += inventoryio.Weight;
                    inventory_running.Price += inventoryio.Weight * inventoryio.Price;
                }
                //计算最新库存价格
                if (inventory_running.Weight != 0)
                    inventory_running.Price = inventory_running.Price / inventory_running.Weight;
                foreach (var inventoryio in inventoryios_current.Where(i => i.Weight < 0))
                {
                    inventory_running.Weight += inventoryio.Weight;
                    inventoryio.Price = inventory_running.Price;
                    commands.Add(inventoryio.ToUpdate());//将出库记录的价格改为最新的库存价格
                }

                if (inventory_running.ID == 0)
                    commands.Add(inventory_running.ToInsert());//若不存在当前库存，则新增记录
                else
                    commands.Add(inventory_running.ToUpdate());//若存在当前库存，则更新记录
            }

            try
            {
                _sqlite_helper.Execute(commands);
                _operation_controller.RecordOperation(user, OperationController.Action.CalculateInventory, "计算月份:" + currentmonth);
                return true;
            }
            catch (Exception e)
            {
                message += "计算月份:" + currentmonth + "时发生错误," + e.ToString();
                return false;
            }
        }

        /// <summary>
        /// 结算当前运行中库存
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Settle(User user, ref string message)
        {
            if (!Calculate(user, ref message))
            {
                return false;
            }

            if (!_settleRunningMonth(user, ref message))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 根据结算月份获取库存
        /// </summary>
        /// <param name="settlemonth"></param>
        /// <returns></returns>
        public IEnumerable<Inventory> GetInventoryBySettleMonth(string settlemonth)
        {
            return GetInventory(_sqlite_helper.Query_DataView("select * from inventory where settleMonth=@SettleMonth",
                new SQLiteParameter("@SettleMonth", settlemonth)));
        }

        /// <summary>
        /// 获取最后一个月的库存情况
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Inventory> GetLastMonthInventory()
        {
            return GetInventory(_sqlite_helper.Query_DataView(new SQLiteCommand("select * from inventory where settleMonth in (select distinct settleMonth from inventory where status <> 'running' order by settleMonth desc limit 1)")));
        }

        /// <summary>
        /// 将包含库存信息的dataview转换为库存信息队列
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        private IEnumerable<Inventory> GetInventory(DataView dv)
        {
            foreach (DataRowView drv in dv)
            {
                yield return new Inventory
                {
                    ID = Convert.ToInt32(drv["id"].ToString()),
                    GoodsID = Convert.ToInt32(drv["goodsId"].ToString()),
                    Price = Convert.ToDouble(drv["price"].ToString()),
                    Weight = Convert.ToDouble(drv["weight"].ToString()),
                    SettleMonth = drv["settleMonth"].ToString(),
                    CalculateDate = Convert.ToDateTime(drv["calculateDate"].ToString()),
                    Status = drv["status"].ToString(),
                };
            }
        }

        /// <summary>
        /// 根据货物编号和结算月份获取货物库存
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="settleMonth"></param>
        /// <returns></returns>
        public Inventory GetGoodsInventory(int goodsId, string settleMonth)
        {
            using (var dv = _sqlite_helper.Query_DataView("select * from inventory where goodsId=@GoodsID and settleMonth=@SettleMonth",
                new[] {
                    new SQLiteParameter("@GoodsID",goodsId),
                    new SQLiteParameter("@SettleMonth",settleMonth),
                }))
            {
                return GetInventory(dv).FirstOrDefault();
            }
        }

        /// <summary>
        /// 根据货物名称和结算月份获取货物库存
        /// </summary>
        /// <param name="goodsName"></param>
        /// <param name="settleMonth"></param>
        /// <returns></returns>
        public Inventory GetGoodsInventoryByGoodsName(string goodsName, string settleMonth)
        {
            DataView dv = null;
            if (string.IsNullOrEmpty(settleMonth))
            {
                dv = _sqlite_helper.Query_DataView("select * from inventory,goods where goods.id=inventory.goodsId and goodsName=@GoodsName order by settleMonth desc",
                    new SQLiteParameter("@GoodsName", goodsName));
            }
            else
            {
                dv = _sqlite_helper.Query_DataView("select * from inventory,goods where goods.id=inventory.goodsId and goodsName=@GoodsName and settleMonth=@SettleMonth",
                    new[]
                    {
                        new SQLiteParameter("@GoodsName",goodsName),
                        new SQLiteParameter("@SettleMonth",settleMonth),
                    });
            }
            using (dv)
                return GetInventory(dv).FirstOrDefault();
        }

        /// <summary>
        /// 根据货物编号获取最近一个月的库存记录
        /// </summary>
        /// <param name="goodsid"></param>
        /// <returns></returns>
        public Inventory GetInventoryByGoodsId(int goodsid)
        {
            using (var dv = _sqlite_helper.Query_DataView("select * from inventory where goodsId=@GoodsID and settleMonth in (select distinct settleMonth from inventory order by settleMonth desc)",
                new SQLiteParameter("@GoodsID", goodsid)))
                return GetInventory(dv).FirstOrDefault();
        }

        public bool Insert(Inventory goods_Inventory, User user, ref string message)
        {
            Model.Inventory goods_inventory_db = GetGoodsInventory(goods_Inventory.GoodsID, goods_Inventory.SettleMonth);
            if (goods_inventory_db == null)
            {
                return this._insert(goods_Inventory, user, ref message);
            }
            else
            {
                message += goods_Inventory.GoodsID + "库存记录已存在,新增失败,\n";
                return false;
            }
        }

        public bool Insert(IEnumerable<Inventory> goods_inventory_list, User user, ref string message)
        {
            return this._insert(goods_inventory_list, user, ref message);
        }

        public bool Update(Inventory goods_Inventory, User user, ref string message)
        {
            Model.Inventory goods_inventory_db = GetGoodsInventory(goods_Inventory.GoodsID, goods_Inventory.SettleMonth);
            if (goods_inventory_db != null)
            {
                return this._update(goods_Inventory, user, ref message);
            }
            else
            {
                message += goods_Inventory.GoodsID + "库存记录更新失败\n";
                return false;
            }
        }

        public bool InsertOrUpdate(Inventory goods_inventory, User user, ref string message)
        {
            var goods_inventory_db = GetGoodsInventory(goods_inventory.GoodsID, goods_inventory.SettleMonth);
            if (goods_inventory_db == null)
            {
                return this._insert(goods_inventory, user, ref message);
            }
            else
            {
                goods_inventory.ID = goods_inventory_db.ID;
                return this._update(goods_inventory, user, ref message);
            }
        }

        public bool InsertOrUpdate(IEnumerable<Inventory> inventory_list, User user, ref string message)
        {
            List<string> sql_list = new List<string>();
            foreach (var inventory in inventory_list)
            {
                Model.Inventory inventory_db = GetGoodsInventory(inventory.GoodsID, inventory.SettleMonth);
                if (inventory_db == null)
                {
                    this._insert(inventory, user, ref message);
                }
                else
                {
                    this._update(inventory, user, ref message);
                }
            }
            return true;
        }

        /// <summary>
        /// 根据结算月份获取库存总值
        /// </summary>
        /// <param name="settleMonth"></param>
        /// <returns></returns>
        public double TotalAmount_Inventory(string settleMonth)
        {
            var inventory_list = GetInventory(_sqlite_helper.Query_DataView("select * from inventory where settleMonth=@SettleMonth",
                new SQLiteParameter("@SettleMonth", settleMonth)));
            double totalamount = 0;
            foreach (var inventory in inventory_list)
            {
                totalamount += inventory.Price * inventory.Weight;
            }
            return totalamount;
        }

        public struct Status
        {
            public const string settled = "settled";
            public const string running = "running";
            public const string locked = "locked";
        }
    }
}
