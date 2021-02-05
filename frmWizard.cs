﻿using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

//to call other class functions: 
using static kkdash.WriteCSV;
using static kkdash.ReadCSV;
using static kkdash.CSVTools;


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
            TS1.Text = ("Ready    ");
            TS2.Text = ("Ready    ");
            TS3.Text = ("Ready    ");
        }


        //====================================================================READ SECTION================================================================

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------Open file(s) and load all data---------------------------------------------------------------
            ResetGlobals();

            ReadTheCSV(1);   //populate panel 1 global configs
            ReadTheCSV(2);   //populate panel 2 global configs
            ReadTheCSV(3);   //populate panel 3 global configs

            //poplulate the config page
            resolveFromVars();
        }








        //=======================================================================SAVE SECTION============================================================================

        private void btnNext_Click(object sender, EventArgs e)
        {
            ResetGlobals();

            //-----------------------------------------------------------save all fields------------------------------------------------------------------
            resolveToVars(); //this takes all text except which panel indicators to global vars
            resolvePanelToVars(); //this takes the panel number to global vars

            WriteCSVfile(1);  // write csv panel1 from globals
            WriteCSVfile(2);  // write csv panel2 from globals
            WriteCSVfile(3);  // write csv panel3 from globals

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
                    if (cmbTemp.Text.ToLower() == "gauge")
                    {
                        lblWarn.Visible = false;
                        txtTempNeedle.Text = "textures/instrument_needle.png";
                        Globals.TempNeedle = txtTempNeedle.Text;
                        Globals.TempNeedleType = "gauge";

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

        private void resolvePanelToVars()
        {
            //Speedo
            Globals.gaugename = ""; Globals.SpeedoShow = "n"; Globals.SpeedoTextShow = "n";  //reset to no values
            if (cmbShowSpeedo.Text == "N") { Globals.SpeedoShow = "n"; }
            if (cmbSpeedoTextShow.Text == "N") { Globals.SpeedoTextShow = "n"; }
            if (cmbShowSpeedo.Text == "Panel 1") { Globals.SpeedoShow = "1"; }
            if (cmbSpeedoTextShow.Text == "Panel 1")  { Globals.SpeedoTextShow = "1"; }
            if (cmbShowSpeedo.Text == "Panel 2") { Globals.SpeedoShow = "2"; }
            if (cmbSpeedoTextShow.Text == "Panel 2") { Globals.SpeedoTextShow = "2"; }
            if (cmbShowSpeedo.Text == "Panel 3") { Globals.SpeedoShow = "3"; }
            if (cmbSpeedoTextShow.Text == "Panel 3") { Globals.SpeedoTextShow = "3"; }

            if ((Globals.SpeedoShow == "1") || (Globals.SpeedoTextShow == "1"))
            {
                Globals.gaugename = "speedo";
                if ((Globals.SpeedoShow == "1") && (Globals.SpeedoTextShow != "1"))
                {
                    Globals.Speedovalp1 = Globals.gaugename + "," + Globals.SpeedoShow + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + "n" + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle;
                }
                if ((Globals.SpeedoShow != "1") && (Globals.SpeedoTextShow == "1"))
                {
                    Globals.Speedovalp1 = Globals.gaugename + "," + "n" + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow  + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle;
                }
            }
            if ((Globals.SpeedoShow == "2") || (Globals.SpeedoTextShow == "2"))
            {
                Globals.gaugename = "speedo";
                if ((Globals.SpeedoShow == "2") && (Globals.SpeedoTextShow != "2"))
                {
                    Globals.Speedovalp2 = Globals.gaugename + "," + Globals.SpeedoShow + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + "n" + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle;
                }
                if ((Globals.SpeedoShow != "2") && (Globals.SpeedoTextShow == "2"))
                {
                    Globals.Speedovalp2 = Globals.gaugename + "," + "n" + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle;
                }
            }
            if ((Globals.SpeedoShow == "3") || (Globals.SpeedoTextShow == "3"))
            {
                Globals.gaugename = "speedo";
                if ((Globals.SpeedoShow == "3") && (Globals.SpeedoTextShow != "3"))
                {
                    Globals.Speedovalp3 = Globals.gaugename + "," + Globals.SpeedoShow + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + "n" + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle;
                }
                if ((Globals.SpeedoShow != "3") && (Globals.SpeedoTextShow == "3"))
                {
                    Globals.Speedovalp3 = Globals.gaugename + "," + "n" + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle;
                }
            }

            //Tacho
            Globals.gaugename = ""; Globals.TachoShow = "n"; Globals.TachoTextShow = "n";  //reset to no values
            if (cmbShowTacho.Text == "N") { Globals.TachoShow = "n"; }
            if (cmbTachoTextShow.Text == "N") { Globals.TachoTextShow = "n"; }
            if (cmbShowTacho.Text == "Panel 1") { Globals.TachoShow = "1"; }
            if (cmbTachoTextShow.Text == "Panel 1") { Globals.TachoTextShow = "1"; }
            if (cmbShowTacho.Text == "Panel 2") { Globals.TachoShow = "2"; }
            if (cmbTachoTextShow.Text == "Panel 2") { Globals.TachoTextShow = "2"; }
            if (cmbShowTacho.Text == "Panel 3") { Globals.TachoShow = "3"; }
            if (cmbTachoTextShow.Text == "Panel 3") { Globals.TachoTextShow = "3"; }

            if ((Globals.TachoShow == "1") || (Globals.TachoTextShow == "1"))
            {
                Globals.gaugename = "Tacho";
                if ((Globals.TachoShow == "1") && (Globals.TachoTextShow != "1"))
                {
                    Globals.Tachovalp1 = Globals.gaugename + "," + Globals.TachoShow + "," + Globals.TachoNeedleWidth + "," + Globals.TachoNeedleLength + "," + Globals.TachoNeedleX + "," + Globals.TachoNeedleY + "," + Globals.TachoOffset + "," + Globals.TachoEnd + "," + Globals.TachoTop + "," + "n" + "," + Globals.TachoTextX + "," + Globals.TachoTextY + "," + Globals.TachoFontSize + "," + Globals.TachoTextStyle + "," + Globals.TachoNeedleType + "," + Globals.TachoNeedle;
                }
                if ((Globals.TachoShow != "1") && (Globals.TachoTextShow == "1"))
                {
                    Globals.Tachovalp1 = Globals.gaugename + "," + "n" + "," + Globals.TachoNeedleWidth + "," + Globals.TachoNeedleLength + "," + Globals.TachoNeedleX + "," + Globals.TachoNeedleY + "," + Globals.TachoOffset + "," + Globals.TachoEnd + "," + Globals.TachoTop + "," + Globals.TachoTextShow + "," + Globals.TachoTextX + "," + Globals.TachoTextY + "," + Globals.TachoFontSize + "," + Globals.TachoTextStyle + "," + Globals.TachoNeedleType + "," + Globals.TachoNeedle;
                }
            }
            if ((Globals.TachoShow == "2") || (Globals.TachoTextShow == "2"))
            {
                Globals.gaugename = "Tacho";
                if ((Globals.TachoShow == "2") && (Globals.TachoTextShow != "2"))
                {
                    Globals.Tachovalp2 = Globals.gaugename + "," + Globals.TachoShow + "," + Globals.TachoNeedleWidth + "," + Globals.TachoNeedleLength + "," + Globals.TachoNeedleX + "," + Globals.TachoNeedleY + "," + Globals.TachoOffset + "," + Globals.TachoEnd + "," + Globals.TachoTop + "," + "n" + "," + Globals.TachoTextX + "," + Globals.TachoTextY + "," + Globals.TachoFontSize + "," + Globals.TachoTextStyle + "," + Globals.TachoNeedleType + "," + Globals.TachoNeedle;
                }
                if ((Globals.TachoShow != "2") && (Globals.TachoTextShow == "2"))
                {
                    Globals.Tachovalp2 = Globals.gaugename + "," + "n" + "," + Globals.TachoNeedleWidth + "," + Globals.TachoNeedleLength + "," + Globals.TachoNeedleX + "," + Globals.TachoNeedleY + "," + Globals.TachoOffset + "," + Globals.TachoEnd + "," + Globals.TachoTop + "," + Globals.TachoTextShow + "," + Globals.TachoTextX + "," + Globals.TachoTextY + "," + Globals.TachoFontSize + "," + Globals.TachoTextStyle + "," + Globals.TachoNeedleType + "," + Globals.TachoNeedle;
                }
            }
            if ((Globals.TachoShow == "3") || (Globals.TachoTextShow == "3"))
            {
                Globals.gaugename = "Tacho";
                if ((Globals.TachoShow == "3") && (Globals.TachoTextShow != "3"))
                {
                    Globals.Tachovalp3 = Globals.gaugename + "," + Globals.TachoShow + "," + Globals.TachoNeedleWidth + "," + Globals.TachoNeedleLength + "," + Globals.TachoNeedleX + "," + Globals.TachoNeedleY + "," + Globals.TachoOffset + "," + Globals.TachoEnd + "," + Globals.TachoTop + "," + "n" + "," + Globals.TachoTextX + "," + Globals.TachoTextY + "," + Globals.TachoFontSize + "," + Globals.TachoTextStyle + "," + Globals.TachoNeedleType + "," + Globals.TachoNeedle;
                }
                if ((Globals.TachoShow != "3") && (Globals.TachoTextShow == "3"))
                {
                    Globals.Tachovalp3 = Globals.gaugename + "," + "n" + "," + Globals.TachoNeedleWidth + "," + Globals.TachoNeedleLength + "," + Globals.TachoNeedleX + "," + Globals.TachoNeedleY + "," + Globals.TachoOffset + "," + Globals.TachoEnd + "," + Globals.TachoTop + "," + Globals.TachoTextShow + "," + Globals.TachoTextX + "," + Globals.TachoTextY + "," + Globals.TachoFontSize + "," + Globals.TachoTextStyle + "," + Globals.TachoNeedleType + "," + Globals.TachoNeedle;
                }
            }

            //Boost
            Globals.gaugename = ""; Globals.BoostShow = "n"; Globals.BoostTextShow = "n";  //reset to no values
            if (cmbShowBoost.Text == "N") { Globals.BoostShow = "n"; }
            if (cmbBoostTextShow.Text == "N") { Globals.BoostTextShow = "n"; }
            if (cmbShowBoost.Text == "Panel 1") { Globals.BoostShow = "1"; }
            if (cmbBoostTextShow.Text == "Panel 1") { Globals.BoostTextShow = "1"; }
            if (cmbShowBoost.Text == "Panel 2") { Globals.BoostShow = "2"; }
            if (cmbBoostTextShow.Text == "Panel 2") { Globals.BoostTextShow = "2"; }
            if (cmbShowBoost.Text == "Panel 3") { Globals.BoostShow = "3"; }
            if (cmbBoostTextShow.Text == "Panel 3") { Globals.BoostTextShow = "3"; }

            if ((Globals.BoostShow == "1") || (Globals.BoostTextShow == "1"))
            {
                Globals.gaugename = "Boost";
                if ((Globals.BoostShow == "1") && (Globals.BoostTextShow != "1"))
                {
                    Globals.Boostvalp1 = Globals.gaugename + "," + Globals.BoostShow + "," + Globals.BoostNeedleWidth + "," + Globals.BoostNeedleLength + "," + Globals.BoostNeedleX + "," + Globals.BoostNeedleY + "," + Globals.BoostOffset + "," + Globals.BoostEnd + "," + Globals.BoostTop + "," + "n" + "," + Globals.BoostTextX + "," + Globals.BoostTextY + "," + Globals.BoostFontSize + "," + Globals.BoostTextStyle + "," + Globals.BoostNeedleType + "," + Globals.BoostNeedle;
                }
                if ((Globals.BoostShow != "1") && (Globals.BoostTextShow == "1"))
                {
                    Globals.Boostvalp1 = Globals.gaugename + "," + "n" + "," + Globals.BoostNeedleWidth + "," + Globals.BoostNeedleLength + "," + Globals.BoostNeedleX + "," + Globals.BoostNeedleY + "," + Globals.BoostOffset + "," + Globals.BoostEnd + "," + Globals.BoostTop + "," + Globals.BoostTextShow + "," + Globals.BoostTextX + "," + Globals.BoostTextY + "," + Globals.BoostFontSize + "," + Globals.BoostTextStyle + "," + Globals.BoostNeedleType + "," + Globals.BoostNeedle;
                }
            }
            if ((Globals.BoostShow == "2") || (Globals.BoostTextShow == "2"))
            {
                Globals.gaugename = "Boost";
                if ((Globals.BoostShow == "2") && (Globals.BoostTextShow != "2"))
                {
                    Globals.Boostvalp2 = Globals.gaugename + "," + Globals.BoostShow + "," + Globals.BoostNeedleWidth + "," + Globals.BoostNeedleLength + "," + Globals.BoostNeedleX + "," + Globals.BoostNeedleY + "," + Globals.BoostOffset + "," + Globals.BoostEnd + "," + Globals.BoostTop + "," + "n" + "," + Globals.BoostTextX + "," + Globals.BoostTextY + "," + Globals.BoostFontSize + "," + Globals.BoostTextStyle + "," + Globals.BoostNeedleType + "," + Globals.BoostNeedle;
                }
                if ((Globals.BoostShow != "2") && (Globals.BoostTextShow == "2"))
                {
                    Globals.Boostvalp2 = Globals.gaugename + "," + "n" + "," + Globals.BoostNeedleWidth + "," + Globals.BoostNeedleLength + "," + Globals.BoostNeedleX + "," + Globals.BoostNeedleY + "," + Globals.BoostOffset + "," + Globals.BoostEnd + "," + Globals.BoostTop + "," + Globals.BoostTextShow + "," + Globals.BoostTextX + "," + Globals.BoostTextY + "," + Globals.BoostFontSize + "," + Globals.BoostTextStyle + "," + Globals.BoostNeedleType + "," + Globals.BoostNeedle;
                }
            }
            if ((Globals.BoostShow == "3") || (Globals.BoostTextShow == "3"))
            {
                Globals.gaugename = "Boost";
                if ((Globals.BoostShow == "3") && (Globals.BoostTextShow != "3"))
                {
                    Globals.Boostvalp3 = Globals.gaugename + "," + Globals.BoostShow + "," + Globals.BoostNeedleWidth + "," + Globals.BoostNeedleLength + "," + Globals.BoostNeedleX + "," + Globals.BoostNeedleY + "," + Globals.BoostOffset + "," + Globals.BoostEnd + "," + Globals.BoostTop + "," + "n" + "," + Globals.BoostTextX + "," + Globals.BoostTextY + "," + Globals.BoostFontSize + "," + Globals.BoostTextStyle + "," + Globals.BoostNeedleType + "," + Globals.BoostNeedle;
                }
                if ((Globals.BoostShow != "3") && (Globals.BoostTextShow == "3"))
                {
                    Globals.Boostvalp3 = Globals.gaugename + "," + "n" + "," + Globals.BoostNeedleWidth + "," + Globals.BoostNeedleLength + "," + Globals.BoostNeedleX + "," + Globals.BoostNeedleY + "," + Globals.BoostOffset + "," + Globals.BoostEnd + "," + Globals.BoostTop + "," + Globals.BoostTextShow + "," + Globals.BoostTextX + "," + Globals.BoostTextY + "," + Globals.BoostFontSize + "," + Globals.BoostTextStyle + "," + Globals.BoostNeedleType + "," + Globals.BoostNeedle;
                }
            }

            //Temp
            Globals.gaugename = ""; Globals.TempShow = "n"; Globals.TempTextShow = "n";  //reset to no values
            if (cmbShowTemp.Text == "N") { Globals.TempShow = "n"; }
            if (cmbTempTextShow.Text == "N") { Globals.TempTextShow = "n"; }
            if (cmbShowTemp.Text == "Panel 1") { Globals.TempShow = "1"; }
            if (cmbTempTextShow.Text == "Panel 1") { Globals.TempTextShow = "1"; }
            if (cmbShowTemp.Text == "Panel 2") { Globals.TempShow = "2"; }
            if (cmbTempTextShow.Text == "Panel 2") { Globals.TempTextShow = "2"; }
            if (cmbShowTemp.Text == "Panel 3") { Globals.TempShow = "3"; }
            if (cmbTempTextShow.Text == "Panel 3") { Globals.TempTextShow = "3"; }

            if ((Globals.TempShow == "1") || (Globals.TempTextShow == "1"))
            {
                Globals.gaugename = "Temp";
                if ((Globals.TempShow == "1") && (Globals.TempTextShow != "1"))
                {
                    Globals.Tempvalp1 = Globals.gaugename + "," + Globals.TempShow + "," + Globals.TempNeedleWidth + "," + Globals.TempNeedleLength + "," + Globals.TempNeedleX + "," + Globals.TempNeedleY + "," + Globals.TempOffset + "," + Globals.TempEnd + "," + Globals.TempTop + "," + "n" + "," + Globals.TempTextX + "," + Globals.TempTextY + "," + Globals.TempFontSize + "," + Globals.TempTextStyle + "," + Globals.TempNeedleType + "," + Globals.TempNeedle;
                }
                if ((Globals.TempShow != "1") && (Globals.TempTextShow == "1"))
                {
                    Globals.Tempvalp1 = Globals.gaugename + "," + "n" + "," + Globals.TempNeedleWidth + "," + Globals.TempNeedleLength + "," + Globals.TempNeedleX + "," + Globals.TempNeedleY + "," + Globals.TempOffset + "," + Globals.TempEnd + "," + Globals.TempTop + "," + Globals.TempTextShow + "," + Globals.TempTextX + "," + Globals.TempTextY + "," + Globals.TempFontSize + "," + Globals.TempTextStyle + "," + Globals.TempNeedleType + "," + Globals.TempNeedle;
                }
            }
            if ((Globals.TempShow == "2") || (Globals.TempTextShow == "2"))
            {
                Globals.gaugename = "Temp";
                if ((Globals.TempShow == "2") && (Globals.TempTextShow != "2"))
                {
                    Globals.Tempvalp2 = Globals.gaugename + "," + Globals.TempShow + "," + Globals.TempNeedleWidth + "," + Globals.TempNeedleLength + "," + Globals.TempNeedleX + "," + Globals.TempNeedleY + "," + Globals.TempOffset + "," + Globals.TempEnd + "," + Globals.TempTop + "," + "n" + "," + Globals.TempTextX + "," + Globals.TempTextY + "," + Globals.TempFontSize + "," + Globals.TempTextStyle + "," + Globals.TempNeedleType + "," + Globals.TempNeedle;
                }
                if ((Globals.TempShow != "2") && (Globals.TempTextShow == "2"))
                {
                    Globals.Tempvalp2 = Globals.gaugename + "," + "n" + "," + Globals.TempNeedleWidth + "," + Globals.TempNeedleLength + "," + Globals.TempNeedleX + "," + Globals.TempNeedleY + "," + Globals.TempOffset + "," + Globals.TempEnd + "," + Globals.TempTop + "," + Globals.TempTextShow + "," + Globals.TempTextX + "," + Globals.TempTextY + "," + Globals.TempFontSize + "," + Globals.TempTextStyle + "," + Globals.TempNeedleType + "," + Globals.TempNeedle;
                }
            }
            if ((Globals.TempShow == "3") || (Globals.TempTextShow == "3"))
            {
                Globals.gaugename = "Temp";
                if ((Globals.TempShow == "3") && (Globals.TempTextShow != "3"))
                {
                    Globals.Tempvalp3 = Globals.gaugename + "," + Globals.TempShow + "," + Globals.TempNeedleWidth + "," + Globals.TempNeedleLength + "," + Globals.TempNeedleX + "," + Globals.TempNeedleY + "," + Globals.TempOffset + "," + Globals.TempEnd + "," + Globals.TempTop + "," + "n" + "," + Globals.TempTextX + "," + Globals.TempTextY + "," + Globals.TempFontSize + "," + Globals.TempTextStyle + "," + Globals.TempNeedleType + "," + Globals.TempNeedle;
                }
                if ((Globals.TempShow != "3") && (Globals.TempTextShow == "3"))
                {
                    Globals.Tempvalp3 = Globals.gaugename + "," + "n" + "," + Globals.TempNeedleWidth + "," + Globals.TempNeedleLength + "," + Globals.TempNeedleX + "," + Globals.TempNeedleY + "," + Globals.TempOffset + "," + Globals.TempEnd + "," + Globals.TempTop + "," + Globals.TempTextShow + "," + Globals.TempTextX + "," + Globals.TempTextY + "," + Globals.TempFontSize + "," + Globals.TempTextStyle + "," + Globals.TempNeedleType + "," + Globals.TempNeedle;
                }
            }

            //Oil
            Globals.gaugename = ""; Globals.OilShow = "n"; Globals.OilTextShow = "n";  //reset to no values
            if (cmbShowOil.Text == "N") { Globals.OilShow = "n"; }
            if (cmbOilTextShow.Text == "N") { Globals.OilTextShow = "n"; }
            if (cmbShowOil.Text == "Panel 1") { Globals.OilShow = "1"; }
            if (cmbOilTextShow.Text == "Panel 1") { Globals.OilTextShow = "1"; }
            if (cmbShowOil.Text == "Panel 2") { Globals.OilShow = "2"; }
            if (cmbOilTextShow.Text == "Panel 2") { Globals.OilTextShow = "2"; }
            if (cmbShowOil.Text == "Panel 3") { Globals.OilShow = "3"; }
            if (cmbOilTextShow.Text == "Panel 3") { Globals.OilTextShow = "3"; }

            if ((Globals.OilShow == "1") || (Globals.OilTextShow == "1"))
            {
                Globals.gaugename = "Oil";
                if ((Globals.OilShow == "1") && (Globals.OilTextShow != "1"))
                {
                    Globals.Oilvalp1 = Globals.gaugename + "," + Globals.OilShow + "," + Globals.OilNeedleWidth + "," + Globals.OilNeedleLength + "," + Globals.OilNeedleX + "," + Globals.OilNeedleY + "," + Globals.OilOffset + "," + Globals.OilEnd + "," + Globals.OilTop + "," + "n" + "," + Globals.OilTextX + "," + Globals.OilTextY + "," + Globals.OilFontSize + "," + Globals.OilTextStyle + "," + Globals.OilNeedleType + "," + Globals.OilNeedle;
                }
                if ((Globals.OilShow != "1") && (Globals.OilTextShow == "1"))
                {
                    Globals.Oilvalp1 = Globals.gaugename + "," + "n" + "," + Globals.OilNeedleWidth + "," + Globals.OilNeedleLength + "," + Globals.OilNeedleX + "," + Globals.OilNeedleY + "," + Globals.OilOffset + "," + Globals.OilEnd + "," + Globals.OilTop + "," + Globals.OilTextShow + "," + Globals.OilTextX + "," + Globals.OilTextY + "," + Globals.OilFontSize + "," + Globals.OilTextStyle + "," + Globals.OilNeedleType + "," + Globals.OilNeedle;
                }
            }
            if ((Globals.OilShow == "2") || (Globals.OilTextShow == "2"))
            {
                Globals.gaugename = "Oil";
                if ((Globals.OilShow == "2") && (Globals.OilTextShow != "2"))
                {
                    Globals.Oilvalp2 = Globals.gaugename + "," + Globals.OilShow + "," + Globals.OilNeedleWidth + "," + Globals.OilNeedleLength + "," + Globals.OilNeedleX + "," + Globals.OilNeedleY + "," + Globals.OilOffset + "," + Globals.OilEnd + "," + Globals.OilTop + "," + "n" + "," + Globals.OilTextX + "," + Globals.OilTextY + "," + Globals.OilFontSize + "," + Globals.OilTextStyle + "," + Globals.OilNeedleType + "," + Globals.OilNeedle;
                }
                if ((Globals.OilShow != "2") && (Globals.OilTextShow == "2"))
                {
                    Globals.Oilvalp2 = Globals.gaugename + "," + "n" + "," + Globals.OilNeedleWidth + "," + Globals.OilNeedleLength + "," + Globals.OilNeedleX + "," + Globals.OilNeedleY + "," + Globals.OilOffset + "," + Globals.OilEnd + "," + Globals.OilTop + "," + Globals.OilTextShow + "," + Globals.OilTextX + "," + Globals.OilTextY + "," + Globals.OilFontSize + "," + Globals.OilTextStyle + "," + Globals.OilNeedleType + "," + Globals.OilNeedle;
                }
            }
            if ((Globals.OilShow == "3") || (Globals.OilTextShow == "3"))
            {
                Globals.gaugename = "Oil";
                if ((Globals.OilShow == "3") && (Globals.OilTextShow != "3"))
                {
                    Globals.Oilvalp3 = Globals.gaugename + "," + Globals.OilShow + "," + Globals.OilNeedleWidth + "," + Globals.OilNeedleLength + "," + Globals.OilNeedleX + "," + Globals.OilNeedleY + "," + Globals.OilOffset + "," + Globals.OilEnd + "," + Globals.OilTop + "," + "n" + "," + Globals.OilTextX + "," + Globals.OilTextY + "," + Globals.OilFontSize + "," + Globals.OilTextStyle + "," + Globals.OilNeedleType + "," + Globals.OilNeedle;
                }
                if ((Globals.OilShow != "3") && (Globals.OilTextShow == "3"))
                {
                    Globals.Oilvalp3 = Globals.gaugename + "," + "n" + "," + Globals.OilNeedleWidth + "," + Globals.OilNeedleLength + "," + Globals.OilNeedleX + "," + Globals.OilNeedleY + "," + Globals.OilOffset + "," + Globals.OilEnd + "," + Globals.OilTop + "," + Globals.OilTextShow + "," + Globals.OilTextX + "," + Globals.OilTextY + "," + Globals.OilFontSize + "," + Globals.OilTextStyle + "," + Globals.OilNeedleType + "," + Globals.OilNeedle;
                }
            }

            //OilT
            Globals.gaugename = ""; Globals.OilTShow = "n"; Globals.OilTTextShow = "n";  //reset to no values
            if (cmbShowOilT.Text == "N") { Globals.OilTShow = "n"; }
            if (cmbOilTTextShow.Text == "N") { Globals.OilTTextShow = "n"; }
            if (cmbShowOilT.Text == "Panel 1") { Globals.OilTShow = "1"; }
            if (cmbOilTTextShow.Text == "Panel 1") { Globals.OilTTextShow = "1"; }
            if (cmbShowOilT.Text == "Panel 2") { Globals.OilTShow = "2"; }
            if (cmbOilTTextShow.Text == "Panel 2") { Globals.OilTTextShow = "2"; }
            if (cmbShowOilT.Text == "Panel 3") { Globals.OilTShow = "3"; }
            if (cmbOilTTextShow.Text == "Panel 3") { Globals.OilTTextShow = "3"; }

            if ((Globals.OilTShow == "1") || (Globals.OilTTextShow == "1"))
            {
                Globals.gaugename = "OilT";
                if ((Globals.OilTShow == "1") && (Globals.OilTTextShow != "1"))
                {
                    Globals.OilTvalp1 = Globals.gaugename + "," + Globals.OilTShow + "," + Globals.OilTNeedleWidth + "," + Globals.OilTNeedleLength + "," + Globals.OilTNeedleX + "," + Globals.OilTNeedleY + "," + Globals.OilTOffset + "," + Globals.OilTEnd + "," + Globals.OilTTop + "," + "n" + "," + Globals.OilTTextX + "," + Globals.OilTTextY + "," + Globals.OilTFontSize + "," + Globals.OilTTextStyle + "," + Globals.OilTNeedleType + "," + Globals.OilTNeedle;
                }
                if ((Globals.OilTShow != "1") && (Globals.OilTTextShow == "1"))
                {
                    Globals.OilTvalp1 = Globals.gaugename + "," + "n" + "," + Globals.OilTNeedleWidth + "," + Globals.OilTNeedleLength + "," + Globals.OilTNeedleX + "," + Globals.OilTNeedleY + "," + Globals.OilTOffset + "," + Globals.OilTEnd + "," + Globals.OilTTop + "," + Globals.OilTTextShow + "," + Globals.OilTTextX + "," + Globals.OilTTextY + "," + Globals.OilTFontSize + "," + Globals.OilTTextStyle + "," + Globals.OilTNeedleType + "," + Globals.OilTNeedle;
                }
            }
            if ((Globals.OilTShow == "2") || (Globals.OilTTextShow == "2"))
            {
                Globals.gaugename = "OilT";
                if ((Globals.OilTShow == "2") && (Globals.OilTTextShow != "2"))
                {
                    Globals.OilTvalp2 = Globals.gaugename + "," + Globals.OilTShow + "," + Globals.OilTNeedleWidth + "," + Globals.OilTNeedleLength + "," + Globals.OilTNeedleX + "," + Globals.OilTNeedleY + "," + Globals.OilTOffset + "," + Globals.OilTEnd + "," + Globals.OilTTop + "," + "n" + "," + Globals.OilTTextX + "," + Globals.OilTTextY + "," + Globals.OilTFontSize + "," + Globals.OilTTextStyle + "," + Globals.OilTNeedleType + "," + Globals.OilTNeedle;
                }
                if ((Globals.OilTShow != "2") && (Globals.OilTTextShow == "2"))
                {
                    Globals.OilTvalp2 = Globals.gaugename + "," + "n" + "," + Globals.OilTNeedleWidth + "," + Globals.OilTNeedleLength + "," + Globals.OilTNeedleX + "," + Globals.OilTNeedleY + "," + Globals.OilTOffset + "," + Globals.OilTEnd + "," + Globals.OilTTop + "," + Globals.OilTTextShow + "," + Globals.OilTTextX + "," + Globals.OilTTextY + "," + Globals.OilTFontSize + "," + Globals.OilTTextStyle + "," + Globals.OilTNeedleType + "," + Globals.OilTNeedle;
                }
            }
            if ((Globals.OilTShow == "3") || (Globals.OilTTextShow == "3"))
            {
                Globals.gaugename = "OilT";
                if ((Globals.OilTShow == "3") && (Globals.OilTTextShow != "3"))
                {
                    Globals.OilTvalp3 = Globals.gaugename + "," + Globals.OilTShow + "," + Globals.OilTNeedleWidth + "," + Globals.OilTNeedleLength + "," + Globals.OilTNeedleX + "," + Globals.OilTNeedleY + "," + Globals.OilTOffset + "," + Globals.OilTEnd + "," + Globals.OilTTop + "," + "n" + "," + Globals.OilTTextX + "," + Globals.OilTTextY + "," + Globals.OilTFontSize + "," + Globals.OilTTextStyle + "," + Globals.OilTNeedleType + "," + Globals.OilTNeedle;
                }
                if ((Globals.OilTShow != "3") && (Globals.OilTTextShow == "3"))
                {
                    Globals.OilTvalp3 = Globals.gaugename + "," + "n" + "," + Globals.OilTNeedleWidth + "," + Globals.OilTNeedleLength + "," + Globals.OilTNeedleX + "," + Globals.OilTNeedleY + "," + Globals.OilTOffset + "," + Globals.OilTEnd + "," + Globals.OilTTop + "," + Globals.OilTTextShow + "," + Globals.OilTTextX + "," + Globals.OilTTextY + "," + Globals.OilTFontSize + "," + Globals.OilTTextStyle + "," + Globals.OilTNeedleType + "," + Globals.OilTNeedle;
                }
            }

            //Fuel
            Globals.gaugename = ""; Globals.FuelShow = "n"; Globals.FuelTextShow = "n";  //reset to no values
            if (cmbShowFuel.Text == "N") { Globals.FuelShow = "n"; }
            if (cmbFuelTextShow.Text == "N") { Globals.FuelTextShow = "n"; }
            if (cmbShowFuel.Text == "Panel 1") { Globals.FuelShow = "1"; }
            if (cmbFuelTextShow.Text == "Panel 1") { Globals.FuelTextShow = "1"; }
            if (cmbShowFuel.Text == "Panel 2") { Globals.FuelShow = "2"; }
            if (cmbFuelTextShow.Text == "Panel 2") { Globals.FuelTextShow = "2"; }
            if (cmbShowFuel.Text == "Panel 3") { Globals.FuelShow = "3"; }
            if (cmbFuelTextShow.Text == "Panel 3") { Globals.FuelTextShow = "3"; }

            if ((Globals.FuelShow == "1") || (Globals.FuelTextShow == "1"))
            {
                Globals.gaugename = "Fuel";
                if ((Globals.FuelShow == "1") && (Globals.FuelTextShow != "1"))
                {
                    Globals.Fuelvalp1 = Globals.gaugename + "," + Globals.FuelShow + "," + Globals.FuelNeedleWidth + "," + Globals.FuelNeedleLength + "," + Globals.FuelNeedleX + "," + Globals.FuelNeedleY + "," + Globals.FuelOffset + "," + Globals.FuelEnd + "," + Globals.FuelTop + "," + "n" + "," + Globals.FuelTextX + "," + Globals.FuelTextY + "," + Globals.FuelFontSize + "," + Globals.FuelTextStyle + "," + Globals.FuelNeedleType + "," + Globals.FuelNeedle;
                }
                if ((Globals.FuelShow != "1") && (Globals.FuelTextShow == "1"))
                {
                    Globals.Fuelvalp1 = Globals.gaugename + "," + "n" + "," + Globals.FuelNeedleWidth + "," + Globals.FuelNeedleLength + "," + Globals.FuelNeedleX + "," + Globals.FuelNeedleY + "," + Globals.FuelOffset + "," + Globals.FuelEnd + "," + Globals.FuelTop + "," + Globals.FuelTextShow + "," + Globals.FuelTextX + "," + Globals.FuelTextY + "," + Globals.FuelFontSize + "," + Globals.FuelTextStyle + "," + Globals.FuelNeedleType + "," + Globals.FuelNeedle;
                }
            }
            if ((Globals.FuelShow == "2") || (Globals.FuelTextShow == "2"))
            {
                Globals.gaugename = "Fuel";
                if ((Globals.FuelShow == "2") && (Globals.FuelTextShow != "2"))
                {
                    Globals.Fuelvalp2 = Globals.gaugename + "," + Globals.FuelShow + "," + Globals.FuelNeedleWidth + "," + Globals.FuelNeedleLength + "," + Globals.FuelNeedleX + "," + Globals.FuelNeedleY + "," + Globals.FuelOffset + "," + Globals.FuelEnd + "," + Globals.FuelTop + "," + "n" + "," + Globals.FuelTextX + "," + Globals.FuelTextY + "," + Globals.FuelFontSize + "," + Globals.FuelTextStyle + "," + Globals.FuelNeedleType + "," + Globals.FuelNeedle;
                }
                if ((Globals.FuelShow != "2") && (Globals.FuelTextShow == "2"))
                {
                    Globals.Fuelvalp2 = Globals.gaugename + "," + "n" + "," + Globals.FuelNeedleWidth + "," + Globals.FuelNeedleLength + "," + Globals.FuelNeedleX + "," + Globals.FuelNeedleY + "," + Globals.FuelOffset + "," + Globals.FuelEnd + "," + Globals.FuelTop + "," + Globals.FuelTextShow + "," + Globals.FuelTextX + "," + Globals.FuelTextY + "," + Globals.FuelFontSize + "," + Globals.FuelTextStyle + "," + Globals.FuelNeedleType + "," + Globals.FuelNeedle;
                }
            }
            if ((Globals.FuelShow == "3") || (Globals.FuelTextShow == "3"))
            {
                Globals.gaugename = "Fuel";
                if ((Globals.FuelShow == "3") && (Globals.FuelTextShow != "3"))
                {
                    Globals.Fuelvalp3 = Globals.gaugename + "," + Globals.FuelShow + "," + Globals.FuelNeedleWidth + "," + Globals.FuelNeedleLength + "," + Globals.FuelNeedleX + "," + Globals.FuelNeedleY + "," + Globals.FuelOffset + "," + Globals.FuelEnd + "," + Globals.FuelTop + "," + "n" + "," + Globals.FuelTextX + "," + Globals.FuelTextY + "," + Globals.FuelFontSize + "," + Globals.FuelTextStyle + "," + Globals.FuelNeedleType + "," + Globals.FuelNeedle;
                }
                if ((Globals.FuelShow != "3") && (Globals.FuelTextShow == "3"))
                {
                    Globals.Fuelvalp3 = Globals.gaugename + "," + "n" + "," + Globals.FuelNeedleWidth + "," + Globals.FuelNeedleLength + "," + Globals.FuelNeedleX + "," + Globals.FuelNeedleY + "," + Globals.FuelOffset + "," + Globals.FuelEnd + "," + Globals.FuelTop + "," + Globals.FuelTextShow + "," + Globals.FuelTextX + "," + Globals.FuelTextY + "," + Globals.FuelFontSize + "," + Globals.FuelTextStyle + "," + Globals.FuelNeedleType + "," + Globals.FuelNeedle;
                }
            }

            //FuelT
            Globals.gaugename = ""; Globals.FuelTShow = "n"; Globals.FuelTTextShow = "n";  //reset to no values
            if (cmbShowFuelT.Text == "N") { Globals.FuelTShow = "n"; }
            if (cmbFuelTTextShow.Text == "N") { Globals.FuelTTextShow = "n"; }
            if (cmbShowFuelT.Text == "Panel 1") { Globals.FuelTShow = "1"; }
            if (cmbFuelTTextShow.Text == "Panel 1") { Globals.FuelTTextShow = "1"; }
            if (cmbShowFuelT.Text == "Panel 2") { Globals.FuelTShow = "2"; }
            if (cmbFuelTTextShow.Text == "Panel 2") { Globals.FuelTTextShow = "2"; }
            if (cmbShowFuelT.Text == "Panel 3") { Globals.FuelTShow = "3"; }
            if (cmbFuelTTextShow.Text == "Panel 3") { Globals.FuelTTextShow = "3"; }

            if ((Globals.FuelTShow == "1") || (Globals.FuelTTextShow == "1"))
            {
                Globals.gaugename = "FuelT";
                if ((Globals.FuelTShow == "1") && (Globals.FuelTTextShow != "1"))
                {
                    Globals.FuelTvalp1 = Globals.gaugename + "," + Globals.FuelTShow + "," + Globals.FuelTNeedleWidth + "," + Globals.FuelTNeedleLength + "," + Globals.FuelTNeedleX + "," + Globals.FuelTNeedleY + "," + Globals.FuelTOffset + "," + Globals.FuelTEnd + "," + Globals.FuelTTop + "," + "n" + "," + Globals.FuelTTextX + "," + Globals.FuelTTextY + "," + Globals.FuelTFontSize + "," + Globals.FuelTTextStyle + "," + Globals.FuelTNeedleType + "," + Globals.FuelTNeedle;
                }
                if ((Globals.FuelTShow != "1") && (Globals.FuelTTextShow == "1"))
                {
                    Globals.FuelTvalp1 = Globals.gaugename + "," + "n" + "," + Globals.FuelTNeedleWidth + "," + Globals.FuelTNeedleLength + "," + Globals.FuelTNeedleX + "," + Globals.FuelTNeedleY + "," + Globals.FuelTOffset + "," + Globals.FuelTEnd + "," + Globals.FuelTTop + "," + Globals.FuelTTextShow + "," + Globals.FuelTTextX + "," + Globals.FuelTTextY + "," + Globals.FuelTFontSize + "," + Globals.FuelTTextStyle + "," + Globals.FuelTNeedleType + "," + Globals.FuelTNeedle;
                }
            }
            if ((Globals.FuelTShow == "2") || (Globals.FuelTTextShow == "2"))
            {
                Globals.gaugename = "FuelT";
                if ((Globals.FuelTShow == "2") && (Globals.FuelTTextShow != "2"))
                {
                    Globals.FuelTvalp2 = Globals.gaugename + "," + Globals.FuelTShow + "," + Globals.FuelTNeedleWidth + "," + Globals.FuelTNeedleLength + "," + Globals.FuelTNeedleX + "," + Globals.FuelTNeedleY + "," + Globals.FuelTOffset + "," + Globals.FuelTEnd + "," + Globals.FuelTTop + "," + "n" + "," + Globals.FuelTTextX + "," + Globals.FuelTTextY + "," + Globals.FuelTFontSize + "," + Globals.FuelTTextStyle + "," + Globals.FuelTNeedleType + "," + Globals.FuelTNeedle;
                }
                if ((Globals.FuelTShow != "2") && (Globals.FuelTTextShow == "2"))
                {
                    Globals.FuelTvalp2 = Globals.gaugename + "," + "n" + "," + Globals.FuelTNeedleWidth + "," + Globals.FuelTNeedleLength + "," + Globals.FuelTNeedleX + "," + Globals.FuelTNeedleY + "," + Globals.FuelTOffset + "," + Globals.FuelTEnd + "," + Globals.FuelTTop + "," + Globals.FuelTTextShow + "," + Globals.FuelTTextX + "," + Globals.FuelTTextY + "," + Globals.FuelTFontSize + "," + Globals.FuelTTextStyle + "," + Globals.FuelTNeedleType + "," + Globals.FuelTNeedle;
                }
            }
            if ((Globals.FuelTShow == "3") || (Globals.FuelTTextShow == "3"))
            {
                Globals.gaugename = "FuelT";
                if ((Globals.FuelTShow == "3") && (Globals.FuelTTextShow != "3"))
                {
                    Globals.FuelTvalp3 = Globals.gaugename + "," + Globals.FuelTShow + "," + Globals.FuelTNeedleWidth + "," + Globals.FuelTNeedleLength + "," + Globals.FuelTNeedleX + "," + Globals.FuelTNeedleY + "," + Globals.FuelTOffset + "," + Globals.FuelTEnd + "," + Globals.FuelTTop + "," + "n" + "," + Globals.FuelTTextX + "," + Globals.FuelTTextY + "," + Globals.FuelTFontSize + "," + Globals.FuelTTextStyle + "," + Globals.FuelTNeedleType + "," + Globals.FuelTNeedle;
                }
                if ((Globals.FuelTShow != "3") && (Globals.FuelTTextShow == "3"))
                {
                    Globals.FuelTvalp3 = Globals.gaugename + "," + "n" + "," + Globals.FuelTNeedleWidth + "," + Globals.FuelTNeedleLength + "," + Globals.FuelTNeedleX + "," + Globals.FuelTNeedleY + "," + Globals.FuelTOffset + "," + Globals.FuelTEnd + "," + Globals.FuelTTop + "," + Globals.FuelTTextShow + "," + Globals.FuelTTextX + "," + Globals.FuelTTextY + "," + Globals.FuelTFontSize + "," + Globals.FuelTTextStyle + "," + Globals.FuelTNeedleType + "," + Globals.FuelTNeedle;
                }
            }

            //FuelP
            Globals.gaugename = ""; Globals.FuelPShow = "n"; Globals.FuelPTextShow = "n";  //reset to no values
            if (cmbShowFuelP.Text == "N") { Globals.FuelPShow = "n"; }
            if (cmbFuelPTextShow.Text == "N") { Globals.FuelPTextShow = "n"; }
            if (cmbShowFuelP.Text == "Panel 1") { Globals.FuelPShow = "1"; }
            if (cmbFuelPTextShow.Text == "Panel 1") { Globals.FuelPTextShow = "1"; }
            if (cmbShowFuelP.Text == "Panel 2") { Globals.FuelPShow = "2"; }
            if (cmbFuelPTextShow.Text == "Panel 2") { Globals.FuelPTextShow = "2"; }
            if (cmbShowFuelP.Text == "Panel 3") { Globals.FuelPShow = "3"; }
            if (cmbFuelPTextShow.Text == "Panel 3") { Globals.FuelPTextShow = "3"; }

            if ((Globals.FuelPShow == "1") || (Globals.FuelPTextShow == "1"))
            {
                Globals.gaugename = "FuelP";
                if ((Globals.FuelPShow == "1") && (Globals.FuelPTextShow != "1"))
                {
                    Globals.FuelPvalp1 = Globals.gaugename + "," + Globals.FuelPShow + "," + Globals.FuelPNeedleWidth + "," + Globals.FuelPNeedleLength + "," + Globals.FuelPNeedleX + "," + Globals.FuelPNeedleY + "," + Globals.FuelPOffset + "," + Globals.FuelPEnd + "," + Globals.FuelPTop + "," + "n" + "," + Globals.FuelPTextX + "," + Globals.FuelPTextY + "," + Globals.FuelPFontSize + "," + Globals.FuelPTextStyle + "," + Globals.FuelPNeedleType + "," + Globals.FuelPNeedle;
                }
                if ((Globals.FuelPShow != "1") && (Globals.FuelPTextShow == "1"))
                {
                    Globals.FuelPvalp1 = Globals.gaugename + "," + "n" + "," + Globals.FuelPNeedleWidth + "," + Globals.FuelPNeedleLength + "," + Globals.FuelPNeedleX + "," + Globals.FuelPNeedleY + "," + Globals.FuelPOffset + "," + Globals.FuelPEnd + "," + Globals.FuelPTop + "," + Globals.FuelPTextShow + "," + Globals.FuelPTextX + "," + Globals.FuelPTextY + "," + Globals.FuelPFontSize + "," + Globals.FuelPTextStyle + "," + Globals.FuelPNeedleType + "," + Globals.FuelPNeedle;
                }
            }
            if ((Globals.FuelPShow == "2") || (Globals.FuelPTextShow == "2"))
            {
                Globals.gaugename = "FuelP";
                if ((Globals.FuelPShow == "2") && (Globals.FuelPTextShow != "2"))
                {
                    Globals.FuelPvalp2 = Globals.gaugename + "," + Globals.FuelPShow + "," + Globals.FuelPNeedleWidth + "," + Globals.FuelPNeedleLength + "," + Globals.FuelPNeedleX + "," + Globals.FuelPNeedleY + "," + Globals.FuelPOffset + "," + Globals.FuelPEnd + "," + Globals.FuelPTop + "," + "n" + "," + Globals.FuelPTextX + "," + Globals.FuelPTextY + "," + Globals.FuelPFontSize + "," + Globals.FuelPTextStyle + "," + Globals.FuelPNeedleType + "," + Globals.FuelPNeedle;
                }
                if ((Globals.FuelPShow != "2") && (Globals.FuelPTextShow == "2"))
                {
                    Globals.FuelPvalp2 = Globals.gaugename + "," + "n" + "," + Globals.FuelPNeedleWidth + "," + Globals.FuelPNeedleLength + "," + Globals.FuelPNeedleX + "," + Globals.FuelPNeedleY + "," + Globals.FuelPOffset + "," + Globals.FuelPEnd + "," + Globals.FuelPTop + "," + Globals.FuelPTextShow + "," + Globals.FuelPTextX + "," + Globals.FuelPTextY + "," + Globals.FuelPFontSize + "," + Globals.FuelPTextStyle + "," + Globals.FuelPNeedleType + "," + Globals.FuelPNeedle;
                }
            }
            if ((Globals.FuelPShow == "3") || (Globals.FuelPTextShow == "3"))
            {
                Globals.gaugename = "FuelP";
                if ((Globals.FuelPShow == "3") && (Globals.FuelPTextShow != "3"))
                {
                    Globals.FuelPvalp3 = Globals.gaugename + "," + Globals.FuelPShow + "," + Globals.FuelPNeedleWidth + "," + Globals.FuelPNeedleLength + "," + Globals.FuelPNeedleX + "," + Globals.FuelPNeedleY + "," + Globals.FuelPOffset + "," + Globals.FuelPEnd + "," + Globals.FuelPTop + "," + "n" + "," + Globals.FuelPTextX + "," + Globals.FuelPTextY + "," + Globals.FuelPFontSize + "," + Globals.FuelPTextStyle + "," + Globals.FuelPNeedleType + "," + Globals.FuelPNeedle;
                }
                if ((Globals.FuelPShow != "3") && (Globals.FuelPTextShow == "3"))
                {
                    Globals.FuelPvalp3 = Globals.gaugename + "," + "n" + "," + Globals.FuelPNeedleWidth + "," + Globals.FuelPNeedleLength + "," + Globals.FuelPNeedleX + "," + Globals.FuelPNeedleY + "," + Globals.FuelPOffset + "," + Globals.FuelPEnd + "," + Globals.FuelPTop + "," + Globals.FuelPTextShow + "," + Globals.FuelPTextX + "," + Globals.FuelPTextY + "," + Globals.FuelPFontSize + "," + Globals.FuelPTextStyle + "," + Globals.FuelPNeedleType + "," + Globals.FuelPNeedle;
                }
            }

            //User1
            Globals.gaugename = ""; Globals.User1Show = "n"; Globals.User1TextShow = "n";  //reset to no values
            if (cmbShowUser1.Text == "N") { Globals.User1Show = "n"; }
            if (cmbUser1TextShow.Text == "N") { Globals.User1TextShow = "n"; }
            if (cmbShowUser1.Text == "Panel 1") { Globals.User1Show = "1"; }
            if (cmbUser1TextShow.Text == "Panel 1") { Globals.User1TextShow = "1"; }
            if (cmbShowUser1.Text == "Panel 2") { Globals.User1Show = "2"; }
            if (cmbUser1TextShow.Text == "Panel 2") { Globals.User1TextShow = "2"; }
            if (cmbShowUser1.Text == "Panel 3") { Globals.User1Show = "3"; }
            if (cmbUser1TextShow.Text == "Panel 3") { Globals.User1TextShow = "3"; }

            if ((Globals.User1Show == "1") || (Globals.User1TextShow == "1"))
            {
                Globals.gaugename = "User1";
                if ((Globals.User1Show == "1") && (Globals.User1TextShow != "1"))
                {
                    Globals.User1valp1 = Globals.gaugename + "," + Globals.User1Show + "," + Globals.User1NeedleWidth + "," + Globals.User1NeedleLength + "," + Globals.User1NeedleX + "," + Globals.User1NeedleY + "," + Globals.User1Offset + "," + Globals.User1End + "," + Globals.User1Top + "," + "n" + "," + Globals.User1TextX + "," + Globals.User1TextY + "," + Globals.User1FontSize + "," + Globals.User1TextStyle + "," + Globals.User1NeedleType + "," + Globals.User1Needle;
                }
                if ((Globals.User1Show != "1") && (Globals.User1TextShow == "1"))
                {
                    Globals.User1valp1 = Globals.gaugename + "," + "n" + "," + Globals.User1NeedleWidth + "," + Globals.User1NeedleLength + "," + Globals.User1NeedleX + "," + Globals.User1NeedleY + "," + Globals.User1Offset + "," + Globals.User1End + "," + Globals.User1Top + "," + Globals.User1TextShow + "," + Globals.User1TextX + "," + Globals.User1TextY + "," + Globals.User1FontSize + "," + Globals.User1TextStyle + "," + Globals.User1NeedleType + "," + Globals.User1Needle;
                }
            }
            if ((Globals.User1Show == "2") || (Globals.User1TextShow == "2"))
            {
                Globals.gaugename = "User1";
                if ((Globals.User1Show == "2") && (Globals.User1TextShow != "2"))
                {
                    Globals.User1valp2 = Globals.gaugename + "," + Globals.User1Show + "," + Globals.User1NeedleWidth + "," + Globals.User1NeedleLength + "," + Globals.User1NeedleX + "," + Globals.User1NeedleY + "," + Globals.User1Offset + "," + Globals.User1End + "," + Globals.User1Top + "," + "n" + "," + Globals.User1TextX + "," + Globals.User1TextY + "," + Globals.User1FontSize + "," + Globals.User1TextStyle + "," + Globals.User1NeedleType + "," + Globals.User1Needle;
                }
                if ((Globals.User1Show != "2") && (Globals.User1TextShow == "2"))
                {
                    Globals.User1valp2 = Globals.gaugename + "," + "n" + "," + Globals.User1NeedleWidth + "," + Globals.User1NeedleLength + "," + Globals.User1NeedleX + "," + Globals.User1NeedleY + "," + Globals.User1Offset + "," + Globals.User1End + "," + Globals.User1Top + "," + Globals.User1TextShow + "," + Globals.User1TextX + "," + Globals.User1TextY + "," + Globals.User1FontSize + "," + Globals.User1TextStyle + "," + Globals.User1NeedleType + "," + Globals.User1Needle;
                }
            }
            if ((Globals.User1Show == "3") || (Globals.User1TextShow == "3"))
            {
                Globals.gaugename = "User1";
                if ((Globals.User1Show == "3") && (Globals.User1TextShow != "3"))
                {
                    Globals.User1valp3 = Globals.gaugename + "," + Globals.User1Show + "," + Globals.User1NeedleWidth + "," + Globals.User1NeedleLength + "," + Globals.User1NeedleX + "," + Globals.User1NeedleY + "," + Globals.User1Offset + "," + Globals.User1End + "," + Globals.User1Top + "," + "n" + "," + Globals.User1TextX + "," + Globals.User1TextY + "," + Globals.User1FontSize + "," + Globals.User1TextStyle + "," + Globals.User1NeedleType + "," + Globals.User1Needle;
                }
                if ((Globals.User1Show != "3") && (Globals.User1TextShow == "3"))
                {
                    Globals.User1valp3 = Globals.gaugename + "," + "n" + "," + Globals.User1NeedleWidth + "," + Globals.User1NeedleLength + "," + Globals.User1NeedleX + "," + Globals.User1NeedleY + "," + Globals.User1Offset + "," + Globals.User1End + "," + Globals.User1Top + "," + Globals.User1TextShow + "," + Globals.User1TextX + "," + Globals.User1TextY + "," + Globals.User1FontSize + "," + Globals.User1TextStyle + "," + Globals.User1NeedleType + "," + Globals.User1Needle;
                }
            }

            //User2
            Globals.gaugename = ""; Globals.User2Show = "n"; Globals.User2TextShow = "n";  //reset to no values
            if (cmbShowUser2.Text == "N") { Globals.User2Show = "n"; }
            if (cmbUser2TextShow.Text == "N") { Globals.User2TextShow = "n"; }
            if (cmbShowUser2.Text == "Panel 1") { Globals.User2Show = "1"; }
            if (cmbUser2TextShow.Text == "Panel 1") { Globals.User2TextShow = "1"; }
            if (cmbShowUser2.Text == "Panel 2") { Globals.User2Show = "2"; }
            if (cmbUser2TextShow.Text == "Panel 2") { Globals.User2TextShow = "2"; }
            if (cmbShowUser2.Text == "Panel 3") { Globals.User2Show = "3"; }
            if (cmbUser2TextShow.Text == "Panel 3") { Globals.User2TextShow = "3"; }

            if ((Globals.User2Show == "1") || (Globals.User2TextShow == "1"))
            {
                Globals.gaugename = "User2";
                if ((Globals.User2Show == "1") && (Globals.User2TextShow != "1"))
                {
                    Globals.User2valp1 = Globals.gaugename + "," + Globals.User2Show + "," + Globals.User2NeedleWidth + "," + Globals.User2NeedleLength + "," + Globals.User2NeedleX + "," + Globals.User2NeedleY + "," + Globals.User2Offset + "," + Globals.User2End + "," + Globals.User2Top + "," + "n" + "," + Globals.User2TextX + "," + Globals.User2TextY + "," + Globals.User2FontSize + "," + Globals.User2TextStyle + "," + Globals.User2NeedleType + "," + Globals.User2Needle;
                }
                if ((Globals.User2Show != "1") && (Globals.User2TextShow == "1"))
                {
                    Globals.User2valp1 = Globals.gaugename + "," + "n" + "," + Globals.User2NeedleWidth + "," + Globals.User2NeedleLength + "," + Globals.User2NeedleX + "," + Globals.User2NeedleY + "," + Globals.User2Offset + "," + Globals.User2End + "," + Globals.User2Top + "," + Globals.User2TextShow + "," + Globals.User2TextX + "," + Globals.User2TextY + "," + Globals.User2FontSize + "," + Globals.User2TextStyle + "," + Globals.User2NeedleType + "," + Globals.User2Needle;
                }
            }
            if ((Globals.User2Show == "2") || (Globals.User2TextShow == "2"))
            {
                Globals.gaugename = "User2";
                if ((Globals.User2Show == "2") && (Globals.User2TextShow != "2"))
                {
                    Globals.User2valp2 = Globals.gaugename + "," + Globals.User2Show + "," + Globals.User2NeedleWidth + "," + Globals.User2NeedleLength + "," + Globals.User2NeedleX + "," + Globals.User2NeedleY + "," + Globals.User2Offset + "," + Globals.User2End + "," + Globals.User2Top + "," + "n" + "," + Globals.User2TextX + "," + Globals.User2TextY + "," + Globals.User2FontSize + "," + Globals.User2TextStyle + "," + Globals.User2NeedleType + "," + Globals.User2Needle;
                }
                if ((Globals.User2Show != "2") && (Globals.User2TextShow == "2"))
                {
                    Globals.User2valp2 = Globals.gaugename + "," + "n" + "," + Globals.User2NeedleWidth + "," + Globals.User2NeedleLength + "," + Globals.User2NeedleX + "," + Globals.User2NeedleY + "," + Globals.User2Offset + "," + Globals.User2End + "," + Globals.User2Top + "," + Globals.User2TextShow + "," + Globals.User2TextX + "," + Globals.User2TextY + "," + Globals.User2FontSize + "," + Globals.User2TextStyle + "," + Globals.User2NeedleType + "," + Globals.User2Needle;
                }
            }
            if ((Globals.User2Show == "3") || (Globals.User2TextShow == "3"))
            {
                Globals.gaugename = "User2";
                if ((Globals.User2Show == "3") && (Globals.User2TextShow != "3"))
                {
                    Globals.User2valp3 = Globals.gaugename + "," + Globals.User2Show + "," + Globals.User2NeedleWidth + "," + Globals.User2NeedleLength + "," + Globals.User2NeedleX + "," + Globals.User2NeedleY + "," + Globals.User2Offset + "," + Globals.User2End + "," + Globals.User2Top + "," + "n" + "," + Globals.User2TextX + "," + Globals.User2TextY + "," + Globals.User2FontSize + "," + Globals.User2TextStyle + "," + Globals.User2NeedleType + "," + Globals.User2Needle;
                }
                if ((Globals.User2Show != "3") && (Globals.User2TextShow == "3"))
                {
                    Globals.User2valp3 = Globals.gaugename + "," + "n" + "," + Globals.User2NeedleWidth + "," + Globals.User2NeedleLength + "," + Globals.User2NeedleX + "," + Globals.User2NeedleY + "," + Globals.User2Offset + "," + Globals.User2End + "," + Globals.User2Top + "," + Globals.User2TextShow + "," + Globals.User2TextX + "," + Globals.User2TextY + "," + Globals.User2FontSize + "," + Globals.User2TextStyle + "," + Globals.User2NeedleType + "," + Globals.User2Needle;
                }
            }

            //User3
            Globals.gaugename = ""; Globals.User3Show = "n"; Globals.User3TextShow = "n";  //reset to no values
            if (cmbShowUser3.Text == "N") { Globals.User3Show = "n"; }
            if (cmbUser3TextShow.Text == "N") { Globals.User3TextShow = "n"; }
            if (cmbShowUser3.Text == "Panel 1") { Globals.User3Show = "1"; }
            if (cmbUser3TextShow.Text == "Panel 1") { Globals.User3TextShow = "1"; }
            if (cmbShowUser3.Text == "Panel 2") { Globals.User3Show = "2"; }
            if (cmbUser3TextShow.Text == "Panel 2") { Globals.User3TextShow = "2"; }
            if (cmbShowUser3.Text == "Panel 3") { Globals.User3Show = "3"; }
            if (cmbUser3TextShow.Text == "Panel 3") { Globals.User3TextShow = "3"; }

            if ((Globals.User3Show == "1") || (Globals.User3TextShow == "1"))
            {
                Globals.gaugename = "User3";
                if ((Globals.User3Show == "1") && (Globals.User3TextShow != "1"))
                {
                    Globals.User3valp1 = Globals.gaugename + "," + Globals.User3Show + "," + Globals.User3NeedleWidth + "," + Globals.User3NeedleLength + "," + Globals.User3NeedleX + "," + Globals.User3NeedleY + "," + Globals.User3Offset + "," + Globals.User3End + "," + Globals.User3Top + "," + "n" + "," + Globals.User3TextX + "," + Globals.User3TextY + "," + Globals.User3FontSize + "," + Globals.User3TextStyle + "," + Globals.User3NeedleType + "," + Globals.User3Needle;
                }
                if ((Globals.User3Show != "1") && (Globals.User3TextShow == "1"))
                {
                    Globals.User3valp1 = Globals.gaugename + "," + "n" + "," + Globals.User3NeedleWidth + "," + Globals.User3NeedleLength + "," + Globals.User3NeedleX + "," + Globals.User3NeedleY + "," + Globals.User3Offset + "," + Globals.User3End + "," + Globals.User3Top + "," + Globals.User3TextShow + "," + Globals.User3TextX + "," + Globals.User3TextY + "," + Globals.User3FontSize + "," + Globals.User3TextStyle + "," + Globals.User3NeedleType + "," + Globals.User3Needle;
                }
            }
            if ((Globals.User3Show == "2") || (Globals.User3TextShow == "2"))
            {
                Globals.gaugename = "User3";
                if ((Globals.User3Show == "2") && (Globals.User3TextShow != "2"))
                {
                    Globals.User3valp2 = Globals.gaugename + "," + Globals.User3Show + "," + Globals.User3NeedleWidth + "," + Globals.User3NeedleLength + "," + Globals.User3NeedleX + "," + Globals.User3NeedleY + "," + Globals.User3Offset + "," + Globals.User3End + "," + Globals.User3Top + "," + "n" + "," + Globals.User3TextX + "," + Globals.User3TextY + "," + Globals.User3FontSize + "," + Globals.User3TextStyle + "," + Globals.User3NeedleType + "," + Globals.User3Needle;
                }
                if ((Globals.User3Show != "2") && (Globals.User3TextShow == "2"))
                {
                    Globals.User3valp2 = Globals.gaugename + "," + "n" + "," + Globals.User3NeedleWidth + "," + Globals.User3NeedleLength + "," + Globals.User3NeedleX + "," + Globals.User3NeedleY + "," + Globals.User3Offset + "," + Globals.User3End + "," + Globals.User3Top + "," + Globals.User3TextShow + "," + Globals.User3TextX + "," + Globals.User3TextY + "," + Globals.User3FontSize + "," + Globals.User3TextStyle + "," + Globals.User3NeedleType + "," + Globals.User3Needle;
                }
            }
            if ((Globals.User3Show == "3") || (Globals.User3TextShow == "3"))
            {
                Globals.gaugename = "User3";
                if ((Globals.User3Show == "3") && (Globals.User3TextShow != "3"))
                {
                    Globals.User3valp3 = Globals.gaugename + "," + Globals.User3Show + "," + Globals.User3NeedleWidth + "," + Globals.User3NeedleLength + "," + Globals.User3NeedleX + "," + Globals.User3NeedleY + "," + Globals.User3Offset + "," + Globals.User3End + "," + Globals.User3Top + "," + "n" + "," + Globals.User3TextX + "," + Globals.User3TextY + "," + Globals.User3FontSize + "," + Globals.User3TextStyle + "," + Globals.User3NeedleType + "," + Globals.User3Needle;
                }
                if ((Globals.User3Show != "3") && (Globals.User3TextShow == "3"))
                {
                    Globals.User3valp3 = Globals.gaugename + "," + "n" + "," + Globals.User3NeedleWidth + "," + Globals.User3NeedleLength + "," + Globals.User3NeedleX + "," + Globals.User3NeedleY + "," + Globals.User3Offset + "," + Globals.User3End + "," + Globals.User3Top + "," + Globals.User3TextShow + "," + Globals.User3TextX + "," + Globals.User3TextY + "," + Globals.User3FontSize + "," + Globals.User3TextStyle + "," + Globals.User3NeedleType + "," + Globals.User3Needle;
                }
            }

            //User4
            Globals.gaugename = ""; Globals.User4Show = "n"; Globals.User4TextShow = "n";  //reset to no values
            if (cmbShowUser4.Text == "N") { Globals.User4Show = "n"; }
            if (cmbUser4TextShow.Text == "N") { Globals.User4TextShow = "n"; }
            if (cmbShowUser4.Text == "Panel 1") { Globals.User4Show = "1"; }
            if (cmbUser4TextShow.Text == "Panel 1") { Globals.User4TextShow = "1"; }
            if (cmbShowUser4.Text == "Panel 2") { Globals.User4Show = "2"; }
            if (cmbUser4TextShow.Text == "Panel 2") { Globals.User4TextShow = "2"; }
            if (cmbShowUser4.Text == "Panel 3") { Globals.User4Show = "3"; }
            if (cmbUser4TextShow.Text == "Panel 3") { Globals.User4TextShow = "3"; }

            if ((Globals.User4Show == "1") || (Globals.User4TextShow == "1"))
            {
                Globals.gaugename = "User4";
                if ((Globals.User4Show == "1") && (Globals.User4TextShow != "1"))
                {
                    Globals.User4valp1 = Globals.gaugename + "," + Globals.User4Show + "," + Globals.User4NeedleWidth + "," + Globals.User4NeedleLength + "," + Globals.User4NeedleX + "," + Globals.User4NeedleY + "," + Globals.User4Offset + "," + Globals.User4End + "," + Globals.User4Top + "," + "n" + "," + Globals.User4TextX + "," + Globals.User4TextY + "," + Globals.User4FontSize + "," + Globals.User4TextStyle + "," + Globals.User4NeedleType + "," + Globals.User4Needle;
                }
                if ((Globals.User4Show != "1") && (Globals.User4TextShow == "1"))
                {
                    Globals.User4valp1 = Globals.gaugename + "," + "n" + "," + Globals.User4NeedleWidth + "," + Globals.User4NeedleLength + "," + Globals.User4NeedleX + "," + Globals.User4NeedleY + "," + Globals.User4Offset + "," + Globals.User4End + "," + Globals.User4Top + "," + Globals.User4TextShow + "," + Globals.User4TextX + "," + Globals.User4TextY + "," + Globals.User4FontSize + "," + Globals.User4TextStyle + "," + Globals.User4NeedleType + "," + Globals.User4Needle;
                }
            }
            if ((Globals.User4Show == "2") || (Globals.User4TextShow == "2"))
            {
                Globals.gaugename = "User4";
                if ((Globals.User4Show == "2") && (Globals.User4TextShow != "2"))
                {
                    Globals.User4valp2 = Globals.gaugename + "," + Globals.User4Show + "," + Globals.User4NeedleWidth + "," + Globals.User4NeedleLength + "," + Globals.User4NeedleX + "," + Globals.User4NeedleY + "," + Globals.User4Offset + "," + Globals.User4End + "," + Globals.User4Top + "," + "n" + "," + Globals.User4TextX + "," + Globals.User4TextY + "," + Globals.User4FontSize + "," + Globals.User4TextStyle + "," + Globals.User4NeedleType + "," + Globals.User4Needle;
                }
                if ((Globals.User4Show != "2") && (Globals.User4TextShow == "2"))
                {
                    Globals.User4valp2 = Globals.gaugename + "," + "n" + "," + Globals.User4NeedleWidth + "," + Globals.User4NeedleLength + "," + Globals.User4NeedleX + "," + Globals.User4NeedleY + "," + Globals.User4Offset + "," + Globals.User4End + "," + Globals.User4Top + "," + Globals.User4TextShow + "," + Globals.User4TextX + "," + Globals.User4TextY + "," + Globals.User4FontSize + "," + Globals.User4TextStyle + "," + Globals.User4NeedleType + "," + Globals.User4Needle;
                }
            }
            if ((Globals.User4Show == "3") || (Globals.User4TextShow == "3"))
            {
                Globals.gaugename = "User4";
                if ((Globals.User4Show == "3") && (Globals.User4TextShow != "3"))
                {
                    Globals.User4valp3 = Globals.gaugename + "," + Globals.User4Show + "," + Globals.User4NeedleWidth + "," + Globals.User4NeedleLength + "," + Globals.User4NeedleX + "," + Globals.User4NeedleY + "," + Globals.User4Offset + "," + Globals.User4End + "," + Globals.User4Top + "," + "n" + "," + Globals.User4TextX + "," + Globals.User4TextY + "," + Globals.User4FontSize + "," + Globals.User4TextStyle + "," + Globals.User4NeedleType + "," + Globals.User4Needle;
                }
                if ((Globals.User4Show != "3") && (Globals.User4TextShow == "3"))
                {
                    Globals.User4valp3 = Globals.gaugename + "," + "n" + "," + Globals.User4NeedleWidth + "," + Globals.User4NeedleLength + "," + Globals.User4NeedleX + "," + Globals.User4NeedleY + "," + Globals.User4Offset + "," + Globals.User4End + "," + Globals.User4Top + "," + Globals.User4TextShow + "," + Globals.User4TextX + "," + Globals.User4TextY + "," + Globals.User4FontSize + "," + Globals.User4TextStyle + "," + Globals.User4NeedleType + "," + Globals.User4Needle;
                }
            }
        }

        // --------------------------------------------------------------------------------populate screen from global variables----------------------------------------------------------
        private void resolveFromVars()
        {
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
                case "Guage":
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
                case "Guage":
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
                case "Guage":
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
                case "Guage":
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
                case "Guage":
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
                case "Guage":
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
                case "Guage":
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
                case "Guage":
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
                case "Guage":
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
                case "Guage":
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
                case "Guage":
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
                case "Guage":
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
                case "Guage":
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

        private void ResetGlobals()
        {
            lblUser1.Text = "User1";
            lblUser2.Text = "User2";
            lblUser3.Text = "User3";
            lblUser4.Text = "User4";
            Globals.flocation = "";
            Globals.flocationName = "";
            Globals.SpeedoNeedleWidth = ""; Globals.SpeedoNeedleLength = ""; Globals.SpeedoNeedleX = ""; Globals.SpeedoNeedleY = ""; Globals.SpeedoOffset = ""; Globals.SpeedoEnd = ""; Globals.SpeedoTop = ""; Globals.SpeedoTextX = ""; Globals.SpeedoTextY = ""; Globals.SpeedoFontSize = ""; Globals.SpeedoTextStyle = ""; Globals.SpeedoNeedle = "";
            Globals.TachoNeedleWidth = ""; Globals.TachoNeedleLength = ""; Globals.TachoNeedleX = ""; Globals.TachoNeedleY = ""; Globals.TachoOffset = ""; Globals.TachoEnd = ""; Globals.TachoTop = ""; Globals.TachoTextX = ""; Globals.TachoTextY = ""; Globals.TachoFontSize = ""; Globals.TachoTextStyle = ""; Globals.TachoNeedle = "";
            Globals.TempNeedleWidth = ""; Globals.TempNeedleLength = ""; Globals.TempNeedleX = ""; Globals.TempNeedleY = ""; Globals.TempOffset = ""; Globals.TempEnd = ""; Globals.TempTop = ""; Globals.TempTextX = ""; Globals.TempTextY = ""; Globals.TempFontSize = ""; Globals.TempTextStyle = ""; Globals.TempNeedle = "";
            Globals.OilNeedleWidth = ""; Globals.OilNeedleLength = ""; Globals.OilNeedleX = ""; Globals.OilNeedleY = ""; Globals.OilOffset = ""; Globals.OilEnd = ""; Globals.OilTop = ""; Globals.OilTextX = ""; Globals.OilTextY = ""; Globals.OilFontSize = ""; Globals.OilTextStyle = ""; Globals.OilNeedle = "";
            Globals.OilTNeedleWidth = ""; Globals.OilTNeedleLength = ""; Globals.OilTNeedleX = ""; Globals.OilTNeedleY = ""; Globals.OilTOffset = ""; Globals.OilTEnd = ""; Globals.OilTTop = ""; Globals.OilTTextX = ""; Globals.OilTTextY = ""; Globals.OilTFontSize = ""; Globals.OilTTextStyle = ""; Globals.OilTNeedle = "";
            Globals.FuelNeedleWidth = ""; Globals.FuelNeedleLength = ""; Globals.FuelNeedleX = ""; Globals.FuelNeedleY = ""; Globals.FuelOffset = ""; Globals.FuelEnd = ""; Globals.FuelTop = ""; Globals.FuelTextX = ""; Globals.FuelTextY = ""; Globals.FuelFontSize = ""; Globals.FuelTextStyle = ""; Globals.FuelNeedle = "";
            Globals.FuelTNeedleWidth = ""; Globals.FuelTNeedleLength = ""; Globals.FuelTNeedleX = ""; Globals.FuelTNeedleY = ""; Globals.FuelTOffset = ""; Globals.FuelTEnd = ""; Globals.FuelTTop = ""; Globals.FuelTTextX = ""; Globals.FuelTTextY = ""; Globals.FuelTFontSize = ""; Globals.FuelTTextStyle = ""; Globals.FuelTNeedle = "";
            Globals.FuelPNeedleWidth = ""; Globals.FuelPNeedleLength = ""; Globals.FuelPNeedleX = ""; Globals.FuelPNeedleY = ""; Globals.FuelPOffset = ""; Globals.FuelPEnd = ""; Globals.FuelPTop = ""; Globals.FuelPTextX = ""; Globals.FuelPTextY = ""; Globals.FuelPFontSize = ""; Globals.FuelPTextStyle = ""; Globals.FuelPNeedle = "";
            Globals.User1NeedleWidth = ""; Globals.User1NeedleLength = ""; Globals.User1NeedleX = ""; Globals.User1NeedleY = ""; Globals.User1Offset = ""; Globals.User1End = ""; Globals.User1Top = ""; Globals.User1TextX = ""; Globals.User1TextY = ""; Globals.User1FontSize = ""; Globals.User1TextStyle = ""; Globals.User1Needle = "";
            Globals.User2NeedleWidth = ""; Globals.User2NeedleLength = ""; Globals.User2NeedleX = ""; Globals.User2NeedleY = ""; Globals.User2Offset = ""; Globals.User2End = ""; Globals.User2Top = ""; Globals.User2TextX = ""; Globals.User2TextY = ""; Globals.User2FontSize = ""; Globals.User2TextStyle = ""; Globals.User2Needle = "";
            Globals.User3NeedleWidth = ""; Globals.User3NeedleLength = ""; Globals.User3NeedleX = ""; Globals.User3NeedleY = ""; Globals.User3Offset = ""; Globals.User3End = ""; Globals.User3Top = ""; Globals.User3TextX = ""; Globals.User3TextY = ""; Globals.User3FontSize = ""; Globals.User3TextStyle = ""; Globals.User3Needle = "";
            Globals.User4NeedleWidth = ""; Globals.User4NeedleLength = ""; Globals.User4NeedleX = ""; Globals.User4NeedleY = ""; Globals.User4Offset = ""; Globals.User4End = ""; Globals.User4Top = ""; Globals.User4TextX = ""; Globals.User4TextY = ""; Globals.User4FontSize = ""; Globals.User4TextStyle = ""; Globals.User4Needle = "";
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

    }
}