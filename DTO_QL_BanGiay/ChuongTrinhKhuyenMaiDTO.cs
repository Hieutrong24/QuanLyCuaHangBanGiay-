using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class ChuongTrinhKhuyenMaiDTO
    {
        public long MaCTKM { get; set; }
        public string TenCTKM { get; set; }
        public string LoaiCTKM { get; set; }
        public string DieuKien { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public decimal MucGiamGia { get; set; }
    }
}
