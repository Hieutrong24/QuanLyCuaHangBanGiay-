using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class XuatXuBUS
    {
        private DAL_QL_BanGiay.XuatXuDAL xxDAL = new DAL_QL_BanGiay.XuatXuDAL();
        public List<DTO_QL_BanGiay.XuatXuDTO> GetAll()
        {
            var list = xxDAL.LayDSXuatXu();
            return list;
        }
    }
}
