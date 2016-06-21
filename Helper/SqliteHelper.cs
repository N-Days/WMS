using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using WMS.Common;
using System.Data;

namespace WMS.Helper
{
    class SqliteHelper
    {
        static SqliteHelper()
        {
            s_databaselock = new OneManyLock();
            s_sqliteconnection = new SQLiteConnection(string.Format("Data Source ={0}{1}", GlobalParam.ApplicationPath, "\\App_Data\\WMSdatabase.db"));
            s_sqliteconnection.Open();
        }

        private static OneManyLock s_databaselock
        {
            get; set;
        }

        private static SQLiteConnection s_sqliteconnection
        {
            get; set;
        }

        private SQLiteTransaction _sqlitetransaction
        {
            get;
            set;
        }

        public SqliteHelper()
        {
        }

        private void _disconnect()
        {
            if (s_sqliteconnection.State != System.Data.ConnectionState.Closed && _sqlitetransaction == null)
                s_sqliteconnection.Close();
        }

        private SQLiteCommand _getcommand(SQLiteCommand command)
        {
            command.Connection = s_sqliteconnection;
            if (_sqlitetransaction != null)
                command.Transaction = _sqlitetransaction;
            return command;
        }

        private SQLiteCommand _getcommand(String sql, SQLiteParameter[] parameters)
        {
            var command = new SQLiteCommand(sql)
            {
                Connection= s_sqliteconnection,
                Parameters =
                {
                    parameters
                }
            };
            return command;
        }

        private SQLiteCommand _getcommand(String sql, SQLiteParameter parameter)
        {
            var command = new SQLiteCommand(sql)
            {
                Connection= s_sqliteconnection,
                Parameters =
                {
                    parameter
                }
            };
            if (_sqlitetransaction != null)
                command.Transaction = _sqlitetransaction;
            return command;
        }

        public void BeginTransaction()
        {
            if (_sqlitetransaction == null)
                _sqlitetransaction = s_sqliteconnection.BeginTransaction();
        }

        public void EndTransaction()
        {
            try
            {
                s_databaselock.Enter(true);
                _sqlitetransaction.Commit();
            }
            catch (Exception e)
            {
                _sqlitetransaction.Rollback();
                throw e;
            }
            finally
            {
                _sqlitetransaction = null;
                s_databaselock.Leave();
            }
        }

        public int Execute(SQLiteCommand command)
        {
            using (var cmd = _getcommand(command))
            {
                try
                {
                    s_databaselock.Enter(true);
                    return command.ExecuteNonQuery();
                }
                finally
                {
                    s_databaselock.Leave();
                }
            }
        }

        public int Execute(String sql, SQLiteParameter[] parameters)
        {
            using (var command = _getcommand(sql, parameters))
            {
                return Execute(command);
            }
        }

        public int Execute(String sql,SQLiteParameter parameter)
        {
            using (var command = _getcommand(sql, parameter))
            {
                return Execute(command);
            }
        }

        public DataSet Query_DataSet(SQLiteCommand command)
        {
            using (var cmd = _getcommand(command))
            using (SQLiteDataAdapter dataadapter = new SQLiteDataAdapter(command))
            {
                s_databaselock.Enter(false);
                DataSet ds = new DataSet();
                try
                {
                    dataadapter.Fill(ds);
                    return ds;
                }
                finally
                {
                    s_databaselock.Leave();
                }
            }
        }

        public DataView Query_DataView(SQLiteCommand command)
        {
            return Query_DataSet(command).Tables[0].DefaultView;
        }

        public DataView Query_DataView(String sql, SQLiteParameter[] parameters)
        {
            using (var command = _getcommand(sql,parameters))
            {
                return Query_DataView(command);
            }
        }

        public DataView Query_DataView(String sql, SQLiteParameter parameter)
        {
            using (var command = _getcommand(sql,parameter))
            {
                return Query_DataView(command);
            }
        }
    }
}
