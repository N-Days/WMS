using WMS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace WMS.Model
{
    class Goods : IDataObject
    {
        private int _id;
        private string _goodsname = "";
        private string _color = "";
        private string _goodstype = "";
        private DateTime _recorddate;
        private int _userid;

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

        public string GoodsName
        {
            get
            {
                return this._goodsname;
            }
            set
            {
                this._goodsname = value;
            }
        }

        public string Color
        {
            get
            {
                return this._color;
            }
            set
            {
                this._color = value;
            }
        }

        public string GoodsType
        {
            get
            {
                return this._goodstype;
            }
            set
            {
                this._goodstype = value;
            }
        }

        public DateTime RecordDate
        {
            get
            {
                return this._recorddate;
            }
            set
            {
                this._recorddate = value;
            }
        }

        public int UserID
        {
            get
            {
                return this._userid;
            }
            set
            {
                this._userid = value;
            }
        }

        public override string ToString()
        {
            return "id:" + ID + ",goodsName:" + GoodsName + ",color:" + Color + ",goodsType:" + GoodsType + ",recordDate:" + RecordDate + ",userId:" + UserID + "";
        }

        public SQLiteCommand ToInsert()
        {
            var command = new SQLiteCommand("insert into goods values(null,'@GoodsName','@Color','@GoodsType','@RecordDate','@UserID')");
            command.Parameters.AddRange(new[]
            {
                new SQLiteParameter("@ID", ID),
                new SQLiteParameter("@GoodsName", GoodsName),
                new SQLiteParameter("@Color", Color),
                new SQLiteParameter("@GoodsType", GoodsType),
            });
            return command;
        }

        public SQLiteCommand ToUpdate()
        {
            var command = new SQLiteCommand("update goods set goodsName='@GoodsName', goodsType='@GoodsType',color='@Color',recordDate='@RecordDate',userId=@UserID where id=@ID");
            command.Parameters.AddRange(new[]
            {
                new SQLiteParameter("@ID", ID),
                new SQLiteParameter("@GoodsName", GoodsName),
                new SQLiteParameter("@Color", Color),
                new SQLiteParameter("@GoodsType", GoodsType),
                new SQLiteParameter("@RecordDate", RecordDate.ToString("s")),
                new SQLiteParameter("@UserID", UserID),
            });
            return command;
        }

        public SQLiteCommand ToDelete()
        {
            throw new NotImplementedException();
        }

    }
}
