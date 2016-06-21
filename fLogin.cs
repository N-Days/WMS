using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMS.Helper;
using WMS.Controllers;
using WMS.Model;

namespace WMS
{
    public partial class fLogin : Form
    {
        private SqliteHelper _sqlite_helper
        {
            get;
            set;
        }
        private UserController _user_controller
        {
            get; set;
        }
        public Model.User CurrentUser = null;

        public fLogin()
        {
            InitializeComponent();
        }


        private void _initData()
        {
            _sqlite_helper = new SqliteHelper();
            _user_controller = new UserController();
        }

        private bool CheckContent()
        {
            if (string.IsNullOrEmpty(this.txt_accountNumber.Text))
            {
                this.txt_accountNumber.Focus();
                return false ;
            }
            if (string.IsNullOrEmpty(this.txt_Password.Text))
            {
                this.txt_Password.Focus();
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
            var user = new User();
            if (_user_controller.UserLogin(txt_accountNumber.Text,txt_Password.Text,out user))
            {
                this.CurrentUser = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            SetFormPosition();
            _initData();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
