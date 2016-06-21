namespace WMS
{
    partial class OperationForm
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
            this.dg_Operation = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Operation)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Operation
            // 
            this.dg_Operation.AllowUserToAddRows = false;
            this.dg_Operation.AllowUserToDeleteRows = false;
            this.dg_Operation.AllowUserToResizeRows = false;
            this.dg_Operation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_Operation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Operation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_Operation.Location = new System.Drawing.Point(0, 0);
            this.dg_Operation.MultiSelect = false;
            this.dg_Operation.Name = "dg_Operation";
            this.dg_Operation.ReadOnly = true;
            this.dg_Operation.RowHeadersVisible = false;
            this.dg_Operation.RowTemplate.Height = 23;
            this.dg_Operation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Operation.Size = new System.Drawing.Size(681, 381);
            this.dg_Operation.TabIndex = 0;
            // 
            // OperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 381);
            this.Controls.Add(this.dg_Operation);
            this.Name = "OperationForm";
            this.Text = "操作日志";
            this.Load += new System.EventHandler(this.OperationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Operation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_Operation;
    }
}