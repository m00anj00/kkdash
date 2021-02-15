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
        public string[] gauges = { "Speedo", "Tacho", "Boost", "Temp", "Oil", "OilT", "Fuel", "FuelT", "FuelP", "Battery", "User1", "User2", "User3", "User4" };

        public int lbNumber = 0; public int lbTop = 0; public int lbFontGap = 20;
        public int lbval = 0; public int lbLeft = 0; public int lbFont = 12; public string Editing = "";
        public Label[] labels = new Label[35]; public Label lblPrompt; public Label lblPromptVal;

        public int startPosX { get; set; }  
        public int startPosY { get; set; }
        public int MousePosX { get; set; }  
        public int MousePosY { get; set; }
        public int NeedleLength { get; set; }

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
                    //place the background in the picturebox
                    drawthebackground();
                    lbval = pictureBG.Height;

                    //place each control name in a list below the image
                    foreach (string gauge in gauges)
                    {
                        if (lbNumber == 0) { lbLeft = 30; lbTop = lbval + lbFontGap; }
                        if (lbNumber == 8) { lbLeft = 150; lbTop = lbval + lbFontGap; }
                        if (lbNumber == 16) { lbLeft = 270; lbTop = lbval + lbFontGap; }
                        if (lbNumber == 24) { lbLeft = 390; lbTop = lbval + lbFontGap; }
                        lblAdd(gauge);
                    }

                    // create a new label for sequence:
                    lblPrompt = new Label(); this.Controls.Add(lblPrompt); lblPrompt.AutoSize = true;
                    lblPrompt.Location = new System.Drawing.Point(lbLeft + 130, pictureBG.Height + 10);
                    lblPrompt.Visible = true; lblPrompt.Font = new Font("Arial", 30, FontStyle.Bold);
                    lblPrompt.Text = "";

                    // create a new label for sequence:
                    lblPromptVal = new Label(); this.Controls.Add(lblPromptVal); lblPromptVal.AutoSize = true;
                    lblPromptVal.Location = new System.Drawing.Point(lbLeft + 220, pictureBG.Height + 50);
                    lblPromptVal.Visible = true; lblPromptVal.Font = new Font("Arial", 30, FontStyle.Bold);
                    lblPromptVal.Text = "";

                    //if a label is clicked it changes colour.  a new label states each action sequence.

                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cant continue.  error: " + ex.Message);
                this.Close();
            }
        }

        public void labels_Click(object sender, EventArgs e)
        {
            var clickedlabel = sender as Label;
            if (clickedlabel != null)
            {
                switch (clickedlabel.Text)
                {
                    case "Speedo": case "Tacho": case "Boost": case "Temp": case "Oil Press": case "Oil Temp": case "Fuel": case "Fuel Temp": case "Fuel Press": case "Battery": case "User1": case "User2": case "User3": case "User4":
                        {
                            if ((clickedlabel.BackColor == Color.White) && (Editing == ""))
                            {
                                clickedlabel.BackColor = Color.Blue;
                                Editing = clickedlabel.Text;
                                //------------------------------------------------- sequence of questions for coordinates ------------------------------------------------------
                                lblPrompt.BackColor = Color.Blue;
                                lblPromptVal.BackColor = Color.Blue;
                                lblPrompt.Text = "Click needle pivot point";
                                lblPromptVal.Text = "For " + clickedlabel.Text;
                                //continues in the pictureBG_clicked events
                            }
                            else
                            {
                                clickedlabel.BackColor = Color.White;
                                lblPrompt.Text = "";
                                lblPromptVal.Text = "";
                                Editing = "";
                            }
                            break;
                        }
                    case "Speedo Text": case "Tacho Text": case "Boost Text": case "Temp Text": case "Oil Press Text": case "Oil Temp Text": case "Fuel Text": case "Fuel Temp Text": case "Fuel Press Text": case "Battery Text": case "User1 Text": case "User2 Text": case "User3 Text": case "User4 Text":
                        {
                            if ((clickedlabel.BackColor == Color.Turquoise) && (Editing == ""))
                            {
                                clickedlabel.BackColor = Color.Blue;
                                Editing = clickedlabel.Text;
                                //------------------------------------------------- sequence of questions for coordinates ------------------------------------------------------
                            }
                            else
                            {
                                clickedlabel.BackColor = Color.Turquoise;
                                Editing = "";
                            }
                            break;
                        }
                }
            }
        }



        private void pictureBG_Click(object sender, EventArgs e)
        {
            //lblPrompt.BackColor = Color.Blue;
            //lblPrompt.Text = "Click the " + clickedlabel.Text + " needle pivot point";


        }


        private void lblAdd(string lblName)
        {
            switch (lblName)
            {
                case "Speedo":
                    {
                        if (Globals.SpeedoShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.White; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Speedo";
                        }
                        if (Globals.SpeedoTextShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.Turquoise; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Speedo Text";
                        }
                        break;
                    }
                case "Tacho":
                    {
                        if (Globals.TachoShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.White; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Tacho";
                        }
                        if (Globals.TachoTextShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.Turquoise; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Tacho Text";
                        }
                        break;
                    }
                case "Boost":
                    {
                        if (Globals.BoostShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.White; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Boost";
                        }
                        if (Globals.BoostTextShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.Turquoise; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Boost Text";
                        }
                        break;
                    }
                 case "Temp":
                    {
                        if (Globals.TempShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.White; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Temp";
                        }
                        if (Globals.TempTextShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.Turquoise; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Temp Text";
                        }
                        break;
                    }
                 case "Oil":
                    {
                        if (Globals.OilShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.White; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Oil Press";
                        }
                        if (Globals.OilTextShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.Turquoise; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Oil Press Text";
                        }
                        break;
                    }
                 case "OilT":
                    {
                        if (Globals.OilTShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.White; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Oil Temp";
                        }
                        if (Globals.OilTTextShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.Turquoise; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Oil Temp Text";
                        }
                        break;
                    }
                 case "Fuel":
                    {
                        if (Globals.FuelShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.White; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Fuel";
                        }
                        if (Globals.FuelTextShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.Turquoise; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Fuel Text";
                        }
                        break;
                    }
                 case "FuelT":
                    {
                        if (Globals.FuelTShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.White; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Fuel Temp";
                        }
                        if (Globals.FuelTTextShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.Turquoise; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Fuel Temp Text";
                        }
                        break;
                    }
                 case "FuelP":
                    {
                        if (Globals.FuelPShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.White; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Fuel Press";
                        }
                        if (Globals.FuelPTextShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.Turquoise; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Fuel Press Text";
                        }
                        break;
                    }
                 case "Battery":
                    {
                        if (Globals.BatteryShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.White; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Battery";
                        }
                        if (Globals.BatteryTextShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.Turquoise; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "Battery Text";
                        }
                        break;
                    }
                 case "User1":
                    {
                        if (Globals.User1Show == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.White; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "User1";
                        }
                        if (Globals.User1TextShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.Turquoise; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "User1 Text";
                        }
                        break;
                    }
                 case "User2":
                    {
                        if (Globals.User2Show == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.White; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "User2";
                        }
                        if (Globals.User2TextShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.Turquoise; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "User2 Text";
                        }
                        break;
                    }
                 case "User3":
                    {
                        if (Globals.User3Show == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.White; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "User3";
                        }
                        if (Globals.User3TextShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.Turquoise; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "User3 Text";
                        }
                        break;
                    }
                 case "User4":
                    {
                        if (Globals.User4Show == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.White; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "User4";
                        }
                        if (Globals.User4TextShow == "1")
                        {
                            lbNumber += 1;
                            lbTop += lbFontGap;
                            labels[lbNumber] = new Label(); this.Controls.Add(labels[lbNumber]); labels[lbNumber].BackColor = Color.Turquoise; labels[lbNumber].Click += new System.EventHandler(labels_Click);
                            labels[lbNumber].Location = new System.Drawing.Point(lbLeft, lbTop); labels[lbNumber].Visible = true; labels[lbNumber].Font = new Font("Arial", lbFont, FontStyle.Bold);
                            labels[lbNumber].AutoSize = true; labels[lbNumber].Text = "User4 Text";
                        }
                        break;
                    }
            }
        }

        private void drawthebackground()
        {
            //background:
            System.Drawing.Image img = System.Drawing.Image.FromFile(@Globals.flocation + "\\" + Globals.P1BG);
            int picWidth = img.Width; int picHeight = img.Height; string picAspect = ""; string imgAspect = ""; double rat43 = 1.33; double rat169 = 1.78;
            double picr = (double)img.Width / (double)img.Height; double dispr = (double)Int32.Parse(Globals.p1DispWidth) / (double)Int32.Parse(Globals.p1DispHeight);

            if (Math.Round(picr, 2) == rat43) { imgAspect = "4:3"; }
            else if (Math.Round(picr, 2) == rat169) { imgAspect = "16:9"; }
            else { imgAspect = Math.Round(picr, 2).ToString() + ":1"; }

            if (Math.Round(dispr, 2) == rat43) { picAspect = "4:3"; }
            else if (Math.Round(dispr, 2) == rat169) { picAspect = "16:9"; }
            else { picAspect = Math.Round(dispr, 2).ToString() + ":1"; }

            if ((img.Height.ToString() != Globals.p1DispHeight) || (img.Width.ToString() != Globals.p1DispWidth)) { this.Text = "Panel 1 SCALED FROM: " + img.Width + " x " + img.Height + " (" + imgAspect + ")" + " TO " + Globals.p1DispWidth + " x " + Globals.p2DispHeight + " (" + picAspect + ")"; }
            this.Size = new System.Drawing.Size(Int32.Parse(Globals.p1DispWidth) + 10, Int32.Parse(Globals.p1DispHeight) + 250);
            pictureBG.Size = new System.Drawing.Size(Int32.Parse(Globals.p1DispWidth) - 10, Int32.Parse(Globals.p1DispHeight) - 10);
            pictureBG.SizeMode = PictureBoxSizeMode.StretchImage; pictureBG.Image = Image.FromFile(Globals.flocation + "\\" + Globals.P1BG);
            //end background
        }

    }
}