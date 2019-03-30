﻿using Business.Repository;
using CommonLib;
using CommonLib.Model.DTO;
using CsvHelper;
using CsvHelper.Configuration;
using DAL;
using QLPN.App_Code;
using QLPN.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QLPN
{
    public partial class QLPN : Form
    {
        private readonly PrisonRepository _prisonRepository;
        private readonly Entities _dbContext;

        public QLPN()
        {
            InitializeComponent();
            _dbContext = new Entities();
            _prisonRepository = new PrisonRepository(_dbContext);
        }

        private void QLPN_Load(object sender, EventArgs e)
        {
            InitScreen();
            dgvPrisonerList.DataSource = _prisonRepository.GetList();
            this.AdjustColumnIndex();
            this.AdjustColumnName();
        }

        private void InitScreen()
        {
            txtSearchPrisonId.Text = String.Empty;
            txtSearchPrisonName.Text = String.Empty;
            ComboBoxUtil.SetDanhSachTraiGiam(_dbContext, cmbSearchDivisonId);

            cmbSearchDivisonId.SelectedItem = null;
            cmbSearchDivisonId.SelectedText = CommonConst.BLANK;
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
            dgvPrisonerList.Columns["phan_loai_quan_che"].DisplayIndex = 12;
            dgvPrisonerList.Columns["ngay_dua_vao_dien_quan_che"].DisplayIndex = 13;
            dgvPrisonerList.Columns["doi_hien_tai"].DisplayIndex = 14;
            dgvPrisonerList.Columns["buong_so"].DisplayIndex = 15;
            dgvPrisonerList.Columns["phan_trai"].DisplayIndex = 17;
            dgvPrisonerList.Columns["danh_muc"].DisplayIndex = 18;
            dgvPrisonerList.Columns["danh_muc_1"].DisplayIndex = 19;
            dgvPrisonerList.Columns["pham_vi_hoat_dong"].DisplayIndex = 20;
            dgvPrisonerList.Columns["bieu_hien_hoat_dong_hien_hanh"].DisplayIndex = 21;
            dgvPrisonerList.Columns["bien_phap_nghiep_vu"].DisplayIndex = 22;
            dgvPrisonerList.Columns["bien_phap_ky_luat"].DisplayIndex = 23;
            dgvPrisonerList.Columns["ngay_dua_ra"].DisplayIndex = 24;
            dgvPrisonerList.Columns["ly_do_dua_ra"].DisplayIndex = 25;
            dgvPrisonerList.Columns["ngay_tao"].DisplayIndex = 26;
            dgvPrisonerList.Columns["nguoi_tao"].DisplayIndex = 27;
            dgvPrisonerList.Columns["ngay_cap_nhat"].DisplayIndex = 28;
            dgvPrisonerList.Columns["nguoi_cap_nhat"].DisplayIndex = 29;

            dgvPrisonerList.Columns["ma_dang_ky"].Width = 120;
            dgvPrisonerList.Columns["ho_va_ten"].Width = 150;
            dgvPrisonerList.Columns["ten_goi_khac"].Width = 150;
            dgvPrisonerList.Columns["ma_trai_giam"].Width = 120;
            dgvPrisonerList.Columns["ngay_thang_nam_sinh"].Width = 100;
            dgvPrisonerList.Columns["gioi_tinh"].Width = 80;
            dgvPrisonerList.Columns["que_quan"].Width = 250;
            dgvPrisonerList.Columns["noi_dktt"].Width = 250;
            dgvPrisonerList.Columns["toi_danh"].Width = 100;
            dgvPrisonerList.Columns["ngay_bat"].Width = 100;
            dgvPrisonerList.Columns["an_phat"].Width = 150;
            dgvPrisonerList.Columns["ngay_nhap_trai"].Width = 100;
            dgvPrisonerList.Columns["phan_loai_quan_che"].Width = 100;
            dgvPrisonerList.Columns["ngay_dua_vao_dien_quan_che"].Width = 100;
            dgvPrisonerList.Columns["doi_hien_tai"].Width = 100;
            dgvPrisonerList.Columns["buong_so"].Width = 100;
            dgvPrisonerList.Columns["phan_trai"].Width = 100;
            dgvPrisonerList.Columns["danh_muc"].Width = 100;
            dgvPrisonerList.Columns["danh_muc_1"].Width = 100;
            dgvPrisonerList.Columns["pham_vi_hoat_dong"].Width = 100;
            dgvPrisonerList.Columns["bieu_hien_hoat_dong_hien_hanh"].Width = 100;
            dgvPrisonerList.Columns["bien_phap_nghiep_vu"].Width = 100;
            dgvPrisonerList.Columns["bien_phap_ky_luat"].Width = 100;
            dgvPrisonerList.Columns["ngay_dua_ra"].Width = 100;
            dgvPrisonerList.Columns["ly_do_dua_ra"].Width = 200;
            dgvPrisonerList.Columns["ngay_tao"].Width = 80;
            dgvPrisonerList.Columns["nguoi_tao"].Width = 80;
            dgvPrisonerList.Columns["ngay_cap_nhat"].Width = 80;
            dgvPrisonerList.Columns["nguoi_cap_nhat"].Width = 80;
        }

        private void AdjustColumnName()
        {
            dgvPrisonerList.Columns["ma_dang_ky"].HeaderText = "Mã đăng ký";
            dgvPrisonerList.Columns["ma_trai_giam"].HeaderText = "Mã trại giam";
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
            dgvPrisonerList.Columns["phan_loai_quan_che"].HeaderText = "Phân loại quản chế";
            dgvPrisonerList.Columns["ngay_dua_vao_dien_quan_che"].HeaderText = "Ngày đưa vào diện quản chế";
            dgvPrisonerList.Columns["doi_hien_tai"].HeaderText = "Đội hiện tại";
            dgvPrisonerList.Columns["buong_so"].HeaderText = "Buồng số";
            dgvPrisonerList.Columns["phan_trai"].HeaderText = "Phân trại";
            dgvPrisonerList.Columns["danh_muc"].HeaderText = "Danh mục";
            dgvPrisonerList.Columns["danh_muc_1"].HeaderText = "Danh mục 1";
            dgvPrisonerList.Columns["pham_vi_hoat_dong"].HeaderText = "Phạm vi hoạt động";
            dgvPrisonerList.Columns["bieu_hien_hoat_dong_hien_hanh"].HeaderText = "Biểu hiện hoạt động hiện hành";
            dgvPrisonerList.Columns["bien_phap_nghiep_vu"].HeaderText = "Biện pháp nghiệp vụ";
            dgvPrisonerList.Columns["bien_phap_ky_luat"].HeaderText = "Biện pháp kỷ luật";
            dgvPrisonerList.Columns["ngay_dua_ra"].HeaderText = "Ngày đưa ra";
            dgvPrisonerList.Columns["ly_do_dua_ra"].HeaderText = "Lý do đưa ra";
            dgvPrisonerList.Columns["ngay_tao"].HeaderText = "Ngày tạo";
            dgvPrisonerList.Columns["nguoi_tao"].HeaderText = "Người tạo";
            dgvPrisonerList.Columns["ngay_cap_nhat"].HeaderText = "Ngày cập nhật";
            dgvPrisonerList.Columns["nguoi_cap_nhat"].HeaderText = "Người cập nhật";
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
                    string pass = Util.GetResource("key");
                    EncDec.Encrypt(tempFile, path, pass);
                    File.Delete(tempFile);
                    MessageBox.Show("Xuất dữ liệu thành công!", CommonConst.MessageCommon.MESSAGE_CAPTION_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất dữ liệu thất bại!\n" + ex.ToString(), CommonConst.MessageCommon.MESSAGE_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private List<prison_mst> GetDataForExport()
        {
            return _prisonRepository.GetList();
        }

        private void ExportCsv()
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DKCNPN form = new DKCNPN();
            form.IsUpdateMode = false;

            form.FormClosed += childForm_Closed;
            form.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgvPrisonerList.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng trên danh sách!", CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dgvPrisonerList.SelectedRows.Count > 1)
            {
                MessageBox.Show("Vui lòng chỉ chọn 1 dòng trên danh sách!", CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                OpenEditForm(this.dgvPrisonerList.CurrentRow.Cells[1].Value.ToString());
            }
        }

        private void OpenEditForm(string maPn)
        {
            DKCNPN form = new DKCNPN();
            form.IsUpdateMode = true;
            form.MaPhamNhan = maPn;

            form.FormClosed += childForm_Closed;
            form.ShowDialog();
        }

        private void childForm_Closed(object sender, EventArgs e)
        {
            List<prison_mst> lsit = _prisonRepository.GetList();
            dgvPrisonerList.DataSource = lsit;
        }

        private void dgvPrisonerList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.OpenEditForm(this.dgvPrisonerList.CurrentRow.Cells[1].Value.ToString());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPrisonerList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng trên danh sách!", CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                List<String> idList = new List<string>();
                foreach (DataGridViewRow row in dgvPrisonerList.SelectedRows)
                {
                    idList.Add(row.Cells[1].Value.ToString());
                }
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        foreach (String id in idList)
                        {
                            _prisonRepository.Delete(id);
                        }
                        dgvPrisonerList.DataSource = _prisonRepository.GetList();
                        MessageBox.Show("Xóa dữ liệu thành công!", CommonConst.MessageCommon.MESSAGE_CAPTION_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại!\n" + ex.ToString(), CommonConst.MessageCommon.MESSAGE_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    string pass = Util.GetResource("key");

                    EncDec.Decrypt(filePath, tempFile, pass);

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
                    MessageBox.Show("Nhập dữ liệu thành công!", CommonConst.MessageCommon.MESSAGE_CAPTION_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPrisonerList.DataSource = _prisonRepository.GetList();
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nhập dữ liệu thất bại!\n" + ex.ToString(), CommonConst.MessageCommon.MESSAGE_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            SearchDto search = new SearchDto();
            search.MaDangKy = txtSearchPrisonId.Text.Trim();
            search.TenPhamNhan = txtSearchPrisonName.Text.Trim();
            search.MaTraiGiam = cmbSearchDivisonId.SelectedValue == null ? String.Empty : cmbSearchDivisonId.SelectedValue.ToString();

            dgvPrisonerList.DataSource = _prisonRepository.SearchPrison(search);
        }
    }
}
