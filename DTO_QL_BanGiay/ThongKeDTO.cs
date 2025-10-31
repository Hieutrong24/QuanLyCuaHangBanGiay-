using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class ThongKeDTO
    {
        // Mã thống kê (Khóa chính)
        public int MaThongKe { get; set; }

        // Ngày lập (dùng kiểu DateTime trong C#)
        public DateTime NgayLap { get; set; }

        // Số lượng bán
        public int SoLuongBan { get; set; }

        // Doanh thu (dùng kiểu decimal cho tiền tệ)
        public decimal DoanhThu { get; set; }
    }
}
