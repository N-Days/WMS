using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using WMS.Controllers;

namespace WMS
{
    public partial class GoodsRecord : Form
    {
        public GoodsRecord(Model.User currentuser)
        {
            InitializeComponent();
            this._currentuser = currentuser;
        }

        private Model.User _currentuser = null;
        private DataTable dt_Goods = new DataTable();

        private TimeController timecontroller = new TimeController();
        private GoodsController goodscontroller = new GoodsController();
        private InventoryController inventorycontroller = new InventoryController();

        private bool CheckContent()
        {
            if (cbx_GoodsType.SelectedIndex < 0)
            {
                cbx_GoodsType.Focus();
                return false;
            }

            string match_number="^[a-zA-Z\\d]+$";
            if (!Regex.IsMatch(txt_GoodsName.Text,match_number))
            {
                txt_GoodsName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txt_Color.Text))
            {
                txt_Color.Focus();
                return false;
            }

            string match_decimal = "^[-+]?[0-9]+(\\.[0-9]+)?$";
            if (!Regex.IsMatch(txt_Price.Text, match_decimal))
            {
                txt_Price.Focus();
                return false;
            }
            if (!Regex.IsMatch(txt_Weight.Text, match_decimal))
            {
                txt_Weight.Focus();
                return false;
            }

            return true;
        }

        private void SetFormPosition()
        {
            Rectangle rec = SystemInformation.VirtualScreen;
            Point point = new Point();
            point.X = (rec.Width - this.Width) / 2;
            point.Y = (rec.Height - this.Height) / 2;
            this.Location = point;
        }

        private void btn_RecordDone_Click(object sender, EventArgs e)
        {
            AddToDataTable();
        }

