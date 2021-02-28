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
            Globals.thecounter = 0;
            Globals.isSaved1 = true;
            Globals.isSaved2 = true;
            Globals.isSaved3 = true;

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
                                    popReadgauges(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15], items[16]);
                                }
                                if ((items[0].ToLower() == "fuelt") || (items[0].ToLower() == "fuelp") || (items[0].ToLower() == "battery") || (items[0].ToLower() == "user1") || (items[0].ToLower() == "user2") || (items[0].ToLower() == "user3") || (items[0].ToLower() == "user4"))
                                {
                                    popReadgauges(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15], items[16]);
                                }
                                if (items[0] == "1") { Globals.p1DispWidth = items[1]; Globals.p1DispHeight = items[2]; }

                                if (items[0] == "Background") { Globals.P1BG = items[1]; }
                                if (items[0] == "Userdefined")
                                {
                                    Globals.User1name = items[1]; Globals.User2name = items[2]; Globals.User3name = items[3]; Globals.User4name = items[4];
                                }
                                if (items[0] == "Offsets")
                                {
                                    Globals.SpeedoCanOffset = items[1]; Globals.TachoCanOffset = items[2]; Globals.BoostCanOffset = items[3]; Globals.TempCanOffset = items[4]; Globals.OilCanOffset = items[5]; Globals.OilTCanOffset = items[6]; Globals.FuelCanOffset = items[7]; Globals.FuelTCanOffset = items[8]; Globals.FuelPCanOffset = items[9]; Globals.BatteryCanOffset = items[10]; Globals.User1CanOffset = items[11]; Globals.User2CanOffset = items[12]; Globals.User3CanOffset = items[13]; Globals.User4CanOffset = items[14];
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
                                if (items[0].ToLower() == "symbols1")
                                {
                                    //           show1,      X1,      Y1,     GPIO1,    show2,      X2,       Y2,      GPIO2,    show3,     X3,      Y3,        GPIO3,     show4,      X4,        Y4,       GPIO4
                                    //sidelights, headlights, fullbeam, spotlights
                                    popSymbols1(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15]); 
                                }
                                if (items[0].ToLower() == "symbols2")
                                {
                                    //foglight, bonnet, boot, door
                                    popSymbols2(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15]);
                                }
                                if (items[0].ToLower() == "symbols3")
                                {
                                    //fuel, brakes, temp, oil
                                    popSymbols3(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15]);
                                }
                                if (items[0].ToLower() == "symbols4")
                                {
                                    //tyre, spanner, demister, washer
                                    popSymbols4(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15]);
                                }
                                if (items[0].ToLower() == "symbols5")
                                {
                                    //hazards, indleft, indright, seatbelts
                                    popSymbols5(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15]);
                                }
                                if (items[0].ToLower() == "symbols6")
                                {
                                    //wiperint, seat1, seat2
                                    popSymbols6(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11]);
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
                                        popReadgauges(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15], items[16]);
                                    }
                                    if ((items[0].ToLower() == "fuelt") || (items[0].ToLower() == "fuelp") || (items[0].ToLower() == "battery") || (items[0].ToLower() == "user1") || (items[0].ToLower() == "user2") || (items[0].ToLower() == "user3") || (items[0].ToLower() == "user4"))
                                    {
                                        popReadgauges(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15], items[16]);
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
                                        popReadgauges(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15], items[16]);
                                    }
                                    if ((items[0].ToLower() == "fuelt") || (items[0].ToLower() == "fuelp") || (items[0].ToLower() == "battery") || (items[0].ToLower() == "user1") || (items[0].ToLower() == "user2") || (items[0].ToLower() == "user3") || (items[0].ToLower() == "user4"))
                                    {
                                        popReadgauges(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9], items[10], items[11], items[12], items[13], items[14], items[15], items[16]);
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


        //----------------------------------------------------------------------------Symbols------------------------------------------------------------------------------------
        private static void popSymbols1(string show1, string X1, string Y1, string GPIO1, string show2, string X2, string Y2, string GPIO2, string show3, string X3, string Y3, string GPIO3, string show4, string X4, string Y4, string GPIO4)
        {
            //sidelights, headlights, fullbeam, spotlights
            if (show1 == "N") { Globals.symSidelights = "N"; }
            if (show1 == "1") { Globals.symSidelights = "Panel 1"; }
            if (show1 == "2") { Globals.symSidelights = "Panel 2"; }
            if (show1 == "3") { Globals.symSidelights = "Panel 3"; }

            if (show2 == "N") { Globals.symHeadlights = "N"; }
            if (show2 == "1") { Globals.symHeadlights = "Panel 1"; }
            if (show2 == "2") { Globals.symHeadlights = "Panel 2"; }
            if (show2 == "3") { Globals.symHeadlights = "Panel 3"; }

            if (show3 == "N") { Globals.symFullbeam = "N"; }
            if (show3 == "1") { Globals.symFullbeam = "Panel 1"; }
            if (show3 == "2") { Globals.symFullbeam = "Panel 2"; }
            if (show3 == "3") { Globals.symFullbeam = "Panel 3"; }

            if (show4 == "N") { Globals.symSpotlights = "N"; }
            if (show4 == "1") { Globals.symSpotlights = "Panel 1"; }
            if (show4 == "2") { Globals.symSpotlights = "Panel 2"; }
            if (show4 == "3") { Globals.symSpotlights = "Panel 3"; }

            Globals.symSidelightsX = X1; Globals.symSidelightsY = Y1; Globals.symSidelightsGPIO = GPIO1;
            Globals.symHeadlightsX = X2; Globals.symHeadlightsY = Y2; Globals.symHeadlightsGPIO = GPIO2;
            Globals.symFullbeamX = X3; Globals.symFullbeamY = Y3; Globals.symFullbeamGPIO = GPIO3;
            Globals.symSpotlightsX = X4; Globals.symSpotlightsY = Y4; Globals.symSpotlightsGPIO = GPIO4;
        }

        private static void popSymbols2(string show1, string X1, string Y1, string GPIO1, string show2, string X2, string Y2, string GPIO2, string show3, string X3, string Y3, string GPIO3, string show4, string X4, string Y4, string GPIO4)
        {
            //foglight, bonnet, boot, door
            if (show1 == "N") { Globals.symFoglights = "N"; }
            if (show1 == "1") { Globals.symFoglights = "Panel 1"; }
            if (show1 == "2") { Globals.symFoglights = "Panel 2"; }
            if (show1 == "3") { Globals.symFoglights = "Panel 3"; }

            if (show2 == "N") { Globals.symBonnet = "N"; }
            if (show2 == "1") { Globals.symBonnet = "Panel 1"; }
            if (show2 == "2") { Globals.symBonnet = "Panel 2"; }
            if (show2 == "3") { Globals.symBonnet = "Panel 3"; }

            if (show3 == "N") { Globals.symBoot = "N"; }
            if (show3 == "1") { Globals.symBoot = "Panel 1"; }
            if (show3 == "2") { Globals.symBoot = "Panel 2"; }
            if (show3 == "3") { Globals.symBoot = "Panel 3"; }

            if (show4 == "N") { Globals.symDoor = "N"; }
            if (show4 == "1") { Globals.symDoor = "Panel 1"; }
            if (show4 == "2") { Globals.symDoor = "Panel 2"; }
            if (show4 == "3") { Globals.symDoor = "Panel 3"; }

            Globals.symFoglightsX = X1; Globals.symFoglightsY = Y1; Globals.symFoglightsGPIO = GPIO1;
            Globals.symBonnetX = X2; Globals.symBonnetY = Y2; Globals.symBonnetGPIO = GPIO2;
            Globals.symBootX = X3; Globals.symBootY = Y3; Globals.symBootGPIO = GPIO3;
            Globals.symDoorX = X4; Globals.symDoorY = Y4; Globals.symDoorGPIO = GPIO4;
        }

        private static void popSymbols3(string show1, string X1, string Y1, string GPIO1, string show2, string X2, string Y2, string GPIO2, string show3, string X3, string Y3, string GPIO3, string show4, string X4, string Y4, string GPIO4)
        {
            //fuel, brakes, temp, oil
            if (show1 == "N") { Globals.symFuel = "N"; }
            if (show1 == "1") { Globals.symFuel = "Panel 1"; }
            if (show1 == "2") { Globals.symFuel = "Panel 2"; }
            if (show1 == "3") { Globals.symFuel = "Panel 3"; }

            if (show2 == "N") { Globals.symBrakes = "N"; }
            if (show2 == "1") { Globals.symBrakes = "Panel 1"; }
            if (show2 == "2") { Globals.symBrakes = "Panel 2"; }
            if (show2 == "3") { Globals.symBrakes = "Panel 3"; }

            if (show3 == "N") { Globals.symTemp = "N"; }
            if (show3 == "1") { Globals.symTemp = "Panel 1"; }
            if (show3 == "2") { Globals.symTemp = "Panel 2"; }
            if (show3 == "3") { Globals.symTemp = "Panel 3"; }

            if (show4 == "N") { Globals.symOil = "N"; }
            if (show4 == "1") { Globals.symOil = "Panel 1"; }
            if (show4 == "2") { Globals.symOil = "Panel 2"; }
            if (show4 == "3") { Globals.symOil = "Panel 3"; }

            Globals.symFuelX = X1; Globals.symFuelY = Y1; Globals.symFuelGPIO = GPIO1;
            Globals.symBrakesX = X2; Globals.symBrakesY = Y2; Globals.symBrakesGPIO = GPIO2;
            Globals.symTempX = X3; Globals.symTempY = Y3; Globals.symTempGPIO = GPIO3;
            Globals.symOilX = X4; Globals.symOilY = Y4; Globals.symOilGPIO = GPIO4;
        }

        private static void popSymbols4(string show1, string X1, string Y1, string GPIO1, string show2, string X2, string Y2, string GPIO2, string show3, string X3, string Y3, string GPIO3, string show4, string X4, string Y4, string GPIO4)
        {
            //tyre, spanner, demister, washer
            if (show1 == "N") { Globals.symTyre = "N"; }
            if (show1 == "1") { Globals.symTyre = "Panel 1"; }
            if (show1 == "2") { Globals.symTyre = "Panel 2"; }
            if (show1 == "3") { Globals.symTyre = "Panel 3"; }

            if (show2 == "N") { Globals.symSpanner = "N"; }
            if (show2 == "1") { Globals.symSpanner = "Panel 1"; }
            if (show2 == "2") { Globals.symSpanner = "Panel 2"; }
            if (show2 == "3") { Globals.symSpanner = "Panel 3"; }

            if (show3 == "N") { Globals.symDemister = "N"; }
            if (show3 == "1") { Globals.symDemister = "Panel 1"; }
            if (show3 == "2") { Globals.symDemister = "Panel 2"; }
            if (show3 == "3") { Globals.symDemister = "Panel 3"; }

            if (show4 == "N") { Globals.symWasher = "N"; }
            if (show4 == "1") { Globals.symWasher = "Panel 1"; }
            if (show4 == "2") { Globals.symWasher = "Panel 2"; }
            if (show4 == "3") { Globals.symWasher = "Panel 3"; }

            Globals.symTyreX = X1; Globals.symTyreY = Y1; Globals.symTyreGPIO = GPIO1;
            Globals.symSpannerX = X2; Globals.symSpannerY = Y2; Globals.symSpannerGPIO = GPIO2;
            Globals.symDemisterX = X3; Globals.symDemisterY = Y3; Globals.symDemisterGPIO = GPIO3;
            Globals.symWasherX = X4; Globals.symWasherY = Y4; Globals.symWasherGPIO = GPIO4;
        }

        private static void popSymbols5(string show1, string X1, string Y1, string GPIO1, string show2, string X2, string Y2, string GPIO2, string show3, string X3, string Y3, string GPIO3, string show4, string X4, string Y4, string GPIO4)
        {
            //hazards, indleft, indright, seatbelts
            if (show1 == "N") { Globals.symHazards = "N"; }
            if (show1 == "1") { Globals.symHazards = "Panel 1"; }
            if (show1 == "2") { Globals.symHazards = "Panel 2"; }
            if (show1 == "3") { Globals.symHazards = "Panel 3"; }

            if (show2 == "N") { Globals.symIndLeft = "N"; }
            if (show2 == "1") { Globals.symIndLeft = "Panel 1"; }
            if (show2 == "2") { Globals.symIndLeft = "Panel 2"; }
            if (show2 == "3") { Globals.symIndLeft = "Panel 3"; }

            if (show3 == "N") { Globals.symIndRight = "N"; }
            if (show3 == "1") { Globals.symIndRight = "Panel 1"; }
            if (show3 == "2") { Globals.symIndRight = "Panel 2"; }
            if (show3 == "3") { Globals.symIndRight = "Panel 3"; }

            if (show4 == "N") { Globals.symSeatbelt = "N"; }
            if (show4 == "1") { Globals.symSeatbelt = "Panel 1"; }
            if (show4 == "2") { Globals.symSeatbelt = "Panel 2"; }
            if (show4 == "3") { Globals.symSeatbelt = "Panel 3"; }

            Globals.symHazardsX = X1; Globals.symHazardsY = Y1; Globals.symHazardsGPIO = GPIO1;
            Globals.symIndLeftX = X2; Globals.symIndLeftY = Y2; Globals.symIndLeftGPIO = GPIO2;
            Globals.symIndRightX = X3; Globals.symIndRightY = Y3; Globals.symIndRightGPIO = GPIO3;
            Globals.symSeatbeltX = X4; Globals.symSeatbeltY = Y4; Globals.symSeatbeltGPIO = GPIO4;
        }

        private static void popSymbols6(string show1, string X1, string Y1, string GPIO1, string show2, string X2, string Y2, string GPIO2, string show3, string X3, string Y3, string GPIO3)
        {
            //wiperint, seat1, seat2
            if (show1 == "N") { Globals.symSeatRight = "N"; }
            if (show1 == "1") { Globals.symSeatRight = "Panel 1"; }
            if (show1 == "2") { Globals.symSeatRight = "Panel 2"; }
            if (show1 == "3") { Globals.symSeatRight = "Panel 3"; }

            if (show2 == "N") { Globals.symSeatLeft = "N"; }
            if (show2 == "1") { Globals.symSeatLeft = "Panel 1"; }
            if (show2 == "2") { Globals.symSeatLeft = "Panel 2"; }
            if (show2 == "3") { Globals.symSeatLeft = "Panel 3"; }

            if (show3 == "N") { Globals.symBoot = "N"; }
            if (show3 == "1") { Globals.symBoot = "Panel 1"; }
            if (show3 == "2") { Globals.symBoot = "Panel 2"; }
            if (show3 == "3") { Globals.symBoot = "Panel 3"; }

            Globals.symSeatRightX = X1; Globals.symSeatRightY = Y1; Globals.symSeatRightGPIO = GPIO1;
            Globals.symSeatLeftX = X2; Globals.symSeatLeftY = Y2; Globals.symSeatLeftGPIO = GPIO2;
            Globals.symBootX = X3; Globals.symBootY = Y3; Globals.symBootGPIO = GPIO3;
        }

        //--------------------------------------------------------------------------set the panel according to the gauge / text box-----------------------------------------------------------------
        public static void popReadgauges(string gaugename, string itemShow, string itemNeedleWidth, string itemNeedleLength, string itemNeedleX, string itemNeedleY, string itemOffset, string itemEnd, string itemTop, string itemTextShow, string itemTextX, string itemTextY, string itemFontSize, string itemTextStyle, string itemNeedleType, string itemNeedle, string gpio)
        {
            Globals.thecounter += 1;
            //                          0                           1                                 2                                 3                              4                             5                           6                              7                         8                           9                              10                         11                           12                              13                             14                              15                                                                                        
            //Globals.Speedovalp1 = Globals.gaugename + "," + Globals.SpeedoShow1 + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow1 + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle;
            switch (gaugename.ToLower())
            {
                case "speedo":
                    {
                        if (itemShow == "1") { Globals.SpeedoShow = "1"; Globals.isSaved1 = false; }
                        if (itemShow == "2") { Globals.SpeedoShow = "2"; Globals.isSaved2 = false; }
                        if (itemShow == "3") { Globals.SpeedoShow = "3"; Globals.isSaved3 = false; }

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
                            Globals.SpeedoGPIO = gpio;
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
                            Globals.SpeedoGPIO = "n";
                        }

                        if (itemTextShow == "1") { Globals.SpeedoTextShow = "1"; Globals.isSaved1 = false; }
                        if (itemTextShow == "2") { Globals.SpeedoTextShow = "2"; Globals.isSaved2 = false; }
                        if (itemTextShow == "3") { Globals.SpeedoTextShow = "3"; Globals.isSaved3 = false; }
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

                case "tacho":
                    {
                        if (itemShow == "1") { Globals.TachoShow = "1"; Globals.isSaved1 = false; }
                        if (itemShow == "2") { Globals.TachoShow = "2"; Globals.isSaved2 = false; }
                        if (itemShow == "3") { Globals.TachoShow = "3"; Globals.isSaved3 = false; }
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
                            Globals.TachoGPIO = gpio;
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
                            Globals.TachoGPIO = "n";
                        }

                        if (itemTextShow == "1") { Globals.TachoTextShow = "1"; Globals.isSaved1 = false; }
                        if (itemTextShow == "2") { Globals.TachoTextShow = "2"; Globals.isSaved2 = false; }
                        if (itemTextShow == "3") { Globals.TachoTextShow = "3"; Globals.isSaved3 = false; }
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

                case "boost":
                    {
                        if (itemShow == "1") { Globals.BoostShow = "1"; Globals.isSaved1 = false; }
                        if (itemShow == "2") { Globals.BoostShow = "2"; Globals.isSaved2 = false; }
                        if (itemShow == "3") { Globals.BoostShow = "3"; Globals.isSaved3 = false; }
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
                            Globals.BoostGPIO = gpio;
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
                            Globals.BoostGPIO = "n";
                        }

                        if (itemTextShow == "1") { Globals.BoostTextShow = "1"; Globals.isSaved1 = false; }
                        if (itemTextShow == "2") { Globals.BoostTextShow = "2"; Globals.isSaved2 = false; }
                        if (itemTextShow == "3") { Globals.BoostTextShow = "3"; Globals.isSaved3 = false; }
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

                case "temp":
                    {
                        if (itemShow == "1") { Globals.TempShow = "1"; Globals.isSaved1 = false; }
                        if (itemShow == "2") { Globals.TempShow = "2"; Globals.isSaved2 = false; }
                        if (itemShow == "3") { Globals.TempShow = "3"; Globals.isSaved3 = false; }
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
                            Globals.TempGPIO = gpio;
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
                            Globals.TempGPIO = "n";
                        }

                        if (itemTextShow == "1") { Globals.TempTextShow = "1"; Globals.isSaved1 = false; }
                        if (itemTextShow == "2") { Globals.TempTextShow = "2"; Globals.isSaved2 = false; }
                        if (itemTextShow == "3") { Globals.TempTextShow = "3"; Globals.isSaved3 = false; }
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

                case "oil":
                    {
                        if (itemShow == "1") { Globals.OilShow = "1"; Globals.isSaved1 = false; }
                        if (itemShow == "2") { Globals.OilShow = "2"; Globals.isSaved2 = false; }
                        if (itemShow == "3") { Globals.OilShow = "3"; Globals.isSaved3 = false; }
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
                            Globals.OilGPIO = gpio;
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
                            Globals.OilGPIO = "n";
                        }

                        if (itemTextShow == "1") { Globals.OilTextShow = "1"; Globals.isSaved1 = false; }
                        if (itemTextShow == "2") { Globals.OilTextShow = "2"; Globals.isSaved2 = false; }
                        if (itemTextShow == "3") { Globals.OilTextShow = "3"; Globals.isSaved3 = false; }
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

                case "oilt":
                    {
                        if (itemShow == "1") { Globals.OilTShow = "1"; Globals.isSaved1 = false; }
                        if (itemShow == "2") { Globals.OilTShow = "2"; Globals.isSaved2 = false; }
                        if (itemShow == "3") { Globals.OilTShow = "3"; Globals.isSaved3 = false; }
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
                            Globals.OilTGPIO = gpio;
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
                            Globals.OilTGPIO = "n";
                        }

                        if (itemTextShow == "1") { Globals.OilTTextShow = "1"; Globals.isSaved1 = false; }
                        if (itemTextShow == "2") { Globals.OilTTextShow = "2"; Globals.isSaved2 = false; }
                        if (itemTextShow == "3") { Globals.OilTTextShow = "3"; Globals.isSaved3 = false; }
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

                case "fuel":
                    {
                        if (itemShow == "1") { Globals.FuelShow = "1"; Globals.isSaved1 = false; }
                        if (itemShow == "2") { Globals.FuelShow = "2"; Globals.isSaved2 = false; }
                        if (itemShow == "3") { Globals.FuelShow = "3"; Globals.isSaved3 = false; }
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
                            Globals.FuelGPIO = gpio;
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
                            Globals.FuelGPIO = "n";
                        }

                        if (itemTextShow == "1") { Globals.FuelTextShow = "1"; Globals.isSaved1 = false; }
                        if (itemTextShow == "2") { Globals.FuelTextShow = "2"; Globals.isSaved2 = false; }
                        if (itemTextShow == "3") { Globals.FuelTextShow = "3"; Globals.isSaved3 = false; }
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

                case "fuelt":
                    {
                        if (itemShow == "1") { Globals.FuelTShow = "1"; Globals.isSaved1 = false; }
                        if (itemShow == "2") { Globals.FuelTShow = "2"; Globals.isSaved2 = false; }
                        if (itemShow == "3") { Globals.FuelTShow = "3"; Globals.isSaved3 = false; }
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
                            Globals.FuelTGPIO = gpio;
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
                            Globals.FuelTGPIO = "n";
                        }

                        if (itemTextShow == "1") { Globals.FuelTTextShow = "1"; Globals.isSaved1 = false; }
                        if (itemTextShow == "2") { Globals.FuelTTextShow = "2"; Globals.isSaved2 = false; }
                        if (itemTextShow == "3") { Globals.FuelTTextShow = "3"; Globals.isSaved3 = false; }
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

                case "fuelp":
                    {
                        if (itemShow == "1") { Globals.FuelPShow = "1"; Globals.isSaved1 = false; }
                        if (itemShow == "2") { Globals.FuelPShow = "2"; Globals.isSaved2 = false; }
                        if (itemShow == "3") { Globals.FuelPShow = "3"; Globals.isSaved3 = false; }
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
                            Globals.FuelPGPIO = gpio;
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
                            Globals.FuelPGPIO = "n";
                        }

                        if (itemTextShow == "1") { Globals.FuelPTextShow = "1"; Globals.isSaved1 = false; }
                        if (itemTextShow == "2") { Globals.FuelPTextShow = "2"; Globals.isSaved2 = false; }
                        if (itemTextShow == "3") { Globals.FuelPTextShow = "3"; Globals.isSaved3 = false; }
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

                case "battery":
                    {
                        if (itemShow == "1") { Globals.BatteryShow = "1"; Globals.isSaved1 = false; }
                        if (itemShow == "2") { Globals.BatteryShow = "2"; Globals.isSaved2 = false; }
                        if (itemShow == "3") { Globals.BatteryShow = "3"; Globals.isSaved3 = false; }
                        if ((itemShow == "1") || (itemShow == "2") || (itemShow == "3"))
                        {
                            Globals.BatteryNeedleWidth = itemNeedleWidth;
                            Globals.BatteryNeedleLength = itemNeedleLength;
                            Globals.BatteryNeedleX = itemNeedleX;
                            Globals.BatteryNeedleY = itemNeedleY;
                            Globals.BatteryOffset = itemOffset;
                            Globals.BatteryEnd = itemEnd;
                            Globals.BatteryTop = itemTop;
                            Globals.BatteryNeedleType = itemNeedleType;
                            Globals.BatteryNeedle = itemNeedle;
                            Globals.BatteryGPIO = gpio;
                        }
                        else
                        {
                            Globals.BatteryNeedleWidth = "0";
                            Globals.BatteryNeedleLength = "0";
                            Globals.BatteryNeedleX = "0";
                            Globals.BatteryNeedleY = "0";
                            Globals.BatteryOffset = "0";
                            Globals.BatteryEnd = "0";
                            Globals.BatteryTop = "0";
                            Globals.BatteryNeedleType = "0";
                            Globals.BatteryNeedle = "0";
                            Globals.BatteryGPIO = "n";
                        }

                        if (itemTextShow == "1") { Globals.BatteryTextShow = "1"; Globals.isSaved1 = false; }
                        if (itemTextShow == "2") { Globals.BatteryTextShow = "2"; Globals.isSaved2 = false; }
                        if (itemTextShow == "3") { Globals.BatteryTextShow = "3"; Globals.isSaved3 = false; }
                        if ((itemTextShow == "1") || (itemTextShow == "2") || (itemTextShow == "3"))
                        {
                            Globals.BatteryTextX = itemTextX;
                            Globals.BatteryTextY = itemTextY;
                            Globals.BatteryFontSize = itemFontSize;
                            Globals.BatteryTextStyle = itemTextStyle;
                        }
                        else
                        {
                            Globals.BatteryTextX = "0";
                            Globals.BatteryTextY = "0";
                            Globals.BatteryFontSize = "0";
                            Globals.BatteryTextStyle = "0";
                        }
                        break;
                    }

                case "user1":
                    {
                        if (itemShow == "1") { Globals.User1Show = "1"; Globals.isSaved1 = false; }
                        if (itemShow == "2") { Globals.User1Show = "2"; Globals.isSaved2 = false; }
                        if (itemShow == "3") { Globals.User1Show = "3"; Globals.isSaved3 = false; }
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
                            Globals.User1GPIO = gpio;
                        }
                        else
                        {
                            //Globals.User1Show
                            Globals.User1NeedleWidth = "0";
                            Globals.User1NeedleLength = "0";
                            Globals.User1NeedleX = "0";
                            Globals.User1NeedleY = "0";
                            Globals.User1Offset = "0";
                            Globals.User1End = "0";
                            Globals.User1Top = "0";
                            Globals.User1NeedleType = "0";
                            Globals.User1Needle = "0";
                            Globals.User1GPIO = "n";
                        }

                        if (itemTextShow == "1") { Globals.User1TextShow = "1"; Globals.isSaved1 = false; }
                        if (itemTextShow == "2") { Globals.User1TextShow = "2"; Globals.isSaved2 = false; }
                        if (itemTextShow == "3") { Globals.User1TextShow = "3"; Globals.isSaved3 = false; }
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

                case "user2":
                    {
                        if (itemShow == "1") { Globals.User2Show = "1"; Globals.isSaved1 = false; }
                        if (itemShow == "2") { Globals.User2Show = "2"; Globals.isSaved2 = false; }
                        if (itemShow == "3") { Globals.User2Show = "3"; Globals.isSaved3 = false; }
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
                            Globals.User2GPIO = gpio;
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
                            Globals.User2GPIO = "n";
                        }

                        if (itemTextShow == "1") { Globals.User2TextShow = "1"; Globals.isSaved1 = false; }
                        if (itemTextShow == "2") { Globals.User2TextShow = "2"; Globals.isSaved2 = false; }
                        if (itemTextShow == "3") { Globals.User2TextShow = "3"; Globals.isSaved3 = false; }
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

                case "user3":
                    {
                        if (itemShow == "1") { Globals.User3Show = "1"; Globals.isSaved1 = false; }
                        if (itemShow == "2") { Globals.User3Show = "2"; Globals.isSaved2 = false; }
                        if (itemShow == "3") { Globals.User3Show = "3"; Globals.isSaved3 = false; }
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
                            Globals.User3GPIO = gpio;
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
                            Globals.User3GPIO = "n";
                        }

                        if (itemTextShow == "1") { Globals.User3TextShow = "1"; Globals.isSaved1 = false; }
                        if (itemTextShow == "2") { Globals.User3TextShow = "2"; Globals.isSaved2 = false; }
                        if (itemTextShow == "3") { Globals.User3TextShow = "3"; Globals.isSaved3 = false; }
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

                case "user4":
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
                            Globals.User4GPIO = gpio;
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
                            Globals.User4GPIO = "n";
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
