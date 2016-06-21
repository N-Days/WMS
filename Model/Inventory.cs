using WMS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace WMS.Model
{
    class Inventory:IDataObject
    {
        private const String c_insert = "insert into inventory values(null,'@GoodsID',@Price,@Weight,'@SettleMonth','@CalculateDate','@Status')";
        private const String c_update = "update inventory set price=@Price ,weight=@Weight ,calculateDate='@CalculateDate',status='@Status' where goodsId=@GoodsID and settleMonth='@SettleMonth'";
        private const String c_delete = "delete from inventory where id=@ID";

        private int _id;
        private int _goodsid;
        private double _weight;
        private double _price;
        private DateTime _calculatedate;
        private string _settlemonth;
        private string _status;

        public int ID
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

        public int GoodsID
        {
            get
            {
                return this._goodsid;
            }
            set
            {
                this._goodsid = value;
            }
        }

        public double Weight
        {
            get
            {
                return this._weight;
            }
            set
            {
                this._weight = value;
            }
        }

        public double Price
        {
            get
            {
                return this._price;
            }
            set
            {
                this._price = value;
            }
        }

        public DateTime CalculateDate
        {
            get
            {
                return this._calculatedate;
            }
            set
            {
                this._calculatedate = value;
            }
        }

        public string SettleMonth
        {
            get
            {
                return this._settlemonth;
            }
            set
            {
                this._settlemonth = value;
            }
        }

        public string Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }

        public override string ToString()
        {
            return "id:"+ID+",goodsId:"+GoodsID+",weight:"+Weight+",price:"+Price+",calculateDate:"+CalculateDate+",settleMonth:"+SettleMonth+",status:"+Status;
        }

        public SQLiteCommand ToInsert()
        {
            return new SQLiteCommand(c_insert)
            {
                Parameters=
                {
                    new SQLiteParameter("@GoodsID", GoodsID),
                    new SQLiteParameter("@Price", Price),
                    new SQLiteParameter("@Weight", Weight),
                    new SQLiteParameter("@SettleMonth", SettleMonth),
                    new SQLiteParameter("@CalculateDate", CalculateDate.ToString("s")),
                    new SQLiteParameter("@Status", Status),
                }
            };
        }

        public SQLiteCommand ToUpdate()
        {
            return new SQLiteCommand(c_update)
            {
                Parameters=
                {
                    new SQLiteParameter("@GoodsID", GoodsID),
                    new SQLiteParameter("@Price", Price),
                    new SQLiteParameter("@Weight", Weight),
                    new SQLiteParameter("@SettleMonth", SettleMonth),
                    new SQLiteParameter("@CalculateDate", CalculateDate.ToString("s")),
                    new SQLiteParameter("@Status", Status),
                }
            };
        }

        public SQLiteCommand ToDelete()
        {
            if (ID == 0)
                throw new ArgumentException("未指定库存记录编号，无法删除");
            else
            {
                return new SQLiteCommand(c_delete)
                {
                    Parameters=
                    {
                        new SQLiteParameter("@ID", ID)
                    }
                };
            }
        }
    }
}
