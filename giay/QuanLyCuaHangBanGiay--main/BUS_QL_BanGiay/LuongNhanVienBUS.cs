using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class LuongNhanVienBUS
    {
        private LuongNhanVienDAL luongNhanVienDAL = new LuongNhanVienDAL();

       
        public List<LuongNhanVienDTO> GetAll()
        {
            return luongNhanVienDAL.GetAll();
        }

        public List<LuongNhanVienDTO> LocTheoTen(string name)
        {
            return luongNhanVienDAL.LocTheoTen(name);
        }

        public List<LuongNhanVienDTO> LocTheoNhomQuyen(string role)
        {
            return luongNhanVienDAL.LocTheoNhomQuyen(role);
        }
    }
}
