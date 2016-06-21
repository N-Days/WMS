namespace WMS
{
    partial class fMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.dg_intermediate = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtn_User = new System.Windows.Forms.ToolStripButton();
            this.toolbtn_GoodsIdTypeIn = new System.Windows.Forms.ToolStripButton();
            this.toolbtn_Inventory = new System.Windows.Forms.ToolStripButton();
            this.toolbtn_IO = new System.Windows.Forms.ToolStripDropDownButton();
            this.原材料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.半成品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbtn_Settled = new System.Windows.Forms.ToolStripDropDownButton();
            this.计算库存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结算库存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbtn_MonthReport = new System.Windows.Forms.ToolStripButton();
            this.toolbtn_Statistic = new System.Windows.Forms.ToolStripButton();
            this.toolbtn_Operation = new System.Windows.Forms.ToolStripButton();
            this.toolbtn_Import = new System.Windows.Forms.ToolStripButton();
            this.toolbtn_Export = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dg_material = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lab_material = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lab_intermediate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_intermediate)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_material)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_intermediate
            // 
            this.dg_intermediate.AllowUserToAddRows = false;
            this.dg_intermediate.AllowUserToDeleteRows = false;
            this.dg_intermediate.AllowUserToResizeRows = false;
            this.dg_intermediate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_intermediate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_intermediate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_intermediate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_intermediate.Location = new System.Drawing.Point(0, 66);
            this.dg_intermediate.Margin = new System.Windows.Forms.Padding(0);
            this.dg_intermediate.MultiSelect = false;
            this.dg_intermediate.Name = "dg_intermediate";
            this.dg_intermediate.ReadOnly = true;
            this.dg_intermediate.RowHeadersVisible = false;
            this.dg_intermediate.RowTemplate.Height = 23;
            this.dg_intermediate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_intermediate.Size = new System.Drawing.Size(969, 936);
            this.dg_intermediate.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 38);
            this.splitter1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 1024);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtn_User,
            this.toolbtn_GoodsIdTypeIn,
            this.toolbtn_Inventory,
            this.toolbtn_IO,
            this.toolbtn_Settled,
            this.toolbtn_MonthReport,
            this.toolbtn_Statistic,
            this.toolbtn_Operation,
            this.toolbtn_Import,
            this.toolbtn_Export});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1924, 38);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbtn_User
            // 
            this.toolbtn_User.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_User.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_User.Image")));
            this.toolbtn_User.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_User.Name = "toolbtn_User";
            this.toolbtn_User.Size = new System.Drawing.Size(114, 35);
            this.toolbtn_User.Text = "用户管理";
            this.toolbtn_User.Click += new System.EventHandler(this.toolbtn_User_Click);
            // 
            // toolbtn_GoodsIdTypeIn
            // 
            this.toolbtn_GoodsIdTypeIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_GoodsIdTypeIn.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_GoodsIdTypeIn.Image")));
            this.toolbtn_GoodsIdTypeIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_GoodsIdTypeIn.Name = "toolbtn_GoodsIdTypeIn";
            this.toolbtn_GoodsIdTypeIn.Size = new System.Drawing.Size(114, 35);
            this.toolbtn_GoodsIdTypeIn.Text = "编号录入";
            this.toolbtn_GoodsIdTypeIn.Click += new System.EventHandler(this.toolbtn_GoodsIdTypeIn_Click);
            // 
            // toolbtn_Inventory
            // 
            this.toolbtn_Inventory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_Inventory.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_Inventory.Image")));
            this.toolbtn_Inventory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_Inventory.Name = "toolbtn_Inventory";
            this.toolbtn_Inventory.Size = new System.Drawing.Size(114, 35);
            this.toolbtn_Inventory.Text = "库存录入";
            this.toolbtn_Inventory.Click += new System.EventHandler(this.toolbtn_Inventory_Click);
            // 
            // toolbtn_IO
            // 
            this.toolbtn_IO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_IO.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.原材料ToolStripMenuItem,
            this.半成品ToolStripMenuItem});
            this.toolbtn_IO.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_IO.Image")));
            this.toolbtn_IO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_IO.Name = "toolbtn_IO";
            this.toolbtn_IO.Size = new System.Drawing.Size(147, 35);
            this.toolbtn_IO.Text = "进出库记录";
            // 
            // 原材料ToolStripMenuItem
            // 
            this.原材料ToolStripMenuItem.Name = "原材料ToolStripMenuItem";
            this.原材料ToolStripMenuItem.Size = new System.Drawing.Size(160, 36);
            this.原材料ToolStripMenuItem.Text = "原材料";
            this.原材料ToolStripMenuItem.Click += new System.EventHandler(this.原材料ToolStripMenuItem_Click);
            // 
            // 半成品ToolStripMenuItem
            // 
            this.半成品ToolStripMenuItem.Name = "半成品ToolStripMenuItem";
            this.半成品ToolStripMenuItem.Size = new System.Drawing.Size(160, 36);
            this.半成品ToolStripMenuItem.Text = "半成品";
            this.半成品ToolStripMenuItem.Click += new System.EventHandler(this.半成品ToolStripMenuItem_Click);
            // 
            // toolbtn_Settled
            // 
            this.toolbtn_Settled.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_Settled.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.计算库存ToolStripMenuItem,
            this.结算库存ToolStripMenuItem});
            this.toolbtn_Settled.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_Settled.Image")));
            this.toolbtn_Settled.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_Settled.Name = "toolbtn_Settled";
            this.toolbtn_Settled.Size = new System.Drawing.Size(123, 35);
            this.toolbtn_Settled.Text = "库存核算";
            // 
            // 计算库存ToolStripMenuItem
            // 
            this.计算库存ToolStripMenuItem.Name = "计算库存ToolStripMenuItem";
            this.计算库存ToolStripMenuItem.Size = new System.Drawing.Size(184, 36);
            this.计算库存ToolStripMenuItem.Text = "计算库存";
            this.计算库存ToolStripMenuItem.Click += new System.EventHandler(this.计算库存ToolStripMenuItem_Click);
            // 
            // 结算库存ToolStripMenuItem
            // 
            this.结算库存ToolStripMenuItem.Name = "结算库存ToolStripMenuItem";
            this.结算库存ToolStripMenuItem.Size = new System.Drawing.Size(184, 36);
            this.结算库存ToolStripMenuItem.Text = "结算库存";
            this.结算库存ToolStripMenuItem.Click += new System.EventHandler(this.结算库存ToolStripMenuItem_Click);
            // 
            // toolbtn_MonthReport
            // 
            this.toolbtn_MonthReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_MonthReport.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_MonthReport.Image")));
            this.toolbtn_MonthReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_MonthReport.Name = "toolbtn_MonthReport";
            this.toolbtn_MonthReport.Size = new System.Drawing.Size(138, 35);
            this.toolbtn_MonthReport.Text = "月报表视图";
            this.toolbtn_MonthReport.Click += new System.EventHandler(this.toolbtn_MonthReport_Click);
            // 
            // toolbtn_Statistic
            // 
            this.toolbtn_Statistic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_Statistic.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_Statistic.Image")));
            this.toolbtn_Statistic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_Statistic.Name = "toolbtn_Statistic";
            this.toolbtn_Statistic.Size = new System.Drawing.Size(114, 35);
            this.toolbtn_Statistic.Text = "月份统计";
            this.toolbtn_Statistic.Click += new System.EventHandler(this.toolbtn_Statistic_Click);
            // 
            // toolbtn_Operation
            // 
            this.toolbtn_Operation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_Operation.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_Operation.Image")));
            this.toolbtn_Operation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_Operation.Name = "toolbtn_Operation";
            this.toolbtn_Operation.Size = new System.Drawing.Size(114, 35);
            this.toolbtn_Operation.Text = "操作日志";
            this.toolbtn_Operation.Click += new System.EventHandler(this.toolbtn_Operation_Click);
            // 
            // toolbtn_Import
            // 
            this.toolbtn_Import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_Import.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_Import.Image")));
            this.toolbtn_Import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_Import.Name = "toolbtn_Import";
            this.toolbtn_Import.Size = new System.Drawing.Size(114, 35);
            this.toolbtn_Import.Text = "数据导入";
            this.toolbtn_Import.Click += new System.EventHandler(this.toolbtn_Import_Click);
            // 
            // toolbtn_Export
            // 
            this.toolbtn_Export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtn_Export.Image = ((System.Drawing.Image)(resources.GetObject("toolbtn_Export.Image")));
            this.toolbtn_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_Export.Name = "toolbtn_Export";
            this.toolbtn_Export.Size = new System.Drawing.Size(114, 35);
            this.toolbtn_Export.Text = "数据导出";
            this.toolbtn_Export.Click += new System.EventHandler(this.toolbtn_Export_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(6, 38);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dg_material);
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dg_intermediate);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip2);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1918, 1024);
            this.splitContainer1.SplitterDistance = 941;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 4;
            // 
            // dg_material
            // 
            this.dg_material.AllowUserToAddRows = false;
            this.dg_material.AllowUserToDeleteRows = false;
            this.dg_material.AllowUserToResizeRows = false;
            this.dg_material.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_material.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_material.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_material.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_material.Location = new System.Drawing.Point(0, 68);
            this.dg_material.Margin = new System.Windows.Forms.Padding(0);
            this.dg_material.MultiSelect = false;
            this.dg_material.Name = "dg_material";
            this.dg_material.ReadOnly = true;
            this.dg_material.RowHeadersVisible = false;
            this.dg_material.RowTemplate.Height = 23;
            this.dg_material.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_material.Size = new System.Drawing.Size(941, 934);
            this.dg_material.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 1002);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(941, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 68);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lab_material);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(941, 66);
            this.panel2.TabIndex = 2;
            // 
            // lab_material
            // 
            this.lab_material.AutoSize = true;
            this.lab_material.Location = new System.Drawing.Point(404, 20);
            this.lab_material.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lab_material.Name = "lab_material";
            this.lab_material.Size = new System.Drawing.Size(130, 24);
            this.lab_material.TabIndex = 1;
            this.lab_material.Text = "原材料仓库";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "原材料仓库";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Location = new System.Drawing.Point(0, 1002);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip2.Size = new System.Drawing.Size(969, 22);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lab_intermediate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(969, 66);
            this.panel3.TabIndex = 1;
            // 
            // lab_intermediate
            // 
            this.lab_intermediate.AutoSize = true;
            this.lab_intermediate.Location = new System.Drawing.Point(440, 20);
            this.lab_intermediate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lab_intermediate.Name = "lab_intermediate";
            this.lab_intermediate.Size = new System.Drawing.Size(130, 24);
            this.lab_intermediate.TabIndex = 1;
            this.lab_intermediate.Text = "半成品仓库";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1062);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "fMain";
            this.Text = "和泰仓管系统";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.SizeChanged += new System.EventHandler(this.fMain_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dg_intermediate)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_material)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_intermediate;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dg_material;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lab_material;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lab_intermediate;
        private System.Windows.Forms.ToolStripButton toolbtn_User;
        private System.Windows.Forms.ToolStripButton toolbtn_Operation;
        private System.Windows.Forms.ToolStripButton toolbtn_GoodsIdTypeIn;
        private System.Windows.Forms.ToolStripButton toolbtn_Inventory;
        private System.Windows.Forms.ToolStripDropDownButton toolbtn_IO;
        private System.Windows.Forms.ToolStripMenuItem 原材料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 半成品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolbtn_Settled;
        private System.Windows.Forms.ToolStripMenuItem 计算库存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结算库存ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripButton toolbtn_Statistic;
        private System.Windows.Forms.ToolStripButton toolbtn_Import;
        private System.Windows.Forms.ToolStripButton toolbtn_Export;
        private System.Windows.Forms.ToolStripButton toolbtn_MonthReport;
    }
}

