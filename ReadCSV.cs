using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic; //for isNumeric()

namespace kkdash
{
    public class ReadCSV
    {
        public static void ReadTheCSV(int PanelNo)
        {
            if (PanelNo == 1)
            {
                try
                {
                    //Get the filename only from the path of specified file
                    using (StreamReader sr = new StreamReader(Globals.flocation + "\\Panel1.csv"))
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
                                if (items[0] == "1") { Globals.p1DispWidth = items[1]; Globals.p1DispHeight = items[2]; }

                                if (items[0] == "Background") { Globals.P1BG = items[1]; }
                                if (items[0] == "Userdefined")
                                {
                                    Globals.User1name = items[1]; Globals.User2name = items[2]; Globals.User3name = items[3]; Globals.User4name = items[4]; Globals.User1CanOffset = items[5]; Globals.User2CanOffset = items[6]; Globals.User3CanOffset = items[7]; Globals.User4CanOffset = items[8];
                                }
                                if (items[0].ToLower() == "ecuconnection")
                                {
                                    //Globals.p1connection = "ecuconnection," + Globals.SerCanP1Ecu + "," + Globals.SerCanPortP1Ecu + "," + Globals.SerCanSpeedP1Ecu + "," + Globals.SerCanAddressP1Ecu + "," + Globals.PanelIP1 + "," + Globals.SerCanAddressP1;
                                    Globals.SerCanP1Ecu = items[1]; Globals.SerCanPortP1Ecu = items[2]; Globals.SerCanSpeedP1Ecu = items[3]; Globals.SerCanAddressP1Ecu = items[4]; Globals.PanelIP1 = items[5]; Globals.SerCanAddressP1 = items[6];
                                }
                                if (items[0].ToLower() == "p2connection")
                                {
                                    //Globals.p2connection = "p2connection " + Globals.SerCanP1P2 + "," + Globals.SerCanPortP1P2 + "," + Globals.SerCanSpeedP1P2 + "," + Globals.SerCanAddressP1P2 + "," + Globals.PanelIP2;
                                    Globals.SerCanP1P2 = items[1]; Globals.SerCanPortP1P2 = items[2]; Globals.SerCanSpeedP1P2 = items[3]; Globals.SerCanAddressP1P2 = items[4]; Globals.PanelIP2 = items[5];
                                }
                                if (items[0].ToLower() == "p3connection")
                                {
                                    //Globals.p3connection = "p3connection" + Globals.SerCanP1P3 + "," + Globals.SerCanPortP1P3 + "," + Globals.SerCanSpeedP1P3 + "," + Globals.SerCanAddressP1P3 + "," + Globals.PanelIP3;
                                    Globals.SerCanP1P3 = items[1]; Globals.SerCanPortP1P3 = items[2]; Globals.SerCanSpeedP1P3 = items[3]; Globals.SerCanAddressP1P3 = items[4]; Globals.PanelIP3 = items[5];
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

            if (PanelNo == 2)
            {
                if (File.Exists(Globals.flocation + "\\panel2.csv"))
                {
                    try
                    {
                        Console.WriteLine("reading panel2.csv");

                        using (StreamReader sr = new StreamReader(Globals.flocation + "\\Panel2.csv"))
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
                                    if (items[0] == "2") { Globals.p2DispWidth = items[1]; Globals.p2DispHeight = items[2]; }
                                    if (items[0] == "Background") { Globals.P2BG = items[1]; }
                                    if (items[0] == "Userdefined")
                                    {
                                        Globals.User1name = items[1];
                                        Globals.User2name = items[2];
                                        Globals.User3name = items[3];
                                        Globals.User4name = items[4];
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
                if (File.Exists(Globals.flocation + "\\panel3.csv"))
                {
                    Console.WriteLine("reading panel3.csv");
                    try
                    {

                        using (StreamReader sr = new StreamReader(Globals.flocation + "\\Panel3.csv"))
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
                                    if (items[0] == "3") { Globals.p3DispWidth = items[1]; Globals.p3DispHeight = items[2]; }
                                    if (items[0] == "Background") { Globals.P3BG = items[1]; }
                                    if (items[0] == "Userdefined")
                                    {
                                        Globals.User1name = items[1];
                                        Globals.User2name = items[2];
                                        Globals.User3name = items[3];
                                        Globals.User4name = items[4];
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

                        if ((itemShow == "1") || (itemShow == "2") || (itemShow == "3"))
                        {
                            Globals.SpeedoNeedleWidth = itemNeedleWidth;
                            Globals.SpeedoNeedleLength = itemNeedleLength;
                            Globals.SpeedoNeedleX = itemNeedleX;
                            Globals.SpeedoNeedleY = itemNeedleY;
                            Globals.SpeedoOffset = itemOffset;
                            Globals.SpeedoEnd = itemEnd;
                            Globals.SpeedoTop = itemTop;
                            Globals.SpeedoNeedleType = itemNeedleType;
                            Globals.SpeedoNeedle = itemNeedle;
                        }
                        else
                        {
                            Globals.SpeedoNeedleWidth = "0";
                            Globals.SpeedoNeedleLength = "0";
                            Globals.SpeedoNeedleX = "0";
                            Globals.SpeedoNeedleY = "0";
                            Globals.SpeedoOffset = "0";
                            Globals.SpeedoEnd = "0";
                            Globals.SpeedoTop = "0";
                            Globals.SpeedoNeedleType = "0";
                            Globals.SpeedoNeedle = "0";
                        }

                        if (itemTextShow == "1") { Globals.SpeedoTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.SpeedoTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.SpeedoTextShow = "3"; }
                        if ((itemTextShow == "1") || (itemTextShow == "2") || (itemTextShow == "3"))
                        {
                            Globals.SpeedoTextX = itemTextX;
                            Globals.SpeedoTextY = itemTextY;
                            Globals.SpeedoFontSize = itemFontSize;
                            Globals.SpeedoTextStyle = itemTextStyle;
                        }
                        else 
                        {
                            Globals.SpeedoTextX = "0";
                            Globals.SpeedoTextY = "0";
                            Globals.SpeedoFontSize = "0";
                            Globals.SpeedoTextStyle = "0";
                        }
                        break;
                    }

                case "Tacho":
                    {
                        if (itemShow == "1") { Globals.TachoShow = "1"; }
                        if (itemShow == "2") { Globals.TachoShow = "2"; }
                        if (itemShow == "3") { Globals.TachoShow = "3"; }
                        if ((itemShow == "1") || (itemShow == "2") || (itemShow == "3"))
                        {
                            Globals.TachoNeedleWidth = itemNeedleWidth;
                            Globals.TachoNeedleLength = itemNeedleLength;
                            Globals.TachoNeedleX = itemNeedleX;
                            Globals.TachoNeedleY = itemNeedleY;
                            Globals.TachoOffset = itemOffset;
                            Globals.TachoEnd = itemEnd;
                            Globals.TachoTop = itemTop;
                            Globals.TachoNeedleType = itemNeedleType;
                            Globals.TachoNeedle = itemNeedle;
                        }
                        else
                        {
                            Globals.TachoNeedleWidth = "0";
                            Globals.TachoNeedleLength = "0";
                            Globals.TachoNeedleX = "0";
                            Globals.TachoNeedleY = "0";
                            Globals.TachoOffset = "0";
                            Globals.TachoEnd = "0";
                            Globals.TachoTop = "0";
                            Globals.TachoNeedleType = "0";
                            Globals.TachoNeedle = "0";
                        }

                        if (itemTextShow == "1") { Globals.TachoTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.TachoTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.TachoTextShow = "3"; }
                        if ((itemTextShow == "1") || (itemTextShow == "2") || (itemTextShow == "3"))
                        {
                            Globals.TachoTextX = itemTextX;
                            Globals.TachoTextY = itemTextY;
                            Globals.TachoFontSize = itemFontSize;
                            Globals.TachoTextStyle = itemTextStyle;
                        }
                        else
                        {
                            Globals.TachoTextX = "0";
                            Globals.TachoTextY = "0";
                            Globals.TachoFontSize = "0";
                            Globals.TachoTextStyle = "0";
                        }
                        break;
                    }

                case "Boost":
                    {
                        if (itemShow == "1") { Globals.BoostShow = "1"; }
                        if (itemShow == "2") { Globals.BoostShow = "2"; }
                        if (itemShow == "3") { Globals.BoostShow = "3"; }
                        if ((itemShow == "1") || (itemShow == "2") || (itemShow == "3"))
                        {
                            Globals.BoostNeedleWidth = itemNeedleWidth;
                            Globals.BoostNeedleLength = itemNeedleLength;
                            Globals.BoostNeedleX = itemNeedleX;
                            Globals.BoostNeedleY = itemNeedleY;
                            Globals.BoostOffset = itemOffset;
                            Globals.BoostEnd = itemEnd;
                            Globals.BoostTop = itemTop;
                            Globals.BoostNeedleType = itemNeedleType;
                            Globals.BoostNeedle = itemNeedle;
                        }
                        else
                        {
                            Globals.BoostNeedleWidth = "0";
                            Globals.BoostNeedleLength = "0";
                            Globals.BoostNeedleX = "0";
                            Globals.BoostNeedleY = "0";
                            Globals.BoostOffset = "0";
                            Globals.BoostEnd = "0";
                            Globals.BoostTop = "0";
                            Globals.BoostNeedleType = "0";
                            Globals.BoostNeedle = "0";
                        }

                        if (itemTextShow == "1") { Globals.BoostTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.BoostTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.BoostTextShow = "3"; }
                        if ((itemTextShow == "1") || (itemTextShow == "2") || (itemTextShow == "3"))
                        {
                            Globals.BoostTextX = itemTextX;
                            Globals.BoostTextY = itemTextY;
                            Globals.BoostFontSize = itemFontSize;
                            Globals.BoostTextStyle = itemTextStyle;
                        }
                        else
                        {
                            Globals.BoostTextX = "0";
                            Globals.BoostTextY = "0";
                            Globals.BoostFontSize = "0";
                            Globals.BoostTextStyle = "0";
                        }
                        break;
                    }

                case "Temp":
                    {
                        if (itemShow == "1") { Globals.TempShow = "1"; }
                        if (itemShow == "2") { Globals.TempShow = "2"; }
                        if (itemShow == "3") { Globals.TempShow = "3"; }
                        if ((itemShow == "1") || (itemShow == "2") || (itemShow == "3"))
                        {
                            Globals.TempNeedleWidth = itemNeedleWidth;
                            Globals.TempNeedleLength = itemNeedleLength;
                            Globals.TempNeedleX = itemNeedleX;
                            Globals.TempNeedleY = itemNeedleY;
                            Globals.TempOffset = itemOffset;
                            Globals.TempEnd = itemEnd;
                            Globals.TempTop = itemTop;
                            Globals.TempNeedleType = itemNeedleType;
                            Globals.TempNeedle = itemNeedle;
                        }
                        else
                        {
                            Globals.TempNeedleWidth = "0";
                            Globals.TempNeedleLength = "0";
                            Globals.TempNeedleX = "0";
                            Globals.TempNeedleY = "0";
                            Globals.TempOffset = "0";
                            Globals.TempEnd = "0";
                            Globals.TempTop = "0";
                            Globals.TempNeedleType = "0";
                            Globals.TempNeedle = "0";
                        }

                        if (itemTextShow == "1") { Globals.TempTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.TempTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.TempTextShow = "3"; }
                        if ((itemTextShow == "1") || (itemTextShow == "2") || (itemTextShow == "3"))
                        {
                            Globals.TempTextX = itemTextX;
                            Globals.TempTextY = itemTextY;
                            Globals.TempFontSize = itemFontSize;
                            Globals.TempTextStyle = itemTextStyle;
                        }
                        else
                        {
                            Globals.TempTextX = "0";
                            Globals.TempTextY = "0";
                            Globals.TempFontSize = "0";
                            Globals.TempTextStyle = "0";
                        }
                        break;
                    }

                case "Oil":
                    {
                        if (itemShow == "1") { Globals.OilShow = "1"; }
                        if (itemShow == "2") { Globals.OilShow = "2"; }
                        if (itemShow == "3") { Globals.OilShow = "3"; }
                        if ((itemShow == "1") || (itemShow == "2") || (itemShow == "3"))
                        {
                            Globals.OilNeedleWidth = itemNeedleWidth;
                            Globals.OilNeedleLength = itemNeedleLength;
                            Globals.OilNeedleX = itemNeedleX;
                            Globals.OilNeedleY = itemNeedleY;
                            Globals.OilOffset = itemOffset;
                            Globals.OilEnd = itemEnd;
                            Globals.OilTop = itemTop;
                            Globals.OilNeedleType = itemNeedleType;
                            Globals.OilNeedle = itemNeedle;
                        }
                        else
                        {
                            Globals.OilNeedleWidth = "0";
                            Globals.OilNeedleLength = "0";
                            Globals.OilNeedleX = "0";
                            Globals.OilNeedleY = "0";
                            Globals.OilOffset = "0";
                            Globals.OilEnd = "0";
                            Globals.OilTop = "0";
                            Globals.OilNeedleType = "0";
                            Globals.OilNeedle = "0";
                        }

                        if (itemTextShow == "1") { Globals.OilTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.OilTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.OilTextShow = "3"; }
                        if ((itemTextShow == "1") || (itemTextShow == "2") || (itemTextShow == "3"))
                        {
                            Globals.OilTextX = itemTextX;
                            Globals.OilTextY = itemTextY;
                            Globals.OilFontSize = itemFontSize;
                            Globals.OilTextStyle = itemTextStyle;
                        }
                        else
                        {
                            Globals.OilTextX = "0";
                            Globals.OilTextY = "0";
                            Globals.OilFontSize = "0";
                            Globals.OilTextStyle = "0";
                        }
                        break;
                    }

                case "OilT":
                    {
                        if (itemShow == "1") { Globals.OilTShow = "1"; }
                        if (itemShow == "2") { Globals.OilTShow = "2"; }
                        if (itemShow == "3") { Globals.OilTShow = "3"; }
                        if ((itemShow == "1") || (itemShow == "2") || (itemShow == "3"))
                        {
                            Globals.OilTNeedleWidth = itemNeedleWidth;
                            Globals.OilTNeedleLength = itemNeedleLength;
                            Globals.OilTNeedleX = itemNeedleX;
                            Globals.OilTNeedleY = itemNeedleY;
                            Globals.OilTOffset = itemOffset;
                            Globals.OilTEnd = itemEnd;
                            Globals.OilTTop = itemTop;
                            Globals.OilTNeedleType = itemNeedleType;
                            Globals.OilTNeedle = itemNeedle;
                        }
                        else
                        {
                            Globals.OilTNeedleWidth = "0";
                            Globals.OilTNeedleLength = "0";
                            Globals.OilTNeedleX = "0";
                            Globals.OilTNeedleY = "0";
                            Globals.OilTOffset = "0";
                            Globals.OilTEnd = "0";
                            Globals.OilTTop = "0";
                            Globals.OilTNeedleType = "0";
                            Globals.OilTNeedle = "0";
                        }

                        if (itemTextShow == "1") { Globals.OilTTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.OilTTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.OilTTextShow = "3"; }
                        if ((itemTextShow == "1") || (itemTextShow == "2") || (itemTextShow == "3"))
                        {
                            Globals.OilTTextX = itemTextX;
                            Globals.OilTTextY = itemTextY;
                            Globals.OilTFontSize = itemFontSize;
                            Globals.OilTTextStyle = itemTextStyle;
                        }
                        else
                        {
                            Globals.OilTTextX = "0";
                            Globals.OilTTextY = "0";
                            Globals.OilTFontSize = "0";
                            Globals.OilTTextStyle = "0";
                        }
                        break;
                    }

                case "Fuel":
                    {
                        if (itemShow == "1") { Globals.FuelShow = "1"; }
                        if (itemShow == "2") { Globals.FuelShow = "2"; }
                        if (itemShow == "3") { Globals.FuelShow = "3"; }
                        if ((itemShow == "1") || (itemShow == "2") || (itemShow == "3"))
                        {
                            Globals.FuelNeedleWidth = itemNeedleWidth;
                            Globals.FuelNeedleLength = itemNeedleLength;
                            Globals.FuelNeedleX = itemNeedleX;
                            Globals.FuelNeedleY = itemNeedleY;
                            Globals.FuelOffset = itemOffset;
                            Globals.FuelEnd = itemEnd;
                            Globals.FuelTop = itemTop;
                            Globals.FuelNeedleType = itemNeedleType;
                            Globals.FuelNeedle = itemNeedle;
                        }
                        else
                        {
                            Globals.FuelNeedleWidth = "0";
                            Globals.FuelNeedleLength = "0";
                            Globals.FuelNeedleX = "0";
                            Globals.FuelNeedleY = "0";
                            Globals.FuelOffset = "0";
                            Globals.FuelEnd = "0";
                            Globals.FuelTop = "0";
                            Globals.FuelNeedleType = "0";
                            Globals.FuelNeedle = "0";
                        }

                        if (itemTextShow == "1") { Globals.FuelTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.FuelTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.FuelTextShow = "3"; }
                        if ((itemTextShow == "1") || (itemTextShow == "2") || (itemTextShow == "3"))
                        {
                            Globals.FuelTextX = itemTextX;
                            Globals.FuelTextY = itemTextY;
                            Globals.FuelFontSize = itemFontSize;
                            Globals.FuelTextStyle = itemTextStyle;
                        }
                        else
                        {
                            Globals.FuelTextX = "0";
                            Globals.FuelTextY = "0";
                            Globals.FuelFontSize = "0";
                            Globals.FuelTextStyle = "0";
                        }
                        break;
                    }

                case "FuelT":
                    {
                        if (itemShow == "1") { Globals.FuelTShow = "1"; }
                        if (itemShow == "2") { Globals.FuelTShow = "2"; }
                        if (itemShow == "3") { Globals.FuelTShow = "3"; }
                        if ((itemShow == "1") || (itemShow == "2") || (itemShow == "3"))
                        {
                            Globals.FuelTNeedleWidth = itemNeedleWidth;
                            Globals.FuelTNeedleLength = itemNeedleLength;
                            Globals.FuelTNeedleX = itemNeedleX;
                            Globals.FuelTNeedleY = itemNeedleY;
                            Globals.FuelTOffset = itemOffset;
                            Globals.FuelTEnd = itemEnd;
                            Globals.FuelTTop = itemTop;
                            Globals.FuelTNeedleType = itemNeedleType;
                            Globals.FuelTNeedle = itemNeedle;
                        }
                        else
                        {
                            Globals.FuelTNeedleWidth = "0";
                            Globals.FuelTNeedleLength = "0";
                            Globals.FuelTNeedleX = "0";
                            Globals.FuelTNeedleY = "0";
                            Globals.FuelTOffset = "0";
                            Globals.FuelTEnd = "0";
                            Globals.FuelTTop = "0";
                            Globals.FuelTNeedleType = "0";
                            Globals.FuelTNeedle = "0";
                        }

                        if (itemTextShow == "1") { Globals.FuelTTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.FuelTTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.FuelTTextShow = "3"; }
                        if ((itemTextShow == "1") || (itemTextShow == "2") || (itemTextShow == "3"))
                        {
                            Globals.FuelTTextX = itemTextX;
                            Globals.FuelTTextY = itemTextY;
                            Globals.FuelTFontSize = itemFontSize;
                            Globals.FuelTTextStyle = itemTextStyle;
                        }
                        else
                        {
                            Globals.FuelTTextX = "0";
                            Globals.FuelTTextY = "0";
                            Globals.FuelTFontSize = "0";
                            Globals.FuelTTextStyle = "0";
                        }
                        break;
                    }

                case "FuelP":
                    {
                        if (itemShow == "1") { Globals.FuelPShow = "1"; }
                        if (itemShow == "2") { Globals.FuelPShow = "2"; }
                        if (itemShow == "3") { Globals.FuelPShow = "3"; }
                        if ((itemShow == "1") || (itemShow == "2") || (itemShow == "3"))
                        {
                            Globals.FuelPNeedleWidth = itemNeedleWidth;
                            Globals.FuelPNeedleLength = itemNeedleLength;
                            Globals.FuelPNeedleX = itemNeedleX;
                            Globals.FuelPNeedleY = itemNeedleY;
                            Globals.FuelPOffset = itemOffset;
                            Globals.FuelPEnd = itemEnd;
                            Globals.FuelPTop = itemTop;
                            Globals.FuelPNeedleType = itemNeedleType;
                            Globals.FuelPNeedle = itemNeedle;
                        }
                        else
                        {
                            Globals.FuelPNeedleWidth = "0";
                            Globals.FuelPNeedleLength = "0";
                            Globals.FuelPNeedleX = "0";
                            Globals.FuelPNeedleY = "0";
                            Globals.FuelPOffset = "0";
                            Globals.FuelPEnd = "0";
                            Globals.FuelPTop = "0";
                            Globals.FuelPNeedleType = "0";
                            Globals.FuelPNeedle = "0";
                        }

                        if (itemTextShow == "1") { Globals.FuelPTextShow = "1"; }
                        if (itemTextShow == "2") { Globals.FuelPTextShow = "2"; }
                        if (itemTextShow == "3") { Globals.FuelPTextShow = "3"; }
                        if ((itemTextShow == "1") || (itemTextShow == "2") || (itemTextShow == "3"))
                        {
                            Globals.FuelPTextX = itemTextX;
                            Globals.FuelPTextY = itemTextY;
                            Globals.FuelPFontSize = itemFontSize;
                            Globals.FuelPTextStyle = itemTextStyle;
                        }
                        else
                        {
                            Globals.FuelPTextX = "0";
                            Globals.FuelPTextY = "0";
                            Globals.FuelPFontSize = "0";
                            Globals.FuelPTextStyle = "0";
                        }
                        break;
                    }

                case "User1":
                    {
                        if (itemShow == "1") { Globals.User1Show = "1"; }
                        if (itemShow == "2") { Globals.User1Show = "2"; }
                        if (itemShow == "3") { Globals.User1Show = "3"; }
                        if ((itemShow == "1") || (itemShow == "2") || (itemShow == "3"))
                        {
                            Globals.User1NeedleWidth = itemNeedleWidth;
                            Globals.User1NeedleLength = itemNeedleLength;
                            Globals.User1NeedleX = itemNeedleX;
                            Globals.User1NeedleY = itemNeedleY;
                            Globals.User1Offset = itemOffset;
                            Globals.User1End = itemEnd;
                            Globals.User1Top = itemTop;
                            Globals.User1NeedleType = itemNeedleType;
                            Globals.User1Needle = itemNeedle;
                        }
                        else
                        {
                            Globals.User1NeedleWidth = "0";
                            Globals.User1NeedleLength = "0";
                            Globals.User1NeedleX = "0";
                            Globals.User1NeedleY = "0";
                            Globals.User1Offset = "0";
                            Globals.User1End = "0";
                            Globals.User1Top = "0";
                            Globals.User1NeedleType = "0";
                            Globals.User1Needle = "0";
                        }

                        if (itemTextShow == "1") { Globals.User1TextShow = "1"; }
                        if (itemTextShow == "2") { Globals.User1TextShow = "2"; }
                        if (itemTextShow == "3") { Globals.User1TextShow = "3"; }
                        if ((itemTextShow == "1") || (itemTextShow == "2") || (itemTextShow == "3"))
                        {
                            Globals.User1TextX = itemTextX;
                            Globals.User1TextY = itemTextY;
                            Globals.User1FontSize = itemFontSize;
                            Globals.User1TextStyle = itemTextStyle;
                        }
                        else
                        {
                            Globals.User1TextX = "0";
                            Globals.User1TextY = "0";
                            Globals.User1FontSize = "0";
                            Globals.User1TextStyle = "0";
                        }
                        break;
                    }

                case "User2":
                    {
                        if (itemShow == "1") { Globals.User2Show = "1"; }
                        if (itemShow == "2") { Globals.User2Show = "2"; }
                        if (itemShow == "3") { Globals.User2Show = "3"; }
                        if ((itemShow == "1") || (itemShow == "2") || (itemShow == "3"))
                        {
                            Globals.User2NeedleWidth = itemNeedleWidth;
                            Globals.User2NeedleLength = itemNeedleLength;
                            Globals.User2NeedleX = itemNeedleX;
                            Globals.User2NeedleY = itemNeedleY;
                            Globals.User2Offset = itemOffset;
                            Globals.User2End = itemEnd;
                            Globals.User2Top = itemTop;
                            Globals.User2NeedleType = itemNeedleType;
                            Globals.User2Needle = itemNeedle;
                        }
                        else
                        {
                            Globals.User2NeedleWidth = "0";
                            Globals.User2NeedleLength = "0";
                            Globals.User2NeedleX = "0";
                            Globals.User2NeedleY = "0";
                            Globals.User2Offset = "0";
                            Globals.User2End = "0";
                            Globals.User2Top = "0";
                            Globals.User2NeedleType = "0";
                            Globals.User2Needle = "0";
                        }

                        if (itemTextShow == "1") { Globals.User2TextShow = "1"; }
                        if (itemTextShow == "2") { Globals.User2TextShow = "2"; }
                        if (itemTextShow == "3") { Globals.User2TextShow = "3"; }
                        if ((itemTextShow == "1") || (itemTextShow == "2") || (itemTextShow == "3"))
                        {
                            Globals.User2TextX = itemTextX;
                            Globals.User2TextY = itemTextY;
                            Globals.User2FontSize = itemFontSize;
                            Globals.User2TextStyle = itemTextStyle;
                        }
                        else
                        {
                            Globals.User2TextX = "0";
                            Globals.User2TextY = "0";
                            Globals.User2FontSize = "0";
                            Globals.User2TextStyle = "0";
                        }
                        break;
                    }

                case "User3":
                    {
                        if (itemShow == "1") { Globals.User3Show = "1"; }
                        if (itemShow == "2") { Globals.User3Show = "2"; }
                        if (itemShow == "3") { Globals.User3Show = "3"; }
                        if ((itemShow == "1") || (itemShow == "2") || (itemShow == "3"))
                        {
                            Globals.User3NeedleWidth = itemNeedleWidth;
                            Globals.User3NeedleLength = itemNeedleLength;
                            Globals.User3NeedleX = itemNeedleX;
                            Globals.User3NeedleY = itemNeedleY;
                            Globals.User3Offset = itemOffset;
                            Globals.User3End = itemEnd;
                            Globals.User3Top = itemTop;
                            Globals.User3NeedleType = itemNeedleType;
                            Globals.User3Needle = itemNeedle;
                        }
                        else
                        {
                            Globals.User3NeedleWidth = "0";
                            Globals.User3NeedleLength = "0";
                            Globals.User3NeedleX = "0";
                            Globals.User3NeedleY = "0";
                            Globals.User3Offset = "0";
                            Globals.User3End = "0";
                            Globals.User3Top = "0";
                            Globals.User3NeedleType = "0";
                            Globals.User3Needle = "0";
                        }

                        if (itemTextShow == "1") { Globals.User3TextShow = "1"; }
                        if (itemTextShow == "2") { Globals.User3TextShow = "2"; }
                        if (itemTextShow == "3") { Globals.User3TextShow = "3"; }
                        if ((itemTextShow == "1") || (itemTextShow == "2") || (itemTextShow == "3"))
                        {
                            Globals.User3TextX = itemTextX;
                            Globals.User3TextY = itemTextY;
                            Globals.User3FontSize = itemFontSize;
                            Globals.User3TextStyle = itemTextStyle;
                        }
                        else
                        {
                            Globals.User3TextX = "0";
                            Globals.User3TextY = "0";
                            Globals.User3FontSize = "0";
                            Globals.User3TextStyle = "0";
                        }
                        break;
                    }

                case "User4":
                    {
                        if (itemShow == "1") { Globals.User4Show = "1"; }
                        if (itemShow == "2") { Globals.User4Show = "2"; }
                        if (itemShow == "3") { Globals.User4Show = "3"; }
                        if ((itemShow == "1") || (itemShow == "2") || (itemShow == "3"))
                        {
                            Globals.User4NeedleWidth = itemNeedleWidth;
                            Globals.User4NeedleLength = itemNeedleLength;
                            Globals.User4NeedleX = itemNeedleX;
                            Globals.User4NeedleY = itemNeedleY;
                            Globals.User4Offset = itemOffset;
                            Globals.User4End = itemEnd;
                            Globals.User4Top = itemTop;
                            Globals.User4NeedleType = itemNeedleType;
                            Globals.User4Needle = itemNeedle;
                        }
                        else
                        {
                            Globals.User4NeedleWidth = "0";
                            Globals.User4NeedleLength = "0";
                            Globals.User4NeedleX = "0";
                            Globals.User4NeedleY = "0";
                            Globals.User4Offset = "0";
                            Globals.User4End = "0";
                            Globals.User4Top = "0";
                            Globals.User4NeedleType = "0";
                            Globals.User4Needle = "0";
                        }

                        if (itemTextShow == "1") { Globals.User4TextShow = "1"; }
                        if (itemTextShow == "2") { Globals.User4TextShow = "2"; }
                        if (itemTextShow == "3") { Globals.User4TextShow = "3"; }
                        if ((itemTextShow == "1") || (itemTextShow == "2") || (itemTextShow == "3"))
                        {
                            Globals.User4TextX = itemTextX;
                            Globals.User4TextY = itemTextY;
                            Globals.User4FontSize = itemFontSize;
                            Globals.User4TextStyle = itemTextStyle;
                        }
                        else
                        {
                            Globals.User4TextX = "0";
                            Globals.User4TextY = "0";
                            Globals.User4FontSize = "0";
                            Globals.User4TextStyle = "0";
                        }
                        break;
                    }
            }
        }
    }
}
