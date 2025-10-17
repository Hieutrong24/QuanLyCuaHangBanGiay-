using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class KhachHangThanThietBUS
    {
        private KhachHangThanThietDAL khDAL = new KhachHangThanThietDAL();
        public bool CongDiemChoKhach(int maKH, int diemCong)
        {
            KhachHangThanThietDTO kh = new KhachHangThanThietDTO
            {
                MaKH = maKH,
                TongDiem = diemCong,
                NgayCapNhat = DateTime.Now // Ngày hôm nay
            };

            return khDAL.CapNhatDiem(kh);
        }
        public KhachHangThanThietDTO GetKhachHangByMaKH(long maKH)
        {
            // 🔥 LOGIC NGHIỆP VỤ: Kiểm tra tính hợp lệ của MaKH
            if (maKH <= 0)
            {
                throw new ArgumentException("Mã Khách Hàng không hợp lệ.");
            }

            try
            {
                // Gọi hàm lấy dữ liệu từ tầng DAL
                return khDAL.GetKhachHangByMaKH(maKH);
            }
            catch (Exception ex)
            {
                // Ném lỗi lại lên tầng UI để hiển thị
                throw new Exception("Lỗi nghiệp vụ khi tìm kiếm thông tin Khách hàng: " + ex.Message, ex);
            }
        }
        public bool InsertKhachHangThanThiet(KhachHangThanThietDTO khachHang)
        {
            // 1. KIỂM TRA NGHIỆP VỤ (Business Rules)

            // Ví dụ: Đảm bảo Mã Khách hàng là hợp lệ (lớn hơn 0)
            if (khachHang.MaKH <= 0)
            {
                throw new ArgumentException("Mã Khách Hàng không được để trống hoặc bằng 0.");
            }

            // Ví dụ: Đảm bảo Hạng Thành Viên không bị rỗng
            if (string.IsNullOrEmpty(khachHang.HangThanhVien))
            {
                // Gán giá trị mặc định nếu cần
                khachHang.HangThanhVien = "Silver";
            }

            try
            {
                // 2. Gọi hàm DAL để thêm dữ liệu
                return khDAL.InsertKhachHangThanThiet(khachHang);
            }
            catch (Exception ex)
            {
                // Ném lỗi lại lên tầng UI để hiển thị
                throw new Exception("Lỗi nghiệp vụ khi thêm Khách hàng thân thiết: " + ex.Message, ex);
            }
        }
    }

    } 

