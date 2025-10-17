using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class PhieuNhapDTO
    {
        public long MaPN { get; set; }
        public long MaNCC { get; set; }
        public long MaNV { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
    }
}
