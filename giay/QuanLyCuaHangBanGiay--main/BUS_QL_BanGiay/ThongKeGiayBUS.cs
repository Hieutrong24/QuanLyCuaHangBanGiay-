using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class ThongKeGiayBUS
    {
        ThongKeGiayDAL dal = new ThongKeGiayDAL();

        public List<ThongKeGiayDTO> LayThongTinGiayTheoLuaChon(string luaChonText)
        {
            int soNgay = 1;
            switch (luaChonText)
            {
                case "1 ngày trước": soNgay = 1; break;
                case "3 ngày trước": soNgay = 3; break;
                case "7 ngày trước": soNgay = 7; break;
                case "14 ngày trước": soNgay = 14; break;
                case "30 ngày trước": soNgay = 30; break;
            }

            return dal.LayThongTinGiay(soNgay);
        }

    }
}
