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
using CommonLib;
using Business.Repository;
using CommonLib.Model.DTO;

namespace QLPN
{
    public partial class DKCNPN : Form
    {
        private readonly Entities _dbContext;
        private PrisonRepository _prisonRepository;
        private bool _isUpdateMode = false;
        private string _maPhamNhan = CommonConst.BLANK;
        public bool IsUpdateMode { get => _isUpdateMode; set => _isUpdateMode = value; }
        public string MaPhamNhan { get => _maPhamNhan; set => _maPhamNhan = value; }

        public DKCNPN()
        {
            InitializeComponent();
            _dbContext = new Entities();
            _prisonRepository = new PrisonRepository(_dbContext);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdatePrisoner();
        }

        private void UpdatePrisoner()
        {
            if (!IsValidate())
            {
                return;
            }
            try
            {
                prison_mst prisoner = new prison_mst();
                prisoner.ma_dang_ky = txtMaPN.Text.Trim();
                prisoner.ma_trai_giam = cmbTraiGiam.SelectedValue.ToString();
                prisoner.ngay_thang_nam_sinh = dtpNgaySinh.Value;
                prisoner.ho_va_ten = txtHoTen.Text.Trim();
                prisoner.ten_goi_khac = txtTenKhac.Text.Trim();

                if (rdbNam.Checked)
                {
                    prisoner.gioi_tinh = CommonConst.GIOI_TINH_NAM;
                }
                else if (rdbNu.Checked)
                {
                    prisoner.gioi_tinh = CommonConst.GIOI_TINH_NU;
                }
                else
                {
                    prisoner.gioi_tinh = null;
                }

                prisoner.dan_toc = cmbDantoc.SelectedValue.ToString();
                prisoner.ton_giao = cmbTonGiao.SelectedValue.ToString();
                prisoner.trinh_do_hoc_van = cmbTrinhDoHocVan.SelectedValue == null ? CommonConst.BLANK : cmbTrinhDoHocVan.SelectedValue.ToString();
                prisoner.ngoai_ngu = cmbNgoaiNgu.SelectedValue == null ? CommonConst.BLANK : cmbNgoaiNgu.SelectedValue.ToString();
                prisoner.quoc_tich = cmbQuocTich.SelectedValue.ToString();

                prisoner.ten_cha = txtTenCha.Text.Trim();
                prisoner.ten_me = txtTenMe.Text.Trim();
                prisoner.ten_vo_chong = txtTenVoChong.Text.Trim();
                prisoner.que_quan = txtQueQuan.Text.Trim();
                prisoner.noi_dktt = txtNoiDkHktt.Text.Trim();

                prisoner.toi_danh = cmbToiDanh.SelectedValue == null ? CommonConst.BLANK : cmbToiDanh.SelectedValue.ToString();
                prisoner.an_phat = txtAnphat.Text.Trim();
                prisoner.ngay_bat = dtpNgayBat.Value;
                prisoner.ngay_nhap_trai = dtpNgayNhapTrai.Value;

                prisoner.phan_loai_quan_che = cmbPhanLoaiQuanChe.SelectedValue == null ? CommonConst.BLANK : cmbPhanLoaiQuanChe.SelectedValue.ToString();
                prisoner.ngay_dua_vao_dien_quan_che = dtpNgayDuaVaoQuanChe.Value;
                prisoner.doi_hien_tai = txtChapHanhAnTai.Text.Trim();
                prisoner.buong_so = cmbBuongGiam.SelectedValue == null ? CommonConst.BLANK : cmbBuongGiam.SelectedValue.ToString();
                //prisoner.khu = cmbBuongGiam.SelectedValue.ToString();
                prisoner.phan_trai = cmbPhanTrai.SelectedValue == null ? CommonConst.BLANK : cmbPhanTrai.SelectedValue.ToString();
                prisoner.danh_muc = cmbDanhMuc.SelectedValue == null ? CommonConst.BLANK : cmbDanhMuc.SelectedValue.ToString();
                prisoner.danh_muc_1 = cmbDanhMuc1.SelectedText == null ? CommonConst.BLANK : cmbDanhMuc1.SelectedText;
                prisoner.pham_vi_hoat_dong = cmbPhamViHoatDong.SelectedValue == null ? CommonConst.BLANK : cmbPhamViHoatDong.SelectedValue.ToString();
                prisoner.bieu_hien_hoat_dong_hien_hanh = txtBieuHienHoatDong.Text.Trim();
                prisoner.bien_phap_nghiep_vu = cmbBienPhapNghiepVu.SelectedValue == null ? CommonConst.BLANK : cmbBienPhapNghiepVu.SelectedValue.ToString();
                prisoner.bien_phap_ky_luat = cmbBienPhapKiLuat.SelectedValue == null ? CommonConst.BLANK : cmbBienPhapKiLuat.SelectedValue.ToString();

               

                prisoner.tien_an = txtTienAn.Text.Trim();
                prisoner.tien_su = txtTienSu.Text.Trim();
                prisoner.tom_tat_toi_danh = txtTomTatHanhVi.Text.Trim();
               

                if (_isUpdateMode)
                {
                    prisoner.ngay_cap_nhat = System.DateTime.Now;
                    if (dtpNgayRaTrai.Value != null)
                    {
                        prisoner.ngay_dua_ra = dtpNgayRaTrai.Value;
                        prisoner.ly_do_dua_ra = txtLyDoRaTrai.Text.Trim();
                    }
                    _prisonRepository.Update(prisoner);
                }
                else
                {
                    if (chkRaTrai.Checked)
                    {
                        prisoner.ngay_dua_ra = dtpNgayRaTrai.Value;
                        prisoner.ly_do_dua_ra = txtLyDoRaTrai.Text.Trim();
                    }
                    prisoner.ngay_tao = System.DateTime.Now;
                    _prisonRepository.Add(prisoner);
                }
                
                MessageBox.Show("Thêm mới thành công!", CommonConst.MessageCommon.MESSAGE_CAPTION_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);

                var confirmResult = MessageBox.Show("Bạn có muốn tự động tạo dữ liệu dummy hay không ??",
                                     "Confirm!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    SetDummyData();
                }
                else
                {
                    ClearScreen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm mới thất bại!\n" + ex.ToString(), CommonConst.MessageCommon.MESSAGE_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DKCNPN_Load(object sender, EventArgs e)
        {
            
            InitScreen();

            if (_isUpdateMode)
            {
                LoadDataToScreen();
            }
            else
            {
                chkRaTrai.Visible = true;
                SetDummyData();
            }
        }

        private void LoadDataToScreen()
        {
            prison_mst prisoner;          
            if (!String.IsNullOrEmpty(_maPhamNhan))
            {
                dtpNgayRaTrai.Format = DateTimePickerFormat.Custom;
                prisoner = _prisonRepository.GetPrisonById(MaPhamNhan);
                if (prisoner != null)
                {
                    txtMaPN.Text = prisoner.ma_dang_ky;
                    
                    
                    txtHoTen.Text = prisoner.ho_va_ten;
                    txtTenKhac.Text = prisoner.ten_goi_khac;
                    txtTenCha.Text = prisoner.ten_cha;
                    txtTenMe.Text = prisoner.ten_me;
                    txtTenVoChong.Text = prisoner.ten_vo_chong;
                    txtQueQuan.Text = prisoner.que_quan;
                    txtNoiDkHktt.Text = prisoner.noi_dktt;
                    txtAnphat.Text = prisoner.an_phat;
                    txtBieuHienHoatDong.Text = prisoner.bieu_hien_hoat_dong_hien_hanh;
                    txtChapHanhAnTai.Text = prisoner.doi_hien_tai;
                    txtTienAn.Text = prisoner.tien_an;
                    txtTienSu.Text = prisoner.tien_su;
                    txtTomTatHanhVi.Text = prisoner.tom_tat_toi_danh;

                    cmbTraiGiam.SelectedValue = prisoner.ma_trai_giam;
                    cmbDantoc.SelectedValue = prisoner.dan_toc;
                    cmbTonGiao.SelectedValue = prisoner.ton_giao;
                    cmbQuocTich.SelectedValue = prisoner.quoc_tich;
                    cmbNgoaiNgu.SelectedValue = prisoner.ngoai_ngu;
                    cmbToiDanh.SelectedValue = prisoner.toi_danh;
                    cmbPhanLoaiQuanChe.SelectedValue = prisoner.phan_loai_quan_che;
                    cmbBuongGiam.SelectedValue = prisoner.buong_so;
                    cmbPhanTrai.SelectedValue = prisoner.phan_trai;
                    cmbDanhMuc.SelectedValue = prisoner.danh_muc;
                    cmbDanhMuc1.SelectedText = prisoner.danh_muc_1;
                    cmbPhamViHoatDong.SelectedValue = prisoner.pham_vi_hoat_dong;
                    cmbBienPhapKiLuat.SelectedValue = prisoner.bien_phap_ky_luat;
                    cmbBienPhapNghiepVu.SelectedValue = prisoner.bien_phap_nghiep_vu;

                    dtpNgaySinh.Value = prisoner.ngay_thang_nam_sinh.Value;
                    dtpNgayBat.Value = prisoner.ngay_bat.Value;
                    dtpNgayNhapTrai.Value = prisoner.ngay_nhap_trai.Value;
                    dtpNgayDuaVaoQuanChe.Value = prisoner.ngay_dua_vao_dien_quan_che.Value;
                    
                    if(prisoner.ngay_dua_ra != null)
                    {
                        dtpNgayRaTrai.Value = prisoner.ngay_dua_ra.Value;
                        txtLyDoRaTrai.Text = prisoner.ly_do_dua_ra;
                    }else
                    {
                        dtpNgayRaTrai.Enabled = false;
                        txtLyDoRaTrai.Enabled = false;
                        txtLyDoRaTrai.BackColor = Color.White;
                        dtpNgayRaTrai.Format = DateTimePickerFormat.Custom;
                        dtpNgayRaTrai.CustomFormat = ":";
                        txtLyDoRaTrai.Text = CommonConst.BLANK;
                    }


                    if (CommonConst.GIOI_TINH_NAM.Equals(prisoner.gioi_tinh))
                    {
                        rdbNam.Checked = true;
                    }
                    else
                    {
                        rdbNu.Checked = true;
                    }
                }
            }
        }
        private void ClearScreen()
        {
            txtHoTen.Text = CommonConst.BLANK;
            txtTenCha.Text = CommonConst.BLANK;
            txtTenMe.Text = CommonConst.BLANK;
            txtTenVoChong.Text = CommonConst.BLANK;
            txtTenKhac.Text = CommonConst.BLANK;
            rdbNam.Checked = true;
            cmbQuocTich.SelectedIndex = cmbQuocTich.FindStringExact("250:Viet Nam");
            dtpNgayRaTrai.Format = DateTimePickerFormat.Custom;
            dtpNgayRaTrai.CustomFormat = "  :  ";

            txtAnphat.Text = CommonConst.BLANK;
            txtChapHanhAnTai.Text = CommonConst.BLANK;
            txtBieuHienHoatDong.Text = CommonConst.BLANK;
            txtTomTatHanhVi.Text = CommonConst.BLANK;
            txtMaPN.Text = CommonConst.BLANK;

            txtQueQuan.Text = CommonConst.BLANK;
            txtNoiDkHktt.Text = CommonConst.BLANK;
            txtTienAn.Text = CommonConst.BLANK;
            txtTienSu.Text = CommonConst.BLANK;
        }
        private void InitScreen()
        {
            ComboBoxUtil.SetDanhSachPhanLoaiQuanChe(_dbContext, cmbPhanLoaiQuanChe);
            ComboBoxUtil.SetDanhSachDanhMuc(_dbContext, cmbDanhMuc);
            ComboBoxUtil.SetDanhSachPhamViHoatDong(_dbContext, cmbPhamViHoatDong);
            ComboBoxUtil.SetDanhSachBienPhapNghiepVu(_dbContext, cmbBienPhapNghiepVu);
            ComboBoxUtil.SetDanhSachBienPhapKiLuat(_dbContext, cmbBienPhapKiLuat);
            ComboBoxUtil.SetDanhSachNgonNgu(_dbContext, cmbNgoaiNgu);
            ComboBoxUtil.SetDanhSachDantoc(_dbContext, cmbDantoc);
            ComboBoxUtil.SetDanhSachTongiao(_dbContext, cmbTonGiao);
            ComboBoxUtil.SetDanhSachHocVan(_dbContext, cmbTrinhDoHocVan);
            ComboBoxUtil.SetDanhSachQuocTich(_dbContext, cmbQuocTich);
            ComboBoxUtil.SetDanhSachToiDanh(_dbContext, cmbToiDanh);
            ComboBoxUtil.SetDanhSachBuongGiam(_dbContext, cmbBuongGiam);
            ComboBoxUtil.SetDanhSachPhanKhu(_dbContext, cmbPhanTrai);
            ComboBoxUtil.SetDanhSachDanhMuc1(cmbDanhMuc1, cmbDanhMuc.SelectedValue.ToString());
            ComboBoxUtil.SetDanhSachTraiGiam(_dbContext, cmbTraiGiam);

            rdbNam.Checked = true;
            cmbQuocTich.SelectedIndex = cmbQuocTich.FindStringExact("250:Viet Nam");
            dtpNgayRaTrai.Format = DateTimePickerFormat.Custom;
            dtpNgayRaTrai.CustomFormat = ":";

            if (_isUpdateMode)
            {

            }
            else
            {
                dtpNgayRaTrai.Enabled = false;
                txtLyDoRaTrai.Enabled = false;
            }
        }

        private void SetDummyData()
        {
            Random rand = new Random();
            txtHoTen.Text = "Nguyễn Văn A" + rand.Next(1, 1000).ToString();
            txtTenCha.Text = "Nguyễn Văn B" + rand.Next(1, 1000).ToString();
            txtTenMe.Text = "Lê Thị C" + rand.Next(1, 1000).ToString();
            txtTenVoChong.Text = "Nguyễn Thu D" + rand.Next(1, 1000).ToString();
            txtTenKhac.Text = txtHoTen.Text.ToUpper().Substring(10, txtHoTen.Text.Length - 10);

            cmbTrinhDoHocVan.SelectedIndex = rand.Next(0, 5); ;
            cmbNgoaiNgu.SelectedIndex = rand.Next(0, 8);
            cmbToiDanh.SelectedIndex = rand.Next(0, 100);
            cmbPhanLoaiQuanChe.SelectedIndex = rand.Next(0, 10);
            cmbDantoc.SelectedIndex = rand.Next(0, 50);
            cmbDanhMuc.SelectedIndex = rand.Next(0, 1);
            cmbDanhMuc1.SelectedIndex = rand.Next(0, 5);
            cmbBuongGiam.SelectedIndex = rand.Next(0, 20);
            cmbPhanTrai.SelectedIndex = rand.Next(0, 10);
            txtAnphat.Text = rand.Next(1, 30).ToString() + " năm tù";
            txtChapHanhAnTai.Text = "Đội " + rand.Next(10, 20).ToString();
            cmbPhamViHoatDong.SelectedIndex = rand.Next(0, 2);
            txtBieuHienHoatDong.Text = "AAAAAAAAAA" + rand.Next(100, 200);
            cmbBienPhapKiLuat.SelectedIndex = rand.Next(0, 2);
            cmbBienPhapNghiepVu.SelectedIndex = rand.Next(0, 1);
            txtTomTatHanhVi.Text = "BBBBBBBBBBB" + rand.Next(100, 200);

            cmbTraiGiam.SelectedIndex = cmbTraiGiam.FindStringExact("0VLB0002:Hồng Ca");
            txtMaPN.Text = "01NV" + _prisonRepository.GetIcrementCodeForDummy() + "0VLB0002";

            dtpNgaySinh.Value = new DateTime(1979, rand.Next(1, 12), rand.Next(1, 30));
            dtpNgayBat.Value = new DateTime(2014, rand.Next(1, 12), rand.Next(1, 30));
            dtpNgayNhapTrai.Value = dtpNgayBat.Value.AddDays(2);
            dtpNgayDuaVaoQuanChe.Value = dtpNgayBat.Value.AddMonths(1);

            txtQueQuan.Text = "Ngõ " + rand.Next(100, 999).ToString() + " đường Tôn Đức Thắng, Đống Đa, Hà Nội";
            txtNoiDkHktt.Text = "Ngõ " + rand.Next(10, 99).ToString() + " đường Huỳnh Thúc Kháng, Đống Đa, Hà Nội";
            string[] dummy = new string[] { "Có", "Không" };

            txtTienAn.Text = dummy[rand.Next(0, 1)];
            txtTienSu.Text = dummy[rand.Next(0, 1)];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void cmbDanhMuc1_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxUtil.SetDanhSachDanhMuc1(cmbDanhMuc1, cmbDanhMuc.SelectedValue.ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool IsValidate()
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(txtMaPN.Text.Trim()))
            {
                isValid = false;
                MessageBox.Show("Hãy nhập vào mã phạm nhân!", CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (dtpNgayBat.Value > dtpNgayNhapTrai.Value)
            {
                isValid = false;
                MessageBox.Show("Ngày nhập trại chưa chính xác. \nNgày nhập trại phải sau ngày bắt!", CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (dtpNgayNhapTrai.Value > dtpNgayDuaVaoQuanChe.Value)
            {
                isValid = false;
                MessageBox.Show("Ngày đưa vào diện quản chế chưa chính xác. \nNgày đưa vào diện quản chế phải sau ngày nhập trại!", CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (!_isUpdateMode && _prisonRepository.IsExist(txtMaPN.Text.Trim()))
            {
                isValid = false;
                MessageBox.Show("Mã phạm nhân đã tồn tại!", CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (chkRaTrai.Checked)
            {
                if (String.IsNullOrEmpty(txtLyDoRaTrai.Text.Trim()))
                {
                    isValid = false;
                    MessageBox.Show("Hãy nhập vào vào lý do ra trại!", CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return isValid;
                }
            }

            return isValid;
        }

        private void DKCNPN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.F10))   // Ctrl-S Save
            {

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F10)
            {
                this.UpdatePrisoner();
                return true;
            }else if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            } else if(keyData == Keys.Delete)
            {
                var confirmResult = MessageBox.Show("Bạn có muốn xóa dữ liệu này không?",
                                     "Confirm!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    MessageBox.Show("Đã xóa thành công!", CommonConst.MessageCommon.MESSAGE_CAPTION_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xóa!", CommonConst.MessageCommon.MESSAGE_CAPTION_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dtpNgayBat_Leave(object sender, EventArgs e)
        {
            dtpNgayNhapTrai.Value = dtpNgayBat.Value;
        }

        private void dtpNgayNhapTrai_Leave(object sender, EventArgs e)
        {
            dtpNgayDuaVaoQuanChe.Value = dtpNgayNhapTrai.Value;
        }

        private void chkRaTrai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRaTrai.Checked)
            {
                dtpNgayRaTrai.Enabled = true;
                txtLyDoRaTrai.Enabled = true;
                txtLyDoRaTrai.BackColor = Color.LightCoral;
                dtpNgayRaTrai.Format = DateTimePickerFormat.Custom;
                dtpNgayRaTrai.CustomFormat = "dd/MM/yyyy";
                dtpNgayRaTrai.Value = System.DateTime.Now;
            }else
            {
                dtpNgayRaTrai.Enabled = false;
                txtLyDoRaTrai.Enabled = false;
                txtLyDoRaTrai.BackColor = Color.White;
                dtpNgayRaTrai.Format = DateTimePickerFormat.Custom;
                dtpNgayRaTrai.CustomFormat = ":";
                txtLyDoRaTrai.Text = CommonConst.BLANK;
            }
        }

        private void btnDummyRegistration_Click(object sender, EventArgs e)
        {
            SetDummyData();
        }
    }
}
