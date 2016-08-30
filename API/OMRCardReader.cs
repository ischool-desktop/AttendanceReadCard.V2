using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AttendanceReadCard
{
    public static class OMRCardReader
    {
        private static int Columns { get; set; }

        private static int Rows { get; set; }

        /// <summary>
        /// 開啟讀卡機裝置連線。
        /// </summary>
        /// <param name="columnCount">卡片欄數。</param>
        /// <param name="rowCount">卡片列數。</param>
        /// <returns></returns>
        public static void Open(int columnCount, int rowCount)
        {
            Columns = columnCount;
            Rows = rowCount;

            OMRStatus Ret = OMRAPI.OMR_OpenDeviceUSB();
            if (Ret != OMRStatus.SR_SUCCESS)
                throw new OMRCardReaderException("OMR USB ERORR", Ret);

            Reset();
        }

        /// <summary>
        /// 關閉讀卡機裝罝連線。
        /// </summary>
        /// <returns></returns>
        public static void Close()
        {
            OMRStatus Ret = OMRAPI.OMR_CloseDevice();
            if (Ret != OMRStatus.SR_SUCCESS)
                throw new OMRCardReaderException("OMR USB ERORR", Ret);
        }

        /// <summary>
        /// 重置讀卡機狀態。
        /// </summary>
        public static void Reset()
        {
            if (!OMRAPI.OMR_Reset())
                ThrowLastError();

            if (!OMRAPI.OMR_SetNumberOfColumnsToRead((uint)Columns))
                ThrowLastError();

            if (!OMRAPI.OMR_SetReadingMethod(SR_READ.SR_READ_DIRECT, 1))
                ThrowLastError();
        }

        /// <summary>
        /// 讀一張卡。
        /// </summary>
        /// <returns></returns>
        public static bool FeedSheet(out byte[] data, out Exception error)
        {
            data = new byte[Rows * Columns];

            if (!OMRAPI.OMR_FeedSheet())
            {
                OMRStatus status;
                string msg = GetLastErrorMessage(out status);
                error = new OMRCardReaderException(msg, status);
                return false;
            }

            OMRStatus feedret = OMRAPI.OMR_GetStatus();
            if (feedret != OMRStatus.SR_SUCCESS)
            {
                string m = "error code =(" + feedret + ")" + "\r" + "\n" +
                    OMRAPI.OMR_FormatMessageCSharp(OMRAPI.OMR_GetLastError(), (uint)SR_STRING.SR_STRING_NORMAL);
                error = new OMRCardReaderException(m, feedret);
                return false;
            }

            OMRAPI.OMR_MARK mi = new OMRAPI.OMR_MARK();

            mi.Type = 0;
            mi.Columns = (uint)Columns;
            mi.Rows = (uint)Rows;

            if (!OMRAPI.OMR_GetMarks(0, ref mi, ref data[0]))
            {
                OMRStatus getret = OMRAPI.OMR_GetStatus();
                if (getret != OMRStatus.SR_SUCCESS)
                {
                    OMRStatus status;
                    string m = GetLastErrorMessage(out status);
                    error = new OMRCardReaderException(m, status);
                    return false;
                }
                else
                    throw new OMRCardReaderException("API 錯誤，取得資料錯誤，API 確回傳狀況正常。", OMRStatus.SR_ERROR_TERM);
            }

            error = null;

            return true;
        }

        private static void ThrowLastError()
        {
            OMRStatus status;
            string msg = GetLastErrorMessage(out status);
            throw new OMRCardReaderException(msg, status);
        }

        private static string GetLastErrorMessage(out OMRStatus status)
        {
            OMRStatus result = OMRAPI.OMR_GetLastError();
            status = result;
            return OMRAPI.OMR_FormatMessageCSharp(result, (uint)SR_STRING.SR_STRING_NORMAL);
        }
    }

    public class OMRCardReaderException : Exception
    {
        public OMRCardReaderException(string msg, OMRStatus status)
            : base(msg)
        {
            Status = status;
        }

        public OMRStatus Status { get; private set; }
    }
}
