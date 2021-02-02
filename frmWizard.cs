using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

//to call other class functions: 
using static dashconfigurator.WriteCSV;
using static dashconfigurator.ReadCSV;
using static dashconfigurator.CSVTools;


namespace dashconfigurator
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
            TS1.Text  = ("Ready    ");
            TS2.Text  = ("Ready    ");
            TS3.Text  = ("Ready    ");
        }


        //====================================================================READ SECTION================================================================

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------Open file(s) and load all data---------------------------------------------------------------
            ReadTheCSV(1);   //populate panel 1 global configs
            ReadTheCSV(2);   //populate panel 2 global configs
            ReadTheCSV(3);   //populate panel 3 global configs

            //poplulate the config page

        }















        //=======================================================================WRITE SECTION============================================================================

        private void btnNext_Click(object sender, EventArgs e)
        {
            //-----------------------------------------------------------save all fields------------------------------------------------------------------
            resolveToVars();

            calcGauges("speedo", "n");

            WriteCSVfile(1);  // write csv panel1
            WriteCSVfile(2);  // write csv panel2 
            WriteCSVfile(3);  // write csv panel3

        }





















        //--------------------------------------change the serial / can listings -------------------------------------------------------------------
        private void cmbComms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSerCanP1P2.Text == "Serial3")
            {
                cmbSerCanP1P2SerSpeed.Visible = true;
                cmbSerCanP1P2CanSpeed.Visible = false;
                cmbSerCanP1P2CanInter.Visible = false;
            }
            else
            {
                cmbSerCanP1P2SerSpeed.Visible = false;
                cmbSerCanP1P2CanSpeed.Visible = true;
                cmbSerCanP1P2CanInter.Visible = true;
            }
        }






        //--------------------------------------------------------------------------------Guage / barV / BarH -------------------------------------------------------------------------------------
        private void setupgauges(string gaugechoice)
        {
            switch (gaugechoice)
            {
                case "Speedo":
                    if (cmbSpeedo.Text.ToLower() == "gauge")
                    {
                        lblWarn.Visible = false;
                        txtSpeedoNeedle.Text = "textures/instrument_needle.png";
                        Globals.SpeedoNeedle = txtSpeedoNeedle.Text;
                        Globals.SpeedoNeedleType = "gauge";

                    }

                    if (cmbSpeedo.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtSpeedoNeedle.Text = "0=10";
                        Globals.SpeedoNeedle = txtSpeedoNeedle.Text;
                        Globals.SpeedoNeedleType = "barV";
                    }
                    if (cmbSpeedo.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtSpeedoNeedle.Text = "0=10";
                        Globals.SpeedoNeedle = txtSpeedoNeedle.Text;
                        Globals.SpeedoNeedleType = "barH";
                    }
                    break;

                case "Tacho":
                    if (cmbTacho.Text.ToLower() == "gauge")
                    {
                        lblWarn.Visible = false;
                        txtTachoNeedle.Text = "textures/instrument_needle.png";
                        Globals.TachoNeedle = txtTachoNeedle.Text;
                        Globals.TachoNeedleType = "gauge";

                    }

                    if (cmbTacho.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtTachoNeedle.Text = "0=10";
                        Globals.TachoNeedle = txtTachoNeedle.Text;
                        Globals.TachoNeedleType = "barV";
                    }
                    if (cmbTacho.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtTachoNeedle.Text = "0=10";
                        Globals.TachoNeedle = txtTachoNeedle.Text;
                        Globals.TachoNeedleType = "barH";
                    }
                    break;

                case "Boost":
                    if (cmbBoost.Text.ToLower() == "gauge")
                    {
                        lblWarn.Visible = false;
                        txtBoostNeedle.Text = "textures/instrument_needle.png";
                        Globals.BoostNeedle = txtBoostNeedle.Text;
                        Globals.BoostNeedleType = "gauge";

                    }

                    if (cmbBoost.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtBoostNeedle.Text = "0=10";
                        Globals.BoostNeedle = txtBoostNeedle.Text;
                        Globals.BoostNeedleType = "barV";
                    }
                    if (cmbBoost.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtBoostNeedle.Text = "0=10";
                        Globals.BoostNeedle = txtBoostNeedle.Text;
                        Globals.BoostNeedleType = "barH";
                    }
                    break;

                case "Oil":
                    if (cmbOil.Text.ToLower() == "gauge")
                    {
                        lblWarn.Visible = false;
                        txtOilNeedle.Text = "textures/instrument_needle.png";
                        Globals.OilNeedle = txtOilNeedle.Text;
                        Globals.OilNeedleType = "gauge";

                    }

                    if (cmbOil.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtOilNeedle.Text = "0=10";
                        Globals.OilNeedle = txtOilNeedle.Text;
                        Globals.OilNeedleType = "barV";
                    }
                    if (cmbOil.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtOilNeedle.Text = "0=10";
                        Globals.OilNeedle = txtOilNeedle.Text;
                        Globals.OilNeedleType = "barH";
                    }
                    break;


                case "OilT":
                    if (cmbOilT.Text.ToLower() == "gauge")
                    {
                        lblWarn.Visible = false;
                        txtOilTNeedle.Text = "textures/instrument_needle.png";
                        Globals.OilTNeedle = txtOilTNeedle.Text;
                        Globals.OilTNeedleType = "gauge";

                    }

                    if (cmbOilT.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtOilTNeedle.Text = "0=10";
                        Globals.OilTNeedle = txtOilTNeedle.Text;
                        Globals.OilTNeedleType = "barV";
                    }
                    if (cmbOilT.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtOilTNeedle.Text = "0=10";
                        Globals.OilTNeedle = txtOilTNeedle.Text;
                        Globals.OilTNeedleType = "barH";
                    }
                    break;

                case "Fuel":
                    if (cmbFuel.Text.ToLower() == "gauge")
                    {
                        lblWarn.Visible = false;
                        txtFuelNeedle.Text = "textures/instrument_needle.png";
                        Globals.FuelNeedle = txtFuelNeedle.Text;
                        Globals.FuelNeedleType = "gauge";

                    }

                    if (cmbFuel.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtFuelNeedle.Text = "0=10";
                        Globals.FuelNeedle = txtFuelNeedle.Text;
                        Globals.FuelNeedleType = "barV";
                    }
                    if (cmbFuel.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtFuelNeedle.Text = "0=10";
                        Globals.FuelNeedle = txtFuelNeedle.Text;
                        Globals.FuelNeedleType = "barH";
                    }
                    break;

                case "FuelT":
                    if (cmbFuelT.Text.ToLower() == "gauge")
                    {
                        lblWarn.Visible = false;
                        txtFuelTNeedle.Text = "textures/instrument_needle.png";
                        Globals.FuelTNeedle = txtFuelTNeedle.Text;
                        Globals.FuelTNeedleType = "gauge";

                    }

                    if (cmbFuelT.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtFuelTNeedle.Text = "0=10";
                        Globals.FuelTNeedle = txtFuelTNeedle.Text;
                        Globals.FuelTNeedleType = "barV";
                    }
                    if (cmbFuelT.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtFuelTNeedle.Text = "0=10";
                        Globals.FuelTNeedle = txtFuelTNeedle.Text;
                        Globals.FuelTNeedleType = "barH";
                    }
                    break;

                case "FuelP":
                    if (cmbFuelP.Text.ToLower() == "gauge")
                    {
                        lblWarn.Visible = false;
                        txtFuelPNeedle.Text = "textures/instrument_needle.png";
                        Globals.FuelPNeedle = txtFuelPNeedle.Text;
                        Globals.FuelPNeedleType = "gauge";

                    }

                    if (cmbFuelP.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtFuelPNeedle.Text = "0=10";
                        Globals.FuelPNeedle = txtFuelPNeedle.Text;
                        Globals.FuelPNeedleType = "barV";
                    }
                    if (cmbFuelP.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtFuelPNeedle.Text = "0=10";
                        Globals.FuelPNeedle = txtFuelPNeedle.Text;
                        Globals.FuelPNeedleType = "barH";
                    }
                    break;

                case "User1":
                    if (cmbUser1.Text.ToLower() == "gauge")
                    {
                        lblWarn.Visible = false;
                        txtUser1Needle.Text = "textures/instrument_needle.png";
                        Globals.User1Needle = txtUser1Needle.Text;
                        Globals.User1NeedleType = "gauge";

                    }

                    if (cmbUser1.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser1Needle.Text = "0=10";
                        Globals.User1Needle = txtUser1Needle.Text;
                        Globals.User1NeedleType = "barV";
                    }
                    if (cmbUser1.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser1Needle.Text = "0=10";
                        Globals.User1Needle = txtUser1Needle.Text;
                        Globals.User1NeedleType = "barH";
                    }
                    break;

                case "User2":
                    if (cmbUser2.Text.ToLower() == "gauge")
                    {
                        lblWarn.Visible = false;
                        txtUser2Needle.Text = "textures/instrument_needle.png";
                        Globals.User2Needle = txtUser2Needle.Text;
                        Globals.User2NeedleType = "gauge";

                    }

                    if (cmbUser2.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser2Needle.Text = "0=10";
                        Globals.User2Needle = txtUser2Needle.Text;
                        Globals.User2NeedleType = "barV";
                    }
                    if (cmbUser2.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser2Needle.Text = "0=10";
                        Globals.User2Needle = txtUser2Needle.Text;
                        Globals.User2NeedleType = "barH";
                    }
                    break;

                case "User3":
                    if (cmbUser3.Text.ToLower() == "gauge")
                    {
                        lblWarn.Visible = false;
                        txtUser3Needle.Text = "textures/instrument_needle.png";
                        Globals.User3Needle = txtUser3Needle.Text;
                        Globals.User3NeedleType = "gauge";

                    }

                    if (cmbUser3.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser3Needle.Text = "0=10";
                        Globals.User3Needle = txtUser3Needle.Text;
                        Globals.User3NeedleType = "barV";
                    }
                    if (cmbUser3.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser3Needle.Text = "0=10";
                        Globals.User3Needle = txtUser3Needle.Text;
                        Globals.User3NeedleType = "barH";
                    }
                    break;

                case "User4":
                    if (cmbUser4.Text.ToLower() == "gauge")
                    {
                        lblWarn.Visible = false;
                        txtUser4Needle.Text = "textures/instrument_needle.png";
                        Globals.User4Needle = txtUser4Needle.Text;
                        Globals.User4NeedleType = "gauge";

                    }

                    if (cmbUser4.Text == "Vertical Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser4Needle.Text = "0=10";
                        Globals.User4Needle = txtUser4Needle.Text;
                        Globals.User4NeedleType = "barV";
                    }
                    if (cmbUser4.Text == "Horizontal Bar")
                    {
                        lblWarn.Visible = true;
                        txtUser4Needle.Text = "0=10";
                        Globals.User4Needle = txtUser4Needle.Text;
                        Globals.User4NeedleType = "barH";
                    }
                    break;



            }
        }

        //------------------------------------------------------------------------------






        private void popScreen()
        {
            if ((Globals.SpeedoTextShow1.ToLower() == "n") && (Globals.SpeedoTextShow2.ToLower() == "n"))
            {
                Globals.SpeedoTextX = "0";
                Globals.SpeedoTextY = "0";
                Globals.SpeedoFontSize = "36";
                Globals.SpeedoTextStyle = "smooth";
                cmbSpeedoTextShow.Text = "N";
            }
            if ((Globals.SpeedoTextShow1.ToLower() == "y") && (Globals.SpeedoTextShow2.ToLower() == "n"))
            {
                //Panel 1
                cmbSpeedoTextShow.Text = "Panel 1";
            }
            if ((Globals.SpeedoTextShow1.ToLower() == "n") && (Globals.SpeedoTextShow2.ToLower() == "y"))
            {
                //Panel 2
                cmbSpeedoTextShow.Text = "Panel 2";
            }

            cmbSpeedoTextStyle.Text = Globals.SpeedoTextStyle;
            txtSpeedoTextX.Text = Globals.SpeedoTextX;
            txtSpeedoTextY.Text = Globals.SpeedoTextY;
            txtSpeedoFontSize.Text = Globals.SpeedoFontSize;

            if ((Globals.SpeedoShow1.ToLower() == "n") && (Globals.SpeedoShow2.ToLower() == "n"))
            {
                Globals.SpeedoNeedleWidth = "50";
                Globals.SpeedoNeedleLength = "1200";
                Globals.SpeedoNeedleX = "0";
                Globals.SpeedoNeedleY = "0";
                Globals.SpeedoOffset = "0";
                Globals.SpeedoEnd = "0";
                Globals.SpeedoTop = "0";
                Globals.SpeedoNeedleType = "Gauge";
                Globals.SpeedoNeedle = "textures/instrument_needle.png";
                cmbShowSpeedo.Text = "n";
            }

            if ((Globals.SpeedoShow1.ToLower() == "y") && (Globals.SpeedoShow2.ToLower() == "n"))
            {
                cmbShowSpeedo.Text = "Panel 1";
            }
            if ((Globals.SpeedoShow1.ToLower() == "n") && (Globals.SpeedoShow2.ToLower() == "y"))
            {
                cmbShowSpeedo.Text = "Panel 2";
            }

            txtSpeedoNeedleWidth.Text = Globals.SpeedoNeedleWidth;
            txtSpeedoNeedleLength.Text = Globals.SpeedoNeedleLength;
            txtSpeedoNeedleX.Text = Globals.SpeedoNeedleX;
            txtSpeedoNeedleY.Text = Globals.SpeedoNeedleY;
            txtSpeedoOffset.Text = Globals.SpeedoOffset;
            txtSpeedoEnd.Text = Globals.SpeedoEnd;
            txtSpeedoTop.Text = Globals.SpeedoTop;
            cmbSpeedo.Text = Globals.SpeedoNeedleType;
            txtSpeedoNeedle.Text = Globals.SpeedoNeedle;

        }





        private void txtUser3_TextChanged(object sender, EventArgs e)
        {
            if (txtUser3.Text != "")
            {
                lblUser3.Text = txtUser1.Text;
            }
        }

        private void lblUser4_Click(object sender, EventArgs e)
        {
            if (txtUser4.Visible == false)
            {
                txtUser4.Visible = true;
            }
            else
            {
                txtUser4.Visible = false;
            }
        }

        private void txtUser4_TextChanged(object sender, EventArgs e)
        {
            if (txtUser4.Text != "")
            {
                lblUser4.Text = txtUser1.Text;
            }
        }

        private void txtUser1_MouseClick(object sender, MouseEventArgs e)
        {
            txtUser1.Visible = false;
        }
        private void txtUser2_MouseClick(object sender, MouseEventArgs e)
        {
            txtUser2.Visible = false;
        }
        private void txtUser3_MouseClick(object sender, MouseEventArgs e)
        {
            txtUser3.Visible = false;
        }
        private void txtUser4_MouseClick(object sender, MouseEventArgs e)
        {
            txtUser4.Visible = false;
        }


        //-----------------------------------------------------------------------------Backgrounds-----------------------------------------------------------------------------------------
        private void btnP1BG_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Picture files All files (*.*)|*.*|(*.gif)|*.gif|(*.bmp)|*.bmp|(*.jpg)|*.jpg";
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
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Picture files All files (*.*)|*.*|(*.gif)|*.gif|(*.bmp)|*.bmp|(*.jpg)|*.jpg";
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
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Picture files All files (*.*)|*.*|(*.gif)|*.gif|(*.bmp)|*.bmp|(*.jpg)|*.jpg";
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
        private void resolveToVars()
        {
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
        }

        //-------------------------------------------------------------------------------get textboxes from variables ----------------------------------------------------------------------------------
        private void resolveFromVars()
        {
            txtSpeedoNeedleWidth.Text = Globals.SpeedoNeedleWidth;
            txtSpeedoNeedleLength.Text = Globals.SpeedoNeedleLength;
            txtSpeedoNeedleX.Text = Globals.SpeedoNeedleX;
            txtSpeedoNeedleY.Text = Globals.SpeedoNeedleY;
            txtSpeedoOffset.Text = Globals.SpeedoOffset;
            txtSpeedoEnd.Text = Globals.SpeedoEnd;
            txtSpeedoTop.Text = Globals.SpeedoTop;
            txtSpeedoTextX.Text = Globals.SpeedoTextX;
            txtSpeedoTextY.Text = Globals.SpeedoTextY;
            txtSpeedoFontSize.Text = Globals.SpeedoFontSize;
            cmbSpeedoTextStyle.Text = Globals.SpeedoTextStyle;
            txtSpeedoNeedle.Text = Globals.SpeedoNeedle;

            txtTachoNeedleWidth.Text = Globals.TachoNeedleWidth;
            txtTachoNeedleLength.Text = Globals.TachoNeedleLength;
            txtTachoNeedleX.Text = Globals.TachoNeedleX;
            txtTachoNeedleY.Text = Globals.TachoNeedleY;
            txtTachoOffset.Text = Globals.TachoOffset;
            txtTachoEnd.Text = Globals.TachoEnd;
            txtTachoTop.Text = Globals.TachoTop;
            txtTachoTextX.Text = Globals.TachoTextX;
            txtTachoTextY.Text = Globals.TachoTextY;
            txtTachoFontSize.Text = Globals.TachoFontSize;
            cmbTachoTextStyle.Text = Globals.TachoTextStyle;
            txtTachoNeedle.Text = Globals.TachoNeedle;

            txtBoostNeedleWidth.Text = Globals.BoostNeedleWidth;
            txtBoostNeedleLength.Text = Globals.BoostNeedleLength;
            txtBoostNeedleX.Text = Globals.BoostNeedleX;
            txtBoostNeedleY.Text = Globals.BoostNeedleY;
            txtBoostOffset.Text = Globals.BoostOffset;
            txtBoostEnd.Text = Globals.BoostEnd;
            txtBoostTop.Text = Globals.BoostTop;
            txtBoostTextX.Text = Globals.BoostTextX;
            txtBoostTextY.Text = Globals.BoostTextY;
            txtBoostFontSize.Text = Globals.BoostFontSize;
            cmbBoostTextStyle.Text = Globals.BoostTextStyle;
            txtBoostNeedle.Text = Globals.BoostNeedle;

            txtTempNeedleWidth.Text = Globals.TempNeedleWidth;
            txtTempNeedleLength.Text = Globals.TempNeedleLength;
            txtTempNeedleX.Text = Globals.TempNeedleX;
            txtTempNeedleY.Text = Globals.TempNeedleY;
            txtTempOffset.Text = Globals.TempOffset;
            txtTempEnd.Text = Globals.TempEnd;
            txtTempTop.Text = Globals.TempTop;
            txtTempTextX.Text = Globals.TempTextX;
            txtTempTextY.Text = Globals.TempTextY;
            txtTempFontSize.Text = Globals.TempFontSize;
            cmbTempTextStyle.Text = Globals.TempTextStyle;
            txtTempNeedle.Text = Globals.TempNeedle;

            txtOilNeedleWidth.Text = Globals.OilNeedleWidth;
            txtOilNeedleLength.Text = Globals.OilNeedleLength;
            txtOilNeedleX.Text = Globals.OilNeedleX;
            txtOilNeedleY.Text = Globals.OilNeedleY;
            txtOilOffset.Text = Globals.OilOffset;
            txtOilEnd.Text = Globals.OilEnd;
            txtOilTop.Text = Globals.OilTop;
            txtOilTextX.Text = Globals.OilTextX;
            txtOilTextY.Text = Globals.OilTextY;
            txtOilFontSize.Text = Globals.OilFontSize;
            cmbOilTextStyle.Text = Globals.OilTextStyle;
            txtOilNeedle.Text = Globals.OilNeedle;

            txtOilTNeedleWidth.Text = Globals.OilTNeedleWidth;
            txtOilTNeedleLength.Text = Globals.OilTNeedleLength;
            txtOilTNeedleX.Text = Globals.OilTNeedleX;
            txtOilTNeedleY.Text = Globals.OilTNeedleY;
            txtOilTOffset.Text = Globals.OilTOffset;
            txtOilTEnd.Text = Globals.OilTEnd;
            txtOilTTop.Text = Globals.OilTTop;
            txtOilTTextX.Text = Globals.OilTTextX;
            txtOilTTextY.Text = Globals.OilTTextY;
            txtOilTFontSize.Text = Globals.OilTFontSize;
            cmbOilTTextStyle.Text = Globals.OilTTextStyle;
            txtOilTNeedle.Text = Globals.OilTNeedle;

            txtFuelNeedleWidth.Text = Globals.FuelNeedleWidth;
            txtFuelNeedleLength.Text = Globals.FuelNeedleLength;
            txtFuelNeedleX.Text = Globals.FuelNeedleX;
            txtFuelNeedleY.Text = Globals.FuelNeedleY;
            txtFuelOffset.Text = Globals.FuelOffset;
            txtFuelEnd.Text = Globals.FuelEnd;
            txtFuelTop.Text = Globals.FuelTop;
            txtFuelTextX.Text = Globals.FuelTextX;
            txtFuelTextY.Text = Globals.FuelTextY;
            txtFuelFontSize.Text = Globals.FuelFontSize;
            cmbFuelTextStyle.Text = Globals.FuelTextStyle;
            txtFuelNeedle.Text = Globals.FuelNeedle;

            txtFuelTNeedleWidth.Text = Globals.FuelTNeedleWidth;
            txtFuelTNeedleLength.Text = Globals.FuelTNeedleLength;
            txtFuelTNeedleX.Text = Globals.FuelTNeedleX;
            txtFuelTNeedleY.Text = Globals.FuelTNeedleY;
            txtFuelTOffset.Text = Globals.FuelTOffset;
            txtFuelTEnd.Text = Globals.FuelTEnd;
            txtFuelTTop.Text = Globals.FuelTTop;
            txtFuelTTextX.Text = Globals.FuelTTextX;
            txtFuelTTextY.Text = Globals.FuelTTextY;
            txtFuelTFontSize.Text = Globals.FuelTFontSize;
            cmbFuelTTextStyle.Text = Globals.FuelTTextStyle;
            txtFuelTNeedle.Text = Globals.FuelTNeedle;

            txtFuelPNeedleWidth.Text = Globals.FuelPNeedleWidth;
            txtFuelPNeedleLength.Text = Globals.FuelPNeedleLength;
            txtFuelPNeedleX.Text = Globals.FuelPNeedleX;
            txtFuelPNeedleY.Text = Globals.FuelPNeedleY;
            txtFuelPOffset.Text = Globals.FuelPOffset;
            txtFuelPEnd.Text = Globals.FuelPEnd;
            txtFuelPTop.Text = Globals.FuelPTop;
            txtFuelPTextX.Text = Globals.FuelPTextX;
            txtFuelPTextY.Text = Globals.FuelPTextY;
            txtFuelPFontSize.Text = Globals.FuelPFontSize;
            cmbFuelPTextStyle.Text = Globals.FuelPTextStyle;
            txtFuelPNeedle.Text = Globals.FuelPNeedle;

            txtUser1NeedleWidth.Text = Globals.User1NeedleWidth;
            txtUser1NeedleLength.Text = Globals.User1NeedleLength;
            txtUser1NeedleX.Text = Globals.User1NeedleX;
            txtUser1NeedleY.Text = Globals.User1NeedleY;
            txtUser1Offset.Text = Globals.User1Offset;
            txtUser1End.Text = Globals.User1End;
            txtUser1Top.Text = Globals.User1Top;
            txtUser1TextX.Text = Globals.User1TextX;
            txtUser1TextY.Text = Globals.User1TextY;
            txtUser1FontSize.Text = Globals.User1FontSize;
            cmbUser1TextStyle.Text = Globals.User1TextStyle;
            txtUser1Needle.Text = Globals.User1Needle;

            txtUser2NeedleWidth.Text = Globals.User2NeedleWidth;
            txtUser2NeedleLength.Text = Globals.User2NeedleLength;
            txtUser2NeedleX.Text = Globals.User2NeedleX;
            txtUser2NeedleY.Text = Globals.User2NeedleY;
            txtUser2Offset.Text = Globals.User2Offset;
            txtUser2End.Text = Globals.User2End;
            txtUser2Top.Text = Globals.User2Top;
            txtUser2TextX.Text = Globals.User2TextX;
            txtUser2TextY.Text = Globals.User2TextY;
            txtUser2FontSize.Text = Globals.User2FontSize;
            cmbUser2TextStyle.Text = Globals.User2TextStyle;
            txtUser2Needle.Text = Globals.User2Needle;

            txtUser3NeedleWidth.Text = Globals.User3NeedleWidth;
            txtUser3NeedleLength.Text = Globals.User3NeedleLength;
            txtUser3NeedleX.Text = Globals.User3NeedleX;
            txtUser3NeedleY.Text = Globals.User3NeedleY;
            txtUser3Offset.Text = Globals.User3Offset;
            txtUser3End.Text = Globals.User3End;
            txtUser3Top.Text = Globals.User3Top;
            txtUser3TextX.Text = Globals.User3TextX;
            txtUser3TextY.Text = Globals.User3TextY;
            txtUser3FontSize.Text = Globals.User3FontSize;
            cmbUser3TextStyle.Text = Globals.User3TextStyle;
            txtUser3Needle.Text = Globals.User3Needle;

            txtUser4NeedleWidth.Text = Globals.User4NeedleWidth;
            txtUser4NeedleLength.Text = Globals.User4NeedleLength;
            txtUser4NeedleX.Text = Globals.User4NeedleX;
            txtUser4NeedleY.Text = Globals.User4NeedleY;
            txtUser4Offset.Text = Globals.User4Offset;
            txtUser4End.Text = Globals.User4End;
            txtUser4Top.Text = Globals.User4Top;
            txtUser4TextX.Text = Globals.User4TextX;
            txtUser4TextY.Text = Globals.User4TextY;
            txtUser4FontSize.Text = Globals.User4FontSize;
            cmbUser4TextStyle.Text = Globals.User4TextStyle;
            txtUser4Needle.Text = Globals.User4Needle;

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

        private void cmbUser1_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}