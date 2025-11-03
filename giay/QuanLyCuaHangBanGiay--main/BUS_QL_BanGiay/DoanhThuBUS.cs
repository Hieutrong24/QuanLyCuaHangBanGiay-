using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class DoanhThuBUS
    {
        private DoanhThuDAL dal = new DoanhThuDAL();

        public List<DoanhThuDTO> GetDoanhThu7NgayGanNhat()
        {
            return dal.GetDoanhThu7NgayGanNhat();
        }

        public List<DoanhThuDTO> GetDoanhThu4ThangGanNhat()
        {
            return dal.GetDoanhThu4ThangGanNhat();
        }

        public List<DoanhThuDTO> GetDoanhThu4NamGanNhat()
        {
            return dal.GetDoanhThu4NamGanNhat();
        }

        public List<DoanhThuDTO> GetSoLuongBanTheoLoai(DateTime tuNgay, DateTime denNgay)
        {
            return dal.GetSoLuongBanTheoLoai(tuNgay, denNgay);
        }

        public List<DoanhThuDTO> GetSoLuongBanTheoThuongHieu(DateTime tuNgay, DateTime denNgay)
        {
            return dal.GetSoLuongBanTheoThuongHieu(tuNgay, denNgay);
        }

        public List<DoanhThuDTO> GetSoLuongBanTheoMau(DateTime tuNgay, DateTime denNgay)
        {
            return dal.GetSoLuongBanTheoMau(tuNgay, denNgay);
        }

        public List<(string TenNV, DateTime Ngay, decimal DoanhThu)> GetDoanhThuNhanVienTheoKhoangNgay(DateTime tuNgay, DateTime denNgay, string TenNV)
        {
            return dal.GetDoanhThuNhanVienTheoKhoangNgay(tuNgay, denNgay, TenNV);
        }


    }
}
