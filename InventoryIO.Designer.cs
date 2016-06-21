namespace WMS
{
    partial class InventoryIO
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
            this.dg_IO = new System.Windows.Forms.DataGridView();
            this.menu_IO = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.date_settleMonth = new System.Windows.Forms.DateTimePicker();
            this.cbx_GoodsName = new System.Windows.Forms.ComboBox();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Last = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Price = new System.Windows.Forms.TextBox();
            this.txt_Weight = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_IO)).BeginInit();
            this.menu_IO.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dg_IO);
            this.splitContainer1.Panel1.Controls.Add(this.date_settleMonth);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cbx_GoodsName);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Next);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Last);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Price);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Weight);
            this.splitContainer1.Size = new System.Drawing.Size(946, 972);
            this.splitContainer1.SplitterDistance = 608;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // dg_IO
            // 
            this.dg_IO.AllowUserToAddRows = false;
            this.dg_IO.AllowUserToDeleteRows = false;
            this.dg_IO.AllowUserToResizeRows = false;
            this.dg_IO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_IO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_IO.ContextMenuStrip = this.menu_IO;
            this.dg_IO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_IO.Location = new System.Drawing.Point(0, 35);
            this.dg_IO.Margin = new System.Windows.Forms.Padding(6);
            this.dg_IO.Name = "dg_IO";
            this.dg_IO.ReadOnly = true;
            this.dg_IO.RowHeadersVisible = false;
            this.dg_IO.RowTemplate.Height = 23;
            this.dg_IO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_IO.Size = new System.Drawing.Size(608, 937);
            this.dg_IO.TabIndex = 2;
            // 
            // menu_IO
            // 
            this.menu_IO.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menu_IO.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.menu_IO.Name = "menu_IO";
            this.menu_IO.Size = new System.Drawing.Size(137, 40);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(136, 36);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // date_settleMonth
            // 
            this.date_settleMonth.CustomFormat = "yyyy-MM";
            this.date_settleMonth.Dock = System.Windows.Forms.DockStyle.Top;
            this.date_settleMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_settleMonth.Location = new System.Drawing.Point(0, 0);
            this.date_settleMonth.Margin = new System.Windows.Forms.Padding(6);
            this.date_settleMonth.Name = "date_settleMonth";
            this.date_settleMonth.Size = new System.Drawing.Size(608, 35);
            this.date_settleMonth.TabIndex = 3;
            this.date_settleMonth.ValueChanged += new System.EventHandler(this.date_settleMonth_ValueChanged);
            // 
            // cbx_GoodsName
            // 
            this.cbx_GoodsName.FormattingEnabled = true;
            this.cbx_GoodsName.Location = new System.Drawing.Point(38, 180);
            this.cbx_GoodsName.Margin = new System.Windows.Forms.Padding(6);
            this.cbx_GoodsName.Name = "cbx_GoodsName";
            this.cbx_GoodsName.Size = new System.Drawing.Size(264, 32);
            this.cbx_GoodsName.TabIndex = 14;
            // 
            // btn_Next
            // 
            this.btn_Next.Location = new System.Drawing.Point(38, 679);
            this.btn_Next.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(268, 90);
            this.btn_Next.TabIndex = 13;
            this.btn_Next.Text = "下一个";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Last
            // 
            this.btn_Last.Location = new System.Drawing.Point(38, 577);
            this.btn_Last.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Last.Name = "btn_Last";
            this.btn_Last.Size = new System.Drawing.Size(268, 90);
            this.btn_Last.TabIndex = 12;
            this.btn_Last.Text = "上一个";
            this.btn_Last.UseVisualStyleBackColor = true;
            this.btn_Last.Click += new System.EventHandler(this.btn_Last_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 398);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "价格(每公斤):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 274);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "重量(公斤):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 150);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "名称:";
            // 
            // txt_Price
            // 
            this.txt_Price.Location = new System.Drawing.Point(38, 428);
            this.txt_Price.Margin = new System.Windows.Forms.Padding(6);
            this.txt_Price.Name = "txt_Price";
            this.txt_Price.Size = new System.Drawing.Size(264, 35);
            this.txt_Price.TabIndex = 4;
            this.txt_Price.Text = "0.0";
            // 
            // txt_Weight
            // 
            this.txt_Weight.Location = new System.Drawing.Point(38, 304);
            this.txt_Weight.Margin = new System.Windows.Forms.Padding(6);
            this.txt_Weight.Name = "txt_Weight";
            this.txt_Weight.Size = new System.Drawing.Size(264, 35);
            this.txt_Weight.TabIndex = 5;
            this.txt_Weight.Text = "0.0";
            // 
            // InventoryIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 972);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "InventoryIO";
            this.Text = "进出库记录";
            this.Load += new System.EventHandler(this.InventoryIO_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_IO)).EndInit();
            this.menu_IO.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dg_IO;
        private System.Windows.Forms.DateTimePicker date_settleMonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Price;
        private System.Windows.Forms.TextBox txt_Weight;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Last;
        private System.Windows.Forms.ComboBox cbx_GoodsName;
        private System.Windows.Forms.ContextMenuStrip menu_IO;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;

    }
}