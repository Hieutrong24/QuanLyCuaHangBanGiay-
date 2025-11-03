using DTO_QL_BanGiay;
using DAL_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS_QL_BanGiay
{
    public class LoaiBUS
    {
        private readonly LoaiDAL loaiDAL = new LoaiDAL();

        // 📋 Lấy toàn bộ danh sách loại
        public static List<LoaiDTO> LayTatCaLoai()
        {
            LoaiDAL loaiDAL = new LoaiDAL();
            return loaiDAL.LayDanhSachLoai();
        }

        public List<LoaiDTO> LayDanhSachLoai()
        {
            return loaiDAL.LayDanhSachLoai();
        }

        // 🔍 Tìm kiếm và truy xuất loại giày
        public LoaiDTO LayLoaiTheoMa(long maLoai)
        {
            return loaiDAL.LayDanhSachLoai().FirstOrDefault(l => l.MaLoai == maLoai);
        }

        public LoaiDTO LayLoaiTheoTen(string tenLoai)
        {
            return loaiDAL.LayDanhSachLoai().FirstOrDefault(l => l.TenLoai.Equals(tenLoai, StringComparison.OrdinalIgnoreCase));
        }

        public List<LoaiDTO> TimKiemLoai(string keyword)
        {
            return loaiDAL.LayDanhSachLoai()
                .Where(l => l.TenLoai.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        public List<LoaiDTO> TimKiemLoaiTheoMa(long maLoai)
        {
            return loaiDAL.LayDanhSachLoai()
                .Where(l => l.MaLoai == maLoai)
                .ToList();
        }

        public List<LoaiDTO> TimKiemLoaiTheoTen(string tenLoai)
        {
            return loaiDAL.LayDanhSachLoai()
                .Where(l => l.TenLoai.Equals(tenLoai, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public LoaiDTO TimKiemLoaiTheoMaVaTen(long maLoai, string tenLoai)
        {
            return loaiDAL.LayDanhSachLoai()
                .FirstOrDefault(l => l.MaLoai == maLoai && l.TenLoai.Equals(tenLoai, StringComparison.OrdinalIgnoreCase));
        }

        public List<LoaiDTO> TimKiemLoaiTheoMaHoacTen(long maLoai, string tenLoai)
        {
            return loaiDAL.LayDanhSachLoai()
                .Where(l => l.MaLoai == maLoai || l.TenLoai.Equals(tenLoai, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<LoaiDTO> TimKiemLoaiTuKhoa(string keyword)
        {
            return loaiDAL.LayDanhSachLoai()
                .Where(l => l.TenLoai.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                         || l.MaLoai.ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        // 🟩 THÊM LOẠI MỚI

        public bool SuaLoai(long maLoai, string tenMoi)
        {
            if (string.IsNullOrWhiteSpace(tenMoi))
                throw new Exception("Tên loại không được để trống!");

            // Kiểm tra loại tồn tại trước khi sửa
            var loai = loaiDAL.LayDanhSachLoai().FirstOrDefault(l => l.MaLoai == maLoai);
            if (loai == null)
                throw new Exception("Không tìm thấy loại cần sửa!");

            return loaiDAL.UpdateLoai(maLoai, tenMoi);
        }
        public bool ThemLoai(string tenLoai)
        {
            if (string.IsNullOrWhiteSpace(tenLoai))
                throw new Exception("Tên loại không được để trống!");

            // Lấy danh sách loại hiện có
            List<LoaiDTO> dsLoai = loaiDAL.LayDanhSachLoai();

            // Sinh mã mới: nếu danh sách trống thì = 1, ngược lại = max + 1
            long maMoi = dsLoai.Count > 0 ? dsLoai.Max(l => l.MaLoai) + 1 : 1;

            LoaiDTO loaiMoi = new LoaiDTO
            {
                MaLoai = maMoi,
                TenLoai = tenLoai
            };

            return loaiDAL.InsertLoai(loaiMoi);
        }
        // 🟥 XÓA LOẠI
        public bool XoaLoai(long maLoai)
        {
            // Kiểm tra loại có tồn tại
            var loai = loaiDAL.LayDanhSachLoai().FirstOrDefault(l => l.MaLoai == maLoai);
            if (loai == null)
                throw new Exception("Không tìm thấy loại cần xóa!");

            // Kiểm tra xem có giày nào đang thuộc loại này không
            GiayDAL giayDAL = new GiayDAL();
            var dsGiay = giayDAL.LayDanhSachGiay(); // Giả sử bạn có hàm này
            bool coGiayThuocLoai = dsGiay.Any(g => g.MaLoai == maLoai);

            if (coGiayThuocLoai)
                throw new Exception("Không thể xóa! Vẫn còn giày thuộc loại này.");

            // Nếu không có giày nào dùng loại này thì mới xóa
            return loaiDAL.DeleteLoai(maLoai);
        }
    }
}
