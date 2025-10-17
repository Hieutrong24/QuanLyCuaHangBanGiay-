using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class LoaiDTO
    {
        public long MaLoai { get; set; }
        public string TenLoai { get; set; }
        public LoaiDTO() { }
        public LoaiDTO(long idLoai, string tenLoai)
        {
            MaLoai = idLoai;
            TenLoai = tenLoai;
        }
    }
}
