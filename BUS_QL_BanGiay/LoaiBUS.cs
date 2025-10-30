using DTO_QL_BanGiay;
using DAL_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class LoaiBUS
    {
        private LoaiDAL loaiDAL = new LoaiDAL();
        public static List<LoaiDTO> LayTatCaLoai()
        {
            LoaiDAL loaiDAL = new LoaiDAL();
            return loaiDAL.LayDanhSachLoai();
        }
        public List<LoaiDTO> LayDanhSachLoai()
        {
            return loaiDAL.LayDanhSachLoai();
        }
        public LoaiDTO LayLoaiTheoMa(long maLoai)
        {
            List<LoaiDTO> dsLoai = loaiDAL.LayDanhSachLoai();
            return dsLoai.FirstOrDefault(l => l.MaLoai == maLoai);
        }
        public LoaiDTO LayLoaiTheoTen(string tenLoai)
        {
            List<LoaiDTO> dsLoai = loaiDAL.LayDanhSachLoai();
            return dsLoai.FirstOrDefault(l => l.TenLoai.Equals(tenLoai, StringComparison.OrdinalIgnoreCase));
        }
        public List<LoaiDTO> TimKiemLoai(string keyword)
        {
            List<LoaiDTO> dsLoai = loaiDAL.LayDanhSachLoai();
            return dsLoai.Where(l => l.TenLoai.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public List<LoaiDTO> TimKiemLoaiTheoMa(long maLoai)
        {
            List<LoaiDTO> dsLoai = loaiDAL.LayDanhSachLoai();
            return dsLoai.Where(l => l.MaLoai == maLoai).ToList();
        }
        public List<LoaiDTO> TimKiemLoaiTheoTen(string tenLoai)
        {
            List<LoaiDTO> dsLoai = loaiDAL.LayDanhSachLoai();
            return dsLoai.Where(l => l.TenLoai.Equals(tenLoai, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public LoaiDTO TimKiemLoaiTheoMaVaTen(long maLoai, string tenLoai)
        {
            List<LoaiDTO> dsLoai = loaiDAL.LayDanhSachLoai();
            return dsLoai.FirstOrDefault(l => l.MaLoai == maLoai && l.TenLoai.Equals(tenLoai, StringComparison.OrdinalIgnoreCase));
        }
        public List<LoaiDTO> TimKiemLoaiTheoMaHoacTen(long maLoai, string tenLoai)
        {
            List<LoaiDTO> dsLoai = loaiDAL.LayDanhSachLoai();
            return dsLoai.Where(l => l.MaLoai == maLoai || l.TenLoai.Equals(tenLoai, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<LoaiDTO> TimKiemLoaiTuKhoa(string keyword)
        {
            List<LoaiDTO> dsLoai = loaiDAL.LayDanhSachLoai();
            return dsLoai.Where(l => l.TenLoai.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 || l.MaLoai.ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        public bool SuaLoai(long maLoai, string tenMoi)
        {
            if (string.IsNullOrWhiteSpace(tenMoi))
                throw new Exception("Tên loại không được để trống!");

            return loaiDAL.UpdateLoai(maLoai, tenMoi);
        }

        public bool XoaLoai(long maLoai)
        {
            List<LoaiDTO> dsLoai = loaiDAL.LayDanhSachLoai();
            var loaiToRemove = dsLoai.FirstOrDefault(l => l.MaLoai == maLoai);
            if (loaiToRemove != null)
            {
                dsLoai.Remove(loaiToRemove);
                return true;
            }
            return false;
        }

        public bool ThemLoai(LoaiDTO loai)
        {
            List<LoaiDTO> dsLoai = loaiDAL.LayDanhSachLoai();
            if (dsLoai.Any(l => l.MaLoai == loai.MaLoai))
            {
                return false; // Loại đã tồn tại
            }
            dsLoai.Add(loai);
            return true;
        }

        public bool ThemLoai(string tenloai)
        {
            return false;

        }


    }
}
