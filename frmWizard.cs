using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

//to call other class functions: 
using static kkdash.WriteCSV;
using static kkdash.ReadCSV;



namespace kkdash
{
    public partial class frmWizard : Form
    {

        public frmWizard()
        {
            InitializeComponent();
        }


        //----------------------------------------------------------Startup--------------------------------------------------------------------------
        private void frmWizard_Load(object sender, EventArgs e)
        {
            Globals.isSaved1 = false;
            Globals.isSaved2 = false;
            Globals.isSaved3 = false;

            TS1.Text = ("Ready    ");
            TS2.Text = ("Ready    ");
            TS3.Text = ("Ready    ");

            MessageBox.Show("Please select the current working director");
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    Globals.flocation = fbd.SelectedPath;
                    this.Activate();
                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    try
                    {
                        populateSymbols();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Cant select no path.  Exiting");
                    this.Close();
                }
            }
        }


        //====================================================================READ SECTION================================================================

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------Open file(s) and load all data---------------------------------------------------------------
            TS1.Text = ("Ready    ");
            TS2.Text = ("Ready    ");
            TS3.Text = ("Ready    ");
            ResetGlobals();
            TS1.Text = ("Reading config    ");
            TS2.Text = ("Ready    ");
            TS3.Text = ("Ready    ");
            ReadTheCSV(1);   //populate panel 1 global configs
            TS1.Text = ("Ready    ");
            TS2.Text = ("Reading config    ");
            TS3.Text = ("Ready    ");

            ReadTheCSV(2);   //populate panel 2 global configs
            TS1.Text = ("Ready    ");
            TS2.Text = ("Ready    ");
            TS3.Text = ("Reading config    ");
            ReadTheCSV(3);   //populate panel 3 global configs
            TS1.Text = ("Ready    ");
            TS2.Text = ("Ready    ");
            TS3.Text = ("Ready    ");

