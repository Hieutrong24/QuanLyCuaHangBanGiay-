namespace QL_BanGiay
{
    partial class frmDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.txtUsername = new Krypton.Toolkit.KryptonTextBox();
            this.txtPassword = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.sưCamera = new Sunny.UI.UISwitch();
            this.btnLogin = new Krypton.Toolkit.KryptonButton();
            this.btnSignIn = new Krypton.Toolkit.KryptonButton();
            this.pnHIenThiCamera = new Krypton.Toolkit.KryptonPanel();
            this.kryptonPictureBox1 = new Krypton.Toolkit.KryptonPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnHIenThiCamera)).BeginInit();
            this.pnHIenThiCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(502, 151);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(375, 48);
            this.txtUsername.StateCommon.Border.Rounding = 10F;
            this.txtUsername.StateCommon.Content.Padding = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(502, 258);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(375, 48);
            this.txtPassword.StateCommon.Border.Rounding = 10F;
            this.txtPassword.StateCommon.Content.Padding = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = " ";
            this.txtPassword.TextChanged += new System.EventHandler(this.kryptonTextBox2_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel1.Location = new System.Drawing.Point(548, 54);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(274, 40);
            this.kryptonLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Welcome to Back!";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(502, 228);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(76, 24);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Password";
            this.kryptonLabel2.Click += new System.EventHandler(this.kryptonLabel2_Click);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(502, 121);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(84, 24);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "User name";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel4.Location = new System.Drawing.Point(596, 426);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(161, 24);
            this.kryptonLabel4.TabIndex = 5;
            this.kryptonLabel4.Values.Text = "Use QR code to log in";
            // 
            // sưCamera
            // 
            this.sưCamera.ActiveColor = System.Drawing.Color.Green;
            this.sưCamera.ActiveText = "On";
            this.sưCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sưCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.sưCamera.InActiveText = "Off";
            this.sưCamera.Location = new System.Drawing.Point(500, 426);
            this.sưCamera.MinimumSize = new System.Drawing.Size(1, 1);
            this.sưCamera.Name = "sưCamera";
            this.sưCamera.Size = new System.Drawing.Size(57, 24);
            this.sưCamera.TabIndex = 7;
            this.sưCamera.Text = "uiSwitch1";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(542, 341);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(112, 50);
            this.btnLogin.StateCommon.Back.Color1 = System.Drawing.Color.MediumTurquoise;
            this.btnLogin.StateCommon.Border.Rounding = 30F;
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnLogin.Values.Text = "Log in";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignIn.Location = new System.Drawing.Point(710, 341);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(112, 50);
            this.btnSignIn.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSignIn.StateCommon.Border.Rounding = 30F;
            this.btnSignIn.TabIndex = 9;
            this.btnSignIn.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.btnSignIn.Values.Text = "Sign in";
            // 
            // pnHIenThiCamera
            // 
            this.pnHIenThiCamera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnHIenThiCamera.Controls.Add(this.kryptonPictureBox1);
            this.pnHIenThiCamera.Location = new System.Drawing.Point(1, 0);
            this.pnHIenThiCamera.Name = "pnHIenThiCamera";
            this.pnHIenThiCamera.Size = new System.Drawing.Size(482, 482);
            this.pnHIenThiCamera.StateCommon.Color1 = System.Drawing.Color.White;
            this.pnHIenThiCamera.TabIndex = 10;
            // 
            // kryptonPictureBox1
            // 
            this.kryptonPictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonPictureBox1.BackgroundImage")));
            this.kryptonPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.kryptonPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPictureBox1.Name = "kryptonPictureBox1";
            this.kryptonPictureBox1.Size = new System.Drawing.Size(482, 482);
            this.kryptonPictureBox1.TabIndex = 7;
            this.kryptonPictureBox1.TabStop = false;
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 485);
            this.Controls.Add(this.pnHIenThiCamera);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.sưCamera);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Name = "frmDangNhap";
            this.Text = "DangNhap";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnHIenThiCamera)).EndInit();
            this.pnHIenThiCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox txtUsername;
        private Krypton.Toolkit.KryptonTextBox txtPassword;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Sunny.UI.UISwitch sưCamera;
        private Krypton.Toolkit.KryptonButton btnLogin;
        private Krypton.Toolkit.KryptonButton btnSignIn;
        private Krypton.Toolkit.KryptonPanel pnHIenThiCamera;
        private Krypton.Toolkit.KryptonPictureBox kryptonPictureBox1;
    }
}

