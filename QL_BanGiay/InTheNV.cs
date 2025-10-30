using DTO_QL_BanGiay;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace QL_BanGiay
{
    public class InTheNV
    {
        public void InTheNhanVienPDF(string filePath, NhanVienDTO nv)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    System.Windows.Forms.MessageBox.Show("Lỗi: filePath chưa được khởi tạo!");
                    return;
                }

                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Khởi tạo tài liệu
                Document doc = new Document(PageSize.A6, 20, 20, 20, 20);

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    System.Windows.Forms.MessageBox.Show("Bắt đầu tạo PDF"); // 1

                    if (string.IsNullOrEmpty(filePath))
                    {
                        System.Windows.Forms.MessageBox.Show("filePath null hoặc rỗng"); // 2
                        return;
                    }

                    System.Windows.Forms.MessageBox.Show("filePath OK"); // 3

                   
                    System.Windows.Forms.MessageBox.Show("Tạo doc xong"); // 4

                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

 
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                    BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    var fontTitle = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.BOLD);
                    var fontNormal = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

                    // Tiêu đề
                    Paragraph title = new Paragraph("THẺ NHÂN VIÊN", fontTitle);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);
                    doc.Add(new Paragraph("\n"));

                    // Ảnh nhân viên
                    if (!string.IsNullOrEmpty(nv.ImagePath))
                    {
                        string basePath = AppDomain.CurrentDomain.BaseDirectory;
                        string imagePath = Path.Combine(basePath, "Images", nv.ImagePath);

                        if (File.Exists(imagePath))
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagePath);
                            img.ScaleAbsolute(100, 100);
                            img.Alignment = Element.ALIGN_CENTER;
                            doc.Add(img);
                            doc.Add(new Paragraph("\n"));
                        }
                    }

                    // Thông tin nhân viên
                    doc.Add(new Paragraph($"Họ tên: {nv.HoTen}", fontNormal));
                    doc.Add(new Paragraph($"Mã nhân viên: {nv.MaTK}", fontNormal));
                    doc.Add(new Paragraph($"Giới tính: {nv.GioiTinh}", fontNormal));
                    doc.Add(new Paragraph($"Chức vụ: {nv.Role}", fontNormal));
                    doc.Add(new Paragraph($"SĐT: {nv.DienThoai}", fontNormal));
                    doc.Add(new Paragraph($"Email: {nv.Email}", fontNormal));

                    doc.Add(new Paragraph("\nNgày in: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNormal));

                    doc.Close();  
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi in thẻ nhân viên: " + ex.Message);
            }
        }

    }
}
