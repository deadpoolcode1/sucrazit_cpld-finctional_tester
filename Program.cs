using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;
using System.Xml.Linq;
using System.Runtime.InteropServices.ComTypes;
using static sucrazit.ExportToExcel;
using static sucrazit.GalilTCPClient;
using static sucrazit.PortChat;
using System.Configuration;
using static sucrazit.ComClient;

using Ganss.Excel;

namespace sucrazit
{
    public class Hatch
    {

        enum InputBytesLtoR
        {
            e_Hatch_1_UP_A = 0,
            e_Hatch_1_UP_B = 1,
            e_Hatch_1_Down_A = 2,
            e_Hatch_1_Down_B = 3,
            e_Hatch_2_UP_A = 4,
            e_Hatch_2_UP_B = 5,
            e_Hatch_2_Down_A = 6,
            e_Hatch_2_Down_B = 7,
            e_Hatch_3_UP_A = 8,
            e_Hatch_3_UP_B = 9,
            e_Hatch_3_Down_A = 10,
            e_Hatch_3_Down_B = 11,
            e_Hatch_4_UP_A = 12,
            e_Hatch_4_UP_B = 13,
            e_Hatch_4_Down_A = 14,
            e_Hatch_4_Down_B = 15,
            e_Hatch_5_UP_A = 16,
            e_Hatch_5_UP_B = 17,
            e_Hatch_5_Down_A = 18,
            e_Hatch_5_Down_B = 19,
            e_Hatch_6_UP_A = 20,
            e_Hatch_6_UP_B = 21,
            e_Hatch_6_Down_A = 22,
            e_Hatch_6_Down_B = 23,
            e_Hatch_7_UP_A = 24,
            e_Hatch_7_UP_B = 25,
            e_Hatch_7_Down_A = 26,
            e_Hatch_7_Down_B = 27,
            e_Hatch_8_UP_A = 28,
            e_Hatch_8_UP_B = 29,
            e_Hatch_8_Down_A = 30,
            e_Hatch_8_Down_B = 31,
            e_Uptake_UP_A = 32,
            e_Uptake_UP_B = 33,
            e_Uptake_Down_A = 34,
            e_Uptake_Down_B = 35,
            e_ExtMSL_sel1 = 36,
            e_ExtMSL_sel2 = 37,
            e_ExtMSL_sel3 = 38,
            e_ExtMSL_sel4 = 39,
            e_ExtMSL_sel5 = 40,
            e_ExtMSL_sel6 = 41,
            e_ExtMSL_sel7 = 42,
            e_ExtMSL_sel8 = 43,
            e_IntMSL_sel1 = 44,
            e_IntMSL_sel2 = 45,
            e_IntMSL_sel3 = 46,
            e_IntMSL_sel4 = 47,
            e_IntMSL_sel5 = 48,
            e_IntMSL_sel6 = 49,
            e_IntMSL_sel7 = 50,
            e_IntMSL_sel8 = 51,
            e_FunCPLD_GA1 = 52,
            e_FunCPLD_GA2 = 53,
            e_FunCPLD_CA1 = 54,
            e_FunCPLD_CA2 = 55
        }

        enum InputBytesRtoL
        {
            e_FunCPLD_CA2 = 0,
            e_FunCPLD_CA1 = 1,
            e_FunCPLD_GA2 = 2,
            e_FunCPLD_GA1 = 3,
            e_IntMSL_sel8 = 4,
            e_IntMSL_sel7 = 5,
            e_IntMSL_sel6 = 6,
            e_IntMSL_sel5 = 7,
            e_IntMSL_sel4 = 8,
            e_IntMSL_sel3 = 9,
            e_IntMSL_sel2 = 10,
            e_IntMSL_sel1 = 11,
            e_ExtMSL_sel8 = 12,
            e_ExtMSL_sel7 = 13,
            e_ExtMSL_sel6 = 14,
            e_ExtMSL_sel5 = 15,
            e_ExtMSL_sel4 = 16,
            e_ExtMSL_sel3 = 17,
            e_ExtMSL_sel2 = 18,
            e_ExtMSL_sel1 = 19,
            e_Uptake_Down_B = 20,
            e_Uptake_Down_A = 21,
            e_Uptake_UP_B = 22,
            e_Uptake_UP_A = 23,
            e_Hatch_8_Down_B = 24,
            e_Hatch_8_Down_A = 25,
            e_Hatch_8_UP_B = 26,
            e_Hatch_8_UP_A = 27,
            e_Hatch_7_Down_B = 28,
            e_Hatch_7_Down_A = 29,
            e_Hatch_7_UP_B = 30,
            e_Hatch_7_UP_A = 31,
            e_Hatch_6_Down_B = 32,
            e_Hatch_6_Down_A = 33,
            e_Hatch_6_UP_B = 34,
            e_Hatch_6_UP_A = 35,
            e_Hatch_5_Down_B = 36,
            e_Hatch_5_Down_A = 37,
            e_Hatch_5_UP_B = 38,
            e_Hatch_5_UP_A = 39,
            e_Hatch_4_Down_B = 40,
            e_Hatch_4_Down_A = 41,
            e_Hatch_4_UP_B = 42,
            e_Hatch_4_UP_A = 43,
            e_Hatch_3_Down_B = 44,
            e_Hatch_3_Down_A = 45,
            e_Hatch_3_UP_B = 46,
            e_Hatch_3_UP_A = 47,
            e_Hatch_2_Down_B = 48,
            e_Hatch_2_Down_A = 49,
            e_Hatch_2_UP_B = 50,
            e_Hatch_2_UP_A = 51,
            e_Hatch_1_Down_B = 52,
            e_Hatch_1_Down_A = 53,
            e_Hatch_1_UP_B = 54,
            e_Hatch_1_UP_A = 55
        }



