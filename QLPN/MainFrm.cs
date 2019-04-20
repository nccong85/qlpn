using Business.Repository;
using CommonLib;
using CommonLib.Model.DTO;
using CsvHelper;
using CsvHelper.Configuration;
using DAL;
using QLPN.App_Code;
using QLPN.DTO;
using QLPN.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QLPN
{
    public partial class MainFrm : Form
    {
        private readonly PrisonRepository _prisonRepository;
        private readonly Entities _dbContext;

        public user_mst UserLogin { get => _user; set => _user = value; }
        private user_mst _user;

        public MainFrm()
        {
            InitializeComponent();
            _dbContext = new Entities();
            _prisonRepository = new PrisonRepository(_dbContext);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                ImplementSearch();

                return true;
            }
            else if (keyData == Keys.F12)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void QLPN_Load(object sender, EventArgs e)
        {
            InitScreen();
            dgvPrisonerList.DataSource = _prisonRepository.GetListPrisonToDisplay(this._user);
            this.AdjustColumnIndex();
            this.AdjustColumnName();
        }

        private void InitScreen()
        {
            txtSearchPrisonId.Text = String.Empty;
            txtSearchPrisonName.Text = String.Empty;
            ComboBoxUtil.SetDanhSachTraiGiam(_dbContext, cmbSearchDivisonId, this._user);

            cmbSearchDivisonId.SelectedItem = null;
            cmbSearchDivisonId.SelectedText = CommonConst.BLANK;

            dgvPrisonerList.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dgvPrisonerList.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dgvPrisonerList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvPrisonerList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPrisonerList.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dgvPrisonerList.DefaultCellStyle.BackColor = Color.Empty;
            dgvPrisonerList.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Info;
            dgvPrisonerList.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvPrisonerList.GridColor = SystemColors.ControlDarkDark;
        }
        private void AdjustColumnIndex()
        {
            dgvPrisonerList.Columns["ma_dang_ky"].DisplayIndex = 0;
            dgvPrisonerList.Columns["ho_va_ten"].DisplayIndex = 1;
            dgvPrisonerList.Columns["ten_goi_khac"].DisplayIndex = 2;
            dgvPrisonerList.Columns["ma_trai_giam"].DisplayIndex = 3;
            dgvPrisonerList.Columns["ngay_thang_nam_sinh"].DisplayIndex = 4;
            dgvPrisonerList.Columns["gioi_tinh"].DisplayIndex = 5;
            dgvPrisonerList.Columns["que_quan"].DisplayIndex = 6;
            dgvPrisonerList.Columns["noi_dktt"].DisplayIndex = 7;
            dgvPrisonerList.Columns["toi_danh"].DisplayIndex = 8;
            dgvPrisonerList.Columns["ngay_bat"].DisplayIndex = 9;
            dgvPrisonerList.Columns["an_phat"].DisplayIndex = 10;
            dgvPrisonerList.Columns["ngay_nhap_trai"].DisplayIndex = 11;
            dgvPrisonerList.Columns["ngay_dua_ra"].DisplayIndex = 12;
            dgvPrisonerList.Columns["ly_do_dua_ra"].DisplayIndex = 13;

            dgvPrisonerList.Columns["ma_dang_ky"].Width = 120;
            dgvPrisonerList.Columns["ho_va_ten"].Width = 150;
            dgvPrisonerList.Columns["ten_goi_khac"].Width = 150;
            dgvPrisonerList.Columns["ma_trai_giam"].Width = 120;
            dgvPrisonerList.Columns["ngay_thang_nam_sinh"].Width = 100;
            dgvPrisonerList.Columns["gioi_tinh"].Width = 100;
            dgvPrisonerList.Columns["que_quan"].Width = 250;
            dgvPrisonerList.Columns["noi_dktt"].Width = 250;
            dgvPrisonerList.Columns["toi_danh"].Width = 250;
            dgvPrisonerList.Columns["ngay_bat"].Width = 100;
            dgvPrisonerList.Columns["an_phat"].Width = 150;
            dgvPrisonerList.Columns["ngay_nhap_trai"].Width = 120;
            dgvPrisonerList.Columns["ngay_dua_ra"].Width = 120;
            dgvPrisonerList.Columns["ly_do_dua_ra"].Width = 150;

            dgvPrisonerList.Columns["id"].Visible = false;
        }

        private void AdjustColumnName()
        {
            dgvPrisonerList.Columns["ma_dang_ky"].HeaderText = "Mã đăng ký";
            dgvPrisonerList.Columns["ma_trai_giam"].HeaderText = "Trại giam";
            dgvPrisonerList.Columns["ngay_thang_nam_sinh"].HeaderText = "Ngày sinh";
            dgvPrisonerList.Columns["ho_va_ten"].HeaderText = "Họ tên";
            dgvPrisonerList.Columns["ten_goi_khac"].HeaderText = "Tên gọi khác";
            dgvPrisonerList.Columns["gioi_tinh"].HeaderText = "Giới tính";
            dgvPrisonerList.Columns["que_quan"].HeaderText = "Quê quán";
            dgvPrisonerList.Columns["noi_dktt"].HeaderText = "Nơi ĐKTT";
            dgvPrisonerList.Columns["toi_danh"].HeaderText = "Tội danh";
            dgvPrisonerList.Columns["ngay_bat"].HeaderText = "Ngày bắt";
            dgvPrisonerList.Columns["an_phat"].HeaderText = "Án phạt";
            dgvPrisonerList.Columns["ngay_nhap_trai"].HeaderText = "Ngày nhập trại";
            dgvPrisonerList.Columns["ngay_dua_ra"].HeaderText = "Ngày đưa ra";
            dgvPrisonerList.Columns["ly_do_dua_ra"].HeaderText = "Lý do đưa ra";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string path = String.Empty;
            try
            {
                if (saveFileDialogExportCsvFilePath.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialogExportCsvFilePath.FileName.ToString();
                    string tempFile = Path.GetTempFileName();
                    List<prison_mst> prisonList = this.GetDataForExport();
                    using (System.IO.TextWriter writer = new System.IO.StreamWriter(tempFile, false, System.Text.Encoding.UTF8))
                    {
                        var csvWriter = new CsvWriter(writer);
                        foreach (var prison in prisonList)
                        {
                            csvWriter.WriteRecord<prison_mst>(prison);
                            csvWriter.NextRecord();
                        }
                        csvWriter.Flush();
                    }
                    EncDec.Encrypt(tempFile, path, Util.PRIVATE_KEY);
                    File.Delete(tempFile);
                    MessageBox.Show(String.Format(Resources.CM_MSG_HANDLE_SUCCESS, Resources.ITEM_ACTION_EXPORT), CommonConst.MessageCommon.MESSAGE_CAPTION_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(String.Concat(Resources.CM_MSG_HANDLE_FAILED, ex.Message), Resources.ITEM_ACTION_EXPORT), CommonConst.MessageCommon.MESSAGE_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private List<prison_mst> GetDataForExport()
        {
            return _prisonRepository.GetListForExport(this._user);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PrisonFrm form = new PrisonFrm();
            form.LoginUser = this._user;
            form.IsUpdateMode = false;

            form.FormClosed += childForm_Closed;
            form.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgvPrisonerList.CurrentRow == null)
            {
                MessageBox.Show(Resources.CM_MSG_SELECT_ROW, CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dgvPrisonerList.SelectedRows.Count > 1)
            {
                MessageBox.Show(Resources.MAIN_MSG_002, CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                OpenEditForm(this.dgvPrisonerList.CurrentRow.Cells[1].Value.ToString());
            }
        }

        private void OpenEditForm(string maPn)
        {
            PrisonFrm form = new PrisonFrm();
            form.LoginUser = this._user;
            form.IsUpdateMode = true;
            form.MaPhamNhan = maPn;

            form.FormClosed += childForm_Closed;
            form.ShowDialog();
        }

        private void childForm_Closed(object sender, EventArgs e)
        {
            dgvPrisonerList.DataSource = _prisonRepository.GetListPrisonToDisplay(this._user); ;
        }

        private void dgvPrisonerList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.OpenEditForm(this.dgvPrisonerList.CurrentRow.Cells[1].Value.ToString());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPrisonerList.SelectedRows.Count == 0)
            {
                MessageBox.Show(Resources.MAIN_MSG_003, CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                List<String> idList = new List<string>();
                foreach (DataGridViewRow row in dgvPrisonerList.SelectedRows)
                {
                    idList.Add(row.Cells[1].Value.ToString());
                }
                DialogResult dr = MessageBox.Show(Resources.MAIN_MSG_004, Resources.CM_TITLE_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        foreach (String id in idList)
                        {
                            _prisonRepository.Delete(id);
                        }
                        dgvPrisonerList.DataSource = _prisonRepository.GetListPrisonToDisplay(this._user);
                        MessageBox.Show(String.Format(Resources.CM_MSG_HANDLE_SUCCESS, Resources.ITEM_ACTION_DELETE), CommonConst.MessageCommon.MESSAGE_CAPTION_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format(String.Concat(Resources.CM_MSG_HANDLE_FAILED, ex.Message), Resources.ITEM_ACTION_DELETE), CommonConst.MessageCommon.MESSAGE_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string filePath = String.Empty;
            string tempFile = String.Empty;
            openFileDialogImportCsvFilePath.Filter = "Binary Files|*.pns";
            openFileDialogImportCsvFilePath.CheckFileExists = true;
            openFileDialogImportCsvFilePath.CheckPathExists = true;

            try
            {
                if (openFileDialogImportCsvFilePath.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialogImportCsvFilePath.FileName;

                    tempFile = Path.GetTempFileName();

                    EncDec.Decrypt(filePath, tempFile, Util.PRIVATE_KEY);

                    Configuration configuration = new Configuration { HasHeaderRecord = false };
                    using (var sr = new StreamReader(tempFile, System.Text.Encoding.UTF8))
                    {
                        var reader = new CsvReader(sr, configuration);

                        //CSVReader will now read the whole file into an enumerable
                        IEnumerable<prison_mst> records = reader.GetRecords<prison_mst>();

                        //First 5 records in CSV file will be printed to the Output Window
                        foreach (prison_mst record in records)
                        {
                            ImportCsv(record);
                        }
                    }
                    File.Delete(tempFile);
                    MessageBox.Show(String.Format(Resources.CM_MSG_HANDLE_SUCCESS, Resources.ITEM_ACTION_IMPORT), CommonConst.MessageCommon.MESSAGE_CAPTION_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPrisonerList.DataSource = _prisonRepository.GetListPrisonToDisplay(this._user);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(String.Concat(Resources.CM_MSG_HANDLE_FAILED, ex.Message), Resources.ITEM_ACTION_IMPORT), CommonConst.MessageCommon.MESSAGE_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportCsv(prison_mst record)
        {
            if (_prisonRepository.IsExist(record.ma_dang_ky))
            {
                prison_mst prison = _prisonRepository.GetPrisonById(record.ma_dang_ky);
                _prisonRepository.Update(Util.UpdatePrison(record, prison));
            }
            else
            {
                _prisonRepository.Add(Util.CreateNewPrison(record));
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ImplementSearch();
        }

        private void ImplementSearch()
        {
            SearchDto search = new SearchDto();
            search.MaDangKy = txtSearchPrisonId.Text.Trim();
            search.TenPhamNhan = txtSearchPrisonName.Text.Trim();
            search.MaTraiGiam = cmbSearchDivisonId.SelectedValue == null ? String.Empty : cmbSearchDivisonId.SelectedValue.ToString();

            dgvPrisonerList.DataSource = _prisonRepository.SearchPrison(search, this._user);
        }

        private void btnReLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            UserFrm user = new UserFrm();
            user.LoginUser = this._user;
            user.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
