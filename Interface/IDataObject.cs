using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace WMS.Interface
{
    interface IDataObject
    {
        SQLiteCommand ToInsert();
        SQLiteCommand ToUpdate();
        SQLiteCommand ToDelete();
    }
}