        enum OutputBytes
        {
            e_GA1 = 0,
            e_GA1Not = 1,
            e_CA1 = 2,
            e_CA1Not = 3,
            e_GA2 = 4,
            e_GA2Not = 5,
            e_CA2 = 6,
            e_CA2Not = 7,
            e_HatchSel1 = 8,
            e_HatchSel2 = 9,
            e_HatchSel3 = 10,
            e_HatchSel4 = 11,
            e_HatchSel5 = 12,
            e_HatchSel6 = 13,
            e_HatchSel7 = 14,
            e_HatchSel8 = 15,
            e_HatchOpen1 = 16,
            e_HatchOpen2 = 17,
            e_HatchOpen3 = 18,
            e_HatchOpen4 = 19,
            e_HatchOpen5 = 20,
            e_HatchOpen6 = 21,
            e_HatchOpen7 = 22,
            e_HatchOpen8 = 23,
            e_UpdakeOpen = 24,
            e_HatchClosed1 = 25,
            e_HatchClosed2 = 26,
            e_HatchClosed3 = 27,
            e_HatchClosed4 = 28,
            e_HatchClosed5 = 29,
            e_HatchClosed6 = 30,
            e_HatchClosed7 = 31,
            e_HatchClosed8 = 32
        }


        /* At this point I have considered that I know the value of LCU_sel, so I know whether to check
         * A or B (External or Internal). The logic is the same. */
        public static int HatchSelected_1stNible(int MSL_sel1, int MSL_sel2, int MSL_sel3, int MSL_sel4)
        {//This function returns which hatch has to be selected from the first nible(1-4)
            if (MSL_sel1 == 1 && MSL_sel2 == 0 && MSL_sel3 == 0 && MSL_sel4 == 0)
                return 1;
            else if (MSL_sel1 == 0 && MSL_sel2 == 1 && MSL_sel3 == 0 && MSL_sel4 == 0)
                return 2;
            else if (MSL_sel1 == 0 && MSL_sel2 == 0 && MSL_sel3 == 1 && MSL_sel4 == 0)
                return 3;
            else if (MSL_sel1 == 0 && MSL_sel2 == 0 && MSL_sel3 == 0 && MSL_sel4 == 1)
                return 4;
            else if (MSL_sel1 == 0 && MSL_sel2 == 0 && MSL_sel3 == 0 && MSL_sel4 == 0)
                return 0; //None hatch has been selected
            else
                return -1; //Fail select
        }

        public static int HatchSelected_2ndNible(int MSL_sel5, int MSL_sel6, int MSL_sel7, int MSL_sel8)
        {//This function returns which hatch has to be selected from the second nible(5-8)
            if (MSL_sel5 == 1 && MSL_sel6 == 0 && MSL_sel7 == 0 && MSL_sel8 == 0)
                return 5;
            else if (MSL_sel5 == 0 && MSL_sel6 == 1 && MSL_sel7 == 0 && MSL_sel8 == 0)
                return 6;
            else if (MSL_sel5 == 0 && MSL_sel6 == 0 && MSL_sel7 == 1 && MSL_sel8 == 0)
                return 7;
            else if (MSL_sel5 == 0 && MSL_sel6 == 0 && MSL_sel7 == 0 && MSL_sel8 == 1)
                return 8;
            else if (MSL_sel5 == 0 && MSL_sel6 == 0 && MSL_sel7 == 0 && MSL_sel8 == 0)
                return 0; //None hatch has been selected
            else
                return -1; //Fail select
        }




        public static bool IsHatchOpen(int Hatch_N_UP_A, int Hatch_N_UP_B, int Hatch_N_Down_A, int Hatch_N_Down_B)
        {//This function will check whether the hatch is open (true) or not (false)            

            if (Hatch_N_UP_A == 0 && Hatch_N_UP_B == 1 && Hatch_N_Down_A == 0 && Hatch_N_Down_B == 0)
                //sensor UP_A is wrong
                return true;
            else if (Hatch_N_UP_A == 1 && Hatch_N_UP_B == 0 && Hatch_N_Down_A == 0 && Hatch_N_Down_B == 0)
                ////sensor UP_B is wrong
                return true;
            else if (Hatch_N_UP_A == 1 && Hatch_N_UP_B == 1 && Hatch_N_Down_A == 0 && Hatch_N_Down_B == 0)
                //all sensors ok
                return true;
            else if (Hatch_N_UP_A == 1 && Hatch_N_UP_B == 1 && Hatch_N_Down_A == 0 && Hatch_N_Down_B == 1)
                //sensor Down_B is wrong
                return true;
            else if (Hatch_N_UP_A == 1 && Hatch_N_UP_B == 1 && Hatch_N_Down_A == 1 && Hatch_N_Down_B == 0)
                //sensor Down_A is wrong
                return true;
            else
                return false;
        }

        //bool answer = Hatch.IsHatchOpen(InputBytes.m_eHatch_1_UP_A, InputBytes.m_eHatch_1_UP_B,
        //    InputBytes.m_eHatch_1_Down_A,InputBytes.m_eHatch_1_Down_B)

        public static bool IsHatchClosed(int Hatch_N_UP_A, int Hatch_N_UP_B, int Hatch_N_Down_A, int Hatch_N_Down_B)
        {//This function will check whether the hatch is close (true) or not (false)

            if (Hatch_N_UP_A == 0 && Hatch_N_UP_B == 0 && Hatch_N_Down_A == 0 && Hatch_N_Down_B == 1)
                //sensor Down_A is wrong
                return true;
            else if (Hatch_N_UP_A == 0 && Hatch_N_UP_B == 0 && Hatch_N_Down_A == 1 && Hatch_N_Down_B == 0)
                //sensor Down_B is wrong
                return true;
            else if (Hatch_N_UP_A == 0 && Hatch_N_UP_B == 0 && Hatch_N_Down_A == 1 && Hatch_N_Down_B == 1)
                //all sensors ok
                return true;
            else if (Hatch_N_UP_A == 0 && Hatch_N_UP_B == 1 && Hatch_N_Down_A == 1 && Hatch_N_Down_B == 1)
                //sensor UP_B is wrong
                return true;
            else if (Hatch_N_UP_A == 1 && Hatch_N_UP_B == 0 && Hatch_N_Down_A == 1 && Hatch_N_Down_B == 1)
                //sensor UP_A is wrong
                return true;
            else
                return false;
        }

