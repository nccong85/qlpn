using Business.Repository;
using CommonLib;
using CommonLib.Model.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLPN.App_Code
{
    public static class ComboBoxUtil
    {
        public const string DEFAULT_ITEM = "----Hãy lựa chọn ----";
        public const string VIETNAM_TEXT = "250:Viet Nam";

        public static void SetDanhSachPhanLoaiQuanChe(Entities dbcontext, ComboBox cmb)
        {
            List<ListItemEx> list = GetCodeListExByCategoryId(dbcontext, CommonConst.CodeMasterCategoryId.PHAN_LOAI_QUAN_CHE);
            SettingComboBox(cmb, list);
            cmb.SelectedItem = null;
            cmb.SelectedText = DEFAULT_ITEM;
        }

        public static void SetDanhSachDanhMuc(Entities dbcontext, ComboBox cmb)
        {
            List<ListItemEx> list = GetCodeListExByCategoryId(dbcontext, CommonConst.CodeMasterCategoryId.PHAN_LOAI_DANH_MUC);
            SettingComboBox(cmb, list);
        }

        public static void SetDanhSachPhamViHoatDong(Entities dbcontext, ComboBox cmb)
        {
            List<ListItemEx> list = GetCodeListExByCategoryId(dbcontext, CommonConst.CodeMasterCategoryId.PHAN_LOAI_PHAM_VI_HOAT_DONG);
            SettingComboBox(cmb, list);
            cmb.SelectedItem = null;
            cmb.SelectedText = DEFAULT_ITEM;
        }

        public static void SetDanhSachBienPhapPhapLuat(Entities dbcontext, ComboBox cmb)
        {
            List<ListItemEx> list = GetCodeListExByCategoryId(dbcontext, CommonConst.CodeMasterCategoryId.PHAN_LOAI_BIEN_PHAP_PHAP_LUAT);
            SettingComboBox(cmb, list);
            cmb.SelectedItem = null;
            cmb.SelectedText = DEFAULT_ITEM;
        }

        public static void SetDanhSachBienPhapNghiepVu(Entities dbcontext, ComboBox cmb)
        {
            List<ListItemEx> list = GetCodeListExByCategoryId(dbcontext, CommonConst.CodeMasterCategoryId.PHAN_LOAI_BIEN_PHAP_NGHIEP_VU);
            SettingComboBox(cmb, list);
        }

        public static void SetDanhSachDantoc(Entities dbcontext, ComboBox cmb)
        {
            List<ListItemEx> list = GetCodeListExByCategoryId(dbcontext, CommonConst.CodeMasterCategoryId.PHAN_LOAI_DAN_TOC);
            SettingComboBox(cmb, list);
        }

        public static void SetDanhSachTongiao(Entities dbcontext, ComboBox cmb)
        {

            List<ListItemEx> list = GetCodeListExByCategoryId(dbcontext, CommonConst.CodeMasterCategoryId.PHAN_LOAI_TON_GIAO);
            SettingComboBox(cmb, list);
            cmb.SelectedIndex = 7;
        }

        public static void SetDanhSachHocVan(Entities dbcontext, ComboBox cmb)
        {
            List<ListItemEx> list = GetCodeListExByCategoryId(dbcontext, CommonConst.CodeMasterCategoryId.PHAN_LOAI_HOC_VAN);
            SettingComboBox(cmb, list);
            cmb.SelectedItem = null;
            cmb.SelectedText = DEFAULT_ITEM;
        }

        public static void SetDanhSachNgonNgu(Entities dbcontext, ComboBox cmb)
        {
            List<ListItemEx> list = GetCodeListExByCategoryId(dbcontext, CommonConst.CodeMasterCategoryId.PHAN_LOAI_NGON_NGU);
            SettingComboBox(cmb, list);
            cmb.SelectedItem = null;
            cmb.SelectedText = DEFAULT_ITEM;
        }

        public static void SetDanhSachQuocTich(Entities dbcontext, ComboBox cmb)
        {
            List<ListItemEx> list = GetCodeListExByCategoryId(dbcontext, CommonConst.CodeMasterCategoryId.PHAN_LOAI_QUOC_TICH);
            SettingComboBox(cmb, list);
            cmb.SelectedIndex = cmb.FindStringExact(VIETNAM_TEXT);
        }

        public static void SetDanhSachToiDanh(Entities dbcontext, ComboBox cmb)
        {
            List<ListItemEx> list = GetCodeListExByCategoryId(dbcontext, CommonConst.CodeMasterCategoryId.PHAN_LOAI_TOI_DANH);
            SettingComboBox(cmb, list);
            cmb.SelectedItem = null;
            cmb.SelectedText = DEFAULT_ITEM;
        }

        public static void SetDanhSachBuongGiam(Entities dbcontext, ComboBox cmb)
        {
            List<ListItem> list = GetCodeListByCategoryId(dbcontext, CommonConst.CodeMasterCategoryId.PHAN_LOAI_BUONG_GIAM);
            SettingComboBox(cmb, list);
            cmb.SelectedItem = null;
            cmb.SelectedText = DEFAULT_ITEM;
        }

        public static void SetDanhSachPhanKhu(Entities dbcontext, ComboBox cmb)
        {
            List<ListItem> list = GetCodeListByCategoryId(dbcontext, CommonConst.CodeMasterCategoryId.PHAN_LOAI_PHAN_KHU);
            SettingComboBox(cmb, list);
            cmb.SelectedItem = null;
            cmb.SelectedText = DEFAULT_ITEM;
        }

        public static void SetDanhSachDanhMuc1(ComboBox cmb, string phanLoaiDanhmuc)
        {
            cmb.Items.Clear();

            cmb.Items.Add(new ListItem("a", "a"));
            cmb.Items.Add(new ListItem("b", "b"));
            cmb.Items.Add(new ListItem("c", "c"));
            cmb.Items.Add(new ListItem("d", "d"));
            cmb.Items.Add(new ListItem("đ", "đ"));
            cmb.Items.Add(new ListItem("e", "e"));
            cmb.Items.Add(new ListItem("g", "g"));

            cmb.ValueMember = "Value";
            cmb.DisplayMember = "Text";
        }
        
        public static void SetDanhSachTraiGiam(Entities dbContext, ComboBox cmb, user_mst user)
        {
            List<ListItemEx> divisionList = GetDivisonList(dbContext, user);
            cmb.DataSource = divisionList;
            cmb.ValueMember = "Value";
            cmb.DisplayMember = "Text";
        }

        public static void SetAutoFilter(ComboBox cmb, List<ListItemEx> dataSource)
        {
            string filter_param = cmb.Text;

            List<ListItemEx> filteredItems = dataSource.FindAll(x => x.ToLower().Contains(filter_param.ToLower()));

            cmb.DataSource = filteredItems;

            if (String.IsNullOrWhiteSpace(filter_param))
            {
                cmb.DataSource = dataSource;
            }
            cmb.DroppedDown = true;

            // this will ensure that the drop down is as long as the list
            cmb.IntegralHeight = true;

            // remove automatically selected first item
            cmb.SelectedIndex = -1;

            cmb.Text = filter_param;

            // set the position of the cursor
            cmb.SelectionStart = filter_param.Length;
            cmb.SelectionLength = 0;
        }

        public static void SetAutoFilter(ComboBox cmb, List<ListItem> dataSource)
        {
            string filter_param = cmb.Text;

            List<ListItem> filteredItems = dataSource.FindAll(x => x.ToLower().Contains(filter_param.ToLower()));

            cmb.DataSource = filteredItems;

            if (String.IsNullOrWhiteSpace(filter_param))
            {
                cmb.DataSource = dataSource;
            }
            cmb.DroppedDown = true;

            // this will ensure that the drop down is as long as the list
            cmb.IntegralHeight = true;

            // remove automatically selected first item
            cmb.SelectedIndex = -1;

            cmb.Text = filter_param;

            // set the position of the cursor
            cmb.SelectionStart = filter_param.Length;
            cmb.SelectionLength = 0;
        }

        private static List<ListItemEx> GetCodeListExByCategoryId(Entities dbcontext, string categoryId)
        {
            CodeMasterRepository codeMasterRepository = new CodeMasterRepository(dbcontext);
            return codeMasterRepository.GetListItemExByCategoryId(categoryId);
        }

        private static List<ListItem> GetCodeListByCategoryId(Entities dbcontext, string categoryId)
        {
            CodeMasterRepository codeMasterRepository = new CodeMasterRepository(dbcontext);
            return codeMasterRepository.GetListItemByCategoryId(categoryId);
        }

        private static List<ListItemEx> GetDivisonList(Entities dbcontext,user_mst user)
        {
            DivisionMasterRepositoty divisionMasterRepositoty = new DivisionMasterRepositoty(dbcontext);
            return divisionMasterRepositoty.GetListWithCode(user);
        }

        private static void SettingComboBox<T>(ComboBox cmb , List<T>list)
        {
            cmb.DataSource = list;
            cmb.ValueMember = "Value";
            cmb.DisplayMember = "Text";
        }
    }
}
