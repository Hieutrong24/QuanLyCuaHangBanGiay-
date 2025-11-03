using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
namespace BUS_QL_BanGiay
{
    public  class ThuongHieuBUS:DBConnect
    {
        private ThuongHieuDAL ttDAL = new ThuongHieuDAL();
        public List<ThuongHieuDTO> LayDanhSachThuongHieu()
        {
            var list = ttDAL.LayDSThuongHieu();
            return list;
        }
    }
}
