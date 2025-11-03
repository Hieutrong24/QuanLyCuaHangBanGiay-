using BUS_QL_BanGiay;
using DTO_QL_BanGiay;
using Guna.UI2.WinForms;
using Krypton.Toolkit;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanGiay
{
    public partial class frmBaoCaoTheoDoi : Form
    {
        DoanhThuBUS busDoanhThu = new DoanhThuBUS();
        ThongKeGiayBUS busThongKeGiay = new ThongKeGiayBUS();
        ThongKeBUS busThongKe = new ThongKeBUS();
        public frmBaoCaoTheoDoi()
        {
            this.Load += new System.EventHandler(this.frmBaoCaoTheoDoi_Load);
            
            this.AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
        }

        private void frmBaoCaoTheoDoi_Load(object sender, EventArgs e)
        {
            
        }
        
    }

}
