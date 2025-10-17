using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class ThongKeBUS
    {
        private readonly ThongKeDAL tkDAL = new ThongKeDAL();

        // --- Phương thức 1: Thêm mới thống kê ---
        public bool ThemThongKe(ThongKeDTO tk)
        {
            // **Quy tắc nghiệp vụ:** Số lượng bán và Doanh thu phải lớn hơn 0
            if (tk.SoLuongBan <= 0 || tk.DoanhThu <= 0)
            {
                // Trả về false nếu dữ liệu không hợp lệ
                return false;
            }

            // Gọi đến DAL để thực thi
            return tkDAL.ThemThongKe(tk) > 0;
        }

        // --- Phương thức 2: Sửa số lượng bán ---
        public bool SuaSoLuongBan(int maThongKe, int soLuongMoi)
        {
            // **Quy tắc nghiệp vụ:** Số lượng bán mới phải lớn hơn hoặc bằng 0
            if (soLuongMoi < 0)
            {
                return false;
            }
            return tkDAL.SuaSoLuongBan(maThongKe, soLuongMoi) > 0;
        }

        // --- Phương thức 3: Sửa doanh thu ---
        public bool SuaDoanhThu(int maThongKe, decimal doanhThuMoi)
        {
            // **Quy tắc nghiệp vụ:** Doanh thu mới phải lớn hơn hoặc bằng 0
            if (doanhThuMoi < 0)
            {
                return false;
            }
            return tkDAL.SuaDoanhThu(maThongKe, doanhThuMoi) > 0;
        }

        // --- Phương thức 4: Lấy ra danh sách thống kê ---
        public List<ThongKeDTO> LayDanhSachThongKe()
        {
            // Có thể thêm logic sắp xếp hoặc lọc dữ liệu ở đây nếu cần
            return tkDAL.LayDanhSachThongKe();
        }
    }
}
