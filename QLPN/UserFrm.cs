using Business.DTO;
using Business.Repository;
using CommonLib;
using DAL;
using QLPN.App_Code;
using QLPN.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLPN
{
    public partial class UserFrm : Form
    {
        private const string DELIMITER = ":";
        private readonly UserRepository userRepository;
        private readonly Entities dbContext;
        public user_mst LoginUser { get => user; set => user = value; }

        private user_mst user = null;

        /// <summary>
        /// Variable to store error message
        /// </summary>
        private string errorMessage;

        /// <summary>
        /// User Id
        /// </summary>
        private int userId = -1;

        public UserFrm()
        {
            InitializeComponent();
            dbContext = new Entities();
            userRepository = new UserRepository(dbContext);
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            user_mst user = new user_mst();

            user.username = txtUsername.Text.Trim();
            user.name = txtName.Text.Trim();
            user.password = EncDec.Encrypt(txtPassword.Text.Trim(), Util.PRIVATE_KEY);
            user.dept_cd = cmbDivision.SelectedValue == null ? CommonConst.BLANK : cmbDivision.SelectedValue.ToString();
            string deptName = cmbDivision.SelectedItem == null ? CommonConst.BLANK : ((CommonLib.Model.DTO.ListItemEx)cmbDivision.SelectedItem).Text;
            user.dept_name = String.IsNullOrEmpty(deptName) ? CommonConst.BLANK : deptName.Substring(deptName.IndexOf(DELIMITER) + 1, deptName.Length - deptName.IndexOf(DELIMITER) - 1);
            user.email = txtEmail.Text.Trim();
            user.tel = txtTel.Text.Trim();
            user.address = txtAddress.Text.Trim();

            if (rdoNam.Checked)
            {
                user.gender = CommonConst.GIOI_TINH_NAM;
            }
            else
            {
                user.gender = CommonConst.GIOI_TINH_NU;
            }

            if (rdoAdmin.Checked)
            {
                user.role = CommonConst.UserRole.ADMIN;
            }
            else
            {
                user.role = CommonConst.UserRole.NORMAL_USER;
            }

            if (rdoEnable.Checked)
            {
                user.status = CommonConst.UserStatus.ENABLE;
            }
            else
            {
                user.role = CommonConst.UserStatus.DISABLE;
            }

            user.created_id = this.user.id;
            user.created_at = System.DateTime.Now;

            try
            {
                if (IsValidate(user, true))
                {
                    this.userRepository.Add(user);
                    this.ResetRegistration();

                    MessageBox.Show(String.Format(Resources.CM_MSG_HANDLE_SUCCESS, Resources.USER_ACTION_ADD), 
                        CommonConst.MessageCommon.MESSAGE_CAPTION_INFOR, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        this.errorMessage,
                        Resources.CM_TITLE_WARNING,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(String.Concat(Resources.CM_MSG_HANDLE_FAILED, ex.Message), 
                    Resources.USER_ACTION_ADD), 
                    CommonConst.MessageCommon.MESSAGE_CAPTION_ERROR, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        private void ResetRegistration()
        {
            txtUsername.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cmbDivision.SelectedIndex = -1;
            txtAddress.Text = string.Empty;
            rdoNormalUser.Checked = true;
            rdoEnable.Checked = true;
            rdoNam.Checked = true;
        }

        private bool IsValidate(user_mst user, bool isAddNew)
        {
            this.errorMessage = string.Empty;

            if (String.IsNullOrEmpty(user.username))
            {
                this.AddErrorMessage(String.Format(Resources.CM_MSG_REQUIRED, Resources.ITEM_USER_USERNAME_UPPER));
            }

            if (String.IsNullOrEmpty(user.name))
            {
                this.AddErrorMessage(String.Format(Resources.CM_MSG_REQUIRED, Resources.ITEM_USER_NAME_UPPER));
            }

            if (isAddNew && String.IsNullOrEmpty(user.password))
            {
                this.AddErrorMessage(String.Format(Resources.CM_MSG_REQUIRED, Resources.ITEM_USER_NAME_UPPER));
            }


            if (isAddNew && userRepository.IsExist(user.username))
            {
                this.AddErrorMessage(String.Format(Resources.CM_MSG_DUPLICATE, Resources.ITEM_USER_USERNAME_UPPER));
            }

            return this.errorMessage != string.Empty ? false : true;
        }

        private void UserFrm_Load(object sender, EventArgs e)
        {
            InitScreen();
        }

        private void InitScreen()
        {
            ComboBoxUtil.SetDanhSachTraiGiam(dbContext, cmbDivision, this.user);
            ComboBoxUtil.SetDanhSachTraiGiam(dbContext, cmb2Division, this.user);

            rdoNam.Checked = true;
            rdoNormalUser.Checked = true;
            rdoEnable.Checked = true;

            rdo2Nam.Checked = true;
            rdo2NormalUser.Checked = true;
            rdo2Enable.Checked = true;

            if (!String.Equals(this.user.role, CommonConst.UserRole.ADMIN))
            {

                rdoAdmin.Enabled = false;
                rdoDisable.Enabled = false;

                rdo2Admin.Enabled = false;
                rdo2Enable.Enabled = false;
            }
        }

        private void userManagementTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (userManagementTab.SelectedIndex == 1)
                {
                    this.LoadDataGridView();
                    this.FormatDataGridView();
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        private void ShowErrorMessage(Exception ex)
        {
            MessageBox.Show(
                 ex.Message,
                 Resources.CM_TITLE_SYSTEM_ERR,
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
        }

        private void LoadDataGridView()
        {
            this.dgvMembers.DataSource = userRepository.GetList(this.user);
        }

        private void FormatDataGridView()
        {
            dgvMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dgvMembers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvMembers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMembers.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dgvMembers.DefaultCellStyle.BackColor = Color.Empty;
            dgvMembers.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            dgvMembers.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvMembers.GridColor = SystemColors.ControlDarkDark;
            dgvMembers.Columns["Username"].HeaderText = "Tên đăng nhập";
            dgvMembers.Columns["Name"].HeaderText = "Tên người dùng";
            dgvMembers.Columns["DepartmentCd"].HeaderText = "Mã đơn vị";
            dgvMembers.Columns["DepartmentName"].HeaderText = "Tên đơn vị";
            dgvMembers.Columns["Role"].HeaderText = "Phân quyền";
            dgvMembers.Columns["Status"].HeaderText = "Trạng thái";

            dgvMembers.Columns["Username"].Width = 150;
            dgvMembers.Columns["Name"].Width = 150;
            dgvMembers.Columns["DepartmentCd"].Width = 100;
            dgvMembers.Columns["DepartmentName"].Width = 150;
            dgvMembers.Columns["Role"].Width = 120;
            dgvMembers.Columns["Status"].Width = 120;

            dgvMembers.Columns["Id"].Visible = false;
        }

        private void dgvMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = dgvMembers.SelectedCells[0].RowIndex;
            try
            {
                userId = int.Parse(dgvMembers[0, currentRow].Value.ToString());
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        private void dgvMembers_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    userId = int.Parse(dgv.SelectedRows[0].Cells[0].Value.ToString());

                    user_mst user = this.userRepository.GetUserById(userId);

                    txt2Username.Text = user.username;
                    txt2Name.Text = user.name;

                    cmb2Division.SelectedValue = user.dept_cd;
                    txt2Address.Text = user.address;

                    if (String.Equals(user.gender, CommonConst.GIOI_TINH_NAM))
                    {
                        rdo2Nam.Checked = true;
                    }
                    else
                    {
                        rdo2Nu.Checked = true;
                    }

                    if (String.Equals(user.role, CommonConst.UserRole.ADMIN))
                    {
                        rdo2Admin.Checked = true;
                    }
                    else
                    {
                        rdo2NormalUser.Checked = true;
                    }

                    if (String.Equals(user.status, CommonConst.UserStatus.ENABLE))
                    {
                        rdo2Enable.Checked = true;
                    }
                    else
                    {
                        rdo2Disable.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if(this.userId == -1)
            {
                MessageBox.Show(Resources.CM_MSG_SELECT_ROW, 
                    CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                return;
            }
            try
            {
                user_mst user = this.userRepository.GetUserById(this.userId);
                string deptName = cmbDivision.SelectedItem == null ? CommonConst.BLANK : ((CommonLib.Model.DTO.ListItemEx)cmb2Division.SelectedItem).Text;


                user.username = txt2Username.Text.Trim();
                user.name = txt2Name.Text.Trim();
                if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    user.password = EncDec.Encrypt(txt2Password.Text.Trim(), Util.PRIVATE_KEY);
                }
                user.dept_cd = cmb2Division.SelectedValue == null ? CommonConst.BLANK : cmb2Division.SelectedValue.ToString();
                user.dept_name = String.IsNullOrEmpty(deptName) ? CommonConst.BLANK : deptName.Substring(deptName.IndexOf(DELIMITER) + 1, deptName.Length - deptName.IndexOf(DELIMITER) - 1);
                user.tel = txt2Tel.Text.Trim();
                user.email = txt2Email.Text.Trim();
                user.address = txt2Address.Text.Trim();
                user.status = (rdo2Enable.Checked ? CommonConst.UserStatus.ENABLE : CommonConst.UserStatus.DISABLE);
                user.updated_id = this.user.id;
                user.updated_at = System.DateTime.Now;

                if (IsValidate(user, false))
                {
                    this.userRepository.Update(user);
                    this.LoadDataGridView();
                    MessageBox.Show(String.Format(Resources.CM_MSG_HANDLE_SUCCESS, Resources.ITEM_ACTION_UPDATE),
                        Resources.CM_TITLE_INFOR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        this.errorMessage,
                        Resources.CM_TITLE_WARNING,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// To generate the error message
        /// </summary>
        /// <param name="error">error message</param>
        private void AddErrorMessage(string error)
        {
            if (this.errorMessage == string.Empty)
            {
                this.errorMessage = Resources.CM_MSG_VALIDATE_HEADER + "\n\n";
            }

            this.errorMessage += error + "\n";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ImplementSearch();
        }

        private void ImplementSearch()
        {
            UserSearchDto search = new UserSearchDto();
            search.username = txtSearchUserName.Text.Trim();
            search.name = txtSearchName.Text.Trim();
            search.dept_cd = cmbSearchDivisonId.SelectedValue == null ? String.Empty : cmbSearchDivisonId.SelectedValue.ToString();

            dgvMembers.DataSource = userRepository.SearchUser(search, this.user);
        }
    }
}
