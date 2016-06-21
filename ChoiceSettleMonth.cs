using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS
{
    public partial class ChoiceSettleMonth : Form
    {
        public ChoiceSettleMonth()
        {
            InitializeComponent();
        }

        public string SettleMonth
        {
            get
            {
                return this.dateTimePicker1.Text;
            }
        }

        private void SetFormPosition()
        {
            Rectangle rec = SystemInformation.VirtualScreen;
            Point point = new Point();
            point.X = (rec.Width - this.Width) / 2;
            point.Y = (rec.Height - this.Height) / 2;
            this.Location = point;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ChoiceSettleMonth_Load(object sender, EventArgs e)
        {
            SetFormPosition();
        }
    }
}
