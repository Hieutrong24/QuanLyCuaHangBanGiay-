using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class ChuongTrinhKhuyenMaiBUS
    {
        // Business logic methods for ChuongTrinhKhuyenMai can be added here
        private DAL_QL_BanGiay.ChuongTrinhKhuyenMaiDAL ctkmDAL = new DAL_QL_BanGiay.ChuongTrinhKhuyenMaiDAL();
        public List<DTO_QL_BanGiay.ChuongTrinhKhuyenMaiDTO> GetAllChuongTrinhKhuyenMai()
        {
            return ctkmDAL.GetAll();
        }
        public bool ThemChuongTrinhKhuyenMai(DTO_QL_BanGiay.ChuongTrinhKhuyenMaiDTO ctkm)
        {
            return ctkmDAL.Insert(ctkm);
        }
        public bool CapNhatChuongTrinhKhuyenMai(DTO_QL_BanGiay.ChuongTrinhKhuyenMaiDTO ctkm)
        {
            return ctkmDAL.Update(ctkm);
        }
        public bool XoaChuongTrinhKhuyenMai(long maCTKM)
        {
            return ctkmDAL.Delete(maCTKM);
        }
         
        public List<DTO_QL_BanGiay.ChuongTrinhKhuyenMaiDTO> TimChuongTrinhKhuyenMaiTheoTen(string tenCTKM)
        {
            return ctkmDAL.SearchByName(tenCTKM);
        }
    }
}
