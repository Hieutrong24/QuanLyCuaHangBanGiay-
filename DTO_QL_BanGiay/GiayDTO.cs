using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DTO_QL_BanGiay
{
    public class GiayDTO
    {
        public long IdGiay { get; set; }
        public string TenGiay { get; set; }
        public decimal DonGia { get; set; } // Giá gốc
        public string TonKho { get; set; }
        public string TenMau { get; set; }

        // Đã đổi từ Image sang string (Mã ảnh/Tên file)
        public string Images { get; set; }


        // --- Thông tin Khuyến Mãi ---
        public decimal PhanTramGiam { get; set; }
        public decimal GiaSauUuDai { get; set; }
        public int Size { get; set; }
        public int SoLuong { get; set; }
        public string DoiTuongSD { get; set; }
        public long MaLoai { get; set; }
        public string ChatLieu { get; set; }
        public string Anh { get; set; }
    }
}
