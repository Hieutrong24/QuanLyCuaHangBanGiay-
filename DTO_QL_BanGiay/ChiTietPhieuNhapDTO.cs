using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class ChiTietPhieuNhapDTO
    {
        public long MaPN { get; set; }
        public long MaGiay { get; set; }
        public string TenGiay { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal ThanhTien { get; set; }
    }

}
