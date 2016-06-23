using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.Controllers;
using WMS.Model;
using System.Text.RegularExpressions;

namespace WMS
{
    public partial class InventoryIO : Form
    {
        public InventoryIO(User user, string goodsType)
        {
            InitializeComponent();
            switch (goodsType)
            {
                case GoodsController.GoodsType.material:
                    {
                        this.Text += "-原材料";
                        break;
                    }

                case GoodsController.GoodsType.intermediate:
                    {
                        this.Text += "-半成品";
                        break;
                    }

                default:
                    {
                        this.Text += "-发现错误";
                        break;
                    }
            }
            this._goodstype = goodsType;
            this._currentuser = user;
        }

        private string _goodstype = null;
        private User _currentuser = null;
        private DataTable dt_inventory_io = new DataTable();
        private Dictionary<string, Goods> dictionary_goods = new Dictionary<string, Goods>();
        private Dictionary<int, Inventory> dictionary_inventory = new Dictionary<int, Inventory>();
        private List<string> list_settleMonth = new List<string>();
        private List<Inventory_IO> list_inventory_io = new List<Inventory_IO>();

        private Inventory_IO_Controller inventory_io_controller = new Inventory_IO_Controller();
        private InventoryController inventorycontroller = new InventoryController();
        private TimeController timecontroller = new TimeController();

        private Inventory _getinventory(int goodsId)
        {
            if (dictionary_inventory.Keys.Contains(goodsId))
                return dictionary_inventory[goodsId];
            else return null;
        }

        private void _addinventory(Model.Inventory inventory)
        {
            if (dictionary_inventory.Keys.Contains(inventory.GoodsID))
            {
                dictionary_inventory[inventory.GoodsID] = inventory;
            }
            else
            {
                dictionary_inventory.Add(inventory.GoodsID, inventory);
            }
        }

        private Goods _getgoods(string goodsName)
        {
            if (dictionary_goods.Keys.Contains(goodsName))
            {
                return dictionary_goods[goodsName];
            }
            else
            {
                return null;
            }
        }

        private void _addgoods(Goods goods)
        {
            if (dictionary_goods.Keys.Contains(goods.GoodsName))
            {
                dictionary_goods[goods.GoodsName] = goods;
            }
            else
            {
                dictionary_goods.Add(goods.GoodsName, goods);
            }
        }

        private void InitData()
        {
            var list_goods = new GoodsController().GetGoodsByType(this._goodstype);
            foreach (var goods in list_goods)
            {
                _addgoods(goods);
                this.cbx_GoodsName.Items.Add(goods.GoodsName);
            }

            list_settleMonth = timecontroller.GetAllSettleMonth(true).ToList();
        }

        private void InitDataGird()
        {
            dictionary_inventory.Clear();
            var list_inventory = inventorycontroller.GetLastMonthInventory();
            foreach (var inventory in list_inventory)
            {
                _addinventory(inventory);
            }

            list_inventory_io = inventory_io_controller.GetGoodsIOBySettleMonth(this.date_settleMonth.Text).ToList();
            dt_inventory_io.Rows.Clear();
            var list_datarow = from inventoryio in list_inventory_io
                               join goods in dictionary_goods.Values
                               on inventoryio.GoodsID equals goods.ID
                               select dt_inventory_io.Rows.Add(inventoryio.ID, goods.GoodsName, inventoryio.Price, inventoryio.Weight, inventoryio.RecordDate);
            foreach (var datarow in list_datarow) ;
            dg_IO.DataBindingComplete += delegate
            {
                foreach (DataGridViewRow dr in dg_IO.Rows)
                {
                    dr.DefaultCellStyle.BackColor = Convert.ToDouble(dr.Cells[3].Value.ToString()) > 0 ? Color.IndianRed : Color.LightSeaGreen;
                }
            };

        }

        private void InitDataTable()
        {
            if (dt_inventory_io == null)
            {
                dt_inventory_io = new DataTable();
            }
            else
            {
                dt_inventory_io.Rows.Clear();
                dt_inventory_io.Columns.Clear();
            }
            dt_inventory_io.Columns.Add("编号");
            dt_inventory_io.Columns.Add("名称");
            dt_inventory_io.Columns.Add("价格(元/公斤)");
            dt_inventory_io.Columns.Add("重量(公斤)");
            dt_inventory_io.Columns.Add("录入日期");
            this.dg_IO.DataSource = dt_inventory_io;
        }

        private void ClearContent()
        {
            this.txt_Price.Text = "0.0";
            this.txt_Weight.Text = "0.0";
        }

        private void SetFormPosition()
        {
            Rectangle rec = SystemInformation.VirtualScreen;
            this.Location = new Point((rec.Width - this.Width) / 2, (rec.Height - this.Height) / 2);
        }

