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
    public partial class UpdatePrisonFrm : Form
    {
        public bool IsUpdateMode { get => _isUpdateMode; set => _isUpdateMode = value; }
        public string MaPhamNhan { get => _maPhamNhan; set => _maPhamNhan = value; }
        public user_mst LoginUser { get => _user; set => _user = value; }

        private readonly Entities _dbContext;
        private PrisonRepository _prisonRepository;
        private bool _isUpdateMode = false;
        private string _maPhamNhan = CommonConst.BLANK;
        private prison_mst _prisoner = null;
        private user_mst _user = null;

        public UpdatePrisonFrm()
        {
            InitializeComponent();
            _dbContext = new Entities();
            _prisonRepository = new PrisonRepository(_dbContext);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsUpdateMode)
            {
                UpdatePrisoner();  
            } else
            {
                AddNewPrisoner();
            }
        }

        private void UpdatePrisoner()
        {
            _prisoner = SetDataToObject(_prisoner);
            _prisoner.ngay_cap_nhat = System.DateTime.Now;
            if (IsValidate(_prisoner))
            {
                _prisonRepository.Update(_prisoner);
                //raiseUpdate();
            }
            else
            {
                return;
            }
            MessageBox.Show("Cập nhật thành công!", CommonConst.MessageCommon.MESSAGE_CAPTION_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private prison_mst SetDataToObject(prison_mst obj)
        {
            obj.ma_dang_ky = txtMaPN.Text.Trim();
            obj.ma_trai_giam = cmbTraiGiam.SelectedValue.ToString();
            obj.ngay_thang_nam_sinh = dtpNgaySinh.Value;
            obj.ho_va_ten = txtHoTen.Text.Trim();
            obj.ten_goi_khac = txtTenKhac.Text.Trim();

            if (rdbNam.Checked)
            {
                obj.gioi_tinh = CommonConst.GIOI_TINH_NAM;
            }
            else if (rdbNu.Checked)
            {
                obj.gioi_tinh = CommonConst.GIOI_TINH_NU;
            }
            else
            {
                obj.gioi_tinh = null;
            }

            obj.dan_toc = cmbDantoc.SelectedValue.ToString();
            obj.ton_giao = cmbTonGiao.SelectedValue.ToString();
            obj.trinh_do_hoc_van = cmbTrinhDoHocVan.SelectedValue == null ? CommonConst.BLANK : cmbTrinhDoHocVan.SelectedValue.ToString();
            obj.ngoai_ngu = cmbNgoaiNgu.SelectedValue == null ? CommonConst.BLANK : cmbNgoaiNgu.SelectedValue.ToString();
            obj.quoc_tich = cmbQuocTich.SelectedValue.ToString();

            obj.ten_cha = txtTenCha.Text.Trim();
            obj.ten_me = txtTenMe.Text.Trim();
            obj.ten_vo_chong = txtTenVoChong.Text.Trim();
            obj.que_quan = txtQueQuan.Text.Trim();
            obj.noi_dktt = txtNoiDkHktt.Text.Trim();

            obj.toi_danh = cmbToiDanh.SelectedValue == null ? CommonConst.BLANK : cmbToiDanh.SelectedValue.ToString();
            obj.an_phat = txtAnphat.Text.Trim();
            obj.ngay_bat = dtpNgayBat.Value;
            obj.ngay_nhap_trai = dtpNgayNhapTrai.Value;

            obj.phan_loai_quan_che = cmbPhanLoaiQuanChe.SelectedValue == null ? CommonConst.BLANK : cmbPhanLoaiQuanChe.SelectedValue.ToString();
            obj.ngay_dua_vao_dien_quan_che = dtpNgayDuaVaoQuanChe.Value;
            obj.doi_hien_tai = txtChapHanhAnTai.Text.Trim();
            obj.buong_so = cmbBuongGiam.SelectedValue == null ? CommonConst.BLANK : cmbBuongGiam.SelectedValue.ToString();
            obj.phan_trai = cmbPhanTrai.SelectedValue == null ? CommonConst.BLANK : cmbPhanTrai.SelectedValue.ToString();
            obj.danh_muc = cmbDanhMuc.SelectedValue == null ? CommonConst.BLANK : cmbDanhMuc.SelectedValue.ToString();
            obj.danh_muc_1 = cmbDanhMuc1.SelectedItem == null ? CommonConst.BLANK : ((ListItem)cmbDanhMuc1.SelectedItem).Value;
            obj.pham_vi_hoat_dong = cmbPhamViHoatDong.SelectedValue == null ? CommonConst.BLANK : cmbPhamViHoatDong.SelectedValue.ToString();
            obj.bieu_hien_hoat_dong_hien_hanh = txtBieuHienHoatDong.Text.Trim();
            obj.bien_phap_nghiep_vu = cmbBienPhapNghiepVu.SelectedValue == null ? CommonConst.BLANK : cmbBienPhapNghiepVu.SelectedValue.ToString();
            obj.bien_phap_ky_luat = cmbBienPhapKiLuat.SelectedValue == null ? CommonConst.BLANK : cmbBienPhapKiLuat.SelectedValue.ToString();

            obj.tien_an = txtTienAn.Text.Trim();
            obj.tien_su = txtTienSu.Text.Trim();
            obj.tom_tat_toi_danh = txtTomTatHanhVi.Text.Trim();

            if (chkRaTrai.Checked)
            {
                obj.ngay_dua_ra = dtpNgayRaTrai.Value;
                obj.ly_do_dua_ra = txtLyDoRaTrai.Text.Trim();
            }

            return obj;
        }
        private void AddNewPrisoner()
        {
            try
            {
                prison_mst prisoner = new prison_mst();

                prisoner = SetDataToObject(prisoner);
                prisoner.ngay_tao = System.DateTime.Now;

                if (IsValidate(prisoner))
                {
                    _prisonRepository.Add(prisoner);
                    //raiseUpdate();
                }
                else
                {
                    return;
                }
                
                MessageBox.Show("Thêm mới thành công!", CommonConst.MessageCommon.MESSAGE_CAPTION_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                this.btnDummyRegistration.Visible = false;
            }
            else
            {
                DisableLydoRaTrai();
                this.btnDummyRegistration.Visible = true;
            }
        }

        private void LoadDataToScreen()
        {       
            if (!String.IsNullOrEmpty(_maPhamNhan))
            {
                _prisoner = _prisonRepository.GetPrisonById(MaPhamNhan);

                if (_prisoner != null)
                {
                    txtMaPN.Text = _prisoner.ma_dang_ky;
                    txtHoTen.Text = _prisoner.ho_va_ten;
                    txtTenKhac.Text = _prisoner.ten_goi_khac;
                    txtTenCha.Text = _prisoner.ten_cha;
                    txtTenMe.Text = _prisoner.ten_me;
                    txtTenVoChong.Text = _prisoner.ten_vo_chong;
                    txtQueQuan.Text = _prisoner.que_quan;
                    txtNoiDkHktt.Text = _prisoner.noi_dktt;
                    txtAnphat.Text = _prisoner.an_phat;
                    txtBieuHienHoatDong.Text = _prisoner.bieu_hien_hoat_dong_hien_hanh;
                    txtChapHanhAnTai.Text = _prisoner.doi_hien_tai;
                    txtTienAn.Text = _prisoner.tien_an;
                    txtTienSu.Text = _prisoner.tien_su;
                    txtTomTatHanhVi.Text = _prisoner.tom_tat_toi_danh;

                    cmbTraiGiam.SelectedValue = _prisoner.ma_trai_giam;
                    cmbDantoc.SelectedValue = _prisoner.dan_toc;
                    cmbTonGiao.SelectedValue = _prisoner.ton_giao;
                    cmbQuocTich.SelectedValue = _prisoner.quoc_tich;
                    cmbTrinhDoHocVan.SelectedValue = _prisoner.trinh_do_hoc_van;
                    cmbNgoaiNgu.SelectedValue = _prisoner.ngoai_ngu;
                    cmbToiDanh.SelectedValue = _prisoner.toi_danh;
                    cmbPhanLoaiQuanChe.SelectedValue = _prisoner.phan_loai_quan_che;
                    cmbBuongGiam.SelectedValue = _prisoner.buong_so;
                    cmbPhanTrai.SelectedValue = _prisoner.phan_trai;
                    cmbDanhMuc.SelectedValue = _prisoner.danh_muc;
                    cmbDanhMuc1.SelectedText = _prisoner.danh_muc_1;
                    cmbPhamViHoatDong.SelectedValue = _prisoner.pham_vi_hoat_dong;
                    cmbBienPhapKiLuat.SelectedValue = _prisoner.bien_phap_ky_luat;
                    cmbBienPhapNghiepVu.SelectedValue = _prisoner.bien_phap_nghiep_vu;

                    dtpNgaySinh.Value = _prisoner.ngay_thang_nam_sinh.Value;
                    dtpNgayBat.Value = _prisoner.ngay_bat.Value;
                    dtpNgayNhapTrai.Value = _prisoner.ngay_nhap_trai.Value;
                    dtpNgayDuaVaoQuanChe.Value = _prisoner.ngay_dua_vao_dien_quan_che.Value;
                    
                    if(_prisoner.ngay_dua_ra != null)
                    {
                        EnableLydoRaTrai();
                        dtpNgayRaTrai.Value = _prisoner.ngay_dua_ra.Value;
                        txtLyDoRaTrai.Text = _prisoner.ly_do_dua_ra;
                    }else
                    {
                        DisableLydoRaTrai();
                    }

                    if (CommonConst.GIOI_TINH_NAM.Equals(_prisoner.gioi_tinh))
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

        private void DisableLydoRaTrai()
        {
            dtpNgayRaTrai.Enabled = false;
            txtLyDoRaTrai.Enabled = false;
            txtLyDoRaTrai.BackColor = Color.White;
            dtpNgayRaTrai.Format = DateTimePickerFormat.Custom;
            dtpNgayRaTrai.CustomFormat = ":";
            txtLyDoRaTrai.Text = CommonConst.BLANK;
        }

        private void EnableLydoRaTrai()
        {
            dtpNgayRaTrai.Enabled = true;
            txtLyDoRaTrai.Enabled = true;
            txtLyDoRaTrai.BackColor = Color.LightCoral;
            dtpNgayRaTrai.Format = DateTimePickerFormat.Custom;
            dtpNgayRaTrai.CustomFormat = "dd/MM/yyyy";
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
            ComboBoxUtil.SetDanhSachTraiGiam(_dbContext, cmbTraiGiam, this._user);

            ClearScreen();

            if (_isUpdateMode)
            {
                btnUpdate.Text = "Cập nhật[F10]";
                txtMaPN.Enabled = false;
            }else
            {
                btnUpdate.Text = "Thêm mới[F10]";
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidate(prison_mst prisoner)
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(prisoner.ma_dang_ky))
            {
                isValid = false;
                MessageBox.Show("Hãy nhập vào mã phạm nhân!", CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (String.IsNullOrEmpty(prisoner.ho_va_ten))
            {
                isValid = false;
                MessageBox.Show("Hãy nhập vào tên phạm nhân!", CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (prisoner.ngay_bat.Value > prisoner.ngay_nhap_trai.Value)
            {
                isValid = false;
                MessageBox.Show("Ngày nhập trại chưa chính xác. \nNgày nhập trại phải sau ngày bắt!", CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (prisoner.ngay_nhap_trai.Value > prisoner.ngay_dua_vao_dien_quan_che.Value)
            {
                isValid = false;
                MessageBox.Show("Ngày đưa vào diện quản chế chưa chính xác. \nNgày đưa vào diện quản chế phải sau ngày nhập trại!", CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (!_isUpdateMode && _prisonRepository.IsExist(prisoner.ma_dang_ky))
            {
                isValid = false;
                MessageBox.Show("Mã phạm nhân đã tồn tại!", CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (prisoner.ngay_dua_ra != null)
            {
                if (String.IsNullOrEmpty(prisoner.ly_do_dua_ra))
                {
                    isValid = false;
                    MessageBox.Show("Hãy nhập vào vào lý do ra trại!", CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return isValid;
                }
            }

            return isValid;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F10)
            {
                if (IsUpdateMode)
                {
                    this.UpdatePrisoner();
                }
                else
                {
                    this.AddNewPrisoner();
                }
                
                return true;
            }else if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dtpNgayBat_Leave(object sender, EventArgs e)
        {
            dtpNgayNhapTrai.Value = dtpNgayBat.Value;
        }

        private void dtpNgayNhapTrai_Leave(object sender, EventArgs e)
        {
            dtpNgayDuaVaoQuanChe.Value = dtpNgayNhapTrai.Value.AddDays(1);
        }

        private void chkRaTrai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRaTrai.Checked)
            {
                EnableLydoRaTrai();
            }else
            {
                DisableLydoRaTrai();
            }
        }

        private void btnDummyRegistration_Click(object sender, EventArgs e)
        {
            SetDummyData();
        }

        private void SetDummyData()
        {
            ClearScreen();
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
    }
}
