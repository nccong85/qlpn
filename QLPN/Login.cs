using Business.Repository;
using CommonLib;
using DAL;
using QLPN.App_Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPN
{
    public partial class Login : Form
    {
        private readonly UserRepository _userRepository;
        private readonly Entities _dbContext;

        public Login()
        {
            InitializeComponent();
            _dbContext = new Entities();
            _userRepository = new UserRepository(_dbContext);
        }

        private void InitScreen()
        {
            lblError.Text = String.Empty;
            txtUserName.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string key = Util.GetResource("key");

            string pass = EncDec.Encrypt(txtPassword.Text.Trim(), key);
            if (_userRepository.IsAuthenticate(txtUserName.Text.Trim(), pass))
            {
                QLPN form = new QLPN();
                form.UserLogin = _userRepository.GetUserByUsername(txtUserName.Text.Trim());
                this.Hide();
                form.Show();
                
            }else
            {
                lblError.Text = "Đăng nhập thất bại!!";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            InitScreen();
        }
    }
}
