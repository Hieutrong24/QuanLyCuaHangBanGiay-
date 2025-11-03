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

        public bool XoaLoai(long maLoai, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                // Gọi xuống DAL thực hiện toàn bộ quy trình xóa
                return loaiDAL.DeleteLoai(maLoai);
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                if (sqlEx.Message.Contains("REFERENCE") || sqlEx.Message.Contains("FOREIGN"))
                {
                    errorMessage = "Không thể xóa loại này vì đang có giày hoặc phiếu nhập liên quan!";
                }
                else
                {
                    errorMessage = "Lỗi SQL: " + sqlEx.Message;
                }
                return false;
            }

        }


        public bool ThemLoai(LoaiDTO loai)
        {
            return loaiDAL.InsertLoai(loai);
        }

        public bool ThemLoai(string tenLoai)
        {
            return loaiDAL.InsertLoai(tenLoai);
        }


    }
}
