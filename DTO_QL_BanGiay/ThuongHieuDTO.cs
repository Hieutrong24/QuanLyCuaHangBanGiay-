using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class ThuongHieuDTO
    {
        long maThuongHieu;
        string tenThuongHieu;

        public ThuongHieuDTO()
        {
            maThuongHieu = 0;
            tenThuongHieu = "";
        }
        public ThuongHieuDTO(long maThuongHieu, string tenThuongHieu)
        {
            this.maThuongHieu = maThuongHieu;
            this.tenThuongHieu = tenThuongHieu;
        }

        public long MaThuongHieu { get; set; }
        public string TenThuongHieu { get; set; }

    }
}
