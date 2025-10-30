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
        public List<HoaDonDTO> GetAllHoaDon_TongTienTang()
        {
            try
            {
                return hdDAL.GetAllHoaDon_TongTienTang();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi tải danh sách hóa đơn (Giá tăng dần): " + ex.Message, ex);
            }
        }

        public List<HoaDonDTO> GetAllHoaDon_TongTienGiam()
        {
            try
            {
                return hdDAL.GetAllHoaDon_TongTienGiam();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi tải danh sách hóa đơn (Giá giảm dần): " + ex.Message, ex);
            }
        }
        public bool CapNhatTongTienHoaDon(long maHD)
        {
            try
            {
                return hdDAL.CapNhatTongTienHoaDon(maHD);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BUS khi cập nhật tổng tiền hóa đơn: " + ex.Message);
                throw;
            }
        }
        public bool DeleteHoaDon(long maHD)
        {
            try
            {
                // Bước 1: Xóa chi tiết hóa đơn trước (tránh lỗi khóa ngoại)
                CTHoaDonBUS cthdBUS = new CTHoaDonBUS();
                bool chiTietDeleted = cthdBUS.DeleteChiTietHoaDon(maHD);

                // Bước 2: Xóa hóa đơn chính
                bool hoaDonDeleted = hdDAL.DeleteHoaDon(maHD);

                // Bước 3: Trả kết quả tổng hợp
                return hoaDonDeleted; // hoặc: chiTietDeleted && hoaDonDeleted
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi xóa hóa đơn: " + ex.Message, ex);
            }
        }

        public List<HoaDonDTO> GetAllHoaDon_MoiNhat()
        {
            try
            {
                return hdDAL.GetAllHoaDon_MoiNhat();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi tải danh sách hóa đơn (Mới nhất): " + ex.Message, ex);
            }
        }

        public List<HoaDonDTO> GetAllHoaDon_CuNhat()
        {
            try
            {
                return hdDAL.GetAllHoaDon_CuNhat();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi tải danh sách hóa đơn (Cũ nhất): " + ex.Message, ex);
            }
        }

    }
}
