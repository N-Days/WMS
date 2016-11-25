using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using WMS.Controllers;
using WMS.Model;
using WMS.Common;

namespace WMS
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private User CurrentUser = null;

        private void fMain_Load(object sender, EventArgs e)
        {
            fLogin login = new fLogin();
            login.ShowDialog();
            if (login.DialogResult != DialogResult.OK)
            {
                this.Close();
                return;
            }
            CurrentUser = login.CurrentUser;
            if (CurrentUser.UserType != (int)Controllers.UserController.UserType.admin)
            {
                this.toolbtn_User.Visible = false;
                this.toolbtn_Operation.Visible = false;
                this.toolbtn_Import.Visible = false;
                this.toolbtn_Export.Visible = false;
            }
            SetFormPosition();
            AutoAdjustment();
            InitDataGird();
            new Controllers.InventoryController();
        }

        /// <summary>
        /// 调整标签位置
        /// </summary>
        private void AutoAdjustment()
        {
            if (this.splitContainer1.Width <= 0 || this.splitter1.Width <= 0)
                return;
            this.lab_material.Location = new Point(lab_material.Parent.Location.X + (lab_material.Parent.Width - lab_material.Width) / 2, lab_material.Parent.Location.Y + (lab_material.Parent.Height - lab_material.Height) / 2);
            this.lab_intermediate.Location = new Point(lab_intermediate.Parent.Location.X + (lab_intermediate.Parent.Width - lab_intermediate.Width) / 2, lab_intermediate.Parent.Location.Y + (lab_intermediate.Parent.Height - lab_intermediate.Height) / 2);
            this.splitContainer1.SplitterDistance = this.splitContainer1.Location.X + (this.splitContainer1.Width - this.splitter1.Width) / 2;
        }

        /// <summary>
        /// 设置窗口位置居中
        /// </summary>
        private void SetFormPosition()
        {
            Rectangle rec = SystemInformation.VirtualScreen;
            this.Location = new Point((rec.Width - this.Width) / 2, (rec.Height - this.Height) / 2);
        }

        private const string c_query = "select goodsName as 名称,round(price,2) as '价格(元/公斤)',round(weight,2) as '重量(公斤)',settleMonth as 结算月份, (case status when 'settled' then '已结算' when 'running' then '运作中' when 'locked' then '已锁定' else '出错'  end) as 状态 from inventory,goods where goods.id=inventory.goodsId and goods.goodsType=@GoodsType and settleMonth = @SettleMonth";

        private string _currentmonth => TimeController.GetRunningMonth();

        private DataView dv_Intermediate => GlobalParam.DataBase.Query_DataView(c_query, new SQLiteParameter[]
                                                                    {
                                                                        new SQLiteParameter("@GoodsType","intermediate"),
                                                                        new SQLiteParameter("@SettleMonth", _currentmonth)
                                                                    });

        private DataView dv_Material => GlobalParam.DataBase.Query_DataView(c_query, new SQLiteParameter[]
                                                                    {
                                                                        new SQLiteParameter("@GoodsType","material"),
                                                                        new SQLiteParameter("@SettleMonth", _currentmonth)
                                                                    });

        private void InitDataGird()
        {
            if (dv_Material != null)
                this.dg_material.DataSource = dv_Material;

            if (dv_Intermediate != null)
                this.dg_intermediate.DataSource = dv_Intermediate;
        }

        private void fMain_SizeChanged(object sender, EventArgs e)
        {
            AutoAdjustment();
        }

        private void toolbtn_User_Click(object sender, EventArgs e)
        {
            var um = new UserManage(CurrentUser);
            um.ShowDialog();
        }

        private void toolbtn_Operation_Click(object sender, EventArgs e)
        {
            OperationForm of = new OperationForm();
            of.ShowDialog();
        }

        private void toolbtn_GoodsIdTypeIn_Click(object sender, EventArgs e)
        {
            GoodsRecord gr = new GoodsRecord(this.CurrentUser);
            gr.ShowDialog();
            InitDataGird();
        }

        private void toolbtn_Inventory_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryform = new InventoryForm(this.CurrentUser);
            inventoryform.ShowDialog();
            InitDataGird();
        }

        private void 原材料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryIO ii = new InventoryIO(this.CurrentUser, Controllers.GoodsController.GoodsType.material);
            ii.ShowDialog();
        }

        private void 半成品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryIO ii = new InventoryIO(this.CurrentUser, Controllers.GoodsController.GoodsType.intermediate);
            ii.ShowDialog();
        }

        private void 计算库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "";
            Controllers.InventoryController ic = new Controllers.InventoryController();
            if (ic.Calculate(this.CurrentUser, ref message))
            {
                MessageBox.Show("计算完成");
            }
            else
            {
                MessageBox.Show(message);
            }
            InitDataGird();
        }

        private void 结算库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settlemonth_running = TimeController.GetRunningMonth();
            if (string.IsNullOrEmpty(settlemonth_running))
            {
                settlemonth_running = TimeController.GetNextMonth(TimeController.GetAllSettleMonth(null).LastOrDefault());
            }
            if (MessageBox.Show("即将进行'" + settlemonth_running + "'的结算操作,是否继续?", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                MessageBox.Show("结算操作已取消");
                return;
            }
            string message = "";
            Controllers.InventoryController ic = new Controllers.InventoryController();
            if (ic.Settle(this.CurrentUser, ref message))
            {
                MessageBox.Show("结算完成");
            }
            else
            {
                MessageBox.Show(message);
            }
            InitDataGird();
        }

        private void toolbtn_Statistic_Click(object sender, EventArgs e)
        {
            StatisticForm sf = new StatisticForm();
            sf.Show();
        }

        private void toolbtn_Import_Click(object sender, EventArgs e)
        {
            DataImport di = new DataImport(this.CurrentUser);
            di.ShowDialog();
            InitDataGird();
        }

        private void toolbtn_MonthReport_Click(object sender, EventArgs e)
        {
            MonthReport mr = new MonthReport();
            mr.ShowDialog();
        }

        private void toolbtn_Export_Click(object sender, EventArgs e)
        {
            System.IO.FileStream fs1 = System.IO.File.Open(@"半成品库存情况.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write);
            System.IO.StreamWriter sw1 = new System.IO.StreamWriter(fs1);
            var dv_Material = GlobalParam.DataBase.Query_DataView(new System.Data.SQLite.SQLiteCommand("select goodsName,weight from inventory,goods where goods.id=inventory.goodsId and settleMonth='2015-12' and goods.goodsType='intermediate'"));
            for (int i = 0; i < dv_Material.Count; i++)
            {
                sw1.WriteLine(dv_Material[i]["goodsName"].ToString() + "        " + dv_Material[i]["weight"].ToString());
            }
            sw1.Close();
            fs1.Close();
        }
    }
}
