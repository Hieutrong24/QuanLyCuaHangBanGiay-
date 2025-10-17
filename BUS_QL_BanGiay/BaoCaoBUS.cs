using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class BaoCaoBUS
    {
        private readonly ThongKeSoLuongGiayDAL _thongKeDAL = new ThongKeSoLuongGiayDAL();

        public List<BaoCaoSoLuongGiayDTO> XemBaoCaoGiayTheoNgay(DateTime ngay)
        {
            return _thongKeDAL.LayTongSoLuongGiayTheoNgay(ngay);
        }
    }
}
