using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.Controllers;
using System.Text.RegularExpressions;
using WMS.Helper;

namespace WMS
{
    public partial class InventoryForm : Form
    {
        public InventoryForm(Model.User currentuser)
        {
            InitializeComponent();
            this._currentuser = currentuser;
        }

        private Model.User _currentuser = null;
        private Model.Goods Goods = null;

        private GoodsController goods_controller
        {
            get;
            set;
        }
        private InventoryController inventory_controller
        {
            get;
            set;
        }
        private SqliteHelper _sqlite_helper
        {
            get;
            set;
        }

        public void InitListView()
        {
            this.lv_Material.Columns.Add("货物", 100, HorizontalAlignment.Left);
            this.lv_Intermediate.Columns.Add("货物", 100, HorizontalAlignment.Left);
            var goods_list = goods_controller.GetAllGoods();
            foreach (var goods in goods_list)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = goods.GoodsName.ToString();
                if (goods.GoodsType.Equals(GoodsController.GoodsType.material))
                {
                    this.lv_Material.Items.Add(lvi);
                }
                else
                {
                    this.lv_Intermediate.Items.Add(lvi);
                }
            }
        }
        private void _initData()
        {
            _sqlite_helper = new SqliteHelper();
            goods_controller = new GoodsController();
            inventory_controller = new InventoryController();
        }
        private void _autosetsplitterdistance()
        {
            splitContainer2.SplitterDistance = splitContainer2.Height / 10 * 4;

        }
        private void SetFormPosition()
        {
            Rectangle rec = SystemInformation.VirtualScreen;
            this.Location = new Point((rec.Width - this.Width) / 2, (rec.Height - this.Height) / 2);
        }

        private void SetContent(string goodsName)
        {
            var goods_inventory = inventory_controller.GetGoodsInventoryByGoodsName(goodsName, null);
            if (goods_inventory != null)
            {
                this.txt_Price.Text = goods_inventory.Price.ToString();
                this.txt_Weight.Text = goods_inventory.Weight.ToString();
            }
            else
            {
                this.txt_Price.Text = "0.0";
                this.txt_Weight.Text = "0.0";
            }

            this.Goods = goods_controller.GetGoodsByGoodsName(goodsName);
            if (Goods != null)
            {
                this.lab_GoodsName.Text = Goods.GoodsName;
                this.lab_Color.Text = Goods.Color;
            }
            else
            {
                this.lab_GoodsName.Text = "";
                this.lab_Color.Text = "";
            }
        }

        private void _refreshdatagird()
        {
            if (lv_Material.SelectedItems != null)
            {
                this.dg_Inventory.DataSource = _sqlite_helper.Query_DataView("select goodsName as 名称,price as '价格(元/公斤)',weight as '重量(公斤)',settleMonth as 结算月份,calculateDate as 计算日期,status as 状态 from inventory,goods where goods.id=inventory.goodsId and goodsName='@GoodsName'",
                    new System.Data.SQLite.SQLiteParameter("@GoodsName", lv_Material.SelectedItems[0].Text));
                if (lv_Intermediate.SelectedItems.Count != 0)
                {
                    SetContent(lv_Material.SelectedItems[0].Text);
                }
            }
            else
            {
                MessageBox.Show("!");
            }
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            _initData();
            InitListView();
            SetFormPosition();
            _autosetsplitterdistance();
        }

        private bool CheckContent()
        {
            if (string.IsNullOrEmpty(lab_GoodsName.Text))
            {
                MessageBox.Show("请选择要修改的货物");
                return false;
            }
            if (string.IsNullOrEmpty(lab_Color.Text))
            {
                MessageBox.Show("请选择要修改的货物");
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

        private void lv_Material_DoubleClick(object sender, EventArgs e)
        {
            _refreshdatagird();
        }

        private void lv_Intermediate_DoubleClick(object sender, EventArgs e)
        {
            if (lv_Intermediate.SelectedItems != null)
            {
                this.dg_Inventory.DataSource = _sqlite_helper.Query_DataView("select goodsName as 名称,price as '价格(元/公斤)',weight as '重量(公斤)',settleMonth as 结算月份,calculateDate as 计算日期,status as 状态 from inventory,goods where goods.id=inventory.goodsId and goodsName='@GoodsName'",
                    new System.Data.SQLite.SQLiteParameter("@GoodsName", lv_Intermediate.SelectedItems[0].Text));
                SetContent(lv_Intermediate.SelectedItems[0].Text);
            }
            else
            {
                MessageBox.Show("!");
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (CheckContent())
            {
                if (Goods != null)
                {
                    Model.Inventory goods_inventory = new Model.Inventory();
                    goods_inventory.GoodsID = Goods.ID;
                    goods_inventory.Price = Convert.ToDouble(txt_Price.Text);
                    goods_inventory.Weight = Convert.ToDouble(txt_Weight.Text);
                    goods_inventory.SettleMonth = date.Text;
                    goods_inventory.CalculateDate = DateTime.Now;
                    goods_inventory.Status = InventoryController.Status.locked;
                    InventoryController inventory_controller = new InventoryController();
                    string message = "";
                    if (inventory_controller.InsertOrUpdate(goods_inventory, this._currentuser, ref message))
                    {
                        _refreshdatagird();
                    }
                    else
                    {
                        MessageBox.Show("新增库存记录失败!\r\n" + message);
                    }
                }
            }
        }

        private void btn_Cannel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dg_Inventory_DoubleClick(object sender, EventArgs e)
        {
            var dgv_select = dg_Inventory.CurrentRow;
            if (dgv_select == default(DataGridViewRow))
                return;
            else
            {
                txt_Price.Text = dgv_select.Cells["价格(元/公斤)"].Value.ToString();
                txt_Weight.Text = dgv_select.Cells["重量(公斤)"].Value.ToString();
                date.Value = Convert.ToDateTime(dgv_select.Cells["结算月份"].Value.ToString());
            }
        }
    }
}
