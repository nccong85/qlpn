using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public static class CommonConst
    {
        public class CodeMasterCategoryId
        {
            public const string PHAN_LOAI_GIOI_TINH = "00";

            public const string PHAN_LOAI_QUAN_CHE = "01";

            public const string PHAN_LOAI_DANH_MUC = "02";

            public const string PHAN_LOAI_PHAM_VI_HOAT_DONG = "03";

            public const string PHAN_LOAI_BIEN_PHAP_KI_LUAT = "04";

            public const string PHAN_LOAI_BIEN_PHAP_NGHIEP_VU = "05";

            public const string PHAN_LOAI_DAN_TOC = "06";

            public const string PHAN_LOAI_TON_GIAO = "07";

            public const string PHAN_LOAI_HOC_VAN = "08";

            public const string PHAN_LOAI_NGON_NGU = "09";

            public const string PHAN_LOAI_QUOC_TICH = "10";

            public const string PHAN_LOAI_TOI_DANH = "11";

            public const string PHAN_LOAI_BUONG_GIAM = "12";

            public const string PHAN_LOAI_PHAN_KHU = "13";
        }

        public class UserRole
        {
            public const string ADMIN = "1";

            public const string NORMAL_USER = "2";
        }

        public class UserStatus
        {
            public const string ENABLE = "1";

            public const string DISABLE = "0";
        }

        public const string GIOI_TINH_NAM = "01";

        public const string GIOI_TINH_NU = "02";

        public const string BLANK = "";

        public class MessageCommon
        {
            public const string MESSAGE_CAPTION_ERROR = "Lỗi";

            public const string MESSAGE_CAPTION_WARNING = "Cảnh báo";

            public const string MESSAGE_CAPTION_INFOR = "Thông báo";
        }

        public class FormatDateTime
        {
            public const string DATE_YYYYMMDD = "yyyy/MM/dd";
            public const string DATE_DDMMYYYY = "dd/MM/yyyy";
            public const string TIME_HHMMSS = "{0:HH:mm:ss}";
            public const string TIME_HHMM = "{0:HH:mm}";
            public const string DATE_MMDDYYYY = "MM/dd/yyyy";
            public const string DATE_FULL = "yyyy/MM/dd HH:mm";
            public const string DATE_FORMAT_DATETIME2 = "{0:yyyy/MM/dd HH:mm:ss.fffffff}";
            public const string DATE_FORMAT_MMDD = "{0:MM/dd}";
            public const string DATE_FORMAT_YYYYMMDD = "{0:yyyy/MM/dd}";
            public const string DATE_FORMAT_YYYYMMDD_HHMMSS = "{0:yyyy/MM/dd HH:mm:ss}";
            public const string DATE_FORMAT_YYYYMMDD_HHMM = "{0:yyyy/MM/dd HH:mm}";
            public const string DATE_FORMAT_YYYYMM = "{0:yyyy/MM}";
            public const string MD_JP = "M月d日";
            public const string YM_JP = "yyyy年MM月";
            public const string YYYYMMDDHHMMSS = "yyyyMMddHHmmss";
            public const string YYYY_MM_DD_HH_MM_SS = "yyyy/MM/dd HH:mm:ss";
            public const string YYYYMMDD = "yyyyMMdd";
            public const string YYYYMM = "yyyyMM";
            public const string YYMMDD = "yyMMdd";
            public const string YYMM = "yyMM";
            public const string YEAR_MONTH = "yyyy/MM";
            public const string DATE_FORMAT_YYYYMM_2 = "{0:yyyyMM}";
            public const string DATE_FORMAT_YYYYMMDD_2 = "{0:yyyyMMdd}";
            public const string YYYY_MM_DD = "yyyy-mm-dd";
            public const string DATE_DATETIME2 = "yyyy/MM/dd HH:mm:ss.fffffff";
            public const string HH_MM = "HHmm";
        }
    }
}