        public static bool IsUptakeOpen(int Uptake_UP_A, int Uptake_UP_B, int Uptake_Down_A, int Uptake_Down_B)
        {//This function will check whether the uptake is (true) open or not (false)

            if (Uptake_UP_A == 0 && Uptake_UP_B == 1 && Uptake_Down_A == 0 && Uptake_Down_B == 0)
                //sensor UP_A is wrong
                return true;
            else if (Uptake_UP_A == 1 && Uptake_UP_B == 0 && Uptake_Down_A == 0 && Uptake_Down_B == 0)
                //sensor UP_B is wrong
                return true;
            else if (Uptake_UP_A == 1 && Uptake_UP_B == 1 && Uptake_Down_A == 0 && Uptake_Down_B == 0)
                //all sensors ok
                return true;
            else if (Uptake_UP_A == 1 && Uptake_UP_B == 1 && Uptake_Down_A == 0 && Uptake_Down_B == 1)
                //sensor Down_B is wrong
                return true;
            else if (Uptake_UP_A == 1 && Uptake_UP_B == 1 && Uptake_Down_A == 1 && Uptake_Down_B == 0)
                //sensor Down_A is wrong
                return true;
            else
                return false;
        }


        //This function is using the outputs of the CPLD
        public static bool IsGlobalAbort1(int Hatch_sel1, int Hatch_sel2, int Hatch_sel3, int Hatch_sel4, int Hatches_opened_out1,
           int Hatches_opened_out2, int Hatches_opened_out3, int Hatches_opened_out4, int uptake_opened_out)
        {//This function will check whether there is a need for global_abort1 (true) or not (false)
            if (Hatch_sel1 == 1 && Hatches_opened_out1 == 0)
                return true;
            else if (Hatch_sel2 == 1 && Hatches_opened_out2 == 0)
                return true;
            else if (Hatch_sel3 == 1 && Hatches_opened_out3 == 0)
                return true;
            else if (Hatch_sel4 == 1 && Hatches_opened_out4 == 0)
                return true;
            else if (uptake_opened_out == 0)
                return true;
            else if (Hatch_sel1 == 0 && Hatch_sel2 == 0 && Hatch_sel3 == 0 && Hatch_sel4 == 0)
                return true;
            else
                return false;
        }


        public static bool IsGlobalAbort2(int Hatch_sel5, int Hatch_sel6, int Hatch_sel7, int Hatch_sel8, int Hatches_opened_out5,
           int Hatches_opened_out6, int Hatches_opened_out7, int Hatches_opened_out8, int uptake_opened_out)
        {//This function will check whether there is a need for global_abort2 (true) or not (false)
            if (Hatch_sel5 == 1 && Hatches_opened_out5 == 1)
                return true;
            else if (Hatch_sel6 == 1 && Hatches_opened_out6 == 1)
                return true;
            else if (Hatch_sel7 == 1 && Hatches_opened_out7 == 1)
                return true;
            else if (Hatch_sel8 == 1 && Hatches_opened_out8 == 1)
                return true;
            else if (uptake_opened_out == 0)
                return true;
            else if (Hatch_sel5 == 0 && Hatch_sel6 == 0 && Hatch_sel7 == 0 && Hatch_sel8 == 0)
                return true;
            else
                return false;
        }



        public static bool IsConsiderAbort1(int Hatch_sel1, int Hatch_sel2, int Hatch_sel3, int Hatch_sel4, int Hatches_closed_out1,
            int Hatches_closed_out2, int Hatches_closed_out3, int Hatches_closed_out4,
            int Hatches_closed_out5, int Hatches_closed_out6, int Hatches_closed_out7, int Hatches_closed_out8, int Hatch_sel5, int Hatch_sel6, int Hatch_sel7, int Hatch_sel8)
        {//This function will check whether there is a need for consider_abort1 (true) or not (false)
            if (Hatch_sel1 == 1 && (Hatches_closed_out2 == 0 || Hatches_closed_out3 == 0 || Hatches_closed_out4 == 0))
                return true;
            else if (Hatch_sel2 == 1 && (Hatches_closed_out1 == 0 || Hatches_closed_out3 == 0 || Hatches_closed_out4 == 0))
                return true;
            else if (Hatch_sel3 == 1 && (Hatches_closed_out2 == 0 || Hatches_closed_out1 == 0 || Hatches_closed_out4 == 0))
                return true;
            else if (Hatch_sel4 == 1 && (Hatches_closed_out2 == 0 || Hatches_closed_out3 == 0 || Hatches_closed_out1 == 0))
                return true;
            else if (Hatch_sel1 == 1 && ((Hatches_closed_out5 == 0 && Hatch_sel5 == 0) || (Hatches_closed_out6 == 0 && Hatch_sel6 == 0) ||
                (Hatches_closed_out7 == 0 && Hatch_sel7 == 0) || (Hatches_closed_out8 == 0 && Hatch_sel8 == 0)))
                return true;
            else if (Hatch_sel2 == 1 && ((Hatches_closed_out5 == 0 && Hatch_sel5 == 0) || (Hatches_closed_out6 == 0 && Hatch_sel6 == 0) ||
                (Hatches_closed_out7 == 0 && Hatch_sel7 == 0) || (Hatches_closed_out8 == 0 && Hatch_sel8 == 0)))
                return true;
            else if (Hatch_sel3 == 1 && ((Hatches_closed_out5 == 0 && Hatch_sel5 == 0) || (Hatches_closed_out6 == 0 && Hatch_sel6 == 0) ||
                (Hatches_closed_out7 == 0 && Hatch_sel7 == 0) || (Hatches_closed_out8 == 0 && Hatch_sel8 == 0)))
                return true;
            else if (Hatch_sel4 == 1 && ((Hatches_closed_out5 == 0 && Hatch_sel5 == 0) || (Hatches_closed_out6 == 0 && Hatch_sel6 == 0) ||
                (Hatches_closed_out7 == 0 && Hatch_sel7 == 0) || (Hatches_closed_out8 == 0 && Hatch_sel8 == 0)))
                return true;
            else
                return false;

        }

