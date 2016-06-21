using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace HeTai.Controllers
{
    class SqLiteController
    {
        private string _databasepath = "Data Source =" + Environment.CurrentDirectory + "\\App_Data\\hetaidatabase.db";
        //private string _databasepath = "Data Source =" + Environment.CurrentDirectory + "\\hetaidatabase.db;Password=123456";

        public SqLiteController()
        {
            //CreateTable();
            //Excute("insert into user values('1','qmareq','984236','高旭东','" + DateTime.Now.ToString("s") + "','1',1,'1')");
        }

        /// <summary>
        /// 建立系统用表
        /// </summary>
        private void CreateTable()
        {
            string[] sql_array = new string[] {
                "create table if not exists inventory(id integer primary key autoincrement, goodsId integer, price real,weight real,settleMonth varchar(7),calculateDate datetime,status varchar(10))",
                "create table if not exists inventoryIO(id integer primary key autoincrement, goodsId integer, price real,weight real,recordDate datetime,settleMonth varchar(7),userId integer)",
                "create table if not exists goods(id integer primary key autoincrement,goodsName varchar(7),color varchar(10),goodsType varchar(12),recordDate datetime,userId integer)",
                "create table if not exists user(id integer primary key autoincrement,accountNumber varchar(50),password varchar(20), userName varchar(10),enrollDate varchar(20),userType integer,createId integer,enable integer)",
                "create table if not exists user_operation(id integer primary key autoincrement,userId integer,operation varchar(50), content varchar(100),operateDate datetime)"
            };
            Excute(sql_array);
        }

        public int Excute(string sql_str)
        {
            SQLiteConnection conn = new SQLiteConnection(_databasepath);
            SQLiteCommand command = new SQLiteCommand(sql_str, conn);

            int LineCount = 0;
            conn.Open();
            try
            {
                LineCount = command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception e)
            {
                conn.Close();
                conn.Dispose();
                throw new Exception("执行数据库指令时发生错误" + e.Message);
            }
            return LineCount;
        }

        public void Excute(string[] sql_array)
        {
            SQLiteConnection conn = new SQLiteConnection(_databasepath);
            conn.Open();
            SQLiteTransaction tran = conn.BeginTransaction();
            try
            {
                for (int i = 0; i < sql_array.Length; i++)
                {
                    SQLiteCommand command = new SQLiteCommand(sql_array[i], conn);
                    command.Transaction = tran;
                    command.ExecuteNonQuery();
                }
                tran.Commit();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception e)
            {
                tran.Rollback();
                conn.Close();
                conn.Dispose();
                throw new Exception("执行事务发生错误" + e.Message);
            }
        }

        public DataSet Query_DataSet(string sql_str)
        {
            SQLiteConnection conn = new SQLiteConnection(_databasepath);
            SQLiteCommand command = new SQLiteCommand(sql_str, conn);
            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter(command);
            DataSet ds = new DataSet();

            conn.Open();
            try
            {
                dataadapter.Fill(ds);
                conn.Close();
                conn.Dispose();
            }
            catch(Exception e)
            {
                conn.Close();
                conn.Dispose();
                throw new Exception("查询数据库发生错误" + e.Message);
            }
            return ds;
        }

        public DataView Query_DataView(string sql_str)
        {
            return Query_DataSet(sql_str).Tables[0].DefaultView;
        }
    }
}
