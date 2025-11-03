using BUS_QL_BanGiay;
using DTO_QL_BanGiay;
using Krypton.Toolkit;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QL_BanGiay
{
    public partial class ThemSanPham : Form
    {
        public ThemSanPham()
        {
            InitializeComponent();
        }
         
        private ThuongHieuBUS thuongHieuBUS = new ThuongHieuBUS();
        private DanhMucBUS danhMucBUS = new DanhMucBUS();
        private XuatXuBUS xuatXuBUS = new XuatXuBUS();

        private void kryptonLabel4_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonLabel3_Click(object sender, EventArgs e)
        {

        }

        private void ThemSanPham_Load(object sender, EventArgs e)
        {
            DanhSachThuongHieu();
            DanhSachDanhMuc();
            Trangthai();
            ThueVAT();
            LoadSize();
            LoadChatLieu();
            LayDSXuatXu();
            LayDSMauSac();

            string tenGiay = txtTSP.Text;
            int soLuong = (int)btnSoLuong.Value;
            decimal donGia = string.IsNullOrWhiteSpace(lblGiaThuc.Text) ? 0 : decimal.Parse(lblGiaThuc.Text);
            string size = cmbSize.Text;
            string chatlieu = cmbChatLieu.Text;
            string mau = cmbMS.Text;
            //int thuonghieu = (int)((UIComboBoxItem)cmbThuongHieu.SelectedItem).ValueChanged;
            string doiTuongSD = "";

            if (btnNam.Checked) doiTuongSD = btnNam.Text;
            else if (btnNu.Checked) doiTuongSD = btnNu.Text;
            else if (btnUnisex.Checked) doiTuongSD = btnUnisex.Text;

            string loai = cmbDM.Text;
            string xuatxu = cmbXX.Text;
            //string hinhanh = txtHinhAnh.Text;
            string trangthai = cmbTT.Text;


        }

        private void DanhSachThuongHieu()
        {
            var list = thuongHieuBUS.LayDanhSachThuongHieu();

            cmbThuongHieu.DataSource = list;
            cmbThuongHieu.DisplayMember = "TenThuongHieu";  // Thuộc tính hiển thị
            cmbThuongHieu.ValueMember = "MaThuongHieu";     // Thuộc tính làm Value
            cmbThuongHieu.ForeColor = Color.Black;
        }

        private void DanhSachDanhMuc( )
        {
            var list = danhMucBUS.LayDSDanhMuc();

            cmbDM.DataSource = list;
            cmbDM.DisplayMember = "TenDanhMuc";  // Thuộc tính hiển thị
            cmbDM.ValueMember = "MaDanhMuc";     // Thuộc tính làm Value
            cmbDM.ForeColor = Color.Black;
            cmbDM.BackColor = Color.White;
            //MessageBox.Show("Số danh mục: " + list.Count);
        }
        private void Trangthai()
        {
            cmbTT.Items.Add("Kinh doanh");
            cmbTT.Items.Add("Ngừng kinh doanh");
            cmbTT.SelectedIndex = 0; // Chọn mục đầu tiên làm mặc định
        }
         
        private void ThueVAT()
        {
            upThue.DecimalPlaces = 2;
            upThue.Increment = 0.01M;
            upThue.Minimum = 0;
            upThue.Maximum = 100;
            upThue.Value = 10;
        }
        private void LoadSize()
        {
            cmbSize.Items.Clear();    
            for (int i = 35; i <= 45; i++)    
            {
                cmbSize.Items.Add(i.ToString());
            }

            cmbSize.SelectedIndex = 0;  
        }

        private void LoadChatLieu()
        {
            cmbChatLieu.Items.Clear();    

            string[] chatLieus = { "Da", "Vải", "Cao su", "Nhựa", "Vải lưới", "Vải tổng hợp" };

            foreach (var cl in chatLieus)
            {
                cmbChatLieu.Items.Add(cl);
            }

            cmbChatLieu.SelectedIndex = 0; // chọn mặc định
        }

        private void LayDSXuatXu()
        {
            var list = xuatXuBUS.GetAll();
            cmbXX.DataSource = list;
            cmbXX.DisplayMember = "TenXX";
            cmbXX.ValueMember = "MaXX";
            cmbXX.ForeColor = Color.Black;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh sản phẩm";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string sourcePath = ofd.FileName;

                        
                        string basePath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                        string folderPath = Path.Combine(basePath, "Images");

                        
                        if (!Directory.Exists(folderPath))
                            Directory.CreateDirectory(folderPath);

                       
                        string fileName = Path.GetFileName(sourcePath);
                        string destPath = Path.Combine(folderPath, fileName);

                        
                        if (File.Exists(destPath))
                        {
                            string ext = Path.GetExtension(fileName);
                            string name = Path.GetFileNameWithoutExtension(fileName);
                            fileName = $"{name}_{Guid.NewGuid()}{ext}";
                            destPath = Path.Combine(folderPath, fileName);
                        }

                       
                        File.Copy(sourcePath, destPath, true);


                        //btnImage.Values.Image = null;  
                        //btnImage.ButtonStyle = Krypton.Toolkit.ButtonStyle.Standalone;
                        //btnImage.BackgroundImage = Image.FromFile(destPath);
                        //btnImage.BackgroundImageLayout = ImageLayout.Zoom;  
                        btnImage.Values.Image = Image.FromFile(destPath);

                        txtImagePath.Text = fileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi copy ảnh: " + ex.Message);
                    }
                }
            }
        }





        private void cmbThuongHieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbThuongHieu.SelectedValue.ToString());
        }

        private void txtGN_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtGN.Text, out decimal gia))  
            {
                lblGN.Text = gia.ToString("N0") + "đ";  
                lblGN.ForeColor = Color.Black;          
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtGN.Text))   
                {
                    lblGN.Text = "Giá trị không hợp lệ!";
                    lblGN.ForeColor = Color.Red; 
                }
                else
                {
                    lblGN.Text = "";  
                }
            }
        }

        private void txtGB_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtGB.Text, out decimal gia))
            {
                lblGB.Text = gia.ToString("N0") + "đ";
                lblGB.ForeColor = Color.Black;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtGB.Text))
                {
                    lblGB.Text = "Giá trị không hợp lệ!";
                    lblGB.ForeColor = Color.Red;
                }
                else
                {
                    lblGB.Text = "";
                }
            }
            TinhGiaThuc();
        }

        private void TinhGiaThuc()
        {
            
            if (decimal.TryParse(txtGB.Text, out decimal giaBan))
            {
                 
                decimal khuyenMai = udKM.Value;  

          
                decimal giaThuc = giaBan - (giaBan * (khuyenMai / 100));

               
                lblGiaThuc.Text = giaThuc.ToString("N0") + "đ";
                lblGiaThuc.ForeColor = Color.Black;
            }
            else
            {
                lblGiaThuc.Text = "Giá không hợp lệ!";
                lblGiaThuc.ForeColor = Color.Red;
            }
        }
        //private string GanMauCoBan(Color c)
        //{
        //    float hue = c.GetHue();
        //    float sat = c.GetSaturation();
        //    float bri = c.GetBrightness();

        //    if (bri < 0.2) return "Đen";
        //    if (bri > 0.8 && sat < 0.2) return "Trắng";
        //    if (hue >= 0 && hue < 30) return "Đỏ";
        //    if (hue >= 40 && hue < 70) return "Vàng";
        //    if (hue >= 100 && hue < 150) return "Xanh lá";
        //    if (hue >= 180 && hue < 260) return "Xanh dương";
        //    if (hue >= 260 && hue < 330) return "Tím";
        //    return "Khác";
        //}
        //private void pkMS_ValueChanged(object sender, Color value)
        //{
        //    Color selectedColor = pkMS.Value;

        //    lblMau.BackColor = selectedColor;
        //    lblMau.Text = GanMauCoBan(selectedColor);

             
        //    lblMau.ForeColor = selectedColor.GetBrightness() > 0.5 ? Color.Black : Color.White;
             
        //}
        private void LayDSMauSac()
        {
            MauSacBUS mauSacBUS = new MauSacBUS();
            var list = mauSacBUS.GetALL();
            cmbMS.DataSource = list;
            cmbMS.DisplayMember = "TenMau";
            cmbMS.ValueMember = "MaMau";
            cmbMS.ForeColor = Color.Black;
        }

        private void udKM_ValueChanged(object sender, EventArgs e)
        {
            TinhGiaThuc();
        }

        private void btnCN_Click(object sender, EventArgs e)
        {   
            
             
            SanPhamDTO sp = new SanPhamDTO();
            sp.TenGiay = txtTSP.Text;
            sp.SoLuong = (int)btnSoLuong.Value;
            
            string giaBanText = lblGiaThuc.Text;

              
            giaBanText = giaBanText.Replace(".", "").Replace("đ", "");

            
            decimal giaBan = 0;
            if (decimal.TryParse(giaBanText, out giaBan))
            {
                sp.DonGia = giaBan;
            }
            else
            {
                MessageBox.Show("Giá bán không hợp lệ.");
            }
             
            sp.Size = cmbSize.Text;
            sp.ChatLieu = cmbChatLieu.Text;
            sp.MaMau = (long)cmbMS.SelectedValue;
            sp.DoiTuongSD = btnNam.Checked ? btnNam.Text : btnNu.Checked ? btnNu.Text : btnUnisex.Checked ? btnUnisex.Text : "";   
            sp.MaLoai = (long)cmbDM.SelectedValue;
            sp.MaXX = (long)cmbXX.SelectedValue;
            sp.HinhAnh = txtImagePath.Text;
            sp.TrangThai = cmbTT.Text;
            sp.MaThuongHieu = (long)cmbThuongHieu.SelectedValue;
            SanPhamBUS spBUS = new SanPhamBUS();
            bool success = spBUS.ThemSP(sp);
            MessageBox.Show("Đã thêm sản phẩm: " + sp.TenGiay);
        }

        private void cmbMS_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
