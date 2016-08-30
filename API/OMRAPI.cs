/*
 * 從  VB6 的範例轉換過來。
 * 2012/8/27 Yaoming
 */
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
namespace AttendanceReadCard
{
    // ----------------------------------------------------------------------------
    // OMR API for SR-2200 Header
    // Copyright 2002- SEKONIC CORPORATION
    // ---------------------------------------------------------------------------
    // version history
    // date        version     notes
    // 2002.08.20  1.0.0       first release
    // ----------------------------------------------------------------------------*/
    // /*----------
    // system fixed number
    // ----------*/
    /// <summary>
    /// 讀卡機狀態列舉。
    /// </summary>
    public enum OMRStatus : uint
    {
        SR_SUCCESS = 0,
        SR_UNSUCCESSFUL,
        SR_DISCONNECTED,
        SR_WRONG_PARAMETER,
        SR_MEMORY_ERROR,
        SR_TIMEOUT,
        SR_RECEIVE_NAK,
        SR_WRONG_RESPONSE,
        // /*
        // '/*
        // Status Error Information
        // 0xXXXXXXXX
        // ||||
        // ||++------- :Page
        // ||
        // |+------ 0x0    :Main
        // |        0x1    :Sensor unit
        // |        0x2    :(reserved)
        // |        0x3    :Barcode reader unit
        // |        0x4    :Printer unit
        // |        0x5    :Stacker unit
        // |        0xf    :other
        // |
        // +---- 0x0   :impossible to recovery(Hard error)
        // 0x1   :Communication Error
        // 0x2   :Cover open error
        // 0x3   :Jam Error
        // 0x4   :Warning
        // */
        SR_ERROR_STATUS_A1 = 0x10000, // 0x00010000
        SR_ERROR_STATUS_A2,
        SR_ERROR_STATUS_A3,
        SR_ERROR_STATUS_A4,
        SR_ERROR_STATUS_A5,
        SR_ERROR_STATUS_B1F = 0x1020000, // 0x01020000
        SR_ERROR_STATUS_B2F,
        SR_ERROR_STATUS_B3F,
        SR_ERROR_STATUS_B4F,
        SR_ERROR_STATUS_B5F,
        SR_ERROR_STATUS_B6F,
        SR_ERROR_STATUS_B1B = 0x2020000, // 0x02020000
        SR_ERROR_STATUS_B2B,
        SR_ERROR_STATUS_B3B,
        SR_ERROR_STATUS_B4B,
        SR_ERROR_STATUS_B5B,
        SR_ERROR_STATUS_B6B,
        SR_ERROR_STATUS_C1 = 0x3030000, // 0x03030000
        SR_ERROR_STATUS_C2,
        SR_ERROR_STATUS_C3,
        SR_ERROR_STATUS_C4,
        SR_ERROR_STATUS_C5,
        SR_ERROR_STATUS_C6,
        SR_ERROR_STATUS_D1 = 0x4040000, // 0x04040000
        SR_ERROR_STATUS_D2,
        SR_ERROR_STATUS_D3,
        SR_ERROR_STATUS_D4,
        SR_ERROR_STATUS_D5,
        SR_ERROR_STATUS_E1 = 0x5050000, // 0x05050000
        SR_ERROR_STATUS_E2,
        SR_ERROR_STATUS_E3,
        SR_ERROR_STATUS_E4,
        SR_ERROR_STATUS_E5,
        SR_ERROR_STATUS_F1 = 0x1F060000, // 0x1f060000
        SR_ERROR_STATUS_F2,
        SR_ERROR_STATUS_F3,
        SR_ERROR_STATUS_F4,
        SR_ERROR_STATUS_F5,
        SR_ERROR_STATUS_F6,
        SR_ERROR_STATUS_CoverOpen = 0x20070000, // 0x20070000
        SR_ERROR_STATUS_G2 = 0x25070001, // 0x25070001
        SR_ERROR_STATUS_G3 = 0x25070002, // 0x25070002
        SR_ERROR_STATUS_H1_NoPaper = 0x30080000, // 0x30080000
        SR_ERROR_STATUS_H2,
        SR_ERROR_STATUS_H3,
        SR_ERROR_STATUS_H4,
        SR_ERROR_STATUS_I1 = 0x35090000, // 0x35090000
        SR_ERROR_STATUS_I2,
        SR_ERROR_STATUS_I3,
        SR_ERROR_STATUS_I4,
        SR_ERROR_STATUS_P1 = 0x42100000, // 0x42100000
        SR_ERROR_STATUS_P2 = 0x43100001, // 0x43100001
        SR_ERROR_STATUS_P3 = 0x44100002, // 0x44100002
        SR_ERROR_STATUS_P4 = 0x45100003, // 0x45100003
        SR_ERROR_STATUS_Q1_SheetEmpty = 0x40110000, // 0x40110000
        SR_ERROR_STATUS_Q2_DoubleFeedError,
        SR_ERROR_STATUS_Q3_LeftSideSkewerError,
        SR_ERROR_STATUS_Q4_MarkScewerError,
        SR_ERROR_STATUS_R1 = 0x40120000, // 0x40120000
        SR_ERROR_STATUS_R2,
        SR_ERROR_STATUS_R3,
        SR_ERROR_STATUS_R4M_TimingMarkError = 0x41120003, // 0x41120003
        SR_ERROR_STATUS_R4F_FrontTimingMarkError = 0x41120004, // 0x41120004
        SR_ERROR_STATUS_R4B_BackTimingMarkError = 0x42120005, // 0x42120005
        SR_ERROR_STATUS_S1F = 0x41130000, // 0x41130000
        SR_ERROR_STATUS_S2F,
        SR_ERROR_STATUS_S1B = 0x42130002, // 0x42130002
        SR_ERROR_STATUS_S2B,
        SR_ERROR_STATUS_T1 = 0x40140000, // 0x40140000
        SR_ERROR_STATUS_T2,
        SR_ERROR_STATUS_T3,
        SR_ERROR_STATUS_T4 = 0x45140003, // 0x45140003
        SR_ERROR_STATUS_T5,
        SR_ERROR_STATUS_T6,
        SR_ERROR_STATUS_T7,
        SR_ERROR_TERM = 0xFFFFFFFF, // 0xffffffff
    }

