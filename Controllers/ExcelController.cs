using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WMS.Controllers
{
    class ExcelController
    {
        private string connect_str = "";
        public ExcelController(string filepath)
        {
            connect_str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=\"Excel 8.0;HDR=No;IMEX=1;\"";//2003版
        }

        public DataSet Query_DataSet(string sql_str)
        {
             if (string.IsNullOrEmpty(connect_str))
            {
                return null;
            }

            try
            {
                DataSet ds = new DataSet();
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = connect_str;
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql_str, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);    //读取Excel表格             
                da.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public DataView Query_DataView(string sql_str)
        {
            DataSet ds = Query_DataSet(sql_str);
            if (ds != null)
            {
                return ds.Tables[0].DefaultView;
            }
            else
            {
                return null;
            }
        }
    }
}
