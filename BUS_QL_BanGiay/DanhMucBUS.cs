using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
namespace BUS_QL_BanGiay
{
    public class DanhMucBUS
    {
        private DanhMucDAL dmDAL = new DanhMucDAL();
        public List<DanhMucDTO> LayDSDanhMuc()
        {
            var list = dmDAL.LayDSDanhMuc();
            return list;
        }
    }
}
