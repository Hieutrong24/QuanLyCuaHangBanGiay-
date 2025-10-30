using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class ThongKeGiayDTO
    {
        public string TenGiay { get; set; }
        public string DoiTuongSD { get; set; }
        public string TenLoai { get; set; }
        public string TenThuongHieu { get; set; }
        public int SoLuongBanRa { get; set; }
        public int SoLuongTonKho { get; set; }
        public decimal LoiNhuan { get; set; }

        public ThongKeGiayDTO() { }

        public ThongKeGiayDTO(string tenGiay, string doiTuongSD, string tenLoai,
                               string tenThuongHieu, int soLuongBanRa, int soLuongTonKho, decimal loiNhuan)
        {
            TenGiay = tenGiay;
            DoiTuongSD = doiTuongSD;
            TenLoai = tenLoai;
            TenThuongHieu = tenThuongHieu;
            SoLuongBanRa = soLuongBanRa;
            SoLuongTonKho = soLuongTonKho;
            LoiNhuan = loiNhuan;
        }
    }
}
