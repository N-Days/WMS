namespace WMS
{
    partial class DataImport
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
            this.cbx_goodsType = new System.Windows.Forms.ComboBox();
            this.date_settlemonth = new System.Windows.Forms.DateTimePicker();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_flash = new System.Windows.Forms.Button();
            this.txt_position = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_datetype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_select = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dg_date = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.cbx_IOtype = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_date)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.cbx_IOtype);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.cbx_goodsType);
            this.splitContainer1.Panel1.Controls.Add(this.date_settlemonth);
            this.splitContainer1.Panel1.Controls.Add(this.btn_import);
            this.splitContainer1.Panel1.Controls.Add(this.btn_flash);
            this.splitContainer1.Panel1.Controls.Add(this.txt_position);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.cbx_datetype);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btn_select);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dg_date);
            this.splitContainer1.Size = new System.Drawing.Size(1374, 948);
            this.splitContainer1.SplitterDistance = 326;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // cbx_goodsType
            // 
            this.cbx_goodsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_goodsType.FormattingEnabled = true;
            this.cbx_goodsType.Items.AddRange(new object[] {
            "原材料",
            "半成品"});
            this.cbx_goodsType.Location = new System.Drawing.Point(140, 484);
            this.cbx_goodsType.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbx_goodsType.Name = "cbx_goodsType";
            this.cbx_goodsType.Size = new System.Drawing.Size(156, 32);
            this.cbx_goodsType.TabIndex = 10;
            // 
            // date_settlemonth
            // 
            this.date_settlemonth.CustomFormat = "yyyy-MM";
            this.date_settlemonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_settlemonth.Location = new System.Drawing.Point(140, 414);
            this.date_settlemonth.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.date_settlemonth.Name = "date_settlemonth";
            this.date_settlemonth.Size = new System.Drawing.Size(156, 35);
            this.date_settlemonth.TabIndex = 9;
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(26, 788);
            this.btn_import.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(270, 46);
            this.btn_import.TabIndex = 8;
            this.btn_import.Text = "导入";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_flash
            // 
            this.btn_flash.Location = new System.Drawing.Point(26, 636);
            this.btn_flash.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_flash.Name = "btn_flash";
            this.btn_flash.Size = new System.Drawing.Size(270, 46);
            this.btn_flash.TabIndex = 7;
            this.btn_flash.Text = "刷新";
            this.btn_flash.UseVisualStyleBackColor = true;
            this.btn_flash.Click += new System.EventHandler(this.btn_flash_Click);
            // 
            // txt_position
            // 
            this.txt_position.Location = new System.Drawing.Point(140, 350);
            this.txt_position.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txt_position.Name = "txt_position";
            this.txt_position.Size = new System.Drawing.Size(156, 35);
            this.txt_position.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 490);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "货物类型:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 426);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "结算月份:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 356);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "导入范围:";
            // 
            // cbx_datetype
            // 
            this.cbx_datetype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_datetype.FormattingEnabled = true;
            this.cbx_datetype.Items.AddRange(new object[] {
            "编号",
            "库存",
            "入出库"});
            this.cbx_datetype.Location = new System.Drawing.Point(140, 280);
            this.cbx_datetype.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbx_datetype.Name = "cbx_datetype";
            this.cbx_datetype.Size = new System.Drawing.Size(156, 32);
            this.cbx_datetype.TabIndex = 4;
            this.cbx_datetype.SelectedIndexChanged += new System.EventHandler(this.cbx_datetype_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 286);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "数据类型:";
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(140, 206);
            this.btn_select.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(156, 46);
            this.btn_select.TabIndex = 1;
            this.btn_select.Text = "选择文件";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 216);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件路径:";
            // 
            // dg_date
            // 
            this.dg_date.AllowUserToAddRows = false;
            this.dg_date.AllowUserToDeleteRows = false;
            this.dg_date.AllowUserToResizeRows = false;
            this.dg_date.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_date.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_date.Location = new System.Drawing.Point(0, 0);
            this.dg_date.Margin = new System.Windows.Forms.Padding(0);
            this.dg_date.MultiSelect = false;
            this.dg_date.Name = "dg_date";
            this.dg_date.ReadOnly = true;
            this.dg_date.RowHeadersVisible = false;
            this.dg_date.RowTemplate.Height = 23;
            this.dg_date.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_date.Size = new System.Drawing.Size(1040, 948);
            this.dg_date.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 551);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "入出库：";
            // 
            // cbx_IOtype
            // 
            this.cbx_IOtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_IOtype.FormattingEnabled = true;
            this.cbx_IOtype.Items.AddRange(new object[] {
            "入库",
            "出库"});
            this.cbx_IOtype.Location = new System.Drawing.Point(140, 548);
            this.cbx_IOtype.Name = "cbx_IOtype";
            this.cbx_IOtype.Size = new System.Drawing.Size(156, 32);
            this.cbx_IOtype.TabIndex = 12;
            // 
            // DataImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 948);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "DataImport";
            this.Text = "数据导入";
            this.Load += new System.EventHandler(this.DataImport_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_date)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbx_datetype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dg_date;
        private System.Windows.Forms.TextBox txt_position;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_flash;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.DateTimePicker date_settlemonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_goodsType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_IOtype;
        private System.Windows.Forms.Label label6;
    }
}