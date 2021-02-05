using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace kkdash
{
    public class WriteCSV
    {

        public static void ShowSave(int panelno)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
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

        public static void WriteCSVfile(int PanelNo)
        {
            string PNO = "";
            string speedoval = "", tachoval = "", boostval = "", tempval = "", oilval = "", oiltval = "", fuelval = "", fueltval = "", fuelpval = "", user1val = "", user2val = "", user3val = "", user4val = "";
            string strSeperator = ",";
            string strFilePath = "";
            string disptxt = "";
            string canser = ""; string vcanval = ""; string vserval = ""; string commsPS = ""; string commsPC = ""; string commsPSspeed = ""; string commsPCspeed = "";

            StringBuilder saOutput = new StringBuilder();

            //ECU connection: SerCanP1Ecu, SerCanPortP1Ecu, SerCanSpeedP1Ecu, SerCanAddressP1Ecu, SerCanEnabledP1P2, SerCanP1P2, SerCanPortP1P2, SerCanSpeedP1P2, SerCanAddressP1P2, SerCanEnabledP1P3, SerCanP1P3, SerCanPortP1P3, SerCanSpeedP1P3, SerCanAddressP1P3,,                 
            switch (PanelNo)
            {
                case 1:
                    if (Globals.flocation == "")
                    {
                        ShowSave(1);
                    }
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
                    disptxt = Globals.p1disptxt;

                    canser = Globals.canser1;
                    vcanval = Globals.canval1; 
                    vserval = Globals.serval1; 
                    commsPS = Globals.commsP1S; 
                    commsPC = Globals.commsP1C; 
                    commsPSspeed = Globals.commsP1Sspeed; 
                    commsPCspeed = Globals.commsP1Cspeed;

                    PNO = "1";
                    break;

                case 2:
                    if (Globals.flocation == "")
                    {
                        ShowSave(2);
                    }
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
                    disptxt = Globals.p2disptxt;

                    canser = Globals.canser2;
                    vcanval = Globals.canval2;
                    vserval = Globals.serval2;
                    commsPS = Globals.commsP2S;
                    commsPC = Globals.commsP2C;
                    commsPSspeed = Globals.commsP1Sspeed;
                    commsPCspeed = Globals.commsP1Cspeed;
                    PNO = "2";
                    break;

                case 3:
                    if (Globals.flocation == "")
                    {
                        ShowSave(3);
                    }
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
                    disptxt = Globals.p3disptxt;

                    canser = Globals.canser3;
                    vcanval = Globals.canval3;
                    vserval = Globals.serval3;
                    commsPS = Globals.commsP3S;
                    commsPC = Globals.commsP3C;
                    commsPSspeed = Globals.commsP3Sspeed;
                    commsPCspeed = Globals.commsP3Cspeed;
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
                new string[] { ",,,,,,,,,,,,,," },
                new string[] { "#CAN type,port,speed:  options are: serial, /dev/ttyS0, 115200, slcan, /dev/ttyUSB0@115200, pcan,can0, 500k #see: https://python-can.readthedocs.io/en/stable/configuration.html" },
                new string[] { "#can,serial,/dev/ttyS0,115200" },
                new string[] { "#can,pcan,can0,500k,,,,,,,,,,," },
                new string[] { canser, vcanval, vserval, commsPS, commsPC, commsPSspeed, commsPCspeed, ",,,,,,,," },
                new string[] { ",,,,,,,,,,,,,," },
                new string[] { "#GAUGE / BAR GRAPH,,,,,,,,,,,,,," },
                new string[] { "#GAUGE STYLE:" },
                new string[] { "#name,show,needle width,needle height,needlex,needley,offset,degreesend,topval,textshow,textX,textY,fontsize,fontstyle,type,needle image" },
                new string[] { "#BAR GRAPH STYLE: (barV or barH)" },
                new string[] { "#name,show,bar width(V),bar height(H),gaugex,gaugey,warn%,guageend,topval,textshow,textX,textY,fontsize,fontstyle,type (barV/barH),0=warn% below-1=warn% above" },
                new string[] { ",,,,,,,,,,,,,," },
                new string[] { "Userdefined", Globals.User1name, Globals.User2name, Globals.User3name, Globals.User4name,",,,,,,,,,," },
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
                new string[] { "#category,item,X,Y,item,X,Y,item,X,Y,item,X,Y," },
                new string[] { "symbolsInfo,seatbelts,10,-140,lowoil,0,0,demister,0,0,battery,0,0,," },
                new string[] { "#CENTRAL PANEL CRITERIA" },
                new string[] { ",,,,,,,,,,,,,," },
                new string[] { "#ODOMETER LOCATION / STYLE" },
                new string[] { ",,,,,,,,,,,,,," },
                new string[] { "#TRIP / ECONOMY COMPUTER DETAILS" },
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