        private bool CheckContent()
        {
            //string match_number = "^[a-zA-Z\\d]+$";
            //if (!Regex.IsMatch(cbx_GoodsName.Text, match_number))
            //{
            //    cbx_GoodsName.Focus();
            //    return false;
            //}

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

        private bool InsertInventoryIO(string goodsname, double weight, double price)
        {
            var inventory_io = new Inventory_IO();
            inventory_io.Price = price;
            inventory_io.Weight = weight;
            inventory_io.UserID = this._currentuser.Id;
            inventory_io.SettleMonth = this.date_settleMonth.Text;
            inventory_io.RecordDate = DateTime.Now;

            var goods = _getgoods(goodsname);
            if (goods != null)//若存在该货物
            {
                bool BeSure = true;
                inventory_io.GoodsID = goods.ID;
                var inventory = _getinventory(goods.ID);
                if (inventory == null)
                {
                    if (MessageBox.Show("未能找到货物'" + goods.GoodsName + "'的库存情况,是否继续录入出入库记录?", "警告", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        BeSure = false;
                    }
                }
                else
                {
                    if (inventory_io.Weight > 0)//若记录为入库
                    {
                        double increase = 0;
                        if (inventory.Price > inventory_io.Price)
                        {
                            increase = (inventory.Price - inventory_io.Price) / inventory.Price;
                        }
                        else
                        {
                            increase = (inventory_io.Price - inventory.Price) / inventory.Price;
                        }
                        if (increase > 0.2)//若涨幅超过20%
                        {
                            if (MessageBox.Show("货物'" + goods.GoodsName + "'价格涨幅超过20%,是否继续录入入库记录?", "警告", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                            {
                                BeSure = false;
                            }
                        }
                    }
                    else//若记录为出库
                    {
                        if (inventory.Weight <= 0)//若库存已空
                        {
                            if (MessageBox.Show("货物'" + goods.GoodsName + "'库存已空,是否继续录入出库记录?", "警告", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                            {
                                BeSure = false;
                            }
                        }
                    }
                }

                if (BeSure)//若确认插入出入库记录
                {
                    string message = "";
                    return inventory_io_controller.Insert(inventory_io, this._currentuser, ref message);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show("不存在该货物");
                return false;
            }
        }

        private void InventoryIO_Load(object sender, EventArgs e)
        {
            SetFormPosition();
            InitDataTable();
            InitData();
            InitDataGird();
        }

        private void date_settleMonth_ValueChanged(object sender, EventArgs e)
        {
            if (list_settleMonth.Contains(this.date_settleMonth.Text))
            {
                this.cbx_GoodsName.Enabled = false;
                this.txt_Price.Enabled = false;
                this.txt_Weight.Enabled = false;
                this.btn_Last.Enabled = false;
                this.btn_Next.Enabled = false;
                this.menu_IO.Enabled = false;
            }
            else
            {
                this.cbx_GoodsName.Enabled = true;
                this.txt_Price.Enabled = true;
                this.txt_Weight.Enabled = true;
                this.btn_Last.Enabled = true;
                this.btn_Next.Enabled = true;
                this.menu_IO.Enabled = true;
            }
            InitDataGird();
        }

        private void dg_IO_DoubleClick(object sender, EventArgs e)
        {
            IO_TypeIn f = new IO_TypeIn(_goodstype);
            f.ShowDialog();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (CheckContent())
            {
                double weight = 0;
                double price = 0;
                double.TryParse(this.txt_Weight.Text, out weight);
                double.TryParse(this.txt_Price.Text, out price);
                if (weight * price != 0)
                {
                    if (InsertInventoryIO(this.cbx_GoodsName.Text, weight, price))
                    {
                        int index = this.cbx_GoodsName.SelectedIndex + 1;
                        if (index < this.cbx_GoodsName.Items.Count) this.cbx_GoodsName.SelectedIndex = index;
                        else this.cbx_GoodsName.SelectedIndex = 0;

                        ClearContent();
                        InitDataGird();
                    }
                }
                else
                {
                    MessageBox.Show("数值不得为0");
                }
            }
        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            if (CheckContent())
            {
                double weight = 0;
                double price = 0;
                double.TryParse(this.txt_Weight.Text, out weight);
                double.TryParse(this.txt_Price.Text, out price);
                if (weight * price != 0)
                {
                    if (InsertInventoryIO(this.cbx_GoodsName.Text, weight, price))
                    {

                        int index = this.cbx_GoodsName.SelectedIndex - 1;
                        if (index > 0) this.cbx_GoodsName.SelectedIndex = index;
                        else this.cbx_GoodsName.SelectedIndex = this.cbx_GoodsName.Items.Count - 1;

                        ClearContent();
                        InitDataGird();
                    }
                }
                else
                {
                    MessageBox.Show("数值不得为0");
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dg_IO.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行需要删除的记录");
                return;
            }

            foreach (var inventory_io in list_inventory_io)
            {
                if (inventory_io.ID.ToString().Equals(this.dg_IO.SelectedRows[0].Cells["编号"].Value.ToString()))
                {
                    string message = "";
                    if (!inventory_io_controller.Delete(inventory_io, this._currentuser, ref message))
                    {
                        MessageBox.Show(message);
                        return;
                    }
                    else
                    {
                        InitDataGird();
                        return;
                    }
                }
            }

            InitDataGird();
        }
    }
}