    public class GlobalConsts
    {
        //*-Global Parameter---------------------*/
        public const uint SR_INITIAL = 0x80000000;
        public const uint SR_DISABLE = 0;
        public const uint SR_ENABLE = 1;
        public const uint SR_FUNCTION_FAIL = 0xFFFFFFFF;
    }

    // /*-iLanguageFlag------------------------*/
    public enum SR_STRING : uint
    {
        SR_STRING_NORMAL = 0,
        SR_STRING_ENGLISH,
        SR_STRING_JAPANESE,
    }

    // /*-iPage -------------------------------*/
    public enum SR_PAGE : uint
    {
        SR_PAGE_FRONT = 0,
        SR_PAGE_BACK,
    }

    // /*-Reading Method(iControlType)---------*/
    public enum SR_READ : uint
    {
        SR_READ_FRONT_EDGE = 1, // '/*  Front Edge control type */
        SR_READ_REAR_EDGE, // /*  Rear Edge control type  */
        SR_READ_DIRECT, // /*  Direct type */
        SR_READ_FACOM, // '/*  FACOM type  */
        SR_READ_BETWEEN_MARK_NO_SPACE, // '/*  Between mark and mark without front edge space  */
        SR_READ_BETWEEN_MARK, // '/*  Between mark and mark   */
        SR_READ_INITIAL = GlobalConsts.SR_INITIAL, // /*  Initialize control type */
    }


    // /*-Sheet thickness----------------------*/
    public enum SR_THICKNESS : uint
    {
        SR_THICKNESS_AUTO_DETECT = 0, // /*  Auto            */
        SR_THICKNESS_80_MICRON, // /*  0.08mm (55kg)   */
        SR_THICKNESS_110_MICRON, // /*  0.11mm (72kg)   */
        SR_THICKNESS_130_MICRON, // /*  0.13mm (90kg)   */
        SR_THICKNESS_160_MICRON, // /*  0.16mm (110kg)  */
        SR_THICKNESS_190_MICRON, // /*  0.19mm (135kg)  */
        SR_THICKNESS_INITIAL = GlobalConsts.SR_INITIAL, // /*  initailze       */
        SR_THICKNESS_55_KG = 1, // /*  0.08mm (55kg)   */
        SR_THICKNESS_72_KG, // /*  0.11mm (72kg)   */
        SR_THICKNESS_90_KG, // /*  0.13mm (90kg)   */
        SR_THICKNESS_110_KG, // /*  0.16mm (110kg)  */
        SR_THICKNESS_135_KG, // /*  0.19mm (135kg)  */
    }

    // /*-Buzzer Tone--------------------------*/
    public enum SR_BUZZER : uint
    {
        SR_BUZZER_TONE_A = 1,
        SR_BUZZER_TONE_B,
        SR_BUZZER_TONE_C,
    }


    // /*-Eject (iDirection)-------------------*/
    public enum SR_EJECT : uint
    {
        SR_EJECT_MAIN = 1,
        SR_EJECT_SELECT,
        SR_EJECT_MAIN_ON_NEXT,
        SR_EJECT_SELECT_ON_NEXT,
    }


