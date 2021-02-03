using System;

namespace dashconfigurator
{
    class CSVTools
    {
        public static void calcGauges(string gaugename,int PanelNum)
        {
            switch (PanelNum)
            {
                case 1:
                    switch (gaugename.ToLower())
                    {
                        case "speedo":
                            Globals.gaugename = "speedo";
                            Globals.SpeedoShow = "n";
                            break;
                    }


                        case "speedo":
                            Globals.gaugename = "speedo";
                            Globals.SpeedoShow = "y";
                            Globals.Speedovalp1 = Globals.gaugename + "," + Globals.SpeedoShow1 + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow1 + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle;
                            break;
                        case "panel 2":
                            Globals.gaugename = "speedo";
                            Globals.SpeedoShow = "n";
                            Globals.Speedovalp2 = Globals.gaugename + "," + Globals.SpeedoShow2 + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow2 + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle;
                            break;
                        case "panel 3":
                            Globals.gaugename = "speedo";
                            Globals.SpeedoShow = "n";
                            Globals.Speedovalp3 = Globals.gaugename + "," + Globals.SpeedoShow3 + "," + Globals.SpeedoNeedleWidth + "," + Globals.SpeedoNeedleLength + "," + Globals.SpeedoNeedleX + "," + Globals.SpeedoNeedleY + "," + Globals.SpeedoOffset + "," + Globals.SpeedoEnd + "," + Globals.SpeedoTop + "," + Globals.SpeedoTextShow3 + "," + Globals.SpeedoTextX + "," + Globals.SpeedoTextY + "," + Globals.SpeedoFontSize + "," + Globals.SpeedoTextStyle + "," + Globals.SpeedoNeedleType + "," + Globals.SpeedoNeedle;
                            break;
                    }
                    break;

            }

        }

    }
}