        public static bool IsConsiderAbort2(int Hatch_sel1, int Hatch_sel2, int Hatch_sel3, int Hatch_sel4, int Hatches_closed_out1,
            int Hatches_closed_out2, int Hatches_closed_out3, int Hatches_closed_out4, int Hatches_closed_out5, int Hatches_closed_out6,
            int Hatches_closed_out7, int Hatches_closed_out8, int Hatch_sel5, int Hatch_sel6, int Hatch_sel7, int Hatch_sel8)
        {//This function will check whether there is a need for consider_abort2 (true) or not (false)
            if (Hatch_sel5 == 1 && (Hatches_closed_out6 == 0 || Hatches_closed_out7 == 0 || Hatches_closed_out8 == 0))
                return true;
            else if (Hatch_sel6 == 1 && (Hatches_closed_out5 == 0 || Hatches_closed_out7 == 0 || Hatches_closed_out8 == 0))
                return true;
            else if (Hatch_sel7 == 1 && (Hatches_closed_out5 == 0 || Hatches_closed_out6 == 0 || Hatches_closed_out8 == 0))
                return true;
            else if (Hatch_sel8 == 1 && (Hatches_closed_out5 == 0 || Hatches_closed_out6 == 0 || Hatches_closed_out7 == 0))
                return true;
            else if (Hatch_sel5 == 1 && ((Hatches_closed_out1 == 0 && Hatch_sel1 == 0) || (Hatches_closed_out2 == 0 && Hatch_sel2 == 0) ||
                (Hatches_closed_out3 == 0 && Hatch_sel3 == 0) || (Hatches_closed_out4 == 0 && Hatch_sel4 == 0)))
                return true;
            else if (Hatch_sel6 == 1 && ((Hatches_closed_out1 == 0 && Hatch_sel1 == 0) || (Hatches_closed_out2 == 0 && Hatch_sel2 == 0) ||
                (Hatches_closed_out3 == 0 && Hatch_sel3 == 0) || (Hatches_closed_out4 == 0 && Hatch_sel4 == 0)))
                return true;
            else if (Hatch_sel7 == 1 && ((Hatches_closed_out5 == 0 && Hatch_sel5 == 0) || (Hatches_closed_out2 == 0 && Hatch_sel2 == 0) ||
                (Hatches_closed_out3 == 0 && Hatch_sel3 == 0) || (Hatches_closed_out4 == 0 && Hatch_sel4 == 0)))
                return true;
            else if (Hatch_sel8 == 1 && ((Hatches_closed_out5 == 0 && Hatch_sel5 == 0) || (Hatches_closed_out2 == 0 && Hatch_sel2 == 0) ||
                (Hatches_closed_out3 == 0 && Hatch_sel3 == 0) || (Hatches_closed_out4 == 0 && Hatch_sel4 == 0)))
                return true;
            else
                return false;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string addDontCare(int size)
        {//This function is creating a string of (size) zeros
            string zerosString = "";
            for (int i = 0; i < size; i++)
            {
                zerosString += '0';
            }
            return zerosString;
        }

        public static string shirshurSensorsString(string sensors, int index)
        {//This function is creating the input string for the sensors according to hatch's index
            string shirshurString = "";
            shirshurString += addDontCare(4 * index) + sensors + addDontCare(9 - index - 1);
            return shirshurString;
        }


         public static void Main(string[] args)
        {
            //var ComClient = new ComClient();
            //ComClient.ComInit();
            UInt32 m_uiTestId = 1;
            var m_lstMsgListStringFirst = new List<MsgStringFirst>();
            NetworkStream GalilStream;
            GalilTCPClient.connect();
            TcpClient client = new TcpClient();
            client.Connect("192.168.0.61", 51328);
            NetworkStream stream = client.GetStream();
            GalilStream = stream;
            GalilTCPClient.ResetGalil(GalilStream);
            string m_ubInBytes;
            string m_ubOutBytes;

            //First Step:
            string m_ubInputString = "";
            string m_ubInputStringTemp;
            string m_sMslSelExt1to4;
            string m_sMslSelExt5to8;
            string m_sMslSelInt1to4;
            string m_sMslSelInt5to8;
            string m_sHatchSelOut;
            bool flag = true;
            int countPass = 0, countFail = 0;
            int m_iselectedHatch;

            string temp = "00000000000000000000000000000000000000000000000000000000";
            GalilTCPClient.WriteFromStringRtoL(GalilStream, temp); //set GPIO
            m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33); //get GPIO
            Console.WriteLine(m_ubOutBytes);
            temp = "10100000000000000000000000000000000000000000000000000000";
            m_ubOutBytes = "";

            GalilTCPClient.WriteFromStringLtoR(GalilStream, temp); //set GPIO
            Thread.Sleep(1000);
            Console.WriteLine();
            m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33); //get GPIO
            Console.WriteLine(m_ubOutBytes);
            

