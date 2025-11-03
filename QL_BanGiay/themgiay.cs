using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QL_BanGiay;
using DTO_QL_BanGiay;

namespace QL_BanGiay
{
    public partial class themgiay : Form
    {
        private GiayBUS giayBUS = new GiayBUS();

        public themgiay()
        {
            InitializeComponent();
        }

        private void themgiay_Load(object sender, EventArgs e)
        {

        }
      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            GiayDTO g = new GiayDTO
            {
                TenGiay = txtTenGiay.Text,
                SoLuong = int.Parse(txtSoLuong.Text),
                DonGia = decimal.Parse(txtDonGia.Text),
                Size = int.Parse(txtSize.Text),
                DoiTuongSD = txtDoiTuong.Text,
                MaLoai = long.Parse(txtMaLoai.Text),
                MaXX = long.Parse(txtMaXX.Text),
                MaMau = long.Parse(txtMaMau.Text),
                MaThuongHieu = long.Parse(txtMaThuongHieu.Text)
            };

            giayBUS.ThemGiayVaChiTietPhieuNhap(g);
        }
    }
}
