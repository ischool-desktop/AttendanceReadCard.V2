namespace AttendanceReadCard
{
    partial class SetupForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvClassMap = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.chClassName = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.chCardName = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dgvPeriodMap = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.chCardPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chPeriod = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.ch_1_0 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.ch_1_1 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.ch_0_1 = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnAutoClass = new DevComponents.DotNetBar.ButtonX();
            this.btnAutoPeriod = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cboOverride = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.cboReadingCardStartYear = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodMap)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClassMap
            // 
            this.dgvClassMap.AllowUserToAddRows = false;
            this.dgvClassMap.AllowUserToDeleteRows = false;
            this.dgvClassMap.AllowUserToResizeRows = false;
            this.dgvClassMap.BackgroundColor = System.Drawing.Color.White;
            this.dgvClassMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chClassName,
            this.chCardName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClassMap.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClassMap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvClassMap.HighlightSelectedColumnHeaders = false;
            this.dgvClassMap.Location = new System.Drawing.Point(12, 38);
            this.dgvClassMap.Margin = new System.Windows.Forms.Padding(2);
            this.dgvClassMap.Name = "dgvClassMap";
            this.dgvClassMap.RowHeadersWidth = 25;
            this.dgvClassMap.RowTemplate.Height = 24;
            this.dgvClassMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvClassMap.Size = new System.Drawing.Size(283, 316);
            this.dgvClassMap.TabIndex = 1;
            this.dgvClassMap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClassMap_CellClick);
            this.dgvClassMap.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvClassMap_KeyUp);
            // 
            // chClassName
            // 
            this.chClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chClassName.DefaultCellStyle = dataGridViewCellStyle1;
            this.chClassName.DisplayMember = "Text";
            this.chClassName.DropDownHeight = 106;
            this.chClassName.DropDownWidth = 121;
            this.chClassName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chClassName.HeaderText = "班級名稱";
            this.chClassName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chClassName.IntegralHeight = false;
            this.chClassName.ItemHeight = 17;
            this.chClassName.Name = "chClassName";
            this.chClassName.ReadOnly = true;
            this.chClassName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chClassName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // chCardName
            // 
            this.chCardName.DropDownHeight = 106;
            this.chCardName.DropDownWidth = 121;
            this.chCardName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chCardName.HeaderText = "讀卡代碼";
            this.chCardName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chCardName.IntegralHeight = false;
            this.chCardName.ItemHeight = 17;
            this.chCardName.Name = "chCardName";
            this.chCardName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chCardName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(87, 21);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "班級名稱對照";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(592, 13);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(60, 21);
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "節次對照";
            this.labelX3.Visible = false;
            // 
            // dgvPeriodMap
            // 
            this.dgvPeriodMap.AllowUserToAddRows = false;
            this.dgvPeriodMap.AllowUserToDeleteRows = false;
            this.dgvPeriodMap.AllowUserToResizeRows = false;
            this.dgvPeriodMap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPeriodMap.BackgroundColor = System.Drawing.Color.White;
            this.dgvPeriodMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chCardPeriod,
            this.chPeriod,
            this.ch_1_0,
            this.ch_1_1,
            this.ch_0_1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeriodMap.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPeriodMap.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPeriodMap.HighlightSelectedColumnHeaders = false;
            this.dgvPeriodMap.Location = new System.Drawing.Point(427, 38);
            this.dgvPeriodMap.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPeriodMap.Name = "dgvPeriodMap";
            this.dgvPeriodMap.RowHeadersWidth = 25;
            this.dgvPeriodMap.RowTemplate.Height = 24;
            this.dgvPeriodMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPeriodMap.Size = new System.Drawing.Size(447, 316);
            this.dgvPeriodMap.TabIndex = 8;
            this.dgvPeriodMap.Visible = false;
            this.dgvPeriodMap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeriodMap_CellClick);
            this.dgvPeriodMap.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvPeriodMap_KeyUp);
            // 
            // chCardPeriod
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chCardPeriod.DefaultCellStyle = dataGridViewCellStyle3;
            this.chCardPeriod.HeaderText = "讀卡節次";
            this.chCardPeriod.Name = "chCardPeriod";
            this.chCardPeriod.ReadOnly = true;
            this.chCardPeriod.Width = 90;
            // 
            // chPeriod
            // 
            this.chPeriod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.chPeriod.DropDownHeight = 106;
            this.chPeriod.DropDownWidth = 121;
            this.chPeriod.FillWeight = 30F;
            this.chPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chPeriod.HeaderText = "節次";
            this.chPeriod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chPeriod.IntegralHeight = false;
            this.chPeriod.ItemHeight = 17;
            this.chPeriod.Name = "chPeriod";
            this.chPeriod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chPeriod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // ch_1_0
            // 
            this.ch_1_0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ch_1_0.DropDownHeight = 106;
            this.ch_1_0.DropDownWidth = 121;
            this.ch_1_0.FillWeight = 40F;
            this.ch_1_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ch_1_0.HeaderText = "●○對應";
            this.ch_1_0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ch_1_0.IntegralHeight = false;
            this.ch_1_0.ItemHeight = 17;
            this.ch_1_0.Name = "ch_1_0";
            this.ch_1_0.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ch_1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // ch_1_1
            // 
            this.ch_1_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ch_1_1.DropDownHeight = 106;
            this.ch_1_1.DropDownWidth = 121;
            this.ch_1_1.FillWeight = 40F;
            this.ch_1_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ch_1_1.HeaderText = " ●●對應";
            this.ch_1_1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ch_1_1.IntegralHeight = false;
            this.ch_1_1.ItemHeight = 17;
            this.ch_1_1.Name = "ch_1_1";
            this.ch_1_1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ch_1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // ch_0_1
            // 
            this.ch_0_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ch_0_1.DropDownHeight = 106;
            this.ch_0_1.DropDownWidth = 121;
            this.ch_0_1.FillWeight = 40F;
            this.ch_0_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ch_0_1.HeaderText = "○●對應";
            this.ch_0_1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ch_0_1.IntegralHeight = false;
            this.ch_0_1.ItemHeight = 17;
            this.ch_0_1.Name = "ch_0_1";
            this.ch_0_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(136, 393);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(220, 393);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "離開";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAutoClass
            // 
            this.btnAutoClass.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAutoClass.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoClass.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAutoClass.Location = new System.Drawing.Point(105, 11);
            this.btnAutoClass.Name = "btnAutoClass";
            this.btnAutoClass.Size = new System.Drawing.Size(75, 23);
            this.btnAutoClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAutoClass.TabIndex = 11;
            this.btnAutoClass.Text = "自動產生";
            this.btnAutoClass.Visible = false;
            // 
            // btnAutoPeriod
            // 
            this.btnAutoPeriod.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAutoPeriod.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoPeriod.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAutoPeriod.Location = new System.Drawing.Point(660, 12);
            this.btnAutoPeriod.Name = "btnAutoPeriod";
            this.btnAutoPeriod.Size = new System.Drawing.Size(75, 23);
            this.btnAutoPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAutoPeriod.TabIndex = 12;
            this.btnAutoPeriod.Text = "自動對照";
            this.btnAutoPeriod.Visible = false;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(12, 365);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(208, 21);
            this.labelX6.TabIndex = 13;
            this.labelX6.Text = "讀卡資料與現有資料衝突處理方式";
            // 
            // cboOverride
            // 
            this.cboOverride.DisplayMember = "Text";
            this.cboOverride.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboOverride.FormattingEnabled = true;
            this.cboOverride.ItemHeight = 19;
            this.cboOverride.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cboOverride.Location = new System.Drawing.Point(12, 392);
            this.cboOverride.Name = "cboOverride";
            this.cboOverride.Size = new System.Drawing.Size(113, 25);
            this.cboOverride.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboOverride.TabIndex = 14;
            this.cboOverride.Text = "略過讀卡資料";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "覆蓋現有資料";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "略過讀卡資料";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(591, 366);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(87, 21);
            this.labelX8.TabIndex = 17;
            this.labelX8.Text = "讀卡起始年份";
            this.labelX8.Visible = false;
            // 
            // cboReadingCardStartYear
            // 
            this.cboReadingCardStartYear.DisplayMember = "Text";
            this.cboReadingCardStartYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboReadingCardStartYear.FormattingEnabled = true;
            this.cboReadingCardStartYear.ItemHeight = 19;
            this.cboReadingCardStartYear.Location = new System.Drawing.Point(591, 391);
            this.cboReadingCardStartYear.Name = "cboReadingCardStartYear";
            this.cboReadingCardStartYear.Size = new System.Drawing.Size(88, 25);
            this.cboReadingCardStartYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboReadingCardStartYear.TabIndex = 18;
            this.cboReadingCardStartYear.Visible = false;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 427);
            this.Controls.Add(this.cboReadingCardStartYear);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.cboOverride);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.btnAutoPeriod);
            this.Controls.Add(this.btnAutoClass);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvPeriodMap);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.dgvClassMap);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SetupForm";
            this.Text = "學生出缺席讀卡設定";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvClassMap;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPeriodMap;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnAutoClass;
        private DevComponents.DotNetBar.ButtonX btnAutoPeriod;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn chClassName;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn chCardName;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboOverride;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboReadingCardStartYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCardPeriod;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn chPeriod;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn ch_1_0;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn ch_1_1;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn ch_0_1;
    }
}