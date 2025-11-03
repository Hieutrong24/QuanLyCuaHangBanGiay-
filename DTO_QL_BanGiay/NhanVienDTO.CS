using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class NhanVienDTO
    {
        public long MaTK { get; set; }           // Mã tài khoản (hoặc mã nhân viên)
        public string HoTen { get; set; }        // Họ tên nhân viên
        public string GioiTinh { get; set; }     // Giới tính
        public DateTime? NgaySinh { get; set; }   // Ngày sinh
        public string DienThoai { get; set; }    // Số điện thoại
        public string Email { get; set; }        // Địa chỉ email
        public string DiaChi { get; set; }       // Địa chỉ cư trú
        public string MatKhau { get; set; }      // Mật khẩu (cần mã hoá khi lưu)
        public string Role { get; set; }         // Quyền (Admin, Nhân viên, ...)
        public DateTime NgayTao { get; set; }    // Ngày tạo tài khoản
        public bool TrangThai { get; set; }    // Trạng thái (Hoạt động / Khóa / Đã nghỉ, ...)
        public string GhiChu { get; set; }
        public string ImagePath { get; set; }    // Đường dẫn ảnh đại diện
        public byte[] QRCode { get; set; }      // Mã QR code (nếu có)
    }
}