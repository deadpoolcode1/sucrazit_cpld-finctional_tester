using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sucrazit
{
    public class Hatch
    {

        enum InputBytes
        {
            m_eHatch_1_UP_A = 0,
            m_eHatch_1_UP_B = 1,
            m_eHatch_1_Down_A = 2,
            m_eHatch_1_Down_B = 3,
            m_eHatch_2_UP_A = 4,
            m_eHatch_2_UP_B = 5,
            m_eHatch_2_Down_A = 6,
            m_eHatch_2_Down_B = 7,
            m_eHatch_3_UP_A = 8,
            m_eHatch_3_UP_B = 9,
            m_eHatch_3_Down_A = 10,
            m_eHatch_3_Down_B = 11,
            m_eHatch_4_UP_A = 12,
            m_eHatch_4_UP_B = 13,
            m_eHatch_4_Down_A = 14,
            m_eHatch_4_Down_B = 15,
            m_eHatch_5_UP_A = 16,
            m_eHatch_5_UP_B = 17,
            m_eHatch_5_Down_A = 18,
            m_eHatch_5_Down_B = 19,
            m_eHatch_6_UP_A = 20,
            m_eHatch_6_UP_B = 21,
            m_eHatch_6_Down_A = 22,
            m_eHatch_6_Down_B = 23,
            m_eHatch_7_UP_A = 24,
            m_eHatch_7_UP_B = 25,
            m_eHatch_7_Down_A = 26,
            m_eHatch_7_Down_B = 27,
            m_eHatch_8_UP_A = 28,
            m_eHatch_8_UP_B = 29,
            m_eHatch_8_Down_A = 30,
            m_eHatch_8_Down_B = 31,
            m_eUptake_UP_A = 32,
            m_eUptake_UP_B = 33,
            m_eUptake_Down_A = 34,
            m_eUptake_Down_B = 35,
            m_eIntMSL_sel1 = 36,
            m_eIntMSL_sel2 = 37,
            m_eIntMSL_sel3 = 38,
            m_eIntMSL_sel4 = 39;
            m_eIntMSL_sel5 = 40,
            m_eIntMSL_sel6 = 41,
            m_eIntMSL_sel7 = 42,
            m_eIntMSL_sel8 = 43,
            m_eExtMSL_sel1 = 44,
            m_eExtMSL_sel2 = 45,
            m_eExtMSL_sel3 = 46,
            m_eExtMSL_sel4 = 47,
            m_eExtMSL_sel5 = 48,
            m_eExtMSL_sel6 = 49,
            m_eExtMSL_sel7 = 50,
            m_eExtMSL_sel8 = 51,
            m_eFunCPLD_GA1 = 52,
            m_eFunCPLD_GA2 = 53,
            m_eFunCPLD_CA1 = 54,
            m_eFunCPLD_CA2 = 55,
            m_eSideSel = 56
        }

        enum OutputBytes
        {
            m_eGA1 = 0,
            m_eGA1Not = 1,
            m_eCA1 = 2,
            m_eCA1Not = 3,
            m_eGA2 = 4,
            m_eGA2Not = 5,
            m_eCA2 = 6,
            m_eCA2Not = 7,
            m_eHatchSel1 = 8,
            m_eHatchSel2 = 9,
            m_eHatchSel3 = 10,
            m_eHatchSel4 = 11,
            m_eHatchSel5 = 12,
            m_eHatchSel6 = 13,
            m_eHatchSel7 = 14,
            m_eHatchSel8 = 15,
            m_eHatchOpen1 = 16,
            m_eHatchOpen2 = 17,
            m_eHatchOpen3 = 18,
            m_eHatchOpen4 = 19,
            m_eHatchOpen5 = 20,
            m_eHatchOpen6 = 21,
            m_eHatchOpen7 = 22,
            m_eHatchOpen8 = 23,
            m_eUpdakeOpen = 24,
            m_eHatchClosed1 = 25,
            m_eHatchClosed2 = 26,
            m_eHatchClosed3 = 27,
            m_eHatchClosed4 = 28,
            m_eHatchClosed5 = 29,
            m_eHatchClosed6 = 30,
            m_eHatchClosed7 = 31,
            m_eHatchClosed8 = 32
        }


        /* At this point I have considered that I know the value of LCU_sel, so I know whether to check
         * A or B (External or Internal). The logic is the same. */
        public byte HatchSelected_1stNible(byte MSL_sel1, byte MSL_sel2, byte MSL_sel3, byte MSL_sel4)
        {//This function returns which hatch has to be selected from the first nible(1-4)
            if (MSL_sel1 == 1 && MSL_sel2 == 0 && MSL_sel3 == 0 && MSL_sel4 == 0)
                return 1;
            else if (MSL_sel1 == 0 && MSL_sel2 == 1 && MSL_sel3 == 0 && MSL_sel4 == 0)
                return 2;
            else if (MSL_sel1 == 0 && MSL_sel2 == 0 && MSL_sel3 == 1 && MSL_sel4 == 0)
                return 3;
            else if (MSL_sel1 == 0 && MSL_sel2 == 0 && MSL_sel3 == 0 && MSL_sel4 == 1)
                return 4;
            else
                return 0; //None hatch has been selected
        }

        public byte HatchSelected_2ndNible(byte MSL_sel5, byte MSL_sel6, byte MSL_sel7, byte MSL_sel8)
        {//This function returns which hatch has to be selected from the second nible(5-8)
            if (MSL_sel5 == 1 && MSL_sel6 == 0 && MSL_sel7 == 0 && MSL_sel8 == 0)
                return 5;
            else if (MSL_sel5 == 0 && MSL_sel6 == 1 && MSL_sel7 == 0 && MSL_sel8 == 0)
                return 6;
            else if (MSL_sel5 == 0 && MSL_sel6 == 0 && MSL_sel7 == 1 && MSL_sel8 == 0)
                return 7;
            else if (MSL_sel5 == 0 && MSL_sel6 == 0 && MSL_sel7 == 0 && MSL_sel8 == 1)
                return 8;
            else
                return 0; //None hatch has been selected
        }




        public bool IsHatchOpen(byte Hatch_N_UP_A, byte Hatch_N_UP_B, byte Hatch_N_Down_A, byte Hatch_N_Down_B)
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

        public bool IsHatchClosed(byte Hatch_N_UP_A, byte Hatch_N_UP_B, byte Hatch_N_Down_A, byte Hatch_N_Down_B)
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

        public bool IsUptakeOpen(byte Uptake_UP_A, byte Uptake_UP_B, byte Uptake_Down_A, byte Uptake_Down_B)
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



        /*public bool IsGlobalAbort1(byte Hatch_sel1, byte Hatch_sel2, byte Hatch_sel3, byte Hatch_sel4, byte Hatches_opened_out1,
           byte Hatches_opened_out2, byte Hatches_opened_out3, byte Hatches_opened_out4, byte uptake_opened_out,
           byte Global_Abort1_from_funCPLD)
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
            else if (Global_Abort1_from_funCPLD == 1)
                return true;
            else
                return false;
        }
        */

        public bool IsGlobalAbort1(byte IntMSL_sel1, byte IntMSL_sel2,byte IntMSL_sel3, byte IntMSL_sel4, byte Hatch_1_UP_A, byte Hatch_1_UP_B,byte Hatch_1_DN_A,byte Hatch_1_DN_B,
                                   byte Hatch_2_UP_A, byte Hatch_2_UP_B, byte Hatch_2_DN_A, byte Hatch_2_DN_B, byte Hatch_3_UP_A, byte Hatch_3_UP_B, byte Hatch_3_DN_A, byte Hatch_3_DN_B,
                                   byte Hatch_4_UP_A, byte Hatch_4_UP_B, byte Hatch_4_DN_A, byte Hatch_4_DN_B,byte Uptake_UP_A,byte Uptake_UP_B, byte Uptake_DN_A, byte Uptake_DN_B, byte Global_Abort1_from_funCPLD)
        {
            if(HatchSelected_1stNible(IntMSL_sel1,IntMSL_sel2,IntMSL_sel3,IntMSL_sel4)==1 && !(IsHatchOpen(Hatch_1_UP_A,Hatch_1_UP_B,Hatch_1_DN_A,Hatch_1_DN_B)))
            {//hatch 1 selected and he is not open
                return true;
            }
            else if(HatchSelected_1stNible(IntMSL_sel1, IntMSL_sel2, IntMSL_sel3, IntMSL_sel4) == 2 && !(IsHatchOpen(Hatch_2_UP_A, Hatch_2_UP_B, Hatch_2_DN_A, Hatch_2_DN_B)))
            {//hatch 2 selected and he is not open
                return true;
            }
            else if(HatchSelected_1stNible(IntMSL_sel1, IntMSL_sel2, IntMSL_sel3, IntMSL_sel4) == 3 && !(IsHatchOpen(Hatch_3_UP_A, Hatch_3_UP_B, Hatch_3_DN_A, Hatch_3_DN_B)))
            {//hatch 3 selected and he is not open
                return true;
            }
            else if(HatchSelected_1stNible(IntMSL_sel1, IntMSL_sel2, IntMSL_sel3, IntMSL_sel4) == 4 && !(IsHatchOpen(Hatch_4_UP_A, Hatch_4_UP_B, Hatch_4_DN_A, Hatch_4_DN_B)))
            {//hatch 4 selected and he is not open
                return true;
            }
            else if(!(IsUptakeOpen(Uptake_UP_A,Uptake_UP_B,Uptake_DN_A,Uptake_DN_B)))
            {//uptake is close
                return true;
            }
            else if(HatchSelected_1stNible(IntMSL_sel1, IntMSL_sel2, IntMSL_sel3, IntMSL_sel4) == 0)
            {//none hatch has been selected
                return true;
            }
            else if(Global_Abort1_from_funCPLD==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*public bool IsGlobalAbort2(byte Hatch_sel5, byte Hatch_sel6, byte Hatch_sel7, byte Hatch_sel8, byte Hatches_opened_out5,
           byte Hatches_opened_out6, byte Hatches_opened_out7, byte Hatches_opened_out8, byte uptake_opened_out,
           byte Global_Abort1_from_funCPLD)
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
            else if (Global_Abort1_from_funCPLD == 1)
                return true;
            else
                return false;
        }
        */
        public bool IsGlobalAbort2(byte ExtMSL_sel1, byte ExtMSL_sel2, byte ExtMSL_sel3, byte ExtMSL_sel4, byte Hatch_5_UP_A, byte Hatch_5_UP_B, byte Hatch_5_DN_A, byte Hatch_5_DN_B,
                                   byte Hatch_6_UP_A, byte Hatch_6_UP_B, byte Hatch_6_DN_A, byte Hatch_6_DN_B, byte Hatch_7_UP_A, byte Hatch_7_UP_B, byte Hatch_7_DN_A, byte Hatch_7_DN_B,
                                   byte Hatch_8_UP_A, byte Hatch_8_UP_B, byte Hatch_8_DN_A, byte Hatch_8_DN_B, byte Uptake_UP_A, byte Uptake_UP_B, byte Uptake_DN_A, byte Uptake_DN_B, byte Global_Abort2_from_funCPLD)
        {
            if (HatchSelected_2ndNible(ExtMSL_sel1, ExtMSL_sel2, ExtMSL_sel3, ExtMSL_sel4) == 5 && !(IsHatchOpen(Hatch_5_UP_A, Hatch_5_UP_B, Hatch_5_DN_A, Hatch_5_DN_B)))
            {//hatch 1 selected and he is not open
                return true;
            }
            else if (HatchSelected_2ndNible(ExtMSL_sel1, ExtMSL_sel2, ExtMSL_sel3, ExtMSL_sel4) == 6 && !(IsHatchOpen(Hatch_6_UP_A, Hatch_6_UP_B, Hatch_6_DN_A, Hatch_6_DN_B)))
            {//hatch 2 selected and he is not open
                return true;
            }
            else if (HatchSelected_2ndNible(ExtMSL_sel1, ExtMSL_sel2, ExtMSL_sel3, ExtMSL_sel4) == 7 && !(IsHatchOpen(Hatch_7_UP_A, Hatch_7_UP_B, Hatch_7_DN_A, Hatch_7_DN_B)))
            {//hatch 3 selected and he is not open
                return true;
            }
            else if (HatchSelected_2ndNible(ExtMSL_sel1, ExtMSL_sel2, ExtMSL_sel3, ExtMSL_sel4) == 8 && !(IsHatchOpen(Hatch_8_UP_A, Hatch_8_UP_B, Hatch_8_DN_A, Hatch_8_DN_B)))
            {//hatch 4 selected and he is not open
                return true;
            }
            else if (!(IsUptakeOpen(Uptake_UP_A, Uptake_UP_B, Uptake_DN_A, Uptake_DN_B)))
            {//uptake is close
                return true;
            }
            else if (HatchSelected_2ndNible(ExtMSL_sel1, ExtMSL_sel2, ExtMSL_sel3, ExtMSL_sel4) == 0)
            {//none hatch has been selected
                return true;
            }
            else if (Global_Abort2_from_funCPLD == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




       /* public bool IsConsiderAbort1(byte Hatch_sel1, byte Hatch_sel2, byte Hatch_sel3, byte Hatch_sel4, byte Hatches_closed_out1,
            byte Hatches_closed_out2, byte Hatches_closed_out3, byte Hatches_closed_out4, byte Consider_Abort1_from_funCPLD,
            byte Hatches_closed_out5, byte Hatches_closed_out6, byte Hatches_closed_out7, byte Hatches_closed_out8,
            byte Hatch_sel5, byte Hatch_sel6, byte Hatch_sel7, byte Hatch_sel8)
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
            else if (Consider_Abort1_from_funCPLD == 1)
                return true;
            else
                return false;

        }
       */

        public bool IsConsiderAbort1(byte IntMSL_sel1, byte IntMSL_sel2, byte IntMSL_sel3, byte IntMSL_sel4, byte Hatch_1_UP_A, byte Hatch_1_UP_B, byte Hatch_1_DN_A, byte Hatch_1_DN_B,
                                   byte Hatch_2_UP_A, byte Hatch_2_UP_B, byte Hatch_2_DN_A, byte Hatch_2_DN_B, byte Hatch_3_UP_A, byte Hatch_3_UP_B, byte Hatch_3_DN_A, byte Hatch_3_DN_B,
                                   byte Hatch_4_UP_A, byte Hatch_4_UP_B, byte Hatch_4_DN_A, byte Hatch_4_DN_B, byte Consider_Abort1_from_funCPLD)
        {
            if(HatchSelected_1stNible())
        }

        public bool IsConsiderAbort2(byte Hatch_sel1, byte Hatch_sel2, byte Hatch_sel3, byte Hatch_sel4, byte Hatches_closed_out1,
            byte Hatches_closed_out2, byte Hatches_closed_out3, byte Hatches_closed_out4, byte Consider_Abort1_from_funCPLD,
            byte Hatches_closed_out5, byte Hatches_closed_out6, byte Hatches_closed_out7, byte Hatches_closed_out8,
            byte Hatch_sel5, byte Hatch_sel6, byte Hatch_sel7, byte Hatch_sel8)
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
            else if (Consider_Abort1_from_funCPLD == 1)
                return true;
            else
                return false;
        }


        static void Main(string[] args)
        {
            byte[] m_ubInBytes = new byte[57];
            byte[] m_ubOutBytes = new byte[33];

            //First Step:

            for (int m_iIdx01 = 0; m_iIdx01 < 131072; m_iIdx01++)
            {
                string m_ubInputString = Convert.ToString(m_iIdx01, 2).PadLeft(17, '0');
                var m_ubInputArray = m_ubInputString.Select(ch => ch - '0').ToArray();
                //setGPIO(m_ubInBytes); //TODO This function will set all the msl_sel+side_sel inputs to the CPLD
                //m_ubOutBytes = getGPIO(); //TODO This function returns an array of 33 bytes(the outputs from the CPLD)
                if (m_ubInBytes[InputBytes.m_eSideSel] == 0)
                {//Checking card number 1
                    if (m_ubInBytes[InputBytes.m_eExtMSL_sel1] == 1 && m_ubInBytes[InputBytes.m_eExtMSL_sel2] == 1 &&
                                     m_ubInBytes[InputBytes.m_eExtMSL_sel3] == 1 && m_ubInBytes[InputBytes.m_eExtMSL_sel4] == 1)
                    { //LCU_sel = 1 -> MUX B
                        if (HatchSelected_1stNible(m_ubInBytes[InputBytes.m_eIntMSL_sel1], m_ubInBytes[InputBytes.m_eIntMSL_sel2],
                            m_ubInBytes[InputBytes.m_eIntMSL_sel3], m_ubInBytes[InputBytes.m_eIntMSL_sel4]) != 0)
                        {//some hatch has been selected
                            if (m_ubOutBytes[(OutputBytes)(7 + HatchSelected_1stNible(m_ubOutBytes[InputBytes.m_eIntMSL_sel1], m_ubOutBytes[InputBytes.m_eIntMSL_sel2],
                                m_ubOutBytes[InputBytes.m_eIntMSL_sel3], m_ubOutBytes[InputBytes.m_eIntMSL_sel4]))] == 0)
                            {//TODO "Failed" in the excel file
                             //FILL IT UP!!
                            }

                            else
                            {//"Pass" in the excel file
                             //FILL IT UP!!
                            }
                        }
                        if (HatchSelected_2ndNible(m_ubInBytes[InputBytes.m_eIntMSL_sel5], m_ubInBytes[InputBytes.m_eIntMSL_sel6],
                            m_ubInBytes[InputBytes.m_eIntMSL_sel7], m_ubInBytes[InputBytes.m_eIntMSL_sel8]) != 0)
                        {//some hatch has been selected 
                            if (m_ubOutBytes[(OutputBytes)(7 + HatchSelected_2ndNible(m_ubOutBytes[InputBytes.m_eIntMSL_sel5], m_ubOutBytes[InputBytes.m_eIntMSL_sel6],
                                m_ubOutBytes[InputBytes.m_eIntMSL_sel7], m_ubOutBytes[InputBytes.m_eIntMSL_sel8]))] == 0)
                            {//"Failed" in the excel file
                             //FILL IT UP!!
                            }
                            else
                            {//"Pass" in the excel file
                             //FILL IT UP!!
                            }
                        }
                        else
                        {//No hatch has been selected
                         //Do I need to check something????
                        }

                    }
                    else
                    { //LCU_sel = 0 -> MUX A
                        if (HatchSelected_1stNible(m_ubOutBytes[InputBytes.m_eExtMSL_sel1], m_ubOutBytes[InputBytes.m_eExtMSL_sel2],
                            m_ubOutBytes[InputBytes.m_eExtMSL_sel3], m_ubOutBytes[InputBytes.m_eExtMSL_sel4]) != 0)
                        {//some hatch has been selected
                            if (m_ubOutBytes[(OutputBytes)(7 + HatchSelected_1stNible(m_ubOutBytes[InputBytes.m_eExtMSL_sel1], m_ubOutBytes[InputBytes.m_eExtMSL_sel2],
                                m_ubOutBytes[InputBytes.m_eExtMSL_sel3], m_ubOutBytes[InputBytes.m_eExtMSL_sel4]))] == 0)
                            {//"Failed" in the excel file
                             //FILL IT UP!!
                            }
                            else
                            {//"Pass" in the excel file
                             //FILL IT UP!!
                            }
                        }
                        if (HatchSelected_2ndNible(m_ubOutBytes[InputBytes.m_eExtMSL_sel5], m_ubOutBytes[InputBytes.m_eExtMSL_sel6],
                            m_ubOutBytes[InputBytes.m_eExtMSL_sel7], m_ubOutBytes[InputBytes.m_eExtMSL_sel8]) != 0)
                        {//some hatch has been selected 
                            if (m_ubOutBytes[(OutputBytes)(7 + HatchSelected_2ndNible(m_ubOutBytes[InputBytes.m_eExtMSL_sel5], m_ubOutBytes[InputBytes.m_eExtMSL_sel6],
                                m_ubOutBytes[InputBytes.m_eExtMSL_sel7], m_ubOutBytes[InputBytes.m_eExtMSL_sel8]))] == 0)
                            {//"Failed" in the excel file
                             //FILL IT UP!!
                            }
                            else
                            {//"Pass" in the excel file
                             //FILL IT UP!!
                            }
                        }
                        else
                        {//No hatch has been selected
                            //go over all the outputs hatch_sel_out(1->8) and make sure the value is 0
                            for(byte m_iIdx02 = 8; m_iIdx02 < 16; m_iIdx02++)
                            {
                                if(m_ubOutBytes[(OutputBytes)(m_iIdx02)]==1)
                                {//"Failed" in the excel file
                                    //FILL IT UP!!
                                }
                                else
                                {//"Pass" in the excel file
                                 //FILL IT UP!!
                                }
                            }
                        }

                    }

                }
                else
                {//Checking card number 2
                    if (m_ubInBytes[InputBytes.m_eExtMSL_sel1] == 1 && m_ubInBytes[InputBytes.m_eExtMSL_sel2] == 1 &&
                                     m_ubInBytes[InputBytes.m_eExtMSL_sel3] == 1 && m_ubInBytes[InputBytes.m_eExtMSL_sel4] == 1)
                    { //LCU_sel = 1 -> MUX B
                        if (HatchSelected_1stNible(m_ubInBytes[InputBytes.m_eIntMSL_sel1], m_ubInBytes[InputBytes.m_eIntMSL_sel2],
                        m_ubInBytes[InputBytes.m_eIntMSL_sel3], m_ubInBytes[InputBytes.m_eIntMSL_sel4]) != 0)
                        {//some hatch has been selected
                            if (m_ubOutBytes[(OutputBytes)(7 + HatchSelected_1stNible(m_ubOutBytes[InputBytes.m_eIntMSL_sel5], m_ubOutBytes[InputBytes.m_eIntMSL_sel6],
                                m_ubOutBytes[InputBytes.m_eIntMSL_sel7], m_ubOutBytes[InputBytes.m_eIntMSL_sel8]))] == 0)
                            {//"Failed" in the excel file
                             //FILL IT UP!!
                            }
                            else
                            {//"Pass" in the excel file
                             //FILL IT UP!!
                            }
                        }
                        else
                        {//No hatch has been selected
                         //Do I need to check something????
                        }
                        if (HatchSelected_2ndNible(m_ubInBytes[InputBytes.m_eIntMSL_sel5], m_ubInBytes[InputBytes.m_eIntMSL_sel6],
                            m_ubInBytes[InputBytes.m_eIntMSL_sel7], m_ubInBytes[InputBytes.m_eIntMSL_sel8]) != 0)
                        {//some hatch has been selected 
                            if (m_ubOutBytes[(OutputBytes)(7 + HatchSelected_2ndNible(m_ubOutBytes[InputBytes.m_eIntMSL_sel1], m_ubOutBytes[InputBytes.m_eIntMSL_sel2],
                                m_ubOutBytes[InputBytes.m_eIntMSL_sel3], m_ubOutBytes[InputBytes.m_eIntMSL_sel4]))] == 0)
                            {//"Failed" in the excel file
                             //FILL IT UP!!
                            }
                            else
                            {//"Pass" in the excel file
                             //FILL IT UP!!
                            }
                        }
                        else
                        {//No hatch has been selected
                         //Do I need to check something????
                        }
                    }
                    else
                    { //LCU_sel = 0 -> MUX A
                        if (HatchSelected_1stNible(m_ubOutBytes[InputBytes.m_eExtMSL_sel1], m_ubOutBytes[InputBytes.m_eExtMSL_sel2],
                            m_ubOutBytes[InputBytes.m_eExtMSL_sel3], m_ubOutBytes[InputBytes.m_eExtMSL_sel4]) != 0)
                        {//some hatch has been selected
                            if (m_ubOutBytes[(OutputBytes)(7 + HatchSelected_1stNible(m_ubOutBytes[InputBytes.m_eExtMSL_sel1], m_ubOutBytes[InputBytes.m_eExtMSL_sel2],
                                m_ubOutBytes[InputBytes.m_eExtMSL_sel3], m_ubOutBytes[InputBytes.m_eExtMSL_sel4]))] == 0)
                            {//"Failed" in the excel file
                             //FILL IT UP!!
                            }
                            else
                            {//"Pass" in the excel file
                             //FILL IT UP!!
                            }
                        }
                        if (HatchSelected_2ndNible(m_ubOutBytes[InputBytes.m_eExtMSL_sel5], m_ubOutBytes[InputBytes.m_eExtMSL_sel6],
                            m_ubOutBytes[InputBytes.m_eExtMSL_sel7], m_ubOutBytes[InputBytes.m_eExtMSL_sel8]) != 0)
                        {//some hatch has been selected 
                            if (m_ubOutBytes[(OutputBytes)(7 + HatchSelected_2ndNible(m_ubOutBytes[InputBytes.m_eExtMSL_sel5], m_ubOutBytes[InputBytes.m_eExtMSL_sel6],
                                m_ubOutBytes[InputBytes.m_eExtMSL_sel7], m_ubOutBytes[InputBytes.m_eExtMSL_sel8]))] == 0)
                            {//"Failed" in the excel file
                             //FILL IT UP!!
                            }
                            else
                            {//"Pass" in the excel file
                             //FILL IT UP!!
                            }
                        }
                        else
                        {//No hatch has been selected
                         //Do I need to check something????
                        }

                    }
                   
                }
            }


            //Second Step


            for (byte m_iIdx05 = 0; m_iIdx05 < 10; m_iIdx05++)
            { //This for loop is for 8 hatches
                for (byte m_iIdx06 = 0; m_iIdx06 < 16; m_iIdx06++)
                {
                    string m_ubInputString = Convert.ToString(m_iIdx06, 2).PadLeft(4, '0');
                    var m_ubInputArray = m_ubInputString.Select(ch => ch - '0').ToArray();
                    //setGPIO(); //This function will set all the hatch inputs to the CPLD
                    //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                    //let's consider the name of the output array is m_ubOutBytes
                    if (IsHatchOpen(m_ubInputArray[m_iIdx05 * 4], m_ubInputArray[m_iIdx05 * 4 + 1], m_ubInputArray[m_iIdx05 * 4 + 2], m_ubInputArray[m_iIdx05 * 4 + 3]))
                    {
                        if (m_ubOutBytes[(OutputBytes.m_eHatchOpen1) + m_iIdx05] == 1)
                        {//"Pass" in the excel file
                            //FILL IT UP!!
                        }
                        else
                        {//"Failed" in the excel file
                            //FILL IT UP!!
                        }
                    }
                    //if we don't need to check the output at undefined status, the following section colored green isn't necessary:
                    //else
                    //{
                    //    if (m_ubOutBytes[(OutputBytes.m_HatchOpen1) + m_iIdx05]==1)
                    //    {//"Failed" in the excel file
                    //        //FILL IT UP!!
                    //    }
                    //    else
                    //    {//"Pass" in the excel file
                    //        //FILL IT UP!!
                    //    }
                    //}

                    if (m_iIdx05 != 9)
                    {
                        if (IsHatchClosed(m_ubInputArray[m_iIdx05 * 4], m_ubInputArray[m_iIdx05 * 4 + 1], m_ubInputArray[m_iIdx05 * 4 + 2], m_ubInputArray[m_iIdx05 * 4 + 3]))
                        {
                            if (m_ubOutBytes[(OutputBytes.m_eHatchClosed1) + m_iIdx05] == 1)
                            {//"Pass" in the excel file
                             //FILL IT UP!!
                            }
                            else
                            {//"Failed" in the excel file
                             //FILL IT UP!!
                            }
                        }
                        //if we don't need to check the output at undefined status, the following section colored green isn't necessary:
                        //else
                        //{
                        //    if (m_ubOutBytes[(OutputBytes.m_HatchOpen1) + m_iIdx05] == 1)
                        //    {//"Failed" in the excel file
                        //        //FILL IT UP!!
                        //    }
                        //    else
                        //    {//"Pass" in the excel file
                        //        //FILL IT UP!!
                        //    }
                        //}
                    }
                }
            }

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

            string m_smslSelectString = "0001"; //hatch 1 selected
            for (int m_iIdx07 = 0; m_iIdx07 < 512; m_iIdx07++)
            {
                string m_ubInputStringTemp = Convert.ToString(m_iIdx07, 2).PadLeft(9, '0');
                string m_ubInputString = m_smslSelectString + m_ubInputStringTemp;
                var m_ubInputArray = m_ubInputString.Select(ch => ch - '0').ToArray();
                //setGPIO(); //This function will set the inputs: msl_sel1-4, 4 sensors of selected hatch, 4 sensors of uptake, 1 G.A from funCPLD
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                /* Global Abort 1 tests: */
                if (IsGlobalAbort1(m_ubOutBytes[OutputBytes.m_eHatchSel1], m_ubOutBytes[OutputBytes.m_eHatchSel2], m_ubOutBytes[OutputBytes.m_eHatchSel3],
                    m_ubOutBytes[OutputBytes.m_eHatchSel4], m_ubOutBytes[OutputBytes.m_eHatchOpen1], m_ubOutBytes[OutputBytes.m_eHatchOpen2],
                    m_ubOutBytes[OutputBytes.m_eHatchOpen3], m_ubOutBytes[OutputBytes.m_eHatchOpen4], m_ubOutBytes[OutputBytes.m_eUpdakeOpen],
                    m_ubInBytes[InputBytes.m_eFunCPLD_GA1]))
                {//Global abort1 = true
                    if (m_ubOutBytes[OutputBytes.m_eGA1] == 0 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 1)
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
                    if (m_ubOutBytes[OutputBytes.m_eGA1] == 1 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 0)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
                }

                /* Global Abort 2 tests: */
                //setGPIO(); //This function will set the inputs: msl_sel5-8, 4 sensors of selected hatch, 4 sensors of uptake, 1 G.A from funCPLD
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                if (IsGlobalAbort2(m_ubOutBytes[OutputBytes.m_eHatchSel5], m_ubOutBytes[OutputBytes.m_eHatchSel6], m_ubOutBytes[OutputBytes.m_eHatchSel7],
                    m_ubOutBytes[OutputBytes.m_eHatchSel8], m_ubOutBytes[OutputBytes.m_eHatchOpen5], m_ubOutBytes[OutputBytes.m_eHatchOpen6],
                    m_ubOutBytes[OutputBytes.m_eHatchOpen7], m_ubOutBytes[OutputBytes.m_eHatchOpen8], m_ubOutBytes[OutputBytes.m_eUpdakeOpen],
                    m_ubInBytes[InputBytes.m_eFunCPLD_GA2]))
                {//Global abort2 = true
                    if (m_ubOutBytes[OutputBytes.m_eGA2] == 0 || m_ubOutBytes[OutputBytes.m_eGA2Not] == 1)
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
                    if (m_ubOutBytes[OutputBytes.m_eGA2] == 1 || m_ubOutBytes[OutputBytes.m_eGA2Not] == 0)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
                }
            }
            m_smslSelectString = "0010"; //hatch 2 selected
            for (int m_iIdx07 = 0; m_iIdx07 < 512; m_iIdx07++)
            {
                string m_ubInputStringTemp = Convert.ToString(m_iIdx07, 2).PadLeft(9, '0');
                string m_ubInputString = m_smslSelectString + m_ubInputStringTemp;
                var m_ubInputArray = m_ubInputString.Select(ch => ch - '0').ToArray();
                //setGPIO(); //This function will set the inputs: msl_sel1-4, 4 sensors of selected hatch, 4 sensors of uptake, 1 G.A from funCPLD
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                /* Global Abort 1 tests: */
                if (IsGlobalAbort1(m_ubOutBytes[OutputBytes.m_eHatchSel1], m_ubOutBytes[OutputBytes.m_eHatchSel2], m_ubOutBytes[OutputBytes.m_eHatchSel3],
                    m_ubOutBytes[OutputBytes.m_eHatchSel4], m_ubOutBytes[OutputBytes.m_eHatchOpen1], m_ubOutBytes[OutputBytes.m_eHatchOpen2],
                    m_ubOutBytes[OutputBytes.m_eHatchOpen3], m_ubOutBytes[OutputBytes.m_eHatchOpen4], m_ubOutBytes[OutputBytes.m_eUpdakeOpen],
                    m_ubInBytes[InputBytes.m_eFunCPLD_GA1]))
                {//Global abort1 = true
                    if (m_ubOutBytes[OutputBytes.m_eGA1] == 0 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 1)
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
                    if (m_ubOutBytes[OutputBytes.m_eGA1] == 1 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 0)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
                }

                /* Global Abort 2 tests: */
                //setGPIO(); //This function will set the inputs: msl_sel5-8, 4 sensors of selected hatch, 4 sensors of uptake, 1 G.A from funCPLD
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                if (IsGlobalAbort2(m_ubOutBytes[OutputBytes.m_eHatchSel5], m_ubOutBytes[OutputBytes.m_eHatchSel6], m_ubOutBytes[OutputBytes.m_eHatchSel7],
                    m_ubOutBytes[OutputBytes.m_eHatchSel8], m_ubOutBytes[OutputBytes.m_eHatchOpen5], m_ubOutBytes[OutputBytes.m_eHatchOpen6],
                    m_ubOutBytes[OutputBytes.m_eHatchOpen7], m_ubOutBytes[OutputBytes.m_eHatchOpen8], m_ubOutBytes[OutputBytes.m_eUpdakeOpen],
                    m_ubInBytes[InputBytes.m_eFunCPLD_GA2]))
                {//Global abort2 = true
                    if (m_ubOutBytes[OutputBytes.m_eGA2] == 0 || m_ubOutBytes[OutputBytes.m_eGA2Not] == 1)
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
                    if (m_ubOutBytes[OutputBytes.m_eGA2] == 1 || m_ubOutBytes[OutputBytes.m_eGA2Not] == 0)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
                }
            }
            m_smslSelectString = "0100"; //hatch 3 selected
            for (int m_iIdx07 = 0; m_iIdx07 < 512; m_iIdx07++)
            {
                string m_ubInputStringTemp = Convert.ToString(m_iIdx07, 2).PadLeft(9, '0');
                string m_ubInputString = m_smslSelectString + m_ubInputStringTemp;
                var m_ubInputArray = m_ubInputString.Select(ch => ch - '0').ToArray();
                //setGPIO(); //This function will set the inputs: msl_sel1-4, 4 sensors of selected hatch, 4 sensors of uptake, 1 G.A from funCPLD
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                /* Global Abort 1 tests: */
                if (IsGlobalAbort1(m_ubOutBytes[OutputBytes.m_eHatchSel1], m_ubOutBytes[OutputBytes.m_eHatchSel2], m_ubOutBytes[OutputBytes.m_eHatchSel3],
                    m_ubOutBytes[OutputBytes.m_eHatchSel4], m_ubOutBytes[OutputBytes.m_eHatchOpen1], m_ubOutBytes[OutputBytes.m_eHatchOpen2],
                    m_ubOutBytes[OutputBytes.m_eHatchOpen3], m_ubOutBytes[OutputBytes.m_eHatchOpen4], m_ubOutBytes[OutputBytes.m_eUpdakeOpen],
                    m_ubInBytes[InputBytes.m_eFunCPLD_GA1]))
                {//Global abort1 = true
                    if (m_ubOutBytes[OutputBytes.m_eGA1] == 0 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 1)
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
                    if (m_ubOutBytes[OutputBytes.m_eGA1] == 1 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 0)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
                }

                /* Global Abort 2 tests: */
                //setGPIO(); //This function will set the inputs: msl_sel5-8, 4 sensors of selected hatch, 4 sensors of uptake, 1 G.A from funCPLD
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                if (IsGlobalAbort2(m_ubOutBytes[OutputBytes.m_eHatchSel5], m_ubOutBytes[OutputBytes.m_eHatchSel6], m_ubOutBytes[OutputBytes.m_eHatchSel7],
                    m_ubOutBytes[OutputBytes.m_eHatchSel8], m_ubOutBytes[OutputBytes.m_eHatchOpen5], m_ubOutBytes[OutputBytes.m_eHatchOpen6],
                    m_ubOutBytes[OutputBytes.m_eHatchOpen7], m_ubOutBytes[OutputBytes.m_eHatchOpen8], m_ubOutBytes[OutputBytes.m_eUpdakeOpen],
                    m_ubInBytes[InputBytes.m_eFunCPLD_GA2]))
                {//Global abort2 = true
                    if (m_ubOutBytes[OutputBytes.m_eGA2] == 0 || m_ubOutBytes[OutputBytes.m_eGA2Not] == 1)
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
                    if (m_ubOutBytes[OutputBytes.m_eGA2] == 1 || m_ubOutBytes[OutputBytes.m_eGA2Not] == 0)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
                }
            }
            m_smslSelectString = "1000"; //hatch 4 selected
            for (int m_iIdx07 = 0; m_iIdx07 < 512; m_iIdx07++)
            {
                string m_ubInputStringTemp = Convert.ToString(m_iIdx07, 2).PadLeft(9, '0');
                string m_ubInputString = m_smslSelectString + m_ubInputStringTemp;
                var m_ubInputArray = m_ubInputString.Select(ch => ch - '0').ToArray();
                //setGPIO(); //This function will set the inputs: msl_sel1-4, 4 sensors of selected hatch, 4 sensors of uptake, 1 G.A from funCPLD
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                /* Global Abort 1 tests: */
                if (IsGlobalAbort1(m_ubOutBytes[OutputBytes.m_eHatchSel1], m_ubOutBytes[OutputBytes.m_eHatchSel2], m_ubOutBytes[OutputBytes.m_eHatchSel3],
                    m_ubOutBytes[OutputBytes.m_eHatchSel4], m_ubOutBytes[OutputBytes.m_eHatchOpen1], m_ubOutBytes[OutputBytes.m_eHatchOpen2],
                    m_ubOutBytes[OutputBytes.m_eHatchOpen3], m_ubOutBytes[OutputBytes.m_eHatchOpen4], m_ubOutBytes[OutputBytes.m_eUpdakeOpen],
                    m_ubInBytes[InputBytes.m_eFunCPLD_GA1]))
                {//Global abort1 = true
                    if (m_ubOutBytes[OutputBytes.m_eGA1] == 0 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 1)
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
                    if (m_ubOutBytes[OutputBytes.m_eGA1] == 1 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 0)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
                }

                /* Global Abort 2 tests: */
                //setGPIO(); //This function will set the inputs: msl_sel5-8, 4 sensors of selected hatch, 4 sensors of uptake, 1 G.A from funCPLD
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                if (IsGlobalAbort2(m_ubOutBytes[OutputBytes.m_eHatchSel5], m_ubOutBytes[OutputBytes.m_eHatchSel6], m_ubOutBytes[OutputBytes.m_eHatchSel7],
                    m_ubOutBytes[OutputBytes.m_eHatchSel8], m_ubOutBytes[OutputBytes.m_eHatchOpen5], m_ubOutBytes[OutputBytes.m_eHatchOpen6],
                    m_ubOutBytes[OutputBytes.m_eHatchOpen7], m_ubOutBytes[OutputBytes.m_eHatchOpen8], m_ubOutBytes[OutputBytes.m_eUpdakeOpen],
                    m_ubInBytes[InputBytes.m_eFunCPLD_GA2]))
                {//Global abort2 = true
                    if (m_ubOutBytes[OutputBytes.m_eGA2] == 0 || m_ubOutBytes[OutputBytes.m_eGA2Not] == 1)
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
                    if (m_ubOutBytes[OutputBytes.m_eGA2] == 1 || m_ubOutBytes[OutputBytes.m_eGA2Not] == 0)
                    {//"Failed" in the excel file
                        //Fill it up!
                    }
                    else
                    {//"Pass" in the excel file
                        //Fill it up!
                    }
                }
            }

            m_smslSelectString = "0000"; //none hatch has been selected -> global abort1&2 = true
            for (int m_iIdx07 = 0; m_iIdx07 < 512; m_iIdx07++)
            {
                string m_ubInputStringTemp = Convert.ToString(m_iIdx07, 2).PadLeft(9, '0');
                string m_ubInputString = m_smslSelectString + m_ubInputStringTemp;
                var m_ubInputArray = m_ubInputString.Select(ch => ch - '0').ToArray();
                //setGPIO(); //This function will set all the relevant inputs to the CPLD
                //getGPIO(); //This function returns an array of 33 bytes(the outputs from the CPLD)
                /* Global Abort 1 tests: */
                if(m_ubOutBytes[OutputBytes.m_eGA1]==0 || m_ubOutBytes[OutputBytes.m_eGA1Not] == 1 || m_ubOutBytes[OutputBytes.m_eGA2] == 0 || m_ubOutBytes[OutputBytes.m_eGA2Not] == 1)
                {//"Failed" in the excel file
                    //Fill it up!
                }
                else
                {//"Pass in the excel file
                    //Fill it up!
                }
            }



            //Fourth step

            

        }//Main
    }//class Hatch
} //namespace
    


