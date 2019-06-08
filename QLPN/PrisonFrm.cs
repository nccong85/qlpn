using Business.Repository;
using CommonLib;
using CommonLib.Model.DTO;
using DAL;
using QLPN.App_Code;
using QLPN.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLPN
{
    public partial class PrisonFrm : Form
    {
        #region Declaration
        public bool IsUpdateMode { get => _isUpdateMode; set => _isUpdateMode = value; }
        public string MaPhamNhan { get => _maPhamNhan; set => _maPhamNhan = value; }
        public user_mst LoginUser { get => _user; set => _user = value; }

        private readonly Entities _dbContext;
        private PrisonRepository _prisonRepository;
        private bool _isUpdateMode = false;
        private string _maPhamNhan = CommonConst.BLANK;
        private prison_mst _prisoner = null;
        private user_mst _user = null;

        private List<ListItemEx> _phanLoaiQuanCheList = null;
        private List<ListItemEx> _danhMucHoatDongList = null;
        private List<ListItemEx> _phamViHoatDongList = null;
        private List<ListItemEx> _bienPhapNghiepVuList = null;
        private List<ListItemEx> _bienPhapPhapLuatList = null;
        private List<ListItemEx> _ngoaiNguList = null;
        private List<ListItemEx> _dantocList = null;
        private List<ListItemEx> _tongiaoList = null;
        private List<ListItemEx> _trinhdoHocVanList = null;
        private List<ListItemEx> _quocTichList = null;
        private List<ListItemEx> _toiDanhList = null;
        private List<ListItem> _buongGiamList = null;
        private List<ListItem> _phanKhuList = null;
        private List<ListItem> _danhMuc1List = null;
        private List<ListItemEx> _traiGiamList = null;
        #endregion
        #region Constructor
        public PrisonFrm()
        {
            InitializeComponent();
            _dbContext = new Entities();
            _prisonRepository = new PrisonRepository(_dbContext);
        }
        #endregion

        #region Event
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsUpdateMode)
            {
                UpdatePrisoner();
            }
            else
            {
                AddNewPrisoner();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            }
            else if (keyData == Keys.Escape)
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
            }
            else
            {
                DisableLydoRaTrai();
            }
        }

        private void btnDummyRegistration_Click(object sender, EventArgs e)
        {
            SetDummyData();
        }

        private void cmbTraiGiam_TextUpdate(object sender, EventArgs e)
        {
            if (_traiGiamList != null)
            {
                ComboBoxUtil.SetAutoFilter(this.cmbTraiGiam, _traiGiamList);
            }
        }

        private void cmbDantoc_TextUpdate(object sender, EventArgs e)
        {
            if (_dantocList != null)
            {
                ComboBoxUtil.SetAutoFilter(this.cmbDantoc, _dantocList);
            }
        }

        private void cmbTrinhDoHocVan_TextUpdate(object sender, EventArgs e)
        {
            if (_trinhdoHocVanList != null)
            {
                ComboBoxUtil.SetAutoFilter(this.cmbTrinhDoHocVan, _trinhdoHocVanList);
            }
        }

        private void cmbNgoaiNgu_TextUpdate(object sender, EventArgs e)
        {
            if (_ngoaiNguList != null)
            {
                ComboBoxUtil.SetAutoFilter(this.cmbNgoaiNgu, _ngoaiNguList);
            }
        }

        private void cmbQuocTich_TextUpdate(object sender, EventArgs e)
        {
            if (_quocTichList != null)
            {
                ComboBoxUtil.SetAutoFilter(this.cmbQuocTich, _quocTichList);
            }
        }

        private void cmbToiDanh_TextUpdate(object sender, EventArgs e)
        {
            if (_toiDanhList != null)
            {
                ComboBoxUtil.SetAutoFilter(this.cmbToiDanh, _toiDanhList);
            }
        }

        private void cmbBuongGiam_TextUpdate(object sender, EventArgs e)
        {
            if (_buongGiamList != null)
            {
                ComboBoxUtil.SetAutoFilter(this.cmbBuongGiam, _buongGiamList);
            }
        }

        private void cmbPhanKhu_TextUpdate(object sender, EventArgs e)
        {
            if (_phanKhuList != null)
            {
                ComboBoxUtil.SetAutoFilter(this.cmbPhanKhu, _phanKhuList);
            }
        }

        private void cmbDanhMuc_TextUpdate(object sender, EventArgs e)
        {
            if (_danhMucHoatDongList != null)
            {
                ComboBoxUtil.SetAutoFilter(this.cmbDanhMuc, _danhMucHoatDongList);
            }
        }

        private void cmbDanhMuc1_TextUpdate(object sender, EventArgs e)
        {
            if (_danhMuc1List != null)
            {
                ComboBoxUtil.SetAutoFilter(this.cmbDanhMuc1, _danhMuc1List);
            }
        }

        private void cmbPhamViHoatDong_TextUpdate(object sender, EventArgs e)
        {
            if (_phamViHoatDongList != null)
            {
                ComboBoxUtil.SetAutoFilter(this.cmbPhamViHoatDong, _phamViHoatDongList);
            }
        }

        private void cmbBienPhapPhapLuat_TextUpdate(object sender, EventArgs e)
        {
            if (_bienPhapPhapLuatList != null)
            {
                ComboBoxUtil.SetAutoFilter(this.cmbBienPhapPhapLuat, _bienPhapPhapLuatList);
            }
        }

        private void cmbBienPhapNghiepVu_TextUpdate(object sender, EventArgs e)
        {
            if (_bienPhapNghiepVuList != null)
            {
                ComboBoxUtil.SetAutoFilter(this.cmbBienPhapNghiepVu, _bienPhapNghiepVuList);
            }
        }

        private void cmbTonGiao_TextUpdate(object sender, EventArgs e)
        {
            if (_tongiaoList != null)
            {
                ComboBoxUtil.SetAutoFilter(this.cmbTonGiao, _tongiaoList);
            }
        }
        #endregion

        #region Private Method
        private void UpdatePrisoner()
        {
            _prisoner = SetDataToObject(_prisoner);
            _prisoner.ngay_cap_nhat = System.DateTime.Now;
            _prisoner.nguoi_tao = this._user.id;
            try
            {
                if (IsValidate(_prisoner))
                {
                    _prisonRepository.Update(_prisoner);
                    MessageBox.Show(String.Format(Resources.CM_MSG_HANDLE_SUCCESS, Resources.ITEM_ACTION_UPDATE), CommonConst.MessageCommon.MESSAGE_CAPTION_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(String.Concat(Resources.CM_MSG_HANDLE_FAILED, ex.Message), Resources.ITEM_ACTION_UPDATE), CommonConst.MessageCommon.MESSAGE_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            obj.phan_trai = cmbPhanKhu.SelectedValue == null ? CommonConst.BLANK : cmbPhanKhu.SelectedValue.ToString();
            obj.danh_muc = cmbDanhMuc.SelectedValue == null ? CommonConst.BLANK : cmbDanhMuc.SelectedValue.ToString();
            obj.danh_muc_1 = cmbDanhMuc1.SelectedItem == null ? CommonConst.BLANK : ((ListItem)cmbDanhMuc1.SelectedItem).Value;
            obj.pham_vi_hoat_dong = cmbPhamViHoatDong.SelectedValue == null ? CommonConst.BLANK : cmbPhamViHoatDong.SelectedValue.ToString();
            obj.bieu_hien_hoat_dong_hien_hanh = txtBieuHienHoatDong.Text.Trim();
            obj.bien_phap_nghiep_vu = cmbBienPhapNghiepVu.SelectedValue == null ? CommonConst.BLANK : cmbBienPhapNghiepVu.SelectedValue.ToString();
            obj.bien_phap_ky_luat = cmbBienPhapPhapLuat.SelectedValue == null ? CommonConst.BLANK : cmbBienPhapPhapLuat.SelectedValue.ToString();

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
                prisoner.nguoi_tao = this._user.id;

                if (IsValidate(prisoner))
                {
                    _prisonRepository.Add(prisoner);
                }
                else
                {
                    return;
                }
                MessageBox.Show(String.Format(Resources.CM_MSG_HANDLE_SUCCESS, Resources.ITEM_ACTION_ADD), CommonConst.MessageCommon.MESSAGE_CAPTION_INFOR, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(String.Concat(Resources.CM_MSG_HANDLE_FAILED, ex.Message), Resources.ITEM_ACTION_ADD), CommonConst.MessageCommon.MESSAGE_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    cmbPhanKhu.SelectedValue = _prisoner.phan_trai;
                    cmbDanhMuc.SelectedValue = _prisoner.danh_muc;
                    cmbDanhMuc1.SelectedText = _prisoner.danh_muc_1;
                    cmbPhamViHoatDong.SelectedValue = _prisoner.pham_vi_hoat_dong;
                    cmbBienPhapPhapLuat.SelectedValue = _prisoner.bien_phap_ky_luat;
                    cmbBienPhapNghiepVu.SelectedValue = _prisoner.bien_phap_nghiep_vu;

                    dtpNgaySinh.Value = _prisoner.ngay_thang_nam_sinh.Value;
                    dtpNgayBat.Value = _prisoner.ngay_bat.Value;
                    dtpNgayNhapTrai.Value = _prisoner.ngay_nhap_trai.Value;
                    dtpNgayDuaVaoQuanChe.Value = _prisoner.ngay_dua_vao_dien_quan_che.Value;

                    if (_prisoner.ngay_dua_ra != null)
                    {
                        EnableLydoRaTrai();
                        dtpNgayRaTrai.Value = _prisoner.ngay_dua_ra.Value;
                        txtLyDoRaTrai.Text = _prisoner.ly_do_dua_ra;
                    }
                    else
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
            dtpNgayRaTrai.CustomFormat = CommonConst.FormatDateTime.DATE_DDMMYYYY;
        }

        private void InitScreen()
        {
            ComboBoxUtil.SetDanhSachPhanLoaiQuanChe(_dbContext, cmbPhanLoaiQuanChe);
            ComboBoxUtil.SetDanhSachDanhMuc(_dbContext, cmbDanhMuc);
            ComboBoxUtil.SetDanhSachPhamViHoatDong(_dbContext, cmbPhamViHoatDong);
            ComboBoxUtil.SetDanhSachBienPhapNghiepVu(_dbContext, cmbBienPhapNghiepVu);
            ComboBoxUtil.SetDanhSachBienPhapPhapLuat(_dbContext, cmbBienPhapPhapLuat);
            ComboBoxUtil.SetDanhSachNgonNgu(_dbContext, cmbNgoaiNgu);
            ComboBoxUtil.SetDanhSachDantoc(_dbContext, cmbDantoc);
            ComboBoxUtil.SetDanhSachTongiao(_dbContext, cmbTonGiao);
            ComboBoxUtil.SetDanhSachHocVan(_dbContext, cmbTrinhDoHocVan);
            ComboBoxUtil.SetDanhSachQuocTich(_dbContext, cmbQuocTich);
            ComboBoxUtil.SetDanhSachToiDanh(_dbContext, cmbToiDanh);
            ComboBoxUtil.SetDanhSachBuongGiam(_dbContext, cmbBuongGiam);
            ComboBoxUtil.SetDanhSachPhanKhu(_dbContext, cmbPhanKhu);
            ComboBoxUtil.SetDanhSachDanhMuc1(cmbDanhMuc1, cmbDanhMuc.SelectedValue.ToString());
            ComboBoxUtil.SetDanhSachTraiGiam(_dbContext, cmbTraiGiam, this._user);

            _phanLoaiQuanCheList = (List<ListItemEx>)cmbPhanLoaiQuanChe.DataSource;
            _danhMucHoatDongList = (List<ListItemEx>)cmbDanhMuc.DataSource;
            _phamViHoatDongList = (List<ListItemEx>)cmbPhamViHoatDong.DataSource;
            _bienPhapNghiepVuList = (List<ListItemEx>)cmbBienPhapNghiepVu.DataSource;
            _bienPhapPhapLuatList = (List<ListItemEx>)cmbBienPhapPhapLuat.DataSource;
            _ngoaiNguList = (List<ListItemEx>)cmbNgoaiNgu.DataSource;
            _dantocList = (List<ListItemEx>)cmbDantoc.DataSource;
            _tongiaoList = (List<ListItemEx>)cmbTonGiao.DataSource;
            _trinhdoHocVanList = (List<ListItemEx>)cmbTrinhDoHocVan.DataSource;
            _quocTichList = (List<ListItemEx>)cmbQuocTich.DataSource;
            _toiDanhList = (List<ListItemEx>)cmbToiDanh.DataSource;
            _buongGiamList = (List<ListItem>)cmbBuongGiam.DataSource;
            _phanKhuList = (List<ListItem>)cmbPhanKhu.DataSource;
            _danhMuc1List = (List<ListItem>)cmbDanhMuc1.DataSource;
            _traiGiamList = (List<ListItemEx>)cmbTraiGiam.DataSource;


            ClearScreen();

            if (_isUpdateMode)
            {
                btnUpdate.Text = Resources.CM_BTN_UPDATE;
                txtMaPN.Enabled = false;
            }
            else
            {
                btnUpdate.Text = Resources.CM_BTN_ADD;
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

        private bool IsValidate(prison_mst prisoner)
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(prisoner.ma_dang_ky))
            {
                isValid = false;
                MessageBox.Show(String.Format(Resources.CM_MSG_REQUIRED, Resources.ITEM_PRISON_ID), CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (String.IsNullOrEmpty(prisoner.ho_va_ten))
            {
                isValid = false;
                MessageBox.Show(String.Format(Resources.CM_MSG_REQUIRED, Resources.ITEM_PRISON_NAME), CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (String.IsNullOrEmpty(prisoner.toi_danh))
            {
                isValid = false;
                MessageBox.Show(String.Format(Resources.CM_MSG_REQUIRED, Resources.ITEM_PRISON_TOI_DANH), CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (prisoner.ngay_bat.Value > prisoner.ngay_nhap_trai.Value)
            {
                isValid = false;
                MessageBox.Show(Resources.PRISON_MSG_001, CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (prisoner.ngay_nhap_trai.Value > prisoner.ngay_dua_vao_dien_quan_che.Value)
            {
                isValid = false;
                MessageBox.Show(Resources.PRISON_MSG_002, CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (!_isUpdateMode && _prisonRepository.IsExist(prisoner.ma_dang_ky))
            {
                isValid = false;
                MessageBox.Show(String.Format(Resources.CM_MSG_DUPLICATE, Resources.ITEM_PRISON_ID_UPPER), CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return isValid;
            }

            if (prisoner.ngay_dua_ra != null)
            {
                if (String.IsNullOrEmpty(prisoner.ly_do_dua_ra))
                {
                    isValid = false;
                    MessageBox.Show(String.Format(Resources.CM_MSG_REQUIRED, Resources.ITEM_PRISON_RESOND_OUT), CommonConst.MessageCommon.MESSAGE_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return isValid;
                }
            }

            return isValid;
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
            cmbPhanKhu.SelectedIndex = rand.Next(0, 10);
            txtAnphat.Text = rand.Next(1, 30).ToString() + " năm tù";
            txtChapHanhAnTai.Text = "Đội " + rand.Next(10, 20).ToString();
            cmbPhamViHoatDong.SelectedIndex = rand.Next(0, 2);
            txtBieuHienHoatDong.Text = "AAAAAAAAAA" + rand.Next(100, 200);
            cmbBienPhapPhapLuat.SelectedIndex = rand.Next(0, 2);
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
        #endregion
    }
}
