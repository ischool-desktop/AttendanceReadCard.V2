﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA;
using FISCA.Presentation;
using FISCA.Permission;
using System.Xml.Linq;
using System.Windows.Forms;

namespace AttendanceReadCard
{
    public static class Program
    {
        public const string SetupFormCoode = "出勤讀卡模組.出勤讀卡設定";

        public const string ReadCardFormCode = "出勤讀卡模組.出勤讀卡";

        [MainMethod()]
        // 2017/11/30 羿均，修改按鈕註冊位置
        public static void Main()
        {
            RibbonBarItemManager ribbon = FISCA.Presentation.MotherForm.RibbonBarItems;

            ribbon["學務作業", "讀卡系統"]["出勤讀卡"].Image = Properties.Resources.ReadCard;
            ribbon["學務作業", "讀卡系統"]["出勤讀卡"].Size = RibbonBarButton.MenuButtonSize.Large;
            MenuButton button = ribbon["學務作業", "讀卡系統"]["出勤讀卡"];
            
            button.Enable = UserAcl.Current[ReadCardFormCode].Executable;
            button.Click += delegate
            {
                new ReadCardForm().ShowDialog();
            };

            ribbon["學務作業", "讀卡系統"]["設定"].Image = Properties.Resources.sandglass_unlock_64;
            ribbon["學務作業", "讀卡系統"]["設定"].Size = RibbonBarButton.MenuButtonSize.Medium;
            button = ribbon["學務作業", "讀卡系統"]["設定"]["出勤讀卡設定"];
            button.Enable = UserAcl.Current[SetupFormCoode].Executable;
            button.Click += delegate
            {
                new SetupForm().ShowDialog();
            };

            // 2017/12/07，羿均，新增【讀取卡片資訊】功能
            MenuButton mb = MotherForm.RibbonBarItems["學務作業", "讀卡系統"]["設定"]["讀卡解析-點名卡"];
            mb.Enable = true;
            mb.Click += delegate
            {
                new ReadCardInformation().ShowDialog();
            };

            Catalog catalog = RoleAclSource.Instance["學務作業"]["功能按鈕"];
            catalog.Add(new RibbonFeature(SetupFormCoode, "出勤讀卡設定"));
            catalog.Add(new RibbonFeature(ReadCardFormCode, "出勤讀卡"));

            // 讀取設定xml  傳入節次
            AddPeriod();
        }

        public static string[] PeriodNameList = new string[] { };

        public static void AddPeriod()
        {
            try
            {
                // 2017/11/30 羿均 ，透過config新增一個CardSettingData的欄位，再透過中央管理系統將讀卡解析設定update到該欄位
                K12.Data.Configuration.ConfigData _CardSettingData = K12.Data.School.Configuration["CardSettingData"];
                _CardSettingData.Save();

                // 讀取卡片解析
                XDocument cardSettingData = XDocument.Parse(_CardSettingData.PreviousData.OuterXml);
                XElement MappingAttendance = cardSettingData.Element("CardPositionSetting").Element("MappingAttendance");
                PeriodNameList = MappingAttendance.Descendants("Period").Select(element => element.Attribute("Value").Value).ToArray();
            }
            catch
            {
                MessageBox.Show("點名讀卡解析資料未設定，請執行讀卡解析並聯絡客服人員!");
            }
        }

        /// <summary>
        /// 卡片上所提供的假別列表。
        /// </summary>
        //public static string[] LeaveNameList = new string[] { "事", "病", "喪", "公"};

        //2016/9/2 穎驊紀錄，下面這項不會再被用到，因為每張卡片每年都有可能會改起始年度，
        //起始年度將由UI給使用者自訂

        /// <summary>
        /// 卡片上的起始年度。
        /// </summary>
        //public static int StartYear = 104;
    }
}
