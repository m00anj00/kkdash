using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static kkdash.WriteCSV;
using static kkdash.ReadCSV;
using System.Threading;

namespace kkdash
{
    public partial class frmGraphic1 : Form
    {
        public string[] gauges = { "Speedo", "Tacho", "Boost", "Temp", "Oil", "OilT", "Fuel", "FuelT", "FuelP", "Battery", "User1", "User2", "User3", "User4" };

        public int lbNumber = 0; public int lbTop = 0; public int lbFontGap = 20; public string dir = "";
        public int lbval = 0; public int lbLeft = 0; public int lbFont = 12; public string Editing = ""; public int stage = 0;
        public Label[] labels = new Label[35]; public Label lblPrompt; public Label lblPromptVal; public string YesNo = "No";
        public string offSetLow = ""; public string offSetHigh = ""; public int lowpointX; public int lowpointY; public int highpointX; public int highpointY;
        public int tempXlen; public int tempYlen; public int tempXlow; public int tempYlow; public int tempXhigh; public int tempYhigh;
        public int lpX; public int lpY;
        public bool showCross = true;
        public int startPosX; public int startPosY; public int MousePosX; public int MousePosY; public int NeedleLength;
        public string movingCentre = "";

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
                        if (lbNumber == 8) { lbLeft = 160; lbTop = lbval + lbFontGap; }
                        if (lbNumber == 16) { lbLeft = 290; lbTop = lbval + lbFontGap; }
                        if (lbNumber == 24) { lbLeft = 420; lbTop = lbval + lbFontGap; }
                        lblAdd(gauge);
                    }

                    // create a new label for sequence:
                    lblPrompt = new Label(); this.Controls.Add(lblPrompt); lblPrompt.AutoSize = true;
                    lblPrompt.Location = new System.Drawing.Point(lbLeft + 130, pictureBG.Height + 10);
                    lblPrompt.Visible = true; lblPrompt.Font = new Font("Arial", 20, FontStyle.Bold);
                    lblPrompt.Text = "";

                    // create a new label for sequence:
                    lblPromptVal = new Label(); this.Controls.Add(lblPromptVal); lblPromptVal.AutoSize = true;
                    lblPromptVal.Location = new System.Drawing.Point(lbLeft + 130, pictureBG.Height + 50);
                    lblPromptVal.Visible = true; lblPromptVal.Font = new Font("Arial", 20, FontStyle.Bold);
                    lblPromptVal.Text = "";

                    txtTopVal.Left = lbLeft + 220;
                    txtTopVal.Top = pictureBG.Height + 100;
                    txtTopVal.Visible = false;

                    btnSave.Left = pictureBG.Width + 20;
                    btnSave.Top = 0;
                    pnlSymbols.Left = pictureBG.Width + 20;
                    pnlSymbols.Top = 50;

                    //get the symbol icons
                    populateSymbols("Read");
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

