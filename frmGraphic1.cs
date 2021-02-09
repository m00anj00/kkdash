using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static kkdash.WriteCSV;
using static kkdash.ReadCSV;

namespace kkdash
{
    public partial class frmGraphic1 : Form
    {
        public bool GettingPos = false;
        public string WhatsGettingPosX = "";
        public string WhatsGettingPosY = "";
        public static int lbNumber = 0;
        public static int lbLeft = 0;
        public static int lbAdd = 30;
        public static int lbTop = 30;
        public static int indexNum = 0;
        public static Label[] labels = new Label[10];
        public bool Editing = false;

        public frmGraphic1()
        {
            InitializeComponent();
        }

        private void frmGraphic_Load(object sender, EventArgs e)
        {
            //read the config file to be sure its correct:

            ReadTheCSV(1);

            try
            {
                if (Globals.P1BG != "")
                {
                    //background:
                    System.Drawing.Image img = System.Drawing.Image.FromFile(@Globals.flocation + "\\" + Globals.P1BG);
                    int picWidth = img.Width;
                    int picHeight = img.Height;
                    string picAspect=""; string imgAspect="";
                    double rat43 = 1.33; double rat169 = 1.78;
                    double picr = (double)img.Width / (double)img.Height;
                    double dispr = (double)Int32.Parse(Globals.p1DispWidth) / (double)Int32.Parse(Globals.p1DispHeight);
                    
                    if (Math.Round(picr,2) == rat43) { imgAspect = "4:3"; }
                    else if (Math.Round(picr, 2) == rat169) { imgAspect = "16:9"; }
                    else { imgAspect = Math.Round(picr, 2).ToString() + ":1";  }
                    
                    if (Math.Round(dispr, 2) == rat43) { picAspect = "4:3"; }
                    else if (Math.Round(dispr, 2) == rat169) { picAspect = "16:9"; }
                    else { picAspect = Math.Round( dispr , 2).ToString() + ":1"; }

                    if ((img.Height.ToString() != Globals.p1DispHeight)|| (img.Width.ToString() != Globals.p1DispWidth))
                    {
                        this.Text = "Panel 1 SCALED FROM: " + img.Width + " x " + img.Height + " (" + imgAspect + ")" +  " TO " + Globals.p1DispWidth + " x " + Globals.p2DispHeight + " (" + picAspect + ")";
                    }
                    this.Size = new System.Drawing.Size(Int32.Parse(Globals.p1DispWidth) + 10, Int32.Parse(Globals.p1DispHeight) + 250);
                    pictureBG.Size = new System.Drawing.Size(Int32.Parse(Globals.p1DispWidth) - 10, Int32.Parse(Globals.p1DispHeight) - 10);
                    pictureBG.SizeMode  = PictureBoxSizeMode.StretchImage;
                    pictureBG.Image = Image.FromFile(Globals.flocation + "\\" + Globals.P1BG);
                    //end background

                    PlaceControls();

                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBG_MouseClick(object sender, MouseEventArgs e)
        {
            if (GettingPos)
            {
                Image b = pictureBG.Image;
                //int x = b.Width * e.X / pictureBG.Width;
                //int y = b.Height * e.Y / pictureBG.Height;
                int zeroW = pictureBG.Width / 2;
                int zeroH = pictureBG.Height / 2;

                int x = e.X - zeroW;
                int y = zeroH - e.Y;
                WhatsGettingPosX = x.ToString();
                WhatsGettingPosY = y.ToString();
                Globals.mouseposX = x; //?
                Globals.mouseposY = y; //?
            }
        }

        private void PlaceControls()
        {
            lbTop = pictureBG.Height + lbTop;
            if (lbNumber < 6)
            {
                lbLeft = 30;
            }
            else
            {
                lbTop = 30;
                lbLeft = 400;
            }

            if (Globals.SpeedoShow == "1")
            {

                labels[lbNumber] = new Label();
                this.Controls.Add(labels[lbNumber]);
                labels[lbNumber].Text = "Speedo";
                labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                labels[lbNumber].Visible = true;
                labels[lbNumber].Font = new Font("Arial", 14, FontStyle.Bold);
                labels[lbNumber].BackColor = Color.White;
                lbTop += 30;
                labels[lbNumber].Click += new System.EventHandler(labels_Click);            }
                lbNumber += 1;
            if (Globals.TachoShow == "1")
            {
                labels[lbNumber] = new Label();
                this.Controls.Add(labels[lbNumber]);
                labels[lbNumber].Text = "Tacho";
                labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                labels[lbNumber].Visible = true;
                labels[lbNumber].Font = new Font("Arial", 14, FontStyle.Bold);
                labels[lbNumber].BackColor = Color.White;
                labels[lbNumber].Click += new System.EventHandler(labels_Click);
                lbTop += 30;
                lbNumber += 1;
            }

            if (Globals.BoostShow == "1")
            {
                labels[lbNumber] = new Label();
                this.Controls.Add(labels[lbNumber]);
                labels[lbNumber].Text = "Boost";
                labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                labels[lbNumber].Visible = true;
                labels[lbNumber].Font = new Font("Arial", 14, FontStyle.Bold);
                labels[lbNumber].BackColor = Color.White;
                labels[lbNumber].Click += new System.EventHandler(labels_Click);
                lbTop += 30;
                lbNumber += 1;
            }

            if (Globals.TempShow == "1")
            {
                labels[lbNumber] = new Label();
                this.Controls.Add(labels[lbNumber]);
                labels[lbNumber].Text = "Temp";
                labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                labels[lbNumber].Visible = true;
                labels[lbNumber].Font = new Font("Arial", 14, FontStyle.Bold);
                labels[lbNumber].BackColor = Color.White;
                labels[lbNumber].Click += new System.EventHandler(labels_Click);
                lbTop += 30;
                lbNumber += 1;
            }

            if (Globals.OilShow == "1")
            {
                labels[lbNumber] = new Label();
                this.Controls.Add(labels[lbNumber]);
                labels[lbNumber].Text = "Oil";
                labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                labels[lbNumber].Visible = true;
                labels[lbNumber].Font = new Font("Arial", 14, FontStyle.Bold);
                labels[lbNumber].BackColor = Color.White;
                labels[lbNumber].Click += new System.EventHandler(labels_Click);
                lbTop += 30;
                lbNumber += 1;
            }

            if (Globals.OilTShow == "1")
            {
                labels[lbNumber] = new Label();
                this.Controls.Add(labels[lbNumber]);
                labels[lbNumber].Text = "OilT";
                labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                labels[lbNumber].Visible = true;
                labels[lbNumber].Font = new Font("Arial", 14, FontStyle.Bold);
                labels[lbNumber].BackColor = Color.White;
                labels[lbNumber].Click += new System.EventHandler(labels_Click);
                lbTop += 30;
                lbNumber += 1;
            }

            if (Globals.FuelShow == "1")
            {
                labels[lbNumber] = new Label();
                this.Controls.Add(labels[lbNumber]);
                labels[lbNumber].Text = "Fuel";
                labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                labels[lbNumber].Visible = true;
                labels[lbNumber].Font = new Font("Arial", 14, FontStyle.Bold);
                labels[lbNumber].BackColor = Color.White;
                labels[lbNumber].Click += new System.EventHandler(labels_Click);
                lbTop += 30;
                lbNumber += 1;
            }

            if (Globals.FuelTShow == "1")
            {
                labels[lbNumber] = new Label();
                this.Controls.Add(labels[lbNumber]);
                labels[lbNumber].Text = "FuelT";
                labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                labels[lbNumber].Visible = true;
                labels[lbNumber].Font = new Font("Arial", 14, FontStyle.Bold);
                labels[lbNumber].BackColor = Color.White;
                labels[lbNumber].Click += new System.EventHandler(labels_Click);
                lbTop += 30;
                lbNumber += 1;
            }

            if (Globals.FuelPShow == "1")
            {
                labels[lbNumber] = new Label();
                this.Controls.Add(labels[lbNumber]);
                labels[lbNumber].Text = "FuelP";
                labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                labels[lbNumber].Visible = true;
                labels[lbNumber].Font = new Font("Arial", 14, FontStyle.Bold);
                labels[lbNumber].BackColor = Color.White;
                labels[lbNumber].Click += new System.EventHandler(labels_Click);
                lbTop += 30;
                lbNumber += 1;
            }

            if (Globals.User1Show == "1")
            {
                labels[lbNumber] = new Label();
                this.Controls.Add(labels[lbNumber]);
                labels[lbNumber].Text = "User1";
                labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                labels[lbNumber].Visible = true;
                labels[lbNumber].Font = new Font("Arial", 14, FontStyle.Bold);
                labels[lbNumber].BackColor = Color.White;
                labels[lbNumber].Click += new System.EventHandler(labels_Click);
                lbTop += 30;
                lbNumber += 1;
            }

            if (Globals.User2Show == "1")
            {
                labels[lbNumber] = new Label();
                this.Controls.Add(labels[lbNumber]);
                labels[lbNumber].Text = "User2";
                labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                labels[lbNumber].Visible = true;
                labels[lbNumber].Font = new Font("Arial", 14, FontStyle.Bold);
                labels[lbNumber].BackColor = Color.White;
                labels[lbNumber].Click += new System.EventHandler(labels_Click);
                lbTop += 30;
                lbNumber += 1;
            }

            if (Globals.User3Show == "1")
            {
                labels[lbNumber] = new Label();
                this.Controls.Add(labels[lbNumber]);
                labels[lbNumber].Text = "User3";
                labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                labels[lbNumber].Visible = true;
                labels[lbNumber].Font = new Font("Arial", 14, FontStyle.Bold);
                labels[lbNumber].BackColor = Color.White;
                labels[lbNumber].Click += new System.EventHandler(labels_Click);
                lbTop += 30;
                lbNumber += 1;
            }

            if (Globals.User4Show == "1")
            {
                labels[lbNumber] = new Label();
                this.Controls.Add(labels[lbNumber]);
                labels[lbNumber].Text = "User4";
                labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                labels[lbNumber].Visible = true;
                labels[lbNumber].Font = new Font("Arial", 14, FontStyle.Bold);
                labels[lbNumber].BackColor = Color.White;
                labels[lbNumber].Click += new System.EventHandler(labels_Click);
                lbTop += 30;
                lbNumber += 1;
            }
        }

        public void labels_Click(object sender, EventArgs e)
        {
            var clickedlabel = sender as Label;
            if (clickedlabel != null)
            {
                if (clickedlabel.BackColor == Color.Blue) { clickedlabel.BackColor = Color.White; } else { clickedlabel.BackColor = Color.Blue; }
                switch (clickedlabel.Text)
                {
                    case "Speedo":


                        break;

                    case "Tacho":


                        break;
                }
            }
        }
    }
}
