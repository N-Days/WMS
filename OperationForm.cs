using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.Helper;

namespace WMS
{
    public partial class OperationForm : Form
    {
        public OperationForm()
        {
            InitializeComponent();
        }

        private void SetFormPosition()
        {
            Rectangle rec = SystemInformation.VirtualScreen;
            Point point = new Point();
            point.X = (rec.Width - this.Width) / 2;
            point.Y = (rec.Height - this.Height) / 2;
            this.Location = point;
        }

        private void OperationForm_Load(object sender, EventArgs e)
        {
            var sqlite_helper = new SqliteHelper();
            dg_Operation.DataSource = sqlite_helper.Query_DataView(new System.Data.SQLite.SQLiteCommand("select userName as 姓名,operation as 操作,content as 内容,operateDate as 操作时间 from user_operation,user where user_operation.userId=user.id"));
            SetFormPosition();
        }
    }
}
