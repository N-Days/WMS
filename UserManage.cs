using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS
{
    public partial class UserManage : Form
    {
        public UserManage(Model.User CurrentUser)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
            this.lab_AdminName.Text = CurrentUser.UserName;
        }

        private Model.User CurrentUser = null;

        private bool CheckContent()
        {
            if (string.IsNullOrEmpty(this.txt_AccountNumber.Text))
            {
                this.txt_AccountNumber.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txt_Password.Text))
            {
                this.txt_Password.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txt_UserName.Text))
            {
                this.txt_UserName.Focus();
                return false;
            }
            return true;
        }

        private void SetFormPosition()
        {
            Rectangle rec = SystemInformation.VirtualScreen;
            Point point = new Point();
            point.X = (rec.Width - this.Width) / 2;
            point.Y = (rec.Height - this.Height) / 2;
            this.Location = point;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (!CheckContent()) return;
            Controllers.UserController uc = new Controllers.UserController();
            Model.User user = new Model.User();
            user.AccountNumber = this.txt_AccountNumber.Text.Trim();
            user.Password = this.txt_Password.Text;
            user.UserName = this.txt_UserName.Text.Trim();
            user.UserType = this.comboBox1.SelectedText.Equals("用户") ? 2 : 1;
            user.EnrollDate = DateTime.Now;
            user.CreateId = CurrentUser.Id;
            user.Enable = this.checkBox1.Checked;
            if (uc.Insert(CurrentUser, user))
            {
                if (MessageBox.Show("新增用户成功,是否关闭此窗口?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("新增用户失败");
            }
        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            SetFormPosition();
        }
    }
}
