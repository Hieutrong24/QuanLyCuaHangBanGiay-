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
    public class SanPhamBUS
    {
        private SanPhamDAL spDAL = new SanPhamDAL();
        public List<SanPhamDTO> GetALL()
        {
            var list = spDAL.GetAll();
            return list;
        }
        public bool ThemSP(SanPhamDTO sp)
        {
            return spDAL.Insert(sp);
        }

        public bool XoaSP(long maGiay)
        {
            return spDAL.Delete(maGiay);
        }
        public int SoLuongLoaiSP()
        {
            var soluong = spDAL.DemSoLuongLoai();
            return soluong;
        }
        public int TongTonKho()
        {
            var tong = spDAL.TongTonKho();
            return tong;
        }

        public int SoSanPhamSapHet()
        {
            return spDAL.SanPhamSapHet();
        }

        public double TongGiaTriTonKho()
        {
            return spDAL.TongGiaTriTonKho();
        }

        //Loc va tim kiems

        public List<SanPhamDTO> LocTheoHang(long thuongHieu)
        {
            try
            {
                return spDAL.LocTheoHang(thuongHieu);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lọc theo hãng: " + ex.Message);
            }
        }

        public List<SanPhamDTO> LocTheoMau(long maMau)
        {
            try
            {
                return spDAL.LocTheoMau(maMau);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lọc theo màu: " + ex.Message);
            }
        }


        public List<SanPhamDTO> LocTheoGia(string sortOrder) { return spDAL.LocTheoGia(sortOrder); }
    }

}

