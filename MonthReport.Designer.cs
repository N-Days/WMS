namespace WMS
{
    partial class MonthReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tv_settleMonth = new System.Windows.Forms.TreeView();
            this.tab_Data = new System.Windows.Forms.TabControl();
            this.page_material = new System.Windows.Forms.TabPage();
            this.bgv_material = new WMS.BoundGridView();
            this.c_goodsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_startWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_startPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_startTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_inWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_inPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_inTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_outWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_outPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_outTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_endWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_endPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_endTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.page_intermediate = new System.Windows.Forms.TabPage();
            this.bgv_intermediate = new WMS.BoundGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tab_Data.SuspendLayout();
            this.page_material.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgv_material)).BeginInit();
            this.page_intermediate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgv_intermediate)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tv_settleMonth);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tab_Data);
            this.splitContainer1.Size = new System.Drawing.Size(808, 392);
            this.splitContainer1.SplitterDistance = 98;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // tv_settleMonth
            // 
            this.tv_settleMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_settleMonth.Location = new System.Drawing.Point(0, 0);
            this.tv_settleMonth.Margin = new System.Windows.Forms.Padding(2);
            this.tv_settleMonth.Name = "tv_settleMonth";
            this.tv_settleMonth.Size = new System.Drawing.Size(98, 392);
            this.tv_settleMonth.TabIndex = 0;
            this.tv_settleMonth.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_settleMonth_AfterSelect);
            // 
            // tab_Data
            // 
            this.tab_Data.Controls.Add(this.page_material);
            this.tab_Data.Controls.Add(this.page_intermediate);
            this.tab_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Data.Location = new System.Drawing.Point(0, 0);
            this.tab_Data.Margin = new System.Windows.Forms.Padding(2);
            this.tab_Data.Name = "tab_Data";
            this.tab_Data.SelectedIndex = 0;
            this.tab_Data.Size = new System.Drawing.Size(708, 392);
            this.tab_Data.TabIndex = 0;
            // 
            // page_material
            // 
            this.page_material.Controls.Add(this.bgv_material);
            this.page_material.Location = new System.Drawing.Point(4, 22);
            this.page_material.Margin = new System.Windows.Forms.Padding(2);
            this.page_material.Name = "page_material";
            this.page_material.Padding = new System.Windows.Forms.Padding(2);
            this.page_material.Size = new System.Drawing.Size(700, 366);
            this.page_material.TabIndex = 0;
            this.page_material.Text = "原材料";
            this.page_material.UseVisualStyleBackColor = true;
            // 
            // bgv_material
            // 
            this.bgv_material.AllowUserToAddRows = false;
            this.bgv_material.AllowUserToDeleteRows = false;
            this.bgv_material.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bgv_material.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_goodsId,
            this.c_startWeight,
            this.c_startPrice,
            this.c_startTotal,
            this.c_inWeight,
            this.c_inPrice,
            this.c_inTotal,
            this.c_outWeight,
            this.c_outPrice,
            this.c_outTotal,
            this.c_endWeight,
            this.c_endPrice,
            this.c_endTotal});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bgv_material.DefaultCellStyle = dataGridViewCellStyle7;
            this.bgv_material.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgv_material.Location = new System.Drawing.Point(2, 2);
            this.bgv_material.Margin = new System.Windows.Forms.Padding(2);
            this.bgv_material.MultiSelect = false;
            this.bgv_material.Name = "bgv_material";
            this.bgv_material.ReadOnly = true;
            this.bgv_material.RowTemplate.Height = 37;
            this.bgv_material.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bgv_material.Size = new System.Drawing.Size(696, 362);
            this.bgv_material.TabIndex = 0;
            // 
            // c_goodsId
            // 
            this.c_goodsId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_goodsId.DataPropertyName = "c_goodsId";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.c_goodsId.DefaultCellStyle = dataGridViewCellStyle1;
            this.c_goodsId.HeaderText = "货物编号";
            this.c_goodsId.Name = "c_goodsId";
            this.c_goodsId.ReadOnly = true;
            // 
            // c_startWeight
            // 
            this.c_startWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_startWeight.DataPropertyName = "c_startWeight";
            this.c_startWeight.HeaderText = "月初重量";
            this.c_startWeight.Name = "c_startWeight";
            this.c_startWeight.ReadOnly = true;
            // 
            // c_startPrice
            // 
            this.c_startPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_startPrice.DataPropertyName = "c_startPrice";
            this.c_startPrice.HeaderText = "月初单价";
            this.c_startPrice.Name = "c_startPrice";
            this.c_startPrice.ReadOnly = true;
            // 
            // c_startTotal
            // 
            this.c_startTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_startTotal.DataPropertyName = "c_startTotal";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.c_startTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.c_startTotal.HeaderText = "月初总值";
            this.c_startTotal.Name = "c_startTotal";
            this.c_startTotal.ReadOnly = true;
            // 
            // c_inWeight
            // 
            this.c_inWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_inWeight.DataPropertyName = "c_inWeight";
            this.c_inWeight.HeaderText = "入库重量";
            this.c_inWeight.Name = "c_inWeight";
            this.c_inWeight.ReadOnly = true;
            // 
            // c_inPrice
            // 
            this.c_inPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_inPrice.DataPropertyName = "c_inPrice";
            this.c_inPrice.HeaderText = "入库单价";
            this.c_inPrice.Name = "c_inPrice";
            this.c_inPrice.ReadOnly = true;
            // 
            // c_inTotal
            // 
            this.c_inTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_inTotal.DataPropertyName = "c_inTotal";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.c_inTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.c_inTotal.HeaderText = "入库总值";
            this.c_inTotal.Name = "c_inTotal";
            this.c_inTotal.ReadOnly = true;
            // 
            // c_outWeight
            // 
            this.c_outWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_outWeight.DataPropertyName = "c_outWeight";
            this.c_outWeight.HeaderText = "出库重量";
            this.c_outWeight.Name = "c_outWeight";
            this.c_outWeight.ReadOnly = true;
            // 
            // c_outPrice
            // 
            this.c_outPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_outPrice.DataPropertyName = "c_outPrice";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.c_outPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.c_outPrice.HeaderText = "出库单价";
            this.c_outPrice.Name = "c_outPrice";
            this.c_outPrice.ReadOnly = true;
            // 
            // c_outTotal
            // 
            this.c_outTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_outTotal.DataPropertyName = "c_outTotal";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.c_outTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.c_outTotal.HeaderText = "出库总值";
            this.c_outTotal.Name = "c_outTotal";
            this.c_outTotal.ReadOnly = true;
            // 
            // c_endWeight
            // 
            this.c_endWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_endWeight.DataPropertyName = "c_endWeight";
            this.c_endWeight.HeaderText = "月末重量";
            this.c_endWeight.Name = "c_endWeight";
            this.c_endWeight.ReadOnly = true;
            // 
            // c_endPrice
            // 
            this.c_endPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_endPrice.DataPropertyName = "c_endPrice";
            this.c_endPrice.HeaderText = "月末单价";
            this.c_endPrice.Name = "c_endPrice";
            this.c_endPrice.ReadOnly = true;
            // 
            // c_endTotal
            // 
            this.c_endTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_endTotal.DataPropertyName = "c_endTotal";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.c_endTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.c_endTotal.HeaderText = "月末总值";
            this.c_endTotal.Name = "c_endTotal";
            this.c_endTotal.ReadOnly = true;
            // 
            // page_intermediate
            // 
            this.page_intermediate.Controls.Add(this.bgv_intermediate);
            this.page_intermediate.Location = new System.Drawing.Point(4, 22);
            this.page_intermediate.Margin = new System.Windows.Forms.Padding(2);
            this.page_intermediate.Name = "page_intermediate";
            this.page_intermediate.Padding = new System.Windows.Forms.Padding(2);
            this.page_intermediate.Size = new System.Drawing.Size(700, 366);
            this.page_intermediate.TabIndex = 1;
            this.page_intermediate.Text = "半成品";
            this.page_intermediate.UseVisualStyleBackColor = true;
            // 
            // bgv_intermediate
            // 
            this.bgv_intermediate.AllowUserToAddRows = false;
            this.bgv_intermediate.AllowUserToDeleteRows = false;
            this.bgv_intermediate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.bgv_intermediate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bgv_intermediate.DefaultCellStyle = dataGridViewCellStyle13;
            this.bgv_intermediate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgv_intermediate.Location = new System.Drawing.Point(2, 2);
            this.bgv_intermediate.Margin = new System.Windows.Forms.Padding(2);
            this.bgv_intermediate.MultiSelect = false;
            this.bgv_intermediate.Name = "bgv_intermediate";
            this.bgv_intermediate.ReadOnly = true;
            this.bgv_intermediate.RowTemplate.Height = 37;
            this.bgv_intermediate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bgv_intermediate.Size = new System.Drawing.Size(696, 362);
            this.bgv_intermediate.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "c_goodsId";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn1.HeaderText = "货物编号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "c_startWeight";
            this.dataGridViewTextBoxColumn2.HeaderText = "月初重量";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "c_startPrice";
            this.dataGridViewTextBoxColumn3.HeaderText = "月初单价";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "c_startTotal";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn4.HeaderText = "月初总值";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "c_inWeight";
            this.dataGridViewTextBoxColumn5.HeaderText = "入库重量";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "c_inPrice";
            this.dataGridViewTextBoxColumn6.HeaderText = "入库单价";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "c_inTotal";
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn7.HeaderText = "入库总值";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "c_outWeight";
            this.dataGridViewTextBoxColumn8.HeaderText = "出库重量";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "c_outPrice";
            this.dataGridViewTextBoxColumn9.HeaderText = "出库单价";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "c_outTotal";
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn10.HeaderText = "出库总值";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "c_endWeight";
            this.dataGridViewTextBoxColumn11.HeaderText = "月末重量";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "c_endPrice";
            this.dataGridViewTextBoxColumn12.HeaderText = "月末单价";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "c_endTotal";
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn13.HeaderText = "月末总值";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // MonthReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 392);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MonthReport";
            this.Text = "月报表";
            this.Load += new System.EventHandler(this.MonthReport_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tab_Data.ResumeLayout(false);
            this.page_material.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bgv_material)).EndInit();
            this.page_intermediate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bgv_intermediate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tab_Data;
        private System.Windows.Forms.TabPage page_material;
        private System.Windows.Forms.TabPage page_intermediate;
        private WMS.BoundGridView bgv_material;
        private System.Windows.Forms.TreeView tv_settleMonth;
        private WMS.BoundGridView bgv_intermediate;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_goodsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_startWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_startPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_startTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_inWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_inPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_inTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_outWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_outPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_outTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_endWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_endPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_endTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
    }
}