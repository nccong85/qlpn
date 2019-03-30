using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPN.DTO
{
    public class SearchDto
    {
        public string MaDangKy { get; set; }
        public string TenPhamNhan { get; set; }
        public Nullable<System.DateTime> NgayThangNamSinh { get; set; }
        public Nullable<System.DateTime> NgayNhapTrai { get; set; }
        public string MaTraiGiam { get; set; }
    }
}
