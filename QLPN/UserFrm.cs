using Business.Repository;
using DAL;
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
    public partial class UserFrm : Form
    {
        private readonly UserRepository _userRepository;
        private readonly Entities _dbContext;

        public UserFrm()
        {
            InitializeComponent();
            _dbContext = new Entities();
            _userRepository = new UserRepository(_dbContext);
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {

        }

        private void UserFrm_Load(object sender, EventArgs e)
        {
            InitScreen();
        }

        private void InitScreen()
        {
            this.dgvMembers.DataSource = _userRepository.GetList();

            dgvMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dgvMembers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvMembers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMembers.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dgvMembers.DefaultCellStyle.BackColor = Color.Empty;
            dgvMembers.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            dgvMembers.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvMembers.GridColor = SystemColors.ControlDarkDark;
        }
    }
}
