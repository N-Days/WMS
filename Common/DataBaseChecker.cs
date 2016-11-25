using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WMS.Helper;
using System.Data.SQLite;

namespace WMS.Common
{
    class DataBaseChecker
    {
        public DataBaseChecker()
        {
        }

        private void _checkpath()
        {
            var filepath = string.Format("{0}{1}", GlobalParam.ApplicationPath, "\\App_Data");
            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(filepath);
        }

        private void _checktable()
        {
            var list = new List<SQLiteCommand>()
            {
                new SQLiteCommand("create table if not exists inventory(id integer primary key autoincrement, goodsId integer, price real,weight real,settleMonth varchar(7),calculateDate datetime,status varchar(10));"),
                new SQLiteCommand("create table if not exists inventoryIO(id integer primary key autoincrement, goodsId integer, price real,weight real,recordDate datetime,settleMonth varchar(7),userId integer);"),
                new SQLiteCommand("create table if not exists goods(id integer primary key autoincrement,goodsName varchar(7),color varchar(10),goodsType varchar(12),recordDate datetime,userId integer);"),
                new SQLiteCommand("create table if not exists user(id integer primary key autoincrement,accountNumber varchar(50),password varchar(20), userName varchar(10),enrollDate varchar(20),userType integer,createId integer,enable integer);"),
                new SQLiteCommand("create table if not exists user_operation(id integer primary key autoincrement,userId integer,operation varchar(50), content varchar(100),operateDate datetime);"),
                new SQLiteCommand(@"CREATE VIEW if not exists MonthReport AS
                                        SELECT goods.goodsName AS 货物编号,
                                               round(ifnull(lastmonth.weight, 0), 2) AS 月初重量,
                                               round(ifnull(lastmonth.price, 0), 2) AS 月初单价,
                                               round(ifnull( (lastmonth.weight * lastmonth.price), 0), 2) AS 月初总值,
                                               round(ifnull(goodin.weight_in, 0), 2) AS 入库重量,
                                               round(ifnull(goodin.price_in, 0), 2) AS 入库单价,
                                               round(ifnull(goodin.total_in, 0), 2) AS 入库总值,
                                               round(ifnull(goodout.weight_out, 0), 2) AS 出库重量,
                                               round(ifnull( (lastmonth.weight * lastmonth.price + ifnull(goodin.total_in, 0) ) / (ifnull(lastmonth.weight, 0) + ifnull(goodin.weight_in, 0) ), 0), 2) AS 出库单价,
                                               round(ifnull( (lastmonth.weight * lastmonth.price + ifnull(goodin.total_in, 0) ) / (ifnull(lastmonth.weight, 0) + ifnull(goodin.weight_in, 0) ) * goodout.weight_out, 0), 2) AS 出库总值,
                                               round(ifnull(current.weight, 0), 2) AS 月末重量,
                                               round(ifnull(current.price, 0), 2) AS 月末单价,
                                               round(ifnull(current.weight * current.price, 0), 2) AS 月末总值,
                                               goods.goodsType,
                                               current.settleMonth
                                          FROM goods
                                               CROSS JOIN
                                               (
                                                   SELECT DISTINCT settleMonth
                                                     FROM inventory
                                                    WHERE status <> 'runing'
                                               )
                                               AS time
                                               LEFT JOIN
                                               inventory AS current ON current.goodsId = goods.id AND
                                                                       current.settleMonth = time.settleMonth
                                               LEFT JOIN
                                               (
                                                   SELECT goodsId,
                                                          sum(weight) AS weight_in,
                                                          sum(weight * price) / sum(weight) AS price_in,
                                                          sum(weight * price) AS total_in,
                                                          settleMonth
                                                     FROM inventoryio
                                                    WHERE weight > 0
                                                    GROUP BY goodsId,
                                                             settleMonth
                                               )
                                               AS goodin ON goodin.goodsId = goods.id AND
                                                            goodin.settleMonth = time.settleMonth
                                               LEFT JOIN
                                               (
                                                   SELECT goodsId,
                                                          abs(sum(weight) ) AS weight_out,
                                                          settleMonth
                                                     FROM inventoryio
                                                    WHERE weight < 0
                                                    GROUP BY goodsId,
                                                             settleMonth
                                               )
                                               AS goodout ON goodout.goodsId = goods.id AND
                                                             goodout.settleMonth = time.settleMonth
                                               LEFT JOIN
                                               inventory AS lastmonth ON lastmonth.goodsId = goods.id
                                         WHERE lastmonth.settleMonth = strftime('%Y-%m', date(time.settleMonth || '-01', '-1 month') )
                                         ORDER BY current.settleMonth; ")
            };
            GlobalParam.DataBase.Execute(list);
        }

        public void Check()
        {
            _checkpath();
            _checktable();
        }
    }
}
