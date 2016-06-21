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
    public partial class IO_TypeIn : Form
    {
        private List<Model.Goods> Goods_List = new List<Model.Goods>();

        private string _goodstype = null;

        public IO_TypeIn(string goodsType)
        {
            InitializeComponent();
        }

        private void CheckContent()
        {
        }

        private void SetDefaultValue()
        {

        }

        private void InitData()
        {
            GoodsController goods_controller = new GoodsController();
            Goods_List=(List<Model.Goods>)goods_controller.GetGoodsByType(_goodstype); 
        }

        private void fTypeIn_Load(object sender, EventArgs e)
        {
            this.Location = Cursor.Position;
            InitData();
            cBox_Status.SelectedIndex=0;
        }
    }
}

