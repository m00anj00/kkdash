using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace kkdash
{
    public class WriteCSV
    {
        public static string symbolsize; public static string symbols1; public static string symbols2; public static string symbols3; public static string symbols4; public static string symbols5; public static string symbols6; public static string symbols7;

        //----------------------------------------------------------------------------InfoPanel---------------------------------------------------------------------------------
        private static string InfoPanel = "InfoPanel" + "," + Globals.InfoPanelX + "," + Globals.InfoPanelY + "," + Globals.InfoTextSize + "," + Globals.OdometerX + "," + Globals.OdometerY + "," + Globals.OdoReadingMilesKM + "," + Globals.EcoX + "," + Globals.EcoY + "," + Globals.EcoSize + "," + Globals.TripX + "," + Globals.TripY + "," + Globals.TripSize;

        public static void ShowSave(int panelno)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Globals.flocation;
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.FileName = "panel" + panelno + ".csv";
                saveFileDialog.Filter = "csv file (*.csv)|*.csv";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string currentDirectory = Path.GetDirectoryName(saveFileDialog.FileName);
                    Globals.flocation = Path.GetFullPath(currentDirectory);
                    Globals.flocationName = saveFileDialog.FileName;     
                }
            }

        }

        public static void writeSymbols()
        {
            symbolsize = "symbolsize" + "," + Globals.symWidth + "," + Globals.symHeight + ",,,,,,,,,,,,,,";
            symbols1 = "symbols1" + "," + Globals.symSidelights + "," + Globals.symSidelightsX + "," + Globals.symSidelightsY + "," + Globals.symSidelightsGPIO + "," + Globals.symHeadlights + "," + Globals.symHeadlightsX + "," + Globals.symHeadlightsY + "," + Globals.symHeadlightsGPIO + "," + Globals.symFullbeam +"," + Globals.symFullbeamX + "," + Globals.symFullbeamY + "," + Globals.symFullbeamGPIO + "," + Globals.symSpotlights +"," + Globals.symSpotlightsX + "," + Globals.symSpotlightsY + "," + Globals.symSpotlightsGPIO;
            symbols2 = "symbols2" + "," + Globals.symFoglights + "," + Globals.symFoglightsX + "," + Globals.symFoglightsY + "," + Globals.symFoglightsGPIO + "," + Globals.symBonnet  + "," + Globals.symBonnetX + "," + Globals.symBonnetY + "," + Globals.symBonnetGPIO + "," + Globals.symBoot  + "," + Globals.symBootX + "," + Globals.symBootY + "," + Globals.symBootGPIO + "," + Globals.symDoor + "," + Globals.symDoorX + "," + Globals.symDoorY + "," + Globals.symDoorGPIO;
            symbols3 = "symbols3" + "," + Globals.symFuel + "," + Globals.symFuelX + "," + Globals.symFuelY + "," + Globals.symFuelGPIO + "," + Globals.symBrakes + "," + Globals.symBrakesX + "," + Globals.symBrakesY + "," + Globals.symBrakesGPIO + "," + Globals.symTemp + "," + Globals.symTempX + "," + Globals.symTempY + "," + Globals.symTempGPIO + "," + Globals.symOil  + "," + Globals.symOilX + "," + Globals.symOilY + "," + Globals.symOilGPIO;
            symbols4 = "symbols4" + "," + Globals.symTyre + "," + Globals.symTyreX + "," + Globals.symTyreY + "," + Globals.symTyreGPIO + "," + Globals.symSpanner + "," + Globals.symSpannerX + "," + Globals.symSpannerY + "," + Globals.symSpannerGPIO + "," + Globals.symDemister + "," + Globals.symDemisterX + "," + Globals.symDemisterY + "," + Globals.symDemisterGPIO + "," + Globals.symWasher + "," + Globals.symWasherX + "," + Globals.symWasherY + "," + Globals.symWasherGPIO;
            symbols5 = "symbols5" + "," + Globals.symHazards + "," + Globals.symHazardsX + "," + Globals.symHazardsY + "," + Globals.symHazardsGPIO + "," + Globals.symIndLeft + "," + Globals.symIndLeftX + "," + Globals.symIndLeftY + "," + Globals.symIndLeftGPIO + "," + Globals.symIndRight + "," + Globals.symIndRightX + "," + Globals.symIndRightY + "," + Globals.symIndRightGPIO + "," + Globals.symSeatbelt + "," + Globals.symSeatbeltX + "," + Globals.symSeatbeltY + "," + Globals.symSeatbeltGPIO;
            symbols6 = "symbols6" + "," + Globals.symSeatRight + "," + Globals.symSeatRightX + "," + Globals.symSeatRightY + "," + Globals.symSeatRightGPIO + "," + Globals.symSeatLeft + "," + Globals.symSeatLeftX + "," + Globals.symSeatLeftY + "," + Globals.symSeatLeftGPIO + "," + Globals.symBoot + "," + Globals.symBootX + "," + Globals.symBootY + "," + Globals.symBootGPIO + "," + Globals.symBattery + "," + Globals.symBatteryX + "," + Globals.symBatteryY + "," + Globals.symBatteryGPIO;
            symbols7 = "symbols7" + "," + Globals.symWiperInt + "," + Globals.symWiperIntX + "," + Globals.symWiperIntY + "," + Globals.symWiperIntGPIO;
        }

        public static void WriteCSVfile(int PanelNo)
        {
            string PNO = "";
            string speedoval = "", tachoval = "", boostval = "", tempval = "", oilval = "", oiltval = "", fuelval = "", fueltval = "", fuelpval = "", batteryval = "", user1val = "", user2val = "", user3val = "", user4val = "";
            string strSeperator = ",";
            string strFilePath = "";
            string disptxt = "";
            string p1conn = ""; string p2conn = ""; string p3conn = "";
            string pantxt = "";
            writeSymbols();

            StringBuilder saOutput = new StringBuilder();

            switch (PanelNo)
            {
                case 1:
                    if (Globals.flocation == "")
                    {
                        ShowSave(1);
                    }
                    disptxt = "1," + Globals.p1DispWidth + "," + Globals.p1DispHeight + ",60,,,,,,,,,,,";
                    strFilePath = Globals.flocation + "\\Panel1.csv";
                    PNO = PanelNo.ToString();
                    speedoval = Globals.Speedovalp1;
                    tachoval = Globals.Tachovalp1;
                    boostval = Globals.Boostvalp1;
                    tempval = Globals.Tempvalp1;
                    oilval = Globals.Oilvalp1;
                    oiltval = Globals.OilTvalp1;
                    fuelval = Globals.Fuelvalp1;
                    fueltval = Globals.FuelTvalp1;
                    fuelpval = Globals.FuelPvalp1;
                    batteryval = Globals.Batteryvalp1;
                    user1val = Globals.User1valp1;
                    user2val = Globals.User2valp1;
                    user3val = Globals.User3valp1;
                    user4val = Globals.User4valp1;

                    p1conn = Globals.p1connection;
                    p2conn = Globals.p2connection;
                    p3conn = Globals.p3connection;
                    pantxt = "Background," + Globals.P1BG + ",,,,,,,,,,,,,,";


                    PNO = "1";
                    break;

                case 2:
                    if (Globals.flocation == "")
                    {
                        ShowSave(2);
                    }
                    disptxt = "2," + Globals.p2DispWidth + "," + Globals.p2DispHeight + ",60,,,,,,,,,,,";
                    strFilePath = Globals.flocation + "\\Panel2.csv";
                    PNO = PanelNo.ToString();
                    speedoval = Globals.Speedovalp2;
                    tachoval = Globals.Tachovalp2;
                    boostval = Globals.Boostvalp2;
                    tempval = Globals.Tempvalp2;
                    oilval = Globals.Oilvalp2;
                    oiltval = Globals.OilTvalp2;
                    fuelval = Globals.Fuelvalp2;
                    fueltval = Globals.FuelTvalp2;
                    fuelpval = Globals.FuelPvalp2;
                    batteryval = Globals.Batteryvalp2;
                    user1val = Globals.User1valp1;
                    user2val = Globals.User2valp1;
                    user3val = Globals.User3valp1;
                    user4val = Globals.User4valp1;
                    pantxt = "Background," + Globals.P2BG + ",,,,,,,,,,,,,,";

                    PNO = "2";
                    break;

                case 3:
                    if (Globals.flocation == "")
                    {
                        ShowSave(3);
                    }
                    disptxt = "3," + Globals.p3DispWidth + "," + Globals.p3DispHeight + ",60,,,,,,,,,,,";
                    strFilePath = Globals.flocation + "\\Panel3.csv";
                    PNO = PanelNo.ToString();
                    speedoval = Globals.Speedovalp3;
                    tachoval = Globals.Tachovalp3;
                    boostval = Globals.Boostvalp3;
                    tempval = Globals.Tempvalp3;
                    oilval = Globals.Oilvalp3;
                    oiltval = Globals.OilTvalp3;
                    fuelval = Globals.Fuelvalp3;
                    fueltval = Globals.FuelTvalp3;
                    fuelpval = Globals.FuelPvalp3;
                    batteryval = Globals.Batteryvalp3;
                    user1val = Globals.User1valp1;
                    user2val = Globals.User2valp1;
                    user3val = Globals.User3valp1;
                    user4val = Globals.User4valp1;
                    pantxt = "Background," + Globals.P3BG + ",,,,,,,,,,,,,,";

                    PNO = "3";
                    break;
            }
        
        string[][] inaOutput = new string[][] {
                new string[] { "panel," + PNO + ",,,,,,,,,,,,," },
                new string[] { ",,,,,,,,,,,,,," },
                new string[] { "#DISPLAY PARAMETERS,,,,,,,,,,,,,," },
                new string[] { "#pos x=0,y=0 is the center of the display,,,,,,,,,,,,," },
                new string[] { "#displaysize,w,h,refresh rate,,,,,,,,,,," },
                new string[] { disptxt },
                new string[] { "#background,pic" },
                new string[] { pantxt },
                new string[] { ",,,,,,,,,,,,,," },
                new string[] { "#CAN connection #see: https://python-can.readthedocs.io/en/stable/configuration.html" },
                new string[] { "#All connections instigated from panel 1 only.  Panel1 pings for panel2/3 via ethernet.  if found will try autoconnection" },
                new string[] { "#ECU con,ECU interface,ECU speed," },
                new string[] { p1conn },
                new string[] { p2conn },
                new string[] { p3conn },
                new string[] { ",,,,,,,,,,,,,," },
                new string[] { "#GAUGE / BAR GRAPH,,,,,,,,,,,,,," },
                new string[] { "#GAUGE STYLE:" },
                new string[] { "#name,show,needle width,needle height,needlex,needley,offset,degreesend,topval,textshow,textX,textY,fontsize,fontstyle,type,needle image" },
                new string[] { "#BAR GRAPH STYLE: (barV or barH)" },
                new string[] { "#name,show,bar width(V),bar height(H),gaugex,gaugey,warn%,guageend,topval,textshow,textX,textY,fontsize,fontstyle,type (barV/barH),0=warn% below-1=warn% above" },
                new string[] { ",,,,,,,,,,,,,," },
                new string[] { "Userdefined", Globals.User1name, Globals.User2name, Globals.User3name, Globals.User4name, ",,,,,,,,," },
                new string[] { "Offsets", Globals.SpeedoCanOffset, Globals.TachoCanOffset, Globals.BoostCanOffset, Globals.TempCanOffset, Globals.OilCanOffset, Globals.OilTCanOffset, Globals.FuelCanOffset, Globals.FuelTCanOffset, Globals.FuelPCanOffset, Globals.BatteryCanOffset, Globals.User1CanOffset, Globals.User2CanOffset, Globals.User3CanOffset, Globals.User4CanOffset, },
                new string[] { "#Speedo:",",,,,,,,,,,,,," },
                new string[] { speedoval },
                new string[] { "#Tacho:",",,,,,,,,,,,,," },
                new string[] { tachoval },
                new string[] { "#Boost:",",,,,,,,,,,,,," },
                new string[] { boostval },
                new string[] { "#Temp:",",,,,,,,,,,,,," },
                new string[] { tempval },
                new string[] { "#Oil:",",,,,,,,,,,,,," },
                new string[] { oilval },
                new string[] { "#OilTemp:",",,,,,,,,,,,,," },
                new string[] { oiltval },
                new string[] { "#FuelLevel:",",,,,,,,,,,,,," },
                new string[] { fuelval },
                new string[] { "#FuelTemp:",",,,,,,,,,,,,," },
                new string[] { fueltval },
                new string[] { "#FuelPressure:",",,,,,,,,,,,,," },
                new string[] { fuelpval },
                new string[] { "#Battery:",",,,,,,,,,,,,," },
                new string[] { batteryval },
                new string[] { "#User1:",",,,,,,,,,,,,," },
                new string[] { user1val },
                new string[] { "#User2:",",,,,,,,,,,,,," },
                new string[] { user2val },
                new string[] { "#User3:",",,,,,,,,,,,,," },
                new string[] { user3val },
                new string[] { "#User4:",",,,,,,,,,,,,," },
                new string[] { user4val },
                new string[] { ",,,,,,,,,,,,,," },
                new string[] { "#WARNING AND INFO LIGHTS:" },
                new string[] { "#symbolsX,item,X,Y,GPIO,item,X,Y,GPIO,item,X,Y,GPIO,item,X,Y,GPIO," },
                new string[] { symbolsize },
                new string[] { symbols1 },
                new string[] { symbols2 },
                new string[] { symbols3 },
                new string[] { symbols4 },
                new string[] { symbols5 },
                new string[] { symbols6 },
                new string[] { symbols7 },
                new string[] { "#CENTRAL PANEL CRITERIA, ODOMETER, TRIP" },
                new string[] { ",,,,,,,,,,,,,," },
                new string[] { InfoPanel },
        };
            try
            {
                int ilength = inaOutput.GetLength(0);
                for (int i = 0; i < ilength; i++)
                {
                    saOutput.AppendLine(string.Join(strSeperator, inaOutput[i]));
                    File.WriteAllText(strFilePath, saOutput.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to write Panel" + PanelNo + " config file");
            }
        }
    }
}
