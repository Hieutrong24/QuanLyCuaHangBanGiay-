using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class BaoCaoSoLuongGiayDTO
    {
        public DateTime Ngay { get; set; }
        public long MaGiay { get; set; }
        public string TenGiay { get; set; }
        public int TongSoLuongBan { get; set; }
        public decimal DonGia { get; set; }
    }
}
