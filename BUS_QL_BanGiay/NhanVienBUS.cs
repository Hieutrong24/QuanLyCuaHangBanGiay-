using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class NhanVienBUS
    {
        private NhanVienDAL nhanVienDAL = new NhanVienDAL();

        // Lấy toàn bộ danh sách nhân viên
        public List<NhanVienDTO> GetAll()
        {
            return nhanVienDAL.GetAll();
        }
        // Lay nhân viên theo mã
        public NhanVienDTO GetByMaNV(long maNV)
        {
            return nhanVienDAL.GetByMaNV(maNV);
        }
        // Thêm nhân viên mới
        public bool Insert(NhanVienDTO nv)
        {
            
            if (string.IsNullOrWhiteSpace(nv.HoTen))
                throw new ArgumentException("Họ tên không được để trống.");

            if (string.IsNullOrWhiteSpace(nv.Email))
                throw new ArgumentException("Email không được để trống.");

            return nhanVienDAL.Insert(nv);
        }
        public void CapNhatQRCode(long maNV, byte[] qrCode)
        {
            nhanVienDAL.CapNhatQRCode(maNV, qrCode);
        }

        public long GetMaNhanVienMoiNhat()
        {
            return nhanVienDAL.GetMaNhanVienMoiNhat();
        }

        public byte[] GetQRCodeByMaNV(int maNV)
        {
            return nhanVienDAL.GetQRCodeByMaNV(maNV);
        }

        public bool Update(NhanVienDTO nv)
        {
            return nhanVienDAL.Update(nv);
        }

        public bool Delete(long maTK)
        {
            return nhanVienDAL.Delete(maTK);
        }

        public List<NhanVienDTO> SearchByName(string ten)
        {
            return nhanVienDAL.Search(ten);
        }

        public bool UpdateRole(NhanVienDTO nv)
        {
            try
            {
                if (nv == null) throw new ArgumentNullException(nameof(nv));
                if (string.IsNullOrWhiteSpace(nv.Role))
                    throw new Exception("Quyền không được để trống.");

                return nhanVienDAL.UpdateRole(nv);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi BUS.UpdateRole: " + ex.Message);
            }
        }

        public bool UpdateTrangThai(NhanVienDTO nv)
        {
            try
            {
                if (nv == null) throw new ArgumentNullException(nameof(nv));
                return nhanVienDAL.UpdateTrangThai(nv);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi BUS.UpdateTrangThai: " + ex.Message);
            }
        }

         
    }
}
