using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Common
{
    class GlobalParam
    {
        internal static string ApplicationPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }
    }
}