    // /*-Unit Name----------------------------*/
    public enum SR_UNIT : uint
    {
        SR_UNIT_MAIN = 0, // /*  Main                */
        SR_UNIT_FRONT, // /*  Front Sensor unit   */
        SR_UNIT_BACK, // /*  Back Sendor unit    */
        SR_UNIT_BARCODE, // /*  Barcode reader unit */
        SR_UNIT_PRINTER, // /*  Printer unit        */
        SR_UNIT_STACKER, // /*  Stacker unit        */
    }


    // /*-Print buffer-------------------------*/
    public enum SR_PRINT : uint
    {
        SR_PRINT_BUFFER_NULL = 0,
        SR_PRINT_BUFFER_1,
        SR_PRINT_BUFFER_2,
        SR_PRINT_BUFFER_3,
    }


    // /*-Field direction----------------------*/
    public enum SR_DIR : uint
    {
        SR_DIR_LEFT_DOWN_VERTICAL = 0,
        SR_DIR_RIGHT_DOWN_VERTICAL,
        SR_DIR_LEFT_UP_VERTICAL,
        SR_DIR_RIGHT_UP_VERTICAL,
        SR_DIR_LEFT_DOWN_HORIZONTAL,
        SR_DIR_RIGHT_DOWN_HORIZONTAL,
        SR_DIR_LEFT_UP_HORIZONTAL,
        SR_DIR_RIGHT_UP_HORIZONTAL,
    }

    public class OMRAPI
    {

        // /*-Global Parameter---------------------*/
        public const uint SR_INITIAL = 0x80000000;
        public const uint SR_DISABLE = 0;
        public const uint SR_ENABLE = 1;
        public const uint SR_FUNCTION_FAIL = 0xFFFFFFFF;
        public const uint SR_PAGE_MAX = 2;
        // /*-Col Row------------------------------*/
        public const uint SR_COL_MAX = 48;
        // /*-Feed Mode(iMode)---------------------*/
        public const uint SR_MODE_AUTO = 0;
        public const uint SR_MODE_MANUAL = 1;
        // /*-WarningError-------------------------*/
        public const uint SR_WARN_MARK_SKEW = 0x200000;
        public const uint SR_WARN_LEFT_SKEW = 0x100000;
        public const uint SR_WARN_DF_ERROR = 0x80000;
        public const uint SR_WARN_TM_ERROR = 0x40000;
        public const uint SR_WARN_HOPPER_EMPTY = 0x20000;
        public const uint SR_WARN_AUTO_REJECT = 0x10000;
        public const uint SR_WARN_NONE = 0x0;
        public const uint SR_WARN_ALL = 0x3F0000;
        public const uint SR_WARN_INITIAL = 0x10000000;
        // /*-Buzzer Volume------------------------*/
        public const uint SR_BUZZER_DISABLE = 0;
        // '/* Buzzer Off           */
        public const uint SR_BUZZER_MIN = 1;
        // '/* Buzzer Volume Min.   */
        public const uint SR_BUZZER_MAX = 5;
        // '/* Buzzer Volume Max.   */
        public const uint SR_BUZZER_INITIAL = SR_INITIAL;
        // /*-ID-----------------------------------*/
        public const uint SR_ID_LENGTH_MAX = 20;
        // /*-Hopper(iDirection)-------------------*/
        public const uint SR_HOPPER_DOWN = 0;
        public const uint SR_HOPPER_UP = 1;
        // /*-Mark Type----------------------------*/
        public const uint SR_MARK_TYPE_16 = 16;
        public const uint SR_MARK_TYPE_256 = 256;
        // /*-Sensor-------------------------------*/
        public const uint SR_SENSOR_OUTPS = 0x20000000;
        public const uint SR_SENSOR_RDPS = 0x10000000;
        public const uint SR_SENSOR_INPS = 0x8000000;
        public const uint SR_SENSOR_PS0 = 0x4000000;
        public const uint SR_SENSOR_UPPS = 0x2000000;
        public const uint SR_SENSOR_DWPS = 0x1000000;
        public const uint SR_SENSOR_SKS = 0x100000;
        public const uint SR_SENSOR_MAIN_CVR = 0x10000;
        public const uint SR_SENSOR_SPS = 0x800;
        public const uint SR_SENSOR_MPS = 0x400;
        public const uint SR_SENSOR_P2PS = 0x200;
        public const uint SR_SENSOR_STPS = 0x100;
        public const uint SR_SENSOR_STK_CVR2 = 0x2;
        public const uint SR_SENSOR_STK_CVR1 = 0x1;
        // /*-Device-------------------------------*/
        public const uint SR_DEVICE_UNIT_BACK = 0x10000;
        public const uint SR_DEVICE_UNIT_BARCODE = 0xF00000;
        public const uint SR_DEVICE_UNIT_BARCODE_V = 0x100000;
        public const uint SR_DEVICE_UNIT_BARCODE_H = 0x200000;
        public const uint SR_DEVICE_UNIT_PRINTER = 0x1000000;
        public const uint SR_DEVICE_UNIT_STACKER = 0x10000000;
        public const uint SR_DEVICE_SENSOR_TYPE_MASK = 0x10;
        public const uint SR_DEVICE_SENSOR_PITCH_MASK = 0xF;
        // /*-Print position-----------------------*/
        public const uint SR_PRINT_INITIAL = 0xFFFF0000;
        public const uint SR_PRINT_MILI = 0xFF00000;
        public const uint SR_PRINT_INCH = 0xFFF0000;
        public const uint SR_PRINT_POSITION = 0xFFFF;
        public const uint SR_PRINT_ANGLE_0 = 1;
        public const uint SR_PRINT_ANGLE_180 = 2;

