using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class MauSacDTO
    {
        public MauSacDTO() { }
        public MauSacDTO(long maMau, string tenMau)
        {
            MaMau = maMau;
            TenMau = tenMau;
        }
        public long MaMau { get; set; }
        public string TenMau { get; set; }
    }
}
