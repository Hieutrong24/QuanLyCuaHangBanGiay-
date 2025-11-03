using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class KhachHangThanThietDTO
    {
        // Thuộc tính
        public long MaKH { get; set; }        // BIGINT PRIMARY KEY
        public DateTime NgayThamGia { get; set; } // DATE
        public int TongDiem { get; set; }     // INT
        public string HangThanhVien { get; set; } // NVARCHAR(50)
        public DateTime NgayCapNhat { get; set; } // DATE
        public int TrangThai { get; set; }   // BIT (1=hoạt động, 0=ngưng)

        // Constructor mặc định
        public KhachHangThanThietDTO()
        {
        }
        public KhachHangThanThietDTO(int maKH, int tongDiem, DateTime ngayCapNhat)
        {
            MaKH = maKH;
            TongDiem = tongDiem;
            NgayCapNhat = ngayCapNhat;
        }
        // Constructor đầy đủ tham số
        public KhachHangThanThietDTO(long maKh, DateTime ngayThamGia, int tongDiem, string hangThanhVien, DateTime ngayCapNhat, int trangThai)
        {
            MaKH = maKh;
            NgayThamGia = ngayThamGia;
            TongDiem = tongDiem;
            HangThanhVien = hangThanhVien;
            NgayCapNhat = ngayCapNhat;
            TrangThai = trangThai;
        }
    }
}
