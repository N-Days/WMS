namespace WMS
{
    partial class StatisticForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lab_start = new System.Windows.Forms.Label();
            this.lab_out = new System.Windows.Forms.Label();
            this.lab_in = new System.Windows.Forms.Label();
            this.lab_end = new System.Windows.Forms.Label();
            this.date_settleMonth = new System.Windows.Forms.DateTimePicker();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lab_minus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "月初库存:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "出库总价:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "入库总价:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "月末库存:";
            // 
            // lab_start
            // 
            this.lab_start.AutoSize = true;
            this.lab_start.Location = new System.Drawing.Point(93, 99);
            this.lab_start.Name = "lab_start";
            this.lab_start.Size = new System.Drawing.Size(23, 12);
            this.lab_start.TabIndex = 1;
            this.lab_start.Text = "0元";
            // 
            // lab_out
            // 
            this.lab_out.AutoSize = true;
            this.lab_out.Location = new System.Drawing.Point(93, 134);
            this.lab_out.Name = "lab_out";
            this.lab_out.Size = new System.Drawing.Size(23, 12);
            this.lab_out.TabIndex = 1;
            this.lab_out.Text = "0元";
            // 
            // lab_in
            // 
            this.lab_in.AutoSize = true;
            this.lab_in.Location = new System.Drawing.Point(93, 169);
            this.lab_in.Name = "lab_in";
            this.lab_in.Size = new System.Drawing.Size(23, 12);
            this.lab_in.TabIndex = 1;
            this.lab_in.Text = "0元";
            // 
            // lab_end
            // 
            this.lab_end.AutoSize = true;
            this.lab_end.Location = new System.Drawing.Point(94, 204);
            this.lab_end.Name = "lab_end";
            this.lab_end.Size = new System.Drawing.Size(23, 12);
            this.lab_end.TabIndex = 1;
            this.lab_end.Text = "0元";
            // 
            // date_settleMonth
            // 
            this.date_settleMonth.CustomFormat = "yyyy-MM";
            this.date_settleMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_settleMonth.Location = new System.Drawing.Point(13, 13);
            this.date_settleMonth.Name = "date_settleMonth";
            this.date_settleMonth.Size = new System.Drawing.Size(200, 21);
            this.date_settleMonth.TabIndex = 2;
            this.date_settleMonth.ValueChanged += new System.EventHandler(this.date_settleMonth_ValueChanged);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(12, 301);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(200, 23);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "库存差值:";
            // 
            // lab_minus
            // 
            this.lab_minus.AutoSize = true;
            this.lab_minus.Location = new System.Drawing.Point(93, 239);
            this.lab_minus.Name = "lab_minus";
            this.lab_minus.Size = new System.Drawing.Size(23, 12);
            this.lab_minus.TabIndex = 1;
            this.lab_minus.Text = "0元";
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 370);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.date_settleMonth);
            this.Controls.Add(this.lab_minus);
            this.Controls.Add(this.lab_end);
            this.Controls.Add(this.lab_in);
            this.Controls.Add(this.lab_out);
            this.Controls.Add(this.lab_start);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatisticForm";
            this.Text = "月份统计";
            this.Load += new System.EventHandler(this.StatisticForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lab_start;
        private System.Windows.Forms.Label lab_out;
        private System.Windows.Forms.Label lab_in;
        private System.Windows.Forms.Label lab_end;
        private System.Windows.Forms.DateTimePicker date_settleMonth;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lab_minus;
    }
}