        private void btn_ClearRecord_Click(object sender, EventArgs e)
        {
            ClearRecord();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string message = "";
            var list_goods = goodscontroller.GetAllGoods();
            
            #region 新增货物
            var linq_goods_needadd = from dr in dt_Goods.AsEnumerable()
                                     where (dr["种类"].ToString().Equals("原材料") || dr["种类"].ToString().Equals("半成品") && list_goods.FirstOrDefault(goods => goods.GoodsName.Equals(dr["名称"].ToString().ToUpper())) == null)
                                     select new Model.Goods()
                                     {
                                         GoodsName = dr["名称"].ToString().ToUpper(),
                                         Color = dr["颜色"].ToString(),
                                         GoodsType = dr["种类"].ToString().Equals("原材料") ? GoodsController.GoodsType.material : GoodsController.GoodsType.intermediate,
                                         RecordDate = DateTime.Now
                                     };
            if (!goodscontroller.Insert(linq_goods_needadd.ToList(), this._currentuser, ref message))
            {
                MessageBox.Show("新增货物失败!" + message);
                return;
            }
            #endregion

            #region 库存状态检查
            var settlemonth_last=timecontroller.GetLastSettleMonth();
            var settlemonth_running=timecontroller.GetRunningMonth();
            if (string.IsNullOrEmpty(settlemonth_last))
            {
                MessageBox.Show("未能找到已结算的月份,无法新增初始库存记录,请在'库存录入'窗口手动添加初始库存");
                return;
            }
            if (string.IsNullOrEmpty(settlemonth_running))
            {
                MessageBox.Show("未能找到运行中的月份,无法新增初始库存记录,请在'库存录入'窗口手动添加初始库存");
                return;
            }
            if (!timecontroller.GetNextMonth(settlemonth_last).Equals(settlemonth_running))
            {
                MessageBox.Show("最后一个已结算的月份'" + settlemonth_last + "'与运行中的月份'" + settlemonth_running + "'存在间隔,无法通过计算检查");
                return;
            }
            #endregion

            #region 新增库存记录
            list_goods = goodscontroller.GetAllGoods();
            var linq_inventory = from dr in dt_Goods.AsEnumerable()
                                 where list_goods.FirstOrDefault(goods => goods.GoodsName.Equals(dr["名称"].ToString().ToUpper())) != null
                                 select new List<Model.Inventory>()
                                 {
                                     new Model.Inventory()
                                     {
                                         GoodsID=list_goods.FirstOrDefault(goods=>goods.GoodsName.Equals(dr["名称"].ToString().ToUpper())).ID,
                                         Price = Convert.ToDouble(dr["初始价格"].ToString()),
                                         Weight = Convert.ToDouble(dr["初始重量"].ToString()),
                                         SettleMonth=timecontroller.GetLastSettleMonth(),
                                         Status = Controllers.InventoryController.Status.locked,
                                         CalculateDate=DateTime.Now,
                                     },
                                     new Model.Inventory()
                                     {
                                         GoodsID=list_goods.FirstOrDefault(goods=>goods.GoodsName.Equals(dr["名称"].ToString().ToUpper())).ID,
                                         Price = Convert.ToDouble(dr["初始价格"].ToString()),
                                         Weight = Convert.ToDouble(dr["初始重量"].ToString()),
                                         SettleMonth=timecontroller.GetRunningMonth(),
                                         Status = Controllers.InventoryController.Status.running,
                                         CalculateDate=DateTime.Now,
                                     }
                                 };
            List<Model.Inventory> list_inventory = new List<Model.Inventory>();
            foreach (var inventory in linq_inventory)
            {
                list_inventory.AddRange(inventory);
            }
            if (!inventorycontroller.Insert(list_inventory, this._currentuser, ref message))
            {
                MessageBox.Show("新增库存记录失败!" + message);
                return;
            }
            #endregion

            if (MessageBox.Show("新增完成,是否关闭本窗口?\n" + message, "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                ClearRecord();
                dt_Goods.Rows.Clear();
            }
        }

        private void btn_cannel_Click(object sender, EventArgs e)
        {
            if (CheckContent() || dt_Goods.Rows.Count != 0)
            {
                if (MessageBox.Show("现在退出将丢失已录入的数据,是否退出?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void GoodsRecord_Load(object sender, EventArgs e)
        {
            dt_Goods.Columns.Add("序号");
            dt_Goods.Columns.Add("名称");
            dt_Goods.Columns.Add("颜色");
            dt_Goods.Columns.Add("种类");
            dt_Goods.Columns.Add("初始价格");
            dt_Goods.Columns.Add("初始重量");
            this.dg_Goods.DataSource = dt_Goods;

            SetFormPosition();
        }

        private void ClearRecord()
        {
            this.cbx_GoodsType.SelectedIndex = -1;
            this.txt_GoodsName.Text = "";
            this.txt_Color.Text = "";
            this.txt_Price.Text = "0.0";
            this.txt_Weight.Text = "0.0";
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dg_Goods.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行要删除的数据");
                return;
            }

            this.dg_Goods.Rows.Remove(this.dg_Goods.SelectedRows[0]);
        }

        private void dg_Goods_DoubleClick(object sender, EventArgs e)
        {
            if (this.dg_Goods.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行要修改的数据");
                return;
            }
        }

        private void AddToDataTable()
        {
            if (CheckContent())
            {
                foreach (DataRow dr_goods in dt_Goods.Rows)
                {
                    if (dr_goods["名称"].ToString().Equals(txt_GoodsName.Text.Trim()))
                    {
                        return;
                    }
                }

                DataRow dr = dt_Goods.NewRow();
                dr["序号"] = dt_Goods.Rows.Count + 1;
                dr["名称"] = txt_GoodsName.Text.Trim();
                dr["颜色"] = txt_Color.Text.Trim();
                dr["种类"] = cbx_GoodsType.Text;
                dr["初始价格"] = txt_Price.Text;
                dr["初始重量"] = txt_Weight.Text;
                dr.EndEdit();
                dt_Goods.Rows.Add(dr);

                this.txt_GoodsName.Text = "";
                this.txt_Color.Text = "";
                this.txt_Price.Text = "0.0";
                this.txt_Weight.Text = "0.0";
            }
        }
    }
}
