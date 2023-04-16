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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        Dictionary<string, List<string>> seatMapping = new Dictionary<string, List<string>>();
        private int idx;
        public PictureBox picBox2;
        private List<string> movieTitulo;
        private List<string> moviePosturo;
        private List<string> movieSinopsis;
        string showHour;
        string whatHour;
        private List<Button> btnList = new List<Button>();
        private List<Button> btnNotAvailable = new List<Button>();
        private List<Button> btnChose = new List<Button>();


        public Form3(int _idx, List<string> _movieTitulo, List<string> _moviePosturo, List<string> _movieSinopsis, string _showHour, string _whatHour, Dictionary<string, List<string>> _seatMapping)
        {
            InitializeComponent();
            idx = _idx;
            movieTitulo = _movieTitulo;
            moviePosturo = _moviePosturo;
            movieSinopsis = _movieSinopsis;
            showHour = _showHour;
            whatHour = _whatHour;
            seatMapping = _seatMapping;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Label screen = new Label();
            screen.Size = new Size(300, 55);
            screen.Location = new Point(380, 675);
            screen.Text = "Screen";
            screen.Font = new Font("Euclid Circular B SemiBold", 18, FontStyle.Bold);
            screen.ForeColor = Color.Orange;
            this.panel_show.Controls.Add(screen);

            Button btnClear = new Button();
            btnClear.Size = new Size(100, 50);
            btnClear.Location = new Point(700, 650);
            btnClear.BackColor = Color.Brown;
            btnClear.Text = "Reset";
            btnClear.Font = new Font("Euclid Circular B SemiBold", 10, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += new EventHandler(ButtonReset_Click);
            this.panel_show.Controls.Add(btnClear);

            Button btnReserved = new Button();
            btnReserved.Size = new Size(100, 50);
            btnReserved.Location = new Point(20, 650);
            btnReserved.BackColor = Color.MediumSeaGreen;
            btnReserved.Text = "Reserve";
            btnReserved.Font = new Font("Euclid Circular B SemiBold", 10, FontStyle.Bold);
            btnReserved.ForeColor = Color.White;
            btnReserved.FlatStyle = FlatStyle.Flat;
            btnReserved.FlatAppearance.BorderSize = 0;
            btnReserved.Click += new EventHandler(ButtonReserve_Click);
            this.panel_show.Controls.Add(btnReserved);

            Button btnBack = new Button();
            btnBack.Size = new Size(100, 50);
            btnBack.Location = new Point(20, 100);
            btnBack.BackColor = Color.Gold;
            btnBack.ForeColor = Color.Black;
            btnBack.Text = "Back";
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Euclid Circular B SemiBold", 10, FontStyle.Bold);
            btnBack.Click += new EventHandler(ButtonBack2_Click);
            this.panel_show.Controls.Add(btnBack);
            string movieHour = string.Format("{0} {1}", Convert.ToString(idx), whatHour);

            Label lblHour = new Label();
            lblHour.Text = movieTitulo[idx];
            if (movieTitulo[idx] == "The Conjuring: The Devil Made Me Do It")
            {
                lblHour.Location = new Point(200, 80);
            }
            else if (movieTitulo[idx] == "Harry Potter and the Deathly Hallows: Part 2")
            {
                lblHour.Location = new Point(180, 80);
            }
            else if (movieTitulo[idx] == "Insidious" || movieTitulo[idx] == "The Nun")
            {
                lblHour.Location = new Point(370, 80);
            }
            else if (movieTitulo[idx] == "IT: Chapter Two")
            {
                lblHour.Location = new Point(330, 80);
            }
            else if(movieTitulo[idx] == "Texas Chainsaw 3D")
            {
                lblHour.Location = new Point(315, 80);
            }
            else if (movieTitulo[idx] == "The Conjuring")
            {
                lblHour.Location = new Point(340, 80);
            }
            else
            {
                lblHour.Location = new Point(360, 80);
            }
            lblHour.Font = new Font("Euclid Circular B SemiBold", 18, FontStyle.Bold);
            lblHour.ForeColor = Color.Orange;
            lblHour.AutoSize = true;
            lblHour.TextAlign = ContentAlignment.MiddleCenter;
            this.panel_show.Controls.Add(lblHour);

            Label titulo = new Label();
            if (movieTitulo[idx] == "The Conjuring: The Devil Made Me Do It")
            {
                titulo.Location = new Point(340, lblHour.Bottom + 5);
            }
            else if (movieTitulo[idx] == "Harry Potter and the Deathly Hallows: Part 2")
            {
                titulo.Location = new Point(345, lblHour.Bottom + 5);
            }
            else
            {
                titulo.Location = new Point(350, lblHour.Bottom + 5);
            }
            titulo.Text = string.Format("Playing at {0}",showHour);
            titulo.Font = new Font("Euclid Circular B SemiBold", 14, FontStyle.Bold);
            titulo.ForeColor = Color.White;
            titulo.AutoSize = true;
            titulo.TextAlign = ContentAlignment.MiddleCenter;
            this.panel_show.Controls.Add(titulo);

            char column = 'A';
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(50, 50);
                    btn.Text = string.Format("{0}{1}", column, j + 1);
                    btn.Location = new Point(50 * j + 180, 50 * i + 150);
                    btn.Font = new Font("Euclid Circular B SemiBold", 10, FontStyle.Bold);
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.White;
                    this.panel_show.Controls.Add(btn);
                    this.btnList.Add(btn);
                    btn.Click += Button_Click;
                }
                column++;
            }


            if (seatMapping.ContainsKey(movieHour))
            {
                List<string> occupied = seatMapping[movieHour];
                foreach (string kursi in occupied)
                {
                    int idx = btnList.FindIndex(btn => btn.Text == kursi);
                    btnList[idx].BackColor = Color.Brown;
                }
            }
            else
            {
                List<string> occupied = new List<string>();
                Random rnd = new Random();
                int num = rnd.Next(0, 71);
                for (int i = 0; i < num; i++)
                {
                    int rndIndex = rnd.Next(0, 100);
                    btnList[rndIndex].BackColor = Color.Brown;
                    occupied.Add(btnList[rndIndex].Text);
                }
                seatMapping[movieHour] = occupied;
            }

            foreach (Button btn in btnList)
            {
                if (btn.BackColor != Color.Brown)
                {
                    btn.BackColor = Color.MediumSeaGreen;
                }
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button btnClicked = sender as Button;
            if (btnClicked.BackColor == Color.MediumSeaGreen)
            {
                btnClicked.BackColor = Color.Gold;
                btnChose.Add(btnClicked);

            }
            else if (btnClicked.BackColor == Color.Gold)
            {
                btnClicked.BackColor = Color.MediumSeaGreen;
                btnChose.Remove(btnClicked);
            }
            else if (btnClicked.BackColor == Color.Brown)
            {
                MessageBox.Show("This seat is unavailable!", "NA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonBack2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(idx, movieTitulo, moviePosturo, movieSinopsis, seatMapping);
            form2.Dock = DockStyle.Fill;
            form2.TopLevel = false;
            form2.ControlBox = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            this.panel_show.Controls.Clear();
            this.panel_show.Controls.Add(form2);
            form2.Show();
        }

        private void ButtonReserve_Click(object sender, EventArgs e)
        {
            List<string> notAvailableSeats = new List<string>();

            if (btnChose.Count == 0)
            {
                MessageBox.Show("No seats selected for reservation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string chooseSeat = string.Join(", ", btnChose.Select(btn => btn.Text));
                DialogResult result = MessageBox.Show(string.Format("Are you sure you want to reserve {0} ?", chooseSeat), "Order Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    MessageBox.Show("Success, Seats reserved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (Button btn in btnChose)
                    {
                        btn.BackColor = Color.Brown;
                    }
                    foreach (Button btn in btnList)
                    {
                        if (btn.BackColor == Color.Brown)
                        {
                            notAvailableSeats.Add(btn.Text);
                        }
                    }
                    string movieHour = string.Format("{0} {1}", Convert.ToString(idx), whatHour);
                    seatMapping[movieHour] = notAvailableSeats;
                    btnChose.Clear();

                }
                else
                {
                    MessageBox.Show("Action canceled", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (Button btn in btnChose)
                    {
                        btn.BackColor = Color.MediumSeaGreen;
                    }
                    btnChose.Clear();

                }
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            List<string> notAvailableSeats = new List<string>();
            DialogResult result = MessageBox.Show("Are you sure you want to clear all the seats and reset?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                foreach (Button btn in btnList)
                {
                    btn.BackColor = Color.MediumSeaGreen;
                    btnNotAvailable.Clear();
                    btnChose.Clear();
                }
            }
            else
            {
                MessageBox.Show("Action canceled", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            foreach (Button btn in btnList)
            {
                if (btn.BackColor == Color.Brown)
                {
                    notAvailableSeats.Add(btn.Text);
                }
            }
            string movieHour = string.Format("{0} {1}", Convert.ToString(idx), whatHour);
            seatMapping[movieHour] = notAvailableSeats;
        }
    }
}