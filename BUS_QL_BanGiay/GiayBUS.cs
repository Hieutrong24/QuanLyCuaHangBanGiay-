using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class GiayBUS
    {
        private GiayDAL _giayDAL = new GiayDAL();



        public DataTable GetSizesByTenGiay(string tenGiay)
        {
            // Gọi phương thức tương ứng từ DAL
            return _giayDAL.GetSizesByTenGiay(tenGiay);
        }
        public List<GiayDTO> LoadGiayVaApDungKhuyenMaiTheoTen(string tenGiayKeyword)
        {
            List<GiayDTO> listGiay = new List<GiayDTO>();
            DataTable dt = _giayDAL.LoadGiayTheoTen(tenGiayKeyword);

            foreach (DataRow row in dt.Rows)
            {
                // *** SỬA LỖI: Chuyển đổi MaGiay sang kiểu long ***
                long maGiay = Convert.ToInt64(row["MaGiay"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);

                // 1. Lấy % giảm từ DAL và tính toán giá sau ưu đãi
                decimal phanTramGiam = _giayDAL.GetPhanTramGiamHieuLuc(maGiay); // Truyền vào kiểu long
                decimal giaSauUuDai = donGia;

                if (phanTramGiam > 0)
                {
                    decimal tyLeGiam = phanTramGiam / 100m;
                    giaSauUuDai = donGia * (1m - tyLeGiam);
                    giaSauUuDai = Math.Ceiling(giaSauUuDai);
                }

                // 2. Đóng gói vào DTO
                listGiay.Add(new GiayDTO
                {
                    IdGiay = maGiay, // ✔️ Bây giờ gán trực tiếp không còn lỗi
                    TenGiay = row["TenGiay"].ToString(),
                    DonGia = donGia,
                    TonKho = row["SoLuong"].ToString(),
                    TenMau = row["TenMau"].ToString(),
                    Images = row["Images"].ToString(),
                    PhanTramGiam = phanTramGiam,
                    GiaSauUuDai = giaSauUuDai
                });
            }

            return listGiay;
        }

        public List<GiayDTO> LoadGiayVaApDungKhuyenMai()
        {
            List<GiayDTO> listGiay = new List<GiayDTO>();
            DataTable dt = _giayDAL.LoadTatCaGiay();

            foreach (DataRow row in dt.Rows)
            {
                // *** SỬA LỖI: Chuyển đổi MaGiay sang kiểu long ***
                long maGiay = Convert.ToInt64(row["MaGiay"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);

                // 1. Lấy % giảm từ DAL và tính toán giá sau ưu đãi
                decimal phanTramGiam = _giayDAL.GetPhanTramGiamHieuLuc(maGiay); // Truyền vào kiểu long
                decimal giaSauUuDai = donGia;

                if (phanTramGiam > 0)
                {
                    decimal tyLeGiam = phanTramGiam / 100m;
                    giaSauUuDai = donGia * (1m - tyLeGiam);
                    giaSauUuDai = Math.Ceiling(giaSauUuDai);
                }

                // 2. Đóng gói vào DTO
                listGiay.Add(new GiayDTO
                {
                    IdGiay = maGiay, // ✔️ Bây giờ gán trực tiếp không còn lỗi
                    TenGiay = row["TenGiay"].ToString(),
                    DonGia = donGia,
                    TonKho = row["SoLuong"].ToString(),
                    TenMau = row["TenMau"].ToString(),
                    Images = row["Images"].ToString(),
                    PhanTramGiam = phanTramGiam,
                    GiaSauUuDai = giaSauUuDai
                });
            }

            return listGiay;
        }

        //Khoa 

        private GiayDAL giayDAL = new GiayDAL();

        public DataTable LayDanhSachGiay() => giayDAL.GetAll();
        public DataTable TimGiayTheoTen(string ten) => giayDAL.SearchByName(ten);
        public DataTable LayGiayTheoLoai(string loai) => giayDAL.GetByLoai(loai);
        public void ThemGiay(GiayDTO g) => giayDAL.Insert(g);
        public void SuaGiay(GiayDTO g) => giayDAL.Update(g);
        public void XoaGiay(int id) => giayDAL.Delete(id);

        public void CapNhatAnh(int maGiay, string fileAnh) => giayDAL.CapNhatAnhGiay(maGiay, fileAnh);


    }
}
