using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class SanPhamDTO
    {
        public long MaGiay { get; set; }
        public string TenGiay { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public string Size { get; set; }
        public string DoiTuongSD { get; set; }   
        public string ChatLieu { get; set; }
        public long MaLoai { get; set; }
        public long MaXX { get; set; }
        public long MaMau { get; set; }
        public long MaThuongHieu { get; set; }
        public string TrangThai { get; set; }
        public string HinhAnh { get; set; }
        public SanPhamDTO() { }

        public SanPhamDTO(long maGiay, string tenGiay, int soLuong, decimal donGia, string size,
                       string doiTuongSD, string chatLieu, long maLoai, long maXX,
                       long maMau, long maThuongHieu, string trangThai, string hinhAnh)
        {
            MaGiay = maGiay;
            TenGiay = tenGiay;
            SoLuong = soLuong;
            DonGia = donGia;
            Size = size;
            DoiTuongSD = doiTuongSD;
            ChatLieu = chatLieu;
            MaLoai = maLoai;
            MaXX = maXX;
            MaMau = maMau;
            MaThuongHieu = maThuongHieu;
            TrangThai = trangThai;
            HinhAnh = hinhAnh;
        }
    }
}
