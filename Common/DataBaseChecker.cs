using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WMS.Helper; 

namespace WMS.Common
{
    class DataBaseChecker
    {
        private SqliteHelper _sqlite_helper
        {
            get; set;
        }

        public DataBaseChecker()
        {
            _checkpath();
            _initData();
        }

        private void _initData()
        {
            _sqlite_helper = new SqliteHelper();
        }

        private void _checkpath()
        {
            var filepath = string.Format("{0}{1}", GlobalParam.ApplicationPath, "\\App_Data");
            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(filepath);
        }

        private void _checktable()
        {
            _sqlite_helper.Execute(new System.Data.SQLite.SQLiteCommand("create table if not exists inventory(id integer primary key autoincrement, goodsId integer, price real,weight real,settleMonth varchar(7),calculateDate datetime,status varchar(10));"));
            _sqlite_helper.Execute(new System.Data.SQLite.SQLiteCommand("create table if not exists inventoryIO(id integer primary key autoincrement, goodsId integer, price real,weight real,recordDate datetime,settleMonth varchar(7),userId integer);"));
            _sqlite_helper.Execute(new System.Data.SQLite.SQLiteCommand("create table if not exists goods(id integer primary key autoincrement,goodsName varchar(7),color varchar(10),goodsType varchar(12),recordDate datetime,userId integer);"));
            _sqlite_helper.Execute(new System.Data.SQLite.SQLiteCommand("create table if not exists user(id integer primary key autoincrement,accountNumber varchar(50),password varchar(20), userName varchar(10),enrollDate varchar(20),userType integer,createId integer,enable integer);"));
            _sqlite_helper.Execute(new System.Data.SQLite.SQLiteCommand("create table if not exists user_operation(id integer primary key autoincrement,userId integer,operation varchar(50), content varchar(100),operateDate datetime);"));
        }

        public void Check()
        {
            _checktable();
        }
    }
}
