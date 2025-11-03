using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class LuongNhanVienDTO
    {
        public long Id { get; set; }
        public long MaNV { get; set; }
        public string HoTen { get; set; }
        public string Role { get; set; }

        public string Thang { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal PhuCap { get; set; }
        public decimal Thuong { get; set; }
        public decimal TongLuong { get; set; }
        public DateTime NgayTinh { get; set; }
        public string GhiChu { get; set; }

    }
}
