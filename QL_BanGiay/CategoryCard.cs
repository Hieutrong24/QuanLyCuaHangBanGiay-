using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BanGiay
{
    public partial class CategoryCard : UserControl
    {
        private PictureBox pictureBox;
        private Label lblName;

        public string CategoryName
        {
            get => lblName.Text;
            set => lblName.Text = value;
        }

        public Image CategoryImage
        {
            get => pictureBox.Image;
            set => pictureBox.Image = value;
        }

        public event EventHandler CategoryClicked;


        public CategoryCard()
        {
            InitializeComponent();
            this.MouseEnter += (s, e) => this.BackColor = Color.FromArgb(60, 60, 60);
            this.MouseLeave += (s, e) => this.BackColor = Color.FromArgb(40, 40, 40);
            this.Width = 200;
            this.Height = 180;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Margin = new Padding(20);
            BorderStyle = BorderStyle.None;
            BackColor = Color.White; 
            DoubleBuffered = true;
            this.Cursor = Cursors.Hand;

            pictureBox = new PictureBox
            {
                Dock = DockStyle.Top,
                Height = 120,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.None,
            };

            lblName = new Label
            {
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(50, 50, 50),
                Height = 35
            };
            Controls.Add(pictureBox);
            this.Controls.Add(pictureBox);
            this.Controls.Add(lblName);

            this.Click += (s, e) => CategoryClicked?.Invoke(this, EventArgs.Empty);
            pictureBox.Click += (s, e) => CategoryClicked?.Invoke(this, EventArgs.Empty);
            lblName.Click += (s, e) => CategoryClicked?.Invoke(this, EventArgs.Empty);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            BackColor = Color.FromArgb(230, 230, 230);
            this.Padding = new Padding(3);
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = Color.White;
            this.Padding = new Padding(0);
        }
        private void CategoryCard_Load(object sender, EventArgs e)
        {

        }

        private void CategoryCard_Load_1(object sender, EventArgs e)
        {

        }
    }
}