        /// <summary>
        /// 取得錯誤訊息。
        /// </summary>
        /// <param name="status"></param>
        /// <param name="iLanguage"></param>
        /// <returns></returns>
        public static string OMR_FormatMessageCSharp(OMRStatus status, uint iLanguage)
        {
            byte[] binaryMsg = new byte[256];

            if (lstrcpy(ref binaryMsg[0], OMR_FormatMessage(status, (uint)iLanguage)) == 0)
            {
                MessageBox.Show("lstrcpy function is fail.", "ischool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }

            string msg = Encoding.UTF8.GetString(binaryMsg);
            return msg.Substring(0, msg.IndexOf('\0'));
        }

        public static bool OMR_GetMarks(uint iPage, ref OMRAPI.OMR_MARK MarkInfo, ref byte MarkArray)
        {
            if (Environment.Is64BitOperatingSystem)
                return OMRAPIx64.OMR_GetMarks(iPage, ref MarkInfo, ref MarkArray);
            else
                return OMRAPIx32.OMR_GetMarks(iPage, ref MarkInfo, ref MarkArray);
        }

        public static OMRStatus OMR_OpenDeviceUSB()
        {
            if (Environment.Is64BitOperatingSystem)
                return OMRAPIx64.OMR_OpenDeviceUSB();
            else
                return OMRAPIx32.OMR_OpenDeviceUSB();
        }

        public static OMRStatus OMR_CloseDevice()
        {
            if (Environment.Is64BitOperatingSystem)
                return OMRAPIx64.OMR_CloseDevice();
            else
                return OMRAPIx32.OMR_CloseDevice();
        }

        public static OMRStatus OMR_GetLastError()
        {
            if (Environment.Is64BitOperatingSystem)
                return OMRAPIx64.OMR_GetLastError();
            else
                return OMRAPIx32.OMR_GetLastError();
        }

        public static uint OMR_FormatMessage(OMRStatus status, uint iLanguage)
        {
            if (Environment.Is64BitOperatingSystem)
                return OMRAPIx64.OMR_FormatMessage(status, iLanguage);
            else
                return OMRAPIx32.OMR_FormatMessage(status, iLanguage);
        }

        public static bool OMR_SetNumberOfColumnsToRead(uint iColumns)
        {
            if (Environment.Is64BitOperatingSystem)
                return OMRAPIx64.OMR_SetNumberOfColumnsToRead(iColumns);
            else
                return OMRAPIx32.OMR_SetNumberOfColumnsToRead(iColumns);
        }

        public static bool OMR_SetReadingMethod(SR_READ iControlType, uint iMultipleValue)
        {
            if (Environment.Is64BitOperatingSystem)
                return OMRAPIx64.OMR_SetReadingMethod(iControlType, iMultipleValue);
            else
                return OMRAPIx32.OMR_SetReadingMethod(iControlType, iMultipleValue);
        }

        public static bool OMR_Reset()
        {
            if (Environment.Is64BitOperatingSystem)
                return OMRAPIx64.OMR_Reset();
            else
                return OMRAPIx32.OMR_Reset();
        }

        public static bool OMR_FeedSheet()
        {
            if (Environment.Is64BitOperatingSystem)
                return OMRAPIx64.OMR_FeedSheet();
            else
                return OMRAPIx32.OMR_FeedSheet();
        }

        public static OMRStatus OMR_GetStatus()
        {
            if (Environment.Is64BitOperatingSystem)
                return OMRAPIx64.OMR_GetStatus();
            else
                return OMRAPIx32.OMR_GetStatus();
        }

        [DllImport("kernel32.dll")]
        public static extern uint lstrcpy(ref byte lpString1, uint lpString2);

        public struct OMR_MARK
        {
            public uint Type;
            public uint Rows;
            public uint Columns;
        }
    }

}