            SymbolsToVars();
            resolveFromVars();

        }

        //=======================================================================SAVE SECTION============================================================================

        private void btnNext_Click(object sender, EventArgs e)
        {
            //-----------------------------------------------------------save all fields------------------------------------------------------------------
            TS1.Text = ("Ready    ");
            TS2.Text = ("Ready    ");
            TS3.Text = ("Ready    ");

            resolveToVars(); //this takes all text except which panel indicators to global vars
            resolvePanelToVars(); //this takes the panel number to global vars
            VarsToSymbols();
            TS1.Text = ("Writing config    ");
            TS2.Text = ("Ready    ");
            TS3.Text = ("Ready    ");
            WriteCSVfile(1);  // write csv panel1 from globals
            TS1.Text = ("Ready    ");
            TS2.Text = ("Writing config    ");
            TS3.Text = ("Ready    ");
            WriteCSVfile(2);  // write csv panel2 from globals
            TS1.Text = ("Ready    ");
            TS2.Text = ("Ready    ");
            TS3.Text = ("Writing config    ");
            WriteCSVfile(3);  // write csv panel3 from globals

            TS1.Text = ("Ready    ");
            TS2.Text = ("Ready    ");
            TS3.Text = ("Ready    ");


            //this.Hide();
            //var form2 = new Form2();
            //form2.Closed += (s, args) => this.Close();
            //form2.Show();

            //display the dash to edit
            // Create a new instance of the Form2 class
            try
            {
                if (Globals.showP1 == "Y")
                {
                    frmGraphic1 frmG1 = new frmGraphic1();

                    // Show the settings form
                    frmG1.Show();
                }

                if (Globals.showP2 == "Y")
                {
                    frmGraphic2 frmG2 = new frmGraphic2();

                    // Show the settings form
                    frmG2.Show();
                }

                if (Globals.showP3 == "Y")
                {
                    frmGraphic3 frmG3 = new frmGraphic3();

                    // Show the settings form
                    frmG3.Show();
                }

                panel1.Hide();
                panel2.Hide();
                panel3.Hide();
                panel4.Hide();
                panel5.Hide();
                btnLoad.Hide();
                btnNext.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void populateSymbols()
        {
            Seat1.Image = System.Drawing.Image.FromFile(@Globals.flocation + "\\symbols\\seats\\seat1-3.png");
            Seat1.SizeMode = PictureBoxSizeMode.StretchImage;
            Seat2.Image = System.Drawing.Image.FromFile(@Globals.flocation + "\\symbols\\seats\\seat2-3.png");
            Seat2.SizeMode = PictureBoxSizeMode.StretchImage;
            door.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\door\\both.png");
            door.SizeMode = PictureBoxSizeMode.StretchImage;
            bonnet.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\door\\bonnet.png");
            bonnet.SizeMode = PictureBoxSizeMode.StretchImage;
            boot.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\door\\boot.png");
            boot.SizeMode = PictureBoxSizeMode.StretchImage;
            demister.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\info\\demister.png");
            demister.SizeMode = PictureBoxSizeMode.StretchImage;
            battery.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\info\\battery.png");
            battery.SizeMode = PictureBoxSizeMode.StretchImage;
            fuel.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\info\\fuel.png");
            fuel.SizeMode = PictureBoxSizeMode.StretchImage;
            oil.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\info\\oil.png");
            oil.SizeMode = PictureBoxSizeMode.StretchImage;
            tyre.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\info\\tyre.png");
            tyre.SizeMode = PictureBoxSizeMode.StretchImage;
            washer.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\info\\washer.png");
            washer.SizeMode = PictureBoxSizeMode.StretchImage;
            wiperint.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\info\\wiper-int.png");
            wiperint.SizeMode = PictureBoxSizeMode.StretchImage;
            indleft.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\indicators\\ind-left.png");
            indleft.SizeMode = PictureBoxSizeMode.StretchImage;
            indright.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\indicators\\ind-right.png");
            indright.SizeMode = PictureBoxSizeMode.StretchImage;
            hazards.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\hazard\\hazards-on.png");
            hazards.SizeMode = PictureBoxSizeMode.StretchImage;
            spanner.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\hazard\\spanner.png");
            spanner.SizeMode = PictureBoxSizeMode.StretchImage;
            temp.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\hazard\\temp.png");
            temp.SizeMode = PictureBoxSizeMode.StretchImage;
            seatbelts.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\seatbelts\\all.png");
            seatbelts.SizeMode = PictureBoxSizeMode.StretchImage;
            sidelight.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\lights\\sidelights.png");
            sidelight.SizeMode = PictureBoxSizeMode.StretchImage;
            highbeam.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\lights\\headlights.png");
            highbeam.SizeMode = PictureBoxSizeMode.StretchImage;
            fullbeam.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\lights\\fullbeam.png");
            fullbeam.SizeMode = PictureBoxSizeMode.StretchImage;
            spotlight.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\lights\\spotlights.png");
            spotlight.SizeMode = PictureBoxSizeMode.StretchImage;
            foglight.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\lights\\foglight.png");
            foglight.SizeMode = PictureBoxSizeMode.StretchImage;
            brakes.Image = System.Drawing.Image.FromFile(Globals.flocation + "\\symbols\\hazard\\brakes.png");
            brakes.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //--------------------------------------------------------------------------------Gauge / barV / BarH -------------------------------------------------------------------------------------
        private void setupgauges(string gaugechoice)
        {
            switch (gaugechoice)
            {
                case "Speedo":
                    if ((cmbSpeedo.Text.ToLower() == "gauge")|| (cmbSpeedo.Text == ""))
                    {
                        lblWarn.Visible = false;
                        txtSpeedoNeedle.Text = "textures/instrument_needle.png";
                        Globals.SpeedoNeedle = txtSpeedoNeedle.Text;
                        Globals.SpeedoNeedleType = "gauge";
                        cmbSpeedo.Text = "gauge";
                    }

                    if (cmbSpeedo.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtSpeedoNeedle.Text = "50";
                        Globals.SpeedoNeedle = txtSpeedoNeedle.Text;
                        Globals.SpeedoNeedleType = "barV";
                    }
                    if (cmbSpeedo.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtSpeedoNeedle.Text = "50";
                        Globals.SpeedoNeedle = txtSpeedoNeedle.Text;
                        Globals.SpeedoNeedleType = "barH";
                    }
                    break;

                case "Tacho":
                    if ((cmbTacho.Text.ToLower() == "gauge") || (cmbTacho.Text == ""))
                    {
                        lblWarn.Visible = false;
                        txtTachoNeedle.Text = "textures/instrument_needle.png";
                        Globals.TachoNeedle = txtTachoNeedle.Text;
                        Globals.TachoNeedleType = "gauge";
                        cmbTacho.Text = "gauge";
                    }

                    if (cmbTacho.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtTachoNeedle.Text = "50";
                        Globals.TachoNeedle = txtTachoNeedle.Text;
                        Globals.TachoNeedleType = "barV";
                    }
                    if (cmbTacho.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtTachoNeedle.Text = "50";
                        Globals.TachoNeedle = txtTachoNeedle.Text;
                        Globals.TachoNeedleType = "barH";
                    }
                    break;

                case "Boost":
                    if ((cmbBoost.Text.ToLower() == "gauge") || (cmbBoost.Text == ""))
                    {
                        lblWarn.Visible = false;
                        txtBoostNeedle.Text = "textures/instrument_needle.png";
                        Globals.BoostNeedle = txtBoostNeedle.Text;
                        Globals.BoostNeedleType = "gauge";
                        cmbBoost.Text = "gauge";
                    }

                    if (cmbBoost.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtBoostNeedle.Text = "50";
                        Globals.BoostNeedle = txtBoostNeedle.Text;
                        Globals.BoostNeedleType = "barV";
                    }
                    if (cmbBoost.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtBoostNeedle.Text = "50";
                        Globals.BoostNeedle = txtBoostNeedle.Text;
                        Globals.BoostNeedleType = "barH";
                    }
                    break;

                case "Temp":
                    if ((cmbTemp.Text.ToLower() == "gauge")||(cmbTemp.Text == ""))
                    {
                        lblWarn.Visible = false;
                        txtTempNeedle.Text = "textures/instrument_needle.png";
                        Globals.TempNeedle = txtTempNeedle.Text;
                        Globals.TempNeedleType = "gauge";
                        cmbTemp.Text = "gauge";
                    }

                    if (cmbTemp.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtTempNeedle.Text = "50";
                        Globals.TempNeedle = txtTempNeedle.Text;
                        Globals.TempNeedleType = "barV";
                    }
                    if (cmbTemp.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtTempNeedle.Text = "50";
                        Globals.TempNeedle = txtTempNeedle.Text;
                        Globals.TempNeedleType = "barH";
                    }
                    break;

                case "Oil":
                    if ((cmbOil.Text.ToLower() == "gauge") || (cmbOil.Text == ""))
                    {
                        lblWarn.Visible = false;
                        txtOilNeedle.Text = "textures/instrument_needle.png";
                        Globals.OilNeedle = txtOilNeedle.Text;
                        Globals.OilNeedleType = "gauge";
                        cmbOil.Text = "gauge";
                    }

                    if (cmbOil.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtOilNeedle.Text = "50";
                        Globals.OilNeedle = txtOilNeedle.Text;
                        Globals.OilNeedleType = "barV";
                    }
                    if (cmbOil.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtOilNeedle.Text = "50";
                        Globals.OilNeedle = txtOilNeedle.Text;
                        Globals.OilNeedleType = "barH";
                    }
                    break;


                case "OilT":
                    if ((cmbOilT.Text.ToLower() == "gauge") || (cmbOilT.Text == ""))
                    {
                        lblWarn.Visible = false;
                        txtOilTNeedle.Text = "textures/instrument_needle.png";
                        Globals.OilTNeedle = txtOilTNeedle.Text;
                        Globals.OilTNeedleType = "gauge";
                        cmbOilT.Text = "gauge";
                    }

                    if (cmbOilT.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtOilTNeedle.Text = "50";
                        Globals.OilTNeedle = txtOilTNeedle.Text;
                        Globals.OilTNeedleType = "barV";
                    }
                    if (cmbOilT.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtOilTNeedle.Text = "50";
                        Globals.OilTNeedle = txtOilTNeedle.Text;
                        Globals.OilTNeedleType = "barH";
                    }
                    break;

                case "Fuel":
                    if ((cmbFuel.Text.ToLower() == "gauge") || (cmbFuel.Text == ""))
                    {
                        lblWarn.Visible = false;
                        txtFuelNeedle.Text = "textures/instrument_needle.png";
                        Globals.FuelNeedle = txtFuelNeedle.Text;
                        Globals.FuelNeedleType = "gauge";
                        cmbFuel.Text = "gauge";
                    }

                    if (cmbFuel.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtFuelNeedle.Text = "50";
                        Globals.FuelNeedle = txtFuelNeedle.Text;
                        Globals.FuelNeedleType = "barV";
                    }
                    if (cmbFuel.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtFuelNeedle.Text = "50";
                        Globals.FuelNeedle = txtFuelNeedle.Text;
                        Globals.FuelNeedleType = "barH";
                    }
                    break;

                case "FuelT":
                    if ((cmbFuelT.Text.ToLower() == "gauge") || (cmbFuelT.Text == ""))
                    {
                        lblWarn.Visible = false;
                        txtFuelTNeedle.Text = "textures/instrument_needle.png";
                        Globals.FuelTNeedle = txtFuelTNeedle.Text;
                        Globals.FuelTNeedleType = "gauge";
                        cmbFuelT.Text = "gauge";
                    }

                    if (cmbFuelT.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtFuelTNeedle.Text = "50";
                        Globals.FuelTNeedle = txtFuelTNeedle.Text;
                        Globals.FuelTNeedleType = "barV";
                    }
                    if (cmbFuelT.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtFuelTNeedle.Text = "50";
                        Globals.FuelTNeedle = txtFuelTNeedle.Text;
                        Globals.FuelTNeedleType = "barH";
                    }
                    break;

                case "FuelP":
                    if ((cmbFuelP.Text.ToLower() == "gauge") || (cmbFuelP.Text == ""))
                    {
                        lblWarn.Visible = false;
                        txtFuelPNeedle.Text = "textures/instrument_needle.png";
                        Globals.FuelPNeedle = txtFuelPNeedle.Text;
                        Globals.FuelPNeedleType = "gauge";
                        cmbFuelP.Text = "gauge";
                    }

                    if (cmbFuelP.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtFuelPNeedle.Text = "50";
                        Globals.FuelPNeedle = txtFuelPNeedle.Text;
                        Globals.FuelPNeedleType = "barV";
                    }
                    if (cmbFuelP.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtFuelPNeedle.Text = "50";
                        Globals.FuelPNeedle = txtFuelPNeedle.Text;
                        Globals.FuelPNeedleType = "barH";
                    }
                    break;

                case "Battery":
                    if ((cmbBattery.Text.ToLower() == "gauge") || (cmbBattery.Text == ""))
                    {
                        lblWarn.Visible = false;
                        txtBatteryNeedle.Text = "textures/instrument_needle.png";
                        Globals.BatteryNeedle = txtBatteryNeedle.Text;
                        Globals.BatteryNeedleType = "gauge";
                        cmbBattery.Text = "gauge";
                    }

                    if (cmbBattery.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtBatteryNeedle.Text = "50";
                        Globals.BatteryNeedle = txtBatteryNeedle.Text;
                        Globals.BatteryNeedleType = "barV";
                    }
                    if (cmbBattery.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtBatteryNeedle.Text = "50";
                        Globals.BatteryNeedle = txtBatteryNeedle.Text;
                        Globals.BatteryNeedleType = "barH";
                    }
                    break;

                case "User1":
                    if ((cmbUser1.Text.ToLower() == "gauge") || (cmbUser1.Text == ""))
                    {
                        lblWarn.Visible = false;
                        txtUser1Needle.Text = "textures/instrument_needle.png";
                        Globals.User1Needle = txtUser1Needle.Text;
                        Globals.User1NeedleType = "gauge";
                        cmbUser1.Text = "gauge";
                    }

                    if (cmbUser1.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser1Needle.Text = "50";
                        Globals.User1Needle = txtUser1Needle.Text;
                        Globals.User1NeedleType = "barV";
                    }
                    if (cmbUser1.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser1Needle.Text = "50";
                        Globals.User1Needle = txtUser1Needle.Text;
                        Globals.User1NeedleType = "barH";
                    }
                    break;

                case "User2":
                    if ((cmbUser2.Text.ToLower() == "gauge") || (cmbUser2.Text == ""))
                    {
                        lblWarn.Visible = false;
                        txtUser2Needle.Text = "textures/instrument_needle.png";
                        Globals.User2Needle = txtUser2Needle.Text;
                        Globals.User2NeedleType = "gauge";
                        cmbUser2.Text = "gauge";
                    }

                    if (cmbUser2.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser2Needle.Text = "50";
                        Globals.User2Needle = txtUser2Needle.Text;
                        Globals.User2NeedleType = "barV";
                    }
                    if (cmbUser2.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser2Needle.Text = "50";
                        Globals.User2Needle = txtUser2Needle.Text;
                        Globals.User2NeedleType = "barH";
                    }
                    break;

                case "User3":
                    if ((cmbUser3.Text.ToLower() == "gauge") || (cmbUser3.Text == ""))
                    {
                        lblWarn.Visible = false;
                        txtUser3Needle.Text = "textures/instrument_needle.png";
                        Globals.User3Needle = txtUser3Needle.Text;
                        Globals.User3NeedleType = "gauge";
                        cmbUser3.Text = "gauge";
                    }

                    if (cmbUser3.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser3Needle.Text = "50";
                        Globals.User3Needle = txtUser3Needle.Text;
                        Globals.User3NeedleType = "barV";
                    }
                    if (cmbUser3.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser3Needle.Text = "50";
                        Globals.User3Needle = txtUser3Needle.Text;
                        Globals.User3NeedleType = "barH";
                    }
                    break;

                case "User4":
                    if ((cmbUser4.Text.ToLower() == "gauge") || (cmbUser4.Text == ""))
                    {
                        lblWarn.Visible = false;
                        txtUser4Needle.Text = "textures/instrument_needle.png";
                        Globals.User4Needle = txtUser4Needle.Text;
                        Globals.User4NeedleType = "gauge";
                        cmbUser4.Text = "gauge";
                    }

                    if (cmbUser4.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser4Needle.Text = "50";
                        Globals.User4Needle = txtUser4Needle.Text;
                        Globals.User4NeedleType = "barV";
                    }
                    if (cmbUser4.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser4Needle.Text = "50";
                        Globals.User4Needle = txtUser4Needle.Text;
                        Globals.User4NeedleType = "barH";
                    }
                    break;
            }
        }

        //------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------Backgrounds-----------------------------------------------------------------------------------------
        private void btnPanel1BG_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Globals.flocation;
                openFileDialog.Filter = "Picture files All files (*.*)|*.*|(*.jpg)|*.jpg|(*.bmp)|*.bmp|(*.gif)|*.gif";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the filename only from the path of specified file
                    Globals.panel1path = openFileDialog.FileName;
                    lblP1Path.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                }
            }
        }

        private void btnP2BG_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Globals.flocation;
                openFileDialog.Filter = "Picture files All files (*.*)|*.*|(*.jpg)|*.jpg|(*.bmp)|*.bmp|(*.gif)|*.gif";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the filename only from the path of specified file
                    Globals.panel2path = openFileDialog.FileName;
                    lblP2Path.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                }
            }
        }

        private void btnP3BG_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Globals.flocation;
                openFileDialog.Filter = "Picture files All files (*.*)|*.*|(*.jpg)|*.jpg|(*.bmp)|*.bmp|(*.gif)|*.gif";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the filename only from the path of specified file
                    Globals.panel3path = openFileDialog.FileName;
                    lblP3Path.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                }
            }
        }



        //-------------------------------------------------------------------------------send textboxes to variables ----------------------------------------------------------------------------------

        private void resolvePanelToVars()
        {

            //=======================================================================items held in the config==================================================================


            Globals.p1DispWidth = txtP1Width.Text;
            Globals.p1DispHeight = txtP1Height.Text;

            Globals.p2DispWidth = txtP2Width.Text;
            Globals.p2DispHeight = txtP2Height.Text;

            Globals.p3DispWidth = txtP3Width.Text;
            Globals.p3DispHeight = txtP3Height.Text;

            Globals.P1BG = lblP1Path.Text;
            Globals.P2BG = lblP2Path.Text;
            Globals.P3BG = lblP3Path.Text;

            //Speedo
            //            Globals.gaugename = ""; Globals.SpeedoShow = "N"; Globals.SpeedoTextShow = "N";  //reset to no values
            if (cmbShowSpeedo.Text == "N") { Globals.SpeedoShow = "N"; }
            if (cmbSpeedoTextShow.Text == "N") { Globals.SpeedoTextShow = "N"; }
            if (cmbShowSpeedo.Text == "Panel 1") { Globals.SpeedoShow = "1"; }
            if (cmbSpeedoTextShow.Text == "Panel 1") { Globals.SpeedoTextShow = "1"; }
            if (cmbShowSpeedo.Text == "Panel 2") { Globals.SpeedoShow = "2"; }
            if (cmbSpeedoTextShow.Text == "Panel 2") { Globals.SpeedoTextShow = "2"; }
            if (cmbShowSpeedo.Text == "Panel 3") { Globals.SpeedoShow = "3"; }
            if (cmbSpeedoTextShow.Text == "Panel 3") { Globals.SpeedoTextShow = "3"; }

            if ((Globals.SpeedoShow == "1") || (Globals.SpeedoTextShow == "1"))
            {
                Globals.gaugename = "speedo";
                Globals.showP1 = "Y";
                if ((Globals.SpeedoShow == "1") && (Globals.SpeedoTextShow != "1")) { Globals.SpeedoTextShow = "N"; } 
                if ((Globals.SpeedoShow != "1") && (Globals.SpeedoTextShow == "1")) { Globals.SpeedoShow = "N"; }
                Globals.Speedovalp1 = Globals.gaugename + "," + Globals.SpeedoShow + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle + "," + Globals.SpeedoGPIO;
            }
            if ((Globals.SpeedoShow == "2") || (Globals.SpeedoTextShow == "2"))
            {
                Globals.gaugename = "speedo";
                Globals.showP2 = "Y";
                if ((Globals.SpeedoShow == "2") && (Globals.SpeedoTextShow != "2")) { Globals.SpeedoTextShow = "N"; }
                if ((Globals.SpeedoShow != "2") && (Globals.SpeedoTextShow == "2")) { Globals.SpeedoShow = "N"; }
                Globals.Speedovalp2 = Globals.gaugename + "," + Globals.SpeedoShow + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle + "," + Globals.SpeedoGPIO;
            }
            if ((Globals.SpeedoShow == "3") || (Globals.SpeedoTextShow == "3"))
            {
                Globals.gaugename = "speedo";
                Globals.showP3 = "Y";
                if ((Globals.SpeedoShow == "3") && (Globals.SpeedoTextShow != "3")) { Globals.SpeedoTextShow = "N"; }
                if ((Globals.SpeedoShow != "3") && (Globals.SpeedoTextShow == "3")) { Globals.SpeedoShow = "N"; }
                Globals.Speedovalp3 = Globals.gaugename + "," + Globals.SpeedoShow + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle + "," + Globals.SpeedoGPIO;
            }

            //Tacho
            //            Globals.gaugename = ""; Globals.TachoShow = "N"; Globals.TachoTextShow = "N";  //reset to no values
            if (cmbShowTacho.Text == "N") { Globals.TachoShow = "N"; }
            if (cmbTachoTextShow.Text == "N") { Globals.TachoTextShow = "N"; }
            if (cmbShowTacho.Text == "Panel 1") { Globals.TachoShow = "1"; }
            if (cmbTachoTextShow.Text == "Panel 1") { Globals.TachoTextShow = "1"; }
            if (cmbShowTacho.Text == "Panel 2") { Globals.TachoShow = "2"; }
            if (cmbTachoTextShow.Text == "Panel 2") { Globals.TachoTextShow = "2"; }
            if (cmbShowTacho.Text == "Panel 3") { Globals.TachoShow = "3"; }
            if (cmbTachoTextShow.Text == "Panel 3") { Globals.TachoTextShow = "3"; }

            if ((Globals.TachoShow == "1") || (Globals.TachoTextShow == "1"))
            {
                Globals.gaugename = "Tacho";
                Globals.showP1 = "Y";
                if ((Globals.TachoShow == "1") && (Globals.TachoTextShow != "1")) { Globals.TachoTextShow = "N"; }
                if ((Globals.TachoShow != "1") && (Globals.TachoTextShow == "1")) { Globals.TachoShow = "N"; }
                Globals.Tachovalp1 = Globals.gaugename + "," + Globals.TachoShow + "," + Globals.TachoNeedleWidth + "," + Globals.TachoNeedleLength + "," + Globals.TachoNeedleX + "," + Globals.TachoNeedleY + "," + Globals.TachoOffset + "," + Globals.TachoEnd + "," + Globals.TachoTop + "," + Globals.TachoTextShow + "," + Globals.TachoTextX + "," + Globals.TachoTextY + "," + Globals.TachoFontSize + "," + Globals.TachoTextStyle + "," + Globals.TachoNeedleType + "," + Globals.TachoNeedle + "," + Globals.TachoGPIO;
            }
            if ((Globals.TachoShow == "2") || (Globals.TachoTextShow == "2"))
            {
                Globals.gaugename = "Tacho";
                Globals.showP2 = "Y";
                if ((Globals.TachoShow == "2") && (Globals.TachoTextShow != "2")) { Globals.TachoTextShow = "N"; }
                if ((Globals.TachoShow != "2") && (Globals.TachoTextShow == "2")) { Globals.TachoShow = "N"; }
                Globals.Tachovalp2 = Globals.gaugename + "," + Globals.TachoShow + "," + Globals.TachoNeedleWidth + "," + Globals.TachoNeedleLength + "," + Globals.TachoNeedleX + "," + Globals.TachoNeedleY + "," + Globals.TachoOffset + "," + Globals.TachoEnd + "," + Globals.TachoTop + "," + Globals.TachoTextShow + "," + Globals.TachoTextX + "," + Globals.TachoTextY + "," + Globals.TachoFontSize + "," + Globals.TachoTextStyle + "," + Globals.TachoNeedleType + "," + Globals.TachoNeedle + "," + Globals.TachoGPIO;
            }
            if ((Globals.TachoShow == "3") || (Globals.TachoTextShow == "3"))
            {
                Globals.gaugename = "Tacho";
                Globals.showP3 = "Y";
                if ((Globals.TachoShow == "3") && (Globals.TachoTextShow != "3")) { Globals.TachoTextShow = "N"; }
                if ((Globals.TachoShow != "3") && (Globals.TachoTextShow == "3")) { Globals.TachoShow = "N"; }
                Globals.Tachovalp3 = Globals.gaugename + "," + Globals.TachoShow + "," + Globals.TachoNeedleWidth + "," + Globals.TachoNeedleLength + "," + Globals.TachoNeedleX + "," + Globals.TachoNeedleY + "," + Globals.TachoOffset + "," + Globals.TachoEnd + "," + Globals.TachoTop + "," + Globals.TachoTextShow + "," + Globals.TachoTextX + "," + Globals.TachoTextY + "," + Globals.TachoFontSize + "," + Globals.TachoTextStyle + "," + Globals.TachoNeedleType + "," + Globals.TachoNeedle + "," + Globals.TachoGPIO;
            }

            //Boost
            //            Globals.gaugename = ""; Globals.BoostShow = "N"; Globals.BoostTextShow = "N";  //reset to no values
            if (cmbShowBoost.Text == "N") { Globals.BoostShow = "N"; }
            if (cmbBoostTextShow.Text == "N") { Globals.BoostTextShow = "N"; }
            if (cmbShowBoost.Text == "Panel 1") { Globals.BoostShow = "1"; }
            if (cmbBoostTextShow.Text == "Panel 1") { Globals.BoostTextShow = "1"; }
            if (cmbShowBoost.Text == "Panel 2") { Globals.BoostShow = "2"; }
            if (cmbBoostTextShow.Text == "Panel 2") { Globals.BoostTextShow = "2"; }
            if (cmbShowBoost.Text == "Panel 3") { Globals.BoostShow = "3"; }
            if (cmbBoostTextShow.Text == "Panel 3") { Globals.BoostTextShow = "3"; }

            if ((Globals.BoostShow == "1") || (Globals.BoostTextShow == "1"))
            {
                Globals.gaugename = "Boost";
                Globals.showP1 = "Y";
                if ((Globals.BoostShow == "1") && (Globals.BoostTextShow != "1")) { Globals.BoostTextShow = "N"; }
                if ((Globals.BoostShow != "1") && (Globals.BoostTextShow == "1")) { Globals.BoostShow = "N"; }
                Globals.Boostvalp2 = Globals.gaugename + "," + Globals.BoostShow + "," + Globals.BoostNeedleWidth + "," + Globals.BoostNeedleLength + "," + Globals.BoostNeedleX + "," + Globals.BoostNeedleY + "," + Globals.BoostOffset + "," + Globals.BoostEnd + "," + Globals.BoostTop + "," + Globals.BoostTextShow + "," + Globals.BoostTextX + "," + Globals.BoostTextY + "," + Globals.BoostFontSize + "," + Globals.BoostTextStyle + "," + Globals.BoostNeedleType + "," + Globals.BoostNeedle + "," + Globals.BoostGPIO;
            }
            if ((Globals.BoostShow == "2") || (Globals.BoostTextShow == "2"))
            {
                Globals.gaugename = "Boost";
                Globals.showP2 = "Y";
                if ((Globals.BoostShow == "2") && (Globals.BoostTextShow != "2")) { Globals.BoostTextShow = "N"; }
                if ((Globals.BoostShow != "2") && (Globals.BoostTextShow == "2")) { Globals.BoostShow = "N"; }
                Globals.Boostvalp1 = Globals.gaugename + "," + Globals.BoostShow + "," + Globals.BoostNeedleWidth + "," + Globals.BoostNeedleLength + "," + Globals.BoostNeedleX + "," + Globals.BoostNeedleY + "," + Globals.BoostOffset + "," + Globals.BoostEnd + "," + Globals.BoostTop + "," + Globals.BoostTextShow + "," + Globals.BoostTextX + "," + Globals.BoostTextY + "," + Globals.BoostFontSize + "," + Globals.BoostTextStyle + "," + Globals.BoostNeedleType + "," + Globals.BoostNeedle + "," + Globals.BoostGPIO;
            }
            if ((Globals.BoostShow == "3") || (Globals.BoostTextShow == "3"))
            {
                Globals.gaugename = "Boost";
                Globals.showP3 = "Y";
                if ((Globals.BoostShow == "3") && (Globals.BoostTextShow != "3")) { Globals.BoostTextShow = "N"; }
                if ((Globals.BoostShow != "3") && (Globals.BoostTextShow == "3")) { Globals.BoostShow = "N"; }
                Globals.Boostvalp3 = Globals.gaugename + "," + Globals.BoostShow + "," + Globals.BoostNeedleWidth + "," + Globals.BoostNeedleLength + "," + Globals.BoostNeedleX + "," + Globals.BoostNeedleY + "," + Globals.BoostOffset + "," + Globals.BoostEnd + "," + Globals.BoostTop + "," + Globals.BoostTextShow + "," + Globals.BoostTextX + "," + Globals.BoostTextY + "," + Globals.BoostFontSize + "," + Globals.BoostTextStyle + "," + Globals.BoostNeedleType + "," + Globals.BoostNeedle + "," + Globals.BoostGPIO;
            }

            //Temp
            //            Globals.gaugename = ""; Globals.TempShow = "N"; Globals.TempTextShow = "N";  //reset to no values
            if (cmbShowTemp.Text == "N") { Globals.TempShow = "N"; }
            if (cmbTempTextShow.Text == "N") { Globals.TempTextShow = "N"; }
            if (cmbShowTemp.Text == "Panel 1") { Globals.TempShow = "1"; }
            if (cmbTempTextShow.Text == "Panel 1") { Globals.TempTextShow = "1"; }
            if (cmbShowTemp.Text == "Panel 2") { Globals.TempShow = "2"; }
            if (cmbTempTextShow.Text == "Panel 2") { Globals.TempTextShow = "2"; }
            if (cmbShowTemp.Text == "Panel 3") { Globals.TempShow = "3"; }
            if (cmbTempTextShow.Text == "Panel 3") { Globals.TempTextShow = "3"; }

            if ((Globals.TempShow == "1") || (Globals.TempTextShow == "1"))
            {
                Globals.gaugename = "Temp";
                Globals.showP1 = "Y";
                if ((Globals.TempShow == "1") && (Globals.TempTextShow != "1")) { Globals.TempTextShow = "N"; }
                if ((Globals.TempShow != "1") && (Globals.TempTextShow == "1")) { Globals.TempShow = "N"; }
                Globals.Tempvalp1 = Globals.gaugename + "," + Globals.TempShow + "," + Globals.TempNeedleWidth + "," + Globals.TempNeedleLength + "," + Globals.TempNeedleX + "," + Globals.TempNeedleY + "," + Globals.TempOffset + "," + Globals.TempEnd + "," + Globals.TempTop + "," + Globals.TempTextShow + "," + Globals.TempTextX + "," + Globals.TempTextY + "," + Globals.TempFontSize + "," + Globals.TempTextStyle + "," + Globals.TempNeedleType + "," + Globals.TempNeedle + "," + Globals.TempGPIO;
            }
            if ((Globals.TempShow == "2") || (Globals.TempTextShow == "2"))
            {
                Globals.gaugename = "Temp";
                Globals.showP2 = "Y";
                if ((Globals.TempShow == "2") && (Globals.TempTextShow != "2")) { Globals.TempTextShow = "N"; }
                if ((Globals.TempShow != "2") && (Globals.TempTextShow == "2")) { Globals.TempShow = "N"; }
                Globals.Tempvalp2 = Globals.gaugename + "," + Globals.TempShow + "," + Globals.TempNeedleWidth + "," + Globals.TempNeedleLength + "," + Globals.TempNeedleX + "," + Globals.TempNeedleY + "," + Globals.TempOffset + "," + Globals.TempEnd + "," + Globals.TempTop + "," + Globals.TempTextShow + "," + Globals.TempTextX + "," + Globals.TempTextY + "," + Globals.TempFontSize + "," + Globals.TempTextStyle + "," + Globals.TempNeedleType + "," + Globals.TempNeedle + "," + Globals.TempGPIO;
            }
            if ((Globals.TempShow == "3") || (Globals.TempTextShow == "3"))
            {
                Globals.gaugename = "Temp";
                Globals.showP3 = "Y";
                if ((Globals.TempShow == "3") && (Globals.TempTextShow != "3")) { Globals.TempTextShow = "N"; }
                if ((Globals.TempShow != "3") && (Globals.TempTextShow == "3")) { Globals.TempShow = "N"; }
                Globals.Tempvalp3 = Globals.gaugename + "," + Globals.TempShow + "," + Globals.TempNeedleWidth + "," + Globals.TempNeedleLength + "," + Globals.TempNeedleX + "," + Globals.TempNeedleY + "," + Globals.TempOffset + "," + Globals.TempEnd + "," + Globals.TempTop + "," + Globals.TempTextShow + "," + Globals.TempTextX + "," + Globals.TempTextY + "," + Globals.TempFontSize + "," + Globals.TempTextStyle + "," + Globals.TempNeedleType + "," + Globals.TempNeedle + "," + Globals.TempGPIO;
            }

            //Oil
            //            Globals.gaugename = ""; Globals.OilShow = "N"; Globals.OilTextShow = "N";  //reset to no values
            if (cmbShowOil.Text == "N") { Globals.OilShow = "N"; }
            if (cmbOilTextShow.Text == "N") { Globals.OilTextShow = "N"; }
            if (cmbShowOil.Text == "Panel 1") { Globals.OilShow = "1"; }
            if (cmbOilTextShow.Text == "Panel 1") { Globals.OilTextShow = "1"; }
            if (cmbShowOil.Text == "Panel 2") { Globals.OilShow = "2"; }
            if (cmbOilTextShow.Text == "Panel 2") { Globals.OilTextShow = "2"; }
            if (cmbShowOil.Text == "Panel 3") { Globals.OilShow = "3"; }
            if (cmbOilTextShow.Text == "Panel 3") { Globals.OilTextShow = "3"; }

            if ((Globals.OilShow == "1") || (Globals.OilTextShow == "1"))
            {
                Globals.gaugename = "Oil";
                Globals.showP1 = "Y";
                if ((Globals.OilShow == "1") && (Globals.OilTextShow != "1")) { Globals.OilTextShow = "N"; }
                if ((Globals.OilShow != "1") && (Globals.OilTextShow == "1")) { Globals.OilShow = "N"; }
                Globals.Oilvalp1 = Globals.gaugename + "," + Globals.OilShow + "," + Globals.OilNeedleWidth + "," + Globals.OilNeedleLength + "," + Globals.OilNeedleX + "," + Globals.OilNeedleY + "," + Globals.OilOffset + "," + Globals.OilEnd + "," + Globals.OilTop + "," + Globals.OilTextShow + "," + Globals.OilTextX + "," + Globals.OilTextY + "," + Globals.OilFontSize + "," + Globals.OilTextStyle + "," + Globals.OilNeedleType + "," + Globals.OilNeedle + "," + Globals.OilGPIO;
            }
            if ((Globals.OilShow == "2") || (Globals.OilTextShow == "2"))
            {
                Globals.gaugename = "Oil";
                Globals.showP2 = "Y";
                if ((Globals.OilShow == "2") && (Globals.OilTextShow != "2")) { Globals.OilTextShow = "N"; }
                if ((Globals.OilShow != "2") && (Globals.OilTextShow == "2")) { Globals.OilShow = "N"; }
                Globals.Oilvalp2 = Globals.gaugename + "," + Globals.OilShow + "," + Globals.OilNeedleWidth + "," + Globals.OilNeedleLength + "," + Globals.OilNeedleX + "," + Globals.OilNeedleY + "," + Globals.OilOffset + "," + Globals.OilEnd + "," + Globals.OilTop + "," + Globals.OilTextShow + "," + Globals.OilTextX + "," + Globals.OilTextY + "," + Globals.OilFontSize + "," + Globals.OilTextStyle + "," + Globals.OilNeedleType + "," + Globals.OilNeedle + "," + Globals.OilGPIO;
            }
            if ((Globals.OilShow == "3") || (Globals.OilTextShow == "3"))
            {
                Globals.gaugename = "Oil";
                Globals.showP3 = "Y";
                if ((Globals.OilShow == "3") && (Globals.OilTextShow != "3")) { Globals.OilTextShow = "N"; }
                if ((Globals.OilShow != "3") && (Globals.OilTextShow == "3")) { Globals.OilShow = "N"; }
                Globals.Oilvalp3 = Globals.gaugename + "," + Globals.OilShow + "," + Globals.OilNeedleWidth + "," + Globals.OilNeedleLength + "," + Globals.OilNeedleX + "," + Globals.OilNeedleY + "," + Globals.OilOffset + "," + Globals.OilEnd + "," + Globals.OilTop + "," + Globals.OilTextShow + "," + Globals.OilTextX + "," + Globals.OilTextY + "," + Globals.OilFontSize + "," + Globals.OilTextStyle + "," + Globals.OilNeedleType + "," + Globals.OilNeedle + "," + Globals.OilGPIO;
            }

            //OilT
            //            Globals.gaugename = ""; Globals.OilTShow = "N"; Globals.OilTTextShow = "N";  //reset to no values
            if (cmbShowOilT.Text == "N") { Globals.OilTShow = "N"; }
            if (cmbOilTTextShow.Text == "N") { Globals.OilTTextShow = "N"; }
            if (cmbShowOilT.Text == "Panel 1") { Globals.OilTShow = "1"; }
            if (cmbOilTTextShow.Text == "Panel 1") { Globals.OilTTextShow = "1"; }
            if (cmbShowOilT.Text == "Panel 2") { Globals.OilTShow = "2"; }
            if (cmbOilTTextShow.Text == "Panel 2") { Globals.OilTTextShow = "2"; }
            if (cmbShowOilT.Text == "Panel 3") { Globals.OilTShow = "3"; }
            if (cmbOilTTextShow.Text == "Panel 3") { Globals.OilTTextShow = "3"; }

            if ((Globals.OilTShow == "1") || (Globals.OilTTextShow == "1"))
            {
                Globals.gaugename = "OilT";
                Globals.showP1 = "Y";
                if ((Globals.OilTShow == "1") && (Globals.OilTTextShow != "1")) { Globals.OilTTextShow = "N"; }
                if ((Globals.OilTShow != "1") && (Globals.OilTTextShow == "1")) { Globals.OilTShow = "N"; }
                Globals.OilTvalp1 = Globals.gaugename + "," + Globals.OilTShow + "," + Globals.OilTNeedleWidth + "," + Globals.OilTNeedleLength + "," + Globals.OilTNeedleX + "," + Globals.OilTNeedleY + "," + Globals.OilTOffset + "," + Globals.OilTEnd + "," + Globals.OilTTop + "," + Globals.OilTTextShow + "," + Globals.OilTTextX + "," + Globals.OilTTextY + "," + Globals.OilTFontSize + "," + Globals.OilTTextStyle + "," + Globals.OilTNeedleType + "," + Globals.OilTNeedle + "," + Globals.OilTGPIO;
            }
            if ((Globals.OilTShow == "2") || (Globals.OilTTextShow == "2"))
            {
                Globals.gaugename = "OilT";
                Globals.showP2 = "Y";
                if ((Globals.OilTShow == "2") && (Globals.OilTTextShow != "2")) { Globals.OilTTextShow = "N"; }
                if ((Globals.OilTShow != "2") && (Globals.OilTTextShow == "2")) { Globals.OilTShow = "N"; }
                Globals.OilTvalp2 = Globals.gaugename + "," + Globals.OilTShow + "," + Globals.OilTNeedleWidth + "," + Globals.OilTNeedleLength + "," + Globals.OilTNeedleX + "," + Globals.OilTNeedleY + "," + Globals.OilTOffset + "," + Globals.OilTEnd + "," + Globals.OilTTop + "," + Globals.OilTTextShow + "," + Globals.OilTTextX + "," + Globals.OilTTextY + "," + Globals.OilTFontSize + "," + Globals.OilTTextStyle + "," + Globals.OilTNeedleType + "," + Globals.OilTNeedle + "," + Globals.OilTGPIO;
            }
            if ((Globals.OilTShow == "3") || (Globals.OilTTextShow == "3"))
            {
                Globals.gaugename = "OilT";
                Globals.showP3 = "Y";
                if ((Globals.OilTShow == "3") && (Globals.OilTTextShow != "3")) { Globals.OilTTextShow = "N"; }
                if ((Globals.OilTShow != "3") && (Globals.OilTTextShow == "3")) { Globals.OilTShow = "N"; }
                Globals.OilTvalp3 = Globals.gaugename + "," + Globals.OilTShow + "," + Globals.OilTNeedleWidth + "," + Globals.OilTNeedleLength + "," + Globals.OilTNeedleX + "," + Globals.OilTNeedleY + "," + Globals.OilTOffset + "," + Globals.OilTEnd + "," + Globals.OilTTop + "," + Globals.OilTTextShow + "," + Globals.OilTTextX + "," + Globals.OilTTextY + "," + Globals.OilTFontSize + "," + Globals.OilTTextStyle + "," + Globals.OilTNeedleType + "," + Globals.OilTNeedle + "," + Globals.OilTGPIO;
            }

            //Fuel
            //            Globals.gaugename = ""; Globals.FuelShow = "N"; Globals.FuelTextShow = "N";  //reset to no values
            if (cmbShowFuel.Text == "N") { Globals.FuelShow = "N"; }
            if (cmbFuelTextShow.Text == "N") { Globals.FuelTextShow = "N"; }
            if (cmbShowFuel.Text == "Panel 1") { Globals.FuelShow = "1"; }
            if (cmbFuelTextShow.Text == "Panel 1") { Globals.FuelTextShow = "1"; }
            if (cmbShowFuel.Text == "Panel 2") { Globals.FuelShow = "2"; }
            if (cmbFuelTextShow.Text == "Panel 2") { Globals.FuelTextShow = "2"; }
            if (cmbShowFuel.Text == "Panel 3") { Globals.FuelShow = "3"; }
            if (cmbFuelTextShow.Text == "Panel 3") { Globals.FuelTextShow = "3"; }

            if ((Globals.FuelShow == "1") || (Globals.FuelTextShow == "1"))
            {
                Globals.gaugename = "Fuel";
                Globals.showP1 = "Y";
                if ((Globals.FuelShow == "1") && (Globals.FuelTextShow != "1")) { Globals.FuelTextShow = "N"; }
                if ((Globals.FuelShow != "1") && (Globals.FuelTextShow == "1")) { Globals.FuelShow = "N"; }
                Globals.Fuelvalp1 = Globals.gaugename + "," + Globals.FuelShow + "," + Globals.FuelNeedleWidth + "," + Globals.FuelNeedleLength + "," + Globals.FuelNeedleX + "," + Globals.FuelNeedleY + "," + Globals.FuelOffset + "," + Globals.FuelEnd + "," + Globals.FuelTop + "," + Globals.FuelTextShow + "," + Globals.FuelTextX + "," + Globals.FuelTextY + "," + Globals.FuelFontSize + "," + Globals.FuelTextStyle + "," + Globals.FuelNeedleType + "," + Globals.FuelNeedle + "," + Globals.FuelGPIO;
            }
            if ((Globals.FuelShow == "2") || (Globals.FuelTextShow == "2"))
            {
                Globals.gaugename = "Fuel";
                Globals.showP2 = "Y";
                if ((Globals.FuelShow == "2") && (Globals.FuelTextShow != "2")) { Globals.FuelTextShow = "N"; }
                if ((Globals.FuelShow != "2") && (Globals.FuelTextShow == "2")) { Globals.FuelShow = "N"; }
                Globals.Fuelvalp2 = Globals.gaugename + "," + Globals.FuelShow + "," + Globals.FuelNeedleWidth + "," + Globals.FuelNeedleLength + "," + Globals.FuelNeedleX + "," + Globals.FuelNeedleY + "," + Globals.FuelOffset + "," + Globals.FuelEnd + "," + Globals.FuelTop + "," + Globals.FuelTextShow + "," + Globals.FuelTextX + "," + Globals.FuelTextY + "," + Globals.FuelFontSize + "," + Globals.FuelTextStyle + "," + Globals.FuelNeedleType + "," + Globals.FuelNeedle + "," + Globals.FuelGPIO;
            }
            if ((Globals.FuelShow == "3") || (Globals.FuelTextShow == "3"))
            {
                Globals.gaugename = "Fuel";
                Globals.showP3 = "Y";
                if ((Globals.FuelShow == "3") && (Globals.FuelTextShow != "3")) { Globals.FuelTextShow = "N"; }
                if ((Globals.FuelShow != "3") && (Globals.FuelTextShow == "3")) { Globals.FuelShow = "N"; }
                Globals.Fuelvalp3 = Globals.gaugename + "," + Globals.FuelShow + "," + Globals.FuelNeedleWidth + "," + Globals.FuelNeedleLength + "," + Globals.FuelNeedleX + "," + Globals.FuelNeedleY + "," + Globals.FuelOffset + "," + Globals.FuelEnd + "," + Globals.FuelTop + "," + Globals.FuelTextShow + "," + Globals.FuelTextX + "," + Globals.FuelTextY + "," + Globals.FuelFontSize + "," + Globals.FuelTextStyle + "," + Globals.FuelNeedleType + "," + Globals.FuelNeedle + "," + Globals.FuelGPIO;
            }

            //FuelT
            //            Globals.gaugename = ""; Globals.FuelTShow = "N"; Globals.FuelTTextShow = "N";  //reset to no values
            if (cmbShowFuelT.Text == "N") { Globals.FuelTShow = "N"; }
            if (cmbFuelTTextShow.Text == "N") { Globals.FuelTTextShow = "N"; }
            if (cmbShowFuelT.Text == "Panel 1") { Globals.FuelTShow = "1"; }
            if (cmbFuelTTextShow.Text == "Panel 1") { Globals.FuelTTextShow = "1"; }
            if (cmbShowFuelT.Text == "Panel 2") { Globals.FuelTShow = "2"; }
            if (cmbFuelTTextShow.Text == "Panel 2") { Globals.FuelTTextShow = "2"; }
            if (cmbShowFuelT.Text == "Panel 3") { Globals.FuelTShow = "3"; }
            if (cmbFuelTTextShow.Text == "Panel 3") { Globals.FuelTTextShow = "3"; }

            if ((Globals.FuelTShow == "1") || (Globals.FuelTTextShow == "1"))
            {
                Globals.gaugename = "FuelT";
                Globals.showP1 = "Y";
                if ((Globals.FuelTShow == "1") && (Globals.FuelTTextShow != "1")) { Globals.FuelTTextShow = "N"; }
                if ((Globals.FuelTShow != "1") && (Globals.FuelTTextShow == "1")) { Globals.FuelTShow = "N"; }
                Globals.FuelTvalp1 = Globals.gaugename + "," + Globals.FuelTShow + "," + Globals.FuelTNeedleWidth + "," + Globals.FuelTNeedleLength + "," + Globals.FuelTNeedleX + "," + Globals.FuelTNeedleY + "," + Globals.FuelTOffset + "," + Globals.FuelTEnd + "," + Globals.FuelTTop + "," + Globals.FuelTTextShow + "," + Globals.FuelTTextX + "," + Globals.FuelTTextY + "," + Globals.FuelTFontSize + "," + Globals.FuelTTextStyle + "," + Globals.FuelTNeedleType + "," + Globals.FuelTNeedle + "," + Globals.FuelTGPIO;
            }
            if ((Globals.FuelTShow == "2") || (Globals.FuelTTextShow == "2"))
            {
                Globals.gaugename = "FuelT";
                Globals.showP2 = "Y";
                if ((Globals.FuelTShow == "2") && (Globals.FuelTTextShow != "2")) { Globals.FuelTTextShow = "N"; }
                if ((Globals.FuelTShow != "2") && (Globals.FuelTTextShow == "2")) { Globals.FuelTShow = "N"; }
                Globals.FuelTvalp2 = Globals.gaugename + "," + Globals.FuelTShow + "," + Globals.FuelTNeedleWidth + "," + Globals.FuelTNeedleLength + "," + Globals.FuelTNeedleX + "," + Globals.FuelTNeedleY + "," + Globals.FuelTOffset + "," + Globals.FuelTEnd + "," + Globals.FuelTTop + "," + Globals.FuelTTextShow + "," + Globals.FuelTTextX + "," + Globals.FuelTTextY + "," + Globals.FuelTFontSize + "," + Globals.FuelTTextStyle + "," + Globals.FuelTNeedleType + "," + Globals.FuelTNeedle + "," + Globals.FuelTGPIO;
            }
            if ((Globals.FuelTShow == "3") || (Globals.FuelTTextShow == "3"))
            {
                Globals.gaugename = "FuelT";
                Globals.showP3 = "Y";
                if ((Globals.FuelTShow == "3") && (Globals.FuelTTextShow != "3")) { Globals.FuelTTextShow = "N"; }
                if ((Globals.FuelTShow != "3") && (Globals.FuelTTextShow == "3")) { Globals.FuelTShow = "N"; }
                Globals.FuelTvalp3 = Globals.gaugename + "," + Globals.FuelTShow + "," + Globals.FuelTNeedleWidth + "," + Globals.FuelTNeedleLength + "," + Globals.FuelTNeedleX + "," + Globals.FuelTNeedleY + "," + Globals.FuelTOffset + "," + Globals.FuelTEnd + "," + Globals.FuelTTop + "," + Globals.FuelTTextShow + "," + Globals.FuelTTextX + "," + Globals.FuelTTextY + "," + Globals.FuelTFontSize + "," + Globals.FuelTTextStyle + "," + Globals.FuelTNeedleType + "," + Globals.FuelTNeedle + "," + Globals.FuelTGPIO;
            }

            //FuelP
            //            Globals.gaugename = ""; Globals.FuelPShow = "N"; Globals.FuelPTextShow = "N";  //reset to no values
            if (cmbShowFuelP.Text == "N") { Globals.FuelPShow = "N"; }
            if (cmbFuelPTextShow.Text == "N") { Globals.FuelPTextShow = "N"; }
            if (cmbShowFuelP.Text == "Panel 1") { Globals.FuelPShow = "1"; }
            if (cmbFuelPTextShow.Text == "Panel 1") { Globals.FuelPTextShow = "1"; }
            if (cmbShowFuelP.Text == "Panel 2") { Globals.FuelPShow = "2"; }
            if (cmbFuelPTextShow.Text == "Panel 2") { Globals.FuelPTextShow = "2"; }
            if (cmbShowFuelP.Text == "Panel 3") { Globals.FuelPShow = "3"; }
            if (cmbFuelPTextShow.Text == "Panel 3") { Globals.FuelPTextShow = "3"; }

            if ((Globals.FuelPShow == "1") || (Globals.FuelPTextShow == "1"))
            {
                Globals.gaugename = "FuelP";
                Globals.showP1 = "Y";
                if ((Globals.FuelPShow == "1") && (Globals.FuelPTextShow != "1")) { Globals.FuelPTextShow = "N"; }
                if ((Globals.FuelPShow != "1") && (Globals.FuelPTextShow == "1")) { Globals.FuelPShow = "N"; }
                Globals.FuelPvalp1 = Globals.gaugename + "," + Globals.FuelPShow + "," + Globals.FuelPNeedleWidth + "," + Globals.FuelPNeedleLength + "," + Globals.FuelPNeedleX + "," + Globals.FuelPNeedleY + "," + Globals.FuelPOffset + "," + Globals.FuelPEnd + "," + Globals.FuelPTop + "," + Globals.FuelPTextShow + "," + Globals.FuelPTextX + "," + Globals.FuelPTextY + "," + Globals.FuelPFontSize + "," + Globals.FuelPTextStyle + "," + Globals.FuelPNeedleType + "," + Globals.FuelPNeedle + "," + Globals.FuelPGPIO;
            }
            if ((Globals.FuelPShow == "2") || (Globals.FuelPTextShow == "2"))
            {
                Globals.gaugename = "FuelP";
                Globals.showP2 = "Y";
                if ((Globals.FuelPShow == "2") && (Globals.FuelPTextShow != "2")) { Globals.FuelPTextShow = "N"; }
                if ((Globals.FuelPShow != "2") && (Globals.FuelPTextShow == "2")) { Globals.FuelPShow = "N"; }
                Globals.FuelPvalp2 = Globals.gaugename + "," + Globals.FuelPShow + "," + Globals.FuelPNeedleWidth + "," + Globals.FuelPNeedleLength + "," + Globals.FuelPNeedleX + "," + Globals.FuelPNeedleY + "," + Globals.FuelPOffset + "," + Globals.FuelPEnd + "," + Globals.FuelPTop + "," + Globals.FuelPTextShow + "," + Globals.FuelPTextX + "," + Globals.FuelPTextY + "," + Globals.FuelPFontSize + "," + Globals.FuelPTextStyle + "," + Globals.FuelPNeedleType + "," + Globals.FuelPNeedle + "," + Globals.FuelPGPIO;
            }
            if ((Globals.FuelPShow == "3") || (Globals.FuelPTextShow == "3"))
            {
                Globals.gaugename = "FuelP";
                Globals.showP3 = "Y";
                if ((Globals.FuelPShow == "3") && (Globals.FuelPTextShow != "3")) { Globals.FuelPTextShow = "N"; }
                if ((Globals.FuelPShow != "3") && (Globals.FuelPTextShow == "3")) { Globals.FuelPShow = "N"; }
                Globals.FuelPvalp3 = Globals.gaugename + "," + Globals.FuelPShow + "," + Globals.FuelPNeedleWidth + "," + Globals.FuelPNeedleLength + "," + Globals.FuelPNeedleX + "," + Globals.FuelPNeedleY + "," + Globals.FuelPOffset + "," + Globals.FuelPEnd + "," + Globals.FuelPTop + "," + Globals.FuelPTextShow + "," + Globals.FuelPTextX + "," + Globals.FuelPTextY + "," + Globals.FuelPFontSize + "," + Globals.FuelPTextStyle + "," + Globals.FuelPNeedleType + "," + Globals.FuelPNeedle + "," + Globals.FuelPGPIO;
            }

            //Battery
            //            Globals.gaugename = ""; Globals.BatteryShow = "N"; Globals.BatteryTextShow = "N";  //reset to no values
            if (cmbShowBattery.Text == "N") { Globals.BatteryShow = "N"; }
            if (cmbBatteryTextShow.Text == "N") { Globals.BatteryTextShow = "N"; }
            if (cmbShowBattery.Text == "Panel 1") { Globals.BatteryShow = "1"; }
            if (cmbBatteryTextShow.Text == "Panel 1") { Globals.BatteryTextShow = "1"; }
            if (cmbShowBattery.Text == "Panel 2") { Globals.BatteryShow = "2"; }
            if (cmbBatteryTextShow.Text == "Panel 2") { Globals.BatteryTextShow = "2"; }
            if (cmbShowBattery.Text == "Panel 3") { Globals.BatteryShow = "3"; }
            if (cmbBatteryTextShow.Text == "Panel 3") { Globals.BatteryTextShow = "3"; }

            if ((Globals.BatteryShow == "1") || (Globals.BatteryTextShow == "1"))
            {
                Globals.gaugename = "Battery";
                Globals.showP1 = "Y";
                if ((Globals.BatteryShow == "1") && (Globals.BatteryTextShow != "1")) { Globals.BatteryTextShow = "N"; }
                if ((Globals.BatteryShow != "1") && (Globals.BatteryTextShow == "1")) { Globals.BatteryShow = "N"; }
                Globals.Batteryvalp1 = Globals.gaugename + "," + Globals.BatteryShow + "," + Globals.BatteryNeedleWidth + "," + Globals.BatteryNeedleLength + "," + Globals.BatteryNeedleX + "," + Globals.BatteryNeedleY + "," + Globals.BatteryOffset + "," + Globals.BatteryEnd + "," + Globals.BatteryTop + "," + Globals.BatteryTextShow + "," + Globals.BatteryTextX + "," + Globals.BatteryTextY + "," + Globals.BatteryFontSize + "," + Globals.BatteryTextStyle + "," + Globals.BatteryNeedleType + "," + Globals.BatteryNeedle + "," + Globals.BatteryGPIO;
            }
            if ((Globals.BatteryShow == "2") || (Globals.BatteryTextShow == "2"))
            {
                Globals.gaugename = "Battery";
                Globals.showP2 = "Y";
                if ((Globals.BatteryShow == "2") && (Globals.BatteryTextShow != "2")) { Globals.BatteryTextShow = "N"; }
                if ((Globals.BatteryShow != "2") && (Globals.BatteryTextShow == "2")) { Globals.BatteryShow = "N"; }
                Globals.Batteryvalp2 = Globals.gaugename + "," + Globals.BatteryShow + "," + Globals.BatteryNeedleWidth + "," + Globals.BatteryNeedleLength + "," + Globals.BatteryNeedleX + "," + Globals.BatteryNeedleY + "," + Globals.BatteryOffset + "," + Globals.BatteryEnd + "," + Globals.BatteryTop + "," + Globals.BatteryTextShow + "," + Globals.BatteryTextX + "," + Globals.BatteryTextY + "," + Globals.BatteryFontSize + "," + Globals.BatteryTextStyle + "," + Globals.BatteryNeedleType + "," + Globals.BatteryNeedle + "," + Globals.BatteryGPIO;
            }
            if ((Globals.BatteryShow == "3") || (Globals.BatteryTextShow == "3"))
            {
                Globals.gaugename = "Battery";
                Globals.showP3 = "Y";
                if ((Globals.BatteryShow == "3") && (Globals.BatteryTextShow != "3")) { Globals.BatteryTextShow = "N"; }
                if ((Globals.BatteryShow != "3") && (Globals.BatteryTextShow == "3")) { Globals.BatteryShow = "N"; }
                Globals.Batteryvalp3 = Globals.gaugename + "," + Globals.BatteryShow + "," + Globals.BatteryNeedleWidth + "," + Globals.BatteryNeedleLength + "," + Globals.BatteryNeedleX + "," + Globals.BatteryNeedleY + "," + Globals.BatteryOffset + "," + Globals.BatteryEnd + "," + Globals.BatteryTop + "," + Globals.BatteryTextShow + "," + Globals.BatteryTextX + "," + Globals.BatteryTextY + "," + Globals.BatteryFontSize + "," + Globals.BatteryTextStyle + "," + Globals.BatteryNeedleType + "," + Globals.BatteryNeedle + "," + Globals.BatteryGPIO;
            }

            //User1
            //            Globals.gaugename = ""; Globals.User1Show = "N"; Globals.User1TextShow = "N";  //reset to no values
            if (cmbShowUser1.Text == "N") { Globals.User1Show = "N"; }
            if (cmbUser1TextShow.Text == "N") { Globals.User1TextShow = "N"; }
            if (cmbShowUser1.Text == "Panel 1") { Globals.User1Show = "1"; }
            if (cmbUser1TextShow.Text == "Panel 1") { Globals.User1TextShow = "1"; }
            if (cmbShowUser1.Text == "Panel 2") { Globals.User1Show = "2"; }
            if (cmbUser1TextShow.Text == "Panel 2") { Globals.User1TextShow = "2"; }
            if (cmbShowUser1.Text == "Panel 3") { Globals.User1Show = "3"; }
            if (cmbUser1TextShow.Text == "Panel 3") { Globals.User1TextShow = "3"; }

            if ((Globals.User1Show == "1") || (Globals.User1TextShow == "1"))
            {
                Globals.gaugename = "User1";
                Globals.showP1 = "Y";
                if ((Globals.User1Show == "1") && (Globals.User1TextShow != "1")) { Globals.User1TextShow = "N"; }
                if ((Globals.User1Show != "1") && (Globals.User1TextShow == "1")) { Globals.User1Show = "N"; }
                Globals.User1valp1 = Globals.gaugename + "," + Globals.User1Show + "," + Globals.User1NeedleWidth + "," + Globals.User1NeedleLength + "," + Globals.User1NeedleX + "," + Globals.User1NeedleY + "," + Globals.User1Offset + "," + Globals.User1End + "," + Globals.User1Top + "," + Globals.User1TextShow + "," + Globals.User1TextX + "," + Globals.User1TextY + "," + Globals.User1FontSize + "," + Globals.User1TextStyle + "," + Globals.User1NeedleType + "," + Globals.User1Needle + "," + Globals.User1GPIO;
            }
            if ((Globals.User1Show == "2") || (Globals.User1TextShow == "2"))
            {
                Globals.gaugename = "User1";
                Globals.showP2 = "Y";
                if ((Globals.User1Show == "2") && (Globals.User1TextShow != "2")) { Globals.User1TextShow = "N"; }
                if ((Globals.User1Show != "2") && (Globals.User1TextShow == "2")) { Globals.User1Show = "N"; }
                Globals.User1valp2 = Globals.gaugename + "," + Globals.User1Show + "," + Globals.User1NeedleWidth + "," + Globals.User1NeedleLength + "," + Globals.User1NeedleX + "," + Globals.User1NeedleY + "," + Globals.User1Offset + "," + Globals.User1End + "," + Globals.User1Top + "," + Globals.User1TextShow + "," + Globals.User1TextX + "," + Globals.User1TextY + "," + Globals.User1FontSize + "," + Globals.User1TextStyle + "," + Globals.User1NeedleType + "," + Globals.User1Needle + "," + Globals.User1GPIO;
            }
            if ((Globals.User1Show == "3") || (Globals.User1TextShow == "3"))
            {
                Globals.gaugename = "User1";
                Globals.showP3 = "Y";
                if ((Globals.User1Show == "3") && (Globals.User1TextShow != "3")) { Globals.User1TextShow = "N"; }
                if ((Globals.User1Show != "3") && (Globals.User1TextShow == "3")) { Globals.User1Show = "N"; }
                Globals.User1valp3 = Globals.gaugename + "," + Globals.User1Show + "," + Globals.User1NeedleWidth + "," + Globals.User1NeedleLength + "," + Globals.User1NeedleX + "," + Globals.User1NeedleY + "," + Globals.User1Offset + "," + Globals.User1End + "," + Globals.User1Top + "," + Globals.User1TextShow + "," + Globals.User1TextX + "," + Globals.User1TextY + "," + Globals.User1FontSize + "," + Globals.User1TextStyle + "," + Globals.User1NeedleType + "," + Globals.User1Needle + "," + Globals.User1GPIO;
            }

            //User2
            //            Globals.gaugename = ""; Globals.User2Show = "N"; Globals.User2TextShow = "N";  //reset to no values
            if (cmbShowUser2.Text == "N") { Globals.User2Show = "N"; }
            if (cmbUser2TextShow.Text == "N") { Globals.User2TextShow = "N"; }
            if (cmbShowUser2.Text == "Panel 1") { Globals.User2Show = "1"; }
            if (cmbUser2TextShow.Text == "Panel 1") { Globals.User2TextShow = "1"; }
            if (cmbShowUser2.Text == "Panel 2") { Globals.User2Show = "2"; }
            if (cmbUser2TextShow.Text == "Panel 2") { Globals.User2TextShow = "2"; }
            if (cmbShowUser2.Text == "Panel 3") { Globals.User2Show = "3"; }
            if (cmbUser2TextShow.Text == "Panel 3") { Globals.User2TextShow = "3"; }

            if ((Globals.User2Show == "1") || (Globals.User2TextShow == "1"))
            {
                Globals.gaugename = "User2";
                Globals.showP1 = "Y";
                if ((Globals.User2Show == "1") && (Globals.User2TextShow != "1")) { Globals.User2TextShow = "N"; }
                if ((Globals.User2Show != "1") && (Globals.User2TextShow == "1")) { Globals.User2Show = "N"; }
                Globals.User2valp1 = Globals.gaugename + "," + Globals.User2Show + "," + Globals.User2NeedleWidth + "," + Globals.User2NeedleLength + "," + Globals.User2NeedleX + "," + Globals.User2NeedleY + "," + Globals.User2Offset + "," + Globals.User2End + "," + Globals.User2Top + "," + Globals.User2TextShow + "," + Globals.User2TextX + "," + Globals.User2TextY + "," + Globals.User2FontSize + "," + Globals.User2TextStyle + "," + Globals.User2NeedleType + "," + Globals.User2Needle + "," + Globals.User2GPIO;
            }
            if ((Globals.User2Show == "2") || (Globals.User2TextShow == "2"))
            {
                Globals.gaugename = "User2";
                Globals.showP2 = "Y";
                if ((Globals.User2Show == "2") && (Globals.User2TextShow != "2")) { Globals.User2TextShow = "N"; }
                if ((Globals.User2Show != "2") && (Globals.User2TextShow == "2")) { Globals.User2Show = "N"; }
                Globals.User2valp2 = Globals.gaugename + "," + Globals.User2Show + "," + Globals.User2NeedleWidth + "," + Globals.User2NeedleLength + "," + Globals.User2NeedleX + "," + Globals.User2NeedleY + "," + Globals.User2Offset + "," + Globals.User2End + "," + Globals.User2Top + "," + Globals.User2TextShow + "," + Globals.User2TextX + "," + Globals.User2TextY + "," + Globals.User2FontSize + "," + Globals.User2TextStyle + "," + Globals.User2NeedleType + "," + Globals.User2Needle + "," + Globals.User2GPIO;
            }
            if ((Globals.User2Show == "3") || (Globals.User2TextShow == "3"))
            {
                Globals.gaugename = "User2";
                Globals.showP3 = "Y";
                if ((Globals.User2Show == "3") && (Globals.User2TextShow != "3")) { Globals.User2TextShow = "N"; }
                if ((Globals.User2Show != "3") && (Globals.User2TextShow == "3")) { Globals.User2Show = "N"; }
                Globals.User2valp3 = Globals.gaugename + "," + Globals.User2Show + "," + Globals.User2NeedleWidth + "," + Globals.User2NeedleLength + "," + Globals.User2NeedleX + "," + Globals.User2NeedleY + "," + Globals.User2Offset + "," + Globals.User2End + "," + Globals.User2Top + "," + Globals.User2TextShow + "," + Globals.User2TextX + "," + Globals.User2TextY + "," + Globals.User2FontSize + "," + Globals.User2TextStyle + "," + Globals.User2NeedleType + "," + Globals.User2Needle + "," + Globals.User2GPIO;
            }

            //User3
            //            Globals.gaugename = ""; Globals.User3Show = "N"; Globals.User3TextShow = "N";  //reset to no values
            if (cmbShowUser3.Text == "N") { Globals.User3Show = "N"; }
            if (cmbUser3TextShow.Text == "N") { Globals.User3TextShow = "N"; }
            if (cmbShowUser3.Text == "Panel 1") { Globals.User3Show = "1"; }
            if (cmbUser3TextShow.Text == "Panel 1") { Globals.User3TextShow = "1"; }
            if (cmbShowUser3.Text == "Panel 2") { Globals.User3Show = "2"; }
            if (cmbUser3TextShow.Text == "Panel 2") { Globals.User3TextShow = "2"; }
            if (cmbShowUser3.Text == "Panel 3") { Globals.User3Show = "3"; }
            if (cmbUser3TextShow.Text == "Panel 3") { Globals.User3TextShow = "3"; }

            if ((Globals.User3Show == "1") || (Globals.User3TextShow == "1"))
            {
                Globals.gaugename = "User3";
                Globals.showP1 = "Y";
                if ((Globals.User3Show == "1") && (Globals.User3TextShow != "1")) { Globals.User3TextShow = "N"; }
                if ((Globals.User3Show != "1") && (Globals.User3TextShow == "1")) { Globals.User3Show = "N"; }
                Globals.User3valp1 = Globals.gaugename + "," + Globals.User3Show + "," + Globals.User3NeedleWidth + "," + Globals.User3NeedleLength + "," + Globals.User3NeedleX + "," + Globals.User3NeedleY + "," + Globals.User3Offset + "," + Globals.User3End + "," + Globals.User3Top + "," + Globals.User3TextShow + "," + Globals.User3TextX + "," + Globals.User3TextY + "," + Globals.User3FontSize + "," + Globals.User3TextStyle + "," + Globals.User3NeedleType + "," + Globals.User3Needle + "," + Globals.User3GPIO;
            }
            if ((Globals.User3Show == "2") || (Globals.User3TextShow == "2"))
            {
                Globals.gaugename = "User3";
                Globals.showP2 = "Y";
                if ((Globals.User3Show == "2") && (Globals.User3TextShow != "2")) { Globals.User3TextShow = "N"; }
                if ((Globals.User3Show != "2") && (Globals.User3TextShow == "2")) { Globals.User3Show = "N"; }
                Globals.User3valp2 = Globals.gaugename + "," + Globals.User3Show + "," + Globals.User3NeedleWidth + "," + Globals.User3NeedleLength + "," + Globals.User3NeedleX + "," + Globals.User3NeedleY + "," + Globals.User3Offset + "," + Globals.User3End + "," + Globals.User3Top + "," + Globals.User3TextShow + "," + Globals.User3TextX + "," + Globals.User3TextY + "," + Globals.User3FontSize + "," + Globals.User3TextStyle + "," + Globals.User3NeedleType + "," + Globals.User3Needle + "," + Globals.User3GPIO;
            }
            if ((Globals.User3Show == "3") || (Globals.User3TextShow == "3"))
            {
                Globals.gaugename = "User3";
                Globals.showP3 = "Y";
                if ((Globals.User3Show == "3") && (Globals.User3TextShow != "3")) { Globals.User3TextShow = "N"; }
                if ((Globals.User3Show != "3") && (Globals.User3TextShow == "3")) { Globals.User3Show = "N"; }
                Globals.User3valp3 = Globals.gaugename + "," + Globals.User3Show + "," + Globals.User3NeedleWidth + "," + Globals.User3NeedleLength + "," + Globals.User3NeedleX + "," + Globals.User3NeedleY + "," + Globals.User3Offset + "," + Globals.User3End + "," + Globals.User3Top + "," + Globals.User3TextShow + "," + Globals.User3TextX + "," + Globals.User3TextY + "," + Globals.User3FontSize + "," + Globals.User3TextStyle + "," + Globals.User3NeedleType + "," + Globals.User3Needle + "," + Globals.User3GPIO;
            }

            //User4
            //            Globals.gaugename = ""; Globals.User4Show = "N"; Globals.User4TextShow = "N";  //reset to no values
            if (cmbShowUser4.Text == "N") { Globals.User4Show = "N"; }
            if (cmbUser4TextShow.Text == "N") { Globals.User4TextShow = "N"; }
            if (cmbShowUser4.Text == "Panel 1") { Globals.User4Show = "1"; }
            if (cmbUser4TextShow.Text == "Panel 1") { Globals.User4TextShow = "1"; }
            if (cmbShowUser4.Text == "Panel 2") { Globals.User4Show = "2"; }
            if (cmbUser4TextShow.Text == "Panel 2") { Globals.User4TextShow = "2"; }
            if (cmbShowUser4.Text == "Panel 3") { Globals.User4Show = "3"; }
            if (cmbUser4TextShow.Text == "Panel 3") { Globals.User4TextShow = "3"; }

            if ((Globals.User4Show == "1") || (Globals.User4TextShow == "1"))
            {
                Globals.gaugename = "User4";
                Globals.showP1 = "Y";
                if ((Globals.User4Show == "1") && (Globals.User4TextShow != "1")) { Globals.User4TextShow = "N"; }
                if ((Globals.User4Show != "1") && (Globals.User4TextShow == "1")) { Globals.User4Show = "N"; }
                Globals.User4valp1 = Globals.gaugename + "," + Globals.User4Show + "," + Globals.User4NeedleWidth + "," + Globals.User4NeedleLength + "," + Globals.User4NeedleX + "," + Globals.User4NeedleY + "," + Globals.User4Offset + "," + Globals.User4End + "," + Globals.User4Top + "," + Globals.User4TextShow + "," + Globals.User4TextX + "," + Globals.User4TextY + "," + Globals.User4FontSize + "," + Globals.User4TextStyle + "," + Globals.User4NeedleType + "," + Globals.User4Needle + "," + Globals.User4GPIO;
            }
            if ((Globals.User4Show == "2") || (Globals.User4TextShow == "2"))
            {
                Globals.gaugename = "User4";
                Globals.showP2 = "Y";
                if ((Globals.User4Show == "2") && (Globals.User4TextShow != "2")) { Globals.User4TextShow = "N"; }
                if ((Globals.User4Show != "2") && (Globals.User4TextShow == "2")) { Globals.User4Show = "N"; }
                Globals.User4valp2 = Globals.gaugename + "," + Globals.User4Show + "," + Globals.User4NeedleWidth + "," + Globals.User4NeedleLength + "," + Globals.User4NeedleX + "," + Globals.User4NeedleY + "," + Globals.User4Offset + "," + Globals.User4End + "," + Globals.User4Top + "," + Globals.User4TextShow + "," + Globals.User4TextX + "," + Globals.User4TextY + "," + Globals.User4FontSize + "," + Globals.User4TextStyle + "," + Globals.User4NeedleType + "," + Globals.User4Needle + "," + Globals.User4GPIO;
            }
            if ((Globals.User4Show == "3") || (Globals.User4TextShow == "3"))
            {
                Globals.gaugename = "User4";
                Globals.showP3 = "Y";
                if ((Globals.User4Show == "3") && (Globals.User4TextShow != "3")) { Globals.User4TextShow = "N"; }
                if ((Globals.User4Show != "3") && (Globals.User4TextShow == "3")) { Globals.User4Show = "N"; }
                Globals.User4valp3 = Globals.gaugename + "," + Globals.User4Show + "," + Globals.User4NeedleWidth + "," + Globals.User4NeedleLength + "," + Globals.User4NeedleX + "," + Globals.User4NeedleY + "," + Globals.User4Offset + "," + Globals.User4End + "," + Globals.User4Top + "," + Globals.User4TextShow + "," + Globals.User4TextX + "," + Globals.User4TextY + "," + Globals.User4FontSize + "," + Globals.User4TextStyle + "," + Globals.User4NeedleType + "," + Globals.User4Needle + "," + Globals.User4GPIO;
            }

        }
        // --------------------------------------------------------------------------------populate screen from global variables----------------------------------------------------------
        private void resolveFromVars()
        {
            //======================================================================= get items held in the config==================================================================

            txtSpeedoCanOffset.Text = Globals.SpeedoCanOffset;
            txtTachoCanOffset.Text = Globals.TachoCanOffset;
            txtBoostCanOffset.Text = Globals.BoostCanOffset;
            txtTempCanOffset.Text = Globals.TempCanOffset;
            txtOilCanOffset.Text = Globals.OilCanOffset;
            txtOilTCanOffset.Text = Globals.OilTCanOffset;
            txtFuelCanOffset.Text = Globals.FuelCanOffset;
            txtFuelTCanOffset.Text = Globals.FuelTCanOffset;
            txtFuelPCanOffset.Text = Globals.FuelPCanOffset;
            txtBatteryCanOffset.Text = Globals.BatteryCanOffset;
            txtUser1CanOffset.Text = Globals.User1CanOffset;
            txtUser2CanOffset.Text = Globals.User2CanOffset;
            txtUser3CanOffset.Text = Globals.User3CanOffset;
            txtUser4CanOffset.Text = Globals.User4CanOffset;

            cmbGPIOSpeedo.Text = Globals.SpeedoGPIO;
            cmbGPIOTacho.Text = Globals.TachoGPIO;
            cmbGPIOBoost.Text = Globals.BoostGPIO;
            cmbGPIOTemp.Text = Globals.TempGPIO;
            cmbGPIOOil.Text = Globals.OilGPIO;
            cmbGPIOOilT.Text = Globals.OilTGPIO;
            cmbGPIOFuel.Text = Globals.FuelGPIO;
            cmbGPIOFuelT.Text = Globals.FuelTGPIO;
            cmbGPIOFuelP.Text = Globals.FuelPGPIO;
            cmbGPIOBattery.Text = Globals.BatteryGPIO;
            cmbGPIOUser1.Text = Globals.User1GPIO;
            cmbGPIOUser2.Text = Globals.User2GPIO;
            cmbGPIOUser3.Text = Globals.User3GPIO;
            cmbGPIOUser4.Text = Globals.User4GPIO;

            lblP1Path.Text = Globals.P1BG;
            lblP2Path.Text = Globals.P2BG;
            lblP3Path.Text = Globals.P3BG;

            //Connectivity
            txtPanel1IP.Text = Globals.PanelIP1;
            txtPaneI2IP.Text  = Globals.PanelIP2;
            txtPanel3IP.Text = Globals.PanelIP3;

            cmbSerCanP1ECU.Text = Globals.SerCanP1Ecu;
            if (cmbSerCanP1ECU.Text == "Serial3")
            {
                cmbSerCanP1ECUSerInter.Visible = true;
                cmbSerCanP1ECUSerSpeed.Visible = true;
                cmbSerCanP1ECUCanInter.Visible = false;
                cmbSerCanP1ECUCanSpeed.Visible = false;
                cmbSerCanP1ECUSerInter.Text = Globals.SerCanPortP1Ecu;
                cmbSerCanP1ECUSerSpeed.Text = Globals.SerCanSpeedP1Ecu;
                cmbCanAddressEcu.Text = Globals.SerCanAddressP1Ecu;
                cmbCanAddressP1.Text = Globals.SerCanAddressP1;
            }
            else
            {
                cmbSerCanP1ECUSerInter.Visible = false;
                cmbSerCanP1ECUSerSpeed.Visible = false;
                cmbSerCanP1ECUCanInter.Visible = true;
                cmbSerCanP1ECUCanSpeed.Visible = true;
                cmbSerCanP1ECUCanInter.Text = Globals.SerCanPortP1Ecu;
                cmbSerCanP1ECUCanSpeed.Text = Globals.SerCanSpeedP1Ecu;
                cmbCanAddressEcu.Text = Globals.SerCanAddressP1Ecu;
                cmbCanAddressP1.Text = Globals.SerCanAddressP1;
            }

            cmbSerCanP1P2.Text = Globals.SerCanP1P2;
            if (cmbSerCanP1P2.Text == "Serial3")
            {
                cmbSerCanP1P2SerInter.Visible = true;
                cmbSerCanP1P2SerSpeed.Visible = true;
                cmbSerCanP1P2CanInter.Visible = false;
                cmbSerCanP1P2CanSpeed.Visible = false;
                cmbSerCanP1P2SerInter.Text = Globals.SerCanPortP1P2;
                cmbSerCanP1P2SerSpeed.Text = Globals.SerCanSpeedP1P2;
                cmbSerCanP2Address.Text = Globals.SerCanAddressP1P2;
            }
            else
            {
                cmbSerCanP1P2SerInter.Visible = false;
                cmbSerCanP1P2SerSpeed.Visible = false;
                cmbSerCanP1P2CanInter.Visible = true;
                cmbSerCanP1P2CanSpeed.Visible = true;
                cmbSerCanP1P2CanInter.Text = Globals.SerCanPortP1P2;
                cmbSerCanP1P2CanSpeed.Text = Globals.SerCanSpeedP1P2;
                cmbSerCanP2Address.Text  = Globals.SerCanAddressP1P2;
            }


            cmbSerCanP1P3.Text = Globals.SerCanP1P3;
            cmbSerCanP1P3CanInter.Text = Globals.SerCanPortP1P3;
            cmbSerCanP1P3CanSpeed.Text = Globals.SerCanSpeedP1P3;
            cmbSerCanP3Address.Text = Globals.SerCanAddressP1P3;


            txtP1Width.Text = Globals.p1DispWidth;
            txtP2Width.Text = Globals.p2DispWidth;
            txtP3Width.Text = Globals.p3DispWidth;
            txtP1Height.Text = Globals.p1DispHeight;
            txtP2Height.Text = Globals.p2DispHeight;
            txtP3Height.Text = Globals.p3DispHeight;

            lblUser1.Text = Globals.User1name;
            lblUser2.Text = Globals.User2name;
            lblUser3.Text = Globals.User3name;
            lblUser4.Text = Globals.User4name;

            txtSpeedoNeedleWidth.Text = Globals.SpeedoNeedleWidth;
            txtSpeedoNeedleLength.Text = Globals.SpeedoNeedleLength;
            txtSpeedoNeedleX.Text = Globals.SpeedoNeedleX;
            txtSpeedoNeedleY.Text = Globals.SpeedoNeedleY;
            txtSpeedoEnd.Text = Globals.SpeedoEnd;
            txtSpeedoTop.Text = Globals.SpeedoTop;
            txtSpeedoTextX.Text = Globals.SpeedoTextX;
            txtSpeedoTextY.Text = Globals.SpeedoTextY;
            txtSpeedoFontSize.Text = Globals.SpeedoFontSize;
            cmbSpeedoTextStyle.Text = Globals.SpeedoTextStyle;
            txtSpeedoNeedle.Text = Globals.SpeedoNeedle;
            cmbSpeedo.Text = Globals.SpeedoNeedleType; 
        
            if (Globals.SpeedoShow == "1") { cmbShowSpeedo.Text = "Panel 1"; }
            if (Globals.SpeedoShow == "2") { cmbShowSpeedo.Text = "Panel 2"; }
            if (Globals.SpeedoShow == "3") { cmbShowSpeedo.Text = "Panel 3"; }

            if (Globals.SpeedoTextShow == "1") { cmbSpeedoTextShow.Text = "Panel 1"; }
            if (Globals.SpeedoTextShow == "2") { cmbSpeedoTextShow.Text = "Panel 2"; }
            if (Globals.SpeedoTextShow == "3") { cmbSpeedoTextShow.Text = "Panel 3"; }

            switch (Globals.SpeedoNeedleType)
            {
                case "barV":
                    if (Globals.SpeedoOffset == "1")
                    {
                       
                        cmbSpeedoAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbSpeedoAboveBelow.Text = "â";
                    }                    
                    break;

                case "barH":
                    if (Globals.SpeedoOffset == "1")
                    {
                        cmbSpeedoAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbSpeedoAboveBelow.Text = "â";
                    }
                    break;
            }

            txtTachoNeedleWidth.Text = Globals.TachoNeedleWidth;
            txtTachoNeedleLength.Text = Globals.TachoNeedleLength;
            txtTachoNeedleX.Text = Globals.TachoNeedleX;
            txtTachoNeedleY.Text = Globals.TachoNeedleY;
            txtTachoEnd.Text = Globals.TachoEnd;
            txtTachoTop.Text = Globals.TachoTop;
            txtTachoTextX.Text = Globals.TachoTextX;
            txtTachoTextY.Text = Globals.TachoTextY;
            txtTachoFontSize.Text = Globals.TachoFontSize;
            cmbTachoTextStyle.Text = Globals.TachoTextStyle;
            txtTachoNeedle.Text = Globals.TachoNeedle;
            cmbTacho.Text = Globals.TachoNeedleType;

            if (Globals.TachoShow == "1") { cmbShowTacho.Text = "Panel 1"; }
            if (Globals.TachoShow == "2") { cmbShowTacho.Text = "Panel 2"; }
            if (Globals.TachoShow == "3") { cmbShowTacho.Text = "Panel 3"; }

            if (Globals.TachoTextShow == "1") { cmbTachoTextShow.Text = "Panel 1"; }
            if (Globals.TachoTextShow == "2") { cmbTachoTextShow.Text = "Panel 2"; }
            if (Globals.TachoTextShow == "3") { cmbTachoTextShow.Text = "Panel 3"; }

            switch (Globals.TachoNeedleType)
            {
                case "barV":
                    if (Globals.TachoOffset == "1")
                    {
                        cmbTachoAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbTachoAboveBelow.Text = "â";
                    }
                    break;

                case "barH":
                    if (Globals.TachoOffset == "1")
                    {
                        cmbTachoAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbTachoAboveBelow.Text = "â";
                    }
                    break;
            }

            txtBoostNeedleWidth.Text = Globals.BoostNeedleWidth;
            txtBoostNeedleLength.Text = Globals.BoostNeedleLength;
            txtBoostNeedleX.Text = Globals.BoostNeedleX;
            txtBoostNeedleY.Text = Globals.BoostNeedleY;
            txtBoostEnd.Text = Globals.BoostEnd;
            txtBoostTop.Text = Globals.BoostTop;
            txtBoostTextX.Text = Globals.BoostTextX;
            txtBoostTextY.Text = Globals.BoostTextY;
            txtBoostFontSize.Text = Globals.BoostFontSize;
            cmbBoostTextStyle.Text = Globals.BoostTextStyle;
            txtBoostNeedle.Text = Globals.BoostNeedle;
            cmbBoost.Text = Globals.BoostNeedleType;

            if (Globals.BoostShow == "1") { cmbShowBoost.Text = "Panel 1"; }
            if (Globals.BoostShow == "2") { cmbShowBoost.Text = "Panel 2"; }
            if (Globals.BoostShow == "3") { cmbShowBoost.Text = "Panel 3"; }

            if (Globals.BoostTextShow == "1") { cmbBoostTextShow.Text = "Panel 1"; }
            if (Globals.BoostTextShow == "2") { cmbBoostTextShow.Text = "Panel 2"; }
            if (Globals.BoostTextShow == "3") { cmbBoostTextShow.Text = "Panel 3"; }

            switch (Globals.BoostNeedleType)
            {
                case "barV":
                    if (Globals.BoostOffset == "1")
                    {
                        cmbBoostAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbBoostAboveBelow.Text = "â";
                    }
                    break;

                case "barH":
                    if (Globals.BoostOffset == "1")
                    {
                        cmbBoostAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbBoostAboveBelow.Text = "â";
                    }
                    break;
            }

            txtTempNeedleWidth.Text = Globals.TempNeedleWidth;
            txtTempNeedleLength.Text = Globals.TempNeedleLength;
            txtTempNeedleX.Text = Globals.TempNeedleX;
            txtTempNeedleY.Text = Globals.TempNeedleY;
            txtTempEnd.Text = Globals.TempEnd;
            txtTempTop.Text = Globals.TempTop;
            txtTempTextX.Text = Globals.TempTextX;
            txtTempTextY.Text = Globals.TempTextY;
            txtTempFontSize.Text = Globals.TempFontSize;
            cmbTempTextStyle.Text = Globals.TempTextStyle;
            txtTempNeedle.Text = Globals.TempNeedle;
            cmbTemp.Text = Globals.TempNeedleType;

            if (Globals.TempShow == "1") { cmbShowTemp.Text = "Panel 1"; }
            if (Globals.TempShow == "2") { cmbShowTemp.Text = "Panel 2"; }
            if (Globals.TempShow == "3") { cmbShowTemp.Text = "Panel 3"; }

            if (Globals.TempTextShow == "1") { cmbTempTextShow.Text = "Panel 1"; }
            if (Globals.TempTextShow == "2") { cmbTempTextShow.Text = "Panel 2"; }
            if (Globals.TempTextShow == "3") { cmbTempTextShow.Text = "Panel 3"; }

            switch (Globals.TempNeedleType)
            {
                case "barV":
                    if (Globals.TempOffset == "1")
                    {
                        cmbTempAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbTempAboveBelow.Text = "â";
                    }
                    break;

                case "barH":
                    if (Globals.TempOffset == "1")
                    {
                        cmbTempAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbTempAboveBelow.Text = "â";
                    }
                    break;
            }

            txtOilNeedleWidth.Text = Globals.OilNeedleWidth;
            txtOilNeedleLength.Text = Globals.OilNeedleLength;
            txtOilNeedleX.Text = Globals.OilNeedleX;
            txtOilNeedleY.Text = Globals.OilNeedleY;
            txtOilEnd.Text = Globals.OilEnd;
            txtOilTop.Text = Globals.OilTop;
            txtOilTextX.Text = Globals.OilTextX;
            txtOilTextY.Text = Globals.OilTextY;
            txtOilFontSize.Text = Globals.OilFontSize;
            cmbOilTextStyle.Text = Globals.OilTextStyle;
            txtOilNeedle.Text = Globals.OilNeedle;
            cmbOil.Text = Globals.OilNeedleType;

            if (Globals.OilShow == "1") { cmbShowOil.Text = "Panel 1"; }
            if (Globals.OilShow == "2") { cmbShowOil.Text = "Panel 2"; }
            if (Globals.OilShow == "3") { cmbShowOil.Text = "Panel 3"; }

            if (Globals.OilTextShow == "1") { cmbOilTextShow.Text = "Panel 1"; }
            if (Globals.OilTextShow == "2") { cmbOilTextShow.Text = "Panel 2"; }
            if (Globals.OilTextShow == "3") { cmbOilTextShow.Text = "Panel 3"; }

            switch (Globals.OilNeedleType)
            {
                case "barV":
                    if (Globals.OilOffset == "1")
                    {
                        cmbOilAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbOilAboveBelow.Text = "â";
                    }
                    break;

                case "barH":
                    if (Globals.OilOffset == "1")
                    {
                        cmbOilAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbOilAboveBelow.Text = "â";
                    }
                    break;
            }

            txtOilTNeedleWidth.Text = Globals.OilTNeedleWidth;
            txtOilTNeedleLength.Text = Globals.OilTNeedleLength;
            txtOilTNeedleX.Text = Globals.OilTNeedleX;
            txtOilTNeedleY.Text = Globals.OilTNeedleY;
            txtOilTEnd.Text = Globals.OilTEnd;
            txtOilTTop.Text = Globals.OilTTop;
            txtOilTTextX.Text = Globals.OilTTextX;
            txtOilTTextY.Text = Globals.OilTTextY;
            txtOilTFontSize.Text = Globals.OilTFontSize;
            cmbOilTTextStyle.Text = Globals.OilTTextStyle;
            txtOilTNeedle.Text = Globals.OilTNeedle;
            cmbOilT.Text = Globals.OilTNeedleType;

            if (Globals.OilTShow == "1") { cmbShowOilT.Text = "Panel 1"; }
            if (Globals.OilTShow == "2") { cmbShowOilT.Text = "Panel 2"; }
            if (Globals.OilTShow == "3") { cmbShowOilT.Text = "Panel 3"; }

            if (Globals.OilTTextShow == "1") { cmbOilTTextShow.Text = "Panel 1"; }
            if (Globals.OilTTextShow == "2") { cmbOilTTextShow.Text = "Panel 2"; }
            if (Globals.OilTTextShow == "3") { cmbOilTTextShow.Text = "Panel 3"; }

            switch (Globals.OilTNeedleType)
            {
                case "barV":
                    if (Globals.OilTOffset == "1")
                    {
                        cmbOilTAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbOilTAboveBelow.Text = "â";
                    }
                    break;

                case "barH":
                    if (Globals.OilTOffset == "1")
                    {
                        cmbOilTAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbOilTAboveBelow.Text = "â";
                    }
                    break;
            }

            txtFuelNeedleWidth.Text = Globals.FuelNeedleWidth;
            txtFuelNeedleLength.Text = Globals.FuelNeedleLength;
            txtFuelNeedleX.Text = Globals.FuelNeedleX;
            txtFuelNeedleY.Text = Globals.FuelNeedleY;
            txtFuelEnd.Text = Globals.FuelEnd;
            txtFuelTop.Text = Globals.FuelTop;
            txtFuelTextX.Text = Globals.FuelTextX;
            txtFuelTextY.Text = Globals.FuelTextY;
            txtFuelFontSize.Text = Globals.FuelFontSize;
            cmbFuelTextStyle.Text = Globals.FuelTextStyle;
            txtFuelNeedle.Text = Globals.FuelNeedle;
            cmbFuel.Text = Globals.FuelNeedleType;

            if (Globals.FuelShow == "1") { cmbShowFuel.Text = "Panel 1"; }
            if (Globals.FuelShow == "2") { cmbShowFuel.Text = "Panel 2"; }
            if (Globals.FuelShow == "3") { cmbShowFuel.Text = "Panel 3"; }

            if (Globals.FuelTextShow == "1") { cmbFuelTextShow.Text = "Panel 1"; }
            if (Globals.FuelTextShow == "2") { cmbFuelTextShow.Text = "Panel 2"; }
            if (Globals.FuelTextShow == "3") { cmbFuelTextShow.Text = "Panel 3"; }

            switch (Globals.FuelNeedleType)
            {
                case "barV":
                    if (Globals.FuelOffset == "1")
                    {
                        cmbFuelAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbFuelAboveBelow.Text = "â";
                    }
                    break;

                case "barH":
                    if (Globals.FuelOffset == "1")
                    {
                        cmbFuelAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbFuelAboveBelow.Text = "â";
                    }
                    break;
            }

            txtFuelTNeedleWidth.Text = Globals.FuelTNeedleWidth;
            txtFuelTNeedleLength.Text = Globals.FuelTNeedleLength;
            txtFuelTNeedleX.Text = Globals.FuelTNeedleX;
            txtFuelTNeedleY.Text = Globals.FuelTNeedleY;
            txtFuelTEnd.Text = Globals.FuelTEnd;
            txtFuelTTop.Text = Globals.FuelTTop;
            txtFuelTTextX.Text = Globals.FuelTTextX;
            txtFuelTTextY.Text = Globals.FuelTTextY;
            txtFuelTFontSize.Text = Globals.FuelTFontSize;
            cmbFuelTTextStyle.Text = Globals.FuelTTextStyle;
            txtFuelTNeedle.Text = Globals.FuelTNeedle;
            cmbFuelT.Text = Globals.FuelTNeedleType;

            if (Globals.FuelTShow == "1") { cmbShowFuelT.Text = "Panel 1"; }
            if (Globals.FuelTShow == "2") { cmbShowFuelT.Text = "Panel 2"; }
            if (Globals.FuelTShow == "3") { cmbShowFuelT.Text = "Panel 3"; }

            if (Globals.FuelTTextShow == "1") { cmbFuelTTextShow.Text = "Panel 1"; }
            if (Globals.FuelTTextShow == "2") { cmbFuelTTextShow.Text = "Panel 2"; }
            if (Globals.FuelTTextShow == "3") { cmbFuelTTextShow.Text = "Panel 3"; }

            switch (Globals.FuelTNeedleType)
            {
                case "barV":
                    if (Globals.FuelTOffset == "1")
                    {
                        cmbFuelTAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbFuelTAboveBelow.Text = "â";
                    }
                    break;

                case "barH":
                    if (Globals.FuelTOffset == "1")
                    {
                        cmbFuelTAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbFuelTAboveBelow.Text = "â";
                    }
                    break;
            }

            txtFuelPNeedleWidth.Text = Globals.FuelPNeedleWidth;
            txtFuelPNeedleLength.Text = Globals.FuelPNeedleLength;
            txtFuelPNeedleX.Text = Globals.FuelPNeedleX;
            txtFuelPNeedleY.Text = Globals.FuelPNeedleY;
            txtFuelPEnd.Text = Globals.FuelPEnd;
            txtFuelPTop.Text = Globals.FuelPTop;
            txtFuelPTextX.Text = Globals.FuelPTextX;
            txtFuelPTextY.Text = Globals.FuelPTextY;
            txtFuelPFontSize.Text = Globals.FuelPFontSize;
            cmbFuelPTextStyle.Text = Globals.FuelPTextStyle;
            txtFuelPNeedle.Text = Globals.FuelPNeedle;
            cmbFuelP.Text = Globals.FuelPNeedleType;

            if (Globals.FuelPShow == "1") { cmbShowFuelP.Text = "Panel 1"; }
            if (Globals.FuelPShow == "2") { cmbShowFuelP.Text = "Panel 2"; }
            if (Globals.FuelPShow == "3") { cmbShowFuelP.Text = "Panel 3"; }

            if (Globals.FuelPTextShow == "1") { cmbFuelPTextShow.Text = "Panel 1"; }
            if (Globals.FuelPTextShow == "2") { cmbFuelPTextShow.Text = "Panel 2"; }
            if (Globals.FuelPTextShow == "3") { cmbFuelPTextShow.Text = "Panel 3"; }

            switch (Globals.FuelPNeedleType)
            {
                case "barV":
                    if (Globals.FuelPOffset == "1")
                    {
                        cmbFuelPAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbFuelPAboveBelow.Text = "â";
                    }
                    break;

                case "barH":
                    if (Globals.FuelPOffset == "1")
                    {
                        cmbFuelPAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbFuelPAboveBelow.Text = "â";
                    }
                    break;
            }

            txtBatteryNeedleWidth.Text = Globals.BatteryNeedleWidth;
            txtBatteryNeedleLength.Text = Globals.BatteryNeedleLength;
            txtBatteryNeedleX.Text = Globals.BatteryNeedleX;
            txtBatteryNeedleY.Text = Globals.BatteryNeedleY;
            txtBatteryEnd.Text = Globals.BatteryEnd;
            txtBatteryTop.Text = Globals.BatteryTop;
            txtBatteryTextX.Text = Globals.BatteryTextX;
            txtBatteryTextY.Text = Globals.BatteryTextY;
            txtBatteryFontSize.Text = Globals.BatteryFontSize;
            cmbBatteryTextStyle.Text = Globals.BatteryTextStyle;
            txtBatteryNeedle.Text = Globals.BatteryNeedle;
            cmbBattery.Text = Globals.BatteryNeedleType;

            if (Globals.BatteryShow == "1") { cmbShowBattery.Text = "Panel 1"; }
            if (Globals.BatteryShow == "2") { cmbShowBattery.Text = "Panel 2"; }
            if (Globals.BatteryShow == "3") { cmbShowBattery.Text = "Panel 3"; }

            if (Globals.BatteryTextShow == "1") { cmbBatteryTextShow.Text = "Panel 1"; }
            if (Globals.BatteryTextShow == "2") { cmbBatteryTextShow.Text = "Panel 2"; }
            if (Globals.BatteryTextShow == "3") { cmbBatteryTextShow.Text = "Panel 3"; }

            switch (Globals.BatteryNeedleType)
            {
                case "barV":
                    if (Globals.BatteryOffset == "1")
                    {
                        cmbBatteryAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbBatteryAboveBelow.Text = "â";
                    }
                    break;

                case "barH":
                    if (Globals.BatteryOffset == "1")
                    {
                        cmbBatteryAboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbBatteryAboveBelow.Text = "â";
                    }
                    break;
            }

            txtUser1NeedleWidth.Text = Globals.User1NeedleWidth;
            txtUser1NeedleLength.Text = Globals.User1NeedleLength;
            txtUser1NeedleX.Text = Globals.User1NeedleX;
            txtUser1NeedleY.Text = Globals.User1NeedleY;
            txtUser1End.Text = Globals.User1End;
            txtUser1Top.Text = Globals.User1Top;
            txtUser1TextX.Text = Globals.User1TextX;
            txtUser1TextY.Text = Globals.User1TextY;
            txtUser1FontSize.Text = Globals.User1FontSize;
            cmbUser1TextStyle.Text = Globals.User1TextStyle;
            txtUser1Needle.Text = Globals.User1Needle;
            cmbUser1.Text = Globals.User1NeedleType;

            if (Globals.User1Show == "1") { cmbShowUser1.Text = "Panel 1"; }
            if (Globals.User1Show == "2") { cmbShowUser1.Text = "Panel 2"; }
            if (Globals.User1Show == "3") { cmbShowUser1.Text = "Panel 3"; }

            if (Globals.User1TextShow == "1") { cmbUser1TextShow.Text = "Panel 1"; }
            if (Globals.User1TextShow == "2") { cmbUser1TextShow.Text = "Panel 2"; }
            if (Globals.User1TextShow == "3") { cmbUser1TextShow.Text = "Panel 3"; }

            switch (Globals.User1NeedleType)
            {
                case "barV":
                    if (Globals.User1Offset == "1")
                    {
                        cmbUser1AboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbUser1AboveBelow.Text = "â";
                    }
                    break;

                case "barH":
                    if (Globals.User1Offset == "1")
                    {
                        cmbUser1AboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbUser1AboveBelow.Text = "â";
                    }
                    break;
            }

            txtUser2NeedleWidth.Text = Globals.User2NeedleWidth;
            txtUser2NeedleLength.Text = Globals.User2NeedleLength;
            txtUser2NeedleX.Text = Globals.User2NeedleX;
            txtUser2NeedleY.Text = Globals.User2NeedleY;
            txtUser2End.Text = Globals.User2End;
            txtUser2Top.Text = Globals.User2Top;
            txtUser2TextX.Text = Globals.User2TextX;
            txtUser2TextY.Text = Globals.User2TextY;
            txtUser2FontSize.Text = Globals.User2FontSize;
            cmbUser2TextStyle.Text = Globals.User2TextStyle;
            txtUser2Needle.Text = Globals.User2Needle;
            cmbUser2.Text = Globals.User2NeedleType;

            if (Globals.User2Show == "1") { cmbShowUser2.Text = "Panel 1"; }
            if (Globals.User2Show == "2") { cmbShowUser2.Text = "Panel 2"; }
            if (Globals.User2Show == "3") { cmbShowUser2.Text = "Panel 3"; }

            if (Globals.User2TextShow == "1") { cmbUser2TextShow.Text = "Panel 1"; }
            if (Globals.User2TextShow == "2") { cmbUser2TextShow.Text = "Panel 2"; }
            if (Globals.User2TextShow == "3") { cmbUser2TextShow.Text = "Panel 3"; }

            switch (Globals.User2NeedleType)
            {
                case "barV":
                    if (Globals.User2Offset == "1")
                    {
                        cmbUser2AboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbUser2AboveBelow.Text = "â";
                    }
                    break;

                case "barH":
                    if (Globals.User2Offset == "1")
                    {
                        cmbUser2AboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbUser2AboveBelow.Text = "â";
                    }
                    break;
            }

            txtUser3NeedleWidth.Text = Globals.User3NeedleWidth;
            txtUser3NeedleLength.Text = Globals.User3NeedleLength;
            txtUser3NeedleX.Text = Globals.User3NeedleX;
            txtUser3NeedleY.Text = Globals.User3NeedleY;
            txtUser3End.Text = Globals.User3End;
            txtUser3Top.Text = Globals.User3Top;
            txtUser3TextX.Text = Globals.User3TextX;
            txtUser3TextY.Text = Globals.User3TextY;
            txtUser3FontSize.Text = Globals.User3FontSize;
            cmbUser3TextStyle.Text = Globals.User3TextStyle;
            txtUser3Needle.Text = Globals.User3Needle;
            cmbUser3.Text = Globals.User3NeedleType;

            if (Globals.User3Show == "1") { cmbShowUser3.Text = "Panel 1"; }
            if (Globals.User3Show == "2") { cmbShowUser3.Text = "Panel 2"; }
            if (Globals.User3Show == "3") { cmbShowUser3.Text = "Panel 3"; }

            if (Globals.User3TextShow == "1") { cmbUser3TextShow.Text = "Panel 1"; }
            if (Globals.User3TextShow == "2") { cmbUser3TextShow.Text = "Panel 2"; }
            if (Globals.User3TextShow == "3") { cmbUser3TextShow.Text = "Panel 3"; }

            switch (Globals.User3NeedleType)
            {
                case "barV":
                    if (Globals.User3Offset == "1")
                    {
                        cmbUser3AboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbUser3AboveBelow.Text = "â";
                    }
                    break;

                case "barH":
                    if (Globals.User3Offset == "1")
                    {
                        cmbUser3AboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbUser3AboveBelow.Text = "â";
                    }
                    break;
            }

            txtUser4NeedleWidth.Text = Globals.User4NeedleWidth;
            txtUser4NeedleLength.Text = Globals.User4NeedleLength;
            txtUser4NeedleX.Text = Globals.User4NeedleX;
            txtUser4NeedleY.Text = Globals.User4NeedleY;
            txtUser4End.Text = Globals.User4End;
            txtUser4Top.Text = Globals.User4Top;
            txtUser4TextX.Text = Globals.User4TextX;
            txtUser4TextY.Text = Globals.User4TextY;
            txtUser4FontSize.Text = Globals.User4FontSize;
            cmbUser4TextStyle.Text = Globals.User4TextStyle;
            txtUser4Needle.Text = Globals.User4Needle;
            cmbUser4.Text = Globals.User4NeedleType;

            if (Globals.User4Show == "1") { cmbShowUser4.Text = "Panel 1"; }
            if (Globals.User4Show == "2") { cmbShowUser4.Text = "Panel 2"; }
            if (Globals.User4Show == "3") { cmbShowUser4.Text = "Panel 3"; }

            if (Globals.User4TextShow == "1") { cmbUser4TextShow.Text = "Panel 1"; }
            if (Globals.User4TextShow == "2") { cmbUser4TextShow.Text = "Panel 2"; }
            if (Globals.User4TextShow == "3") { cmbUser4TextShow.Text = "Panel 3"; }

            switch (Globals.User4NeedleType)
            {
                case "barV":
                    if (Globals.User4Offset == "1")
                    {
                        cmbUser4AboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbUser4AboveBelow.Text = "â";
                    }
                    break;

                case "barH":
                    if (Globals.User4Offset == "1")
                    {
                        cmbUser4AboveBelow.Text = "á";
                    }
                    else
                    {
                        cmbUser4AboveBelow.Text = "â";
                    }
                    break;
            }
        }

        //------------------------------------------------------------------------------- poplulate variable from textboxes ----------------------------------------------------------------------------------
        private void resolveToVars()
        {
            //Connectivity (This is only instigated from Panel 1)
            Globals.PanelIP1 = txtPanel1IP.Text;
            Globals.PanelIP2 = txtPaneI2IP.Text;
            Globals.PanelIP3 = txtPanel3IP.Text;
            Globals.p1DispWidth = txtP1Width.Text;
            Globals.p1DispHeight = txtP1Height.Text;
            Globals.p2DispWidth = txtP2Width.Text;
            Globals.p2DispHeight = txtP2Height.Text;
            Globals.p3DispWidth = txtP3Width.Text;
            Globals.p3DispHeight = txtP3Height.Text;

            Globals.SpeedoCanOffset = txtSpeedoCanOffset.Text;
            Globals.TachoCanOffset = txtTachoCanOffset.Text;
            Globals.BoostCanOffset = txtBoostCanOffset.Text;
            Globals.TempCanOffset = txtTempCanOffset.Text;
            Globals.OilCanOffset = txtOilCanOffset.Text;
            Globals.OilTCanOffset = txtOilTCanOffset.Text;
            Globals.FuelCanOffset = txtFuelCanOffset.Text;
            Globals.FuelTCanOffset = txtFuelTCanOffset.Text;
            Globals.FuelPCanOffset = txtFuelPCanOffset.Text;
            Globals.BatteryCanOffset = txtBatteryCanOffset.Text;
            Globals.User1CanOffset = txtUser1CanOffset.Text;
            Globals.User2CanOffset = txtUser2CanOffset.Text;
            Globals.User3CanOffset = txtUser3CanOffset.Text;
            Globals.User4CanOffset = txtUser4CanOffset.Text;

            Globals.SpeedoGPIO = cmbGPIOSpeedo.Text;
            Globals.TachoGPIO = cmbGPIOTacho.Text;
            Globals.BoostGPIO = cmbGPIOBoost.Text;
            Globals.TempGPIO = cmbGPIOTemp.Text;
            Globals.OilGPIO = cmbGPIOOil.Text;
            Globals.OilTGPIO = cmbGPIOOilT.Text;
            Globals.FuelGPIO = cmbGPIOFuel.Text;
            Globals.FuelTGPIO = cmbGPIOFuelT.Text;
            Globals.FuelPGPIO = cmbGPIOFuelP.Text;
            Globals.BatteryGPIO = cmbGPIOBattery.Text;
            Globals.User1GPIO = cmbGPIOUser1.Text;
            Globals.User2GPIO = cmbGPIOUser2.Text;
            Globals.User3GPIO = cmbGPIOUser3.Text;
            Globals.User4GPIO = cmbGPIOUser4.Text;


            switch (cmbSerCanP1ECU.Text)
            {
                case "Serial3":
                    Globals.SerCanP1Ecu = "serial3";         // Serial3 / can        ---   cmbSerCanP1ECU
                    Globals.SerCanPortP1Ecu = cmbSerCanP1ECUSerInter.Text;  // /dev/ttyS0 can0
                    Globals.SerCanSpeedP1Ecu = cmbSerCanP1ECUSerSpeed.Text;	    // 115200	125k
                    Globals.SerCanAddressP1Ecu = "";   // 0x101 --both Panel 1 and ECU config
                    break;

                case "pcan":
                    Globals.SerCanP1Ecu = "pcan";          // Serial3 / can        ---   cmbSerCanP1ECU
                    Globals.SerCanPortP1Ecu = cmbSerCanP1ECUCanInter.Text;	    // /dev/ttyS0 can0
                    Globals.SerCanSpeedP1Ecu = cmbSerCanP1ECUCanSpeed.Text;	    // 115200	125k
                    Globals.SerCanAddressP1 = cmbCanAddressP1.Text;   // 0x101 --both Panel 1 and ECU config
                    Globals.SerCanAddressP1Ecu = cmbCanAddressEcu.Text;   // 0x101 --both Panel 1 and ECU config
                    break;

                case "slcan":
                    Globals.SerCanP1Ecu = "slcan";          // Serial3 / can        ---   cmbSerCanP1ECU
                    Globals.SerCanPortP1Ecu = cmbSerCanP1ECUCanInter.Text;	    // /dev/ttyS0 can0
                    Globals.SerCanSpeedP1Ecu = cmbSerCanP1ECUCanSpeed.Text;	    // 115200	125k
                    Globals.SerCanAddressP1 = cmbCanAddressP1.Text;   // 0x101 --both Panel 1 and ECU config
                    Globals.SerCanAddressP1Ecu = cmbCanAddressEcu.Text;   // 0x101 --both Panel 1 and ECU config
                    break;

                case "vcan":
                    Globals.SerCanP1Ecu = "vcan";          // Serial3 / can        ---   cmbSerCanP1ECU
                    Globals.SerCanPortP1Ecu = cmbSerCanP1ECUCanInter.Text;	    // /dev/ttyS0 can0
                    Globals.SerCanSpeedP1Ecu = cmbSerCanP1ECUCanSpeed.Text;	    // 115200	125k
                    Globals.SerCanAddressP1 = cmbCanAddressP1.Text;   // 0x101 --both Panel 1 and ECU config
                    Globals.SerCanAddressP1Ecu = cmbCanAddressEcu.Text;   // 0x101 --both Panel 1 and ECU config
                    break;

                case "serialcan":
                    Globals.SerCanP1Ecu = "serialcan";          // Serial3 / can        ---   cmbSerCanP1ECU
                    Globals.SerCanPortP1Ecu = cmbSerCanP1ECUCanInter.Text;	    // /dev/ttyS0 can0
                    Globals.SerCanSpeedP1Ecu = cmbSerCanP1ECUCanSpeed.Text;	    // 115200	125k
                    Globals.SerCanAddressP1 = cmbCanAddressP1.Text;   // 0x101 --both Panel 1 and ECU config
                    Globals.SerCanAddressP1Ecu = cmbCanAddressEcu.Text;   // 0x101 --both Panel 1 and ECU config
                    break;

                case "obd":
                    Globals.SerCanP1Ecu = "obd";          // Serial3 / can        ---   cmbSerCanP1ECU
                    Globals.SerCanPortP1Ecu = cmbSerCanP1ECUCanInter.Text;	    // /dev/ttyS0 can0
                    Globals.SerCanSpeedP1Ecu = cmbSerCanP1ECUCanSpeed.Text;	    // 115200	125k
                    Globals.SerCanAddressP1 = cmbCanAddressP1.Text;   // 0x101 --both Panel 1 and ECU config
                    Globals.SerCanAddressP1Ecu = cmbCanAddressEcu.Text;   // 0x101 --both Panel 1 and ECU config                    break;
                    break;            
            }

            switch (cmbSerCanP1P2.Text)
            {
                case "Ethernet":
                    Globals.SerCanP1P2 = "Ethernet";
                    Globals.SerCanPortP1P2 = "";
                    Globals.SerCanSpeedP1P2 = "";
                    Globals.SerCanAddressP1P2 = "";
                    break;

                case "Serial3":
                    Globals.SerCanP1P2 = "Serial3";
                    Globals.SerCanPortP1P2 = cmbSerCanP1P2SerInter.Text;
                    Globals.SerCanSpeedP1P2 = cmbSerCanP1P2SerSpeed.Text;
                    Globals.SerCanAddressP1P2 = "";
                    break;

                case "pcan":
                    Globals.SerCanP1P2 = "pcan";
                    Globals.SerCanPortP1P2 = cmbSerCanP1P2CanInter.Text;
                    Globals.SerCanSpeedP1P2 = cmbSerCanP1P2CanSpeed.Text;
                    Globals.SerCanAddressP1P2 = cmbSerCanP2Address.Text;
                    break;

                case "slcan":
                    Globals.SerCanP1P2 = "slcan";
                    Globals.SerCanPortP1P2 = cmbSerCanP1P2CanInter.Text;
                    Globals.SerCanSpeedP1P2 = cmbSerCanP1P2CanSpeed.Text;
                    Globals.SerCanAddressP1P2 = cmbSerCanP2Address.Text;
                    break;

                case "vcan":
                    Globals.SerCanP1P2 = "vcan";
                    Globals.SerCanPortP1P2 = cmbSerCanP1P2CanInter.Text;
                    Globals.SerCanSpeedP1P2 = cmbSerCanP1P2CanSpeed.Text;
                    Globals.SerCanAddressP1P2 = cmbSerCanP2Address.Text;
                    break;

                case "serialcan":
                    Globals.SerCanP1P2 = "serialcan";
                    Globals.SerCanPortP1P2 = cmbSerCanP1P2CanInter.Text;
                    Globals.SerCanSpeedP1P2 = cmbSerCanP1P2CanSpeed.Text;
                    Globals.SerCanAddressP1P2 = cmbSerCanP2Address.Text;
                    break;

                case "obd":
                    Globals.SerCanP1P2 = "odb";
                    Globals.SerCanPortP1P2 = cmbSerCanP1P2CanInter.Text;
                    Globals.SerCanSpeedP1P2 = cmbSerCanP1P2CanSpeed.Text;
                    Globals.SerCanAddressP1P2 = cmbSerCanP2Address.Text;
                    break;
            }

            switch (cmbSerCanP1P3.Text)
            {
                case "Ethernet":
                    Globals.SerCanP1P3 = "ethernet";
                    Globals.SerCanPortP1P3 = "";
                    Globals.SerCanSpeedP1P3 = "";
                    Globals.SerCanAddressP1P3 = "";
                    break;
                case "pcan":
                    Globals.SerCanP1P3 = "pcan";
                    Globals.SerCanPortP1P3 = cmbSerCanP1P3CanInter.Text;
                    Globals.SerCanSpeedP1P3 = cmbSerCanP1P3CanSpeed.Text;
                    Globals.SerCanAddressP1P3 = cmbSerCanP3Address.Text;
                    break;
                case "slcan":
                    Globals.SerCanP1P3 = "slcan";
                    Globals.SerCanPortP1P3 = cmbSerCanP1P3CanInter.Text;
                    Globals.SerCanSpeedP1P3 = cmbSerCanP1P3CanSpeed.Text;
                    Globals.SerCanAddressP1P3 = cmbSerCanP3Address.Text;
                    break;
                case "vcan":
                    Globals.SerCanP1P3 = "vcan";
                    Globals.SerCanPortP1P3 = cmbSerCanP1P3CanInter.Text;
                    Globals.SerCanSpeedP1P3 = cmbSerCanP1P3CanSpeed.Text;
                    Globals.SerCanAddressP1P3 = cmbSerCanP3Address.Text;
                    break;
                case "serialcan":
                    Globals.SerCanP1P3 = "serialcan";
                    Globals.SerCanPortP1P3 = cmbSerCanP1P3CanInter.Text;
                    Globals.SerCanSpeedP1P3 = cmbSerCanP1P3CanSpeed.Text;
                    Globals.SerCanAddressP1P3 = cmbSerCanP3Address.Text;
                    break;
                case "obd":
                    Globals.SerCanP1P3 = "odb";
                    Globals.SerCanPortP1P3 = cmbSerCanP1P3CanInter.Text;
                    Globals.SerCanSpeedP1P3 = cmbSerCanP1P3CanSpeed.Text;
                    Globals.SerCanAddressP1P3 = cmbSerCanP3Address.Text;
                    break;
            }

            Globals.p1connection = "ecuconnection," + Globals.SerCanP1Ecu + "," + Globals.SerCanPortP1Ecu + "," + Globals.SerCanSpeedP1Ecu + "," + Globals.SerCanAddressP1Ecu + "," + Globals.PanelIP1 + "," + Globals.SerCanAddressP1;
            Globals.p2connection = "p2connection," + Globals.SerCanP1P2 + "," + Globals.SerCanPortP1P2 + "," + Globals.SerCanSpeedP1P2 + "," + Globals.SerCanAddressP1P2 + "," + Globals.PanelIP2;
            Globals.p3connection = "p3connection," + Globals.SerCanP1P3 + "," + Globals.SerCanPortP1P3 + "," + Globals.SerCanSpeedP1P3 + "," + Globals.SerCanAddressP1P3 + "," + Globals.PanelIP3;

            //user gauge names
            Globals.User1name = lblUser1.Text ;
            Globals.User2name = lblUser2.Text;
            Globals.User3name = lblUser3.Text;
            Globals.User4name = lblUser4.Text;


            Globals.SpeedoNeedleWidth = txtSpeedoNeedleWidth.Text;
            Globals.SpeedoNeedleLength = txtSpeedoNeedleLength.Text;
            Globals.SpeedoNeedleX = txtSpeedoNeedleX.Text;
            Globals.SpeedoNeedleY = txtSpeedoNeedleY.Text;
            Globals.SpeedoOffset = txtSpeedoOffset.Text;
            Globals.SpeedoEnd = txtSpeedoEnd.Text;
            Globals.SpeedoTop = txtSpeedoTop.Text;
            Globals.SpeedoTextX = txtSpeedoTextX.Text;
            Globals.SpeedoTextY = txtSpeedoTextY.Text;
            Globals.SpeedoFontSize = txtSpeedoFontSize.Text;
            Globals.SpeedoTextStyle = cmbSpeedoTextStyle.Text;
            Globals.SpeedoNeedle = txtSpeedoNeedle.Text;
            switch (cmbSpeedo.Text)
            {
                case "Gauge":
                    Globals.SpeedoNeedleType = "gauge";
                    break;
                case "Vertical Bar":
                    Globals.SpeedoNeedleType = "barV";
                    break;
                case "Horizontal Bar":
                    Globals.SpeedoNeedleType = "barH";
                    break;
            }
            if (Globals.SpeedoNeedleType != "Gauge") { if (cmbSpeedoAboveBelow.Text == "á") { Globals.SpeedoNeedle = txtSpeedoNeedle.Text; Globals.SpeedoOffset  = "1"; } else { Globals.SpeedoNeedle = txtSpeedoNeedle.Text; Globals.SpeedoOffset = "0"; } } else  { Globals.SpeedoNeedle = txtSpeedoNeedle.Text; }

            Globals.TachoNeedleWidth = txtTachoNeedleWidth.Text;
            Globals.TachoNeedleLength = txtTachoNeedleLength.Text;
            Globals.TachoNeedleX = txtTachoNeedleX.Text;
            Globals.TachoNeedleY = txtTachoNeedleY.Text;
            Globals.TachoOffset = txtTachoOffset.Text;
            Globals.TachoEnd = txtTachoEnd.Text;
            Globals.TachoTop = txtTachoTop.Text;
            Globals.TachoTextX = txtTachoTextX.Text;
            Globals.TachoTextY = txtTachoTextY.Text;
            Globals.TachoFontSize = txtTachoFontSize.Text;
            Globals.TachoTextStyle = cmbTachoTextStyle.Text;
            Globals.TachoNeedle = txtTachoNeedle.Text;
            switch (cmbTacho.Text)
            {
                case "Gauge":
                    Globals.TachoNeedleType = "gauge";
                    break;
                case "Vertical Bar":
                    Globals.TachoNeedleType = "barV";
                    break;
                case "Horizontal Bar":
                    Globals.TachoNeedleType = "barH";
                    break;
            }
            if (Globals.TachoNeedleType != "Gauge") { if (cmbTachoAboveBelow.Text == "á") { Globals.TachoNeedle = txtTachoNeedle.Text; Globals.TachoOffset = "1"; } else { Globals.TachoNeedle = txtTachoNeedle.Text; Globals.TachoOffset = "0"; } } else { Globals.TachoNeedle = txtTachoNeedle.Text; }

            Globals.BoostNeedleWidth = txtBoostNeedleWidth.Text;
            Globals.BoostNeedleLength = txtBoostNeedleLength.Text;
            Globals.BoostNeedleX = txtBoostNeedleX.Text;
            Globals.BoostNeedleY = txtBoostNeedleY.Text;
            Globals.BoostOffset = txtBoostOffset.Text;
            Globals.BoostEnd = txtBoostEnd.Text;
            Globals.BoostTop = txtBoostTop.Text;
            Globals.BoostTextX = txtBoostTextX.Text;
            Globals.BoostTextY = txtBoostTextY.Text;
            Globals.BoostFontSize = txtBoostFontSize.Text;
            Globals.BoostTextStyle = cmbBoostTextStyle.Text;
            Globals.BoostNeedle = txtBoostNeedle.Text;
            switch (cmbBoost.Text)
            {
                case "Gauge":
                    Globals.BoostNeedleType = "gauge";
                    break;
                case "Vertical Bar":
                    Globals.BoostNeedleType = "barV";
                    break;
                case "Horizontal Bar":
                    Globals.BoostNeedleType = "barH";
                    break;
            }
            if (Globals.BoostNeedleType != "Gauge") { if (cmbBoostAboveBelow.Text == "á") { Globals.BoostNeedle = txtBoostNeedle.Text; Globals.BoostOffset = "1"; } else { Globals.BoostNeedle = txtBoostNeedle.Text; Globals.BoostOffset = "0"; } } else { Globals.BoostNeedle = txtBoostNeedle.Text; }

            Globals.TempNeedleWidth = txtTempNeedleWidth.Text;
            Globals.TempNeedleLength = txtTempNeedleLength.Text;
            Globals.TempNeedleX = txtTempNeedleX.Text;
            Globals.TempNeedleY = txtTempNeedleY.Text;
            Globals.TempOffset = txtTempOffset.Text;
            Globals.TempEnd = txtTempEnd.Text;
            Globals.TempTop = txtTempTop.Text;
            Globals.TempTextX = txtTempTextX.Text;
            Globals.TempTextY = txtTempTextY.Text;
            Globals.TempFontSize = txtTempFontSize.Text;
            Globals.TempTextStyle = cmbTempTextStyle.Text;
            Globals.TempNeedle = txtTempNeedle.Text;
            switch (cmbTemp.Text)
            {
                case "Gauge":
                    Globals.TempNeedleType = "gauge";
                    break;
                case "Vertical Bar":
                    Globals.TempNeedleType = "barV";
                    break;
                case "Horizontal Bar":
                    Globals.TempNeedleType = "barH";
                    break;
            }
            if (Globals.TempNeedleType != "Gauge") { if (cmbTempAboveBelow.Text == "á") { Globals.TempNeedle = txtTempNeedle.Text; Globals.TempOffset = "1"; } else { Globals.TempNeedle = txtTempNeedle.Text; Globals.TempOffset = "0"; } } else { Globals.TempNeedle = txtTempNeedle.Text; }

            Globals.OilNeedleWidth = txtOilNeedleWidth.Text;
            Globals.OilNeedleLength = txtOilNeedleLength.Text;
            Globals.OilNeedleX = txtOilNeedleX.Text;
            Globals.OilNeedleY = txtOilNeedleY.Text;
            Globals.OilOffset = txtOilOffset.Text;
            Globals.OilEnd = txtOilEnd.Text;
            Globals.OilTop = txtOilTop.Text;
            Globals.OilTextX = txtOilTextX.Text;
            Globals.OilTextY = txtOilTextY.Text;
            Globals.OilFontSize = txtOilFontSize.Text;
            Globals.OilTextStyle = cmbOilTextStyle.Text;
            Globals.OilNeedle = txtOilNeedle.Text;
            switch (cmbOil.Text)
            {
                case "Gauge":
                    Globals.OilNeedleType = "gauge";
                    break;
                case "Vertical Bar":
                    Globals.OilNeedleType = "barV";
                    break;
                case "Horizontal Bar":
                    Globals.OilNeedleType = "barH";
                    break;
            }
            if (Globals.OilNeedleType != "Gauge") { if (cmbOilAboveBelow.Text == "á") { Globals.OilNeedle = txtOilNeedle.Text; Globals.OilOffset = "1"; } else { Globals.OilNeedle = txtOilNeedle.Text; Globals.OilOffset = "0"; } } else { Globals.OilNeedle = txtOilNeedle.Text; }

            Globals.OilTNeedleWidth = txtOilTNeedleWidth.Text;
            Globals.OilTNeedleLength = txtOilTNeedleLength.Text;
            Globals.OilTNeedleX = txtOilTNeedleX.Text;
            Globals.OilTNeedleY = txtOilTNeedleY.Text;
            Globals.OilTOffset = txtOilTOffset.Text;
            Globals.OilTEnd = txtOilTEnd.Text;
            Globals.OilTTop = txtOilTTop.Text;
            Globals.OilTTextX = txtOilTTextX.Text;
            Globals.OilTTextY = txtOilTTextY.Text;
            Globals.OilTFontSize = txtOilTFontSize.Text;
            Globals.OilTTextStyle = cmbOilTTextStyle.Text;
            Globals.OilTNeedle = txtOilTNeedle.Text;
            switch (cmbOilT.Text)
            {
                case "Gauge":
                    Globals.OilTNeedleType = "gauge";
                    break;
                case "Vertical Bar":
                    Globals.OilTNeedleType = "barV";
                    break;
                case "Horizontal Bar":
                    Globals.OilTNeedleType = "barH";
                    break;
            }
            if (Globals.OilTNeedleType != "Gauge") { if (cmbOilTAboveBelow.Text == "á") { Globals.OilTNeedle = txtOilTNeedle.Text; Globals.OilTOffset = "1"; } else { Globals.OilTNeedle = txtOilTNeedle.Text; Globals.OilTOffset = "0"; } } else { Globals.OilTNeedle = txtOilTNeedle.Text; }

            Globals.FuelNeedleWidth = txtFuelNeedleWidth.Text;
            Globals.FuelNeedleLength = txtFuelNeedleLength.Text;
            Globals.FuelNeedleX = txtFuelNeedleX.Text;
            Globals.FuelNeedleY = txtFuelNeedleY.Text;
            Globals.FuelOffset = txtFuelOffset.Text;
            Globals.FuelEnd = txtFuelEnd.Text;
            Globals.FuelTop = txtFuelTop.Text;
            Globals.FuelTextX = txtFuelTextX.Text;
            Globals.FuelTextY = txtFuelTextY.Text;
            Globals.FuelFontSize = txtFuelFontSize.Text;
            Globals.FuelTextStyle = cmbFuelTextStyle.Text;
            Globals.FuelNeedle = txtFuelNeedle.Text;
            switch (cmbFuel.Text)
            {
                case "Gauge":
                    Globals.FuelNeedleType = "gauge";
                    break;
                case "Vertical Bar":
                    Globals.FuelNeedleType = "barV";
                    break;
                case "Horizontal Bar":
                    Globals.FuelNeedleType = "barH";
                    break;
            }
            if (Globals.FuelNeedleType != "Gauge") { if (cmbFuelAboveBelow.Text == "á") { Globals.FuelNeedle = txtFuelNeedle.Text; Globals.FuelOffset = "1"; } else { Globals.FuelNeedle = txtFuelNeedle.Text; Globals.FuelOffset = "0"; } } else { Globals.FuelNeedle = txtFuelNeedle.Text; }

            Globals.FuelTNeedleWidth = txtFuelTNeedleWidth.Text;
            Globals.FuelTNeedleLength = txtFuelTNeedleLength.Text;
            Globals.FuelTNeedleX = txtFuelTNeedleX.Text;
            Globals.FuelTNeedleY = txtFuelTNeedleY.Text;
            Globals.FuelTOffset = txtFuelTOffset.Text;
            Globals.FuelTEnd = txtFuelTEnd.Text;
            Globals.FuelTTop = txtFuelTTop.Text;
            Globals.FuelTTextX = txtFuelTTextX.Text;
            Globals.FuelTTextY = txtFuelTTextY.Text;
            Globals.FuelTFontSize = txtFuelTFontSize.Text;
            Globals.FuelTTextStyle = cmbFuelTTextStyle.Text;
            Globals.FuelTNeedle = txtFuelTNeedle.Text;
            switch (cmbFuelT.Text)
            {
                case "Gauge":
                    Globals.FuelTNeedleType = "gauge";
                    break;
                case "Vertical Bar":
                    Globals.FuelTNeedleType = "barV";
                    break;
                case "Horizontal Bar":
                    Globals.FuelTNeedleType = "barH";
                    break;
            }
            if (Globals.FuelTNeedleType != "Gauge") { if (cmbFuelTAboveBelow.Text == "á") { Globals.FuelTNeedle = txtFuelTNeedle.Text; Globals.FuelTOffset = "1"; } else { Globals.FuelTNeedle = txtFuelTNeedle.Text; Globals.FuelTOffset = "0"; } } else { Globals.FuelTNeedle = txtFuelTNeedle.Text; }

            Globals.FuelPNeedleWidth = txtFuelPNeedleWidth.Text;
            Globals.FuelPNeedleLength = txtFuelPNeedleLength.Text;
            Globals.FuelPNeedleX = txtFuelPNeedleX.Text;
            Globals.FuelPNeedleY = txtFuelPNeedleY.Text;
            Globals.FuelPOffset = txtFuelPOffset.Text;
            Globals.FuelPEnd = txtFuelPEnd.Text;
            Globals.FuelPTop = txtFuelPTop.Text;
            Globals.FuelPTextX = txtFuelPTextX.Text;
            Globals.FuelPTextY = txtFuelPTextY.Text;
            Globals.FuelPFontSize = txtFuelPFontSize.Text;
            Globals.FuelPTextStyle = cmbFuelPTextStyle.Text;
            Globals.FuelPNeedle = txtFuelPNeedle.Text;
            switch (cmbFuelP.Text)
            {
                case "Gauge":
                    Globals.FuelPNeedleType = "gauge";
                    break;
                case "Vertical Bar":
                    Globals.FuelPNeedleType = "barV";
                    break;
                case "Horizontal Bar":
                    Globals.FuelPNeedleType = "barH";
                    break;
            }
            if (Globals.FuelPNeedleType != "Gauge") { if (cmbFuelPAboveBelow.Text == "á") { Globals.FuelPNeedle = txtFuelPNeedle.Text; Globals.FuelPOffset = "1"; } else { Globals.FuelPNeedle = txtFuelPNeedle.Text; Globals.FuelPOffset = "0"; } } else { Globals.FuelPNeedle = txtFuelPNeedle.Text; }

            Globals.BatteryNeedleWidth = txtBatteryNeedleWidth.Text;
            Globals.BatteryNeedleLength = txtBatteryNeedleLength.Text;
            Globals.BatteryNeedleX = txtBatteryNeedleX.Text;
            Globals.BatteryNeedleY = txtBatteryNeedleY.Text;
            Globals.BatteryOffset = txtBatteryOffset.Text;
            Globals.BatteryEnd = txtBatteryEnd.Text;
            Globals.BatteryTop = txtBatteryTop.Text;
            Globals.BatteryTextX = txtBatteryTextX.Text;
            Globals.BatteryTextY = txtBatteryTextY.Text;
            Globals.BatteryFontSize = txtBatteryFontSize.Text;
            Globals.BatteryTextStyle = cmbBatteryTextStyle.Text;
            Globals.BatteryNeedle = txtBatteryNeedle.Text;
            switch (cmbBattery.Text)
            {
                case "Gauge":
                    Globals.BatteryNeedleType = "gauge";
                    break;
                case "Vertical Bar":
                    Globals.BatteryNeedleType = "barV";
                    break;
                case "Horizontal Bar":
                    Globals.BatteryNeedleType = "barH";
                    break;
            }
            if (Globals.BatteryNeedleType != "Gauge") { if (cmbBatteryAboveBelow.Text == "á") { Globals.BatteryNeedle = txtBatteryNeedle.Text; Globals.BatteryOffset = "1"; } else { Globals.BatteryNeedle = txtBatteryNeedle.Text; Globals.BatteryOffset = "0"; } } else { Globals.BatteryNeedle = txtBatteryNeedle.Text; }

            Globals.User1NeedleWidth = txtUser1NeedleWidth.Text;
            Globals.User1NeedleLength = txtUser1NeedleLength.Text;
            Globals.User1NeedleX = txtUser1NeedleX.Text;
            Globals.User1NeedleY = txtUser1NeedleY.Text;
            Globals.User1Offset = txtUser1Offset.Text;
            Globals.User1End = txtUser1End.Text;
            Globals.User1Top = txtUser1Top.Text;
            Globals.User1TextX = txtUser1TextX.Text;
            Globals.User1TextY = txtUser1TextY.Text;
            Globals.User1FontSize = txtUser1FontSize.Text;
            Globals.User1TextStyle = cmbUser1TextStyle.Text;
            Globals.User1Needle = txtUser1Needle.Text;
            switch (cmbUser1.Text)
            {
                case "Gauge":
                    Globals.User1NeedleType = "gauge";
                    break;
                case "Vertical Bar":
                    Globals.User1NeedleType = "barV";
                    break;
                case "Horizontal Bar":
                    Globals.User1NeedleType = "barH";
                    break;
            }
            if (Globals.User1NeedleType != "Gauge") { if (cmbUser1AboveBelow.Text == "á") { Globals.User1Needle = txtUser1Needle.Text; Globals.User1Offset = "1"; } else { Globals.User1Needle = txtUser1Needle.Text; Globals.User1Offset = "0"; } } else { Globals.User1Needle = txtUser1Needle.Text; }

            Globals.User2NeedleWidth = txtUser2NeedleWidth.Text;
            Globals.User2NeedleLength = txtUser2NeedleLength.Text;
            Globals.User2NeedleX = txtUser2NeedleX.Text;
            Globals.User2NeedleY = txtUser2NeedleY.Text;
            Globals.User2Offset = txtUser2Offset.Text;
            Globals.User2End = txtUser2End.Text;
            Globals.User2Top = txtUser2Top.Text;
            Globals.User2TextX = txtUser2TextX.Text;
            Globals.User2TextY = txtUser2TextY.Text;
            Globals.User2FontSize = txtUser2FontSize.Text;
            Globals.User2TextStyle = cmbUser2TextStyle.Text;
            Globals.User2Needle = txtUser2Needle.Text;
            switch (cmbUser2.Text)
            {
                case "Gauge":
                    Globals.User2NeedleType = "gauge";
                    break;
                case "Vertical Bar":
                    Globals.User2NeedleType = "barV";
                    break;
                case "Horizontal Bar":
                    Globals.User2NeedleType = "barH";
                    break;
            }
            if (Globals.User2NeedleType != "Gauge") { if (cmbUser2AboveBelow.Text == "á") { Globals.User2Needle = txtUser2Needle.Text; Globals.User2Offset = "1"; } else { Globals.User2Needle = txtUser2Needle.Text; Globals.User2Offset = "0"; } } else { Globals.User2Needle = txtUser2Needle.Text; }

            Globals.User3NeedleWidth = txtUser3NeedleWidth.Text;
            Globals.User3NeedleLength = txtUser3NeedleLength.Text;
            Globals.User3NeedleX = txtUser3NeedleX.Text;
            Globals.User3NeedleY = txtUser3NeedleY.Text;
            Globals.User3Offset = txtUser3Offset.Text;
            Globals.User3End = txtUser3End.Text;
            Globals.User3Top = txtUser3Top.Text;
            Globals.User3TextX = txtUser3TextX.Text;
            Globals.User3TextY = txtUser3TextY.Text;
            Globals.User3FontSize = txtUser3FontSize.Text;
            Globals.User3TextStyle = cmbUser3TextStyle.Text;
            Globals.User3Needle = txtUser3Needle.Text;
            switch (cmbUser3.Text)
            {
                case "Gauge":
                    Globals.User3NeedleType = "gauge";
                    break;
                case "Vertical Bar":
                    Globals.User3NeedleType = "barV";
                    break;
                case "Horizontal Bar":
                    Globals.User3NeedleType = "barH";
                    break;
            }
            if (Globals.User3NeedleType != "Gauge") { if (cmbUser3AboveBelow.Text == "á") { Globals.User3Needle = txtUser3Needle.Text; Globals.User3Offset = "1"; } else { Globals.User3Needle = txtUser3Needle.Text; Globals.User3Offset = "0"; } } else { Globals.User3Needle = txtUser3Needle.Text; }

            Globals.User4NeedleWidth = txtUser4NeedleWidth.Text;
            Globals.User4NeedleLength = txtUser4NeedleLength.Text;
            Globals.User4NeedleX = txtUser4NeedleX.Text;
            Globals.User4NeedleY = txtUser4NeedleY.Text;
            Globals.User4Offset = txtUser4Offset.Text;
            Globals.User4End = txtUser4End.Text;
            Globals.User4Top = txtUser4Top.Text;
            Globals.User4TextX = txtUser4TextX.Text;
            Globals.User4TextY = txtUser4TextY.Text;
            Globals.User4FontSize = txtUser4FontSize.Text;
            Globals.User4TextStyle = cmbUser4TextStyle.Text;
            Globals.User4Needle = txtUser4Needle.Text;
            switch (cmbUser4.Text)
            {
                case "Gauge":
                    Globals.User4NeedleType = "gauge";
                    break;
                case "Vertical Bar":
                    Globals.User4NeedleType = "barV";
                    break;
                case "Horizontal Bar":
                    Globals.User4NeedleType = "barH";
                    break;
            }
            if (Globals.User4NeedleType != "Gauge") { if (cmbUser4AboveBelow.Text == "á") { Globals.User4Needle = txtUser4Needle.Text; Globals.User4Offset = "1"; } else { Globals.User4Needle = txtUser4Needle.Text; Globals.User4Offset = "0"; } } else { Globals.User4Needle = txtUser4Needle.Text; }
        }

        private void VarsToSymbols()
        {
            if (Globals.symBattery == "N") {cmbSymBattery.Text = "N"; }
            if (Globals.symBattery == "1") {cmbSymBattery.Text = "Panel 1"; }
            if (Globals.symBattery == "2") {cmbSymBattery.Text = "Panel 2"; }
            if (Globals.symBattery == "3") {cmbSymBattery.Text = "Panel 3"; }
            txtSymBatteryX.Text = Globals.symBatteryX; txtSymBatteryY.Text = Globals.symBatteryY; txtSymBatteryGPIO.Text = Globals.symBatteryGPIO;

            if (Globals.symBonnet == "N") { cmbSymBonnet.Text = "N"; }
            if (Globals.symBonnet == "1") { cmbSymBonnet.Text = "Panel 1"; }
            if (Globals.symBonnet == "2") { cmbSymBonnet.Text = "Panel 2"; }
            if (Globals.symBonnet == "3") { cmbSymBonnet.Text = "Panel 3"; }
            txtSymBonnetX.Text = Globals.symBonnetX; txtSymBonnetY.Text = Globals.symBonnetY; txtSymBonnetGPIO.Text = Globals.symBonnetGPIO;

            if (Globals.symBoot == "N") { cmbSymBoot.Text = "N"; }
            if (Globals.symBoot == "1") { cmbSymBoot.Text = "Panel 1"; }
            if (Globals.symBoot == "2") { cmbSymBoot.Text = "Panel 2"; }
            if (Globals.symBoot == "3") { cmbSymBoot.Text = "Panel 3"; }
            txtSymBootX.Text = Globals.symBootX; txtSymBootY.Text = Globals.symBootY; txtSymBootGPIO.Text = Globals.symBootGPIO;

            if (Globals.symBrakes == "N") { cmbSymBrakes.Text = "N"; }
            if (Globals.symBrakes == "1") { cmbSymBrakes.Text = "Panel 1"; }
            if (Globals.symBrakes == "2") { cmbSymBrakes.Text = "Panel 2"; }
            if (Globals.symBrakes == "3") { cmbSymBrakes.Text = "Panel 3"; }
            txtSymBrakesX.Text = Globals.symBrakesX; txtSymBrakesY.Text = Globals.symBrakesY; txtSymBrakesGPIO.Text = Globals.symBrakesGPIO;

            if (Globals.symDemister == "N") { cmbSymDemister.Text = "N"; }
            if (Globals.symDemister == "1") { cmbSymDemister.Text = "Panel 1"; }
            if (Globals.symDemister == "2") { cmbSymDemister.Text = "Panel 2"; }
            if (Globals.symDemister == "3") { cmbSymDemister.Text = "Panel 3"; }
            txtSymDemisterX.Text = Globals.symDemisterX; txtSymDemisterY.Text = Globals.symDemisterY; txtSymDemisterGPIO.Text = Globals.symDemisterGPIO;

            if (Globals.symDoor == "N") { cmbSymDoor.Text = "N"; }
            if (Globals.symDoor == "1") { cmbSymDoor.Text = "Panel 1"; }
            if (Globals.symDoor == "2") { cmbSymDoor.Text = "Panel 2"; }
            if (Globals.symDoor == "3") { cmbSymDoor.Text = "Panel 3"; }
            txtSymDoorX.Text = Globals.symDoorX; txtSymDoorY.Text = Globals.symDoorY; txtSymDoorGPIO.Text = Globals.symDoorGPIO;

            if (Globals.symFoglights == "N") { cmbSymFoglight.Text = "N"; }
            if (Globals.symFoglights == "1") { cmbSymFoglight.Text = "Panel 1"; }
            if (Globals.symFoglights == "2") { cmbSymFoglight.Text = "Panel 2"; }
            if (Globals.symFoglights == "3") { cmbSymFoglight.Text = "Panel 3"; }
            txtSymFoglightX.Text = Globals.symFoglightsX; txtSymFoglightY.Text = Globals.symFoglightsY; txtSymFoglightGPIO.Text = Globals.symFoglightsGPIO;

            if (Globals.symFuel == "N") { cmbSymFuel.Text = "N"; }
            if (Globals.symFuel == "1") { cmbSymFuel.Text = "Panel 1"; }
            if (Globals.symFuel == "2") { cmbSymFuel.Text = "Panel 2"; }
            if (Globals.symFuel == "3") { cmbSymFuel.Text = "Panel 3"; }
            txtSymFuelX.Text = Globals.symFuelX; txtSymFuelY.Text = Globals.symFuelY; txtSymFuelGPIO.Text = Globals.symFuelGPIO;

            if (Globals.symFullbeam == "N") { cmbSymFullbeam.Text = "N"; }
            if (Globals.symFullbeam == "1") { cmbSymFullbeam.Text = "Panel 1"; }
            if (Globals.symFullbeam == "2") { cmbSymFullbeam.Text = "Panel 2"; }
            if (Globals.symFullbeam == "3") { cmbSymFullbeam.Text = "Panel 3"; }
            txtSymFullbeamX.Text = Globals.symFullbeamX; txtSymFullbeamY.Text = Globals.symFullbeamY; txtSymFullbeamGPIO.Text = Globals.symFullbeamGPIO;

            if (Globals.symHazards == "N") { cmbSymHazards.Text = "N"; }
            if (Globals.symHazards == "1") { cmbSymHazards.Text = "Panel 1"; }
            if (Globals.symHazards == "2") { cmbSymHazards.Text = "Panel 2"; }
            if (Globals.symHazards == "3") { cmbSymHazards.Text = "Panel 3"; }
            txtSymHazardsX.Text = Globals.symHazardsX; txtSymHazardsY.Text = Globals.symHazardsY; txtSymHazardsGPIO.Text = Globals.symHazardsGPIO;

            if (Globals.symHeadlights == "N") { cmbSymHeadlights.Text = "N"; }
            if (Globals.symHeadlights == "1") { cmbSymHeadlights.Text = "Panel 1"; }
            if (Globals.symHeadlights == "2") { cmbSymHeadlights.Text = "Panel 2"; }
            if (Globals.symHeadlights == "3") { cmbSymHeadlights.Text = "Panel 3"; }
            txtSymHeadlightsX.Text = Globals.symHeadlightsX; txtSymHeadlightsY.Text = Globals.symHeadlightsY; txtSymHeadlightsGPIO.Text = Globals.symHeadlightsGPIO;

            if (Globals.symIndLeft == "N") { cmbSymIndLeft.Text = "N"; }
            if (Globals.symIndLeft == "1") { cmbSymIndLeft.Text = "Panel 1"; }
            if (Globals.symIndLeft == "2") { cmbSymIndLeft.Text = "Panel 2"; }
            if (Globals.symIndLeft == "3") { cmbSymIndLeft.Text = "Panel 3"; }
            txtSymIndLeftX.Text = Globals.symIndLeftX; txtSymIndLeftY.Text = Globals.symIndLeftY; txtSymIndLeftGPIO.Text = Globals.symIndLeftGPIO;

            if (Globals.symIndRight == "N") { cmbSymIndRight.Text = "N"; }
            if (Globals.symIndRight == "1") { cmbSymIndRight.Text = "Panel 1"; }
            if (Globals.symIndRight == "2") { cmbSymIndRight.Text = "Panel 2"; }
            if (Globals.symIndRight == "3") { cmbSymIndRight.Text = "Panel 3"; }
            txtSymIndRightX.Text = Globals.symIndRightX; txtSymIndRightY.Text = Globals.symIndRightY; txtSymIndRightGPIO.Text = Globals.symIndRightGPIO;

            if (Globals.symOil == "N") { cmbSymOil.Text = "N"; }
            if (Globals.symOil == "1") { cmbSymOil.Text = "Panel 1"; }
            if (Globals.symOil == "2") { cmbSymOil.Text = "Panel 2"; }
            if (Globals.symOil == "3") { cmbSymOil.Text = "Panel 3"; }
            txtSymOilX.Text = Globals.symOilX; txtSymOilY.Text = Globals.symOilY; txtSymOilGPIO.Text = Globals.symOilGPIO;

            if (Globals.symSeatbelt == "N") { cmbSymSeatbelts.Text = "N"; }
            if (Globals.symSeatbelt == "1") { cmbSymSeatbelts.Text = "Panel 1"; }
            if (Globals.symSeatbelt == "2") { cmbSymSeatbelts.Text = "Panel 2"; }
            if (Globals.symSeatbelt == "3") { cmbSymSeatbelts.Text = "Panel 3"; }
            txtSymSeatbeltsX.Text = Globals.symSeatbeltX; txtSymSeatbeltsY.Text = Globals.symSeatbeltY; txtSymSeatbeltsGPIO.Text = Globals.symSeatbeltGPIO;

            if (Globals.symSeatLeft == "N") { cmbSymSeat1.Text = "N"; }
            if (Globals.symSeatLeft == "1") { cmbSymSeat1.Text = "Panel 1"; }
            if (Globals.symSeatLeft == "2") { cmbSymSeat1.Text = "Panel 2"; }
            if (Globals.symSeatLeft == "3") { cmbSymSeat1.Text = "Panel 3"; }
            txtSymSeat1X.Text = Globals.symSeatLeftX; txtSymSeat1Y.Text = Globals.symSeatLeft; txtSymSeat1GPIO.Text = Globals.symSeatLeftGPIO;

            if (Globals.symSeatRight == "N") { cmbSymSeat2.Text = "N"; }
            if (Globals.symSeatRight == "1") { cmbSymSeat2.Text = "Panel 1"; }
            if (Globals.symSeatRight == "2") { cmbSymSeat2.Text = "Panel 2"; }
            if (Globals.symSeatRight == "3") { cmbSymSeat2.Text = "Panel 3"; }
            txtSymSeat2X.Text = Globals.symSeatRight; txtSymSeat2Y.Text = Globals.symSeatRight; txtSymSeat2GPIO.Text = Globals.symSeatRight;

            if (Globals.symSidelights == "N") { cmbSymSidelights.Text = "N"; }
            if (Globals.symSidelights == "1") { cmbSymSidelights.Text = "Panel 1"; }
            if (Globals.symSidelights == "2") { cmbSymSidelights.Text = "Panel 2"; }
            if (Globals.symSidelights == "3") { cmbSymSidelights.Text = "Panel 3"; }
            txtSymSidelightX.Text = Globals.symSidelightsX; txtSymSidelightY.Text = Globals.symSidelightsY; txtSymSidelightGPIO.Text = Globals.symSidelightsGPIO;

            if (Globals.symSpotlights == "N") { cmbSymSpotlights.Text = "N"; }
            if (Globals.symSpotlights == "1") { cmbSymSpotlights.Text = "Panel 1"; }
            if (Globals.symSpotlights == "2") { cmbSymSpotlights.Text = "Panel 2"; }
            if (Globals.symSpotlights == "3") { cmbSymSpotlights.Text = "Panel 3"; }
            txtSymSpotlightX.Text = Globals.symSpotlightsX; txtSymSpotlightY.Text = Globals.symSpotlightsY; txtSymSpotlightGPIO.Text = Globals.symSpotlightsGPIO;

            if (Globals.symTemp == "N") { cmbSymTemp.Text = "N"; }
            if (Globals.symTemp == "1") { cmbSymTemp.Text = "Panel 1"; }
            if (Globals.symTemp == "2") { cmbSymTemp.Text = "Panel 2"; }
            if (Globals.symTemp == "3") { cmbSymTemp.Text = "Panel 3"; }
            txtSymTempX.Text = Globals.symTempX; txtSymTempY.Text = Globals.symTempY; txtSymTempGPIO.Text = Globals.symTempGPIO;

            if (Globals.symTyre == "N") { cmbSymTyre.Text = "N"; }
            if (Globals.symTyre == "1") { cmbSymTyre.Text = "Panel 1"; }
            if (Globals.symTyre == "2") { cmbSymTyre.Text = "Panel 2"; }
            if (Globals.symTyre == "3") { cmbSymTyre.Text = "Panel 3"; }
            txtSymTyreX.Text = Globals.symTyreX; txtSymTyreY.Text = Globals.symTyreY; txtSymTyreGPIO.Text = Globals.symTyreGPIO;

            if (Globals.symWasher == "N") { cmbSymWasher.Text = "N"; }
            if (Globals.symWasher == "1") { cmbSymWasher.Text = "Panel 1"; }
            if (Globals.symWasher == "2") { cmbSymWasher.Text = "Panel 2"; }
            if (Globals.symWasher == "3") { cmbSymWasher.Text = "Panel 3"; }
            txtSymWasherX.Text = Globals.symWasherX; txtSymWasherY.Text = Globals.symWasherY; txtSymWasherGPIO.Text = Globals.symWasherGPIO;

            if (Globals.symWiperInt == "N") { cmbSymWiperInt.Text = "N"; }
            if (Globals.symWiperInt == "1") { cmbSymWiperInt.Text = "Panel 1"; }
            if (Globals.symWiperInt == "2") { cmbSymWiperInt.Text = "Panel 2"; }
            if (Globals.symWiperInt == "3") { cmbSymWiperInt.Text = "Panel 3"; }
            txtSymWiperIntX.Text = Globals.symWiperIntX; txtSymWiperIntY.Text = Globals.symWiperIntY; wiperint.Text = Globals.symWiperIntGPIO;
        }

        private void SymbolsToVars()
        {
            if (cmbSymBattery.Text == "N") { Globals.symBattery = "N"; }
            if (cmbSymBattery.Text == "Panel 1") { Globals.symBattery = "1"; }
            if (cmbSymBattery.Text == "Panel 2") { Globals.symBattery = "2"; }
            if (cmbSymBattery.Text == "Panel 3") { Globals.symBattery = "3"; }
            Globals.symBatteryX = txtSymBatteryX.Text; Globals.symBatteryY = txtSymBatteryY.Text; Globals.symBatteryGPIO = txtSymBatteryGPIO.Text;

            if (cmbSymBonnet.Text == "N") { Globals.symBonnet = "N"; }
            if (cmbSymBonnet.Text == "Panel 1") { Globals.symBonnet = "1"; }
            if (cmbSymBonnet.Text == "Panel 2") { Globals.symBonnet = "2"; }
            if (cmbSymBonnet.Text == "Panel 3") { Globals.symBonnet = "3"; }
            Globals.symBonnetX = txtSymBonnetX.Text; Globals.symBonnetY = txtSymBonnetY.Text; Globals.symBonnetGPIO = txtSymBonnetGPIO.Text;

            if (cmbSymBoot.Text == "N") { Globals.symBoot = "N"; }
            if (cmbSymBoot.Text == "Panel 1") { Globals.symBoot = "1"; }
            if (cmbSymBoot.Text == "Panel 2") { Globals.symBoot = "2"; }
            if (cmbSymBoot.Text == "Panel 3") { Globals.symBoot = "3"; }
            Globals.symBootX = txtSymBootX.Text; Globals.symBootY = txtSymBootY.Text; Globals.symBootGPIO = txtSymBootGPIO.Text;

            if (cmbSymBrakes.Text == "N") { Globals.symBrakes = "N"; }
            if (cmbSymBrakes.Text == "Panel 1") { Globals.symBrakes = "1"; }
            if (cmbSymBrakes.Text == "Panel 2") { Globals.symBrakes = "2"; }
            if (cmbSymBrakes.Text == "Panel 3") { Globals.symBrakes = "3"; }
            Globals.symBrakesX = txtSymBrakesX.Text; Globals.symBrakesY = txtSymBrakesY.Text; Globals.symBrakesGPIO = txtSymBrakesGPIO.Text;

            if (cmbSymDemister.Text == "N") { Globals.symDemister = "N"; }
            if (cmbSymDemister.Text == "Panel 1") { Globals.symDemister = "1"; }
            if (cmbSymDemister.Text == "Panel 2") { Globals.symDemister = "2"; }
            if (cmbSymDemister.Text == "Panel 3") { Globals.symDemister = "3"; }
            Globals.symDemisterX = txtSymDemisterX.Text; Globals.symDemisterY = txtSymDemisterY.Text; Globals.symDemisterGPIO = txtSymDemisterGPIO.Text;

            if (cmbSymDoor.Text == "N") { Globals.symDoor = "N"; }
            if (cmbSymDoor.Text == "Panel 1") { Globals.symDoor = "1"; }
            if (cmbSymDoor.Text == "Panel 2") { Globals.symDoor = "2"; }
            if (cmbSymDoor.Text == "Panel 3") { Globals.symDoor = "3"; }
            Globals.symDoorX = txtSymDoorX.Text; Globals.symDoorY = txtSymDoorY.Text; Globals.symDoorGPIO = txtSymDoorGPIO.Text;

            if (cmbSymFoglight.Text == "N") { Globals.symFoglights = "N"; }
            if (cmbSymFoglight.Text == "Panel 1") { Globals.symFoglights = "1"; }
            if (cmbSymFoglight.Text == "Panel 2") { Globals.symFoglights = "2"; }
            if (cmbSymFoglight.Text == "Panel 3") { Globals.symFoglights = "3"; }
            Globals.symFoglightsX = txtSymFoglightX.Text; Globals.symFoglightsY = txtSymFoglightY.Text; Globals.symFoglightsGPIO = txtSymFoglightGPIO.Text;

            if (cmbSymFuel.Text == "N") { Globals.symFuel = "N"; }
            if (cmbSymFuel.Text == "Panel 1") { Globals.symFuel = "1"; }
            if (cmbSymFuel.Text == "Panel 2") { Globals.symFuel = "2"; }
            if (cmbSymFuel.Text == "Panel 3") { Globals.symFuel = "3"; }
            Globals.symFuelX = txtSymFuelX.Text; Globals.symFuelY = txtSymFuelY.Text; Globals.symFuelGPIO = txtSymFuelGPIO.Text ;

            if (cmbSymFullbeam.Text == "N") { Globals.symFullbeam = "N"; }
            if (cmbSymFullbeam.Text == "Panel 1") { Globals.symFullbeam = "1"; }
            if (cmbSymFullbeam.Text == "Panel 2") { Globals.symFullbeam = "2"; }
            if (cmbSymFullbeam.Text == "Panel 3") { Globals.symFullbeam = "3"; }
            Globals.symFullbeamX = txtSymFullbeamX.Text; Globals.symFullbeamY = txtSymFullbeamY.Text; Globals.symFullbeamGPIO = txtSymFullbeamGPIO.Text;

            if (cmbSymHazards.Text == "N") { Globals.symHazards = "N"; }
            if (cmbSymHazards.Text == "Panel 1") { Globals.symHazards = "1"; }
            if (cmbSymHazards.Text == "Panel 2") { Globals.symHazards = "2"; }
            if (cmbSymHazards.Text == "Panel 3") { Globals.symHazards = "3"; }
            Globals.symHazardsX = txtSymHazardsX.Text; Globals.symHazardsY = txtSymHazardsY.Text; Globals.symHazardsGPIO = txtSymHazardsGPIO.Text;

            if (cmbSymHeadlights.Text == "N") { Globals.symHeadlights = "N"; }
            if (cmbSymHeadlights.Text == "Panel 1") { Globals.symHeadlights = "1"; }
            if (cmbSymHeadlights.Text == "Panel 2") { Globals.symHeadlights = "2"; }
            if (cmbSymHeadlights.Text == "Panel 3") { Globals.symHeadlights = "3"; }
            Globals.symHeadlightsX = txtSymHeadlightsX.Text; Globals.symHeadlightsY = txtSymHeadlightsY.Text; Globals.symHeadlightsGPIO = txtSymHeadlightsGPIO.Text;

            if (cmbSymIndLeft.Text == "N") { Globals.symIndLeft = "N"; }
            if (cmbSymIndLeft.Text == "Panel 1") { Globals.symIndLeft = "1"; }
            if (cmbSymIndLeft.Text == "Panel 2") { Globals.symIndLeft = "2"; }
            if (cmbSymIndLeft.Text == "Panel 3") { Globals.symIndLeft = "3"; }
            Globals.symIndLeftX = txtSymIndLeftX.Text; Globals.symIndLeftY = txtSymIndLeftY.Text; Globals.symIndLeftGPIO = txtSymIndLeftGPIO.Text;

            if (cmbSymIndRight.Text == "N") { Globals.symIndRight = "N"; }
            if (cmbSymIndRight.Text == "Panel 1") { Globals.symIndRight = "1"; }
            if (cmbSymIndRight.Text == "Panel 2") { Globals.symIndRight = "2"; }
            if (cmbSymIndRight.Text == "Panel 3") { Globals.symIndRight = "3"; }
            Globals.symIndRightX = txtSymIndRightX.Text; Globals.symIndRightY = txtSymIndRightY.Text; Globals.symIndRightGPIO = txtSymIndRightGPIO.Text;

            if (cmbSymOil.Text == "N") { Globals.symOil = "N"; }
            if (cmbSymOil.Text == "Panel 1") { Globals.symOil = "1"; }
            if (cmbSymOil.Text == "Panel 2") { Globals.symOil = "2"; }
            if (cmbSymOil.Text == "Panel 3") { Globals.symOil = "3"; }
            Globals.symOilX = txtSymOilX.Text; Globals.symOilY = txtSymOilY.Text; Globals.symOilGPIO = txtSymOilGPIO.Text;

            if (cmbSymSeatbelts.Text == "N") { Globals.symSeatbelt = "N"; }
            if (cmbSymSeatbelts.Text == "Panel 1") { Globals.symSeatbelt = "1"; }
            if (cmbSymSeatbelts.Text == "Panel 2") { Globals.symSeatbelt = "2"; }
            if (cmbSymSeatbelts.Text == "Panel 3") { Globals.symSeatbelt = "3"; }
            Globals.symSeatbeltX = txtSymSeatbeltsX.Text; Globals.symSeatbeltY = txtSymSeatbeltsY.Text; Globals.symSeatbeltGPIO = txtSymSeatbeltsGPIO.Text;

            if (cmbSymSeat1.Text == "N") { Globals.symSeatLeft = "N"; }
            if (cmbSymSeat1.Text == "Panel 1") { Globals.symSeatLeft = "1"; }
            if (cmbSymSeat1.Text == "Panel 2") { Globals.symSeatLeft = "2"; }
            if (cmbSymSeat1.Text == "Panel 3") { Globals.symSeatLeft = "3"; }
            Globals.symSeatLeftX = txtSymSeat1X.Text; Globals.symSeatLeftY = txtSymSeat1Y.Text; Globals.symSeatLeftGPIO = txtSymSeat1GPIO.Text;

            if (cmbSymSeat2.Text == "N") { Globals.symSeatRight = "N"; }
            if (cmbSymSeat2.Text == "Panel 1") { Globals.symSeatRight = "1"; }
            if (cmbSymSeat2.Text == "Panel 2") { Globals.symSeatRight = "2"; }
            if (cmbSymSeat2.Text == "Panel 3") { Globals.symSeatRight = "3"; }
            Globals.symSeatRightX = txtSymSeat1X.Text; Globals.symSeatRightY = txtSymSeat2Y.Text; Globals.symSeatRightGPIO = txtSymSeat2GPIO.Text;

            if (cmbSymSidelights.Text == "N") { Globals.symSidelights = "N"; }
            if (cmbSymSidelights.Text == "Panel 1") { Globals.symSidelights = "1"; }
            if (cmbSymSidelights.Text == "Panel 2") { Globals.symSidelights = "2"; }
            if (cmbSymSidelights.Text == "Panel 3") { Globals.symSidelights = "3"; }
            Globals.symSidelightsX = txtSymSidelightX.Text; Globals.symSidelightsY = txtSymSidelightY.Text; Globals.symSidelightsGPIO = txtSymSidelightGPIO.Text;

            if (cmbSymSpanner.Text == "N") { Globals.symSpanner = "N"; }
            if (cmbSymSpanner.Text == "Panel 1") { Globals.symSpanner = "1"; }
            if (cmbSymSpanner.Text == "Panel 2") { Globals.symSpanner = "2"; }
            if (cmbSymSpanner.Text == "Panel 3") { Globals.symSpanner = "3"; }
            Globals.symSpannerX = txtSymSpannerX.Text; Globals.symSpannerY = txtSymSpannerY.Text; Globals.symSpannerGPIO = txtSymSpannerGPIO.Text;

            if (cmbSymSpotlights.Text == "N") { Globals.symSpotlights = "N"; }
            if (cmbSymSpotlights.Text == "Panel 1") { Globals.symSpotlights = "1"; }
            if (cmbSymSpotlights.Text == "Panel 2") { Globals.symSpotlights = "2"; }
            if (cmbSymSpotlights.Text == "Panel 3") { Globals.symSpotlights = "3"; }
            Globals.symSpotlightsX = txtSymSpotlightX.Text; Globals.symSpotlightsY = txtSymSpotlightY.Text; Globals.symSpotlightsGPIO = txtSymSpotlightGPIO.Text;

            if (cmbSymTemp.Text == "N") { Globals.symTemp = "N"; }
            if (cmbSymTemp.Text == "Panel 1") { Globals.symTemp = "1"; }
            if (cmbSymTemp.Text == "Panel 2") { Globals.symTemp = "2"; }
            if (cmbSymTemp.Text == "Panel 3") { Globals.symTemp = "3"; }
            Globals.symTempX = txtSymTempX.Text; Globals.symTempY = txtSymTempY.Text; Globals.symTempGPIO = txtSymTempGPIO.Text;

            if (cmbSymTyre.Text == "N") { Globals.symTyre = "N"; }
            if (cmbSymTyre.Text == "Panel 1") { Globals.symTyre = "1"; }
            if (cmbSymTyre.Text == "Panel 2") { Globals.symTyre = "2"; }
            if (cmbSymTyre.Text == "Panel 3") { Globals.symTyre = "3"; }
            Globals.symTyreX = txtSymTyreX.Text; Globals.symTyreY = txtSymTyreY.Text; Globals.symTyreGPIO = txtSymTyreGPIO.Text;

            if (cmbSymWasher.Text == "N") { Globals.symWasher = "N"; }
            if (cmbSymWasher.Text == "Panel 1") { Globals.symWasher = "1"; }
            if (cmbSymWasher.Text == "Panel 2") { Globals.symWasher = "2"; }
            if (cmbSymWasher.Text == "Panel 3") { Globals.symWasher = "3"; }
            Globals.symWasherX = txtSymWasherX.Text; Globals.symWasherY = txtSymWasherY.Text; Globals.symWasherGPIO = txtSymWasherGPIO.Text;

            if (cmbSymWiperInt.Text == "N") { Globals.symWiperInt = "N"; }
            if (cmbSymWiperInt.Text == "Panel 1") { Globals.symWiperInt = "1"; }
            if (cmbSymWiperInt.Text == "Panel 2") { Globals.symWiperInt = "2"; }
            if (cmbSymWiperInt.Text == "Panel 3") { Globals.symWiperInt = "3"; }
            Globals.symWiperIntX = txtSymWiperIntX.Text; Globals.symWiperIntY = txtSymWiperIntY.Text; Globals.symWiperIntGPIO = txtSymWiperIntGPIO.Text;
        }

        private void ResetGlobals()
        {
            lblUser1.Text = "User1";
            lblUser2.Text = "User2";
            lblUser3.Text = "User3";
            lblUser4.Text = "User4";
            Globals.showP1 = "None";
            Globals.showP2 = "None";
            Globals.showP3 = "None";

            Globals.SpeedoNeedleWidth = "0"; Globals.SpeedoNeedleLength = "1200"; Globals.SpeedoNeedleX = "0"; Globals.SpeedoNeedleY = "0"; Globals.SpeedoOffset = "0"; Globals.SpeedoEnd = "0"; Globals.SpeedoTop = "0"; Globals.SpeedoTextX = "0"; Globals.SpeedoTextY = "0"; Globals.SpeedoFontSize = "0"; Globals.SpeedoTextStyle = "smooth"; Globals.SpeedoNeedle = "textures/instrument_needle.png";
            Globals.TachoNeedleWidth = "0"; Globals.TachoNeedleLength = "0"; Globals.TachoNeedleX = "0"; Globals.TachoNeedleY = "0"; Globals.TachoOffset = "0"; Globals.TachoEnd = "0"; Globals.TachoTop = "0"; Globals.TachoTextX = "0"; Globals.TachoTextY = "0"; Globals.TachoFontSize = "0"; Globals.TachoTextStyle = "smooth"; Globals.TachoNeedle = "textures/instrument_needle.png";
            Globals.BoostNeedleWidth = "0"; Globals.BoostNeedleLength = "0"; Globals.BoostNeedleX = "0"; Globals.BoostNeedleY = "0"; Globals.BoostOffset = "0"; Globals.BoostEnd = "0"; Globals.BoostTop = "0"; Globals.BoostTextX = "0"; Globals.BoostTextY = "0"; Globals.BoostFontSize = "0"; Globals.BoostTextStyle = "smooth"; Globals.BoostNeedle = "textures/instrument_needle.png";
            Globals.TempNeedleWidth = "0"; Globals.TempNeedleLength = "0"; Globals.TempNeedleX = "0"; Globals.TempNeedleY = "0"; Globals.TempOffset = "0"; Globals.TempEnd = "0"; Globals.TempTop = "0"; Globals.TempTextX = "0"; Globals.TempTextY = "0"; Globals.TempFontSize = "0"; Globals.TempTextStyle = "smooth"; Globals.TempNeedle = "textures/instrument_needle.png";
            Globals.OilNeedleWidth = "0"; Globals.OilNeedleLength = "0"; Globals.OilNeedleX = "0"; Globals.OilNeedleY = "0"; Globals.OilOffset = "0"; Globals.OilEnd = "0"; Globals.OilTop = "0"; Globals.OilTextX = "0"; Globals.OilTextY = "0"; Globals.OilFontSize = "0"; Globals.OilTextStyle = "smooth"; Globals.OilNeedle = "textures/instrument_needle.png";
            Globals.OilTNeedleWidth = "0"; Globals.OilTNeedleLength = "0"; Globals.OilTNeedleX = "0"; Globals.OilTNeedleY = "0"; Globals.OilTOffset = "0"; Globals.OilTEnd = "0"; Globals.OilTTop = "0"; Globals.OilTTextX = "0"; Globals.OilTTextY = "0"; Globals.OilTFontSize = "0"; Globals.OilTTextStyle = "smooth"; Globals.OilTNeedle = "textures/instrument_needle.png";
            Globals.FuelNeedleWidth = "0"; Globals.FuelNeedleLength = "0"; Globals.FuelNeedleX = "0"; Globals.FuelNeedleY = "0"; Globals.FuelOffset = "0"; Globals.FuelEnd = "0"; Globals.FuelTop = "0"; Globals.FuelTextX = "0"; Globals.FuelTextY = "0"; Globals.FuelFontSize = "0"; Globals.FuelTextStyle = "smooth"; Globals.FuelNeedle = "textures/instrument_needle.png";
            Globals.FuelTNeedleWidth = "0"; Globals.FuelTNeedleLength = "0"; Globals.FuelTNeedleX = "0"; Globals.FuelTNeedleY = "0"; Globals.FuelTOffset = "0"; Globals.FuelTEnd = "0"; Globals.FuelTTop = "0"; Globals.FuelTTextX = "0"; Globals.FuelTTextY = "0"; Globals.FuelTFontSize = "0"; Globals.FuelTTextStyle = "smooth"; Globals.FuelTNeedle = "textures/instrument_needle.png";
            Globals.FuelPNeedleWidth = "0"; Globals.FuelPNeedleLength = "0"; Globals.FuelPNeedleX = "0"; Globals.FuelPNeedleY = "0"; Globals.FuelPOffset = "0"; Globals.FuelPEnd = "0"; Globals.FuelPTop = "0"; Globals.FuelPTextX = "0"; Globals.FuelPTextY = "0"; Globals.FuelPFontSize = "0"; Globals.FuelPTextStyle = "smooth"; Globals.FuelPNeedle = "textures/instrument_needle.png";
            Globals.BatteryNeedleWidth = "0"; Globals.BatteryNeedleLength = "0"; Globals.BatteryNeedleX = "0"; Globals.BatteryNeedleY = "0"; Globals.BatteryOffset = "0"; Globals.BatteryEnd = "0"; Globals.BatteryTop = "0"; Globals.BatteryTextX = "0"; Globals.BatteryTextY = "0"; Globals.BatteryFontSize = "0"; Globals.BatteryTextStyle = "smooth"; Globals.BatteryNeedle = "textures/instrument_needle.png";
            Globals.User1NeedleWidth = "0"; Globals.User1NeedleLength = "0"; Globals.User1NeedleX = "0"; Globals.User1NeedleY = "0"; Globals.User1Offset = "0"; Globals.User1End = "0"; Globals.User1Top = "0"; Globals.User1TextX = "0"; Globals.User1TextY = "0"; Globals.User1FontSize = "0"; Globals.User1TextStyle = "smooth"; Globals.User1Needle = "textures/instrument_needle.png";
            Globals.User2NeedleWidth = "0"; Globals.User2NeedleLength = "0"; Globals.User2NeedleX = "0"; Globals.User2NeedleY = "0"; Globals.User2Offset = "0"; Globals.User2End = "0"; Globals.User2Top = "0"; Globals.User2TextX = "0"; Globals.User2TextY = "0"; Globals.User2FontSize = "0"; Globals.User2TextStyle = "smooth"; Globals.User2Needle = "textures/instrument_needle.png";
            Globals.User3NeedleWidth = "0"; Globals.User3NeedleLength = "0"; Globals.User3NeedleX = "0"; Globals.User3NeedleY = "0"; Globals.User3Offset = "0"; Globals.User3End = "0"; Globals.User3Top = "0"; Globals.User3TextX = "0"; Globals.User3TextY = "0"; Globals.User3FontSize = "0"; Globals.User3TextStyle = "smooth"; Globals.User3Needle = "textures/instrument_needle.png";
            Globals.User4NeedleWidth = "0"; Globals.User4NeedleLength = "0"; Globals.User4NeedleX = "0"; Globals.User4NeedleY = "0"; Globals.User4Offset = "0"; Globals.User4End = "0"; Globals.User4Top = "0"; Globals.User4TextX = "0"; Globals.User4TextY = "0"; Globals.User4FontSize = "0"; Globals.User4TextStyle = "smooth"; Globals.User4Needle = "textures/instrument_needle.png";
            Globals.SpeedoGPIO = "N"; Globals.TachoGPIO = "N"; Globals.BoostGPIO = "N"; Globals.TempGPIO = "N"; Globals.OilGPIO = "N"; Globals.OilTGPIO = "N"; Globals.FuelGPIO = "N"; Globals.FuelTGPIO = "N"; Globals.FuelPGPIO = "N"; Globals.BatteryGPIO = "N"; Globals.User1GPIO = "N"; Globals.User2GPIO = "N"; Globals.User3GPIO = "N"; Globals.User4GPIO = "N";
            Globals.symBattery = "N";Globals.symBatteryX = "0"; Globals.symBatteryY = "0"; Globals.symBatteryGPIO = "0";
            Globals.symBonnet  = "N"; Globals.symBonnetX = "0"; Globals.symBonnetY = "0"; Globals.symBonnetGPIO = "0";
            Globals.symBoot = "N"; Globals.symBootX = "0"; Globals.symBootY = "0"; Globals.symBootGPIO = "0";
            Globals.symBrakes = "N"; Globals.symBrakesX = "0"; Globals.symBrakesY = "0"; Globals.symBrakesGPIO = "0";
            Globals.symDemister = "N"; Globals.symDemisterX = "0"; Globals.symDemisterY = "0"; Globals.symDemisterGPIO = "0";
            Globals.symDoor = "N"; Globals.symDoorX = "0"; Globals.symDoorY = "0"; Globals.symDoorGPIO = "0";
            Globals.symFoglights = "N"; Globals.symFoglightsX = "0"; Globals.symFoglightsY = "0"; Globals.symFoglightsGPIO = "0";
            Globals.symFuel = "N"; Globals.symFuelX = "0"; Globals.symFuelY = "0"; Globals.symFuelGPIO = "0";
            Globals.symFullbeam = "N"; Globals.symFullbeamX = "0"; Globals.symFullbeamY = "0"; Globals.symFullbeamGPIO = "0";
            Globals.symHazards = "N"; Globals.symHazardsX = "0"; Globals.symHazardsY = "0"; Globals.symHazardsGPIO = "0";
            Globals.symHeadlights = "N"; Globals.symHeadlightsX = "0"; Globals.symHeadlightsY = "0"; Globals.symHeadlightsGPIO = "0";
            Globals.symIndLeft = "N"; Globals.symIndLeftX = "0"; Globals.symIndLeftY = "0"; Globals.symIndLeftGPIO = "0";
            Globals.symIndRight = "N"; Globals.symIndRightX = "0"; Globals.symIndRightY = "0"; Globals.symIndRightGPIO = "0";
            Globals.symOil = "N"; Globals.symOilX = "0"; Globals.symOilY = "0"; Globals.symOilGPIO = "0";
            Globals.symSeatbelt = "N"; Globals.symSeatbeltX = "0"; Globals.symSeatbeltY = "0"; Globals.symSeatbeltGPIO = "0";
            Globals.symSeatLeft = "N"; Globals.symSeatLeftX = "0"; Globals.symSeatLeftY = "0"; Globals.symSeatLeftGPIO = "0";
            Globals.symSeatRight = "N"; Globals.symSeatRightX = "0"; Globals.symSeatRightY = "0"; Globals.symSeatRightGPIO = "0";
            Globals.symSidelights = "N"; Globals.symSidelightsX = "0"; Globals.symSidelightsY = "0"; Globals.symSidelightsGPIO = "0";
            Globals.symSpanner = "N"; Globals.symSpannerX = "0"; Globals.symSpannerY = "0"; Globals.symSpannerGPIO = "0";
            Globals.symSpotlights = "N"; Globals.symSpotlightsX = "0"; Globals.symSpotlightsY = "0"; Globals.symSpotlightsGPIO = "0";
            Globals.symTemp = "N"; Globals.symTempX = "0"; Globals.symTempY = "0"; Globals.symTempGPIO = "0";
            Globals.symTyre = "N"; Globals.symTyreX = "0"; Globals.symTyreY = "0"; Globals.symTyreGPIO = "0";
            Globals.symWasher = "N"; Globals.symWasherX = "0"; Globals.symWasherY = "0"; Globals.symWasherGPIO = "0";
            Globals.symWiperInt = "N"; Globals.symWiperIntX = "0"; Globals.symWiperIntY = "0"; Globals.symWiperIntGPIO = "0";
        }

        //-----------------------------------------------------------------------show changes for gauge / bar----------------------------------------------------------------------------
        private void cmbSpeedo_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupgauges("Speedo");
        }

        private void cmbTacho_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupgauges("Tacho");
        }

        private void cmbBoost_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupgauges("Boost");
        }

        private void cmbTemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupgauges("Temp");
        }

        private void cmbOil_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupgauges("Oil");
        }

        private void cmbOilT_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupgauges("OilT");
        }

        private void cmbFuel_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupgauges("Fuel");
        }

        private void cmbFuelT_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupgauges("FuelT");
        }

        private void cmbFuelP_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupgauges("FuelP");
        }

        private void cmbBattery_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupgauges("Battery");
        }

        private void cmbUser1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            setupgauges("User1");
        }

        private void cmbUser2_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupgauges("User2");
        }

        private void cmbUser3_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupgauges("User3");
        }

        private void cmbUser4_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupgauges("User4");
        }
        //--------------------------------------------------------------ToolTips-------------------------------------------------------------------------------------------

        private void lblWarn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usage for bars. 0 means go red below %.  1 means go red above %.   Format for 'below 10%': 0,10 or for 'above 90%': 1,90");
        }

        private void label46_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Can Offset (in decimal).  See speeduino CAN references:  https://wiki.speeduino.com/en/Secondary_Serial_IO_interface");
        }

        private void lblUser1_Click(object sender, EventArgs e)
        {
            if (txtUser1.Visible == false)
            {
                txtUser1.Text = lblUser1.Text;
                txtUser1.Visible = true;
            }
            else
            {
                txtUser1.Visible = false;
            }

        }

        private void lblUser2_Click_1(object sender, EventArgs e)
        {
            if (txtUser2.Visible == false)
            {
                txtUser2.Text = lblUser2.Text;
                txtUser2.Visible = true;
            }
            else
            {
                txtUser2.Visible = false;
            }
        }

        private void lblUser3_Click_1(object sender, EventArgs e)
        {
            if (txtUser3.Visible == false)
            {
                txtUser3.Text = lblUser3.Text;
                txtUser3.Visible = true;
            }
            else
            {
                txtUser3.Visible = false;
            }

        }

        private void lblUser4_Click(object sender, EventArgs e)
        {
            if (txtUser4.Visible == false)
            {
                txtUser4.Text = lblUser4.Text;
                txtUser4.Visible = true;
            }
            else
            {
                txtUser4.Visible = false;
            }
        }

        private void txtUser1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUser1.Text != "")
                {
                    lblUser1.Text = txtUser1.Text;
                    txtUser1.Visible = false;
                }
            }

        }

        private void txtUser2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUser2.Text != "")
                {
                    lblUser2.Text = txtUser2.Text;
                    txtUser2.Visible = false;
                }
            }

        }

        private void txtUser3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUser3.Text != "")
                {
                    lblUser3.Text = txtUser3.Text;
                    txtUser3.Visible = false;
                }
            }

        }

        private void txtUser4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUser4.Text != "")
                {
                    lblUser4.Text = txtUser4.Text;
                    txtUser4.Visible = false;
                }
            }

        }

        //--------------------------------------change the serial / can listings -------------------------------------------------------------------
        private void cmbSerCanP1ECU_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbSerCanP1ECU.Text)
            {
                case "Serial3":
                    cmbSerCanP1ECUSerSpeed.Visible = true;
                    cmbSerCanP1ECUSerInter.Visible = true;
                    cmbSerCanP1ECUCanSpeed.Visible = false;
                    cmbSerCanP1ECUCanInter.Visible = false;
                    break;

                case "CAN Pcan":
                    cmbSerCanP1ECUSerSpeed.Visible = false;
                    cmbSerCanP1ECUSerInter.Visible = false;
                    cmbSerCanP1ECUCanSpeed.Visible = true;
                    cmbSerCanP1ECUCanInter.Visible = true;
                    break;

                case "CAN slcan":
                    cmbSerCanP1ECUSerSpeed.Visible = false;
                    cmbSerCanP1ECUSerInter.Visible = false;

                    cmbSerCanP1ECUCanSpeed.Visible = true;
                    cmbSerCanP1ECUCanInter.Visible = true;
                    break;

                default:
                    cmbSerCanP1ECUSerSpeed.Visible = false;
                    cmbSerCanP1ECUSerInter.Visible = false;

                    cmbSerCanP1ECUCanSpeed.Visible = true;
                    cmbSerCanP1ECUCanInter.Visible = true;
                    break;
            }
        }

        private void cmbSerCanP1P2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbSerCanP1P2.Text)
            {
                case "Serial3":
                    Globals.SerCanP1P2 = "seraial3";
                    cmbSerCanP1P2SerSpeed.Visible = true;
                    cmbSerCanP1P2SerInter.Visible = true;

                    cmbSerCanP1P2CanSpeed.Visible = false;
                    cmbSerCanP1P2CanInter.Visible = false;
                    break;

                case "Ethernet":
                    Globals.SerCanP1P2 = "ethernet";
                    cmbSerCanP1P2SerSpeed.Visible = false;
                    cmbSerCanP1P2SerInter.Visible = false;

                    cmbSerCanP1P2CanSpeed.Visible = false;
                    cmbSerCanP1P2CanInter.Visible = false;
                    break;

                case "CAN Pcan":
                    Globals.SerCanP1P2 = "pcan";
                    cmbSerCanP1P2SerSpeed.Visible = false;
                    cmbSerCanP1P2SerInter.Visible = false;

                    cmbSerCanP1P2CanSpeed.Visible = true;
                    cmbSerCanP1P2CanInter.Visible = true;
                    break;

                case "CAN slcan":
                    Globals.SerCanP1P2 = "slcan";
                    cmbSerCanP1P2SerSpeed.Visible = false;
                    cmbSerCanP1ECUSerInter.Visible = false;

                    cmbSerCanP1P2CanSpeed.Visible = true;
                    cmbSerCanP1P2CanInter.Visible = true;
                    break;

                default:
                    Globals.SerCanP1P2 = cmbSerCanP1P2.Text;
                    cmbSerCanP1P2SerSpeed.Visible = false;
                    cmbSerCanP1ECUSerInter.Visible = false;

                    cmbSerCanP1P2CanSpeed.Visible = true;
                    cmbSerCanP1P2CanInter.Visible = true;
                    break;
            }

        }

        private void cmbSerCanP1P3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbSerCanP1P3.Text)
            {
                case "Ethernet":
                    cmbSerCanP1P3CanSpeed.Visible = false;
                    cmbSerCanP1P3CanInter.Visible = false;
                    break;

                case "CAN Pcan":
                    cmbSerCanP1P3CanSpeed.Visible = true;
                    cmbSerCanP1P3CanInter.Visible = true;
                    break;

                case "CAN slcan":
                    cmbSerCanP1P3CanSpeed.Visible = true;
                    cmbSerCanP1P3CanInter.Visible = true;
                    break;

                default:
                    cmbSerCanP1P3CanSpeed.Visible = true;
                    cmbSerCanP1P3CanInter.Visible = true;
                    break;
            }

        }

        private void createSymbolVars()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(Globals.flocation + "\\Panel1.csv"))
            {
                if (Globals.isSaved1 != true)
                {
                    DialogResult dialogResult = MessageBox.Show("Panel1.csv exist.  Do you wish to overwrite?", "Save changes", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        WriteCSVfile(1);
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }
                }
            }
            if (File.Exists(Globals.flocation + "\\Panel2.csv"))
            {
                if (Globals.isSaved2 != true)
                {
                    DialogResult dialogResult = MessageBox.Show("Panel2.csv exist.  Do you wish to overwrite?", "Save changes", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        WriteCSVfile(2);
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }
                }
            }
            if (File.Exists(Globals.flocation + "\\Panel3.csv"))
            {
                if (Globals.isSaved3 != true)
                {
                    DialogResult dialogResult = MessageBox.Show("Panel3.csv exist.  Do you wish to overwrite?", "Save changes", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        WriteCSVfile(3);
                        this.Close();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }
                }
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {
            frmPi frmpi = new frmPi();

            // Show the settings form
            frmpi.Show();
        }
    }
}