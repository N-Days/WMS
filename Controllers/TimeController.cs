using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WMS.Common;
using WMS.Helper;
using System.Data.SQLite;

namespace WMS.Controllers
{
    static class TimeController
    {
        private const String c_default = "select distinct settleMonth from inventory order by settleMonth";
        private const String c_settle = "select distinct settleMonth from inventory where status <> 'running' order by settleMonth";
        private const String c_unsettle = "select distinct settleMonth from inventory where status = 'running' order by settleMonth";

        private static IEnumerable<String> QuerySettleMonth(bool? IsSettled)
        {
            SQLiteCommand command;
            if (IsSettled == null)
                command = new SQLiteCommand(c_default);
            else if (IsSettled == true)
                command = new SQLiteCommand(c_settle);
            else
                command = new SQLiteCommand(c_unsettle);


            using (var dv_Month = GlobalParam.DataBase.Query_DataView(command))
            {
                for (int i = 0; i < dv_Month.Count; i++)
                    yield return dv_Month[i]["settleMonth"].ToString();
            }
        }

        /// <summary>
        /// 获取运行中的月份
        /// </summary>
        /// <returns></returns>
        public static string GetRunningMonth()
        {
            return QuerySettleMonth(false).FirstOrDefault();
        }

        /// <summary>
        /// 获取最后一个已结算的月份
        /// </summary>
        /// <returns></returns>
        public static string GetLastSettleMonth()
        {
            return QuerySettleMonth(true).LastOrDefault();
        }

        public static bool CompareMonth(string lastmonth, string nextmonth)
        {
            return false;
        }

        public static IEnumerable<String> GetAllSettleMonth(bool? IsSettled)
        {
            return QuerySettleMonth(IsSettled);
        }

        public static string GetLastMonth(string settleMonth)
        {
            return Convert.ToDateTime(settleMonth).AddMonths(-1).ToString("yyyy-MM");
        }

        public static string GetNextMonth(string settltMonth)
        {
            return Convert.ToDateTime(settltMonth).AddMonths(1).ToString("yyyy-MM");
        }
    }
}
