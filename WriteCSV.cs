using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace dashconfigurator
{
    public class WriteCSV
    {
        public static void WriteCSVfile(int PanelNo)
        {
            switch (PanelNo)
            {
                case 1:
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.InitialDirectory = "c:\\";
                        saveFileDialog.FilterIndex = 2;
                        saveFileDialog.RestoreDirectory = true;
                        saveFileDialog.FileName = "panel1.csv";
                        saveFileDialog.Filter = "csv file (*.csv)|*.csv";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string currentDirectory = Path.GetDirectoryName(saveFileDialog.FileName);

                            Globals.flocation = Path.GetFullPath(currentDirectory);

                            // write the panel1.csv config file
                            string strFilePath = saveFileDialog.FileName;
                            string strSeperator = ",";
                            StringBuilder saOutput = new StringBuilder();

                            string[][] inaOutput = new string[][]{
                            new string []{"panel,1,,,,,,,,,,,,," },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#DISPLAY PARAMETERS,,,,,,,,,,,,,,"},
                            new string []{"#pos x=0,y=0 is the center of the display,,,,,,,,,,,,,"},
                            new string []{"#displaysize,w,h,refresh rate,,,,,,,,,,," },
                            new string []{ Globals.p1disptxt },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#CAN type,port,speed:  options are: serial, /dev/ttyS0, 115200, slcan, /dev/ttyUSB0@115200, pcan,can0, 500k #see: https://python-can.readthedocs.io/en/stable/configuration.html" },
                            new string []{ "#can,serial,/dev/ttyS0,115200" },
                            new string []{ "#can,pcan,can0,500k,,,,,,,,,,," },
                            new string []{ Globals.canser1,Globals.canval1, Globals.serval1, Globals.commsP1S, Globals.commsP1C, Globals.commsP1Sspeed, Globals.commsP1Cspeed,",,,,,,,," },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#GAUGE / BAR GRAPH,,,,,,,,,,,,,," },
                            new string []{"#GAUGE STYLE:" },
                            new string []{"#name,show,needle width,needle height,needlex,needley,offset,degreesend,topval,textshow,textX,textY,fontsize,fontstyle,type,needle image" },
                            new string []{"#BAR GRAPH STYLE: (barV or barH)" },
                            new string []{"#name,show,bar width(V),bar height(H),gaugex,gaugey,warn%,guageend,topval,textshow,textX,textY,fontsize,fontstyle,type (barV/barH),0=warn% below-1=warn% above" },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{ "Userdefined",Globals.User1name, Globals.User2name, Globals.User3name, Globals.User4name },
                            new string[] { Globals.Speedovalp1 },
                            new string []{ Globals.Tachovalp1 },
                            new string []{ Globals.Boostvalp1 },
                            new string []{ Globals.Tempvalp1 },
                            new string []{ Globals.Oilvalp1 },
                            new string []{ Globals.OilTvalp1 },
                            new string []{ Globals.Fuelvalp1 },
                            new string []{ Globals.FuelTvalp1 },
                            new string []{ Globals.FuelPvalp1 },
                            new string []{ Globals.User1valp1 },
                            new string []{ Globals.User2valp1 },
                            new string []{ Globals.User3valp1 },
                            new string []{ Globals.User4valp1 },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#WARNING AND INFO LIGHTS:" },
                            new string []{"#category,item,X,Y,item,X,Y,item,X,Y,item,X,Y," },
                            new string []{"symbolsInfo,seatbelts,10,-140,lowoil,0,0,demister,0,0,battery,0,0,," },
                            new string []{"#CENTRAL PANEL CRITERIA" },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#ODOMETER LOCATION / STYLE" },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#TRIP / ECONOMY COMPUTER DETAILS" },
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
                                MessageBox.Show("Failed writing panel1.csv");
                            }
                        }
                    }
                    break;

                case 2:
                    {
                        string strSeperator = ",";
                        StringBuilder sbOutput = new StringBuilder();

                        string[][] inbOutput = new string[][]{
                            new string []{"panel,2,,,,,,,,,,,,," },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#DISPLAY PARAMETERS,,,,,,,,,,,,,,"},
                            new string []{"#pos x=0,y=0 is the center of the display,,,,,,,,,,,,,"},
                            new string []{"#displaysize,w,h,refresh rate,,,,,,,,,,," },
                            new string []{ Globals.p2disptxt },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#CAN type,port,speed:  options are: serial, /dev/ttyS0, 115200, slcan, /dev/ttyUSB0@115200, pcan,can0, 500k #see: https://python-can.readthedocs.io/en/stable/configuration.html" },
                            new string []{ "#can,serial,/dev/ttyS0,115200" },
                            new string []{ "#can,pcan,can0,500k,,,,,,,,,,," },
                            new string []{ Globals.canser2,Globals.canval2, Globals.serval2, Globals.commsP2S, Globals.commsP2C, Globals.commsP2Sspeed, Globals.commsP2Cspeed,",,,,,,,," },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#GAUGE / BAR GRAPH,,,,,,,,,,,,,," },
                            new string []{"#GAUGE STYLE:" },
                            new string []{"#name,show,needle width,needle height,needlex,needley,offset,degreesend,topval,textshow,textX,textY,fontsize,fontstyle,type,needle image" },
                            new string []{"#BAR GRAPH STYLE: (barV or barH)" },
                            new string []{"#name,show,bar width(V),bar height(H),gaugex,gaugey,warn%,guageend,topval,textshow,textX,textY,fontsize,fontstyle,type (barV/barH),0=warn% below-1=warn% above" },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{ "Userdefined",Globals.User1name, Globals.User2name, Globals.User3name, Globals.User4name },
                            new string[] { Globals.Speedovalp2 },
                            new string []{ Globals.Tachovalp2 },
                            new string []{ Globals.Boostvalp2 },
                            new string []{ Globals.Tempvalp2 },
                            new string []{ Globals.Oilvalp2 },
                            new string []{ Globals.OilTvalp2 },
                            new string []{ Globals.Fuelvalp2 },
                            new string []{ Globals.FuelTvalp2 },
                            new string []{ Globals.FuelPvalp2 },
                            new string []{ Globals.User1valp2 },
                            new string []{ Globals.User2valp2 },
                            new string []{ Globals.User3valp2 },
                            new string []{ Globals.User4valp2 },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#WARNING AND INFO LIGHTS:" },
                            new string []{"#category,item,X,Y,item,X,Y,item,X,Y,item,X,Y," },
                            new string []{"symbolsInfo,seatbelts,10,-140,lowoil,0,0,demister,0,0,battery,0,0,," },
                            new string []{"#CENTRAL PANEL CRITERIA" },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#ODOMETER LOCATION / STYLE" },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#TRIP / ECONOMY COMPUTER DETAILS" },
                    };

                        try
                        {
                            int ilength = inbOutput.GetLength(0);
                            for (int i = 0; i < ilength; i++)
                            {
                                sbOutput.AppendLine(string.Join(strSeperator, inbOutput[i]));
                                File.WriteAllText(Globals.flocation + "\\panel2.csv", sbOutput.ToString());
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Failed writing panel2.csv");
                        }
                    }
                    break;

                case 3:
                    {
                        string strSeperator = ",";
                        StringBuilder scOutput = new StringBuilder();

                        string[][] incOutput = new string[][]{
                            new string []{"panel,3,,,,,,,,,,,,," },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#DISPLAY PARAMETERS,,,,,,,,,,,,,,"},
                            new string []{"#pos x=0,y=0 is the center of the display,,,,,,,,,,,,,"},
                            new string []{"#displaysize,w,h,refresh rate,,,,,,,,,,," },
                            new string []{ Globals.p3disptxt },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#CAN type,port,speed:  options are: serial, /dev/ttyS0, 115200, slcan, /dev/ttyUSB0@115200, pcan,can0, 500k #see: https://python-can.readthedocs.io/en/stable/configuration.html" },
                            new string []{ "#can,serial,/dev/ttyS0,115200" },
                            new string []{ "#can,pcan,can0,500k,,,,,,,,,,," },
                            new string []{ Globals.canser3,Globals.canval3, Globals.serval3, Globals.commsP3S, Globals.commsP3C, Globals.commsP3Sspeed, Globals.commsP3Cspeed,",,,,,,,," },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#GAUGE / BAR GRAPH,,,,,,,,,,,,,," },
                            new string []{"#GAUGE STYLE:" },
                            new string []{"#name,show,needle width,needle height,needlex,needley,offset,degreesend,topval,textshow,textX,textY,fontsize,fontstyle,type,needle image" },
                            new string []{"#BAR GRAPH STYLE: (barV or barH)" },
                            new string []{"#name,show,bar width(V),bar height(H),gaugex,gaugey,warn%,guageend,topval,textshow,textX,textY,fontsize,fontstyle,type (barV/barH),0=warn% below-1=warn% above" },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{ "Userdefined",Globals.User1name, Globals.User2name, Globals.User3name, Globals.User4name },
                            new string[] { Globals.Speedovalp3 },
                            new string []{ Globals.Tachovalp3 },
                            new string []{ Globals.Boostvalp3 },
                            new string []{ Globals.Tempvalp3 },
                            new string []{ Globals.Oilvalp3 },
                            new string []{ Globals.OilTvalp3 },
                            new string []{ Globals.Fuelvalp3 },
                            new string []{ Globals.FuelTvalp3 },
                            new string []{ Globals.FuelPvalp3 },
                            new string []{ Globals.User1valp3 },
                            new string []{ Globals.User2valp3 },
                            new string []{ Globals.User3valp3 },
                            new string []{ Globals.User4valp3 },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#WARNING AND INFO LIGHTS:" },
                            new string []{"#category,item,X,Y,item,X,Y,item,X,Y,item,X,Y," },
                            new string []{"symbolsInfo,seatbelts,10,-140,lowoil,0,0,demister,0,0,battery,0,0,," },
                            new string []{"#CENTRAL PANEL CRITERIA" },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#ODOMETER LOCATION / STYLE" },
                            new string []{",,,,,,,,,,,,,," },
                            new string []{"#TRIP / ECONOMY COMPUTER DETAILS" },
                    };

                        try
                        {
                            int ilength = incOutput.GetLength(0);
                            for (int i = 0; i < ilength; i++)
                            {
                                scOutput.AppendLine(string.Join(strSeperator, incOutput[i]));
                                File.WriteAllText(Globals.flocation + "\\panel3.csv", scOutput.ToString());
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Failed writing panel3.csv");
                        }
                    }
                    break;
            }
        }
    }
}
