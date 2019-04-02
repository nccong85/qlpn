using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class PrisonDisplayDto
    {
        public int id { get; set; }
        public string ma_dang_ky { get; set; }
        public string ma_trai_giam { get; set; }
        public Nullable<System.DateTime> ngay_thang_nam_sinh { get; set; }
        public string ho_va_ten { get; set; }
        public string ten_goi_khac { get; set; }
        public string gioi_tinh { get; set; }
        public string que_quan { get; set; }
        public string noi_dktt { get; set; }
        public string toi_danh { get; set; }
        public Nullable<System.DateTime> ngay_bat { get; set; }
        public string an_phat { get; set; }
        public Nullable<System.DateTime> ngay_nhap_trai { get; set; }
        public Nullable<System.DateTime> ngay_dua_ra { get; set; }
        public string ly_do_dua_ra { get; set; }
    }
}
