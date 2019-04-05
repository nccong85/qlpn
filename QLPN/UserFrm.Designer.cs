namespace QLPN
{
    partial class UserFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Header = new System.Windows.Forms.TextBox();
            this.userManagementTab = new System.Windows.Forms.TabControl();
            this.addNewTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbDivision = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rdoNu = new System.Windows.Forms.RadioButton();
            this.rdoNam = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rdoNormalUser = new System.Windows.Forms.RadioButton();
            this.rdoAdmin = new System.Windows.Forms.RadioButton();
            this.label20 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rdoDisable = new System.Windows.Forms.RadioButton();
            this.rdoEnable = new System.Windows.Forms.RadioButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.updateTab = new System.Windows.Forms.TabPage();
            this.searchTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSearchDivisonId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearchUserId = new System.Windows.Forms.TextBox();
            this.txtSearchUsername = new System.Windows.Forms.TextBox();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txt2Tel = new System.Windows.Forms.TextBox();
            this.txt2Email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt2Username = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt2Name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt2Password = new System.Windows.Forms.TextBox();
            this.cmb2Division = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txt2Address = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdo2Nu = new System.Windows.Forms.RadioButton();
            this.rdo2Nam = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdo2NormalUser = new System.Windows.Forms.RadioButton();
            this.rdo2Admin = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdo2Disable = new System.Windows.Forms.RadioButton();
            this.rdo2Enable = new System.Windows.Forms.RadioButton();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.userManagementTab.SuspendLayout();
            this.addNewTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.updateTab.SuspendLayout();
            this.searchTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.SystemColors.Control;
            this.Header.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Header.Enabled = false;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.DimGray;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(732, 28);
            this.Header.TabIndex = 30;
            this.Header.Text = "Quản lý thông tin người sử dụng";
            this.Header.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // userManagementTab
            // 
            this.userManagementTab.Controls.Add(this.addNewTab);
            this.userManagementTab.Controls.Add(this.updateTab);
            this.userManagementTab.Location = new System.Drawing.Point(0, 35);
            this.userManagementTab.Name = "userManagementTab";
            this.userManagementTab.SelectedIndex = 0;
            this.userManagementTab.Size = new System.Drawing.Size(730, 698);
            this.userManagementTab.TabIndex = 31;
            // 
            // addNewTab
            // 
            this.addNewTab.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addNewTab.Controls.Add(this.tableLayoutPanel2);
            this.addNewTab.Location = new System.Drawing.Point(4, 24);
            this.addNewTab.Name = "addNewTab";
            this.addNewTab.Padding = new System.Windows.Forms.Padding(3);
            this.addNewTab.Size = new System.Drawing.Size(722, 670);
            this.addNewTab.TabIndex = 0;
            this.addNewTab.Text = "Đăng ký mới";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.txtTel, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtEmail, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtUsername, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label13, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtName, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label15, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtPassword, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbDivision, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label16, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label18, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtAddress, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label19, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label20, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.panel7, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.panel8, 2, 7);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(705, 260);
            this.tableLayoutPanel2.TabIndex = 32;
            // 
            // txtTel
            // 
            this.txtTel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTel.Location = new System.Drawing.Point(458, 69);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(235, 21);
            this.txtTel.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(123, 69);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(209, 21);
            this.txtEmail.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 15);
            this.label11.TabIndex = 8;
            this.label11.Text = "Email";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tên đăng nhập";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtUsername.Location = new System.Drawing.Point(123, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(209, 21);
            this.txtUsername.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(338, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "Họ tên";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtName.Location = new System.Drawing.Point(458, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(235, 21);
            this.txtName.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 15);
            this.label14.TabIndex = 4;
            this.label14.Text = "Mật khẩu";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(338, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 15);
            this.label15.TabIndex = 5;
            this.label15.Text = "Đơn vị";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPassword.Location = new System.Drawing.Point(123, 37);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(209, 21);
            this.txtPassword.TabIndex = 3;
            // 
            // cmbDivision
            // 
            this.cmbDivision.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmbDivision.FormattingEnabled = true;
            this.cmbDivision.Location = new System.Drawing.Point(458, 38);
            this.cmbDivision.Name = "cmbDivision";
            this.cmbDivision.Size = new System.Drawing.Size(235, 23);
            this.cmbDivision.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(338, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 15);
            this.label16.TabIndex = 9;
            this.label16.Text = "Số điện thoại";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 15);
            this.label17.TabIndex = 10;
            this.label17.Text = "Giới tính";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 136);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 15);
            this.label18.TabIndex = 11;
            this.label18.Text = "Địa chỉ";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.SetColumnSpan(this.txtAddress, 3);
            this.txtAddress.Location = new System.Drawing.Point(123, 133);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(570, 21);
            this.txtAddress.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 168);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 15);
            this.label19.TabIndex = 13;
            this.label19.Text = "Phân quyền";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel5, 3);
            this.panel5.Controls.Add(this.rdoNu);
            this.panel5.Controls.Add(this.rdoNam);
            this.panel5.Location = new System.Drawing.Point(123, 99);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(570, 26);
            this.panel5.TabIndex = 17;
            // 
            // rdoNu
            // 
            this.rdoNu.AutoSize = true;
            this.rdoNu.Location = new System.Drawing.Point(61, 5);
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Size = new System.Drawing.Size(41, 19);
            this.rdoNu.TabIndex = 8;
            this.rdoNu.TabStop = true;
            this.rdoNu.Text = "Nữ";
            this.rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            this.rdoNam.AutoSize = true;
            this.rdoNam.Location = new System.Drawing.Point(3, 4);
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.Size = new System.Drawing.Size(52, 19);
            this.rdoNam.TabIndex = 7;
            this.rdoNam.TabStop = true;
            this.rdoNam.Text = "Nam";
            this.rdoNam.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel6, 3);
            this.panel6.Controls.Add(this.rdoNormalUser);
            this.panel6.Controls.Add(this.rdoAdmin);
            this.panel6.Location = new System.Drawing.Point(123, 163);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(570, 26);
            this.panel6.TabIndex = 18;
            // 
            // rdoNormalUser
            // 
            this.rdoNormalUser.AutoSize = true;
            this.rdoNormalUser.Location = new System.Drawing.Point(95, 3);
            this.rdoNormalUser.Name = "rdoNormalUser";
            this.rdoNormalUser.Size = new System.Drawing.Size(130, 19);
            this.rdoNormalUser.TabIndex = 1;
            this.rdoNormalUser.TabStop = true;
            this.rdoNormalUser.Text = "Người dùng thường";
            this.rdoNormalUser.UseVisualStyleBackColor = true;
            // 
            // rdoAdmin
            // 
            this.rdoAdmin.AutoSize = true;
            this.rdoAdmin.Location = new System.Drawing.Point(3, 3);
            this.rdoAdmin.Name = "rdoAdmin";
            this.rdoAdmin.Size = new System.Drawing.Size(68, 19);
            this.rdoAdmin.TabIndex = 10;
            this.rdoAdmin.TabStop = true;
            this.rdoAdmin.Text = "Quản trị";
            this.rdoAdmin.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 200);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 15);
            this.label20.TabIndex = 14;
            this.label20.Text = "Trạng thái";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel7, 3);
            this.panel7.Controls.Add(this.rdoDisable);
            this.panel7.Controls.Add(this.rdoEnable);
            this.panel7.Location = new System.Drawing.Point(123, 195);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(570, 26);
            this.panel7.TabIndex = 19;
            // 
            // rdoDisable
            // 
            this.rdoDisable.AutoSize = true;
            this.rdoDisable.Location = new System.Drawing.Point(95, 4);
            this.rdoDisable.Name = "rdoDisable";
            this.rdoDisable.Size = new System.Drawing.Size(107, 19);
            this.rdoDisable.TabIndex = 2;
            this.rdoDisable.TabStop = true;
            this.rdoDisable.Text = "Không hiệu lực";
            this.rdoDisable.UseVisualStyleBackColor = true;
            // 
            // rdoEnable
            // 
            this.rdoEnable.AutoSize = true;
            this.rdoEnable.Location = new System.Drawing.Point(3, 3);
            this.rdoEnable.Name = "rdoEnable";
            this.rdoEnable.Size = new System.Drawing.Size(86, 19);
            this.rdoEnable.TabIndex = 1;
            this.rdoEnable.TabStop = true;
            this.rdoEnable.Text = "Có hiệu lực";
            this.rdoEnable.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel8, 2);
            this.panel8.Controls.Add(this.btnRegistration);
            this.panel8.Location = new System.Drawing.Point(338, 227);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(355, 30);
            this.panel8.TabIndex = 20;
            // 
            // btnRegistration
            // 
            this.btnRegistration.BackColor = System.Drawing.SystemColors.Control;
            this.btnRegistration.FlatAppearance.BorderSize = 2;
            this.btnRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRegistration.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRegistration.Location = new System.Drawing.Point(252, 3);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(100, 26);
            this.btnRegistration.TabIndex = 1;
            this.btnRegistration.Text = "Đăng ký";
            this.btnRegistration.UseVisualStyleBackColor = false;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
            // 
            // updateTab
            // 
            this.updateTab.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.updateTab.Controls.Add(this.tableLayoutPanel1);
            this.updateTab.Controls.Add(this.dgvMembers);
            this.updateTab.Controls.Add(this.searchTab);
            this.updateTab.Location = new System.Drawing.Point(4, 24);
            this.updateTab.Name = "updateTab";
            this.updateTab.Padding = new System.Windows.Forms.Padding(3);
            this.updateTab.Size = new System.Drawing.Size(722, 670);
            this.updateTab.TabIndex = 1;
            this.updateTab.Text = "Tìm kiếm/Cập nhật";
            // 
            // searchTab
            // 
            this.searchTab.Controls.Add(this.tabPage1);
            this.searchTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTab.Location = new System.Drawing.Point(6, 6);
            this.searchTab.Name = "searchTab";
            this.searchTab.SelectedIndex = 0;
            this.searchTab.Size = new System.Drawing.Size(705, 100);
            this.searchTab.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmbSearchDivisonId);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtSearchUserId);
            this.tabPage1.Controls.Add(this.txtSearchUsername);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(697, 71);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tìm kiếm";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 2;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch.Location = new System.Drawing.Point(522, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 26);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(180, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên người dùng";
            // 
            // cmbSearchDivisonId
            // 
            this.cmbSearchDivisonId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSearchDivisonId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSearchDivisonId.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbSearchDivisonId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchDivisonId.FormattingEnabled = true;
            this.cmbSearchDivisonId.Location = new System.Drawing.Point(356, 33);
            this.cmbSearchDivisonId.Name = "cmbSearchDivisonId";
            this.cmbSearchDivisonId.Size = new System.Drawing.Size(145, 24);
            this.cmbSearchDivisonId.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(353, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Đơn vị";
            // 
            // txtSearchUserId
            // 
            this.txtSearchUserId.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSearchUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSearchUserId.Location = new System.Drawing.Point(24, 33);
            this.txtSearchUserId.Name = "txtSearchUserId";
            this.txtSearchUserId.Size = new System.Drawing.Size(134, 23);
            this.txtSearchUserId.TabIndex = 1;
            // 
            // txtSearchUsername
            // 
            this.txtSearchUsername.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSearchUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSearchUsername.Location = new System.Drawing.Point(183, 33);
            this.txtSearchUsername.Name = "txtSearchUsername";
            this.txtSearchUsername.Size = new System.Drawing.Size(146, 23);
            this.txtSearchUsername.TabIndex = 2;
            // 
            // dgvMembers
            // 
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToOrderColumns = true;
            this.dgvMembers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMembers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Location = new System.Drawing.Point(6, 112);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.Size = new System.Drawing.Size(705, 269);
            this.dgvMembers.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.txt2Tel, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt2Email, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt2Username, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt2Name, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt2Password, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmb2Division, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label21, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt2Address, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label22, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label23, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdate, 3, 7);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 398);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(705, 260);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // txt2Tel
            // 
            this.txt2Tel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt2Tel.Location = new System.Drawing.Point(458, 69);
            this.txt2Tel.Name = "txt2Tel";
            this.txt2Tel.Size = new System.Drawing.Size(235, 21);
            this.txt2Tel.TabIndex = 6;
            // 
            // txt2Email
            // 
            this.txt2Email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt2Email.Location = new System.Drawing.Point(123, 69);
            this.txt2Email.Name = "txt2Email";
            this.txt2Email.Size = new System.Drawing.Size(209, 21);
            this.txt2Email.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Email";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên đăng nhập";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt2Username
            // 
            this.txt2Username.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt2Username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txt2Username.Location = new System.Drawing.Point(123, 5);
            this.txt2Username.Name = "txt2Username";
            this.txt2Username.Size = new System.Drawing.Size(209, 21);
            this.txt2Username.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(338, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Họ tên";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt2Name
            // 
            this.txt2Name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txt2Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txt2Name.Location = new System.Drawing.Point(458, 5);
            this.txt2Name.Name = "txt2Name";
            this.txt2Name.Size = new System.Drawing.Size(235, 21);
            this.txt2Name.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Mật khẩu";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(338, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Đơn vị";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt2Password
            // 
            this.txt2Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt2Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txt2Password.Location = new System.Drawing.Point(123, 37);
            this.txt2Password.Name = "txt2Password";
            this.txt2Password.Size = new System.Drawing.Size(209, 21);
            this.txt2Password.TabIndex = 3;
            // 
            // cmb2Division
            // 
            this.cmb2Division.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmb2Division.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmb2Division.FormattingEnabled = true;
            this.cmb2Division.Location = new System.Drawing.Point(458, 36);
            this.cmb2Division.Name = "cmb2Division";
            this.cmb2Division.Size = new System.Drawing.Size(235, 23);
            this.cmb2Division.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(338, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Số điện thoại";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "Giới tính";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 136);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(45, 15);
            this.label21.TabIndex = 11;
            this.label21.Text = "Địa chỉ";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt2Address
            // 
            this.txt2Address.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txt2Address, 3);
            this.txt2Address.Location = new System.Drawing.Point(123, 133);
            this.txt2Address.Name = "txt2Address";
            this.txt2Address.Size = new System.Drawing.Size(570, 21);
            this.txt2Address.TabIndex = 9;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 168);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 15);
            this.label22.TabIndex = 13;
            this.label22.Text = "Phân quyền";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.rdo2Nu);
            this.panel1.Controls.Add(this.rdo2Nam);
            this.panel1.Location = new System.Drawing.Point(123, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 26);
            this.panel1.TabIndex = 17;
            // 
            // rdo2Nu
            // 
            this.rdo2Nu.AutoSize = true;
            this.rdo2Nu.Location = new System.Drawing.Point(61, 5);
            this.rdo2Nu.Name = "rdo2Nu";
            this.rdo2Nu.Size = new System.Drawing.Size(41, 19);
            this.rdo2Nu.TabIndex = 8;
            this.rdo2Nu.TabStop = true;
            this.rdo2Nu.Text = "Nữ";
            this.rdo2Nu.UseVisualStyleBackColor = true;
            // 
            // rdo2Nam
            // 
            this.rdo2Nam.AutoSize = true;
            this.rdo2Nam.Location = new System.Drawing.Point(3, 4);
            this.rdo2Nam.Name = "rdo2Nam";
            this.rdo2Nam.Size = new System.Drawing.Size(52, 19);
            this.rdo2Nam.TabIndex = 7;
            this.rdo2Nam.TabStop = true;
            this.rdo2Nam.Text = "Nam";
            this.rdo2Nam.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 3);
            this.panel2.Controls.Add(this.rdo2NormalUser);
            this.panel2.Controls.Add(this.rdo2Admin);
            this.panel2.Location = new System.Drawing.Point(123, 163);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(570, 26);
            this.panel2.TabIndex = 18;
            // 
            // rdo2NormalUser
            // 
            this.rdo2NormalUser.AutoSize = true;
            this.rdo2NormalUser.Location = new System.Drawing.Point(95, 3);
            this.rdo2NormalUser.Name = "rdo2NormalUser";
            this.rdo2NormalUser.Size = new System.Drawing.Size(130, 19);
            this.rdo2NormalUser.TabIndex = 1;
            this.rdo2NormalUser.TabStop = true;
            this.rdo2NormalUser.Text = "Người dùng thường";
            this.rdo2NormalUser.UseVisualStyleBackColor = true;
            // 
            // rdo2Admin
            // 
            this.rdo2Admin.AutoSize = true;
            this.rdo2Admin.Location = new System.Drawing.Point(3, 3);
            this.rdo2Admin.Name = "rdo2Admin";
            this.rdo2Admin.Size = new System.Drawing.Size(68, 19);
            this.rdo2Admin.TabIndex = 10;
            this.rdo2Admin.TabStop = true;
            this.rdo2Admin.Text = "Quản trị";
            this.rdo2Admin.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 200);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 15);
            this.label23.TabIndex = 14;
            this.label23.Text = "Trạng thái";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 3);
            this.panel3.Controls.Add(this.rdo2Disable);
            this.panel3.Controls.Add(this.rdo2Enable);
            this.panel3.Location = new System.Drawing.Point(123, 195);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(570, 26);
            this.panel3.TabIndex = 19;
            // 
            // rdo2Disable
            // 
            this.rdo2Disable.AutoSize = true;
            this.rdo2Disable.Location = new System.Drawing.Point(95, 4);
            this.rdo2Disable.Name = "rdo2Disable";
            this.rdo2Disable.Size = new System.Drawing.Size(107, 19);
            this.rdo2Disable.TabIndex = 2;
            this.rdo2Disable.TabStop = true;
            this.rdo2Disable.Text = "Không hiệu lực";
            this.rdo2Disable.UseVisualStyleBackColor = true;
            // 
            // rdo2Enable
            // 
            this.rdo2Enable.AutoSize = true;
            this.rdo2Enable.Location = new System.Drawing.Point(3, 3);
            this.rdo2Enable.Name = "rdo2Enable";
            this.rdo2Enable.Size = new System.Drawing.Size(86, 19);
            this.rdo2Enable.TabIndex = 1;
            this.rdo2Enable.TabStop = true;
            this.rdo2Enable.Text = "Có hiệu lực";
            this.rdo2Enable.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.FlatAppearance.BorderSize = 2;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdate.Location = new System.Drawing.Point(602, 227);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 26);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // UserFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(732, 736);
            this.Controls.Add(this.userManagementTab);
            this.Controls.Add(this.Header);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thông tin người sử dụng";
            this.Load += new System.EventHandler(this.UserFrm_Load);
            this.userManagementTab.ResumeLayout(false);
            this.addNewTab.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.updateTab.ResumeLayout(false);
            this.searchTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Header;
        private System.Windows.Forms.TabControl userManagementTab;
        private System.Windows.Forms.TabPage addNewTab;
        private System.Windows.Forms.TabPage updateTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbDivision;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton rdoNormalUser;
        private System.Windows.Forms.RadioButton rdoAdmin;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.RadioButton rdoDisable;
        private System.Windows.Forms.RadioButton rdoEnable;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.TabControl searchTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSearchDivisonId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearchUserId;
        private System.Windows.Forms.TextBox txtSearchUsername;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txt2Tel;
        private System.Windows.Forms.TextBox txt2Email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt2Username;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt2Name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt2Password;
        private System.Windows.Forms.ComboBox cmb2Division;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt2Address;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdo2Nu;
        private System.Windows.Forms.RadioButton rdo2Nam;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdo2NormalUser;
        private System.Windows.Forms.RadioButton rdo2Admin;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdo2Disable;
        private System.Windows.Forms.RadioButton rdo2Enable;
        private System.Windows.Forms.Button btnUpdate;
    }
}