        private void populateSymbols(string ClearReadSave)
        {
            if (ClearReadSave == "clear")
            {
                if (Globals.symSeatLeft == "1") { Seat1.Image = Image.FromFile(Globals.flocation + "\\symbols\\seats\\seat1-3.png"); Seat1.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { Seat1.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symSeatRight == "1") { Seat2.Image = Image.FromFile(Globals.flocation + "\\symbols\\seats\\seat2-3.png"); Seat1.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { Seat2.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symDoor == "1") { door.Image = Image.FromFile(Globals.flocation + "\\symbols\\door\\both.png"); door.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { door.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symBonnet == "1") { bonnet.Image = Image.FromFile(Globals.flocation + "\\symbols\\door\\bonnet.png"); bonnet.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { bonnet.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symBoot == "1") { boot.Image = Image.FromFile(Globals.flocation + "\\symbols\\door\\boot.png"); boot.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { boot.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symDemister == "1") { demister.Image = Image.FromFile(Globals.flocation + "\\symbols\\info\\demister.png"); demister.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { demister.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symBattery == "1") { battery.Image = Image.FromFile(Globals.flocation + "\\symbols\\info\\battery.png"); battery.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { battery.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symFuel == "1") { fuel.Image = Image.FromFile(Globals.flocation + "\\symbols\\info\\fuel.png"); fuel.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { fuel.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symOil == "1") { oil.Image = Image.FromFile(Globals.flocation + "\\symbols\\info\\oil.png"); oil.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { oil.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symTyre == "1") { tyre.Image = Image.FromFile(Globals.flocation + "\\symbols\\info\\tyre.png"); tyre.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { tyre.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symWasher == "1") { washer.Image = Image.FromFile(Globals.flocation + "\\symbols\\info\\washer.png"); washer.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { washer.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symWiperInt == "1") { wiperint.Image = Image.FromFile(Globals.flocation + "\\symbols\\info\\wiper-int.png"); wiperint.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { wiperint.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symIndLeft == "1") { indleft.Image = Image.FromFile(Globals.flocation + "\\symbols\\indicators\\ind-left.png"); indleft.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { indleft.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symIndLeft == "1") { indright.Image = Image.FromFile(Globals.flocation + "\\symbols\\indicators\\ind-right.png"); indright.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { indright.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symHazards == "1") { hazards.Image = Image.FromFile(Globals.flocation + "\\symbols\\hazard\\hazards-on.png"); hazards.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { hazards.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symSpanner == "1") { spanner.Image = Image.FromFile(Globals.flocation + "\\symbols\\hazard\\spanner.png"); spanner.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { spanner.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symTemp == "1") { temp.Image = Image.FromFile(Globals.flocation + "\\symbols\\hazard\\temp.png"); temp.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { temp.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symSeatbelt == "1") { seatbelts.Image = Image.FromFile(Globals.flocation + "\\symbols\\seatbelts\\all.png"); seatbelts.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { seatbelts.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symSidelights == "1") { sidelight.Image = Image.FromFile(Globals.flocation + "\\symbols\\lights\\sidelights.png"); sidelight.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { sidelight.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symHeadlights == "1") { highbeam.Image = Image.FromFile(Globals.flocation + "\\symbols\\lights\\headlights.png"); highbeam.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { highbeam.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symFullbeam == "1") { fullbeam.Image = Image.FromFile(Globals.flocation + "\\symbols\\lights\\fullbeam.png"); fullbeam.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { fullbeam.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symSpotlights == "1") { spotlight.Image = Image.FromFile(Globals.flocation + "\\symbols\\lights\\spotlights.png"); spotlight.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { spotlight.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
                if (Globals.symFoglights == "1") { foglight.Image = Image.FromFile(Globals.flocation + "\\symbols\\lights\\foglight.png"); foglight.SizeMode = PictureBoxSizeMode.StretchImage; }
                else { foglight.Image = Image.FromFile(Globals.flocation + "\\symbols\\none.png"); }
            }

            if (ClearReadSave == "read")
            {
            }
            if (ClearReadSave == "save")
            {
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
                                if ((clickedlabel.Text == "Speedo") && (Globals.SpeedoNeedleType == "gauge")) { lblPrompt.Text = "Click needle pivot point"; movingCentre = "gauge"; }
                                if ((clickedlabel.Text == "Speedo") && ((Globals.SpeedoNeedleType == "barH") || (Globals.SpeedoNeedleType == "barV"))) { lblPrompt.Text = "Click bar TOP LEFT"; movingCentre = "bar"; }
                                if ((clickedlabel.Text == "Tacho") && (Globals.TachoNeedleType == "gauge")) { lblPrompt.Text = "Click needle pivot point"; movingCentre = "gauge"; }
                                if ((clickedlabel.Text == "Tacho") && ((Globals.TachoNeedleType == "barH") || (Globals.TachoNeedleType == "barV"))) { lblPrompt.Text = "Click bar TOP LEFT"; movingCentre = "bar"; }
                                if ((clickedlabel.Text == "Boost") && (Globals.BoostNeedleType == "gauge")) { lblPrompt.Text = "Click needle pivot point"; movingCentre = "gauge"; }
                                if ((clickedlabel.Text == "Boost") && ((Globals.BoostNeedleType == "barH") || (Globals.BoostNeedleType == "barV"))) { lblPrompt.Text = "Click bar TOP LEFT"; movingCentre = "bar"; }
                                if ((clickedlabel.Text == "Temp") && (Globals.TempNeedleType == "gauge")) { lblPrompt.Text = "Click needle pivot point"; movingCentre = "gauge"; }
                                if ((clickedlabel.Text == "Temp") && ((Globals.TempNeedleType == "barH") || (Globals.TempNeedleType == "barV"))) { lblPrompt.Text = "Click bar TOP LEFT"; movingCentre = "bar"; }
                                if ((clickedlabel.Text == "Oil Press") && (Globals.OilNeedleType == "gauge")) { lblPrompt.Text = "Click needle pivot point"; movingCentre = "gauge"; }
                                if ((clickedlabel.Text == "Oil Press") && ((Globals.OilNeedleType == "barH") || (Globals.OilNeedleType == "barV"))) { lblPrompt.Text = "Click bar TOP LEFT"; movingCentre = "bar"; }
                                if ((clickedlabel.Text == "Oil Temp") && (Globals.OilTNeedleType == "gauge")) { lblPrompt.Text = "Click needle pivot point"; movingCentre = "gauge"; }
                                if ((clickedlabel.Text == "Oil Temp") && ((Globals.OilTNeedleType == "barH") || (Globals.OilTNeedleType == "barV"))) { lblPrompt.Text = "Click bar TOP LEFT"; movingCentre = "bar"; }
                                if ((clickedlabel.Text == "Fuel") && (Globals.FuelNeedleType == "gauge")) { lblPrompt.Text = "Click needle pivot point"; movingCentre = "gauge"; }
                                if ((clickedlabel.Text == "Fuel") && ((Globals.FuelNeedleType == "barH") || (Globals.FuelNeedleType == "barV"))) { lblPrompt.Text = "Click bar TOP LEFT"; movingCentre = "bar"; }
                                if ((clickedlabel.Text == "Fuel Temp") && (Globals.FuelTNeedleType == "gauge")) { lblPrompt.Text = "Click needle pivot point"; movingCentre = "gauge"; }
                                if ((clickedlabel.Text == "Fuel Temp") && ((Globals.FuelTNeedleType == "barH") || (Globals.FuelTNeedleType == "barV"))) { lblPrompt.Text = "Click bar TOP LEFT"; movingCentre = "bar"; }
                                if ((clickedlabel.Text == "Fuel Press") && (Globals.FuelPNeedleType == "gauge")) { lblPrompt.Text = "Click needle pivot point"; movingCentre = "gauge"; }
                                if ((clickedlabel.Text == "Fuel Press") && ((Globals.FuelPNeedleType == "barH") || (Globals.FuelPNeedleType == "barV"))) { lblPrompt.Text = "Click bar TOP LEFT"; movingCentre = "bar"; }
                                if ((clickedlabel.Text == "Battery") && (Globals.BatteryNeedleType == "gauge")) { lblPrompt.Text = "Click needle pivot point"; movingCentre = "gauge"; }
                                if ((clickedlabel.Text == "Battery") && ((Globals.BatteryNeedleType == "barH") || (Globals.BatteryNeedleType == "barV"))) { lblPrompt.Text = "Click bar TOP LEFT"; movingCentre = "bar"; }
                                if ((clickedlabel.Text == "User1") && (Globals.User1NeedleType == "gauge")) { lblPrompt.Text = "Click needle pivot point"; movingCentre = "gauge"; }
                                if ((clickedlabel.Text == "User1") && ((Globals.User1NeedleType == "barH") || (Globals.User1NeedleType == "barV"))) { lblPrompt.Text = "Click bar TOP LEFT"; movingCentre = "bar"; }
                                if ((clickedlabel.Text == "User2") && (Globals.User2NeedleType == "gauge")) { lblPrompt.Text = "Click needle pivot point"; movingCentre = "gauge"; }
                                if ((clickedlabel.Text == "User2") && ((Globals.User2NeedleType == "barH") || (Globals.User2NeedleType == "barV"))) { lblPrompt.Text = "Click bar TOP LEFT"; movingCentre = "bar"; }
                                if ((clickedlabel.Text == "User3") && (Globals.User3NeedleType == "gauge")) { lblPrompt.Text = "Click needle pivot point"; movingCentre = "gauge"; }
                                if ((clickedlabel.Text == "User3") && ((Globals.User3NeedleType == "barH") || (Globals.User3NeedleType == "barV"))) { lblPrompt.Text = "Click bar TOP LEFT"; movingCentre = "bar"; }
                                if ((clickedlabel.Text == "User4") && (Globals.User4NeedleType == "gauge")) { lblPrompt.Text = "Click needle pivot point"; movingCentre = "gauge"; }
                                if ((clickedlabel.Text == "User4") && ((Globals.User4NeedleType == "barH") || (Globals.User4NeedleType == "barV"))) { lblPrompt.Text = "Click bar TOP LEFT"; movingCentre = "bar"; }


                                lblPrompt.BackColor = Color.Blue;
                                lblPromptVal.BackColor = Color.Blue;
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
                                movingCentre = "text";
                                clickedlabel.BackColor = Color.WhiteSmoke;
                                Editing = clickedlabel.Text;

                                lblPrompt.Location = new System.Drawing.Point(lbLeft + 200, pictureBG.Height + 10);
                                lblPrompt.Visible = true; lblPrompt.Font = new Font("Arial", 20, FontStyle.Bold);
                                lblPrompt.Visible = true;

                                lblPromptVal.Location = new System.Drawing.Point(lbLeft + 200, pictureBG.Height + 50);
                                lblPromptVal.Visible = true; lblPromptVal.Font = new Font("Arial", 20, FontStyle.Bold);
                                lblPromptVal.Visible = true;

                                //1st step. bar position
                                lblPrompt.Text = "Click the CENTER point";
                                lblPromptVal.Text = "For " + Editing;

                            }
                            else
                            {
                                clickedlabel.BackColor = Color.Turquoise;
                                Editing = "";

                                lblPrompt.Visible = false;
                                lblPromptVal.Visible = false;

                                //1st step. bar position
                                lblPrompt.Text = "";
                                lblPromptVal.Text = "";
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
                switch (Editing)
                {
                    case "Speedo": case "Tacho": case "Boost": case "Temp": case "Oil Press": case "Oil Temp": case "Fuel": case "Fuel Temp": case "Fuel Press": case "Battery": case "User1": case "User2": case "User3": case "User4":
                        {
                            switch (lblPrompt.Text)
                            {
                                //=================================================================================== Gauge ==========================================================================================================
                                case "Click needle pivot point":
                                    {
                                        if (stage == 0)
                                        {
                                            if (showCross == true)
                                            {
                                                //1st step. pivot center
                                                startPosX = mouseEventArgs.X;
                                                startPosY = mouseEventArgs.Y;

                                                if (Editing == "Speedo") { Globals.SpeedoNeedleX = (startPosX - (pictureBG.Width / 2)).ToString(); Globals.SpeedoNeedleY = ((pictureBG.Height / 2) - MousePosY).ToString(); }
                                                if (Editing == "Tacho") { Globals.TachoNeedleX = (startPosX - (pictureBG.Width / 2)).ToString(); Globals.TachoNeedleY = ((pictureBG.Height / 2) - MousePosY).ToString(); }
                                                if (Editing == "Boost") { Globals.BoostNeedleX = (startPosX - (pictureBG.Width / 2)).ToString(); Globals.BoostNeedleY = ((pictureBG.Height / 2) - MousePosY).ToString(); }
                                                if (Editing == "Temp") { Globals.TempNeedleX = (startPosX - (pictureBG.Width / 2)).ToString(); Globals.TempNeedleY = ((pictureBG.Height / 2) - MousePosY).ToString(); }
                                                if (Editing == "Oil Press") { Globals.OilNeedleX = (startPosX - (pictureBG.Width / 2)).ToString(); Globals.OilNeedleY = ((pictureBG.Height / 2) - MousePosY).ToString(); }
                                                if (Editing == "Oil Temp") { Globals.OilTNeedleX = (startPosX - (pictureBG.Width / 2)).ToString(); Globals.OilTNeedleY = ((pictureBG.Height / 2) - MousePosY).ToString(); }
                                                if (Editing == "Fuel") { Globals.FuelNeedleX = (startPosX - (pictureBG.Width / 2)).ToString(); Globals.FuelNeedleY = ((pictureBG.Height / 2) - MousePosY).ToString(); }
                                                if (Editing == "Fuel Temp") { Globals.FuelTNeedleX = (startPosX - (pictureBG.Width / 2)).ToString(); Globals.FuelTNeedleY = ((pictureBG.Height / 2) - MousePosY).ToString(); }
                                                if (Editing == "Fuel Press") { Globals.FuelPNeedleX = (startPosX - (pictureBG.Width / 2)).ToString(); Globals.FuelPNeedleY = ((pictureBG.Height / 2) - MousePosY).ToString(); }
                                                if (Editing == "Battery") { Globals.BatteryNeedleX = (startPosX - (pictureBG.Width / 2)).ToString(); Globals.BatteryNeedleY = ((pictureBG.Height / 2) - MousePosY).ToString(); }
                                                if (Editing == "User1") { Globals.User1NeedleX = (startPosX - (pictureBG.Width / 2)).ToString(); Globals.User1NeedleY = ((pictureBG.Height / 2) - MousePosY).ToString(); }
                                                if (Editing == "User2") { Globals.User2NeedleX = (startPosX - (pictureBG.Width / 2)).ToString(); Globals.User2NeedleY = ((pictureBG.Height / 2) - MousePosY).ToString(); }
                                                if (Editing == "User3") { Globals.User3NeedleX = (startPosX - (pictureBG.Width / 2)).ToString(); Globals.User3NeedleY = ((pictureBG.Height / 2) - MousePosY).ToString(); }
                                                if (Editing == "User4") { Globals.User4NeedleX = (startPosX - (pictureBG.Width / 2)).ToString(); Globals.User4NeedleY = ((pictureBG.Height / 2) - MousePosY).ToString(); }

                                                //draw lines
                                                using (Graphics p = pictureBG.CreateGraphics())
                                                {
                                                    // Draw next line and...
                                                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX, startPosY - 300);
                                                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX, startPosY + 300);
                                                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX - 300, startPosY);
                                                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX + 300, startPosY);
                                                }
                                                pnlDirections.Left = lbLeft + 250;
                                                pnlDirections.Top = pictureBG.Height + 100;
                                                pnlDirections.Visible = true;
                                            }                                        }


                                        break;
                                    }
                                case "Click the needle length":
                                    {
                                        //2nd step. needle length
                                        if (stage == 1)
                                        {
                                            if (mouseEventArgs.X > (startPosX + 20))
                                            {
                                                dir = "right";
                                                using (Graphics p = pictureBG.CreateGraphics())
                                                {
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY - 300);
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY + 300);
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX - 300, startPosY);
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX + 300, startPosY);

                                                    tempXlen = mouseEventArgs.X; tempYlen = startPosY;
                                                    p.DrawLine(Pens.Blue, startPosX, startPosY, mouseEventArgs.X, startPosY);

                                                }
                                                switch (Editing)
                                                {
                                                    case "Speedo": { Globals.SpeedoNeedleLength = ((mouseEventArgs.X - startPosX) * 10).ToString(); } break;
                                                    case "Tacho": { Globals.TachoNeedleLength = ((mouseEventArgs.X - startPosX) * 10).ToString(); } break;
                                                    case "Boost": { Globals.BoostNeedleLength = ((mouseEventArgs.X - startPosX) * 10).ToString(); } break;
                                                    case "Temp": { Globals.TempNeedleLength = ((mouseEventArgs.X - startPosX) * 10).ToString(); } break;
                                                    case "Oil Press": { Globals.OilNeedleLength = ((mouseEventArgs.X - startPosX) * 10).ToString(); } break;
                                                    case "Oil Temp": { Globals.OilTNeedleLength = ((mouseEventArgs.X - startPosX) * 10).ToString(); } break;
                                                    case "Fuel": { Globals.FuelNeedleLength = ((mouseEventArgs.X - startPosX) * 10).ToString(); } break;
                                                    case "Fuel Temp": { Globals.FuelTNeedleLength = ((mouseEventArgs.X - startPosX) * 10).ToString(); } break;
                                                    case "Fuel Press": { Globals.FuelPNeedleLength = ((mouseEventArgs.X - startPosX) * 10).ToString(); } break;
                                                    case "Battery": { Globals.BatteryNeedleLength = ((mouseEventArgs.X - startPosX) * 10).ToString(); } break;
                                                    case "User1": { Globals.User1NeedleLength = ((mouseEventArgs.X - startPosX) * 10).ToString(); } break;
                                                    case "User2": { Globals.User2NeedleLength = ((mouseEventArgs.X - startPosX) * 10).ToString(); } break;
                                                    case "User3": { Globals.User3NeedleLength = ((mouseEventArgs.X - startPosX) * 10).ToString(); } break;
                                                    case "User4": { Globals.User4NeedleLength = ((mouseEventArgs.X - startPosX) * 10).ToString(); } break;
                                                }
                                            }
                                            if (mouseEventArgs.X < (startPosX - 20))
                                            {
                                                dir = "left";
                                                using (Graphics p = pictureBG.CreateGraphics())
                                                {
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY - 300);
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY + 300);
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX - 300, startPosY);
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX + 300, startPosY);

                                                    tempXlen = mouseEventArgs.X; tempYlen = startPosY;
                                                    p.DrawLine(Pens.Blue, startPosX, startPosY, mouseEventArgs.X, startPosY);
                                                }
                                                switch (Editing)
                                                {
                                                    case "Speedo": { Globals.SpeedoNeedleLength = ((startPosX - mouseEventArgs.X) * 10).ToString(); } break;
                                                    case "Tacho": { Globals.TachoNeedleLength = ((startPosX - mouseEventArgs.X) * 10).ToString(); } break;
                                                    case "Boost": { Globals.BoostNeedleLength = ((startPosX - mouseEventArgs.X) * 10).ToString(); } break;
                                                    case "Temp": { Globals.TempNeedleLength = ((startPosX - mouseEventArgs.X) * 10).ToString(); } break;
                                                    case "Oil Press": { Globals.OilNeedleLength = ((startPosX - mouseEventArgs.X) * 10).ToString(); } break;
                                                    case "Oil Temp": { Globals.OilTNeedleLength = ((startPosX - mouseEventArgs.X) * 10).ToString(); } break;
                                                    case "Fuel": { Globals.FuelNeedleLength = ((startPosX - mouseEventArgs.X) * 10).ToString(); } break;
                                                    case "Fuel Temp": { Globals.FuelTNeedleLength = ((startPosX - mouseEventArgs.X) * 10).ToString(); } break;
                                                    case "Fuel Press": { Globals.FuelPNeedleLength = ((startPosX - mouseEventArgs.X) * 10).ToString(); } break;
                                                    case "Battery": { Globals.BatteryNeedleLength = ((startPosX - mouseEventArgs.X) * 10).ToString(); } break;
                                                    case "User1": { Globals.User1NeedleLength = ((startPosX - mouseEventArgs.X) * 10).ToString(); } break;
                                                    case "User2": { Globals.User2NeedleLength = ((startPosX - mouseEventArgs.X) * 10).ToString(); } break;
                                                    case "User3": { Globals.User3NeedleLength = ((startPosX - mouseEventArgs.X) * 10).ToString(); } break;
                                                    case "User4": { Globals.User4NeedleLength = ((startPosX - mouseEventArgs.X) * 10).ToString(); } break;
                                                }
                                            }

                                            if (mouseEventArgs.Y > (startPosY + 20))
                                            {
                                                dir = "down";
                                                tempXlen = startPosX; tempYlen = mouseEventArgs.Y;
                                                using (Graphics p = pictureBG.CreateGraphics())
                                                {
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY - 300);
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY + 300);
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX - 300, startPosY);
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX + 300, startPosY);

                                                    p.DrawLine(Pens.Blue, startPosX, startPosY, startPosX, mouseEventArgs.Y);
                                                }
                                                switch (Editing)
                                                {
                                                    case "Speedo": { Globals.SpeedoNeedleLength = ((mouseEventArgs.Y - startPosY) * 10).ToString(); } break;
                                                    case "Tacho": { Globals.TachoNeedleLength = ((mouseEventArgs.Y - startPosY) * 10).ToString(); } break;
                                                    case "Boost": { Globals.BoostNeedleLength = ((mouseEventArgs.Y - startPosY) * 10).ToString(); } break;
                                                    case "Temp": { Globals.TempNeedleLength = ((mouseEventArgs.Y - startPosY) * 10).ToString(); } break;
                                                    case "Oil Press": { Globals.OilNeedleLength = ((mouseEventArgs.Y - startPosY) * 10).ToString(); } break;
                                                    case "Oil Temp": { Globals.OilTNeedleLength = ((mouseEventArgs.Y - startPosY) * 10).ToString(); } break;
                                                    case "Fuel": { Globals.FuelNeedleLength = ((mouseEventArgs.Y - startPosY) * 10).ToString(); } break;
                                                    case "Fuel Temp": { Globals.FuelTNeedleLength = ((mouseEventArgs.Y - startPosY) * 10).ToString(); } break;
                                                    case "Fuel Press": { Globals.FuelPNeedleLength = ((mouseEventArgs.Y - startPosY) * 10).ToString(); } break;
                                                    case "Battery": { Globals.BatteryNeedleLength = ((mouseEventArgs.Y - startPosY) * 10).ToString(); } break;
                                                    case "User1": { Globals.User1NeedleLength = ((mouseEventArgs.Y - startPosY) * 10).ToString(); } break;
                                                    case "User2": { Globals.User2NeedleLength = ((mouseEventArgs.Y - startPosY) * 10).ToString(); } break;
                                                    case "User3": { Globals.User3NeedleLength = ((mouseEventArgs.Y - startPosY) * 10).ToString(); } break;
                                                    case "User4": { Globals.User4NeedleLength = ((mouseEventArgs.Y - startPosY) * 10).ToString(); } break;
                                                }

                                            }
                                            if (mouseEventArgs.Y < (startPosY - 20))
                                            {
                                                dir = "up";
                                                using (Graphics p = pictureBG.CreateGraphics())
                                                {
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY - 300);
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY + 300);
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX - 300, startPosY);
                                                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX + 300, startPosY);

                                                    tempXlen = startPosX; tempYlen = mouseEventArgs.Y;
                                                    p.DrawLine(Pens.Blue, startPosX, startPosY, startPosX, mouseEventArgs.Y);
                                                }
                                                switch (Editing)
                                                {
                                                    case "Speedo": { Globals.SpeedoNeedleLength = ((startPosY - mouseEventArgs.Y) * 10).ToString(); } break;
                                                    case "Tacho": { Globals.TachoNeedleLength = ((startPosY - mouseEventArgs.Y) * 10).ToString(); } break;
                                                    case "Boost": { Globals.BoostNeedleLength = ((startPosY - mouseEventArgs.Y) * 10).ToString(); } break;
                                                    case "Temp": { Globals.TempNeedleLength = ((startPosY - mouseEventArgs.Y) * 10).ToString(); } break;
                                                    case "Oil Press": { Globals.OilNeedleLength = ((startPosY - mouseEventArgs.Y) * 10).ToString(); } break;
                                                    case "Oil Temp": { Globals.OilTNeedleLength = ((startPosY - mouseEventArgs.Y) * 10).ToString(); } break;
                                                    case "Fuel": { Globals.FuelNeedleLength = ((startPosY - mouseEventArgs.Y) * 10).ToString(); } break;
                                                    case "Fuel Temp": { Globals.FuelTNeedleLength = ((startPosY - mouseEventArgs.Y) * 10).ToString(); } break;
                                                    case "Fuel Press": { Globals.FuelPNeedleLength = ((startPosY - mouseEventArgs.Y) * 10).ToString(); } break;
                                                    case "Battery": { Globals.BatteryNeedleLength = ((startPosY - mouseEventArgs.Y) * 10).ToString(); } break;
                                                    case "User1": { Globals.User1NeedleLength = ((startPosY - mouseEventArgs.Y) * 10).ToString(); } break;
                                                    case "User2": { Globals.User2NeedleLength = ((startPosY - mouseEventArgs.Y) * 10).ToString(); } break;
                                                    case "User3": { Globals.User3NeedleLength = ((startPosY - mouseEventArgs.Y) * 10).ToString(); } break;
                                                    case "User4": { Globals.User4NeedleLength = ((startPosY - mouseEventArgs.Y) * 10).ToString(); } break;
                                                }
                                            }
                                        }
                                        stage += 1;
                                        lblPrompt.Text = "Click gauge LOW value";
                                        break;
                                    }

                                case "Click gauge LOW value":
                                    {
                                        //2nd step. needle low value
                                        if (stage == 2)
                                        {
                                            lowpointX = mouseEventArgs.X;
                                            lowpointY = mouseEventArgs.Y;
                                            using (Graphics p = pictureBG.CreateGraphics())
                                            {
                                                p.DrawLine(Pens.Black, startPosX, startPosY, tempXlen, tempYlen);
                                                tempXlow = mouseEventArgs.X; tempYlow = mouseEventArgs.Y;
                                                p.DrawLine(Pens.Orange, startPosX, startPosY, mouseEventArgs.X, mouseEventArgs.Y);
                                            }
                                        }
                                        stage += 1;
                                        lblPrompt.Text = "Click gauge TOP value";
                                        break;
                                    }

                                case "Click gauge TOP value":
                                    {
                                        //3rd step. needle top value
                                        if (stage == 3)
                                        {
                                            highpointX = mouseEventArgs.X;
                                            highpointY = mouseEventArgs.Y;
                                            using (Graphics p = pictureBG.CreateGraphics())
                                            {
                                                p.DrawLine(Pens.Black, startPosX, startPosY, tempXlow, tempYlow);
                                                tempXhigh = mouseEventArgs.X; tempYhigh = mouseEventArgs.Y;
                                                p.DrawLine(Pens.Orange, startPosX, startPosY, mouseEventArgs.X, mouseEventArgs.Y);
                                            }

                                            //reset values and text boxes
                                            lblPrompt.Text = "";
                                            lblPromptVal.Text = "";
                                            stage = 0;

                                            //now calculate gauge offsets in degrees.  lower is direction offset relative to 90 degree multiple.  higher is total number of degrees of arc.
                                            double angle1 = 0;
                                            double dx = 0;
                                            double dy = 0;
                                            double theta = 0;
                                            double angle2 = 0;

                                            if (dir == "up")
                                            {
                                                dy = (startPosY - lowpointY);
                                                dx = (startPosX - lowpointX);
                                                theta = Math.Atan2(dx, dy);
                                                angle1 = (((theta * 180) / Math.PI) % 360);
                                                if (angle1 < 0) { angle1 += 360; }
                                                offSetLow = (Math.Round(90 - angle1)).ToString();

                                                dy = (startPosY - highpointY);
                                                dx = (startPosX - highpointX);
                                                theta = Math.Atan2(dy, dx);
                                                angle2 = ((((theta * 180) / Math.PI) % 360) - 90);
                                                if (angle2 < 0)
                                                {
                                                    angle2 += 360;
                                                }
                                                offSetHigh = (Math.Round((angle1 + angle2))).ToString();

                                                switch (Editing)
                                                {
                                                    //  values
                                                    case "Speedo": { Globals.SpeedoOffset = offSetLow; Globals.SpeedoEnd = offSetHigh; Globals.SpeedoNeedleX = startPosX.ToString(); Globals.SpeedoNeedleY = startPosY.ToString(); } break;
                                                    case "Tacho": { Globals.TachoOffset = offSetLow; Globals.TachoEnd = offSetHigh; Globals.TachoNeedleX = startPosX.ToString(); Globals.TachoNeedleY = startPosY.ToString(); } break;
                                                    case "Boost": { Globals.BoostOffset = offSetLow; Globals.BoostEnd = offSetHigh; Globals.BoostNeedleX = startPosX.ToString(); Globals.BoostNeedleY = startPosY.ToString(); } break;
                                                    case "Temp": { Globals.TempOffset = offSetLow; Globals.TempEnd = offSetHigh; Globals.TempNeedleX = startPosX.ToString(); Globals.TempNeedleY = startPosY.ToString(); } break;
                                                    case "Oil Press": { Globals.OilOffset = offSetLow; Globals.OilEnd = offSetHigh; Globals.OilNeedleX = startPosX.ToString(); Globals.OilNeedleY = startPosY.ToString(); } break;
                                                    case "Oil Temp": { Globals.OilTOffset = offSetLow; Globals.OilTEnd = offSetHigh; Globals.OilTNeedleX = startPosX.ToString(); Globals.OilTNeedleY = startPosY.ToString(); } break;
                                                    case "Fuel": { Globals.FuelOffset = offSetLow; Globals.FuelEnd = offSetHigh; Globals.FuelNeedleX = startPosX.ToString(); Globals.FuelNeedleY = startPosY.ToString(); } break;
                                                    case "Fuel Temp": { Globals.FuelTOffset = offSetLow; Globals.FuelTEnd = offSetHigh; Globals.FuelTNeedleX = startPosX.ToString(); Globals.FuelTNeedleY = startPosY.ToString(); } break;
                                                    case "Fuel Press": { Globals.FuelPOffset = offSetLow; Globals.FuelPEnd = offSetHigh; Globals.FuelPNeedleX = startPosX.ToString(); Globals.FuelPNeedleY = startPosY.ToString(); } break;
                                                    case "Battery": { Globals.BatteryOffset = offSetLow; Globals.BatteryEnd = offSetHigh; Globals.BatteryNeedleX = startPosX.ToString(); Globals.BatteryNeedleY = startPosY.ToString(); } break;
                                                    case "User1": { Globals.User1Offset = offSetLow; Globals.User1End = offSetHigh; Globals.User1NeedleX = startPosX.ToString(); Globals.User1NeedleY = startPosY.ToString(); } break;
                                                    case "User2": { Globals.User2Offset = offSetLow; Globals.User2End = offSetHigh; Globals.User2NeedleX = startPosX.ToString(); Globals.User2NeedleY = startPosY.ToString(); } break;
                                                    case "User3": { Globals.User3Offset = offSetLow; Globals.User3End = offSetHigh; Globals.User2NeedleX = startPosX.ToString(); Globals.User3NeedleY = startPosY.ToString(); } break;
                                                    case "User4": { Globals.User4Offset = offSetLow; Globals.User4End = offSetHigh; Globals.User4NeedleX = startPosX.ToString(); Globals.User4NeedleY = startPosY.ToString(); } break;
                                                }

                                            }

                                            if (dir == "down")
                                            {
                                                dy = (startPosY - lowpointY);
                                                dx = (startPosX - lowpointX);
                                                theta = Math.Atan2(dx, dy);
                                                angle1 = (((theta * 180) / Math.PI) % 360);

                                                if (angle1 < 0) { angle1 += 360; }
                                                offSetLow = (Math.Round(angle1 - 180)).ToString();

                                                dy = (startPosY - highpointY);
                                                dx = (startPosX - highpointX);
                                                theta = Math.Atan2(dx, dy);
                                                angle2 = ((((theta * 180) / Math.PI) % 360));
                                                if (angle2 < 0)
                                                {
                                                    angle2 += 360;
                                                }
                                                offSetHigh = (Math.Round(angle1 - angle2)).ToString();

                                                switch (Editing)
                                                {
                                                    //  values
                                                    case "Speedo": { Globals.SpeedoOffset = offSetLow; Globals.SpeedoEnd = offSetHigh; Globals.SpeedoNeedleX = startPosX.ToString(); Globals.SpeedoNeedleY = startPosY.ToString(); } break;
                                                    case "Tacho": { Globals.TachoOffset = offSetLow; Globals.TachoEnd = offSetHigh; Globals.TachoNeedleX = startPosX.ToString(); Globals.TachoNeedleY = startPosY.ToString(); } break;
                                                    case "Boost": { Globals.BoostOffset = offSetLow; Globals.BoostEnd = offSetHigh; Globals.BoostNeedleX = startPosX.ToString(); Globals.BoostNeedleY = startPosY.ToString(); } break;
                                                    case "Temp": { Globals.TempOffset = offSetLow; Globals.TempEnd = offSetHigh; Globals.TempNeedleX = startPosX.ToString(); Globals.TempNeedleY = startPosY.ToString(); } break;
                                                    case "Oil Press": { Globals.OilOffset = offSetLow; Globals.OilEnd = offSetHigh; Globals.OilNeedleX = startPosX.ToString(); Globals.OilNeedleY = startPosY.ToString(); } break;
                                                    case "Oil Temp": { Globals.OilTOffset = offSetLow; Globals.OilTEnd = offSetHigh; Globals.OilTNeedleX = startPosX.ToString(); Globals.OilTNeedleY = startPosY.ToString(); } break;
                                                    case "Fuel": { Globals.FuelOffset = offSetLow; Globals.FuelEnd = offSetHigh; Globals.FuelNeedleX = startPosX.ToString(); Globals.FuelNeedleY = startPosY.ToString(); } break;
                                                    case "Fuel Temp": { Globals.FuelTOffset = offSetLow; Globals.FuelTEnd = offSetHigh; Globals.FuelTNeedleX = startPosX.ToString(); Globals.FuelTNeedleY = startPosY.ToString(); } break;
                                                    case "Fuel Press": { Globals.FuelPOffset = offSetLow; Globals.FuelPEnd = offSetHigh; Globals.FuelPNeedleX = startPosX.ToString(); Globals.FuelPNeedleY = startPosY.ToString(); } break;
                                                    case "Battery": { Globals.BatteryOffset = offSetLow; Globals.BatteryEnd = offSetHigh; Globals.BatteryNeedleX = startPosX.ToString(); Globals.BatteryNeedleY = startPosY.ToString(); } break;
                                                    case "User1": { Globals.User1Offset = offSetLow; Globals.User1End = offSetHigh; Globals.User1NeedleX = startPosX.ToString(); Globals.User1NeedleY = startPosY.ToString(); } break;
                                                    case "User2": { Globals.User2Offset = offSetLow; Globals.User2End = offSetHigh; Globals.User2NeedleX = startPosX.ToString(); Globals.User2NeedleY = startPosY.ToString(); } break;
                                                    case "User3": { Globals.User3Offset = offSetLow; Globals.User3End = offSetHigh; Globals.User2NeedleX = startPosX.ToString(); Globals.User3NeedleY = startPosY.ToString(); } break;
                                                    case "User4": { Globals.User4Offset = offSetLow; Globals.User4End = offSetHigh; Globals.User4NeedleX = startPosX.ToString(); Globals.User4NeedleY = startPosY.ToString(); } break;
                                                }
                                            }

                                            if (dir == "left")
                                            {
                                                dy = (lowpointY - startPosY);
                                                dx = (lowpointX - startPosX);
                                                theta = Math.Atan2(dx, dy);
                                                angle1 = ((((theta * 180) / Math.PI) % 360) - 270);
                                                if (angle1 < 0) { angle1 += 360; }

                                                offSetLow = "-" + (Math.Round(angle1)).ToString();

                                                dy = (startPosY - highpointY);
                                                dx = (startPosX - highpointX);
                                                theta = Math.Atan2(dy, dx);
                                                angle2 = ((((theta * 180) / Math.PI) % 360));
                                                if (angle2 < 0)
                                                {
                                                    angle2 += 360;
                                                }
                                                offSetHigh = (Math.Round((angle1 + angle2))).ToString();

                                                switch (Editing)
                                                {
                                                    //  values
                                                    //  values
                                                    case "Speedo": { Globals.SpeedoOffset = offSetLow; Globals.SpeedoEnd = offSetHigh; Globals.SpeedoNeedleX = startPosX.ToString(); Globals.SpeedoNeedleY = startPosY.ToString(); } break;
                                                    case "Tacho": { Globals.TachoOffset = offSetLow; Globals.TachoEnd = offSetHigh; Globals.TachoNeedleX = startPosX.ToString(); Globals.TachoNeedleY = startPosY.ToString(); } break;
                                                    case "Boost": { Globals.BoostOffset = offSetLow; Globals.BoostEnd = offSetHigh; Globals.BoostNeedleX = startPosX.ToString(); Globals.BoostNeedleY = startPosY.ToString(); } break;
                                                    case "Temp": { Globals.TempOffset = offSetLow; Globals.TempEnd = offSetHigh; Globals.TempNeedleX = startPosX.ToString(); Globals.TempNeedleY = startPosY.ToString(); } break;
                                                    case "Oil Press": { Globals.OilOffset = offSetLow; Globals.OilEnd = offSetHigh; Globals.OilNeedleX = startPosX.ToString(); Globals.OilNeedleY = startPosY.ToString(); } break;
                                                    case "Oil Temp": { Globals.OilTOffset = offSetLow; Globals.OilTEnd = offSetHigh; Globals.OilTNeedleX = startPosX.ToString(); Globals.OilTNeedleY = startPosY.ToString(); } break;
                                                    case "Fuel": { Globals.FuelOffset = offSetLow; Globals.FuelEnd = offSetHigh; Globals.FuelNeedleX = startPosX.ToString(); Globals.FuelNeedleY = startPosY.ToString(); } break;
                                                    case "Fuel Temp": { Globals.FuelTOffset = offSetLow; Globals.FuelTEnd = offSetHigh; Globals.FuelTNeedleX = startPosX.ToString(); Globals.FuelTNeedleY = startPosY.ToString(); } break;
                                                    case "Fuel Press": { Globals.FuelPOffset = offSetLow; Globals.FuelPEnd = offSetHigh; Globals.FuelPNeedleX = startPosX.ToString(); Globals.FuelPNeedleY = startPosY.ToString(); } break;
                                                    case "Battery": { Globals.BatteryOffset = offSetLow; Globals.BatteryEnd = offSetHigh; Globals.BatteryNeedleX = startPosX.ToString(); Globals.BatteryNeedleY = startPosY.ToString(); } break;
                                                    case "User1": { Globals.User1Offset = offSetLow; Globals.User1End = offSetHigh; Globals.User1NeedleX = startPosX.ToString(); Globals.User1NeedleY = startPosY.ToString(); } break;
                                                    case "User2": { Globals.User2Offset = offSetLow; Globals.User2End = offSetHigh; Globals.User2NeedleX = startPosX.ToString(); Globals.User2NeedleY = startPosY.ToString(); } break;
                                                    case "User3": { Globals.User3Offset = offSetLow; Globals.User3End = offSetHigh; Globals.User2NeedleX = startPosX.ToString(); Globals.User3NeedleY = startPosY.ToString(); } break;
                                                    case "User4": { Globals.User4Offset = offSetLow; Globals.User4End = offSetHigh; Globals.User4NeedleX = startPosX.ToString(); Globals.User4NeedleY = startPosY.ToString(); } break;
                                                }
                                            }

                                            if (dir == "right")
                                            {
                                                dy = (lowpointY - startPosY);
                                                dx = (lowpointX - startPosX);
                                                theta = Math.Atan2(dx, dy);
                                                angle1 = ((((theta * 180) / Math.PI) % 360) - 270);
                                                if (angle1 < 0) { angle1 += 360; }

                                                offSetLow = (Math.Round(angle1)).ToString();

                                                dy = (startPosY - highpointY);
                                                dx = (startPosX - highpointX);
                                                theta = Math.Atan2(dy, dx);
                                                angle2 = ((((theta * 180) / Math.PI) % 360));
                                                if (angle2 < 0)
                                                {
                                                    angle2 += 360;
                                                }
                                                offSetHigh = (Math.Round((angle1 + angle2))).ToString();

                                                switch (Editing)
                                                {
                                                    //  values
                                                    case "Speedo": { Globals.SpeedoOffset = offSetLow; Globals.SpeedoEnd = offSetHigh; Globals.SpeedoNeedleX = startPosX.ToString(); Globals.SpeedoNeedleY = startPosY.ToString(); } break;
                                                    case "Tacho": { Globals.TachoOffset = offSetLow; Globals.TachoEnd = offSetHigh; Globals.TachoNeedleX = startPosX.ToString(); Globals.TachoNeedleY = startPosY.ToString(); } break;
                                                    case "Boost": { Globals.BoostOffset = offSetLow; Globals.BoostEnd = offSetHigh; Globals.BoostNeedleX = startPosX.ToString(); Globals.BoostNeedleY = startPosY.ToString(); } break;
                                                    case "Temp": { Globals.TempOffset = offSetLow; Globals.TempEnd = offSetHigh; Globals.TempNeedleX = startPosX.ToString(); Globals.TempNeedleY = startPosY.ToString(); } break;
                                                    case "Oil Press": { Globals.OilOffset = offSetLow; Globals.OilEnd = offSetHigh; Globals.OilNeedleX = startPosX.ToString(); Globals.OilNeedleY = startPosY.ToString(); } break;
                                                    case "Oil Temp": { Globals.OilTOffset = offSetLow; Globals.OilTEnd = offSetHigh; Globals.OilTNeedleX = startPosX.ToString(); Globals.OilTNeedleY = startPosY.ToString(); } break;
                                                    case "Fuel": { Globals.FuelOffset = offSetLow; Globals.FuelEnd = offSetHigh; Globals.FuelNeedleX = startPosX.ToString(); Globals.FuelNeedleY = startPosY.ToString(); } break;
                                                    case "Fuel Temp": { Globals.FuelTOffset = offSetLow; Globals.FuelTEnd = offSetHigh; Globals.FuelTNeedleX = startPosX.ToString(); Globals.FuelTNeedleY = startPosY.ToString(); } break;
                                                    case "Fuel Press": { Globals.FuelPOffset = offSetLow; Globals.FuelPEnd = offSetHigh; Globals.FuelPNeedleX = startPosX.ToString(); Globals.FuelPNeedleY = startPosY.ToString(); } break;
                                                    case "Battery": { Globals.BatteryOffset = offSetLow; Globals.BatteryEnd = offSetHigh; Globals.BatteryNeedleX = startPosX.ToString(); Globals.BatteryNeedleY = startPosY.ToString(); } break;
                                                    case "User1": { Globals.User1Offset = offSetLow; Globals.User1End = offSetHigh; Globals.User1NeedleX = startPosX.ToString(); Globals.User1NeedleY = startPosY.ToString(); } break;
                                                    case "User2": { Globals.User2Offset = offSetLow; Globals.User2End = offSetHigh; Globals.User2NeedleX = startPosX.ToString(); Globals.User2NeedleY = startPosY.ToString(); } break;
                                                    case "User3": { Globals.User3Offset = offSetLow; Globals.User3End = offSetHigh; Globals.User2NeedleX = startPosX.ToString(); Globals.User3NeedleY = startPosY.ToString(); } break;
                                                    case "User4": { Globals.User4Offset = offSetLow; Globals.User4End = offSetHigh; Globals.User4NeedleX = startPosX.ToString(); Globals.User4NeedleY = startPosY.ToString(); } break;
                                                }
                                            }
                                        }
                                    }
                                    lblPrompt.Text = "Enter the highest value";
                                    lblPromptVal.Text = "Then click the gauge";
                                    stage += 1;
                                    txtTopVal.Visible = true;
                                    break;

                                case "Enter the highest value":
                                    {
                                        using (Graphics p = pictureBG.CreateGraphics())
                                        {
                                            p.DrawLine(Pens.Black, startPosX, startPosY, tempXhigh, tempYhigh);
                                        }

                                        switch (Editing)
                                        {
                                            //  values
                                            case "Speedo": { Globals.SpeedoTop = txtTopVal.Text; } break;
                                            case "Tacho": { Globals.TachoTop = txtTopVal.Text; } break;
                                            case "Boost": { Globals.BoostTop = txtTopVal.Text; } break;
                                            case "Temp": { Globals.TempTop = txtTopVal.Text; } break;
                                            case "Oil Press": { Globals.OilTop = txtTopVal.Text; } break;
                                            case "Oil Temp": { Globals.OilTTop = txtTopVal.Text; } break;
                                            case "Fuel": { Globals.FuelTop = txtTopVal.Text; } break;
                                            case "Fuel Temp": { Globals.FuelTTop = txtTopVal.Text; } break;
                                            case "Fuel Press": { Globals.FuelPTop = txtTopVal.Text; } break;
                                            case "Battery": { Globals.BatteryTop = txtTopVal.Text; } break;
                                            case "User1": { Globals.User1Top = txtTopVal.Text; } break;
                                            case "User2": { Globals.User2Top = txtTopVal.Text; } break;
                                            case "User3": { Globals.User3Top = txtTopVal.Text; } break;
                                            case "User4": { Globals.User4Top = txtTopVal.Text; } break;
                                        }
                                        txtTopVal.Text = "";
                                        txtTopVal.Visible = false;
                                        lblPrompt.Text = "";
                                        lblPromptVal.Text = "";
                                        stage = 0;
                                        tempXlen = 0; tempYlen = 0; tempXlow = 0; tempYlow = 0; tempXhigh = 0; tempYhigh = 0;
                                        ResetThePage(lbNumber);
                                    }
                                    break;



                                //===================================================BAR=========================================================================

                                case "Enter highest value":
                                    {
                                        txtTopVal.Visible = false;
                                        commitBar(Editing, txtTopVal.Text);
                                        ResetThePage(lbNumber);
                                    }
                                    break;

                                case "Click bar TOP LEFT":
                                    {
                                        //1st step. bar bottom left
                                        if (stage == 0)
                                        {
                                            lpX = mouseEventArgs.X;
                                            lpY = mouseEventArgs.Y;
                                        }
                                        //reset values and text boxes
                                        lblPrompt.Text = "Click bar BOTTOM RIGHT";
                                        stage += 1;
                                    }
                                    break;

                                case "Click bar BOTTOM RIGHT":
                                    {
                                        //2nd step. bar length
                                        if (stage == 1)
                                        {
                                            lowpointX = lpX - (pictureBG.Width / 2);
                                            lowpointY = lpY - (pictureBG.Height / 2);

                                            highpointX = mouseEventArgs.X - lpX;
                                            highpointY = mouseEventArgs.Y - lpY;

                                            tempXlow = lpX; tempYlow = lpY; tempXhigh = highpointX; tempYhigh = highpointY;

                                            using (Graphics p = pictureBG.CreateGraphics())
                                            {
                                                p.DrawRectangle(Pens.Pink, tempXlow, tempYlow, tempXhigh, tempYhigh);
                                                Thread.Sleep(1500);
                                                p.DrawRectangle(Pens.Black, tempXlow, tempYlow, tempXhigh, tempYhigh);
                                            }

                                            txtTopVal.Visible = true;
                                            lblPrompt.Text = "Enter highest value";
                                            lblPromptVal.Text = "for " + Editing;

                                            //commit all values above so it allows for entry                                        }
                                        }
                                        break;
                                    }

                                case "Speedo Text": case "Tacho Text": case "Boost Text": case "Temp Text": case "Oil Press Text": case "Oil Temp Text": case "Fuel Text": case "Fuel Temp Text": case "Fuel Press Text": case "Battery Text": case "User1 Text": case "User2 Text": case "User3 Text": case "User4 Text":
                                    {
                                        startPosX = mouseEventArgs.X;
                                        startPosY = mouseEventArgs.Y;
                                        movingCentre = "text";
                                        placeTextSet(Editing, "white");
                                    }
                                    break;
                            }
                            break;
                        }
                }
            }
        }

        private void commitBar(string Editing, string TopVal)
        {
            if (Editing == "Speedo")
            {
                if ((Globals.SpeedoNeedleType == "barV") || (Globals.SpeedoNeedleType == "barH"))
                { Globals.SpeedoNeedleWidth = highpointX.ToString(); Globals.SpeedoNeedleLength = highpointY.ToString(); Globals.SpeedoNeedleX = lowpointX.ToString(); Globals.SpeedoNeedleY = lowpointY.ToString(); Globals.SpeedoTop = TopVal; }
            }
            if (Editing == "Tacho")
            {
                if ((Globals.TachoNeedleType == "barV") || (Globals.TachoNeedleType == "barH"))
                { Globals.TachoNeedleWidth = highpointX.ToString(); Globals.TachoNeedleLength = highpointY.ToString(); Globals.TachoNeedleX = lowpointX.ToString(); Globals.TachoNeedleY = lowpointY.ToString(); Globals.TachoTop = TopVal; }
            }
            if (Editing == "Boost")
            {
                if ((Globals.BoostNeedleType == "barV") || (Globals.BoostNeedleType == "barH"))
                { Globals.BoostNeedleWidth = highpointX.ToString(); Globals.BoostNeedleLength = highpointY.ToString(); Globals.BoostNeedleX = lowpointX.ToString(); Globals.BoostNeedleY = lowpointY.ToString(); Globals.BoostTop = TopVal; }
            }
            if (Editing == "Temp")
            {
                if ((Globals.TempNeedleType == "barV") || (Globals.TempNeedleType == "barH"))
                { Globals.TempNeedleWidth = highpointX.ToString(); Globals.TempNeedleLength = highpointY.ToString(); Globals.TempNeedleX = lowpointX.ToString(); Globals.TempNeedleY = lowpointY.ToString(); Globals.TempTop = TopVal; }
            }
            if (Editing == "Oil Press")
            {
                if ((Globals.OilNeedleType == "barV") || (Globals.OilNeedleType == "barH"))
                { Globals.OilNeedleWidth = highpointX.ToString(); Globals.OilNeedleLength = highpointY.ToString(); Globals.OilNeedleX = lowpointX.ToString(); Globals.OilNeedleY = lowpointY.ToString(); Globals.OilTop = TopVal; }
            }
            if (Editing == "Oil Temp")
            {
                if ((Globals.OilTNeedleType == "barV") || (Globals.OilTNeedleType == "barH"))
                { Globals.OilTNeedleWidth = highpointX.ToString(); Globals.OilTNeedleLength = highpointY.ToString(); Globals.OilTNeedleX = lowpointX.ToString(); Globals.OilTNeedleY = lowpointY.ToString(); Globals.OilTTop = TopVal; }
            }
            if (Editing == "Fuel")
            {
                if ((Globals.FuelNeedleType == "barV") || (Globals.FuelNeedleType == "barH"))
                { Globals.FuelNeedleWidth = highpointX.ToString(); Globals.FuelNeedleLength = highpointY.ToString(); Globals.FuelNeedleX = lowpointX.ToString(); Globals.FuelNeedleY = lowpointY.ToString(); Globals.FuelTop = TopVal; }
            }
            if (Editing == "Fuel Temp")
            {
                if ((Globals.FuelTNeedleType == "barV") || (Globals.FuelTNeedleType == "barH"))
                { Globals.FuelTNeedleWidth = highpointX.ToString(); Globals.FuelTNeedleLength = highpointY.ToString(); Globals.FuelTNeedleX = lowpointX.ToString(); Globals.FuelTNeedleY = lowpointY.ToString(); Globals.FuelTTop = TopVal; }
            }
            if (Editing == "Fuel Press")
            {
                if ((Globals.FuelPNeedleType == "barV") || (Globals.FuelPNeedleType == "barH"))
                { Globals.FuelPNeedleWidth = highpointX.ToString(); Globals.FuelPNeedleLength = highpointY.ToString(); Globals.FuelPNeedleX = lowpointX.ToString(); Globals.FuelPNeedleY = lowpointY.ToString(); Globals.FuelPTop = TopVal; }
            }
            if (Editing == "Battery")
            {
                if ((Globals.BatteryNeedleType == "barV") || (Globals.BatteryNeedleType == "barH"))
                { Globals.BatteryNeedleWidth = highpointX.ToString(); Globals.BatteryNeedleLength = highpointY.ToString(); Globals.BatteryNeedleX = lowpointX.ToString(); Globals.BatteryNeedleY = lowpointY.ToString(); Globals.BatteryTop = TopVal; }
            }
            if (Editing == "User1")
            {
                if ((Globals.User1NeedleType == "barV") || (Globals.User1NeedleType == "barH"))
                { Globals.User1NeedleWidth = highpointX.ToString(); Globals.User1NeedleLength = highpointY.ToString(); Globals.User1NeedleX = lowpointX.ToString(); Globals.User1NeedleY = lowpointY.ToString(); Globals.User1Top = TopVal; }
            }
            if (Editing == "User2")
            {
                if ((Globals.User2NeedleType == "barV") || (Globals.User2NeedleType == "barH"))
                { Globals.User2NeedleWidth = highpointX.ToString(); Globals.User2NeedleLength = highpointY.ToString(); Globals.User2NeedleX = lowpointX.ToString(); Globals.User2NeedleY = lowpointY.ToString(); Globals.User2Top = TopVal; }
            }
            if (Editing == "User3")
            {
                if ((Globals.User3NeedleType == "barV") || (Globals.User3NeedleType == "barH"))
                { Globals.User3NeedleWidth = highpointX.ToString(); Globals.User3NeedleLength = highpointY.ToString(); Globals.User3NeedleX = lowpointX.ToString(); Globals.User3NeedleY = lowpointY.ToString(); Globals.User3Top = TopVal; }
            }
            if (Editing == "User4")
            {
                if ((Globals.User4NeedleType == "barV") || (Globals.User4NeedleType == "barH"))
                { Globals.User4NeedleWidth = highpointX.ToString(); Globals.User4NeedleLength = highpointY.ToString(); Globals.User4NeedleX = lowpointX.ToString(); Globals.User4NeedleY = lowpointY.ToString(); Globals.User4Top = TopVal; }
            }

            stage = 0;
            ResetThePage(lbNumber);
        }

        public void placeText(string fontStyle, string fontSize, string colour)
        {
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            if (Int32.Parse(fontSize) < 8) { fontSize = "18"; }
            using (Graphics p = pictureBG.CreateGraphics())
            {
                if (colour == "white")
                {
                    if (fontStyle == "smooth")
                    {
                        using (Font arialFont = new Font("Arial", Int32.Parse(fontSize), FontStyle.Regular))
                        {
                            p.DrawString("000", arialFont, Brushes.White, startPosX, startPosY, sf);
                        }
                    }

                    if (fontStyle == "bold")
                    {
                        using (Font arialFont = new Font("Arial", Int32.Parse(fontSize), FontStyle.Bold))
                        {
                            p.DrawString("000", arialFont, Brushes.White, startPosX, startPosY, sf);
                        }
                    }
                }

                if (colour == "black")
                {
                    if (fontStyle == "smooth")
                    {
                        using (Font arialFont = new Font("Arial", Int32.Parse(fontSize), FontStyle.Regular))
                        {
                            p.DrawString("000", arialFont, Brushes.Black, startPosX, startPosY, sf);
                        }
                    }
                    if (fontStyle == "bold")
                    {
                        using (Font arialFont = new Font("Arial", Int32.Parse(fontSize), FontStyle.Bold))
                        {
                            p.DrawString("000", arialFont, Brushes.Black, startPosX, startPosY, sf);
                        }
                    }
                }
            }

            pnlDirections.Left = lbLeft + 250;
            pnlDirections.Top = pictureBG.Height + 100;
            pnlDirections.Show();
        }

        public void placeTextSet(string Editing,string colour)
        {
            string fontStyle = ""; string fontSize = "18"; float locX = 0; float locY = 0;

            if (Editing == "Speedo Text") { fontStyle = Globals.SpeedoTextStyle; fontSize = Globals.SpeedoFontSize; Globals.SpeedoTextX = startPosX.ToString(); Globals.SpeedoTextY = startPosY.ToString(); locX = startPosX; locY = startPosY; }
            if (Editing == "Tacho Text") { fontStyle = Globals.TachoTextStyle; fontSize = Globals.TachoFontSize; Globals.TachoTextX = startPosX.ToString(); Globals.TachoTextY = startPosY.ToString(); locX = startPosX; locY = startPosY; }
            if (Editing == "Boost Text") { fontStyle = Globals.BoostTextStyle; fontSize = Globals.BoostFontSize; Globals.BoostTextX = startPosX.ToString(); Globals.BoostTextY = startPosY.ToString(); locX = startPosX; locY = startPosY; }
            if (Editing == "Temp Text") { fontStyle = Globals.TempTextStyle; fontSize = Globals.TempFontSize; Globals.TempTextX = startPosX.ToString(); Globals.TempTextY = startPosY.ToString(); locX = startPosX; locY = startPosY; }
            if (Editing == "Oil Press Text") { fontStyle = Globals.OilTextStyle; fontSize = Globals.OilFontSize; Globals.OilTextX = startPosX.ToString(); Globals.OilTextY = startPosY.ToString(); locX = startPosX; locY = startPosY; }
            if (Editing == "Oil Temp Text") { fontStyle = Globals.OilTTextStyle; fontSize = Globals.OilTFontSize; Globals.OilTTextX = startPosX.ToString(); Globals.OilTTextY = startPosY.ToString(); locX = startPosX; locY = startPosY; }
            if (Editing == "Fuel Text") { fontStyle = Globals.FuelTextStyle; fontSize = Globals.FuelFontSize; Globals.FuelTextX = startPosX.ToString(); Globals.FuelTextY = startPosY.ToString(); locX = startPosX; locY = startPosY; }
            if (Editing == "Fuel Temp  Text") { fontStyle = Globals.FuelTTextStyle; fontSize = Globals.FuelTFontSize; Globals.FuelTTextX = startPosX.ToString(); Globals.FuelTTextY = startPosY.ToString(); locX = startPosX; locY = startPosY; }
            if (Editing == "Fuel Press Text") { fontStyle = Globals.FuelPTextStyle; fontSize = Globals.FuelPFontSize; Globals.FuelPTextX = startPosX.ToString(); Globals.FuelPTextY = startPosY.ToString(); locX = startPosX; locY = startPosY; }
            if (Editing == "Battery Text") { fontStyle = Globals.BatteryTextStyle; fontSize = Globals.BatteryFontSize; Globals.BatteryTextX = startPosX.ToString(); Globals.BatteryTextY = startPosY.ToString(); locX = startPosX; locY = startPosY; }
            if (Editing == "User1 Text") { fontStyle = Globals.User1TextStyle; fontSize = Globals.User1FontSize; Globals.User1TextX = startPosX.ToString(); Globals.User1TextY = startPosY.ToString(); locX = startPosX; locY = startPosY; }
            if (Editing == "User2 Text") { fontStyle = Globals.User2TextStyle; fontSize = Globals.User2FontSize; Globals.User2TextX = startPosX.ToString(); Globals.User2TextY = startPosY.ToString(); locX = startPosX; locY = startPosY; }
            if (Editing == "User3 Text") { fontStyle = Globals.User3TextStyle; fontSize = Globals.User3FontSize; Globals.User3TextX = startPosX.ToString(); Globals.User3TextY = startPosY.ToString(); locX = startPosX; locY = startPosY; }
            if (Editing == "User4 Text") { fontStyle = Globals.User4TextStyle; fontSize = Globals.User4FontSize; Globals.User4TextX = startPosX.ToString(); Globals.User4TextY = startPosY.ToString(); locX = startPosX; locY = startPosY; }

            placeText(fontStyle,fontSize,colour);
        }

public void finaliseText()
        {
            Editing = "";

            for (int i = 1; i < (lbNumber + 1); i++)
            {
                if (labels[i].BackColor == Color.Turquoise)
                {
                    labels[i].BackColor = Color.LightGreen;
                }
            }

            lblPrompt.Text = "";
            lblPromptVal.Text = "";
        }

        public void ResetThePage(int lbNumber)
        {
            // page reset
        //    drawthebackground();
            Editing = "";

            for (int i = 1; i < (lbNumber + 1); i++)
            {
                if (labels[i].BackColor == Color.Blue)
                {
                    labels[i].BackColor = Color.LightGreen;
                }
                if (labels[i].BackColor == Color.WhiteSmoke)
                {
                    labels[i].BackColor = Color.LightGreen;
                }
            }
            lblPrompt.Text = "";
            lblPromptVal.Text = "";
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

            if (Math.Round(picr, 2) == rat43) { imgAspect = "4:3"; } else if (Math.Round(picr, 2) == rat169) { imgAspect = "16:9"; } else { imgAspect = Math.Round(picr, 2).ToString() + ":1"; }
            if (Math.Round(dispr, 2) == rat43) { picAspect = "4:3"; } else if (Math.Round(dispr, 2) == rat169) { picAspect = "16:9"; } else { picAspect = Math.Round(dispr, 2).ToString() + ":1"; }
            if ((img.Height.ToString() != Globals.p1DispHeight) || (img.Width.ToString() != Globals.p1DispWidth)) { this.Text = "Panel 1 SCALED FROM: " + img.Width + " x " + img.Height + " (" + imgAspect + ")" + " TO " + Globals.p1DispWidth + " x " + Globals.p2DispHeight + " (" + picAspect + ")"; }

            pictureBG.Size = new System.Drawing.Size(Int32.Parse(Globals.p1DispWidth), Int32.Parse(Globals.p1DispHeight));
            pictureBG.SizeMode = PictureBoxSizeMode.StretchImage; pictureBG.Image = Image.FromFile(Globals.flocation + "\\" + Globals.P1BG);
            this.Size = new System.Drawing.Size(Int32.Parse(Globals.p1DispWidth) + 10, Int32.Parse(Globals.p1DispHeight) + 50);
            this.AutoSize = true;
            //end background
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (Globals.SpeedoNeedleWidth == "0") { Globals.SpeedoNeedleWidth = "50"; }
            if (Globals.TachoNeedleWidth == "0") { Globals.TachoNeedleWidth = "50"; }
            if (Globals.BoostNeedleWidth == "0") { Globals.BoostNeedleWidth = "50"; }
            if (Globals.TempNeedleWidth == "0") { Globals.TempNeedleWidth = "50"; }
            if (Globals.OilNeedleWidth == "0") { Globals.OilNeedleWidth = "50"; }
            if (Globals.OilTNeedleWidth == "0") { Globals.OilTNeedleWidth = "50"; }
            if (Globals.FuelNeedleWidth == "0") { Globals.FuelNeedleWidth = "50"; }
            if (Globals.FuelTNeedleWidth == "0") { Globals.FuelTNeedleWidth = "50"; }
            if (Globals.FuelPNeedleWidth == "0") { Globals.FuelPNeedleWidth = "50"; }
            if (Globals.BatteryNeedleWidth == "0") { Globals.BatteryNeedleWidth = "50"; }
            if (Globals.User1NeedleWidth == "0") { Globals.User1NeedleWidth = "50"; }
            if (Globals.User2NeedleWidth == "0") { Globals.User2NeedleWidth = "50"; }
            if (Globals.User3NeedleWidth == "0") { Globals.User3NeedleWidth = "50"; }
            if (Globals.User4NeedleWidth == "0") { Globals.User4NeedleWidth = "50"; }

            Globals.Speedovalp1 = "Speedo" + "," + Globals.SpeedoShow + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle + "," + Globals.SpeedoGPIO;
            Globals.Tachovalp1 = "Tacho" + "," + Globals.TachoShow + "," + Globals.TachoNeedleWidth + "," + Globals.TachoNeedleLength + "," + Globals.TachoNeedleX + "," + Globals.TachoNeedleY + "," + Globals.TachoOffset + "," + Globals.TachoEnd + "," + Globals.TachoTop + "," + Globals.TachoTextShow + "," + Globals.TachoTextX + "," + Globals.TachoTextY + "," + Globals.TachoFontSize + "," + Globals.TachoTextStyle + "," + Globals.TachoNeedleType + "," + Globals.TachoNeedle + "," + Globals.TachoGPIO;
            Globals.Boostvalp1 = "Boost" + "," + Globals.BoostShow + "," + Globals.BoostNeedleWidth + "," + Globals.BoostNeedleLength + "," + Globals.BoostNeedleX + "," + Globals.BoostNeedleY + "," + Globals.BoostOffset + "," + Globals.BoostEnd + "," + Globals.BoostTop + "," + Globals.BoostTextShow + "," + Globals.BoostTextX + "," + Globals.BoostTextY + "," + Globals.BoostFontSize + "," + Globals.BoostTextStyle + "," + Globals.BoostNeedleType + "," + Globals.BoostNeedle + "," + Globals.BoostGPIO;
            Globals.Tempvalp1 = "Temp" + "," + Globals.TempShow + "," + Globals.TempNeedleWidth + "," + Globals.TempNeedleLength + "," + Globals.TempNeedleX + "," + Globals.TempNeedleY + "," + Globals.TempOffset + "," + Globals.TempEnd + "," + Globals.TempTop + "," + Globals.TempTextShow + "," + Globals.TempTextX + "," + Globals.TempTextY + "," + Globals.TempFontSize + "," + Globals.TempTextStyle + "," + Globals.TempNeedleType + "," + Globals.TempNeedle + "," + Globals.TempGPIO;
            Globals.Oilvalp1 = "Oil" + "," + Globals.OilShow + "," + Globals.OilNeedleWidth + "," + Globals.OilNeedleLength + "," + Globals.OilNeedleX + "," + Globals.OilNeedleY + "," + Globals.OilOffset + "," + Globals.OilEnd + "," + Globals.OilTop + "," + Globals.OilTextShow + "," + Globals.OilTextX + "," + Globals.OilTextY + "," + Globals.OilFontSize + "," + Globals.OilTextStyle + "," + Globals.OilNeedleType + "," + Globals.OilNeedle + "," + Globals.OilGPIO;
            Globals.OilTvalp1 = "OilT" + "," + Globals.OilTShow + "," + Globals.OilTNeedleWidth + "," + Globals.OilTNeedleLength + "," + Globals.OilTNeedleX + "," + Globals.OilTNeedleY + "," + Globals.OilTOffset + "," + Globals.OilTEnd + "," + Globals.OilTTop + "," + Globals.OilTTextShow + "," + Globals.OilTTextX + "," + Globals.OilTTextY + "," + Globals.OilTFontSize + "," + Globals.OilTTextStyle + "," + Globals.OilTNeedleType + "," + Globals.OilTNeedle + "," + Globals.OilTGPIO;
            Globals.Fuelvalp1 = "Fuel" + "," + Globals.FuelShow + "," + Globals.FuelNeedleWidth + "," + Globals.FuelNeedleLength + "," + Globals.FuelNeedleX + "," + Globals.FuelNeedleY + "," + Globals.FuelOffset + "," + Globals.FuelEnd + "," + Globals.FuelTop + "," + Globals.FuelTextShow + "," + Globals.FuelTextX + "," + Globals.FuelTextY + "," + Globals.FuelFontSize + "," + Globals.FuelTextStyle + "," + Globals.FuelNeedleType + "," + Globals.FuelNeedle + "," + Globals.FuelGPIO;
            Globals.FuelTvalp1 = "FuelT" + "," + Globals.FuelTShow + "," + Globals.FuelTNeedleWidth + "," + Globals.FuelTNeedleLength + "," + Globals.FuelTNeedleX + "," + Globals.FuelTNeedleY + "," + Globals.FuelTOffset + "," + Globals.FuelTEnd + "," + Globals.FuelTTop + "," + Globals.FuelTTextShow + "," + Globals.FuelTTextX + "," + Globals.FuelTTextY + "," + Globals.FuelTFontSize + "," + Globals.FuelTTextStyle + "," + Globals.FuelTNeedleType + "," + Globals.FuelTNeedle + "," + Globals.FuelTGPIO;
            Globals.FuelPvalp1 = "FuelP" + "," + Globals.FuelPShow + "," + Globals.FuelPNeedleWidth + "," + Globals.FuelPNeedleLength + "," + Globals.FuelPNeedleX + "," + Globals.FuelPNeedleY + "," + Globals.FuelPOffset + "," + Globals.FuelPEnd + "," + Globals.FuelPTop + "," + Globals.FuelPTextShow + "," + Globals.FuelPTextX + "," + Globals.FuelPTextY + "," + Globals.FuelPFontSize + "," + Globals.FuelPTextStyle + "," + Globals.FuelPNeedleType + "," + Globals.FuelPNeedle + "," + Globals.FuelPGPIO;
            Globals.Batteryvalp1 = "Battery" + "," + Globals.BatteryShow + "," + Globals.BatteryNeedleWidth + "," + Globals.BatteryNeedleLength + "," + Globals.BatteryNeedleX + "," + Globals.BatteryNeedleY + "," + Globals.BatteryOffset + "," + Globals.BatteryEnd + "," + Globals.BatteryTop + "," + Globals.BatteryTextShow + "," + Globals.BatteryTextX + "," + Globals.BatteryTextY + "," + Globals.BatteryFontSize + "," + Globals.BatteryTextStyle + "," + Globals.BatteryNeedleType + "," + Globals.BatteryNeedle + "," + Globals.BatteryGPIO;
            Globals.User1valp1 = "User1" + "," + Globals.User1Show + "," + Globals.User1NeedleWidth + "," + Globals.User1NeedleLength + "," + Globals.User1NeedleX + "," + Globals.User1NeedleY + "," + Globals.User1Offset + "," + Globals.User1End + "," + Globals.User1Top + "," + Globals.User1TextShow + "," + Globals.User1TextX + "," + Globals.User1TextY + "," + Globals.User1FontSize + "," + Globals.User1TextStyle + "," + Globals.User1NeedleType + "," + Globals.User1Needle + "," + Globals.User1GPIO;
            Globals.User2valp1 = "User2" + "," + Globals.User2Show + "," + Globals.User2NeedleWidth + "," + Globals.User2NeedleLength + "," + Globals.User2NeedleX + "," + Globals.User2NeedleY + "," + Globals.User2Offset + "," + Globals.User2End + "," + Globals.User2Top + "," + Globals.User2TextShow + "," + Globals.User2TextX + "," + Globals.User2TextY + "," + Globals.User2FontSize + "," + Globals.User2TextStyle + "," + Globals.User2NeedleType + "," + Globals.User2Needle + "," + Globals.User2GPIO;
            Globals.User3valp1 = "User3" + "," + Globals.User3Show + "," + Globals.User3NeedleWidth + "," + Globals.User3NeedleLength + "," + Globals.User3NeedleX + "," + Globals.User3NeedleY + "," + Globals.User3Offset + "," + Globals.User3End + "," + Globals.User3Top + "," + Globals.User3TextShow + "," + Globals.User3TextX + "," + Globals.User3TextY + "," + Globals.User3FontSize + "," + Globals.User3TextStyle + "," + Globals.User3NeedleType + "," + Globals.User3Needle + "," + Globals.User3GPIO;
            Globals.User4valp1 = "User4" + "," + Globals.User4Show + "," + Globals.User4NeedleWidth + "," + Globals.User4NeedleLength + "," + Globals.User4NeedleX + "," + Globals.User4NeedleY + "," + Globals.User4Offset + "," + Globals.User4End + "," + Globals.User4Top + "," + Globals.User4TextShow + "," + Globals.User4TextX + "," + Globals.User4TextY + "," + Globals.User4FontSize + "," + Globals.User4TextStyle + "," + Globals.User4NeedleType + "," + Globals.User4Needle + "," + Globals.User4GPIO;

            WriteCSVfile(1);
            Globals.isSaved1 = true;
            this.Close();
        }

        private void moveCenter(string dir)
        {
            using (Graphics p = pictureBG.CreateGraphics())
            {
                //gauge
                if ((dir == "up") && (movingCentre == "gauge"))
                {
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY - 300);
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY + 300);
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX - 300, startPosY);
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX + 300, startPosY);
                    startPosY = startPosY - 1;
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX, startPosY - 300);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX, startPosY + 300);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX - 300, startPosY);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX + 300, startPosY);
                    showCross = true;
                }

                if ((dir == "down") && (movingCentre == "gauge"))
                {
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY - 300);
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY + 300);
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX - 300, startPosY);
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX + 300, startPosY);
                    startPosY = startPosY + 1;
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX, startPosY - 300);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX, startPosY + 300);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX - 300, startPosY);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX + 300, startPosY);
                    showCross = true;
                }

                if ((dir == "left") && (movingCentre == "gauge"))
                {
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY - 300);
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY + 300);
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX - 300, startPosY);
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX + 300, startPosY);
                    startPosX = startPosX - 1;
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX, startPosY - 300);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX, startPosY + 300);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX - 300, startPosY);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX + 300, startPosY);
                    showCross = true;
                }

                if ((dir == "right") && (movingCentre == "gauge"))
                {
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY - 300);
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX, startPosY + 300);
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX - 300, startPosY);
                    p.DrawLine(Pens.Black, startPosX, startPosY, startPosX + 300, startPosY);
                    startPosX = startPosX + 1;
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX, startPosY - 300);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX, startPosY + 300);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX - 300, startPosY);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX + 300, startPosY);
                    showCross = true;
                }

                //text
                if ((dir == "up") && (movingCentre == "text"))
                {
                    placeTextSet(Editing, "black");
                    startPosY = startPosY - 1;
                    placeTextSet(Editing, "white");
                }

                if ((dir == "down") && (movingCentre == "text"))
                {
                    placeTextSet(Editing, "black");
                    startPosY = startPosY + 1;
                    placeTextSet(Editing, "white");
                }

                if ((dir == "left") && (movingCentre == "text"))
                {
                    placeTextSet(Editing, "black");
                    startPosX = startPosX - 1;
                    placeTextSet(Editing, "white");
                }

                if ((dir == "right") && (movingCentre == "text"))
                {
                    placeTextSet(Editing, "black");
                    startPosX = startPosX + 1;
                    placeTextSet(Editing, "white");
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            moveCenter("up");
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            moveCenter("down");
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            moveCenter("right");
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            moveCenter("left");
        }

        private void pnlDirections_Paint(object sender, PaintEventArgs e)
        {
            if (movingCentre == "gauge")
            {
                //draw lines
                using (Graphics p = pictureBG.CreateGraphics())
                {
                    // Draw next line and...
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX, startPosY - 300);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX, startPosY + 300);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX - 300, startPosY);
                    p.DrawLine(Pens.White, startPosX, startPosY, startPosX + 300, startPosY);
                    showCross = true;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (movingCentre == "gauge")
            {
                showCross = true;
                stage += 1;
                lblPrompt.Text = "Click the needle length";
                pnlDirections.Visible = false;
            }

            if (movingCentre == "text")
            {
                placeTextSet(Editing, "black");
                pnlDirections.Visible = false;
                ResetThePage(lbNumber);
            }
        }

        private void sidelight_Click(object sender, EventArgs e)
        {

        }

        private void highbeam_Click(object sender, EventArgs e)
        {

        }

        private void fullbeam_Click(object sender, EventArgs e)
        {

        }

        private void spotlight_Click(object sender, EventArgs e)
        {

        }

        private void foglight_Click(object sender, EventArgs e)
        {

        }

        private void demister_Click(object sender, EventArgs e)
        {

        }

        private void battery_Click(object sender, EventArgs e)
        {

        }

        private void fuel_Click(object sender, EventArgs e)
        {

        }

        private void oil_Click(object sender, EventArgs e)
        {

        }

        private void tyre_Click(object sender, EventArgs e)
        {

        }

        private void washer_Click(object sender, EventArgs e)
        {

        }

        private void wiperint_Click(object sender, EventArgs e)
        {

        }

        private void indleft_Click(object sender, EventArgs e)
        {

        }

        private void indright_Click(object sender, EventArgs e)
        {

        }

        private void hazards_Click(object sender, EventArgs e)
        {

        }

        private void spanner_Click(object sender, EventArgs e)
        {

        }

        private void temp_Click(object sender, EventArgs e)
        {

        }

        private void seatbelts_Click(object sender, EventArgs e)
        {

        }

        private void door_Click(object sender, EventArgs e)
        {

        }

        private void bonnet_Click(object sender, EventArgs e)
        {

        }

        private void boot_Click(object sender, EventArgs e)
        {

        }

        private void Seat1_Click(object sender, EventArgs e)
        {

        }
    }
}