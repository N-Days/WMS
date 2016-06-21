using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WMS
{
    class DB
    {
        //数据库连接字符串
        private string DBstr;

        public DB(string server=".",string uid="sa",string pwd="sql",string database="WMSStorage")
        {
            DBstr = string.Format("server={0};uid={1};pwd={2};database={3}", server, uid, pwd, database);
            if (!CheckDatabase())
            {
            }
        }

        private bool CheckDatabase()
        {
            DataView dv_Database = GetDv("use master select * from sys.databases where name='db_WMS'");
            if (dv_Database.Table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CreateDatabase()
        {
        }

        private void CreateDatabaseTable()
        {
            string[] createtable = new string[] { };
        }

        //执行一个非查询的数据库操作
        public int Execute(string NonquerySql, bool DebugFlag)
        {
            SqlConnection conn = new SqlConnection(DBstr);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = NonquerySql;
            conn.Open();
            int n = 0;
            try
            {
                if (DebugFlag)
                {
                    conn.Close();
                    throw new Exception(NonquerySql);
                }
                n = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception(NonquerySql + "\r\n" + e.ToString());
            }
            conn.Close();
            return n;
        }
        
        //执行一个非查询的数据库操作
        public int Execute(string NonQuerySql)
        {
            return Execute(NonQuerySql, false);
        }

        //执行一个查询的数据库操作,返回dataset
        public DataSet GetDs(string QuerySql, bool DebugFlag)
        {
            SqlConnection conn = new SqlConnection(DBstr);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = QuerySql;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            conn.Open();
            try
            {
                if (DebugFlag)
                {
                    conn.Dispose();
                    throw new Exception(QuerySql);
                }
                da.Fill(ds);
                conn.Dispose();
            }
            catch(Exception e)
            {
                conn.Dispose();
                throw new Exception(QuerySql + "\r\n" + e.ToString());
            }
            if (ds == null) return null;
            return ds;
        }

        //执行一个查询的数据库操作,返回dataset
        public DataSet GetDs(string QuerySql)
        {
            return GetDs(QuerySql, false);
        }

        //执行一个查询的数据库操作,返回dataview
        public DataView GetDv(string QuerySql)
        {
            DataView dv = GetDs(QuerySql).Tables[0].DefaultView;
            return dv;
        }
    }
}
