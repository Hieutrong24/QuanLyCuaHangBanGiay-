using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class KhachHangDTO
    {
        public long MaKH { get; set; }
        public DateTime NgayThamGia { get; set; }
        public int TongDiem { get; set; }
        public string HangThanhVien { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string TrangThai { get; set; }
        public string SDT { get; set; }
    }

}
