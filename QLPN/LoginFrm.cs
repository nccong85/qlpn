﻿using Business.Repository;
using CommonLib;
using DAL;
using QLPN.App_Code;
using QLPN.Properties;
using System;
using System.Windows.Forms;

namespace QLPN
{
    public partial class LoginFrm : Form
    {
        private readonly UserRepository _userRepository;
        private readonly Entities _dbContext;

        public LoginFrm()
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
                MainFrm form = new MainFrm();
                form.UserLogin = _userRepository.GetUserByUsername(txtUserName.Text.Trim());
                this.Hide();
                form.ShowDialog();
            }
            else
            {
                lblError.Text = Resources.LOGIN_MSG_001;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            InitScreen();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
