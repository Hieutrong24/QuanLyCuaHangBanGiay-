using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QL_BanGiay;
using DAL_QL_BanGiay;

namespace BUS_QL_BanGiay
{
    public class CTHoaDonBUS
    {
        // Khởi tạo đối tượng DAL để giao tiếp với tầng dữ liệu
        private CTHoaDonDAL cthdDAL = new CTHoaDonDAL();



        public bool ThemChiTiet(CTHoaDonDTO cthd)
        {
            return cthdDAL.InsertChiTietHoaDon(cthd);
        }

        public bool ThemDanhSachChiTiet(List<CTHoaDonDTO> danhSach)
        {
            return cthdDAL.InsertDanhSachChiTiet(danhSach);
        }
        public List<CTHoaDonDTO> GetChiTietByMaHD(string maHD)
        {
            try
            {
                // 🔥 LOGIC NGHIỆP VỤ: Kiểm tra tính hợp lệ của tham số
                if (string.IsNullOrEmpty(maHD))
                {
                    // Trả về danh sách trống hoặc ném lỗi nếu mã HD không hợp lệ
                    return new List<CTHoaDonDTO>();
                }

                // Gọi hàm lấy dữ liệu từ tầng DAL
                return cthdDAL.GetChiTietByMaHD(maHD);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi BUS (Ghi log, kiểm tra logic)

                // Ném lỗi lại lên tầng UI để hiển thị
                throw new Exception("Lỗi nghiệp vụ khi tải chi tiết hóa đơn: " + ex.Message, ex);
            }
        }

        // Bạn có thể thêm các hàm khác như ThemChiTiet(...), CapNhatChiTiet(...), v.v.
    }
}
