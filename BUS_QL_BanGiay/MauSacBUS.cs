using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class MauSacBUS
    {
        private DAL_QL_BanGiay.MauSacDAL mauDAL = new DAL_QL_BanGiay.MauSacDAL();
        public List<DTO_QL_BanGiay.MauSacDTO> GetALL()
        {
            var list = mauDAL.LayDSMauSac();
            return list;
        }
    }
}
