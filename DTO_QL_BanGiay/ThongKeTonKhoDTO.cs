using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class ThongKeTonKhoDTO
    {
        public string TenLoai { get; set; }

        // Tổng số lượng tồn kho của loại đó
        public int TongSoLuong { get; set; }

        public ThongKeTonKhoDTO() { }

        public ThongKeTonKhoDTO(string tenLoai, int tongSoLuong)
        {
            TenLoai = tenLoai;
            TongSoLuong = tongSoLuong;
        }
    }
}
