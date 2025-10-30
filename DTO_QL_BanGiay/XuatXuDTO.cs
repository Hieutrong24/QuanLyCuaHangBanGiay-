using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class XuatXuDTO
    {
        public long MaXX { get; set; }
        public string TenXX { get; set; }
        public XuatXuDTO()
        {
            MaXX = 0;
            TenXX = string.Empty;
        }
        public XuatXuDTO(long maXX, string tenXX)
        {
            MaXX = maXX;
            TenXX = tenXX;
        }
    }
}
