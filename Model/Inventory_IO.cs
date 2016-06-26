using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using WMS.Interface;

namespace WMS.Model
{
    class Inventory_IO:IDataObject
    {
        private const String c_insert = "insert into inventoryIO values(null,@GoodsID,@Price,@Weight,@RecordDate,@SettleMonth,@UserID)";
        private const String c_update = "update inventoryIO set goodsId=@GoodsID,price=@Price,weight=@Weight,recordDate=@RecordDate,settleMonth=@SettleMonth,userId=@UserID where id=@ID";
        private const String c_delete = "delete from inventoryIO where ID=@ID";


        public int ID
        {
            get;
            set;
        }

        public int GoodsID
        {
            get;
            set;
        }

        public double Weight
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }

        public DateTime RecordDate
        {
            get;
            set;
        }

        public string SettleMonth
        {
            get;
            set;
        }

        public int InventoryId
        {
            get;
            set;
        }

        public int UserID
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "id:"+ID+",goodsId:"+GoodsID+",weight:"+Weight+",price:"+Price+",recordDate:"+RecordDate.ToString()+",settleMonth:"+SettleMonth+",userId:"+UserID+"";
        }

        public SQLiteCommand ToInsert()
        {
            return new SQLiteCommand(c_insert)
            {
                Parameters =
                {
                    new SQLiteParameter("@GoodsID",GoodsID),
                    new SQLiteParameter("@Price",Price),
                    new SQLiteParameter("@Weight",Weight),
                    new SQLiteParameter("@RecordDate",RecordDate.ToString("s")),
                    new SQLiteParameter("@SettleMonth",SettleMonth),
                    new SQLiteParameter("@UserID",UserID),
                }
            };
        }

        public SQLiteCommand ToUpdate()
        {
            if (ID == 0)
                throw new ArgumentException("进出库记录编号错误,无法执行");
            return new SQLiteCommand(c_update)
            {
                Parameters =
                {
                    new SQLiteParameter("@ID",ID),
                    new SQLiteParameter("@GoodsID",GoodsID),
                    new SQLiteParameter("@Price",Price),
                    new SQLiteParameter("@Weight",Weight),
                    new SQLiteParameter("@RecordDate",RecordDate.ToString("s")),
                    new SQLiteParameter("@SettleMonth",SettleMonth),
                    new SQLiteParameter("@UserID",UserID),
                }
            };
        }

        public SQLiteCommand ToDelete()
        {
            if (ID == 0)
                throw new ArgumentException("进出库记录编号错误,无法执行");
            return new SQLiteCommand(c_delete)
            {
                Parameters =
                {
                    new SQLiteParameter("@ID",ID),
                }
            };
        }
    }
}
