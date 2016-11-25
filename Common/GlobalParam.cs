using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Helper;

namespace WMS.Common
{
    class GlobalParam
    {
        internal static string ApplicationPath => AppDomain.CurrentDomain.BaseDirectory;

        private static SqliteHelper _database = null;
        public static SqliteHelper DataBase => _database == null ? _database = new SqliteHelper() : _database;
    }
}
