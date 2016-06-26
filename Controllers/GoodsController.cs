using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using WMS.Helper;
using WMS.Model;

namespace WMS.Controllers
{
    class GoodsController : IDisposable
    {
        private SqliteHelper _sqlite_helper
        {
            get;
            set;
        }
        private OperationController _operation_controller
        {
            get;
            set;
        }

        public GoodsController()
        {
            _initData();
        }

        private void _initData()
        {
            _sqlite_helper = new SqliteHelper();
            _operation_controller = new OperationController();
        }

        private IEnumerable<Goods> _getgoods(DataView dv)
        {
            foreach (DataRowView drv in dv)
            {
                yield return new Goods
                {
                    ID = Convert.ToInt32(drv["id"].ToString()),
                    GoodsName = drv["goodsName"].ToString(),
                    GoodsType = drv["goodsType"].ToString(),
                    Color = drv["color"].ToString(),
                    RecordDate = Convert.ToDateTime(drv["recordDate"].ToString()),
                    UserID = Convert.ToInt32(drv["userId"].ToString())
                };
            }
        }

        private bool _insert(Goods goods, Model.User user, ref string message)
        {
            using (var command = goods.ToInsert())
            {
                command.Parameters.AddRange(new[]
                {
                    new SQLiteParameter("@RecordDate", DateTime.Now.ToString("s")),
                    new SQLiteParameter("@UserID", user.Id),
                });
                _sqlite_helper.Execute(command);
                _operation_controller.RecordOperation(user, OperationController.Action.InsertGoods, goods.ToString());
                message += goods.GoodsName + "新增成功,\n";
                return true;
            }
        }

        private bool _update(Goods goods, User user, ref string message)
        {
            _sqlite_helper.Execute(goods.ToUpdate());
            _operation_controller.RecordOperation(user, OperationController.Action.UpdateGoods, goods.ToString());
            message += goods.GoodsName + "更新成功,\n";
            return true;
        }

        public IEnumerable<Goods> GetAllGoods()
        {
            using (var command = new SQLiteCommand("select * from goods"))
                return _getgoods(_sqlite_helper.Query_DataView(command));
        }

        public Goods GetGoodsById(int goodsId)
        {
            var command = new SQLiteCommand("select * from goods where id=@GoodsID");
            command.Parameters.Add(new SQLiteParameter("@GoodsID", goodsId));
            using (command)
            using (var dv = _sqlite_helper.Query_DataView(command))
            {
                return _getgoods(dv).FirstOrDefault();
            }
        }

        public Goods GetGoodsByGoodsName(string goodsName)
        {
            var command = new SQLiteCommand("select * from goods where goodsName=@GoodsName");
            command.Parameters.Add(new SQLiteParameter("@GoodsName", goodsName));
            using (command)
            using (var dv = _sqlite_helper.Query_DataView(command))
            {
                return _getgoods(dv).FirstOrDefault();
            }
        }

        public IEnumerable<Goods> GetGoodsByType(string goodsType)
        {
            var command = new SQLiteCommand("select * from goods where goodsType=@GoodsType");
            command.Parameters.Add(new SQLiteParameter("@GoodsType", goodsType));
            using (command)
                return _getgoods(_sqlite_helper.Query_DataView(command));
        }

        public bool Insert(Goods goods, User user, ref string message)
        {
            var goods_db = GetGoodsByGoodsName(goods.GoodsName);
            if (goods_db == null)
            {
                return _insert(goods, user, ref message);
            }
            else
            {
                message += goods.GoodsName + "存在同名货物,无法新增,\n";
                return false;
            }
        }

        public bool Insert(IEnumerable<Goods> goods_list, User user, ref string message)
        {
            try
            {
                foreach (var goods in goods_list)
                {
                    var goods_db = GetGoodsByGoodsName(goods.GoodsName);
                    if (goods_db == null)
                    {
                        if (!_insert(goods, user, ref message))
                            return false;
                    }
                    else
                    {
                        message += goods.GoodsName + "存在同名货物,无法新增,\n";
                        return false;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Goods goods, User user, ref string message)
        {
            var goods_db = GetGoodsByGoodsName(goods.GoodsName);
            if (goods_db != null)
            {
                return _update(goods, user, ref message);
            }
            else
            {
                message += goods.GoodsName + "更新失败,数据库中不存在该货物\n";
                return false;
            }
        }

        public bool InsertOrUpdate(Goods goods, User user, ref string message)
        {
            var goods_db = GetGoodsByGoodsName(goods.GoodsName);
            if (goods_db != null)
            {
                return _update(goods, user, ref message);
            }
            else
            {
                return _insert(goods, user, ref message);
            }
        }

        public bool InsertOrUpdate(IEnumerable<Goods> goods_list, User user, ref string message)
        {
            foreach (var goods in goods_list)
            {
                var goods_db = GetGoodsById(goods.ID);
                if (goods_db != null)
                {
                    _update(goods, user, ref message);
                }
                else
                {
                    _insert(goods, user, ref message);
                }
            }
            return true;
        }

        public void Dispose()
        {

        }

        public struct GoodsType
        {
            public const string material = "material";
            public const string intermediate = "intermediate";
        }
    }
}
