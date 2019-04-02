using CommonLib;
using DAL;
using QLPN.Properties;
using System;
using System.Resources;
using System.Threading;

namespace QLPN.App_Code
{
    public static class Util
    {
        public static string PRIVATE_KEY = GetResource("key");
        public static prison_mst CreateNewPrison(prison_mst obj)
        {
            prison_mst ret = new prison_mst();

            ret.ma_dang_ky = obj.ma_dang_ky;
            ret.ma_trai_giam = obj.ma_trai_giam;
            ret.ngay_thang_nam_sinh = obj.ngay_thang_nam_sinh;
            ret.ho_va_ten = obj.ho_va_ten;
            ret.ten_goi_khac = obj.ten_goi_khac;
            ret.gioi_tinh = obj.gioi_tinh;
            ret.que_quan = obj.que_quan;
            ret.noi_dktt = obj.noi_dktt;
            ret.toi_danh = obj.toi_danh;
            ret.ngay_bat = obj.ngay_bat;
            ret.an_phat = obj.an_phat;
            ret.ngay_nhap_trai = obj.ngay_nhap_trai;
            ret.phan_loai_quan_che = obj.phan_loai_quan_che;
            ret.ngay_dua_vao_dien_quan_che = obj.ngay_dua_vao_dien_quan_che;
            ret.doi_hien_tai = obj.doi_hien_tai;
            ret.buong_so = obj.buong_so;
            ret.phan_trai = obj.phan_trai;
            ret.danh_muc = obj.danh_muc;
            ret.danh_muc_1 = obj.danh_muc_1;
            ret.pham_vi_hoat_dong = obj.pham_vi_hoat_dong;
            ret.bieu_hien_hoat_dong_hien_hanh = obj.bieu_hien_hoat_dong_hien_hanh;
            ret.bien_phap_nghiep_vu = obj.bien_phap_nghiep_vu;
            ret.bien_phap_ky_luat = obj.bien_phap_ky_luat;
            ret.ngay_dua_ra = obj.ngay_dua_ra;
            ret.ly_do_dua_ra = obj.ly_do_dua_ra;
            ret.ton_giao = obj.ton_giao;
            ret.dan_toc = obj.dan_toc;
            ret.quoc_tich = obj.quoc_tich;
            ret.trinh_do_hoc_van = obj.trinh_do_hoc_van;
            ret.ngoai_ngu = obj.ngoai_ngu;
            ret.ten_cha = obj.ten_cha;
            ret.ten_me = obj.ten_me;
            ret.ten_vo_chong = obj.ten_vo_chong;
            ret.tien_an = obj.tien_an;
            ret.tien_su = obj.tien_su;

            ret.ngay_tao = obj.ngay_tao;
            ret.nguoi_tao = obj.nguoi_tao;
            ret.ngay_cap_nhat = obj.ngay_cap_nhat;
            ret.nguoi_cap_nhat = obj.nguoi_cap_nhat;

            return ret;
        }

        public static prison_mst UpdatePrison(prison_mst fromObj, prison_mst toObj)
        {
            toObj.ma_trai_giam = fromObj.ma_trai_giam;
            toObj.ngay_thang_nam_sinh = fromObj.ngay_thang_nam_sinh;
            toObj.ho_va_ten = fromObj.ho_va_ten;
            toObj.ten_goi_khac = fromObj.ten_goi_khac;
            toObj.gioi_tinh = fromObj.gioi_tinh;
            toObj.que_quan = fromObj.que_quan;
            toObj.noi_dktt = fromObj.noi_dktt;
            toObj.toi_danh = fromObj.toi_danh;
            toObj.ngay_bat = fromObj.ngay_bat;
            toObj.an_phat = fromObj.an_phat;
            toObj.ngay_nhap_trai = fromObj.ngay_nhap_trai;
            toObj.phan_loai_quan_che = fromObj.phan_loai_quan_che;
            toObj.ngay_dua_vao_dien_quan_che = fromObj.ngay_dua_vao_dien_quan_che;
            toObj.doi_hien_tai = fromObj.doi_hien_tai;
            toObj.buong_so = fromObj.buong_so;
            toObj.phan_trai = fromObj.phan_trai;
            toObj.danh_muc = fromObj.danh_muc;
            toObj.danh_muc_1 = fromObj.danh_muc_1;
            toObj.pham_vi_hoat_dong = fromObj.pham_vi_hoat_dong;
            toObj.bieu_hien_hoat_dong_hien_hanh = fromObj.bieu_hien_hoat_dong_hien_hanh;
            toObj.bien_phap_nghiep_vu = fromObj.bien_phap_nghiep_vu;
            toObj.bien_phap_ky_luat = fromObj.bien_phap_ky_luat;
            toObj.ngay_dua_ra = fromObj.ngay_dua_ra;
            toObj.ly_do_dua_ra = fromObj.ly_do_dua_ra;
            toObj.ton_giao = fromObj.ton_giao;
            toObj.dan_toc = fromObj.dan_toc;
            toObj.quoc_tich = fromObj.quoc_tich;
            toObj.trinh_do_hoc_van = fromObj.trinh_do_hoc_van;
            toObj.ngoai_ngu = fromObj.ngoai_ngu;
            toObj.ten_cha = fromObj.ten_cha;
            toObj.ten_me = fromObj.ten_me;
            toObj.ten_vo_chong = fromObj.ten_vo_chong;
            toObj.tien_an = fromObj.tien_an;
            toObj.tien_su = fromObj.tien_su;

            toObj.ngay_tao = fromObj.ngay_tao;
            toObj.nguoi_tao = fromObj.nguoi_tao;
            toObj.ngay_cap_nhat = fromObj.ngay_cap_nhat;
            toObj.nguoi_cap_nhat = fromObj.nguoi_cap_nhat;

            return toObj;
        }

        /// <summary>
        /// Get resource from resource file.
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public static string GetResource(string resourceId)
        {
            string retString = String.Empty;
            try
            {
                if (String.IsNullOrEmpty(resourceId)) return retString;

                var resourceManager = new ResourceManager("QLPN.Properties.Resources", typeof(Resources).Assembly);
                object obj = resourceManager.GetObject(resourceId, Thread.CurrentThread.CurrentCulture);

                return obj != null ? obj.ToString() : retString;
            }
            catch (Exception)
            {
                return retString;
            }
        }

        /// <summary>
        /// Get resource from resource file.
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public static string GetResource(string resourceId, params object[] args)
        {
            string retString = string.Empty;

            try
            {
                if (String.IsNullOrEmpty(resourceId)) return retString;

                var resourceManager = new ResourceManager("QLPN.Properties.Resources", typeof(Resources).Assembly);
                object obj = resourceManager.GetObject(resourceId, Thread.CurrentThread.CurrentCulture);

                return obj != null ? String.Format(obj.ToString(), args) : retString;
            }
            catch (Exception)
            {
                return retString;
            }
        }
    }
}
