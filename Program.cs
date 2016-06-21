using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WMS.Common;

namespace WMS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var checker = new DataBaseChecker();
            checker.Check();
            Application.Run(new fMain());
        }
    }
}
