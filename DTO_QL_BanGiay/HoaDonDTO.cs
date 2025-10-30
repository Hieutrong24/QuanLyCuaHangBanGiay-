using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class HoaDonDTO
    {

        // Thuộc tính chính
        public long MaHD { get; set; } // BIGINT PRIMARY KEY
        public long MaKH { get; set; } // BIGINT (Mã Khách Hàng)
        public string TenNV { get; set; }
        public long MaNV { get; set; } // BIGINT FOREIGN KEY (Mã Nhân Viên Bán)
        public DateTime NgayBan { get; set; } // DATE
        public decimal TongTien { get; set; } // DECIMAL(18, 2)
        public decimal Thue { get; set; } // DECIMAL(5, 2)
        public long MaKM { get; set; } // BIGINT FOREIGN KEY (Mã Khuyến Mãi)

        // Constructor mặc định (Không có tham số)
        public HoaDonDTO()
        {
        }

        // Constructor đầy đủ tham số (Tương tự như SanPhamDTO)
        public HoaDonDTO(long maHd, long maKh, long maNv, DateTime ngayBan, decimal tongTien, decimal thue, long maKm)
        {
            MaHD = maHd;
            MaKH = maKh;
            MaNV = maNv;
            NgayBan = ngayBan;
            TongTien = tongTien;
            Thue = thue;
            MaKM = maKm;
        }
    }
}
