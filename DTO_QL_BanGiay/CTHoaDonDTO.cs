using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class CTHoaDonDTO
    {
        // Thuộc tính Khóa Ngoại
        public long MaHD { get; set; }        // BIGINT
        public long MaGiay { get; set; }      // BIGINT

        // Thuộc tính Dữ liệu
        public int SoLuong { get; set; }       // INT
        public decimal GiaBan { get; set; }    // DECIMAL(18, 2)

        // *Tùy chọn: Thêm các thuộc tính hiển thị (Ví dụ: TenGiay) nếu cần cho UI*
        public string TenGiay { get; set; }
        public string MaAnh { get; set; }

        // Constructor mặc định
        public CTHoaDonDTO()
        {
        }
        public CTHoaDonDTO(long maHD, long maGiay, int soLuong, decimal giaBan)
        {
            MaHD = maHD;
            MaGiay = maGiay;
            SoLuong = soLuong;
            GiaBan = giaBan;
        }
        // Constructor đầy đủ tham số
        public CTHoaDonDTO(long maHd, long maGiay, int soLuong, decimal giaBan, string tenGiay, string maAnh)
        {
            MaHD = maHd;
            MaGiay = maGiay;
            SoLuong = soLuong;
            GiaBan = giaBan;
            TenGiay = tenGiay;
            MaAnh = maAnh;
        }
    }
}
