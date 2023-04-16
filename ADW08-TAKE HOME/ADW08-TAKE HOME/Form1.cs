using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ADW08_TAKE_HOME
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        
        string source = @"C:\Users\KENT LEE\source\repos\ADW08-TAKE HOME\ADW08-TAKE HOME\bin\Debug\Week 8 Poster\poster sinopsis fix.txt";
        public List<string> movieTitulo = new List<string>();
        public List<string> moviePosturo = new List<string>();
        public List<string> movieSinopsis = new List<string>();
        public Dictionary<string, List<string>> seatMapping = new Dictionary<string, List<string>>();
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        int count = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader movie = new StreamReader(source);
            string a;
            while ((a = movie.ReadLine()) != null)
            {
                string[] fix = a.Split(',');
                if (fix.Length == 3)
                {
                    movieTitulo.Add(fix[0]);
                    moviePosturo.Add(fix[1]);
                    movieSinopsis.Add(fix[2]);
                }
            }
            
            for (int i = 0; i < movieTitulo.Count; i++)
            {
                PictureBox picBox = new PictureBox();
                picBox.ImageLocation = moviePosturo[i];
                picBox.Size = new Size(200, 200);
                picBox.SizeMode = PictureBoxSizeMode.Zoom;
                picBox.Tag = i;
                picBox.Location = new Point((count % 4) * 200 + 30, (count / 4) * 290 + 120);
                picBox.Click += Picturebox_Click;
                this.panel_tampil.Controls.Add(picBox);
                count++;

                Label label = new Label();
                label.Text = movieTitulo[i];
                label.Font = new Font("Euclid Circular B SemiBold", 10, FontStyle.Bold);
                label.ForeColor = Color.Orange;
                label.AutoSize = true;
                label.TextAlign = ContentAlignment.MiddleCenter;
                if (i == 0)
                {
                    label.Location = new Point(picBox.Left + 60, picBox.Bottom + 10);
                }
                else if(i==1)
                {
                    label.Location = new Point(picBox.Left + 50, picBox.Bottom + 10);
                }
                else if (i==2)
                {
                    label.Location = new Point(picBox.Left + 33, picBox.Bottom + 10);
                }
                else if (i==4)
                {
                    label.Location = new Point(picBox.Left + 68, picBox.Bottom + 10);
                }
                else if(i == 5)
                {
                    label.Location = new Point(picBox.Left + 45, picBox.Bottom + 10);
                }
                else if(i == 6)
                {
                    label.Location = new Point(picBox.Left + 70, picBox.Bottom + 10);
                }
                else if (i==3)
                {
                    label.Location = new Point(picBox.Left - 10, picBox.Bottom + 10);
                }
                else if(i==7)
                {
                    label.Location = new Point(picBox.Left - 30, picBox.Bottom + 10);
                }
                
                this.panel_tampil.Controls.Add(label);


            }
        }
        private void Picturebox_Click(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            string nameFilm = picBox.Tag as string;
            int idx = (int)picBox.Tag;

            Form2 form2 = new Form2(idx, movieTitulo, moviePosturo, movieSinopsis, seatMapping);
            form2.picBox2 = picBox;
            form2.Dock = DockStyle.Fill;
            form2.TopLevel = false;
            form2.ControlBox = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            this.panel_tampil.Controls.Clear();
            this.panel_tampil.Controls.Add(form2);
            form2.Show();
        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
