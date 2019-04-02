using Business.Repository;
using CommonLib;
using DAL;
using QLPN.App_Code;
using System;
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                ImplementLogin();
                return true;
            }
            else if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void InitScreen()
        {
            lblError.Text = String.Empty;
            txtUserName.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ImplementLogin();
        }

        private void ImplementLogin()
        {
            string pass = EncDec.Encrypt(txtPassword.Text.Trim(), Util.PRIVATE_KEY);
            if (_userRepository.IsAuthenticate(txtUserName.Text.Trim(), pass))
            {
                QLPN form = new QLPN();
                form.UserLogin = _userRepository.GetUserByUsername(txtUserName.Text.Trim());
                this.Hide();
                form.Show();
            }
            else
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
