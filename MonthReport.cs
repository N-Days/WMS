using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS.Controllers;
using WMS.Model;
using WMS.Common;

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

        private DataTable dt_material = null;
        private DataTable dt_intermediate = null;
        private const string c_view = "select * from MonthReport where goodsType=@goodsType and settleMonth=@settleMonth union select '统计',null,null,round(sum(MonthReport.月初总值),2),null,null,round(sum(MonthReport.入库总值),2),null,null,round(sum(MonthReport.出库总值),2),null,null,round(sum(MonthReport.月末总值),2),null,null from  MonthReport where goodsType=@goodsType and settleMonth=@settleMonth order by goodsType desc";

        private void InitSettleMonth()
        {
            var month_list = TimeController.GetAllSettleMonth(true);
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

            var list_inventory_lastmonth = inventorycontroller.GetInventoryBySettleMonth(TimeController.GetLastMonth(this.tv_settleMonth.SelectedNode.Text));
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

                var inventory_in = new Model.Inventory_IO();
                var inventory_out = new Model.Inventory_IO();

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

                var inventory_lastmonth = list_inventory_lastmonth.FirstOrDefault(i => i.GoodsID == goods.ID) ?? new Inventory();
                var inventory_currentmonth = list_inventory_currentmonth.FirstOrDefault(i => i.GoodsID == goods.ID) ?? new Inventory();

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
                                inventory_lastmonth.Weight.ToString("n2"),
                                inventory_lastmonth.Price.ToString("n2"),
                                (inventory_lastmonth.Price * inventory_lastmonth.Weight).ToString("n2"),
                                inventory_in.Weight.ToString("n2"),
                                inventory_in.Price.ToString("n2"),
                                (inventory_in.Weight * inventory_in.Price).ToString("n2"),
                                inventory_out.Weight.ToString("n2"),
                                inventory_out.Price.ToString("n2"),
                                (inventory_out.Weight * inventory_out.Price).ToString("n2"),
                                inventory_currentmonth.Weight.ToString("n2"),
                                inventory_currentmonth.Price.ToString("n2"),
                                (inventory_currentmonth.Weight * inventory_currentmonth.Price).ToString("n2"));
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
                                inventory_lastmonth.Weight.ToString("n2"),
                                inventory_lastmonth.Price.ToString("n2"),
                                (inventory_lastmonth.Price * inventory_lastmonth.Weight).ToString("n2"),
                                inventory_in.Weight.ToString("n2"),
                                inventory_in.Price.ToString("n2"),
                                (inventory_in.Weight * inventory_in.Price).ToString("n2"),
                                inventory_out.Weight.ToString("n2"),
                                inventory_out.Price.ToString("n2"),
                                (inventory_out.Weight * inventory_out.Price).ToString("n2"),
                                inventory_currentmonth.Weight.ToString("n2"),
                                inventory_currentmonth.Price.ToString("n2"),
                                (inventory_currentmonth.Weight * inventory_currentmonth.Price).ToString("n2"));
                            break;
                            #endregion
                        }

                    default:
                        {
                            break;
                        }
                }
            }
            dt_material.Rows.Add("统计", "", "上月库存:", total_last_material.ToString("n2"), "", "本月入库:", total_in_material.ToString("n2"), "", "本月出库:", total_out_material.ToString("n2"), "", "本月库存:", total_current_material.ToString("n2"));
            dt_intermediate.Rows.Add("统计", "", "上月库存:", total_last_intermediate.ToString("n2"), "", "本月入库:", total_in_intermediate.ToString("n2"), "", "本月出库:", total_out_intermediate.ToString("n2"), "", "本月库存:", total_current_intermediate.ToString("n2"));
        }

        private void _getmonthreport()
        {
            dt_intermediate.Rows.Clear();
            dt_material.Rows.Clear();
            var _dt_intermediate = GlobalParam.DataBase.Query_DataView(c_view, new System.Data.SQLite.SQLiteParameter[]
                                                                        {
                                                                            new System.Data.SQLite.SQLiteParameter("@goodsType","intermediate"),
                                                                            new System.Data.SQLite.SQLiteParameter("@settleMonth",this.tv_settleMonth.SelectedNode.Text),
                                                                        }).Table;
            var _dt_material = GlobalParam.DataBase.Query_DataView(c_view, new System.Data.SQLite.SQLiteParameter[]
                                                                        {
                                                                            new System.Data.SQLite.SQLiteParameter("@goodsType","material"),
                                                                            new System.Data.SQLite.SQLiteParameter("@settleMonth",this.tv_settleMonth.SelectedNode.Text),
                                                                        }).Table;
            for (int i = 0; i < _dt_intermediate.Rows.Count-1; i++)
                dt_intermediate.Rows.Add(_dt_intermediate.Rows[i][0], _dt_intermediate.Rows[i][1], _dt_intermediate.Rows[i][2], _dt_intermediate.Rows[i][3], _dt_intermediate.Rows[i][4], _dt_intermediate.Rows[i][5], _dt_intermediate.Rows[i][6], _dt_intermediate.Rows[i][7], _dt_intermediate.Rows[i][8], _dt_intermediate.Rows[i][9], _dt_intermediate.Rows[i][10], _dt_intermediate.Rows[i][11], _dt_intermediate.Rows[i][12]);
            for (int i = 0; i < _dt_material.Rows.Count-1; i++)
                dt_material.Rows.Add(_dt_material.Rows[i][0], _dt_material.Rows[i][1], _dt_material.Rows[i][2], _dt_material.Rows[i][3], _dt_material.Rows[i][4], _dt_material.Rows[i][5], _dt_material.Rows[i][6], _dt_material.Rows[i][7], _dt_material.Rows[i][8], _dt_material.Rows[i][9], _dt_material.Rows[i][10], _dt_material.Rows[i][11], _dt_material.Rows[i][12]);

            var count_intermediate = _dt_intermediate.Rows.Count - 1;
            dt_intermediate.Rows.Add("统计",
                string.Empty, "月初库存:", _dt_intermediate.Rows[count_intermediate][3],
                string.Empty, "本月入库:", _dt_intermediate.Rows[count_intermediate][6],
                string.Empty, "本月出库:", _dt_intermediate.Rows[count_intermediate][9],
                string.Empty, "月末库存:", _dt_intermediate.Rows[count_intermediate][12]);

            var count_material = _dt_material.Rows.Count - 1;
            dt_material.Rows.Add("统计",
                string.Empty, "月初库存:", _dt_material.Rows[count_material][3],
                string.Empty, "本月入库:", _dt_material.Rows[count_material][6],
                string.Empty, "本月出库:", _dt_material.Rows[count_material][9],
                string.Empty, "月末库存:", _dt_material.Rows[count_material][12]);
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
            dt_material.Columns.Add("c_startTotal", typeof(double));
            dt_material.Columns.Add("c_inWeight");
            dt_material.Columns.Add("c_inPrice");
            dt_material.Columns.Add("c_inTotal", typeof(double));
            dt_material.Columns.Add("c_outWeight");
            dt_material.Columns.Add("c_outPrice");
            dt_material.Columns.Add("c_outTotal", typeof(double));
            dt_material.Columns.Add("c_endWeight");
            dt_material.Columns.Add("c_endPrice");
            dt_material.Columns.Add("c_endTotal", typeof(double));

            dt_intermediate = new DataTable("intermediate");
            dt_intermediate.Columns.Add("c_goodsId");
            dt_intermediate.Columns.Add("c_startWeight");
            dt_intermediate.Columns.Add("c_startPrice");
            dt_intermediate.Columns.Add("c_startTotal", typeof(double));
            dt_intermediate.Columns.Add("c_inWeight");
            dt_intermediate.Columns.Add("c_inPrice");
            dt_intermediate.Columns.Add("c_inTotal", typeof(double));
            dt_intermediate.Columns.Add("c_outWeight");
            dt_intermediate.Columns.Add("c_outPrice");
            dt_intermediate.Columns.Add("c_outTotal", typeof(double));
            dt_intermediate.Columns.Add("c_endWeight");
            dt_intermediate.Columns.Add("c_endPrice");
            dt_intermediate.Columns.Add("c_endTotal", typeof(double));

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
                _getmonthreport();
                //InitMonthReport();
            }
        }
    }
}