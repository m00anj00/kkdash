namespace kkdash
{
    class Globals
    {
        public static int mouseposX { get; set; }
        public static int mouseposY { get; set; }

        public static string P1BG { get; set; }
        public static string P2BG { get; set; }
        public static string P3BG { get; set; }

        public static string showP1 { get; set; }
        public static string showP2 { get; set; }
        public static string showP3 { get; set; }

        //General
        public static string gaugename { get; set; }
        public static string ConfigFileName { get; set; }
        public static string flocation { get; set; }
        public static string flocationName { get; set; }

        public static string p1DispWidth { get; set; }
        public static string p2DispWidth { get; set; }
        public static string p3DispWidth { get; set; }
        public static string p1DispHeight { get; set; }
        public static string p2DispHeight { get; set; }
        public static string p3DispHeight { get; set; }

        //can/serial3/ethernet
        //Panel 1        
        public static string p1connection { get; set; }
        public static string p2connection { get; set; }
        public static string p3connection { get; set; }

        public static string SerCanP1Ecu { get; set; }          // Serial3 / can        ---   cmbSerCanP1ECU
        public static string SerCanPortP1Ecu { get; set; }	    // /dev/ttyS0 can0
        public static string SerCanSpeedP1Ecu { get; set; }	    // 115200	125k
        public static string SerCanAddressP1Ecu { get; set; }   // 0x101 --both Panel 1 and ECU config
        public static string SerCanAddressP1 { get; set; }   // 0x101 --both Panel 1 and ECU config

        public static string SerCanP1P2 { get; set; }           // serial3 / can / ethernet  ---   cmbSerCanP1P2
        public static string SerCanPortP1P2 { get; set; }       // /dev/ttyS0 can0  --both Panel 1 and Panel 2 config
        public static string SerCanSpeedP1P2 { get; set; }      // 115200	125k    --both Panel 1 and Panel 2 config
        public static string SerCanAddressP1P2 { get; set; }	// 0x102 --both Panel 1 and Panel 2 config				

        public static string SerCanP1P3 { get; set; }           // can / ethernet            ---   cmbSerCanP1P3
        public static string SerCanPortP1P3 { get; set; }       // can0             --both Panel 1 and Panel 3 config     
        public static string SerCanSpeedP1P3 { get; set; }      // 125k             --both Panel 1 and Panel 3 config
        public static string SerCanAddressP1P3 { get; set; }	// 0x103 --both Panel 1 and Panel 3 config				

        public static string User1CanOffset { get; set; }
        public static string User2CanOffset { get; set; }
        public static string User3CanOffset { get; set; }
        public static string User4CanOffset { get; set; }

        //user gauge names
        public static string User1name { get; set; }
        public static string User2name { get; set; }
        public static string User3name { get; set; }
        public static string User4name { get; set; }

        public static string User1valp1 { get; set; }
        public static string User1valp2 { get; set; }
        public static string User1valp3 { get; set; }
        public static string User1valp4 { get; set; }
        public static string User2valp1 { get; set; }
        public static string User2valp2 { get; set; }
        public static string User2valp3 { get; set; }
        public static string User2valp4 { get; set; }
        public static string User3valp1 { get; set; }
        public static string User3valp2 { get; set; }
        public static string User3valp3 { get; set; }
        public static string User3valp4 { get; set; }
        public static string User4valp1 { get; set; }
        public static string User4valp2 { get; set; }
        public static string User4valp3 { get; set; }
        public static string User4valp4 { get; set; }

        //speedo
        public static string SpeedoShow { get; set; }
        public static string SpeedoNeedle { get; set; }
        public static string SpeedoNeedleType { get; set; }
        public static string SpeedoNeedleWidth { get; set; }
        public static string SpeedoNeedleLength { get; set; }
        public static string SpeedoNeedleX { get; set; }
        public static string SpeedoNeedleY { get; set; }
        public static string SpeedoOffset { get; set; }
        public static string SpeedoEnd { get; set; }
        public static string SpeedoTop { get; set; }
        public static string SpeedoTextShow { get; set; }
        public static string SpeedoTextX { get; set; }
        public static string SpeedoTextY { get; set; }
        public static string SpeedoFontSize { get; set; }
        public static string SpeedoTextStyle { get; set; }
        //tacho
        public static string TachoShow { get; set; }
        public static string TachoNeedle { get; set; }
        public static string TachoNeedleType { get; set; }
        public static string TachoNeedleWidth { get; set; }
        public static string TachoNeedleLength { get; set; }
        public static string TachoNeedleX { get; set; }
        public static string TachoNeedleY { get; set; }
        public static string TachoOffset { get; set; }
        public static string TachoEnd { get; set; }
        public static string TachoTop { get; set; }
        public static string TachoTextShow { get; set; }
        public static string TachoTextX { get; set; }
        public static string TachoTextY { get; set; }
        public static string TachoFontSize { get; set; }
        public static string TachoTextStyle { get; set; }

        public static string BoostShow { get; set; }
        public static string BoostNeedle { get; set; }
        public static string BoostNeedleType { get; set; }
        public static string BoostNeedleWidth { get; set; }
        public static string BoostNeedleLength { get; set; }
        public static string BoostNeedleX { get; set; }
        public static string BoostNeedleY { get; set; }
        public static string BoostOffset { get; set; }
        public static string BoostEnd { get; set; }
        public static string BoostTop { get; set; }
        public static string BoostTextShow { get; set; }
        public static string BoostTextX { get; set; }
        public static string BoostTextY { get; set; }
        public static string BoostFontSize { get; set; }
        public static string BoostTextStyle { get; set; }

        public static string TempShow { get; set; }
        public static string TempNeedle { get; set; }
        public static string TempNeedleType { get; set; }
        public static string TempNeedleWidth { get; set; }
        public static string TempNeedleLength { get; set; }
        public static string TempNeedleX { get; set; }
        public static string TempNeedleY { get; set; }
        public static string TempOffset { get; set; }
        public static string TempEnd { get; set; }
        public static string TempTop { get; set; }
        public static string TempTextShow { get; set; }
        public static string TempTextX { get; set; }
        public static string TempTextY { get; set; }
        public static string TempFontSize { get; set; }
        public static string TempTextStyle { get; set; }

        public static string OilShow { get; set; }
        public static string OilNeedle { get; set; }
        public static string OilNeedleType { get; set; }
        public static string OilNeedleWidth { get; set; }
        public static string OilNeedleLength { get; set; }
        public static string OilNeedleX { get; set; }
        public static string OilNeedleY { get; set; }
        public static string OilOffset { get; set; }
        public static string OilEnd { get; set; }
        public static string OilTop { get; set; }
        public static string OilTextShow { get; set; }
        public static string OilTextX { get; set; }
        public static string OilTextY { get; set; }
        public static string OilFontSize { get; set; }
        public static string OilTextStyle { get; set; }

        public static string OilTShow { get; set; }
        public static string OilTNeedle { get; set; }
        public static string OilTNeedleType { get; set; }
        public static string OilTNeedleWidth { get; set; }
        public static string OilTNeedleLength { get; set; }
        public static string OilTNeedleX { get; set; }
        public static string OilTNeedleY { get; set; }
        public static string OilTOffset { get; set; }
        public static string OilTEnd { get; set; }
        public static string OilTTop { get; set; }
        public static string OilTTextShow { get; set; }
        public static string OilTTextX { get; set; }
        public static string OilTTextY { get; set; }
        public static string OilTFontSize { get; set; }
        public static string OilTTextStyle { get; set; }

        public static string FuelShow { get; set; }
        public static string FuelNeedle { get; set; }
        public static string FuelNeedleType { get; set; }
        public static string FuelNeedleWidth { get; set; }
        public static string FuelNeedleLength { get; set; }
        public static string FuelNeedleX { get; set; }
        public static string FuelNeedleY { get; set; }
        public static string FuelOffset { get; set; }
        public static string FuelEnd { get; set; }
        public static string FuelTop { get; set; }
        public static string FuelTextShow { get; set; }
        public static string FuelTextX { get; set; }
        public static string FuelTextY { get; set; }
        public static string FuelFontSize { get; set; }
        public static string FuelTextStyle { get; set; }

        public static string FuelTShow { get; set; }
        public static string FuelTNeedle { get; set; }
        public static string FuelTNeedleType { get; set; }
        public static string FuelTNeedleWidth { get; set; }
        public static string FuelTNeedleLength { get; set; }
        public static string FuelTNeedleX { get; set; }
        public static string FuelTNeedleY { get; set; }
        public static string FuelTOffset { get; set; }
        public static string FuelTEnd { get; set; }
        public static string FuelTTop { get; set; }
        public static string FuelTTextShow { get; set; }
        public static string FuelTTextX { get; set; }
        public static string FuelTTextY { get; set; }
        public static string FuelTFontSize { get; set; }
        public static string FuelTTextStyle { get; set; }

        public static string FuelPShow { get; set; }
        public static string FuelPNeedle { get; set; }
        public static string FuelPNeedleType { get; set; }
        public static string FuelPNeedleWidth { get; set; }
        public static string FuelPNeedleLength { get; set; }
        public static string FuelPNeedleX { get; set; }
        public static string FuelPNeedleY { get; set; }
        public static string FuelPOffset { get; set; }
        public static string FuelPEnd { get; set; }
        public static string FuelPTop { get; set; }
        public static string FuelPTextShow { get; set; }
        public static string FuelPTextX { get; set; }
        public static string FuelPTextY { get; set; }
        public static string FuelPFontSize { get; set; }
        public static string FuelPTextStyle { get; set; }

        public static string User1Show { get; set; }
        public static string User1Needle { get; set; }
        public static string User1NeedleType { get; set; }
        public static string User1NeedleWidth { get; set; }
        public static string User1NeedleLength { get; set; }
        public static string User1NeedleX { get; set; }
        public static string User1NeedleY { get; set; }
        public static string User1Offset { get; set; }
        public static string User1End { get; set; }
        public static string User1Top { get; set; }
        public static string User1TextShow { get; set; }
        public static string User1TextX { get; set; }
        public static string User1TextY { get; set; }
        public static string User1FontSize { get; set; }
        public static string User1TextStyle { get; set; }

        public static string User2Show { get; set; }
        public static string User2Needle { get; set; }
        public static string User2NeedleType { get; set; }
        public static string User2NeedleWidth { get; set; }
        public static string User2NeedleLength { get; set; }
        public static string User2NeedleX { get; set; }
        public static string User2NeedleY { get; set; }
        public static string User2Offset { get; set; }
        public static string User2End { get; set; }
        public static string User2Top { get; set; }
        public static string User2TextShow { get; set; }
        public static string User2TextX { get; set; }
        public static string User2TextY { get; set; }
        public static string User2FontSize { get; set; }
        public static string User2TextStyle { get; set; }

        public static string User3Show { get; set; }
        public static string User3Needle { get; set; }
        public static string User3NeedleType { get; set; }
        public static string User3NeedleWidth { get; set; }
        public static string User3NeedleLength { get; set; }
        public static string User3NeedleX { get; set; }
        public static string User3NeedleY { get; set; }
        public static string User3Offset { get; set; }
        public static string User3End { get; set; }
        public static string User3Top { get; set; }
        public static string User3TextShow { get; set; }
        public static string User3TextX { get; set; }
        public static string User3TextY { get; set; }
        public static string User3FontSize { get; set; }
        public static string User3TextStyle { get; set; }

        public static string User4Show { get; set; }
        public static string User4Needle { get; set; }
        public static string User4NeedleType { get; set; }
        public static string User4NeedleWidth { get; set; }
        public static string User4NeedleLength { get; set; }
        public static string User4NeedleX { get; set; }
        public static string User4NeedleY { get; set; }
        public static string User4Offset { get; set; }
        public static string User4End { get; set; }
        public static string User4Top { get; set; }
        public static string User4TextShow { get; set; }
        public static string User4TextX { get; set; }
        public static string User4TextY { get; set; }
        public static string User4FontSize { get; set; }
        public static string User4TextStyle { get; set; }

        //Panel 1
        public static string panel1path { get; set; }
        public static string Speedovalp1 { get; set; }
        public static string Tachovalp1 { get; set; }
        public static string Boostvalp1 { get; set; }
        public static string Tempvalp1 { get; set; }
        public static string Oilvalp1 { get; set; }
        public static string OilTvalp1 { get; set; }
        public static string Fuelvalp1 { get; set; }
        public static string FuelTvalp1 { get; set; }
        public static string FuelPvalp1 { get; set; }
        public static string p1disptxt { get; set; }

        public static string canser1 { get; set; }
        public static string canval1 { get; set; }
        public static string serval1 { get; set; }
        public static string commsP1S { get; set; }
        public static string commsP1C { get; set; }
        public static string commsP1Sspeed { get; set; }
        public static string commsP1Cspeed { get; set; }

        public static string PanelBG1 { get; set; }
        public static string PanelW1 { get; set; }
        public static string PanelH1 { get; set; }
        public static string PanelIP1 { get; set; }

        public static string SpeedoTB1 { get; set; }
        public static string TachoTB1 { get; set; }
        public static string BoostTB1 { get; set; }
        public static string TempTB1 { get; set; }
        public static string OilTB1 { get; set; }
        public static string OilTTB1 { get; set; }
        public static string FuelTB1 { get; set; }
        public static string FuelTTB1 { get; set; }
        public static string FuelPTB1 { get; set; }
        public static string User1PTB1 { get; set; }
        public static string User2PTB1 { get; set; }
        public static string User3PTB1 { get; set; }
        public static string User4PTB1 { get; set; }

        //Panel 2
        public static string panel2path { get; set; }
        public static string Speedovalp2 { get; set; }
        public static string Tachovalp2 { get; set; }
        public static string Boostvalp2 { get; set; }
        public static string Tempvalp2 { get; set; }
        public static string Oilvalp2 { get; set; }
        public static string OilTvalp2 { get; set; }
        public static string Fuelvalp2 { get; set; }
        public static string FuelTvalp2 { get; set; }
        public static string FuelPvalp2 { get; set; }
        public static string p2disptxt { get; set; }

        public static string canser2 { get; set; }
        public static string canval2 { get; set; }
        public static string serval2 { get; set; }
        public static string commsP2S { get; set; }
        public static string commsP2C { get; set; }
        public static string commsP2Sspeed { get; set; }
        public static string commsP2Cspeed { get; set; }

        public static string PanelBG2 { get; set; }
        public static string PanelW2 { get; set; }
        public static string PanelH2 { get; set; }
        public static string PanelIP2 { get; set; }

        public static string SpeedoTB2 { get; set; }
        public static string TachoTB2 { get; set; }
        public static string BoostTB2 { get; set; }
        public static string TempTB2 { get; set; }
        public static string OilTB2 { get; set; }
        public static string OilTTB2 { get; set; }
        public static string FuelTB2 { get; set; }
        public static string FuelTTB2 { get; set; }
        public static string FuelPTB2 { get; set; }
        public static string User1PTB2 { get; set; }
        public static string User2PTB2 { get; set; }
        public static string User3PTB2 { get; set; }
        public static string User4PTB2 { get; set; }

        //Panel 3
        public static string panel3path { get; set; }
        public static string Speedovalp3 { get; set; }
        public static string Tachovalp3 { get; set; }
        public static string Boostvalp3 { get; set; }
        public static string Tempvalp3 { get; set; }
        public static string Oilvalp3 { get; set; }
        public static string OilTvalp3 { get; set; }
        public static string Fuelvalp3 { get; set; }
        public static string FuelTvalp3 { get; set; }
        public static string FuelPvalp3 { get; set; }
        public static string p3disptxt { get; set; }

        public static string canser3 { get; set; }
        public static string canval3 { get; set; }
        public static string serval3 { get; set; }
        public static string commsP3S { get; set; }
        public static string commsP3C { get; set; }
        public static string commsP3Sspeed { get; set; }
        public static string commsP3Cspeed { get; set; }

        public static string PanelBG3 { get; set; }
        public static string PanelW3 { get; set; }
        public static string PanelH3 { get; set; }
        public static string PanelIP3 { get; set; }

        public static string SpeedoTB3 { get; set; }
        public static string TachoTB3 { get; set; }
        public static string BoostTB3 { get; set; }
        public static string TempTB3 { get; set; }
        public static string OilTB3 { get; set; }
        public static string OilTTB3 { get; set; }
        public static string FuelTB3 { get; set; }
        public static string FuelTTB3 { get; set; }
        public static string FuelPTB3 { get; set; }
        public static string User1PTB3 { get; set; }
        public static string User2PTB3 { get; set; }
        public static string User3PTB3 { get; set; }
        public static string User4PTB3 { get; set; }
    }
}
