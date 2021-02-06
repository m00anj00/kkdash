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

        public static void WriteCSVfile(int PanelNo)
        {
            string PNO = "";
            string speedoval = "", tachoval = "", boostval = "", tempval = "", oilval = "", oiltval = "", fuelval = "", fueltval = "", fuelpval = "", user1val = "", user2val = "", user3val = "", user4val = "";
            string strSeperator = ",";
            string strFilePath = "";
            string disptxt = "";
            string p1conn = ""; string p2conn = ""; string p3conn = "";
            string pantxt = "";

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
                    p1conn = Globals.p1connection;
                    p2conn = Globals.p2connection;
                    p3conn = Globals.p3connection;


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
                new string[] { "#backgrounds,panel1,panel2,panel3" },
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
