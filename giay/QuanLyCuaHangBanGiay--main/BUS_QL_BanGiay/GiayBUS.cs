using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUS_QL_BanGiay
{
    public class GiayBUS
    {
        private GiayDAL _giayDAL = new GiayDAL();
        private GiayDAL giayDAL = new GiayDAL();

        // ==================== CÁC HÀM LOADING ====================

        public List<GiayDTO> LoadGiayTheoMa(long maGiay)
        {
            List<GiayDTO> listGiay = new List<GiayDTO>();
            DataTable dt = _giayDAL.LoadGiayTheoMa(maGiay);

            foreach (DataRow row in dt.Rows)
            {
                long ma = Convert.ToInt64(row["MaGiay"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);
                decimal phanTramGiam = _giayDAL.GetPhanTramGiamHieuLuc(ma);
                decimal giaSauUuDai = phanTramGiam > 0
                    ? Math.Ceiling(donGia * (1m - phanTramGiam / 100m))
                    : donGia;

                listGiay.Add(new GiayDTO
                {
                    IdGiay = ma,
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

        public DataTable GetSizesByTenGiay(string tenGiay) =>
            _giayDAL.GetSizesByTenGiay(tenGiay);

        public List<GiayDTO> LoadGiayVaApDungKhuyenMaiTheoTen(string tenGiayKeyword)
        {
            List<GiayDTO> listGiay = new List<GiayDTO>();
            DataTable dt = _giayDAL.LoadGiayTheoTen(tenGiayKeyword);

            foreach (DataRow row in dt.Rows)
            {
                long maGiay = Convert.ToInt64(row["MaGiay"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);
                decimal phanTramGiam = _giayDAL.GetPhanTramGiamHieuLuc(maGiay);
                decimal giaSauUuDai = phanTramGiam > 0
                    ? Math.Ceiling(donGia * (1m - phanTramGiam / 100m))
                    : donGia;

                listGiay.Add(new GiayDTO
                {
                    IdGiay = maGiay,
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

        public List<GiayDTO> LoadGiayVaApDungKhuyenMai_Tang()
        {
            List<GiayDTO> listGiay = new List<GiayDTO>();
            DataTable dt = _giayDAL.LoadGiaySapXepTang();

            foreach (DataRow row in dt.Rows)
            {
                long maGiay = Convert.ToInt64(row["MaGiay"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);
                decimal phanTramGiam = _giayDAL.GetPhanTramGiamHieuLuc(maGiay);
                decimal giaSauUuDai = phanTramGiam > 0
                    ? Math.Ceiling(donGia * (1m - phanTramGiam / 100m))
                    : donGia;

                listGiay.Add(new GiayDTO
                {
                    IdGiay = maGiay,
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

        public List<GiayDTO> LoadGiayVaApDungKhuyenMai_Giam()
        {
            List<GiayDTO> listGiay = new List<GiayDTO>();
            DataTable dt = _giayDAL.LoadGiaySapXepGiam();

            foreach (DataRow row in dt.Rows)
            {
                long maGiay = Convert.ToInt64(row["MaGiay"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);
                decimal phanTramGiam = _giayDAL.GetPhanTramGiamHieuLuc(maGiay);
                decimal giaSauUuDai = phanTramGiam > 0
                    ? Math.Ceiling(donGia * (1m - phanTramGiam / 100m))
                    : donGia;

                listGiay.Add(new GiayDTO
                {
                    IdGiay = maGiay,
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

        public bool CapNhatSoLuong(long maGiay, int soLuongTru)
        {
            if (maGiay <= 0 || soLuongTru <= 0)
                throw new ArgumentException("Mã giày và số lượng phải > 0.");

            return _giayDAL.CapNhatSoLuong(maGiay, soLuongTru);
        }

        public List<GiayDTO> LoadGiayVaApDungKhuyenMai()
        {
            List<GiayDTO> listGiay = new List<GiayDTO>();
            DataTable dt = _giayDAL.LoadTatCaGiay();

            foreach (DataRow row in dt.Rows)
            {
                long maGiay = Convert.ToInt64(row["MaGiay"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);
                decimal phanTramGiam = _giayDAL.GetPhanTramGiamHieuLuc(maGiay);
                decimal giaSauUuDai = phanTramGiam > 0
                    ? Math.Ceiling(donGia * (1m - phanTramGiam / 100m))
                    : donGia;

                listGiay.Add(new GiayDTO
                {
                    IdGiay = maGiay,
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

        // ==================== CRUD CHO FORM KHO ====================
        public DataTable LayDanhSachGiay()
        {
            try
            {
                return giayDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải danh sách giày đầy đủ: " + ex.Message);
            }
        }
        public DataTable GetAll()
        {
            return giayDAL.GetAll();
        }
        public DataTable TimGiayTheoTen(string ten) => giayDAL.SearchByName(ten);
        public DataTable LayGiayTheoLoai(string loai) => giayDAL.GetByLoai(loai);
        public void ThemGiay(GiayDTO g) => giayDAL.Insert(g);
        public bool CapNhatGiay(GiayDTO g)
        {
            return giayDAL.UpdateGiay(g);
        }
        public void XoaGiay(long id) => giayDAL.Delete(id);
        public void CapNhatAnh(long maGiay, string fileAnh) => giayDAL.CapNhatAnhGiay(maGiay, fileAnh);
        public void ThemGiayVaChiTietPhieuNhap(GiayDTO g) => giayDAL.ThemGiayVaChiTietPhieuNhap(g);

        public List<GiayDTO> GetAllADKM() => giayDAL.GetAllGiayADKM();
    }
}
