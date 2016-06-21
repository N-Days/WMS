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
    public partial class MonthReport : Form
    {
        public MonthReport()
        {
            InitializeComponent();
        }

        private GoodsController goodscontroller = new GoodsController();
        private Inventory_IO_Controller inventoryIO = new Inventory_IO_Controller();
        private InventoryController inventorycontroller = new InventoryController();
        private TimeController timecontroller = new TimeController();

        private DataTable dt_material = null;
        private DataTable dt_intermediate = null;

        private void InitSettleMonth()
        {
            var month_list = timecontroller.GetAllSettleMonth(true);
            foreach (var month in month_list.Reverse())
                tv_settleMonth.Nodes.Add(month);
        }

        private void InitMonthReport()
        {
            if (string.IsNullOrEmpty(this.tv_settleMonth.SelectedNode.Text))
            {
                MessageBox.Show("请选择要查看的月份");
                return;
            }

            var list_inventory_lastmonth = inventorycontroller.GetInventoryBySettleMonth(timecontroller.GetLastMonth(this.tv_settleMonth.SelectedNode.Text));
            var list_inventory_currentmonth = inventorycontroller.GetInventoryBySettleMonth(this.tv_settleMonth.SelectedNode.Text);
            var list_goods = goodscontroller.GetAllGoods();
            var list_inventoryIO = inventoryIO.GetGoodsIOBySettleMonth(this.tv_settleMonth.SelectedNode.Text);

            dt_material.Rows.Clear();
            dt_intermediate.Rows.Clear();

            double total_last_material = 0, total_in_material = 0, total_out_material = 0, total_current_material = 0;
            double total_last_intermediate = 0, total_in_intermediate = 0, total_out_intermediate = 0, total_current_intermediate = 0;
            foreach (var goods in list_goods)
            {
                var list_inventoryio_goods = from inventoryio in list_inventoryIO
                                             where inventoryio.GoodsID == goods.ID
                                             select inventoryio;

                Model.Inventory_IO inventory_in = new Model.Inventory_IO();
                Model.Inventory_IO inventory_out = new Model.Inventory_IO();

                foreach (var inventoryio in list_inventoryio_goods)
                {
                    if (inventoryio.Weight > 0)
                    {
                        var pricetotal = inventoryio.Weight * inventoryio.Price + inventory_in.Weight * inventory_in.Price;
                        inventory_in.Weight += inventoryio.Weight;
                        inventory_in.Price = pricetotal / inventory_in.Weight;
                    }
                    else
                    {
                        inventoryio.Weight = 0 - inventoryio.Weight;
                        var pricetotal = inventoryio.Weight * inventoryio.Price + inventory_out.Weight * inventory_out.Price;
                        inventory_out.Weight += inventoryio.Weight;
                        inventory_out.Price = pricetotal / inventory_out.Weight;
                    }
                }

                Model.Inventory inventory_lastmonth = list_inventory_lastmonth.FirstOrDefault(i => i.GoodsID == goods.ID);
                if (inventory_lastmonth == null) inventory_lastmonth = new Model.Inventory();
                Model.Inventory inventory_currentmonth = list_inventory_currentmonth.FirstOrDefault(i => i.GoodsID == goods.ID);
                if (inventory_currentmonth == null) inventory_currentmonth = new Model.Inventory();

                switch (goods.GoodsType)
                {
                    case GoodsController.GoodsType.material:
                        {
                            #region 原材料
                            total_last_material += inventory_lastmonth.Price * inventory_lastmonth.Weight;
                            total_in_material += inventory_in.Weight * inventory_in.Price;
                            total_out_material += inventory_out.Weight * inventory_out.Price;
                            total_current_material += inventory_currentmonth.Weight * inventory_currentmonth.Price;
                            dt_material.Rows.Add(
                                goods.GoodsName,
                                inventory_lastmonth.Weight,
                                inventory_lastmonth.Price,
                                inventory_lastmonth.Price * inventory_lastmonth.Weight,
                                inventory_in.Weight,
                                inventory_in.Price,
                                inventory_in.Weight * inventory_in.Price,
                                inventory_out.Weight,
                                inventory_out.Price,
                                inventory_out.Weight * inventory_out.Price,
                                inventory_currentmonth.Weight,
                                inventory_currentmonth.Price,
                                inventory_currentmonth.Weight * inventory_currentmonth.Price);
                            break;
                            #endregion
                        }

                    case GoodsController.GoodsType.intermediate:
                        {
                            #region 半成品
                            total_last_intermediate += inventory_lastmonth.Price * inventory_lastmonth.Weight;
                            total_in_intermediate += inventory_in.Weight * inventory_in.Price;
                            total_out_intermediate += inventory_out.Weight * inventory_out.Price;
                            total_current_intermediate += inventory_currentmonth.Weight * inventory_currentmonth.Price;

                            dt_intermediate.Rows.Add(
                                goods.GoodsName,
                                inventory_lastmonth.Weight,
                                inventory_lastmonth.Price,
                                inventory_lastmonth.Price * inventory_lastmonth.Weight,
                                inventory_in.Weight,
                                inventory_in.Price,
                                inventory_in.Weight * inventory_in.Price,
                                inventory_out.Weight,
                                inventory_out.Price,
                                inventory_out.Weight * inventory_out.Price,
                                inventory_currentmonth.Weight,
                                inventory_currentmonth.Price,
                                inventory_currentmonth.Weight * inventory_currentmonth.Price);
                            break;
                            #endregion
                        }

                    default:
                        {
                            break;
                        }
                }
            }
            dt_material.Rows.Add("统计", "", "上月库存:", total_last_material, "", "本月入库:", total_in_material,"", "本月出库:", total_out_material, "", "本月库存:", total_current_material);
            dt_intermediate.Rows.Add("统计", "", "上月库存:", total_last_intermediate, "", "本月入库:", total_in_intermediate,"", "本月出库:", total_out_intermediate, "", "本月库存:", total_current_intermediate);
        }

        private void InitBoundGridView()
        {
            WMS.HeaderItem item = this.bgv_material.Headers.GetHeaderByLocation(0, 0);
            item.EndY = 1;
            item = this.bgv_intermediate.Headers.GetHeaderByLocation(0, 0);
            item.EndY = 1;

            this.bgv_material.Headers.AddHeader(1, 3, 1, 1, "上月库存");
            this.bgv_material.Headers.AddHeader(4, 6, 1, 1, "本月入库");
            this.bgv_material.Headers.AddHeader(7, 9, 1, 1, "本月出库");
            this.bgv_material.Headers.AddHeader(10, 12, 1, 1, "本月库存");

            this.bgv_intermediate.Headers.AddHeader(1, 3, 1, 1, "上月库存");
            this.bgv_intermediate.Headers.AddHeader(4, 6, 1, 1, "本月入库");
            this.bgv_intermediate.Headers.AddHeader(7, 9, 1, 1, "本月出库");
            this.bgv_intermediate.Headers.AddHeader(10, 12, 1, 1, "本月库存");

            dt_material = new DataTable("material");
            dt_material.Columns.Add("c_goodsId");
            dt_material.Columns.Add("c_startWeight");
            dt_material.Columns.Add("c_startPrice");
            dt_material.Columns.Add("c_startTotal");
            dt_material.Columns.Add("c_inWeight");
            dt_material.Columns.Add("c_inPrice");
            dt_material.Columns.Add("c_inTotal");
            dt_material.Columns.Add("c_outWeight");
            dt_material.Columns.Add("c_outPrice");
            dt_material.Columns.Add("c_outTotal");
            dt_material.Columns.Add("c_endWeight");
            dt_material.Columns.Add("c_endPrice");
            dt_material.Columns.Add("c_endTotal");

            dt_intermediate = new DataTable("intermediate");
            dt_intermediate.Columns.Add("c_goodsId");
            dt_intermediate.Columns.Add("c_startWeight");
            dt_intermediate.Columns.Add("c_startPrice");
            dt_intermediate.Columns.Add("c_startTotal");
            dt_intermediate.Columns.Add("c_inWeight");
            dt_intermediate.Columns.Add("c_inPrice");
            dt_intermediate.Columns.Add("c_inTotal");
            dt_intermediate.Columns.Add("c_outWeight");
            dt_intermediate.Columns.Add("c_outPrice");
            dt_intermediate.Columns.Add("c_outTotal");
            dt_intermediate.Columns.Add("c_endWeight");
            dt_intermediate.Columns.Add("c_endPrice");
            dt_intermediate.Columns.Add("c_endTotal");

            this.bgv_material.DataSource = dt_material;
            this.bgv_intermediate.DataSource = dt_intermediate;
        }

        private void SetFormPosition()
        {
            Rectangle rec = SystemInformation.VirtualScreen;
            this.Location = new Point((rec.Width - this.Width) / 2, (rec.Height - this.Height) / 2);
        }

        private void MonthReport_Load(object sender, EventArgs e)
        {
            SetFormPosition();
            InitSettleMonth();
            InitBoundGridView();
        }

        private void tv_settleMonth_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Node.Text))
            {
                InitMonthReport();
            }
        }
    }
}