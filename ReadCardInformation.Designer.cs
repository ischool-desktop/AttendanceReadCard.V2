namespace AttendanceReadCard
{
    partial class ReadCardInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.ExitBtn = new DevComponents.DotNetBar.ButtonX();
            this.ExportCardDatabtn = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Location = new System.Drawing.Point(12, 12);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(318, 121);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "讀卡解析";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(297, 49);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "*注意事項:\r\n為了能夠正確的解析卡片，\r\n請將卡紙上每一列第一個圓圈塗滿";
            // 
            // ExitBtn
            // 
            this.ExitBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ExitBtn.BackColor = System.Drawing.Color.Transparent;
            this.ExitBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ExitBtn.Location = new System.Drawing.Point(255, 146);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 23);
            this.ExitBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ExitBtn.TabIndex = 2;
            this.ExitBtn.Text = "離開";
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ExportCardDatabtn
            // 
            this.ExportCardDatabtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ExportCardDatabtn.BackColor = System.Drawing.Color.Transparent;
            this.ExportCardDatabtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ExportCardDatabtn.Location = new System.Drawing.Point(118, 146);
            this.ExportCardDatabtn.Name = "ExportCardDatabtn";
            this.ExportCardDatabtn.Size = new System.Drawing.Size(106, 23);
            this.ExportCardDatabtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ExportCardDatabtn.TabIndex = 3;
            this.ExportCardDatabtn.Text = "匯出讀卡解析";
            this.ExportCardDatabtn.Click += new System.EventHandler(this.ExportCardDatabtn_Click);
            // 
            // ReadCardInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 178);
            this.Controls.Add(this.ExportCardDatabtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.Name = "ReadCardInformation";
            this.Text = "讀取卡片資訊";
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX ExitBtn;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX ExportCardDatabtn;
    }
}