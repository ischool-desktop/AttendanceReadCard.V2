using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA;
using FISCA.Presentation;
using FISCA.Permission;

namespace AttendanceReadCard
{
    public static class Program
    {
        public const string SetupFormCoode = "出勤請假讀卡模組.出勤讀卡設定";

        public const string ReadCardFormCode = "出勤請假讀卡模組.出勤讀卡";

        [MainMethod()]
        public static void Main()
        {
            RibbonBarItemManager ribbon = FISCA.Presentation.MotherForm.RibbonBarItems;

            ribbon["學務作業", "出勤/請假讀卡"]["設定"].Image = Properties.Resources.sandglass_unlock_64;

            MenuButton button = ribbon["學務作業", "出勤/請假讀卡"]["設定"]["讀卡設定"];
            button.Enable = UserAcl.Current[SetupFormCoode].Executable;
            button.Click += delegate
            {
                new SetupForm().ShowDialog();
            };

            button = ribbon["學務作業", "出勤/請假讀卡"]["讀卡"];
            button.Image = Properties.Resources.ReadCard;
            button.Enable = UserAcl.Current[ReadCardFormCode].Executable;
            button.Click += delegate
            {
                new ReadCardForm().ShowDialog();
            };

            Catalog catalog = RoleAclSource.Instance["學務作業"]["功能按鈕"];
            catalog.Add(new RibbonFeature(SetupFormCoode, "出勤/請假讀卡設定"));
            catalog.Add(new RibbonFeature(ReadCardFormCode, "出勤/請假讀卡"));
        }

        /// <summary>
        /// 卡片上所提供的節次列表。
        /// </summary>
        public static string[] PeriodNameList = new string[] { "早修/升旗", 
                    "第一節", "第二節", "第三節", "第四節", "午休",
                    "第五節", "第六節", "第七節", "第八節", "第九節"};

        /// <summary>
        /// 卡片上所提供的假別列表。
        /// </summary>
        public static string[] LeaveNameList = new string[] { "事", 
                    "病", "喪", "公"};

        /// <summary>
        /// 卡片上的起始年度。
        /// </summary>
        public static int StartYear = 104;
    }
}
