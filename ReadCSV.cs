using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace dashconfigurator
{
    public class ReadCSV
    {
        public static void ReadTheCSV(int PanelNo)
        {
            if (PanelNo == 1)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "panel1 configuration file (*.*)|*.*|(*.csv)|*.csv";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.FileName = "panel1.csv";
                    try
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            //Get the filename only from the path of specified file
                            Globals.ConfigFileName = openFileDialog.FileName;
                            using (StreamReader sr = new StreamReader(Globals.ConfigFileName))
                            {
                                string currentLine;
                                while ((currentLine = sr.ReadLine()) != null)
                                {
                                    int count = currentLine.Split(',').Length - 1;
                                    if (count > 2)
                                    {
                                        string[] items = currentLine.Split(',');
                                        //gauges and bars
                                        if ((items[0].ToLower() == "speedo") || (items[0].ToLower() == "tacho") || (items[0].ToLower() == "boost") || (items[0].ToLower() == "temp") || (items[0].ToLower() == "oil") || (items[0].ToLower() == "oilt") || (items[0].ToLower() == "fuel"))
                                        {
                                            popReadGauges(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15]);
                                        }
                                        if ((items[0].ToLower() == "fuelt") || (items[0].ToLower() == "fuelp") || (items[0].ToLower() == "user1") || (items[0].ToLower() == "user2") || (items[0].ToLower() == "user3") || (items[0].ToLower() == "user4"))
                                        {
                                            popReadGauges(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15]);
                                        }
                                        if (items[0].ToLower() == "SerCanP1Ecu")
                                        {
                                            //ECU connection: SerCanP1Ecu, SerCanPortP1Ecu, SerCanSpeedP1Ecu, SerCanAddressP1Ecu, SerCanEnabledP1P2, SerCanP1P2, SerCanPortP1P2, SerCanSpeedP1P2, SerCanAddressP1P2, SerCanEnabledP1P3, SerCanP1P3, SerCanPortP1P3, SerCanSpeedP1P3, SerCanAddressP1P3,,                 

                                        }
                                        if (items[0].ToLower() == "SerCanP1P2")
                                        {
                                            //Panel 2 connection: SerCanP2P1, SerCanPortP2P1, SerCanSpeedP2P1, SerCanAddressP2P1      

                                        }
                                        if (items[0].ToLower() == "SerCanP1P3")
                                        {
                                            //Panel 3 connection

                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cannot open panel1.csv file.");
                    }

                }
            }

            if (PanelNo == 2)
            {
                if (File.Exists(Globals.ConfigFileName + "\\panel2.csv"))
                {
                    try
                    {

                        using (StreamReader sr = new StreamReader(Globals.ConfigFileName + "\\panel2.csv"))
                        {
                            string currentLine;
                            while ((currentLine = sr.ReadLine()) != null)
                            {
                                int count = currentLine.Split(',').Length - 1;
                                if (count > 2)
                                {

                                    string[] items = currentLine.Split(',');
                                    if ((items[0].ToLower() == "speedo") || (items[0].ToLower() == "tacho") || (items[0].ToLower() == "boost") || (items[0].ToLower() == "temp") || (items[0].ToLower() == "oil") || (items[0].ToLower() == "oilt") || (items[0].ToLower() == "fuel"))
                                    {
                                        popReadGauges(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15]);
                                    }
                                    if ((items[0].ToLower() == "fuelt") || (items[0].ToLower() == "fuelp") || (items[0].ToLower() == "user1") || (items[0].ToLower() == "user2") || (items[0].ToLower() == "user3") || (items[0].ToLower() == "user4"))
                                    {
                                        popReadGauges(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15]);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cannot open panel2.csv file.");
                    }
                } 
            }

            if (PanelNo == 3)
            {
                if (File.Exists(Globals.ConfigFileName + "\\panel3.csv"))
                {
                    try
                    {

                        using (StreamReader sr = new StreamReader(Globals.ConfigFileName + "\\panel3.csv"))
                        {
                            string currentLine;
                            while ((currentLine = sr.ReadLine()) != null)
                            {
                                int count = currentLine.Split(',').Length - 1;
                                if (count > 2)
                                {

                                    string[] items = currentLine.Split(',');
                                    if ((items[0].ToLower() == "speedo") || (items[0].ToLower() == "tacho") || (items[0].ToLower() == "boost") || (items[0].ToLower() == "temp") || (items[0].ToLower() == "oil") || (items[0].ToLower() == "oilt") || (items[0].ToLower() == "fuel"))
                                    {
                                        popReadGauges(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15]);
                                    }
                                    if ((items[0].ToLower() == "fuelt") || (items[0].ToLower() == "fuelp") || (items[0].ToLower() == "user1") || (items[0].ToLower() == "user2") || (items[0].ToLower() == "user3") || (items[0].ToLower() == "user4"))
                                    {
                                        popReadGauges(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15]);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cannot open panel3.csv file.");
                    }
                }
            }
        }


        //--------------------------------------------------------------------------set the panel according to the gauge / text box-----------------------------------------------------------------
        public static void popReadGauges(string gaugename, string itemShow, string itemNeedleWidth, string itemNeedleLength, string itemNeedleX, string itemNeedleY, string itemOffset, string itemEnd, string itemTop, string itemTextShow, string itemTextX, string itemTextY, string itemFontSize, string itemTextStyle, string itemNeedleType, string itemNeedle)
        {
            //                          0                           1                                 2                                 3                              4                             5                           6                              7                         8                           9                              10                         11                           12                              13                             14                              15                                                                                        
            //Globals.Speedovalp1 = Globals.gaugename + "," + Globals.SpeedoShow1 + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow1 + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle;
            switch (gaugename)
            {
                case "speedo":
                    {
                        if (itemShow == "1") { Globals.SpeedoShow = "1"; }
                        if (itemShow == "2") { Globals.SpeedoShow = "2"; }
                        if (itemShow == "3") { Globals.SpeedoShow = "3"; }

                        if (itemTextShow == "1") { Globals.SpeedoTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.SpeedoTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.SpeedoTextShow = "3"; }
                        break;
                    }

                    case "Tacho":
                    {
                        if (itemShow == "1") { Globals.TachoShow = "1"; }
                        if (itemShow == "2") { Globals.TachoShow = "2"; }
                        if (itemShow == "3") { Globals.TachoShow = "3"; }

                        if (itemTextShow == "1") { Globals.TachoTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.TachoTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.TachoTextShow = "3"; }
                        break;
                    }

                case "Boost":
                    {
                        if (itemShow == "1") { Globals.BoostShow = "1"; }
                        if (itemShow == "2") { Globals.BoostShow = "2"; }
                        if (itemShow == "3") { Globals.BoostShow = "3"; }

                        if (itemTextShow == "1") { Globals.BoostTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.BoostTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.BoostTextShow = "3"; }
                        break;
                    }

                case "Temp":
                    {
                        if (itemShow == "1") { Globals.TempShow = "1"; }
                        if (itemShow == "2") { Globals.TempShow = "2"; }
                        if (itemShow == "3") { Globals.TempShow = "3"; }

                        if (itemTextShow == "1") { Globals.TempTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.TempTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.TempTextShow = "3"; }
                        break;
                    }

                case "Oil":
                    {
                        if (itemShow == "1") { Globals.OilShow = "1"; }
                        if (itemShow == "2") { Globals.OilShow = "2"; }
                        if (itemShow == "3") { Globals.OilShow = "3"; }

                        if (itemTextShow == "1") { Globals.OilTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.OilTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.OilTextShow = "3"; }
                        break;
                    }

                case "OilT":
                    {
                        if (itemShow == "1") { Globals.OilTShow = "1"; }
                        if (itemShow == "2") { Globals.OilTShow = "2"; }
                        if (itemShow == "3") { Globals.OilTShow = "3"; }

                        if (itemTextShow == "1") { Globals.OilTTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.OilTTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.OilTTextShow = "3"; }
                        break;
                    }

                case "Fuel":
                    {
                        if (itemShow == "1") { Globals.FuelShow = "1"; }
                        if (itemShow == "2") { Globals.FuelShow = "2"; }
                        if (itemShow == "3") { Globals.FuelShow = "3"; }

                        if (itemTextShow == "1") { Globals.FuelTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.FuelTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.FuelTextShow = "3"; }
                        break;
                    }

                case "FuelT":
                    {
                        if (itemShow == "1") { Globals.FuelTShow = "1"; }
                        if (itemShow == "2") { Globals.FuelTShow = "2"; }
                        if (itemShow == "3") { Globals.FuelTShow = "3"; }

                        if (itemTextShow == "1") { Globals.FuelTTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.FuelTTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.FuelTTextShow = "3"; }
                        break;
                    }

                case "FuelP":
                    {
                        if (itemShow == "1") { Globals.FuelPShow = "1"; }
                        if (itemShow == "2") { Globals.FuelPShow = "2"; }
                        if (itemShow == "3") { Globals.FuelPShow = "3"; }

                        if (itemTextShow == "1") { Globals.FuelPTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.FuelPTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.FuelPTextShow = "3"; }
                        break;
                    }

                case "User1":
                    {
                        if (itemShow == "1") { Globals.User1Show = "1"; }
                        if (itemShow == "2") { Globals.User1Show = "2"; }
                        if (itemShow == "3") { Globals.User1Show = "3"; }

                        if (itemTextShow == "1") { Globals.User1TextShow = "1"; }
                        if (itemTextShow == "2") { Globals.User1TextShow = "2"; }
                        if (itemTextShow == "3") { Globals.User1TextShow = "3"; }
                        break;
                    }

                case "User2":
                    {
                        if (itemShow == "1") { Globals.User2Show = "1"; }
                        if (itemShow == "2") { Globals.User2Show = "2"; }
                        if (itemShow == "3") { Globals.User2Show = "3"; }

                        if (itemTextShow == "1") { Globals.User2TextShow = "1"; }
                        if (itemTextShow == "2") { Globals.User2TextShow = "2"; }
                        if (itemTextShow == "3") { Globals.User2TextShow = "3"; }
                        break;
                    }

                case "User3":
                    {
                        if (itemShow == "1") { Globals.User3Show = "1"; }
                        if (itemShow == "2") { Globals.User3Show = "2"; }
                        if (itemShow == "3") { Globals.User3Show = "3"; }

                        if (itemTextShow == "1") { Globals.User3TextShow = "1"; }
                        if (itemTextShow == "2") { Globals.User3TextShow = "2"; }
                        if (itemTextShow == "3") { Globals.User3TextShow = "3"; }
                        break;
                    }

                case "User4":
                    {
                        if (itemShow == "1") { Globals.User4Show = "1"; }
                        if (itemShow == "2") { Globals.User4Show = "2"; }
                        if (itemShow == "3") { Globals.User4Show = "3"; }

                        if (itemTextShow == "1") { Globals.User4TextShow = "1"; }
                        if (itemTextShow == "2") { Globals.User4TextShow = "2"; }
                        if (itemTextShow == "3") { Globals.User4TextShow = "3"; }
                        break;
                    }
            }
        }
    }
}
