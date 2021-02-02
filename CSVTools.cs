using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dashconfigurator
{
    class CSVTools
    {
        public static void calcGauges(string gaugename,string PanelName)
        {
            switch (gaugename)
            {
                case "Speedo":
                switch (PanelName.ToLower())
                    {
                        case "n":
                            Globals.gaugename = "speedo";
                            Globals.SpeedoShow1 = "n";
                            Globals.SpeedoShow2 = "n";
                            Globals.SpeedoShow3 = "n";
                            break;
                        case "panel 1":
                            Globals.gaugename = "speedo";
                            Globals.SpeedoShow1 = "y";
                            Globals.SpeedoShow2 = "n";
                            Globals.SpeedoShow3 = "n";
                            Globals.Speedovalp1 = Globals.gaugename + "," + Globals.SpeedoShow1 + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow1 + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle;
                            break;
                        case "panel 2":
                            Globals.gaugename = "speedo";
                            Globals.SpeedoShow1 = "n";
                            Globals.SpeedoShow2 = "y";
                            Globals.SpeedoShow2 = "n";
                            Globals.Speedovalp2 = Globals.gaugename + "," + Globals.SpeedoShow2 + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow2 + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle;
                            break;
                        case "panel 3":
                            Globals.gaugename = "speedo";
                            Globals.SpeedoShow1 = "n";
                            Globals.SpeedoShow2 = "y";
                            Globals.SpeedoShow3 = "y";
                            Globals.Speedovalp3 = Globals.gaugename + "," + Globals.SpeedoShow3 + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow3 + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle;
                            break;
                    }
                    break;

                case "Tacho":
                    switch (PanelName.ToLower())
                    {
                        case "n":
                            Globals.gaugename = "Tacho";
                            Globals.TachoShow1 = "n";
                            Globals.TachoShow2 = "n";
                            Globals.TachoShow3 = "n";
                            break;
                        case "panel 1":
                            Globals.gaugename = "Tacho";
                            Globals.TachoShow1 = "y";
                            Globals.TachoShow2 = "n";
                            Globals.TachoShow3 = "n";
                            Globals.Tachovalp1 = Globals.gaugename + "," + Globals.TachoShow1 + "," + Globals.TachoNeedleWidth + "," + Globals.TachoNeedleLength + "," + Globals.TachoNeedleX + "," + Globals.TachoNeedleY + "," + Globals.TachoOffset + "," + Globals.TachoEnd + "," + Globals.TachoTop + "," + Globals.TachoTextShow1 + "," + Globals.TachoTextX + "," + Globals.TachoTextY + "," + Globals.TachoFontSize + "," + Globals.TachoTextStyle + "," + Globals.TachoNeedleType + "," + Globals.TachoNeedle;
                            break;
                        case "panel 2":
                            Globals.gaugename = "Tacho";
                            Globals.TachoShow1 = "n";
                            Globals.TachoShow2 = "y";
                            Globals.TachoShow2 = "n";
                            Globals.Tachovalp2 = Globals.gaugename + "," + Globals.TachoShow2 + "," + Globals.TachoNeedleWidth + "," + Globals.TachoNeedleLength + "," + Globals.TachoNeedleX + "," + Globals.TachoNeedleY + "," + Globals.TachoOffset + "," + Globals.TachoEnd + "," + Globals.TachoTop + "," + Globals.TachoTextShow2 + "," + Globals.TachoTextX + "," + Globals.TachoTextY + "," + Globals.TachoFontSize + "," + Globals.TachoTextStyle + "," + Globals.TachoNeedleType + "," + Globals.TachoNeedle;
                            break;
                        case "panel 3":
                            Globals.gaugename = "Tacho";
                            Globals.TachoShow1 = "n";
                            Globals.TachoShow2 = "y";
                            Globals.TachoShow3 = "y";
                            Globals.Tachovalp3 = Globals.gaugename + "," + Globals.TachoShow3 + "," + Globals.TachoNeedleWidth + "," + Globals.TachoNeedleLength + "," + Globals.TachoNeedleX + "," + Globals.TachoNeedleY + "," + Globals.TachoOffset + "," + Globals.TachoEnd + "," + Globals.TachoTop + "," + Globals.TachoTextShow3 + "," + Globals.TachoTextX + "," + Globals.TachoTextY + "," + Globals.TachoFontSize + "," + Globals.TachoTextStyle + "," + Globals.TachoNeedleType + "," + Globals.TachoNeedle;
                            break;
                    }
                    break;

                case "Boost":
                    switch (PanelName.ToLower())
                    {
                        case "n":
                            Globals.gaugename = "Boost";
                            Globals.BoostShow1 = "n";
                            Globals.BoostShow2 = "n";
                            Globals.BoostShow3 = "n";
                            break;
                        case "panel 1":
                            Globals.gaugename = "Boost";
                            Globals.BoostShow1 = "y";
                            Globals.BoostShow2 = "n";
                            Globals.BoostShow3 = "n";
                            Globals.Boostvalp1 = Globals.gaugename + "," + Globals.BoostShow1 + "," + Globals.BoostNeedleWidth + "," + Globals.BoostNeedleLength + "," + Globals.BoostNeedleX + "," + Globals.BoostNeedleY + "," + Globals.BoostOffset + "," + Globals.BoostEnd + "," + Globals.BoostTop + "," + Globals.BoostTextShow1 + "," + Globals.BoostTextX + "," + Globals.BoostTextY + "," + Globals.BoostFontSize + "," + Globals.BoostTextStyle + "," + Globals.BoostNeedleType + "," + Globals.BoostNeedle;
                            break;
                        case "panel 2":
                            Globals.gaugename = "Boost";
                            Globals.BoostShow1 = "n";
                            Globals.BoostShow2 = "y";
                            Globals.BoostShow2 = "n";
                            Globals.Boostvalp2 = Globals.gaugename + "," + Globals.BoostShow2 + "," + Globals.BoostNeedleWidth + "," + Globals.BoostNeedleLength + "," + Globals.BoostNeedleX + "," + Globals.BoostNeedleY + "," + Globals.BoostOffset + "," + Globals.BoostEnd + "," + Globals.BoostTop + "," + Globals.BoostTextShow2 + "," + Globals.BoostTextX + "," + Globals.BoostTextY + "," + Globals.BoostFontSize + "," + Globals.BoostTextStyle + "," + Globals.BoostNeedleType + "," + Globals.BoostNeedle;
                            break;
                        case "panel 3":
                            Globals.gaugename = "Boost";
                            Globals.BoostShow1 = "n";
                            Globals.BoostShow2 = "y";
                            Globals.BoostShow3 = "y";
                            Globals.Boostvalp3 = Globals.gaugename + "," + Globals.BoostShow3 + "," + Globals.BoostNeedleWidth + "," + Globals.BoostNeedleLength + "," + Globals.BoostNeedleX + "," + Globals.BoostNeedleY + "," + Globals.BoostOffset + "," + Globals.BoostEnd + "," + Globals.BoostTop + "," + Globals.BoostTextShow3 + "," + Globals.BoostTextX + "," + Globals.BoostTextY + "," + Globals.BoostFontSize + "," + Globals.BoostTextStyle + "," + Globals.BoostNeedleType + "," + Globals.BoostNeedle;
                            break;
                    }
                    break;

                case "Temp":
                    switch (PanelName.ToLower())
                    {
                        case "n":
                            Globals.gaugename = "Temp";
                            Globals.TempShow1 = "n";
                            Globals.TempShow2 = "n";
                            Globals.TempShow3 = "n";
                            break;
                        case "panel 1":
                            Globals.gaugename = "Temp";
                            Globals.TempShow1 = "y";
                            Globals.TempShow2 = "n";
                            Globals.TempShow3 = "n";
                            Globals.Tempvalp1 = Globals.gaugename + "," + Globals.TempShow1 + "," + Globals.TempNeedleWidth + "," + Globals.TempNeedleLength + "," + Globals.TempNeedleX + "," + Globals.TempNeedleY + "," + Globals.TempOffset + "," + Globals.TempEnd + "," + Globals.TempTop + "," + Globals.TempTextShow1 + "," + Globals.TempTextX + "," + Globals.TempTextY + "," + Globals.TempFontSize + "," + Globals.TempTextStyle + "," + Globals.TempNeedleType + "," + Globals.TempNeedle;
                            break;
                        case "panel 2":
                            Globals.gaugename = "Temp";
                            Globals.TempShow1 = "n";
                            Globals.TempShow2 = "y";
                            Globals.TempShow2 = "n";
                            Globals.Tempvalp2 = Globals.gaugename + "," + Globals.TempShow2 + "," + Globals.TempNeedleWidth + "," + Globals.TempNeedleLength + "," + Globals.TempNeedleX + "," + Globals.TempNeedleY + "," + Globals.TempOffset + "," + Globals.TempEnd + "," + Globals.TempTop + "," + Globals.TempTextShow2 + "," + Globals.TempTextX + "," + Globals.TempTextY + "," + Globals.TempFontSize + "," + Globals.TempTextStyle + "," + Globals.TempNeedleType + "," + Globals.TempNeedle;
                            break;
                        case "panel 3":
                            Globals.gaugename = "Temp";
                            Globals.TempShow1 = "n";
                            Globals.TempShow2 = "y";
                            Globals.TempShow3 = "y";
                            Globals.Tempvalp3 = Globals.gaugename + "," + Globals.TempShow3 + "," + Globals.TempNeedleWidth + "," + Globals.TempNeedleLength + "," + Globals.TempNeedleX + "," + Globals.TempNeedleY + "," + Globals.TempOffset + "," + Globals.TempEnd + "," + Globals.TempTop + "," + Globals.TempTextShow3 + "," + Globals.TempTextX + "," + Globals.TempTextY + "," + Globals.TempFontSize + "," + Globals.TempTextStyle + "," + Globals.TempNeedleType + "," + Globals.TempNeedle;
                            break;
                    }
                    break;

                case "Oil":
                    switch (PanelName.ToLower())
                    {
                        case "n":
                            Globals.gaugename = "Oil";
                            Globals.OilShow1 = "n";
                            Globals.OilShow2 = "n";
                            Globals.OilShow3 = "n";
                            break;
                        case "panel 1":
                            Globals.gaugename = "Oil";
                            Globals.OilShow1 = "y";
                            Globals.OilShow2 = "n";
                            Globals.OilShow3 = "n";
                            Globals.Oilvalp1 = Globals.gaugename + "," + Globals.OilShow1 + "," + Globals.OilNeedleWidth + "," + Globals.OilNeedleLength + "," + Globals.OilNeedleX + "," + Globals.OilNeedleY + "," + Globals.OilOffset + "," + Globals.OilEnd + "," + Globals.OilTop + "," + Globals.OilTextShow1 + "," + Globals.OilTextX + "," + Globals.OilTextY + "," + Globals.OilFontSize + "," + Globals.OilTextStyle + "," + Globals.OilNeedleType + "," + Globals.OilNeedle;
                            break;
                        case "panel 2":
                            Globals.gaugename = "Oil";
                            Globals.OilShow1 = "n";
                            Globals.OilShow2 = "y";
                            Globals.OilShow2 = "n";
                            Globals.Oilvalp2 = Globals.gaugename + "," + Globals.OilShow2 + "," + Globals.OilNeedleWidth + "," + Globals.OilNeedleLength + "," + Globals.OilNeedleX + "," + Globals.OilNeedleY + "," + Globals.OilOffset + "," + Globals.OilEnd + "," + Globals.OilTop + "," + Globals.OilTextShow2 + "," + Globals.OilTextX + "," + Globals.OilTextY + "," + Globals.OilFontSize + "," + Globals.OilTextStyle + "," + Globals.OilNeedleType + "," + Globals.OilNeedle;
                            break;
                        case "panel 3":
                            Globals.gaugename = "Oil";
                            Globals.OilShow1 = "n";
                            Globals.OilShow2 = "y";
                            Globals.OilShow3 = "y";
                            Globals.Oilvalp3 = Globals.gaugename + "," + Globals.OilShow3 + "," + Globals.OilNeedleWidth + "," + Globals.OilNeedleLength + "," + Globals.OilNeedleX + "," + Globals.OilNeedleY + "," + Globals.OilOffset + "," + Globals.OilEnd + "," + Globals.OilTop + "," + Globals.OilTextShow3 + "," + Globals.OilTextX + "," + Globals.OilTextY + "," + Globals.OilFontSize + "," + Globals.OilTextStyle + "," + Globals.OilNeedleType + "," + Globals.OilNeedle;
                            break;
                    }
                    break;

                case "OilT":
                    switch (PanelName.ToLower())
                    {
                        case "n":
                            Globals.gaugename = "OilT";
                            Globals.OilTShow1 = "n";
                            Globals.OilTShow2 = "n";
                            Globals.OilTShow3 = "n";
                            break;
                        case "panel 1":
                            Globals.gaugename = "OilT";
                            Globals.OilTShow1 = "y";
                            Globals.OilTShow2 = "n";
                            Globals.OilTShow3 = "n";
                            Globals.OilTvalp1 = Globals.gaugename + "," + Globals.OilTShow1 + "," + Globals.OilTNeedleWidth + "," + Globals.OilTNeedleLength + "," + Globals.OilTNeedleX + "," + Globals.OilTNeedleY + "," + Globals.OilTOffset + "," + Globals.OilTEnd + "," + Globals.OilTTop + "," + Globals.OilTTextShow1 + "," + Globals.OilTTextX + "," + Globals.OilTTextY + "," + Globals.OilTFontSize + "," + Globals.OilTTextStyle + "," + Globals.OilTNeedleType + "," + Globals.OilTNeedle;
                            break;
                        case "panel 2":
                            Globals.gaugename = "OilT";
                            Globals.OilTShow1 = "n";
                            Globals.OilTShow2 = "y";
                            Globals.OilTShow2 = "n";
                            Globals.OilTvalp2 = Globals.gaugename + "," + Globals.OilTShow2 + "," + Globals.OilTNeedleWidth + "," + Globals.OilTNeedleLength + "," + Globals.OilTNeedleX + "," + Globals.OilTNeedleY + "," + Globals.OilTOffset + "," + Globals.OilTEnd + "," + Globals.OilTTop + "," + Globals.OilTTextShow2 + "," + Globals.OilTTextX + "," + Globals.OilTTextY + "," + Globals.OilTFontSize + "," + Globals.OilTTextStyle + "," + Globals.OilTNeedleType + "," + Globals.OilTNeedle;
                            break;
                        case "panel 3":
                            Globals.gaugename = "OilT";
                            Globals.OilTShow1 = "n";
                            Globals.OilTShow2 = "y";
                            Globals.OilTShow3 = "y";
                            Globals.OilTvalp3 = Globals.gaugename + "," + Globals.OilTShow3 + "," + Globals.OilTNeedleWidth + "," + Globals.OilTNeedleLength + "," + Globals.OilTNeedleX + "," + Globals.OilTNeedleY + "," + Globals.OilTOffset + "," + Globals.OilTEnd + "," + Globals.OilTTop + "," + Globals.OilTTextShow3 + "," + Globals.OilTTextX + "," + Globals.OilTTextY + "," + Globals.OilTFontSize + "," + Globals.OilTTextStyle + "," + Globals.OilTNeedleType + "," + Globals.OilTNeedle;
                            break;
                    }
                    break;

                case "Fuel":
                    switch (PanelName.ToLower())
                    {
                        case "n":
                            Globals.gaugename = "Fuel";
                            Globals.FuelShow1 = "n";
                            Globals.FuelShow2 = "n";
                            Globals.FuelShow3 = "n";
                            break;
                        case "panel 1":
                            Globals.gaugename = "Fuel";
                            Globals.FuelShow1 = "y";
                            Globals.FuelShow2 = "n";
                            Globals.FuelShow3 = "n";
                            Globals.Fuelvalp1 = Globals.gaugename + "," + Globals.FuelShow1 + "," + Globals.FuelNeedleWidth + "," + Globals.FuelNeedleLength + "," + Globals.FuelNeedleX + "," + Globals.FuelNeedleY + "," + Globals.FuelOffset + "," + Globals.FuelEnd + "," + Globals.FuelTop + "," + Globals.FuelTextShow1 + "," + Globals.FuelTextX + "," + Globals.FuelTextY + "," + Globals.FuelFontSize + "," + Globals.FuelTextStyle + "," + Globals.FuelNeedleType + "," + Globals.FuelNeedle;
                            break;
                        case "panel 2":
                            Globals.gaugename = "Fuel";
                            Globals.FuelShow1 = "n";
                            Globals.FuelShow2 = "y";
                            Globals.FuelShow2 = "n";
                            Globals.Fuelvalp2 = Globals.gaugename + "," + Globals.FuelShow2 + "," + Globals.FuelNeedleWidth + "," + Globals.FuelNeedleLength + "," + Globals.FuelNeedleX + "," + Globals.FuelNeedleY + "," + Globals.FuelOffset + "," + Globals.FuelEnd + "," + Globals.FuelTop + "," + Globals.FuelTextShow2 + "," + Globals.FuelTextX + "," + Globals.FuelTextY + "," + Globals.FuelFontSize + "," + Globals.FuelTextStyle + "," + Globals.FuelNeedleType + "," + Globals.FuelNeedle;
                            break;
                        case "panel 3":
                            Globals.gaugename = "Fuel";
                            Globals.FuelShow1 = "n";
                            Globals.FuelShow2 = "y";
                            Globals.FuelShow3 = "y";
                            Globals.Fuelvalp3 = Globals.gaugename + "," + Globals.FuelShow3 + "," + Globals.FuelNeedleWidth + "," + Globals.FuelNeedleLength + "," + Globals.FuelNeedleX + "," + Globals.FuelNeedleY + "," + Globals.FuelOffset + "," + Globals.FuelEnd + "," + Globals.FuelTop + "," + Globals.FuelTextShow3 + "," + Globals.FuelTextX + "," + Globals.FuelTextY + "," + Globals.FuelFontSize + "," + Globals.FuelTextStyle + "," + Globals.FuelNeedleType + "," + Globals.FuelNeedle;
                            break;
                    }
                    break;

                case "FuelT":
                    switch (PanelName.ToLower())
                    {
                        case "n":
                            Globals.gaugename = "FuelT";
                            Globals.FuelTShow1 = "n";
                            Globals.FuelTShow2 = "n";
                            Globals.FuelTShow3 = "n";
                            break;
                        case "panel 1":
                            Globals.gaugename = "FuelT";
                            Globals.FuelTShow1 = "y";
                            Globals.FuelTShow2 = "n";
                            Globals.FuelTShow3 = "n";
                            Globals.FuelTvalp1 = Globals.gaugename + "," + Globals.FuelTShow1 + "," + Globals.FuelTNeedleWidth + "," + Globals.FuelTNeedleLength + "," + Globals.FuelTNeedleX + "," + Globals.FuelTNeedleY + "," + Globals.FuelTOffset + "," + Globals.FuelTEnd + "," + Globals.FuelTTop + "," + Globals.FuelTTextShow1 + "," + Globals.FuelTTextX + "," + Globals.FuelTTextY + "," + Globals.FuelTFontSize + "," + Globals.FuelTTextStyle + "," + Globals.FuelTNeedleType + "," + Globals.FuelTNeedle;
                            break;
                        case "panel 2":
                            Globals.gaugename = "FuelT";
                            Globals.FuelTShow1 = "n";
                            Globals.FuelTShow2 = "y";
                            Globals.FuelTShow2 = "n";
                            Globals.FuelTvalp2 = Globals.gaugename + "," + Globals.FuelTShow2 + "," + Globals.FuelTNeedleWidth + "," + Globals.FuelTNeedleLength + "," + Globals.FuelTNeedleX + "," + Globals.FuelTNeedleY + "," + Globals.FuelTOffset + "," + Globals.FuelTEnd + "," + Globals.FuelTTop + "," + Globals.FuelTTextShow2 + "," + Globals.FuelTTextX + "," + Globals.FuelTTextY + "," + Globals.FuelTFontSize + "," + Globals.FuelTTextStyle + "," + Globals.FuelTNeedleType + "," + Globals.FuelTNeedle;
                            break;
                        case "panel 3":
                            Globals.gaugename = "FuelT";
                            Globals.FuelTShow1 = "n";
                            Globals.FuelTShow2 = "y";
                            Globals.FuelTShow3 = "y";
                            Globals.FuelTvalp3 = Globals.gaugename + "," + Globals.FuelTShow3 + "," + Globals.FuelTNeedleWidth + "," + Globals.FuelTNeedleLength + "," + Globals.FuelTNeedleX + "," + Globals.FuelTNeedleY + "," + Globals.FuelTOffset + "," + Globals.FuelTEnd + "," + Globals.FuelTTop + "," + Globals.FuelTTextShow3 + "," + Globals.FuelTTextX + "," + Globals.FuelTTextY + "," + Globals.FuelTFontSize + "," + Globals.FuelTTextStyle + "," + Globals.FuelTNeedleType + "," + Globals.FuelTNeedle;
                            break;
                    }
                    break;

                case "FuelP":
                    switch (PanelName.ToLower())
                    {
                        case "n":
                            Globals.gaugename = "FuelP";
                            Globals.FuelPShow1 = "n";
                            Globals.FuelPShow2 = "n";
                            Globals.FuelPShow3 = "n";
                            break;
                        case "panel 1":
                            Globals.gaugename = "FuelP";
                            Globals.FuelPShow1 = "y";
                            Globals.FuelPShow2 = "n";
                            Globals.FuelPShow3 = "n";
                            Globals.FuelPvalp1 = Globals.gaugename + "," + Globals.FuelPShow1 + "," + Globals.FuelPNeedleWidth + "," + Globals.FuelPNeedleLength + "," + Globals.FuelPNeedleX + "," + Globals.FuelPNeedleY + "," + Globals.FuelPOffset + "," + Globals.FuelPEnd + "," + Globals.FuelPTop + "," + Globals.FuelPTextShow1 + "," + Globals.FuelPTextX + "," + Globals.FuelPTextY + "," + Globals.FuelPFontSize + "," + Globals.FuelPTextStyle + "," + Globals.FuelPNeedleType + "," + Globals.FuelPNeedle;
                            break;
                        case "panel 2":
                            Globals.gaugename = "FuelP";
                            Globals.FuelPShow1 = "n";
                            Globals.FuelPShow2 = "y";
                            Globals.FuelPShow2 = "n";
                            Globals.FuelPvalp2 = Globals.gaugename + "," + Globals.FuelPShow2 + "," + Globals.FuelPNeedleWidth + "," + Globals.FuelPNeedleLength + "," + Globals.FuelPNeedleX + "," + Globals.FuelPNeedleY + "," + Globals.FuelPOffset + "," + Globals.FuelPEnd + "," + Globals.FuelPTop + "," + Globals.FuelPTextShow2 + "," + Globals.FuelPTextX + "," + Globals.FuelPTextY + "," + Globals.FuelPFontSize + "," + Globals.FuelPTextStyle + "," + Globals.FuelPNeedleType + "," + Globals.FuelPNeedle;
                            break;
                        case "panel 3":
                            Globals.gaugename = "FuelP";
                            Globals.FuelPShow1 = "n";
                            Globals.FuelPShow2 = "y";
                            Globals.FuelPShow3 = "y";
                            Globals.FuelPvalp3 = Globals.gaugename + "," + Globals.FuelPShow3 + "," + Globals.FuelPNeedleWidth + "," + Globals.FuelPNeedleLength + "," + Globals.FuelPNeedleX + "," + Globals.FuelPNeedleY + "," + Globals.FuelPOffset + "," + Globals.FuelPEnd + "," + Globals.FuelPTop + "," + Globals.FuelPTextShow3 + "," + Globals.FuelPTextX + "," + Globals.FuelPTextY + "," + Globals.FuelPFontSize + "," + Globals.FuelPTextStyle + "," + Globals.FuelPNeedleType + "," + Globals.FuelPNeedle;
                            break;
                    }
                    break;

                case "User1":
                    switch (PanelName.ToLower())
                    {
                        case "n":
                            Globals.gaugename = "User1";
                            Globals.User1Show1 = "n";
                            Globals.User1Show2 = "n";
                            Globals.User1Show3 = "n";
                            break;
                        case "panel 1":
                            Globals.gaugename = "User1";
                            Globals.User1Show1 = "y";
                            Globals.User1Show2 = "n";
                            Globals.User1Show3 = "n";
                            Globals.User1valp1 = Globals.gaugename + "," + Globals.User1Show1 + "," + Globals.User1NeedleWidth + "," + Globals.User1NeedleLength + "," + Globals.User1NeedleX + "," + Globals.User1NeedleY + "," + Globals.User1Offset + "," + Globals.User1End + "," + Globals.User1Top + "," + Globals.User1TextShow1 + "," + Globals.User1TextX + "," + Globals.User1TextY + "," + Globals.User1FontSize + "," + Globals.User1TextStyle + "," + Globals.User1NeedleType + "," + Globals.User1Needle;
                            break;
                        case "panel 2":
                            Globals.gaugename = "User1";
                            Globals.User1Show1 = "n";
                            Globals.User1Show2 = "y";
                            Globals.User1Show2 = "n";
                            Globals.User1valp2 = Globals.gaugename + "," + Globals.User1Show2 + "," + Globals.User1NeedleWidth + "," + Globals.User1NeedleLength + "," + Globals.User1NeedleX + "," + Globals.User1NeedleY + "," + Globals.User1Offset + "," + Globals.User1End + "," + Globals.User1Top + "," + Globals.User1TextShow2 + "," + Globals.User1TextX + "," + Globals.User1TextY + "," + Globals.User1FontSize + "," + Globals.User1TextStyle + "," + Globals.User1NeedleType + "," + Globals.User1Needle;
                            break;
                        case "panel 3":
                            Globals.gaugename = "User1";
                            Globals.User1Show1 = "n";
                            Globals.User1Show2 = "y";
                            Globals.User1Show3 = "y";
                            Globals.User1valp3 = Globals.gaugename + "," + Globals.User1Show3 + "," + Globals.User1NeedleWidth + "," + Globals.User1NeedleLength + "," + Globals.User1NeedleX + "," + Globals.User1NeedleY + "," + Globals.User1Offset + "," + Globals.User1End + "," + Globals.User1Top + "," + Globals.User1TextShow3 + "," + Globals.User1TextX + "," + Globals.User1TextY + "," + Globals.User1FontSize + "," + Globals.User1TextStyle + "," + Globals.User1NeedleType + "," + Globals.User1Needle;
                            break;
                    }
                    break;

                case "User2":
                    switch (PanelName.ToLower())
                    {
                        case "n":
                            Globals.gaugename = "User2";
                            Globals.User2Show1 = "n";
                            Globals.User2Show2 = "n";
                            Globals.User2Show3 = "n";
                            break;
                        case "panel 1":
                            Globals.gaugename = "User2";
                            Globals.User2Show1 = "y";
                            Globals.User2Show2 = "n";
                            Globals.User2Show3 = "n";
                            Globals.User2valp1 = Globals.gaugename + "," + Globals.User2Show1 + "," + Globals.User2NeedleWidth + "," + Globals.User2NeedleLength + "," + Globals.User2NeedleX + "," + Globals.User2NeedleY + "," + Globals.User2Offset + "," + Globals.User2End + "," + Globals.User2Top + "," + Globals.User2TextShow1 + "," + Globals.User2TextX + "," + Globals.User2TextY + "," + Globals.User2FontSize + "," + Globals.User2TextStyle + "," + Globals.User2NeedleType + "," + Globals.User2Needle;
                            break;
                        case "panel 2":
                            Globals.gaugename = "User2";
                            Globals.User2Show1 = "n";
                            Globals.User2Show2 = "y";
                            Globals.User2Show2 = "n";
                            Globals.User2valp2 = Globals.gaugename + "," + Globals.User2Show2 + "," + Globals.User2NeedleWidth + "," + Globals.User2NeedleLength + "," + Globals.User2NeedleX + "," + Globals.User2NeedleY + "," + Globals.User2Offset + "," + Globals.User2End + "," + Globals.User2Top + "," + Globals.User2TextShow2 + "," + Globals.User2TextX + "," + Globals.User2TextY + "," + Globals.User2FontSize + "," + Globals.User2TextStyle + "," + Globals.User2NeedleType + "," + Globals.User2Needle;
                            break;
                        case "panel 3":
                            Globals.gaugename = "User2";
                            Globals.User2Show1 = "n";
                            Globals.User2Show2 = "y";
                            Globals.User2Show3 = "y";
                            Globals.User2valp3 = Globals.gaugename + "," + Globals.User2Show3 + "," + Globals.User2NeedleWidth + "," + Globals.User2NeedleLength + "," + Globals.User2NeedleX + "," + Globals.User2NeedleY + "," + Globals.User2Offset + "," + Globals.User2End + "," + Globals.User2Top + "," + Globals.User2TextShow3 + "," + Globals.User2TextX + "," + Globals.User2TextY + "," + Globals.User2FontSize + "," + Globals.User2TextStyle + "," + Globals.User2NeedleType + "," + Globals.User2Needle;
                            break;
                    }
                    break;

                case "User3":
                    switch (PanelName.ToLower())
                    {
                        case "n":
                            Globals.gaugename = "User3";
                            Globals.User3Show1 = "n";
                            Globals.User3Show2 = "n";
                            Globals.User3Show3 = "n";
                            break;
                        case "panel 1":
                            Globals.gaugename = "User3";
                            Globals.User3Show1 = "y";
                            Globals.User3Show2 = "n";
                            Globals.User3Show3 = "n";
                            Globals.User3valp1 = Globals.gaugename + "," + Globals.User3Show1 + "," + Globals.User3NeedleWidth + "," + Globals.User3NeedleLength + "," + Globals.User3NeedleX + "," + Globals.User3NeedleY + "," + Globals.User3Offset + "," + Globals.User3End + "," + Globals.User3Top + "," + Globals.User3TextShow1 + "," + Globals.User3TextX + "," + Globals.User3TextY + "," + Globals.User3FontSize + "," + Globals.User3TextStyle + "," + Globals.User3NeedleType + "," + Globals.User3Needle;
                            break;
                        case "panel 2":
                            Globals.gaugename = "User3";
                            Globals.User3Show1 = "n";
                            Globals.User3Show2 = "y";
                            Globals.User3Show2 = "n";
                            Globals.User3valp2 = Globals.gaugename + "," + Globals.User3Show2 + "," + Globals.User3NeedleWidth + "," + Globals.User3NeedleLength + "," + Globals.User3NeedleX + "," + Globals.User3NeedleY + "," + Globals.User3Offset + "," + Globals.User3End + "," + Globals.User3Top + "," + Globals.User3TextShow2 + "," + Globals.User3TextX + "," + Globals.User3TextY + "," + Globals.User3FontSize + "," + Globals.User3TextStyle + "," + Globals.User3NeedleType + "," + Globals.User3Needle;
                            break;
                        case "panel 3":
                            Globals.gaugename = "User3";
                            Globals.User3Show1 = "n";
                            Globals.User3Show2 = "y";
                            Globals.User3Show3 = "y";
                            Globals.User3valp3 = Globals.gaugename + "," + Globals.User3Show3 + "," + Globals.User3NeedleWidth + "," + Globals.User3NeedleLength + "," + Globals.User3NeedleX + "," + Globals.User3NeedleY + "," + Globals.User3Offset + "," + Globals.User3End + "," + Globals.User3Top + "," + Globals.User3TextShow3 + "," + Globals.User3TextX + "," + Globals.User3TextY + "," + Globals.User3FontSize + "," + Globals.User3TextStyle + "," + Globals.User3NeedleType + "," + Globals.User3Needle;
                            break;
                    }
                    break;

                case "User4":
                    switch (PanelName.ToLower())
                    {
                        case "n":
                            Globals.gaugename = "User4";
                            Globals.User4Show1 = "n";
                            Globals.User4Show2 = "n";
                            Globals.User4Show3 = "n";
                            break;
                        case "panel 1":
                            Globals.gaugename = "User4";
                            Globals.User4Show1 = "y";
                            Globals.User4Show2 = "n";
                            Globals.User4Show3 = "n";
                            Globals.User4valp1 = Globals.gaugename + "," + Globals.User4Show1 + "," + Globals.User4NeedleWidth + "," + Globals.User4NeedleLength + "," + Globals.User4NeedleX + "," + Globals.User4NeedleY + "," + Globals.User4Offset + "," + Globals.User4End + "," + Globals.User4Top + "," + Globals.User4TextShow1 + "," + Globals.User4TextX + "," + Globals.User4TextY + "," + Globals.User4FontSize + "," + Globals.User4TextStyle + "," + Globals.User4NeedleType + "," + Globals.User4Needle;
                            break;
                        case "panel 2":
                            Globals.gaugename = "User4";
                            Globals.User4Show1 = "n";
                            Globals.User4Show2 = "y";
                            Globals.User4Show2 = "n";
                            Globals.User4valp2 = Globals.gaugename + "," + Globals.User4Show2 + "," + Globals.User4NeedleWidth + "," + Globals.User4NeedleLength + "," + Globals.User4NeedleX + "," + Globals.User4NeedleY + "," + Globals.User4Offset + "," + Globals.User4End + "," + Globals.User4Top + "," + Globals.User4TextShow2 + "," + Globals.User4TextX + "," + Globals.User4TextY + "," + Globals.User4FontSize + "," + Globals.User4TextStyle + "," + Globals.User4NeedleType + "," + Globals.User4Needle;
                            break;
                        case "panel 3":
                            Globals.gaugename = "User4";
                            Globals.User4Show1 = "n";
                            Globals.User4Show2 = "y";
                            Globals.User4Show3 = "y";
                            Globals.User4valp3 = Globals.gaugename + "," + Globals.User4Show3 + "," + Globals.User4NeedleWidth + "," + Globals.User4NeedleLength + "," + Globals.User4NeedleX + "," + Globals.User4NeedleY + "," + Globals.User4Offset + "," + Globals.User4End + "," + Globals.User4Top + "," + Globals.User4TextShow3 + "," + Globals.User4TextX + "," + Globals.User4TextY + "," + Globals.User4FontSize + "," + Globals.User4TextStyle + "," + Globals.User4NeedleType + "," + Globals.User4Needle;
                            break;
                    }
                    break;
            }

        }

    }
}

