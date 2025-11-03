using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class ChiTietKMBUS
    {
        private DAL_QL_BanGiay.ChiTietKMDAL chiTietKMDAL = new DAL_QL_BanGiay.ChiTietKMDAL();
        public List<DTO_QL_BanGiay.ChiTietKhuyenMaiDTO> GetAllChiTietKM()
        {
            return chiTietKMDAL.GetAll();
        }

        public bool TimCTKMTheoMa(long maCTKM)
        {
            return chiTietKMDAL.TimCTKMTheoMa(maCTKM);
        }
        public long TimKiemTheoMaDem(long maCTKM)
        {
            return chiTietKMDAL.KiemTraDemMa(maCTKM);
        }
    }
}
