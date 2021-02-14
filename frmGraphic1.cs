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
        public static int lbval = 0;
        public static int lbtxtval = 0;
        public static int lbFont = 10;
        public static int lbFontGap = 22;

        public static int lbLeft = 30;
        public static int lbAdd = 30;
        public static int lbTop = 30;
        public static int indexNum = 0;

        public static string mouseXY = "";
        public static int mouseX = 0;
        public static int mouseY = 0;

        public static Label[] labels = new Label[35];
        public static Label[] lblX = new Label[35];
        public static Label[] lblY = new Label[35];
        public static Label[] lblPrompt = new Label[35];

        public string Editing = "";

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
                    string picAspect = ""; string imgAspect = "";
                    double rat43 = 1.33; double rat169 = 1.78;
                    double picr = (double)img.Width / (double)img.Height;
                    double dispr = (double)Int32.Parse(Globals.p1DispWidth) / (double)Int32.Parse(Globals.p1DispHeight);

                    if (Math.Round(picr, 2) == rat43) { imgAspect = "4:3"; }
                    else if (Math.Round(picr, 2) == rat169) { imgAspect = "16:9"; }
                    else { imgAspect = Math.Round(picr, 2).ToString() + ":1"; }

                    if (Math.Round(dispr, 2) == rat43) { picAspect = "4:3"; }
                    else if (Math.Round(dispr, 2) == rat169) { picAspect = "16:9"; }
                    else { picAspect = Math.Round(dispr, 2).ToString() + ":1"; }

                    if ((img.Height.ToString() != Globals.p1DispHeight) || (img.Width.ToString() != Globals.p1DispWidth))
                    {
                        this.Text = "Panel 1 SCALED FROM: " + img.Width + " x " + img.Height + " (" + imgAspect + ")" + " TO " + Globals.p1DispWidth + " x " + Globals.p2DispHeight + " (" + picAspect + ")";
                    }
                    this.Size = new System.Drawing.Size(Int32.Parse(Globals.p1DispWidth) + 10, Int32.Parse(Globals.p1DispHeight) + 250);
                    pictureBG.Size = new System.Drawing.Size(Int32.Parse(Globals.p1DispWidth) - 10, Int32.Parse(Globals.p1DispHeight) - 10);
                    pictureBG.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBG.Image = Image.FromFile(Globals.flocation + "\\" + Globals.P1BG);
                    //end background

                    PlaceControls();

                    //lblX lblY lblPrompt
                    lblPrompt[0] = new Label();
                    this.Controls.Add(lblPrompt[0]);
                    lblPrompt[0].Location = new System.Drawing.Point(lbLeft + 130, pictureBG.Height + 10);
                    lblPrompt[0].Visible = true;
                    lblPrompt[0].Font = new Font("Arial", 12, FontStyle.Bold);
                    lblPrompt[0].AutoSize = true;

                    //lblX lblY lblPrompt
                    lblX[0] = new Label();
                    this.Controls.Add(lblX[0]);
                    lblX[0].Location = new System.Drawing.Point(lbLeft + 300, pictureBG.Height + 10);
                    lblX[0].Visible = true;
                    lblX[0].Font = new Font("Arial", 12, FontStyle.Bold);


                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No background.  cant continue.  error: " + ex.Message);
                this.Close();
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

        private string[] gauges = { "Speedo", "Tacho", "Boost", "Temp", "Oil", "OilT", "Fuel", "FuelT", "FuelP", "Battery", "User1", "User2", "User3", "User4" };

        private void PlaceControls()
        {
            lbval = pictureBG.Height;

            foreach (string gauge in gauges)
            {
                if (lbNumber == 0)
                {
                    lbLeft = 30;
                    lbTop = lbval + lbFontGap;
                }
                if (lbNumber == 8)
                {
                    lbLeft = 150;
                    lbTop = lbval + lbFontGap;
                }
                if (lbNumber == 16)
                {
                    lbLeft = 270;
                    lbTop = lbval + lbFontGap;
                }
                if (lbNumber == 24)
                {
                    lbLeft = 390;
                    lbTop = lbval + lbFontGap;
                }
                addlabel(gauge);
            }
        }

        private void addlabel(string lblName)
        {
            switch (lblName)
            {
                case "Speedo":
                    {
                        if (Globals.SpeedoShow == "1")
                        {

                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "Speedo";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].BackColor = Color.White;
                            lbTop += lbFontGap;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                        }
                        lbNumber += 1;
                        if (Globals.SpeedoTextShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "SpeedoText";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Regular);
                            labels[lbNumber].BackColor = Color.Turquoise;
                            lbTop += lbFontGap;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                        }
                        lbNumber += 1;
                        break;
                    }

                case "Tacho":
                    {
                        if (Globals.TachoShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "Tacho";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].BackColor = Color.White;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        if (Globals.TachoTextShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "TachoText";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Regular);
                            labels[lbNumber].BackColor = Color.Turquoise;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        break;
                    }
                case "Boost":
                    {
                        if (Globals.BoostShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "Boost";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].BackColor = Color.White;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        if (Globals.BoostTextShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "BoostText";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Regular);
                            labels[lbNumber].BackColor = Color.Turquoise;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        break;
                    }
                case "Temp":
                    {
                        if (Globals.TempShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "Temp";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].BackColor = Color.White;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        if (Globals.TempTextShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "TempText";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Regular);
                            labels[lbNumber].BackColor = Color.Turquoise;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        break;
                    }
                case "Oil":
                    {
                        if (Globals.OilShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "Oil";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].BackColor = Color.White;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        if (Globals.OilTextShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "OilText";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Regular);
                            labels[lbNumber].BackColor = Color.Turquoise;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        break;
                    }
                case "OilT":
                    {
                        if (Globals.OilTShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "OilT";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].BackColor = Color.White;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        if (Globals.OilTTextShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "OilTText";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Regular);
                            labels[lbNumber].BackColor = Color.Turquoise;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        break;
                    }
                case "Fuel":
                    {
                        if (Globals.FuelShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "Fuel";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].BackColor = Color.White;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        if (Globals.FuelTextShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "FuelText";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Regular);
                            labels[lbNumber].BackColor = Color.Turquoise;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        break;
                    }
                case "FuelT":
                    {
                        if (Globals.FuelTShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "FuelT";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].BackColor = Color.White;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        if (Globals.FuelTTextShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "FuelTText";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Regular);
                            labels[lbNumber].BackColor = Color.Turquoise;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        break;
                    }
                case "FuelP":
                    {
                        if (Globals.FuelPShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "FuelP";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].BackColor = Color.White;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        if (Globals.FuelPTextShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "FuelPText";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Regular);
                            labels[lbNumber].BackColor = Color.Turquoise;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        break;
                    }
                case "Battery":
                    {
                        if (Globals.BatteryShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "Battery";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].BackColor = Color.White;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        if (Globals.BatteryTextShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "BatteryText";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Regular);
                            labels[lbNumber].BackColor = Color.Turquoise;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        break;
                    }
                case "User1":
                    {
                        if (Globals.User1Show == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "User1";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].BackColor = Color.White;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        if (Globals.User1TextShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "User1Text";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Regular);
                            labels[lbNumber].BackColor = Color.Turquoise;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        break;
                    }
                case "User2":
                    {
                        if (Globals.User2Show == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "User2";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].BackColor = Color.White;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        if (Globals.User2TextShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "User2Text";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Regular);
                            labels[lbNumber].BackColor = Color.Turquoise;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        break;
                    }
                case "User3":
                    {
                        if (Globals.User3Show == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "User3";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].BackColor = Color.White;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        if (Globals.User3TextShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "User3Text";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Regular);
                            labels[lbNumber].BackColor = Color.Turquoise;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        break;
                    }
                case "User4":
                    {
                        if (Globals.User4Show == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "User4";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].BackColor = Color.White;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        if (Globals.User4TextShow == "1")
                        {
                            labels[lbNumber] = new Label();
                            this.Controls.Add(labels[lbNumber]);
                            labels[lbNumber].Text = "User4Text";
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop);
                            labels[lbNumber].Visible = true;
                            labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Regular);
                            labels[lbNumber].BackColor = Color.Turquoise;
                            labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            lbTop += lbFontGap;
                            lbNumber += 1;
                        }
                        break;
                    }
            }
        }

        public void labels_Click(object sender, EventArgs e)
        {
            var clickedlabel = sender as Label;
            if (clickedlabel != null)
            {
                switch (clickedlabel.Text)
                {
                    case "Speedo": case "Tacho": case "Boost": case "Temp": case "Oil": case "OilT": case "Fuel": case "FuelT":
                    case "FuelP": case "Battery": case "User1": case "User2": case "User3": case "User4":
                        {
                            if ((clickedlabel.BackColor == Color.White) && (Editing == ""))
                            {
                                clickedlabel.BackColor = Color.Blue;
                                Editing = clickedlabel.Text;
                                lblPrompt[0].Text = Editing + " Start point: ";
                            }
                            else
                            {
                                clickedlabel.BackColor = Color.White;
                            }
                            break;
                        }
                    case "SpeedoText": case "TachoText": case "BoostText": case "TempText": case "OilText": case "OilTText": case "FuelText": case "FuelTText":
                    case "FuelPText": case "BatteryText": case "User1Text": case "User2Text": case "User3Text": case "User4Text":
                        {
                            if ((clickedlabel.BackColor == Color.Turquoise) && (Editing == ""))
                            {
                                clickedlabel.BackColor = Color.Blue;
                                Editing = clickedlabel.Text;
                                lblPrompt[0].Text = Editing + " Start point: ";
                            }
                            else
                            {
                                clickedlabel.BackColor = Color.Turquoise;
                            }
                            break;
                        }
                }
            }
        }

        private void pictureBG_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs != null)
            {
                mouseX = mouseEventArgs.X - (pictureBG.Width / 2);
                mouseY = (pictureBG.Height / 2) - mouseEventArgs.Y;
                mouseXY = mouseX + "," + mouseY;
                lblX[0].Text = mouseXY;
                startXY(Editing, mouseX, mouseY);
            }
        }

        private void startXY(string gaugename, int X, int Y)
        {
            switch (gaugename)
            {
                case "Speedo":
                    Globals.SpeedoNeedleX = X.ToString();
                    Globals.SpeedoNeedleY = Y.ToString();
                    break;
            }
            Editing = "";
        }

        private void endXY(string gaugename, int X)
        {
            switch (gaugename)
            {
                case "Speedo":
                    Globals.SpeedoNeedleLength = X.ToString();
                    break;
            }
            Editing = "";
        }    
    }
}
