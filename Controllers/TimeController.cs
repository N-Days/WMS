using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WMS.Helper;
using System.Data.SQLite;

namespace WMS.Controllers
{
    class TimeController : IDisposable
    {
        private List<string> MonthList = new List<string>();
        private SqliteHelper _sqlite_helper
        {
            get;
            set;
        }

        private const String c_default = "select distinct settleMonth from inventory order by settleMonth";
        private const String c_settle = "select distinct settleMonth from inventory where status <> 'running' order by settleMonth";
        private const String c_unsettle = "select distinct settleMonth from inventory where status = 'running' order by settleMonth";

        public TimeController()
        {
            _initData();
        }

        private void _initData()
        {
            _sqlite_helper = new SqliteHelper();
        }

        private IEnumerable<String> QuerySettleMonth(bool? IsSettled)
        {
            SQLiteCommand command;
            if (IsSettled == null)
                command = new SQLiteCommand(c_default);
            else if (IsSettled == true)
                command = new SQLiteCommand(c_settle);
            else
                command = new SQLiteCommand(c_unsettle);


            using (var dv_Month = _sqlite_helper.Query_DataView(command))
            {
                for (int i = 0; i < dv_Month.Count; i++)
                    yield return dv_Month[i]["settleMonth"].ToString();
            }
        }

        /// <summary>
        /// 获取运行中的月份
        /// </summary>
        /// <returns></returns>
        public string GetRunningMonth()
        {
            return QuerySettleMonth(false).FirstOrDefault();
        }

        /// <summary>
        /// 获取最后一个已结算的月份
        /// </summary>
        /// <returns></returns>
        public string GetLastSettleMonth()
        {
            return QuerySettleMonth(true).LastOrDefault();
        }

        public bool CompareMonth(string lastmonth, string nextmonth)
        {
            return false;
        }

        public IEnumerable<String> GetAllSettleMonth(bool? IsSettled)
        {
            return QuerySettleMonth(IsSettled);
        }

        public string GetLastMonth(string settleMonth)
        {
            return Convert.ToDateTime(settleMonth).AddMonths(-1).ToString("yyyy-MM");
        }

        public string GetNextMonth(string settltMonth)
        {
            return Convert.ToDateTime(settltMonth).AddMonths(1).ToString("yyyy-MM");
        }

        public void Dispose()
        {
        }
    }
}
