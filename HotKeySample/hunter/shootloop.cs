using System;
using System.Runtime.InteropServices;
using System.Threading;

public class ShootLoop
{

    const string USER32DLL = "User32.dll";
    const string CONFIG = "config.xml";
    [DllImport(USER32DLL)]
    private static extern bool SetCursorPos(int x, int y);

    [DllImport(USER32DLL)]
    private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);

    private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;  //The left button was pressed
    private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;  //The left button was released.
    private const UInt32 MOUSEEVENTF_RIGHTDOWN = 0x08;   //The right button was pressed
    private const UInt32 MOUSEEVENTF_RIGHTUP = 0x10;   //The left button was released.
    private const UInt32 MOUSEEVENTF_MIDDLEDOWN = 0x0020;  //The middle button was pressed
    private const UInt32 MOUSEEVENTF_MIDDLEUP = 0x0040;  //The middle button was released.

    [DllImport(USER32DLL, EntryPoint = "keybd_event", SetLastError = true)]
    public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        
    private static double TtickTime = 0;
    private static double Speed = 1;
    private const double UNI_CD_TIME = 1500;
    private const double SKILL_CD_3 = 1000 * 15;
    private const double SKILL_CD_2 = 1000 * 10;
    private const double SKILL_CD_1 = 1000 * 6;
    private const double SKILL_SING_2 = 1500;
    private const double SKILL_SING_1 = 1000 * 3;

    private const double WAIT_1_TIME = 1000;
    private const double WAIT_2_TIME = 2000;

    private const byte SKILL_KEY_1 = 69;
    private const byte SKILL_KEY_2 = 81;
    private const byte SKILL_KEY_3 = 49;

    private static double cdTime = 0;

    public static void ClickKeyShoot()
    {
        while(true)
        {
            FuncKeyClick(SKILL_KEY_1);
            CountCDTime(SKILL_SING_1);//3  
            FuncKeyClick(SKILL_KEY_2);
            CountCDTime(UNI_CD_TIME);//1.5 
            FuncKeyClick(SKILL_KEY_3);
            CountCDTime(UNI_CD_TIME);//1.5  6
            FuncKeyClick(SKILL_KEY_1);
            CountCDTime(SKILL_SING_1);//3
            CountCDTime(UNI_CD_TIME);//1.5
            CountCDTime(UNI_CD_TIME);//1.5 12
            FuncKeyClick(SKILL_KEY_1);
            CountCDTime(SKILL_SING_1);//3  15
            FuncKeyClick(SKILL_KEY_2);
            CountCDTime(UNI_CD_TIME);//1.5 16.5
            FuncKeyClick(SKILL_KEY_3);
            CountCDTime(UNI_CD_TIME);//1.5  18
            FuncKeyClick(SKILL_KEY_1);
            CountCDTime(SKILL_SING_1);//3   21
            //FuncKeyClick(SKILL_KEY_3);
            CountCDTime(UNI_CD_TIME);//1.5  
            CountCDTime(UNI_CD_TIME);//1.5  24
            FuncKeyClick(SKILL_KEY_1);
            CountCDTime(SKILL_SING_1);//3   27
            FuncKeyClick(SKILL_KEY_2);
            CountCDTime(UNI_CD_TIME);//1.5
            CountCDTime(UNI_CD_TIME);//1.5  30
            FuncKeyClick(SKILL_KEY_1);
            CountCDTime(SKILL_SING_1);//3   33
            FuncKeyClick(SKILL_KEY_3);

            CountCDTime(UNI_CD_TIME);//1.5 
            CountCDTime(UNI_CD_TIME);//1.5  36
            FuncKeyClick(SKILL_KEY_1);
            CountCDTime(SKILL_SING_1);//3   39
            FuncKeyClick(SKILL_KEY_2);
            CountCDTime(UNI_CD_TIME);//1.5
            CountCDTime(UNI_CD_TIME);//1.5  42
            FuncKeyClick(SKILL_KEY_1);
            CountCDTime(SKILL_SING_1);//3   45
            CountCDTime(UNI_CD_TIME);//1.5
            FuncKeyClick(SKILL_KEY_3);
            CountCDTime(UNI_CD_TIME);//1.5  48
            FuncKeyClick(SKILL_KEY_1);
            CountCDTime(SKILL_SING_1);//3   51
            FuncKeyClick(SKILL_KEY_2);
            CountCDTime(UNI_CD_TIME);//1.5  
            CountCDTime(UNI_CD_TIME);//1.5  54
            FuncKeyClick(SKILL_KEY_1);
            CountCDTime(SKILL_SING_1);//3   57
            CountCDTime(UNI_CD_TIME);//1.5  
            CountCDTime(UNI_CD_TIME);//1.5  60

        }

    }




    public static void SpeedShot()
    {
        Speed = 0.4;
        FuncKeyClick(53);
        FuncKeyClick(SKILL_KEY_1);
        CountCDTime(UNI_CD_TIME); //1.5
        FuncKeyClick(SKILL_KEY_2);
        CountCDTime(UNI_CD_TIME);//1.5
        FuncKeyClick(49);
        CountCDTime(UNI_CD_TIME);//1.5
        CountCDTime(UNI_CD_TIME);//1.5
        FuncKeyClick(SKILL_KEY_1);
        CountCDTime(SKILL_SING_1);//3
        CountCDTime(UNI_CD_TIME);//1.5
        FuncKeyClick(SKILL_KEY_2);
        CountCDTime(UNI_CD_TIME);//1.5
        FuncKeyClick(SKILL_KEY_1);
        CountCDTime(UNI_CD_TIME);//1.5
        CountCDTime(UNI_CD_TIME);//1.5
        CountCDTime(SKILL_SING_1);//3
        FuncKeyClick(SKILL_KEY_1);
        CountCDTime(SKILL_SING_1);//3
        CountCDTime(SKILL_SING_1);//3

    }

    public static double CdTick()
    {

        CostSkill3();
        CostSkill1();
        CostSkill2();


        while (true)
        {
            if(TtickTime % SKILL_CD_1 == 0)
            {
                CostSkill1();
            }
            if (TtickTime % SKILL_CD_2 == 0)
            {
                CostSkill2();
            }

            TtickTime += UNI_CD_TIME;
        }

        return TtickTime;
    }


    private static void CostSkill1()
    {
        FuncKeyClick(SKILL_KEY_1);
        CountCDTime(SKILL_SING_1);
        TtickTime += SKILL_SING_1;

    }

    private static void CostSkill2()
    {
        FuncKeyClick(SKILL_KEY_2);
        CountCDTime(SKILL_SING_2);
        TtickTime += SKILL_SING_2;

    }

    private static void CostSkill3()
    {
        FuncKeyClick(SKILL_KEY_3);
        CountCDTime(UNI_CD_TIME);
        TtickTime += UNI_CD_TIME;

    }


    public static double CountCDTime( double cdt)
    {

        Thread.Sleep((int)cdt);
        cdTime += cdt;
        System.Console.WriteLine(cdTime);
        return cdTime;
    }

    public static void FuncKeyClick( byte keyNum)
    {
        //A'65' B"66  Z'90  (0)'48 (1)'49  (9)'57  F1'112  F12'123  
        //Q SKILL_KEY_2  E SKILL_KEY_1  R 82  F 70
        //
        keybd_event(keyNum, 0, 0, 0);
        keybd_event(keyNum, 0, 0x0002, 0);
        System.Console.WriteLine(keyNum);

    }

    public static void FuncKeyPress( byte keyNum)
    {
        keybd_event(keyNum, 0, 0, 0);
    }


    public static void FuncKeyUp(byte keyNum)
    {
        //A'65' B"66  Z'90  (0)'48 (1)'49  (9)'57  F1'112  F12'123  
        //Q SKILL_KEY_2  E SKILL_KEY_1  R 82  F 70
        //
        keybd_event(keyNum, 0, 0x0002, 0);

    }


}
