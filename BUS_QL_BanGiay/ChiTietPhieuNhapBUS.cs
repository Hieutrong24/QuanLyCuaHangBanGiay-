using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class ChiTietPhieuNhapBUS
    {
        private ChiTietPhieuNhapDAL dal = new ChiTietPhieuNhapDAL();

        public List<ChiTietPhieuNhapDTO> LayDanhSachChiTietPhieuNhap()
        {
            return dal.LayDanhSachChiTietPhieuNhap();
        }
    }
}
