namespace WMS
{
    partial class GoodsRecord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btn_ClearRecord = new System.Windows.Forms.Button();
            this.btn_RecordDone = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Weight = new System.Windows.Forms.TextBox();
            this.txt_Price = new System.Windows.Forms.TextBox();
            this.txt_Color = new System.Windows.Forms.TextBox();
            this.txt_GoodsName = new System.Windows.Forms.TextBox();
            this.cbx_GoodsType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dg_Goods = new System.Windows.Forms.DataGridView();
            this.menu_goods = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_cannel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Goods)).BeginInit();
            this.menu_goods.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_cannel);
            this.splitContainer1.Panel2.Controls.Add(this.btn_OK);
            this.splitContainer1.Size = new System.Drawing.Size(654, 463);
            this.splitContainer1.SplitterDistance = 426;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btn_ClearRecord);
            this.splitContainer2.Panel1.Controls.Add(this.btn_RecordDone);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.txt_Weight);
            this.splitContainer2.Panel1.Controls.Add(this.txt_Price);
            this.splitContainer2.Panel1.Controls.Add(this.txt_Color);
            this.splitContainer2.Panel1.Controls.Add(this.txt_GoodsName);
            this.splitContainer2.Panel1.Controls.Add(this.cbx_GoodsType);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dg_Goods);
            this.splitContainer2.Size = new System.Drawing.Size(654, 426);
            this.splitContainer2.SplitterDistance = 254;
            this.splitContainer2.TabIndex = 0;
            // 
            // btn_ClearRecord
            // 
            this.btn_ClearRecord.Location = new System.Drawing.Point(129, 298);
            this.btn_ClearRecord.Name = "btn_ClearRecord";
            this.btn_ClearRecord.Size = new System.Drawing.Size(75, 23);
            this.btn_ClearRecord.TabIndex = 16;
            this.btn_ClearRecord.Text = "清空录入";
            this.btn_ClearRecord.UseVisualStyleBackColor = true;
            this.btn_ClearRecord.Click += new System.EventHandler(this.btn_ClearRecord_Click);
            // 
            // btn_RecordDone
            // 
            this.btn_RecordDone.Location = new System.Drawing.Point(37, 298);
            this.btn_RecordDone.Name = "btn_RecordDone";
            this.btn_RecordDone.Size = new System.Drawing.Size(75, 23);
            this.btn_RecordDone.TabIndex = 15;
            this.btn_RecordDone.Text = "录入完成";
            this.btn_RecordDone.UseVisualStyleBackColor = true;
            this.btn_RecordDone.Click += new System.EventHandler(this.btn_RecordDone_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "初始重量:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "初始价格:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "颜色:";
            // 
            // txt_Weight
            // 
            this.txt_Weight.Location = new System.Drawing.Point(83, 221);
            this.txt_Weight.Name = "txt_Weight";
            this.txt_Weight.Size = new System.Drawing.Size(121, 21);
            this.txt_Weight.TabIndex = 10;
            this.txt_Weight.Text = "0.0";
            // 
            // txt_Price
            // 
            this.txt_Price.Location = new System.Drawing.Point(83, 184);
            this.txt_Price.Name = "txt_Price";
            this.txt_Price.Size = new System.Drawing.Size(121, 21);
            this.txt_Price.TabIndex = 11;
            this.txt_Price.Text = "0.0";
            // 
            // txt_Color
            // 
            this.txt_Color.Location = new System.Drawing.Point(83, 147);
            this.txt_Color.Name = "txt_Color";
            this.txt_Color.Size = new System.Drawing.Size(121, 21);
            this.txt_Color.TabIndex = 8;
            // 
            // txt_GoodsName
            // 
            this.txt_GoodsName.Location = new System.Drawing.Point(83, 110);
            this.txt_GoodsName.Name = "txt_GoodsName";
            this.txt_GoodsName.Size = new System.Drawing.Size(121, 21);
            this.txt_GoodsName.TabIndex = 9;
            // 
            // cbx_GoodsType
            // 
            this.cbx_GoodsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_GoodsType.FormattingEnabled = true;
            this.cbx_GoodsType.Items.AddRange(new object[] {
            "半成品",
            "原材料"});
            this.cbx_GoodsType.Location = new System.Drawing.Point(83, 73);
            this.cbx_GoodsType.Name = "cbx_GoodsType";
            this.cbx_GoodsType.Size = new System.Drawing.Size(121, 20);
            this.cbx_GoodsType.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "种类:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "名称:";
            // 
            // dg_Goods
            // 
            this.dg_Goods.AllowUserToAddRows = false;
            this.dg_Goods.AllowUserToDeleteRows = false;
            this.dg_Goods.AllowUserToResizeRows = false;
            this.dg_Goods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dg_Goods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Goods.ContextMenuStrip = this.menu_goods;
            this.dg_Goods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Goods.Location = new System.Drawing.Point(0, 0);
            this.dg_Goods.MultiSelect = false;
            this.dg_Goods.Name = "dg_Goods";
            this.dg_Goods.ReadOnly = true;
            this.dg_Goods.RowHeadersVisible = false;
            this.dg_Goods.RowTemplate.Height = 23;
            this.dg_Goods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Goods.Size = new System.Drawing.Size(394, 424);
            this.dg_Goods.TabIndex = 0;
            this.dg_Goods.DoubleClick += new System.EventHandler(this.dg_Goods_DoubleClick);
            // 
            // menu_goods
            // 
            this.menu_goods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.menu_goods.Name = "menu_goods";
            this.menu_goods.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // btn_cannel
            // 
            this.btn_cannel.Location = new System.Drawing.Point(332, 5);
            this.btn_cannel.Name = "btn_cannel";
            this.btn_cannel.Size = new System.Drawing.Size(75, 23);
            this.btn_cannel.TabIndex = 1;
            this.btn_cannel.Text = "取消";
            this.btn_cannel.UseVisualStyleBackColor = true;
            this.btn_cannel.Click += new System.EventHandler(this.btn_cannel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(226, 5);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // GoodsRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 463);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GoodsRecord";
            this.Text = "品种录入";
            this.Load += new System.EventHandler(this.GoodsRecord_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Goods)).EndInit();
            this.menu_goods.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btn_ClearRecord;
        private System.Windows.Forms.Button btn_RecordDone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Weight;
        private System.Windows.Forms.TextBox txt_Price;
        private System.Windows.Forms.TextBox txt_Color;
        private System.Windows.Forms.TextBox txt_GoodsName;
        private System.Windows.Forms.ComboBox cbx_GoodsType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dg_Goods;
        private System.Windows.Forms.Button btn_cannel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.ContextMenuStrip menu_goods;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}