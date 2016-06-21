namespace WMS
{
    partial class InventoryForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lv_Material = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lv_Intermediate = new System.Windows.Forms.ListView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dg_Inventory = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.btn_Cannel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lab_Color = new System.Windows.Forms.Label();
            this.lab_GoodsName = new System.Windows.Forms.Label();
            this.txt_Weight = new System.Windows.Forms.TextBox();
            this.txt_Price = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1508, 1002);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(280, 1002);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lv_Material);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Size = new System.Drawing.Size(264, 955);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "原材料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lv_Material
            // 
            this.lv_Material.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Material.GridLines = true;
            this.lv_Material.Location = new System.Drawing.Point(6, 6);
            this.lv_Material.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lv_Material.MultiSelect = false;
            this.lv_Material.Name = "lv_Material";
            this.lv_Material.Size = new System.Drawing.Size(252, 943);
            this.lv_Material.TabIndex = 0;
            this.lv_Material.UseCompatibleStateImageBehavior = false;
            this.lv_Material.View = System.Windows.Forms.View.Details;
            this.lv_Material.DoubleClick += new System.EventHandler(this.lv_Material_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lv_Intermediate);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Size = new System.Drawing.Size(264, 955);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "半成品";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lv_Intermediate
            // 
            this.lv_Intermediate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Intermediate.GridLines = true;
            this.lv_Intermediate.Location = new System.Drawing.Point(6, 6);
            this.lv_Intermediate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lv_Intermediate.MultiSelect = false;
            this.lv_Intermediate.Name = "lv_Intermediate";
            this.lv_Intermediate.Size = new System.Drawing.Size(252, 943);
            this.lv_Intermediate.TabIndex = 0;
            this.lv_Intermediate.UseCompatibleStateImageBehavior = false;
            this.lv_Intermediate.View = System.Windows.Forms.View.Details;
            this.lv_Intermediate.DoubleClick += new System.EventHandler(this.lv_Intermediate_DoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dg_Inventory);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.date);
            this.splitContainer2.Panel2.Controls.Add(this.btn_Cannel);
            this.splitContainer2.Panel2.Controls.Add(this.btn_OK);
            this.splitContainer2.Panel2.Controls.Add(this.label8);
            this.splitContainer2.Panel2.Controls.Add(this.lab_Color);
            this.splitContainer2.Panel2.Controls.Add(this.lab_GoodsName);
            this.splitContainer2.Panel2.Controls.Add(this.txt_Weight);
            this.splitContainer2.Panel2.Controls.Add(this.txt_Price);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(1220, 1002);
            this.splitContainer2.SplitterDistance = 512;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 0;
            // 
            // dg_Inventory
            // 
            this.dg_Inventory.AllowUserToAddRows = false;
            this.dg_Inventory.AllowUserToDeleteRows = false;
            this.dg_Inventory.AllowUserToResizeRows = false;
            this.dg_Inventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_Inventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Inventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Inventory.Location = new System.Drawing.Point(0, 0);
            this.dg_Inventory.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dg_Inventory.MultiSelect = false;
            this.dg_Inventory.Name = "dg_Inventory";
            this.dg_Inventory.ReadOnly = true;
            this.dg_Inventory.RowHeadersVisible = false;
            this.dg_Inventory.RowTemplate.Height = 23;
            this.dg_Inventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Inventory.Size = new System.Drawing.Size(1220, 512);
            this.dg_Inventory.TabIndex = 2;
            this.dg_Inventory.DoubleClick += new System.EventHandler(this.dg_Inventory_DoubleClick);
            // 
            // date
            // 
            this.date.CustomFormat = "yyyy-MM";
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(550, 280);
            this.date.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(200, 35);
            this.date.TabIndex = 12;
            // 
            // btn_Cannel
            // 
            this.btn_Cannel.Location = new System.Drawing.Point(688, 412);
            this.btn_Cannel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_Cannel.Name = "btn_Cannel";
            this.btn_Cannel.Size = new System.Drawing.Size(150, 46);
            this.btn_Cannel.TabIndex = 11;
            this.btn_Cannel.Text = "取消";
            this.btn_Cannel.UseVisualStyleBackColor = true;
            this.btn_Cannel.Click += new System.EventHandler(this.btn_Cannel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(320, 412);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(150, 46);
            this.btn_OK.TabIndex = 11;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(420, 290);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 24);
            this.label8.TabIndex = 9;
            this.label8.Text = "结算月份:";
            // 
            // lab_Color
            // 
            this.lab_Color.AutoSize = true;
            this.lab_Color.Location = new System.Drawing.Point(550, 108);
            this.lab_Color.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lab_Color.Name = "lab_Color";
            this.lab_Color.Size = new System.Drawing.Size(0, 24);
            this.lab_Color.TabIndex = 8;
            // 
            // lab_GoodsName
            // 
            this.lab_GoodsName.AutoSize = true;
            this.lab_GoodsName.Location = new System.Drawing.Point(550, 46);
            this.lab_GoodsName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lab_GoodsName.Name = "lab_GoodsName";
            this.lab_GoodsName.Size = new System.Drawing.Size(0, 24);
            this.lab_GoodsName.TabIndex = 7;
            // 
            // txt_Weight
            // 
            this.txt_Weight.Location = new System.Drawing.Point(554, 226);
            this.txt_Weight.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_Weight.Name = "txt_Weight";
            this.txt_Weight.Size = new System.Drawing.Size(196, 35);
            this.txt_Weight.TabIndex = 6;
            this.txt_Weight.Text = "0.0";
            // 
            // txt_Price
            // 
            this.txt_Price.Location = new System.Drawing.Point(554, 164);
            this.txt_Price.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_Price.Name = "txt_Price";
            this.txt_Price.Size = new System.Drawing.Size(196, 35);
            this.txt_Price.TabIndex = 5;
            this.txt_Price.Text = "0.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(194, 356);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(814, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "注意:修改货物价格或重量,将锁定此货物,即该货物在结算月份内无法被计算";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 232);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "重量(公斤):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 170);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "价格(元/公斤):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "颜色:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(468, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称:";
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1508, 1002);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "InventoryForm";
            this.Text = "库存录入";
            this.Load += new System.EventHandler(this.InventoryForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Inventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView lv_Material;
        private System.Windows.Forms.ListView lv_Intermediate;
        private System.Windows.Forms.DataGridView dg_Inventory;
        private System.Windows.Forms.Button btn_Cannel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lab_Color;
        private System.Windows.Forms.Label lab_GoodsName;
        private System.Windows.Forms.TextBox txt_Weight;
        private System.Windows.Forms.TextBox txt_Price;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date;
    }
}