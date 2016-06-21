using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.Controllers;

namespace WMS
{
    public partial class StatisticForm : Form
    {
        public StatisticForm()
        {
            InitializeComponent();
        }

        private void Statistic()
        {
            Inventory_IO_Controller inventory_io_controller = new Inventory_IO_Controller();
            InventoryController inventory_controller=new InventoryController();

            double totalamount_in=inventory_io_controller.TotalAmount_In(this.date_settleMonth.Text);
            double totalamount_out=0-inventory_io_controller.TotalAmount_Out(this.date_settleMonth.Text);
            double totalamount_start=inventory_controller.TotalAmount_Inventory(this.date_settleMonth.Value.AddMonths(-1).ToString("yyyy-MM"));
            double totalamount_end=inventory_controller.TotalAmount_Inventory(this.date_settleMonth.Text);
            double minus = totalamount_start + totalamount_in - totalamount_out - totalamount_end;

            this.lab_in.Text = totalamount_in.ToString()+"元";
            this.lab_out.Text = totalamount_out.ToString()+"元";
            this.lab_start.Text = totalamount_start.ToString()+"元";
            this.lab_end.Text = totalamount_end.ToString() + "元";
            this.lab_minus.Text = minus.ToString() + "元";
        }

        private void SetFormPosition()
        {
            Rectangle rec = SystemInformation.VirtualScreen;
            this.Location = new Point((rec.Width - this.Width) / 2, (rec.Height - this.Height) / 2);
        }

        private void date_settleMonth_ValueChanged(object sender, EventArgs e)
        {
            Statistic();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StatisticForm_Load(object sender, EventArgs e)
        {
            SetFormPosition();
            Statistic();
        }

    }
}
