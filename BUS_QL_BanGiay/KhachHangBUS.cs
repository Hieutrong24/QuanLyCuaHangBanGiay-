using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class KhachHangBUS
    {
        private KhachHangDAL dal = new KhachHangDAL();

        public KhachHangDTO GetDefaultCustomer()
        {
            return dal.GetFirstCustomer();
        }

        public DataTable GetLichSuMuaHang(long maKH)
        {
            return dal.GetLichSuMuaHang(maKH);
        }

        public DataTable GetSoLanMuaHangTheoThang(long maKH)
        {
            return dal.GetSoLanMuaHangTheoThang(maKH);
        }
        public DataTable GetTanSuatMuaHang(long maKH)
        {
            return dal.GetTanSuatMuaHang(maKH);
        }

        public DataTable GetAllKhachHang()
        {
            return dal.GetAllKhachHang();
        }


    }
}
