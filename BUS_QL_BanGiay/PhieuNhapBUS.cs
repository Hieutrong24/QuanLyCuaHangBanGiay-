using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class PhieuNhapBUS
    {
        private readonly PhieuNhapDAL dal = new PhieuNhapDAL();

        public List<PhieuNhapDTO> LayDanhSachPhieuNhap()
        {
            return dal.LayDanhSachPhieuNhap();
        }

        
    }
}
