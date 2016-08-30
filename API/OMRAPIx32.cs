using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AttendanceReadCard
{
    public static class OMRAPIx32
    {
        // ------------------------------------------------------------------------------
        // OMR_GetMarks(int iPage, OMR_MARK_INFO *pMarkInfo, CHAR *pMarks);
        [DllImport("OMRAPI.x32")]
        public static extern bool OMR_GetMarks(uint iPage, ref OMRAPI.OMR_MARK MarkInfo, ref byte MarkArray);

        // /*-----------------------------------------------------------------------------
        // OMR API functions
        // -----------------------------------------------------------------------------*/
        // /*-USB Port Functions-------------------*/
        // OMR_STATUS  OMR_API OMR_OpenDeviceUSB();
        [DllImport("OMRAPI.x32")]
        public static extern OMRStatus OMR_OpenDeviceUSB();

        // /*-other--------------------------------*/
        // OMR_STATUS  OMR_API OMR_CloseDevice(void);
        [DllImport("OMRAPI.x32")]
        public static extern OMRStatus OMR_CloseDevice();

        // OMR_STATUS  OMR_API OMR_GetLastError(void);
        [DllImport("OMRAPI.x32")]
        public static extern OMRStatus OMR_GetLastError();

        // const CHAR  OMR_API *OMR_FormatMessage(OMR_STATUS status  int iLanguageFlag);
        [DllImport("OMRAPI.x32")]
        public static extern uint OMR_FormatMessage(OMRStatus status, uint iLanguage);

        // const CHAR  OMR_API *OMR_GetST(int iPage);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_GetST(long iPage);

        // /*-Commands-----------------------------*/
        // /*-Settings-----------------------------*/
        // BOOL        OMR_API OMR_SetNumberOfColumnsToRead(int iColumns);
        [DllImport("OMRAPI.x32")]
        public static extern bool OMR_SetNumberOfColumnsToRead(uint iColumns);

        // int         OMR_API OMR_GetNumberOfColumnsToRead(void);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_GetNumberOfColumnsToRead();

        // BOOL        OMR_API OMR_SetReadingMethod(int iControlType  int iMultipleValue);
        [DllImport("OMRAPI.x32")]
        public static extern bool OMR_SetReadingMethod(SR_READ iControlType, uint iMultipleValue);

        // BOOL        OMR_API OMR_GetReadingMethod(int *iControlType  int *iMultipleValue);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_GetReadingMethod(ref uint iControlType, ref uint iMultipleValue);

        // BOOL        OMR_API OMR_SetBackSensorUnit(int iDirective);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_SetBackSensorUnit(uint iDirective);

        // int         OMR_API OMR_GetBackSensorUnit(void);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_GetBackSensorUnit();

        // BOOL        OMR_API OMR_SetSheetFeedMode(int iMode  int iInsertTime);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_SetSheetFeedMode(uint iMode, uint iInsertTime);

        // Public Declare Function OMR_SetSheetFeedMode Lib "OMRAPI.x32" (ByRef iMode As Long, ByRef iInsertTime As Long) As Long
        // BOOL        OMR_API OMR_GetSheetFeedMode(int *iMode  int *iInsertTime);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_GetSheetFeedMode(ref uint iMode, ref uint iInsertTime);

        // Public Declare Function OMR_GetSheetFeedMode Lib "OMRAPI.x32" (ByRef iMode As Integer, ByRef iInsertTime As Integer) As Integer
        // BOOL        OMR_API OMR_SetSheetThickness(int iThickness);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_SetSheetThickness(uint iThickness);

        // int         OMR_API OMR_GetSheetThickness(void);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_GetSheetThickness();

        // BOOL        OMR_API OMR_SetWarningError(DWORD dwConfigData, int iSkewCol, int iSkewLevel);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_SetWarningError(uint dwConfigData, uint iSkewCol, uint iSkewLevel);

        // BOOL        OMR_API OMR_GetWarningError(DWORD *dwConfigData  int *iSkewCol, int *iSkewLevel);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_GetWarningError(ref uint dwConfigData, ref uint iSkewCol, ref uint iSkewLevel);

        // BOOL        OMR_API OMR_SetPanelConfig(int iPanelEnable);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_SetPanelConfig(uint iPanelEnable);

        // int         OMR_API OMR_GetPanelConfig(void);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_GetPanelConfig();

        // BOOL        OMR_API OMR_SetBuzzerConfig(int iVolume  int iTone);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_SetBuzzerConfig(uint iVolume, uint iTone);

        // BOOL        OMR_API OMR_GetBuzzerConfig(int *iVolume  int *iTone);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_GetBuzzerConfig(ref uint iVolume, ref uint iTone);

        // BOOL        OMR_API OMR_SetID(CHAR *pID);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_SetID(ref byte pID);

        // BOOL        OMR_API OMR_GetID(CHAR *pID);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_GetID(ref byte pID);

        // BOOL        OMR_API OMR_SetPrintString(int  CHAR *);
        // BOOL        OMR_API OMR_GetPrintString(int  CHAR *);
        // BOOL        OMR_API OMR_SetPrintPosition(DWORD);
        // DWORD       OMR_API OMR_GetPrintPosition(void);
        // BOOL        OMR_API OMR_SetPrintOrder(int  int  int);
        // BOOL        OMR_API OMR_GetPrintOrder(int*  int*  int*);
        // BOOL        OMR_API OMR_SetPrintAngle(DWORD);
        // DWORD       OMR_API OMR_GetPrintAngle(void);
        // //BOOL      OMR_API OMR_SetPrintFont(CHAR *pFont);
        // //BOOL      OMR_API OMR_GetPrintFont(CHAR *pFont);
        // //BOOL      OMR_API OMR_SetBarCodeConfig(CHAR *pCommand);
        // */
        // /*-movement request---------------------*/
        // BOOL        OMR_API OMR_Reset(void);
        [DllImport("OMRAPI.x32")]
        public static extern bool OMR_Reset();

        // BOOL        OMR_API OMR_FeedSheet(void);
        [DllImport("OMRAPI.x32")]
        public static extern bool OMR_FeedSheet();

        // BOOL        OMR_API OMR_MoveHopper(int iDirection);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_MoveHopper(int iDirection);

        // BOOL        OMR_API OMR_EjectSheet(int iDirection);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_EjectSheet(int iDirection);

        // BOOL        OMR_API OMR_InitialSetting(void);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_InitialSetting();

        // OMR_STATUS  OMR_API OMR_CancelError(void);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_CancelError();

        // /*-deta request-------------------------*/
        // BOOL        OMR_API OMR_GetMarks(int iPage  OMR_MARK *stMark);
        // Public Declare Function OMR_GetMarks Lib "OMRAPI.x32" (ByVal iPage As Long, ByRef stMark As OMR_MARK) As Long
        // OMR_STATUS  OMR_API OMR_GetStatus(void);
        [DllImport("OMRAPI.x32")]
        public static extern OMRStatus OMR_GetStatus();

        // DWORD       OMR_API OMR_GetSensorInfo(void);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_GetSensorInfo();

        // DWORD       OMR_API OMR_GetDeviceInfo(void);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_GetDeviceInfo();

        // BOOL        OMR_API OMR_GetMachineName(CHAR* pResult);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_GetMachineName(ref byte pResult);

        // BOOL        OMR_API OMR_GetVersion(int iTarget  CHAR* pResult);
        //[DllImport("OMRAPI.x32")]
        //public static extern uint OMR_GetVersion(uint iTarget, ref byte pResult);
    }
}
