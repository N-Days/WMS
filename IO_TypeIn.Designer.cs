namespace WMS
{
    partial class IO_TypeIn
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
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Last = new System.Windows.Forms.Button();
            this.Btn_Next = new System.Windows.Forms.Button();
            this.cBox_Status = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Quality = new System.Windows.Forms.TextBox();
            this.txt_Price = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(20, 31);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(48, 21);
            this.txt_ID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "名称:";
            // 
            // Btn_Last
            // 
            this.Btn_Last.Location = new System.Drawing.Point(383, 6);
            this.Btn_Last.Name = "Btn_Last";
            this.Btn_Last.Size = new System.Drawing.Size(75, 23);
            this.Btn_Last.TabIndex = 2;
            this.Btn_Last.Text = "上一个";
            this.Btn_Last.UseVisualStyleBackColor = true;
            // 
            // Btn_Next
            // 
            this.Btn_Next.Location = new System.Drawing.Point(383, 35);
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.Size = new System.Drawing.Size(75, 23);
            this.Btn_Next.TabIndex = 2;
            this.Btn_Next.Text = "下一个";
            this.Btn_Next.UseVisualStyleBackColor = true;
            // 
            // cBox_Status
            // 
            this.cBox_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_Status.FormattingEnabled = true;
            this.cBox_Status.Items.AddRange(new object[] {
            "出库",
            "入库"});
            this.cBox_Status.Location = new System.Drawing.Point(98, 31);
            this.cBox_Status.Name = "cBox_Status";
            this.cBox_Status.Size = new System.Drawing.Size(56, 20);
            this.cBox_Status.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "状态:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "重量(公斤):";
            // 
            // txt_Quality
            // 
            this.txt_Quality.Location = new System.Drawing.Point(176, 31);
            this.txt_Quality.Name = "txt_Quality";
            this.txt_Quality.Size = new System.Drawing.Size(69, 21);
            this.txt_Quality.TabIndex = 0;
            // 
            // txt_Price
            // 
            this.txt_Price.Location = new System.Drawing.Point(276, 31);
            this.txt_Price.Name = "txt_Price";
            this.txt_Price.Size = new System.Drawing.Size(81, 21);
            this.txt_Price.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "价格(每公斤):";
            // 
            // IO_TypeIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 64);
            this.Controls.Add(this.cBox_Status);
            this.Controls.Add(this.Btn_Next);
            this.Controls.Add(this.Btn_Last);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Price);
            this.Controls.Add(this.txt_Quality);
            this.Controls.Add(this.txt_ID);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IO_TypeIn";
            this.Text = "数据录入";
            this.Load += new System.EventHandler(this.fTypeIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Last;
        private System.Windows.Forms.Button Btn_Next;
        private System.Windows.Forms.ComboBox cBox_Status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Quality;
        private System.Windows.Forms.TextBox txt_Price;
        private System.Windows.Forms.Label label4;
    }
}