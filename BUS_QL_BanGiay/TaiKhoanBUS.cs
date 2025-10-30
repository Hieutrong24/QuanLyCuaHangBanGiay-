using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class TaiKhoanBUS
    {
        TaiKhoanDAL tkDAL = new TaiKhoanDAL();
        public TaiKhoanDTO DangNhap(string tenDN, string matKhau)
        {
            return tkDAL.DangNhap(tenDN, matKhau);
        }
    }
}