            for (UInt32 m_iIdx01 = 0; m_iIdx01 < 65536; m_iIdx01++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx01, 2).PadLeft(16, '0');
                m_ubInputString += addDontCare(4) + m_ubInputStringTemp + addDontCare(36);
                GalilTCPClient.WriteFromStringRtoL(GalilStream, m_ubInputString); //set GPIO
                m_ubInBytes = m_ubInputString;
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33); //get GPIO
                m_sMslSelExt1to4 = Reverse(m_ubInputStringTemp.Substring(4, 4));
                m_sMslSelExt5to8 = Reverse(m_ubInputStringTemp.Substring(0, 4));
                m_sMslSelInt1to4 = Reverse(m_ubInputStringTemp.Substring(12, 4));
                m_sMslSelInt5to8 = Reverse(m_ubInputStringTemp.Substring(8, 4));
                m_sHatchSelOut = Reverse(m_ubOutBytes.Substring(0, 8));
                if ((m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel1] == 1 && m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel2] == 1 && m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel3] == 1 && m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel4] == 1) ||
                    (m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel5] == 1 && m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel6] == 1 && m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel7] == 1 && m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel8] == 1))
                { //LCU_sel = 1 -> MUX B
                    m_iselectedHatch = HatchSelected_1stNible(m_ubInBytes[(int)InputBytesRtoL.e_IntMSL_sel1], m_ubInBytes[(int)InputBytesRtoL.e_IntMSL_sel2],
                        m_ubInBytes[(int)InputBytesRtoL.e_IntMSL_sel3], m_ubInBytes[(int)InputBytesRtoL.e_IntMSL_sel4]);
                    if (m_iselectedHatch > 0)
                    {//some hatch has been selected
                        if (m_ubOutBytes[(int)(OutputBytes)(7 + m_iselectedHatch)] == 0)
                        {//TODO "Failed" in the excel file
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'F');
                        }

                        else
                        {//"Pass" in the excel file
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'P');
                        }
                    }
                    else
                    {//No hatch has been selected
                     //go over all the outputs hatch_sel_out(1->8) and make sure the value is 0
                        for (byte m_iIdx02 = 8; m_iIdx02 < 16; m_iIdx02++)
                        {
                            if (m_ubOutBytes[(int)(OutputBytes)(m_iIdx02)] == 1)
                            {
                                flag = false;
                            }
                        }
                        if (flag)
                        {//"Pass" in Excel file
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'P');
                        }
                        else
                        {//"Failed" in excel file
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'F');
                        }
                    }
                    if (HatchSelected_2ndNible(m_ubInBytes[(int)InputBytesRtoL.e_IntMSL_sel5], m_ubInBytes[(int)InputBytesRtoL.e_IntMSL_sel6],
                                               m_ubInBytes[(int)InputBytesRtoL.e_IntMSL_sel7], m_ubInBytes[(int)InputBytesRtoL.e_IntMSL_sel8]) > 0)
                    {//some hatch has been selected 
                        if (m_ubOutBytes[(int)(OutputBytes)(7 + HatchSelected_2ndNible(m_ubOutBytes[(int)InputBytesRtoL.e_IntMSL_sel5], m_ubOutBytes[(int)InputBytesRtoL.e_IntMSL_sel6],
                            m_ubOutBytes[(int)InputBytesRtoL.e_IntMSL_sel7], m_ubOutBytes[(int)InputBytesRtoL.e_IntMSL_sel8]))] == 0)
                        {//"Failed" in the excel file
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'F');
                        }
                        else
                        {//"Pass" in the excel file
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'P');
                        }
                    }
                    else
                    {//No hatch has been selected
                     //go over all the outputs hatch_sel_out(1->8) and make sure the value is 0
                        for (byte m_iIdx02 = 8; m_iIdx02 < 16; m_iIdx02++)
                        {
                            if (m_ubOutBytes[(int)(OutputBytes)(m_iIdx02)] == 1)
                            {
                                flag = false;
                            }
                        }
                        if (flag)
                        {//"Pass" in Excel file
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'P');
                        }
                        else
                        {//"Failed" in excel file
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'F');
                        }
                    }

                }
                else
                { //LCU_sel = 0 -> MUX A
                    m_iselectedHatch = HatchSelected_1stNible(m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel1] - '0', m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel2] - '0',
                        m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel3] - '0', m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel4] - '0');
                    if (m_iselectedHatch > 0)
                    {//some hatch has been selected
                        if (m_ubOutBytes[(int)(OutputBytes)(7 + m_iselectedHatch)] == 0)
                        {//"Failed" in the excel file
                            countFail++;
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'F');
                        }
                        else
                        {//"Pass" in the excel file
                            countPass++;
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'P');
                        }
                    }
                    else
                    {//No hatch has been selected
                     //go over all the outputs hatch_sel_out(1->8) and make sure the value is 0
                        for (byte m_iIdx02 = 8; m_iIdx02 < 16; m_iIdx02++)
                        {
                            if (m_ubOutBytes[(int)(OutputBytes)(m_iIdx02)] == 1)
                            {
                                flag = false;
                            }
                        }
                        if (flag)
                        {//"Pass" in Excel file
                            countPass++;
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'P');
                        }
                        else
                        {//"Failed" in excel file
                            countFail++;
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'F');
                        }
                    }
                    if (HatchSelected_2ndNible(m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel5], m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel6],
                        m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel7], m_ubInBytes[(int)InputBytesRtoL.e_ExtMSL_sel8]) > 0)
                    {//some hatch has been selected 
                        if (m_ubOutBytes[(int)(OutputBytes)(7 + HatchSelected_2ndNible(m_ubOutBytes[(int)InputBytesRtoL.e_ExtMSL_sel5], m_ubOutBytes[(int)InputBytesRtoL.e_ExtMSL_sel6],
                            m_ubOutBytes[(int)InputBytesRtoL.e_ExtMSL_sel7], m_ubOutBytes[(int)InputBytesRtoL.e_ExtMSL_sel8]))] == 0)
                        {//"Failed" in the excel file
                            countFail++;
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'F');
                        }
                        else
                        {//"Pass" in the excel file
                            countPass++;
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'P');
                        }
                    }
                    else
                    {//No hatch has been selected
                     //go over all the outputs hatch_sel_out(1->8) and make sure the value is 0
                        for (byte m_iIdx02 = 8; m_iIdx02 < 16; m_iIdx02++)
                        {
                            if (m_ubOutBytes[(int)(OutputBytes)(m_iIdx02)] == 1)
                            {
                                flag = false;
                            }
                        }
                        if (flag)
                        {//"Pass" in Excel file
                            countPass++;
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'P');
                        }
                        else
                        {//"Failed" in excel file
                            countFail++;
                            ExportToExcel.AddMsgToListStringFirst(m_lstMsgListStringFirst, m_uiTestId, m_sMslSelExt1to4, m_sMslSelExt5to8, m_sMslSelInt1to4, m_sMslSelInt5to8, m_sHatchSelOut, 'F');
                        }
                    }

                }
                m_uiTestId++;
                m_ubInputString = "";
            }
            ExcelMapper mapper = new ExcelMapper();
            var m_FirstFile = @"D:\First_Stage.xlsx";
            mapper.Save(m_FirstFile, m_lstMsgListStringFirst, "Messages_Excel1", true);
            Console.ReadKey();
            //Second Step

            m_ubInputString = "";
            for (byte m_iIdx05 = 0; m_iIdx05 < 9; m_iIdx05++)
            { //This for loop is for 8 hatches + 1 uptake
                for (byte m_iIdx06 = 0; m_iIdx06 < 16; m_iIdx06++)
                {
                    m_ubInputStringTemp = Convert.ToString(m_iIdx06, 2).PadLeft(4, '0');
                    m_ubInputString += addDontCare(20) + shirshurSensorsString(m_ubInputStringTemp, m_iIdx05);
                    GalilTCPClient.WriteFromStringRtoL(GalilStream, m_ubInputString);
                    m_ubInBytes = m_ubInputString;
                    m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);
                    //setGPIO(); //This function will set the sensors of hatch number (m_iIdx05+1) as an input for the CPLD
                    //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                    if (IsHatchOpen(m_ubInBytes[m_iIdx05 * 4], m_ubInBytes[m_iIdx05 * 4 + 1], m_ubInBytes[m_iIdx05 * 4 + 2], m_ubInBytes[m_iIdx05 * 4 + 3]))
                    {//hatch number (m_iIdx05+1) is open
                        if (m_ubOutBytes[(int)(OutputBytes.e_HatchOpen1) + m_iIdx05] == 1)
                        {//"Pass" in the excel file
                         //FILL IT UP!!
                        }
                        else
                        {//"Failed" in the excel file
                         //FILL IT UP!!
                        }
                    }

                    if (m_iIdx05 != 8)
                    {
                        if (IsHatchClosed(m_ubInBytes[m_iIdx05 * 4], m_ubInBytes[m_iIdx05 * 4 + 1], m_ubInBytes[m_iIdx05 * 4 + 2], m_ubInBytes[m_iIdx05 * 4 + 3]))
                        {//hatch number (m_iIdx05+1) is closed
                            if (m_ubOutBytes[(int)(OutputBytes.e_HatchClosed1) + m_iIdx05] == 1)
                            {//"Pass" in the excel file
                             //FILL IT UP!!
                            }
                            else
                            {//"Failed" in the excel file
                             //FILL IT UP!!
                            }
                        }
                    }
                }
                m_uiTestId++;
            }

            //FINISH HERE


            //third step
            /*new!
             * string m_smslSelectString = "0001"; //hatch 1 selected
             * string m_sHatch1SensorsString = "0101";
             * setGPIO();
             * getGPIO();
             * if (m_ubOutBytes[OutputBytes.m_eGA1] == 0 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 1)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
             * m_sHatch1SensorsString = "1100";  
             * if (m_ubOutBytes[OutputBytes.m_eGA1] == 1 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 0)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
             * string m_smslSelectString = "0010"; //hatch 2 selected
             * string m_sHatch2SensorsString = "0101";
             * setGPIO();
             * getGPIO();
             * if (m_ubOutBytes[OutputBytes.m_eGA1] == 0 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 1)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
             * m_sHatch2SensorsString = "1100";  
             * if (m_ubOutBytes[OutputBytes.m_eGA1] == 1 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 0)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
             * string m_smslSelectString = "0100"; //hatch 3 selected
             * string m_sHatch3SensorsString = "0101";
             * setGPIO();
             * getGPIO();
             * if (m_ubOutBytes[OutputBytes.m_eGA1] == 0 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 1)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
             * m_sHatch3SensorsString = "1100";  
             * if (m_ubOutBytes[OutputBytes.m_eGA1] == 1 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 0)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
             * string m_smslSelectString = "1000"; //hatch 4 selected
             * string m_sHatch4SensorsString = "0101";
             * setGPIO();
             * getGPIO();
             * if (m_ubOutBytes[OutputBytes.m_eGA1] == 0 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 1)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
             * m_sHatch4SensorsString = "1100";  
             * if (m_ubOutBytes[OutputBytes.m_eGA1] == 1 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 0)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }

            m_sUptakeSensorsString = "0101";
            setGPIO();
            getGPIO();
            if (m_ubOutBytes[OutputBytes.m_eGA1] == 0 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 1)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }


            string m_smslSelectString = "0000"; //none hatch has been selected
            setGPIO();
            getGPIO();
            if (m_ubOutBytes[OutputBytes.m_eGA1] == 0 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 1)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }

            byte m_ubFunCPLD_GA1 = 1;
            setGPIO();
            getGPIO();
            if (m_ubOutBytes[OutputBytes.m_eGA1] == 0 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 1)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }

             *end new/
            /* Global Abort 1 tests: */
            m_ubInputString = "";
            m_ubInputString += "0001" + addDontCare(52); //checking GA1 from functional CPLD
            GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);
            m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);
            //setGPIO();        just 1 input is relevant
            //getGPIO();
            if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
            {//"Failed" in the excel file
             //Fill it up!
            }
            else
            {//"Pass" in the excel file
             //Fill it up!
            }
            m_uiTestId++;
            m_ubInputString = "";
            m_ubInputString += "0000" + addDontCare(52); //checking GA1 = 0 from functional CPLD
            GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);
            m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);
            if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
            {//"Failed" in the excel file
             //Fill it up!
            }
            else
            {//"Pass" in the excel file
             //Fill it up!
            }
            m_uiTestId++;
            m_ubInputString = "";
            m_ubInputString += "0010" + addDontCare(52); //checking GA2 from functional CPLD
            GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
            m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
            if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
            {//"Failed" in the excel file
             //Fill it up!
            }
            else
            {//"Pass" in the excel file
             //Fill it up!
            }
            m_uiTestId++;
            m_ubInputString = "";
            m_ubInputString += "0000" + addDontCare(52); //checking GA2 = 0 from functional CPLD
            GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);   //setGPIO
            m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);        //getGPIO
            //setGPIO();        just 1 input is relevant
            //getGPIO();
            if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
            {//"Failed" in the excel file
             //Fill it up!
            }
            else
            {//"Pass" in the excel file
             //Fill it up!
            }
            m_uiTestId++;
            string m_sOpenSensors = "1100";
            string m_sNotOpenSensors = "0101";
            string m_sUptakeSensorsOpen = "1100";
            string m_sUptakeSensorsNotOpen = "0101";
            string m_smslSelectFirstQuartetString = "0001"; //hatch 1 selected
            string m_smslSelectSecondQuartetString = "0001"; //hatch 5 selected
            string m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += addDontCare(12) + m_smslSelectSecondQuartetString + m_smslSelectFirstQuartetString + m_sUptakeSensorsOpen + addDontCare(16) + m_sSensorsString;
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0001"; //hatch 1 selected
            m_smslSelectSecondQuartetString = "0010"; //hatch 6 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0001"; //hatch 1 selected
            m_smslSelectSecondQuartetString = "0100"; //hatch 7 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0001"; //hatch 1 selected
            m_smslSelectSecondQuartetString = "1000"; //hatch 8 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0010"; //hatch 2 selected
            m_smslSelectSecondQuartetString = "0001"; //hatch 5 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0010"; //hatch 2 selected
            m_smslSelectSecondQuartetString = "0010"; //hatch 6 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0010"; //hatch 2 selected
            m_smslSelectSecondQuartetString = "0100"; //hatch 7 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0010"; //hatch 2 selected
            m_smslSelectSecondQuartetString = "1000"; //hatch 8 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0100"; //hatch 3 selected
            m_smslSelectSecondQuartetString = "0001"; //hatch 5 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0100"; //hatch 3 selected
            m_smslSelectSecondQuartetString = "0010"; //hatch 6 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0100"; //hatch 3 selected
            m_smslSelectSecondQuartetString = "0100"; //hatch 7 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0100"; //hatch 3 selected
            m_smslSelectSecondQuartetString = "1000"; //hatch 8 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "1000"; //hatch 4 selected
            m_smslSelectSecondQuartetString = "0001"; //hatch 5 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "1000"; //hatch 4 selected
            m_smslSelectSecondQuartetString = "0010"; //hatch 6 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "1000"; //hatch 4 selected
            m_smslSelectSecondQuartetString = "0100"; //hatch 7 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "1000"; //hatch 4 selected
            m_smslSelectSecondQuartetString = "1000"; //hatch 8 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0000"; //None hatch selected from first quartet
            m_smslSelectSecondQuartetString = "0001"; //hatch 5 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0000"; //None hatch selected from first quartet
            m_smslSelectSecondQuartetString = "0010"; //hatch 6 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0000"; //None hatch selected from first quartet
            m_smslSelectSecondQuartetString = "0100"; //hatch 7 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0000"; //None hatch selected from first quartet
            m_smslSelectSecondQuartetString = "1000"; //hatch 8 selected
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0001"; //Hatch 1 selected
            m_smslSelectSecondQuartetString = "0000"; //None hatch selected from second quartet
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0010"; //Hatch 2 selected
            m_smslSelectSecondQuartetString = "0000"; //None hatch selected from second quartet
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0100"; //Hatch 3 selected
            m_smslSelectSecondQuartetString = "0000"; //None hatch selected from second quartet
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }


            m_smslSelectFirstQuartetString = "1000"; //Hatch 4 selected
            m_smslSelectSecondQuartetString = "0000"; //None hatch selected from second quartet
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0000"; //None hatch selected from first quartet
            m_smslSelectSecondQuartetString = "0000"; //None hatch selected from second quartet
            m_sSensorsString = "";
            m_ubInputString = "";
            for (int m_iIdx02 = 0; m_iIdx02 < 16; m_iIdx02++)
            {//This for loop creates a string which presents the inputs of first quartet's sensors(optional combinations are open/close)
                m_ubInputStringTemp = Convert.ToString(m_iIdx02, 2).PadLeft(4, '0');
                for (byte m_iIdx03 = 0; m_iIdx03 < 4; m_iIdx03++)
                {
                    if (m_ubInputStringTemp[m_iIdx03] == '0') //not open sensors
                    {
                        m_sSensorsString += m_sNotOpenSensors;
                    }
                    else //open sensors
                    {
                        m_sSensorsString += m_sOpenSensors;
                    }
                }
                /* Global Abort 1 tests , Uptake OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 1 tests ,Uptake NOT OPEN: */
                m_ubInputString += m_sSensorsString + addDontCare(16) + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchOpen1], m_ubOutBytes[(int)OutputBytes.e_HatchOpen2],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen3], m_ubOutBytes[(int)OutputBytes.e_HatchOpen4], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                /* Global Abort 2 tests ,Uptake NOT OPEN: */
                m_ubInputString += addDontCare(16) + m_sSensorsString + m_sUptakeSensorsNotOpen + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                if (IsGlobalAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6], m_ubOutBytes[(int)OutputBytes.e_HatchSel7],
                    m_ubOutBytes[(int)OutputBytes.e_HatchSel8], m_ubOutBytes[(int)OutputBytes.e_HatchOpen5], m_ubOutBytes[(int)OutputBytes.e_HatchOpen6],
                    m_ubOutBytes[(int)OutputBytes.e_HatchOpen7], m_ubOutBytes[(int)OutputBytes.e_HatchOpen8], m_ubOutBytes[(int)OutputBytes.e_UpdakeOpen]))
                {//Global abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//Global abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_GA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_GA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_uiTestId++;
            }

            //Fourth step
            m_ubInputString = "";
            m_ubInputString += addDontCare(52) + "0010"; //checking CA1 from functional CPLD
            GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
            m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
            //setGPIO();        just 1 input is relevant
            //getGPIO();
            if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
            {//"Failed" in the excel file
             //Fill it up!
            }
            else
            {//"Pass" in the excel file
             //Fill it up!
            }
            m_uiTestId++;
            m_ubInputString = "";
            m_ubInputString += addDontCare(52) + "0000"; //checking CA1 from functional CPLD
            GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
            m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
            if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
            {//"Failed" in the excel file
             //Fill it up!
            }
            else
            {//"Pass" in the excel file
             //Fill it up!
            }
            m_uiTestId++;
            m_ubInputString = "";
            m_ubInputString += addDontCare(52) + "0001"; //checking CA2 from functional CPLD
            GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
            m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
            if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
            {//"Failed" in the excel file
             //Fill it up!
            }
            else
            {//"Pass" in the excel file
             //Fill it up!
            }
            m_uiTestId++;
            m_ubInputString = "";
            m_smslSelectFirstQuartetString = "0001"; //hatch 1 selected
            m_smslSelectSecondQuartetString = "0001"; //hatch 5 selected
            string m_sCloseSensors = "0011";
            string m_sNotCloseSensors = "0101";
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }
            m_smslSelectFirstQuartetString = "0010"; //hatch 2 selected
            m_smslSelectSecondQuartetString = "0001"; //hatch 5 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }
            m_smslSelectFirstQuartetString = "0100"; //hatch 3 selected
            m_smslSelectSecondQuartetString = "0001"; //hatch 5 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }
            m_smslSelectFirstQuartetString = "1000"; //hatch 4 selected
            m_smslSelectSecondQuartetString = "0001"; //hatch 5 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0000"; //none hatch selected from first quartet
            m_smslSelectSecondQuartetString = "0001"; //hatch 5 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0001"; //hatch 1 selected
            m_smslSelectSecondQuartetString = "0010"; //hatch 6 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }
            m_smslSelectFirstQuartetString = "0010"; //hatch 2 selected
            m_smslSelectSecondQuartetString = "0010"; //hatch 6 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }
            m_smslSelectFirstQuartetString = "0100"; //hatch 3 selected
            m_smslSelectSecondQuartetString = "0010"; //hatch 6 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }
            m_smslSelectFirstQuartetString = "1000"; //hatch 4 selected
            m_smslSelectSecondQuartetString = "0010"; //hatch 6 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0000"; //none hatch selected from first quartet
            m_smslSelectSecondQuartetString = "0010"; //hatch 6 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0001"; //hatch 1 selected
            m_smslSelectSecondQuartetString = "0100"; //hatch 7 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }
            m_smslSelectFirstQuartetString = "0010"; //hatch 2 selected
            m_smslSelectSecondQuartetString = "0100"; //hatch 7 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }
            m_smslSelectFirstQuartetString = "0100"; //hatch 3 selected
            m_smslSelectSecondQuartetString = "0100"; //hatch 7 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }
            m_smslSelectFirstQuartetString = "1000"; //hatch 4 selected
            m_smslSelectSecondQuartetString = "0100"; //hatch 7 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0000"; //none hatch selected from first quartet
            m_smslSelectSecondQuartetString = "0100"; //hatch 7 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0001"; //hatch 1 selected
            m_smslSelectSecondQuartetString = "1000"; //hatch 8 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }
            m_smslSelectFirstQuartetString = "0010"; //hatch 2 selected
            m_smslSelectSecondQuartetString = "1000"; //hatch 8 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }
            m_smslSelectFirstQuartetString = "0100"; //hatch 3 selected
            m_smslSelectSecondQuartetString = "1000"; //hatch 8 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }
            m_smslSelectFirstQuartetString = "1000"; //hatch 4 selected
            m_smslSelectSecondQuartetString = "1000"; //hatch 8 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0000"; //none hatch selected from first quartet
            m_smslSelectSecondQuartetString = "1000"; //hatch 8 selected
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0001"; //hatch 1 selected
            m_smslSelectSecondQuartetString = "0000"; //none hatch selected from second quartet
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0010"; //hatch 2 selected
            m_smslSelectSecondQuartetString = "0000"; //none hatch selected from second quartet
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "0100"; //hatch 3 selected
            m_smslSelectSecondQuartetString = "0000"; //none hatch selected from second quartet
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }

            m_smslSelectFirstQuartetString = "1000"; //hatch 4 selected
            m_smslSelectSecondQuartetString = "0000"; //none hatch selected from second quartet
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }
            m_smslSelectFirstQuartetString = "0000"; //none hatch selected from first quartet
            m_smslSelectSecondQuartetString = "0000"; //none hatch selected from second quartet
            for (int m_iIdx08 = 0; m_iIdx08 < 256; m_iIdx08++)
            {
                m_ubInputStringTemp = Convert.ToString(m_iIdx08, 2).PadLeft(8, '0');
                for (byte m_iIdx09 = 0; m_iIdx09 < 8; m_iIdx09++)
                {
                    if (m_ubInputStringTemp[m_iIdx09] == '0') //not close sensors
                    {
                        m_ubInputString += m_sNotCloseSensors;
                    }
                    else //close sensors
                    {
                        m_ubInputString += m_sCloseSensors;
                    }

                }
                m_ubInputString += addDontCare(4) + m_smslSelectFirstQuartetString + m_smslSelectSecondQuartetString + addDontCare(12);
                //setGPIO(); //This function will set the inputs:msl_sel1-4, msl_sel5-8, 4 sensors of first quartet who didn't chose * 3, 4 sensors of second quartet * 4
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                GalilTCPClient.WriteFromStringLtoR(GalilStream, m_ubInputString);       //setGPIO
                m_ubOutBytes = GalilTCPClient.ReadOutputsFromGalil(GalilStream, 33);    //getGPIO
                /*Consider abort 1 check:*/
                if (IsConsiderAbort1(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort1 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort1 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA1] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA1Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                /*Consider abort 2 check:*/
                if (IsConsiderAbort2(m_ubOutBytes[(int)OutputBytes.e_HatchSel1], m_ubOutBytes[(int)OutputBytes.e_HatchSel2], m_ubOutBytes[(int)OutputBytes.e_HatchSel3], m_ubOutBytes[(int)OutputBytes.e_HatchSel4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed1],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed2], m_ubOutBytes[(int)OutputBytes.e_HatchClosed3], m_ubOutBytes[(int)OutputBytes.e_HatchClosed4], m_ubOutBytes[(int)OutputBytes.e_HatchClosed5],
                        m_ubOutBytes[(int)OutputBytes.e_HatchClosed6], m_ubOutBytes[(int)OutputBytes.e_HatchClosed7], m_ubOutBytes[(int)OutputBytes.e_HatchClosed8], m_ubOutBytes[(int)OutputBytes.e_HatchSel5], m_ubOutBytes[(int)OutputBytes.e_HatchSel6],
                        m_ubOutBytes[(int)OutputBytes.e_HatchSel7], m_ubOutBytes[(int)OutputBytes.e_HatchSel8]))
                {//consider abort2 = true
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 0 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 1)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                else
                {//consider abort2 = false
                    if (m_ubOutBytes[(int)OutputBytes.e_CA2] == 1 || m_ubOutBytes[(int)OutputBytes.e_CA2Not] == 0)
                    {//"Failed" in the excel file
                     //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                     //Fill it up!
                    }
                }
                m_ubInputString = "";
                m_uiTestId++;
            }
        }//Main
    }//class Hatch
}//namespace






