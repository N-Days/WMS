using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using WMS.Controllers;
using WMS.Model;

namespace WMS
{
    public partial class DataImport : Form
    {
        private User _currentuser = null;
        private GoodsController controller_goods = new GoodsController();

        public DataImport(User user)
        {
            InitializeComponent();
            this._currentuser = user;
        }

        private void SetFormPosition()
        {
            Rectangle rec = SystemInformation.VirtualScreen;
            Point point = new System.Drawing.Point();
            point.X = (rec.Width - this.Width) / 2;
            point.Y = (rec.Height - this.Height) / 2;
            this.Location = point;
        }

        private void OpenFile()
        {
        }

        private bool CheckContent()
        {
            if (string.IsNullOrEmpty(_filepath))
            {
                MessageBox.Show("请选择要导入的Excel文件");
                return false;
            }
            if (string.IsNullOrEmpty(cbx_datetype.Text))
            {
                MessageBox.Show("请选择要导入的数据类型");
                return false;
            }

            if (this.cbx_datetype.Text.Equals("编号"))
            {
                if (this.cbx_goodsType.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择货物类型");
                    return false;
                }
            }

            return true;
        }

        private string _filepath = "";

        private void btn_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _filepath = fileDialog.FileName;
            }
        }

        private void DataImport_Load(object sender, EventArgs e)
        {
            SetFormPosition();
            this.label4.Visible = false;
            this.date_settlemonth.Visible = false;
            this.label5.Visible = false;
            this.cbx_goodsType.Visible = false;
            this.label6.Visible = false;
            this.cbx_IOtype.Visible = false;
        }

        private void btn_flash_Click(object sender, EventArgs e)
        {
            if (CheckContent())
            {
                ExcelController excelcontroller = new ExcelController(this._filepath);
                DataView dv = excelcontroller.Query_DataView("select * from [Sheet1$" + this.txt_position.Text + "]");
                this.dg_date.DataSource = dv;
            }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            if (CheckContent())
            {
                if (this.dg_date.DataSource == null)
                {
                    MessageBox.Show("请点击刷新按钮");
                    return;
                }
                string[] str = _filepath.Split('\\');
                string filename = str[str.Length - 1];
                if (MessageBox.Show("即将把文件'" + filename + "'作为[" + cbx_datetype.Text + "]数据源导入到数据库中,是否继续?", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    MessageBox.Show("导入已取消");
                    return;
                }
            }

            switch (this.cbx_datetype.Text)
            {
                case "库存":
                    {
                        #region 库存
                        DataView dv_data = (DataView)this.dg_date.DataSource;
                        if (dv_data != null)
                        {
                            List<Model.Inventory> inventory_list = new List<Model.Inventory>();
                            var goods_list = new GoodsController().GetAllGoods();
                            foreach (DataRowView drv in dv_data)
                            {
                                if (string.IsNullOrEmpty(drv[0].ToString()) || drv[0].ToString().Equals("格式行"))
                                {
                                    continue;
                                }
                                Model.Inventory inventory = new Model.Inventory();
                                foreach (var goods in goods_list)
                                {
                                    if (goods.GoodsName.Equals(drv[0].ToString().ToUpper()))
                                    {
                                        inventory.GoodsID = goods.ID;
                                        break;
                                    }
                                }
                                if (inventory.GoodsID == 0) continue;

                                double price = 0;
                                double weight = 0;
                                if (double.TryParse(drv[1].ToString(), out weight))
                                {
                                    inventory.Weight = weight;
                                }
                                else
                                {
                                    inventory.Weight = 0.0;
                                }

                                if (double.TryParse(drv[2].ToString(), out price))
                                {
                                    inventory.Price = price;
                                }
                                else
                                {
                                    inventory.Price = 0.0;
                                }

                                inventory.SettleMonth = this.date_settlemonth.Text;
                                inventory.CalculateDate = DateTime.Now;
                                inventory.Status = InventoryController.Status.locked;

                                inventory_list.Add(inventory);
                            }
                            string message = "";
                            InventoryController ic = new InventoryController();
                            ic.InsertOrUpdate(inventory_list, this._currentuser, ref message);
                            MessageBox.Show(message);
                        }

                        break;
                        #endregion
                    }

                case "编号":
                    {
                        #region 编号
                        var dv_data = (DataView)this.dg_date.DataSource;
                        if (dv_data != null)
                        {
                            var list_goods_current = controller_goods.GetAllGoods();
                            var list_goods = new List<Goods>();
                            foreach (DataRowView drv in dv_data)
                            {
                                if (string.IsNullOrEmpty(drv[0].ToString()) || drv[0].ToString().Equals("格式行"))
                                {
                                    continue;
                                }
                                var goods = new Goods();
                                goods.GoodsName = drv[0].ToString().ToUpper();
                                goods.Color = drv[1].ToString();
                                goods.GoodsType = this.cbx_goodsType.Text.Equals("原材料") ? "material" : "intermediate";
                                goods.RecordDate = DateTime.Now;
                                goods.UserID = this._currentuser.Id;

                                list_goods.Add(goods);
                            }

                            foreach (var goods in list_goods)
                            {
                                foreach (var goods_current in list_goods_current)
                                {
                                    if (goods.GoodsName.Equals(goods_current.GoodsName))
                                    {
                                        goods.ID = goods.ID;
                                    }
                                }
                            }

                            string message = "";
                            controller_goods.InsertOrUpdate(list_goods, this._currentuser, ref message);
                            MessageBox.Show(message);
                        }
                        break;
                        #endregion
                    }

                case "入出库":
                    {
                        #region 入出库
                        DataView dv_io = (DataView)this.dg_date.DataSource;
                        if (dv_io != null)
                        {
                            Inventory_IO_Controller inventory_io_controller = new Inventory_IO_Controller();
                            List<Model.Inventory_IO> list_io = new List<Model.Inventory_IO>();
                            var list_goods = new GoodsController().GetAllGoods();
                            for (int i = 0; i < dv_io.Count; i++)
                            {
                                if (string.IsNullOrEmpty(dv_io[i][0].ToString()) || dv_io[i][0].ToString().Equals("格式行"))
                                {
                                    continue;
                                }
                                Model.Inventory_IO inventoryio = null;
                                foreach (var goods in list_goods)
                                {
                                    if (goods.GoodsName.Equals(dv_io[i][0].ToString().ToUpper()))
                                    {
                                        inventoryio = new Model.Inventory_IO()
                                        {
                                            GoodsID = goods.ID,
                                            RecordDate = DateTime.Now,
                                            SettleMonth = this.date_settlemonth.Text,
                                        };
                                        break;
                                    }
                                }
                                if (inventoryio == null)
                                {
                                    continue;
                                }

                                double weight, price;
                                double.TryParse(dv_io[i][1].ToString(), out weight);
                                double.TryParse(dv_io[i][2].ToString(), out price);
                                if (this.cbx_IOtype.Text.Equals("出库"))
                                {
                                    weight = 0 - weight;
                                }
                                if (weight * price != 0)
                                {
                                    inventoryio.Weight = weight;
                                    inventoryio.Price = price;
                                    list_io.Add(inventoryio);
                                }
                            }
                            string message = "";
                            foreach (var inventoryio in list_io)
                            {
                                inventory_io_controller.Insert(inventoryio, _currentuser, ref message);
                            }
                            MessageBox.Show(message);
                        }
                        break;
                        #endregion
                    }

                default:
                    {
                        break;
                    }
            }
        }

        private void cbx_datetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbx_datetype.Text.Equals("编号"))
            {
                this.label4.Visible = false;
                this.date_settlemonth.Visible = false;
                this.label5.Visible = true;
                this.cbx_goodsType.Visible = true;
                this.label6.Visible = false;
                this.cbx_IOtype.Visible = false;
                return;
            }

            if (this.cbx_datetype.Text.Equals("库存"))
            {
                this.label4.Visible = true;
                this.date_settlemonth.Visible = true;
                this.label5.Visible = false;
                this.cbx_goodsType.Visible = false;
                this.label6.Visible = false;
                this.cbx_IOtype.Visible = false;
                return;
            }

            if (this.cbx_datetype.Text.Equals("入出库"))
            {
                this.label4.Visible = true;
                this.date_settlemonth.Visible = true;

                this.label5.Visible = false;
                this.cbx_goodsType.Visible = false;

                this.label6.Visible = true;
                this.cbx_IOtype.Visible = true;

                return;
            }
        }
    }
}
