using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADW08_TAKE_HOME
{
    public partial class Form2 : Form
    {
        private int idx;
        public PictureBox picBox2;
        private List<string> movieTitulo;
        private List<string> moviePosturo;
        private List<string> movieSinopsis;
        Dictionary<string, List<string>> seatMapping = new Dictionary<string, List<string>>();
        
        public Form2(int _index, List<string> _movieTitulo, List<string> _moviePosturo, List<string> _movieSinopsis, Dictionary<string, List<string>> _seatMapping)
        {
            InitializeComponent();
            idx = _index;
            movieTitulo = _movieTitulo;
            moviePosturo = _moviePosturo;
            movieSinopsis = _movieSinopsis;
            seatMapping = _seatMapping;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Label labelJudul = new Label();
            labelJudul.Text = movieTitulo[idx];
            labelJudul.AutoSize = true;
            labelJudul.Font = new Font("Euclid Circular B SemiBold", 25, FontStyle.Bold);
            labelJudul.ForeColor = Color.Orange;
            labelJudul.Location = new Point(363, 110);
            this.panel_show.Controls.Add(labelJudul);

            Label lblSinopsis = new Label();
            lblSinopsis.Text = movieSinopsis[idx];
            lblSinopsis.AutoSize = true;
            lblSinopsis.Font = new Font("Euclid Circular B Medium", 10, FontStyle.Regular);
            lblSinopsis.ForeColor = Color.White; 
            lblSinopsis.Location = new Point(370, 160);
            lblSinopsis.MaximumSize = new Size(450, 250);
            lblSinopsis.TextAlign = ContentAlignment.TopLeft;
            this.panel_show.Controls.Add(lblSinopsis);

            PictureBox picBox = new PictureBox();
            picBox.Size = new Size(300, 300);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.Location = new Point(30, 120);
            picBox.ImageLocation = moviePosturo[idx];
            this.panel_show.Controls.Add(picBox);

            Button btn = new Button();
            btn.Text = "19.45";
            btn.Size = new Size(90, 40);
            btn.Font = new Font("Euclid Circular B SemiBold", 10, FontStyle.Regular);
            btn.ForeColor = Color.White;
            btn.BackColor = Color.Black;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Tag = 1;
            btn.Location = new Point(370, 390);
            btn.Click += Button_Click;
            this.panel_show.Controls.Add(btn);

            Button btn1 = new Button();
            btn1.Text = "00.00";
            btn1.Size = new Size(90, 40);
            btn1.Font = new Font("Euclid Circular B SemiBold", 10, FontStyle.Regular);
            btn1.ForeColor = Color.White;
            btn1.BackColor = Color.Black;
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.FlatAppearance.BorderSize = 0;
            btn1.Tag = 2;
            btn1.Location = new Point(480,390);
            btn1.Click += Button_Click;
            this.panel_show.Controls.Add(btn1);

            Button btn2 = new Button();
            btn2.Text = "03.00";
            btn2.Size = new Size(90, 40);
            btn2.Font = new Font("Euclid Circular B SemiBold", 10, FontStyle.Regular);
            btn2.ForeColor = Color.White;
            btn2.BackColor = Color.Black;
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.FlatAppearance.BorderSize = 0;
            btn2.Tag = 3;
            btn2.Location = new Point(590, 390);
            btn2.Click += Button_Click;
            this.panel_show.Controls.Add(btn2);

            Button btnBack = new Button();
            btnBack.Text = "Back";
            btnBack.Size = new Size(90, 40);
            btnBack.Font = new Font("Euclid Circular B SemiBold", 10, FontStyle.Regular);
            btnBack.ForeColor = Color.White;
            btnBack.BackColor = Color.Brown;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Location = new Point(800, 390);
            btnBack.Click += ButtonBack_Click;
            this.panel_show.Controls.Add(btnBack);


        }
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Dock = DockStyle.Fill;
            form1.FormBorderStyle = FormBorderStyle.None;
            form1.TopLevel = false;
            form1.ControlBox = false;
            form1.seatMapping = this.seatMapping;
            this.panel_show.Controls.Clear();
            this.panel_show.Controls.Add(form1);
            form1.Show();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string showHour = btn.Text;
            string whatHour = Convert.ToString(btn.Tag);
            Form3 form3 = new Form3 (idx, movieTitulo, moviePosturo, movieSinopsis, showHour, whatHour, seatMapping);
            form3.Dock = DockStyle.Fill;
            form3.TopLevel = false;
            form3.AutoScroll = true;
            form3.ControlBox = false;
            form3.FormBorderStyle = FormBorderStyle.None;
            this.panel_show.Controls.Clear();
            this.panel_show.Controls.Add(form3);
            form3.Show();

        }
    }
}
