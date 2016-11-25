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
using System.Text.RegularExpressions;
using WMS.Helper;
using WMS.Model;
using WMS.Common;

namespace WMS
{
    public partial class InventoryForm : Form
    {
        public InventoryForm(User currentuser)
        {
            InitializeComponent();
            _currentuser = currentuser;
        }

        private User _currentuser = null;
        private Goods m_goods = null;

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
        private SqliteHelper _sqlite_helper => GlobalParam.DataBase;

        public void InitListView()
        {
            this.lv_Material.Columns.Add("货物", 100, HorizontalAlignment.Left);
            this.lv_Intermediate.Columns.Add("货物", 100, HorizontalAlignment.Left);
            var goods_list = goods_controller.GetAllGoods();
            foreach (var goods in goods_list)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = goods.GoodsName.ToString();
                lvi.Tag = goods;
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

        private void SetContent()
        {
            var goods_inventory = inventory_controller.GetGoodsInventoryByGoodsName(m_goods.GoodsName, null);
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

            if (m_goods != null)
            {
                this.lab_GoodsName.Text = m_goods.GoodsName;
                this.lab_Color.Text = m_goods.Color;
            }
            else
            {
                this.lab_GoodsName.Text = "";
                this.lab_Color.Text = "";
            }
        }

        private void _refreshdatagird()
        {
            if (m_goods != null)
            {
                dg_Inventory.DataSource = _sqlite_helper.Query_DataView("select goodsName as 名称,round(price,2) as '价格(元/公斤)',round(weight,2) as '重量(公斤)',settleMonth as 结算月份,calculateDate as 计算日期,status as 状态 from inventory,goods where goods.id=inventory.goodsId and goodsName=@GoodsName",
                    new SQLiteParameter("@GoodsName", m_goods.GoodsName));
                dg_Inventory.Sort(dg_Inventory.Columns[3], ListSortDirection.Descending);
                var lastdate = $"{dg_Inventory[3, 0].Value.ToString()}-01 00:00:00";
                date.MaxDate = Convert.ToDateTime(lastdate);
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
            if (lv_Material.SelectedItems != null)
            {
                m_goods = (Goods)lv_Material.SelectedItems[0].Tag;
                _refreshdatagird();
                SetContent();
            }
            else
            {
                MessageBox.Show("!");
            }
        }

        private void lv_Intermediate_DoubleClick(object sender, EventArgs e)
        {
            if (lv_Intermediate.SelectedItems != null)
            {
                m_goods = (Goods)lv_Intermediate.SelectedItems[0].Tag;
                _refreshdatagird();
                SetContent();
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
                if (m_goods != null)
                {
                    var goods_inventory = new Inventory();
                    goods_inventory.GoodsID = m_goods.ID;
                    goods_inventory.Price = Convert.ToDouble(txt_Price.Text);
                    goods_inventory.Weight = Convert.ToDouble(txt_Weight.Text);
                    goods_inventory.SettleMonth = date.Text;
                    goods_inventory.CalculateDate = DateTime.Now;
                    goods_inventory.Status = InventoryController.Status.locked;

                    string message = "";
                    if (inventory_controller.InsertOrUpdate(goods_inventory, this._currentuser, ref message))
                    {
                        _refreshdatagird();
                        MessageBox.Show("锁定完成");
                    }
                    else
                    {
                        MessageBox.Show("新增库存记录失败!\r\n" + message);
                    }
                }
            }
            else
            {
                MessageBox.Show("未通过内容检查");
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
