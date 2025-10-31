using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class HoaDonBUS
    {

        private HoaDonDAL hdDAL = new HoaDonDAL();

        public bool ThemHoaDon(HoaDonDTO hoaDon)
        {
            // ✅ Kiểm tra nghiệp vụ
            if (hoaDon.MaKH <= 0)
                throw new ArgumentException("Mã khách hàng không hợp lệ.");

            if (hoaDon.TongTien <= 0)
                throw new ArgumentException("Tổng tiền phải lớn hơn 0.");

            try
            {
                return hdDAL.InsertHoaDon(hoaDon);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi BUS khi thêm hóa đơn: " + ex.Message, ex);
            }
        }

        public List<HoaDonDTO> GetAllHoaDon()
        {
            try
            {
                // Gọi hàm lấy dữ liệu từ tầng DAL
                return hdDAL.GetAllHoaDon();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi BUS (Ghi log, hoặc ném lỗi thân thiện hơn)
                // Trong BUS, bạn nên kiểm tra logic kinh doanh nếu cần.

                // Ở đây, ta ném lỗi ra tầng UI để hiển thị
                throw new Exception("Lỗi nghiệp vụ khi tải danh sách hóa đơn: " + ex.Message, ex);
            }
        }
    }
}
