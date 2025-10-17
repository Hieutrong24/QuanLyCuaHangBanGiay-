using BUS_QL_BanGiay;
using DTO_QL_BanGiay;
using QRCoder;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanGiay
{
    public partial class frmThemNhanVien : Form
    {
        private NhanVienDTO NhanVienMoi;

        private frmDanhSachNhanVien parentForm;
        private NhanVienDTO emp;

        public frmThemNhanVien(frmDanhSachNhanVien form)
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
            parentForm = form;
        }
        public frmThemNhanVien(NhanVienDTO emp)
        {
            this.emp = emp;
        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }

        private void frmThemNhanVien_Load(object sender, EventArgs e)
        {
            LoadCBONhomQuyen();
        }



        private void btnThemNV_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraHopLe())
                {
                    NhanVienMoi = new NhanVienDTO
                    {
                        HoTen = txtTNV.Text.Trim(),
                        Email = txtEMAIL.Text.Trim(),
                        DienThoai = txtSDT.Text.Trim(),
                        MatKhau = txtMK.Text.Trim(),
                        NgaySinh = pkDT.Value,
                        DiaChi = txtDC.Text.Trim(),
                        Role = cboVaiTro.SelectedValue?.ToString(),
                        TrangThai = true,
                        ImagePath = btnImagesAvatar.Tag != null
                            ? Path.GetFileName(btnImagesAvatar.Tag.ToString())
                            : null,
                        NgayTao = DateTime.Now,
                        GioiTinh = rdoNam.Checked ? "Nam" : rdoNu.Checked ? "Nữ" : "Khác",
                    };

                    NhanVienBUS nhanVienBUS = new NhanVienBUS();

                    
                    bool isAdded = nhanVienBUS.Insert(NhanVienMoi);

                    if (isAdded)
                    {
                       
                        long maNV = nhanVienBUS.GetMaNhanVienMoiNhat();

                        
                        Image qrImg = TaoQRCode($"MaNV: {maNV}\nTen: {NhanVienMoi.HoTen}");

                       
                        using (MemoryStream ms = new MemoryStream())
                        {
                            qrImg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] qrBytes = ms.ToArray();
                            nhanVienBUS.CapNhatQRCode(maNV, qrBytes);
                        }

                        
                        MessageBox.Show(" Nhân viên và mã QR đã được tạo thành công!");
                        if (isAdded)
                        {
                            MessageBox.Show("Nhân viên và mã QR đã được tạo thành công!");

                            parentForm?.Invoke(new Action(() =>
                            {
                                parentForm.LoadDanhSachNhanVien();
                            }));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private Image TaoQRCode(string duLieu)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(duLieu, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
        private void btnImagesAvatar_Click(object sender, EventArgs e)
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
 
                        btnImagesAvatar.Values.Image = Image.FromFile(destPath);
                        btnImagesAvatar.Tag = destPath;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi copy ảnh: " + ex.Message);
                    }
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool KiemTraHopLe()
        {
            if (string.IsNullOrWhiteSpace(txtTNV.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEMAIL.Text))
            {
                MessageBox.Show("Vui lòng nhập email!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMK.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return false;
            }

            if (cboVaiTro.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhóm quyền!");
                return false;
            }

            return true;
        }

        private void cboVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVaiTro.SelectedItem != null)
            {
                string vaiTro = cboVaiTro.SelectedItem.ToString();
                 
            }
        }
        private void LoadCBONhomQuyen()
        {
            var nhomQuyen = new Dictionary<string, string>
            {
                { "ADMIN", "Quản trị viên" },
                { "BANHANG", "Nhân viên bán hàng" },
                { "THUKHO", "Thủ kho" },
                { "KETOAN", "Kế toán" },
                { "BAOHANH", "Nhân viên bảo hành" }
            };

            cboVaiTro.DataSource = new BindingSource(nhomQuyen, null);
            cboVaiTro.DisplayMember = "Value";
            cboVaiTro.ValueMember = "Key";
            cboVaiTro.SelectedIndex = -1;
        }
    }
}
