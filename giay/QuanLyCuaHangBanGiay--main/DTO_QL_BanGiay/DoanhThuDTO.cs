using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class DoanhThuDTO
    {
        public string TenMocThoiGian { get; set; }  
        public double TongDoanhThu { get; set; }
        public string TenDanhMuc { get; set; }   // Tên loại / thương hiệu / màu
        public int SoLuongBan { get; set; }      // Tổng số lượng bán được
    }
}
