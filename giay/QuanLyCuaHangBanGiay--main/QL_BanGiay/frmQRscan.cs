using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using QRCoder;
using ZXing;
using System.Diagnostics;   // để mở link trong trình duyệt

namespace QL_BanGiay
{
    public partial class MainForm : Form
    {

        private PictureBox pbPreview;      
        private TextBox txtToEncode;       
        private Button btnGenerate;        
        private Button btnStartCam;        
        private Button btnStopCam;         
        private ComboBox cbCameras;        
        private ListBox lstLog;            
        private TextBox txtScanResult;
        private Button btnSendToParent;

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        // biến để tránh log trùng lặp
        private string lastResult = "";
        public event Action<string> OnQRCodeScanned;
        public MainForm()
        {
            Text = "QR Code Generator + Scanner";
            Width = 900;
            Height = 600;
            StartPosition = FormStartPosition.CenterScreen;

            // preview camera / QR
            pbPreview = new PictureBox
            {
                Left = 10,
                Top = 10,
                Width = 560,
                Height = 420,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            Controls.Add(pbPreview);

            var lbl = new Label { Left = 10, Top = 440, Text = "Text / URL to encode:", AutoSize = true };
            Controls.Add(lbl);

            txtToEncode = new TextBox { Left = 10, Top = 460, Width = 420 };
            Controls.Add(txtToEncode);

            btnGenerate = new Button { Left = 440, Top = 458, Width = 130, Text = "Generate QR" };
            btnGenerate.Click += BtnGenerate_Click;
            Controls.Add(btnGenerate);

            var lblCam = new Label { Left = 580, Top = 10, Text = "Camera:", AutoSize = true };
            Controls.Add(lblCam);

            cbCameras = new ComboBox { Left = 580, Top = 30, Width = 290, DropDownStyle = ComboBoxStyle.DropDownList };
            Controls.Add(cbCameras);

            btnStartCam = new Button { Left = 580, Top = 70, Width = 140, Text = "Start Camera" };
            btnStartCam.Click += BtnStartCam_Click;
            Controls.Add(btnStartCam);

            btnStopCam = new Button { Left = 730, Top = 70, Width = 140, Text = "Stop Camera" };
            btnStopCam.Click += BtnStopCam_Click;
            Controls.Add(btnStopCam);

            var lblResult = new Label { Left = 580, Top = 110, Text = "Scan Result:", AutoSize = true };
            Controls.Add(lblResult);

            txtScanResult = new TextBox { Left = 580, Top = 130, Width = 290 };
            txtScanResult.ReadOnly = true;
            txtScanResult.DoubleClick += TxtScanResult_DoubleClick; // mở link khi double click
            Controls.Add(txtScanResult);

            lstLog = new ListBox { Left = 580, Top = 170, Width = 290, Height = 260 };
            Controls.Add(lstLog);

            Load += MainForm_Load;
            FormClosing += MainForm_FormClosing;
            btnSendToParent = new Button { Left = 580, Top = 440, Width = 290, Text = "Gửi mã QR sang form bán hàng" };
            btnSendToParent.Click += (s, e) => {
                if (!string.IsNullOrWhiteSpace(txtScanResult.Text))
                {
                    OnQRCodeScanned?.Invoke(txtScanResult.Text);
                    MessageBox.Show("Đã gửi mã QR sang form bán hàng!");
                }
            };
            Controls.Add(btnSendToParent);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo fi in videoDevices)
                {
                    cbCameras.Items.Add(fi.Name);
                }
                if (cbCameras.Items.Count > 0) cbCameras.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error enumerating video devices: " + ex.Message);
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            var payload = txtToEncode.Text.Trim();
            if (string.IsNullOrEmpty(payload))
            {
                MessageBox.Show("Enter text or URL to encode.");
                return;
            }

            using (var qrGenerator = new QRCodeGenerator())
            using (var qrData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q))
            using (var qrCode = new QRCode(qrData))
            {
                var bitmap = qrCode.GetGraphic(20);
                pbPreview.Image?.Dispose();
                pbPreview.Image = new Bitmap(bitmap);
            }

            lstLog.Items.Insert(0, DateTime.Now.ToString("HH:mm:ss") + " - Generated QR");
        }

        private void BtnStartCam_Click(object sender, EventArgs e)
        {
            if (videoDevices == null || videoDevices.Count == 0)
            {
                MessageBox.Show("No camera found.");
                return;
            }

            int idx = cbCameras.SelectedIndex;
            if (idx < 0) idx = 0;

            var fi = videoDevices[idx];
            videoSource = new VideoCaptureDevice(fi.MonikerString);
            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();

            lstLog.Items.Insert(0, DateTime.Now.ToString("HH:mm:ss") + " - Camera started");
            btnStartCam.Enabled = false;
        }

        private void BtnStopCam_Click(object sender, EventArgs e)
        {
            StopCamera();
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

                // hiển thị camera
                if (pbPreview.InvokeRequired)
                {
                    pbPreview.Invoke(new Action(() =>
                    {
                        if (pbPreview.Image != null)
                            pbPreview.Image.Dispose();
                        pbPreview.Image = (Bitmap)bitmap.Clone();
                    }));
                }
                else
                {
                    if (pbPreview.Image != null)
                        pbPreview.Image.Dispose();
                    pbPreview.Image = (Bitmap)bitmap.Clone();
                }

                // quét QR
                try
                {
                    var reader = new BarcodeReader
                    {
                        Options = {
                            TryHarder = true,
                            PossibleFormats = new[] { BarcodeFormat.QR_CODE }
                        }
                    };
                    var result = reader.Decode(bitmap);
                    if (result != null && result.Text != lastResult)
                    {
                        lastResult = result.Text;
                        if (txtScanResult.InvokeRequired)
                        {
                            txtScanResult.Invoke(new Action(() =>
                            {
                                txtScanResult.Text = result.Text;
                                lstLog.Items.Insert(0, DateTime.Now.ToString("HH:mm:ss") + " - Scanned: " + result.Text);
                            }));
                        }
                        else
                        {
                            txtScanResult.Text = result.Text;
                            OnQRCodeScanned?.Invoke(result.Text);
                            lstLog.Items.Insert(0, DateTime.Now.ToString("HH:mm:ss") + " - Scanned: " + result.Text);
                        }
                    }
                }
                catch { }

                bitmap.Dispose();
            }
            catch { }
        }

        private void TxtScanResult_DoubleClick(object sender, EventArgs e)
        {
            string text = txtScanResult.Text.Trim();
            if (!string.IsNullOrEmpty(text) && (text.StartsWith("http://") || text.StartsWith("https://")))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = text,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot open link: " + ex.Message);
                }
            }
        }

        private void StopCamera()
        {
            try
            {
                if (videoSource != null)
                {
                    if (videoSource.IsRunning)
                    {
                        videoSource.NewFrame -= VideoSource_NewFrame;
                        videoSource.SignalToStop();
                        videoSource.WaitForStop();
                    }
                    videoSource = null;
                }

                btnStartCam.Enabled = true;
                lstLog.Items.Insert(0, DateTime.Now.ToString("HH:mm:ss") + " - Camera stopped");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error stopping camera: " + ex.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
            pbPreview.Image?.Dispose();
        }
    }
}
