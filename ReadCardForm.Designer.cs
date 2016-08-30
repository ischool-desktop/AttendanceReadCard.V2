namespace AttendanceReadCard
{
    partial class ReadCardForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.intSchoolYear = new DevComponents.Editors.IntegerInput();
            this.intSemester = new DevComponents.Editors.IntegerInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dgvAttendance = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnBeginRead = new DevComponents.DotNetBar.ButtonX();
            this.btnAbsence = new DevComponents.DotNetBar.ButtonItem();
            this.btnLeave = new DevComponents.DotNetBar.ButtonItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.intValue = new DevComponents.Editors.IntegerInput();
            this.chDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chSeatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chStudentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.intSchoolYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSemester)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intValue)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(808, 466);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "關閉";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(727, 466);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // intSchoolYear
            // 
            this.intSchoolYear.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.intSchoolYear.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intSchoolYear.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intSchoolYear.Location = new System.Drawing.Point(60, 14);
            this.intSchoolYear.MaxValue = 200;
            this.intSchoolYear.MinValue = 90;
            this.intSchoolYear.Name = "intSchoolYear";
            this.intSchoolYear.ShowUpDown = true;
            this.intSchoolYear.Size = new System.Drawing.Size(80, 25);
            this.intSchoolYear.TabIndex = 1;
            this.intSchoolYear.Value = 100;
            // 
            // intSemester
            // 
            this.intSemester.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.intSemester.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intSemester.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intSemester.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intSemester.Location = new System.Drawing.Point(215, 14);
            this.intSemester.MaxValue = 2;
            this.intSemester.MinValue = 1;
            this.intSemester.Name = "intSemester";
            this.intSemester.ShowUpDown = true;
            this.intSemester.Size = new System.Drawing.Size(80, 25);
            this.intSemester.TabIndex = 1;
            this.intSemester.Value = 1;
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
            this.labelX1.Location = new System.Drawing.Point(7, 16);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(47, 21);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "學年度";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(175, 16);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(34, 21);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "學期";
            // 
            // dgvAttendance
            // 
            this.dgvAttendance.AllowUserToAddRows = false;
            this.dgvAttendance.AllowUserToDeleteRows = false;
            this.dgvAttendance.AllowUserToResizeRows = false;
            this.dgvAttendance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAttendance.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendance.CausesValidation = false;
            this.dgvAttendance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chDateTime,
            this.chClassName,
            this.chSeatNo,
            this.chName,
            this.chStudentNumber,
            this.p0,
            this.p1,
            this.p2,
            this.p3,
            this.p4,
            this.p5,
            this.p6,
            this.p7,
            this.p8,
            this.p9,
            this.p10});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttendance.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAttendance.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvAttendance.HighlightSelectedColumnHeaders = false;
            this.dgvAttendance.Location = new System.Drawing.Point(7, 51);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.ReadOnly = true;
            this.dgvAttendance.RowHeadersWidth = 25;
            this.dgvAttendance.RowTemplate.Height = 24;
            this.dgvAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendance.Size = new System.Drawing.Size(876, 408);
            this.dgvAttendance.TabIndex = 3;
            this.dgvAttendance.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAttendance_CellFormatting);
            this.dgvAttendance.SelectionChanged += new System.EventHandler(this.dgvAttendance_SelectionChanged);
            // 
            // btnBeginRead
            // 
            this.btnBeginRead.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBeginRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBeginRead.AutoExpandOnClick = true;
            this.btnBeginRead.BackColor = System.Drawing.Color.Transparent;
            this.btnBeginRead.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBeginRead.Location = new System.Drawing.Point(808, 15);
            this.btnBeginRead.Name = "btnBeginRead";
            this.btnBeginRead.Size = new System.Drawing.Size(75, 23);
            this.btnBeginRead.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBeginRead.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAbsence,
            this.btnLeave});
            this.btnBeginRead.TabIndex = 4;
            this.btnBeginRead.Text = "開始讀卡";
            // 
            // btnAbsence
            // 
            this.btnAbsence.GlobalItem = false;
            this.btnAbsence.Name = "btnAbsence";
            this.btnAbsence.Text = "點名卡";
            this.btnAbsence.Click += new System.EventHandler(this.btnAbsence_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.GlobalItem = false;
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Text = "請假卡";
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
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
            this.labelX3.Location = new System.Drawing.Point(642, 16);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(74, 21);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "濃淡辨識度";
            // 
            // intValue
            // 
            this.intValue.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.intValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intValue.Location = new System.Drawing.Point(722, 14);
            this.intValue.MaxValue = 12;
            this.intValue.MinValue = 1;
            this.intValue.Name = "intValue";
            this.intValue.ShowUpDown = true;
            this.intValue.Size = new System.Drawing.Size(80, 25);
            this.intValue.TabIndex = 5;
            this.intValue.Value = 5;
            // 
            // chDateTime
            // 
            this.chDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.chDateTime.DataPropertyName = "DateTime";
            this.chDateTime.HeaderText = "日期";
            this.chDateTime.Name = "chDateTime";
            this.chDateTime.ReadOnly = true;
            this.chDateTime.Width = 59;
            // 
            // chClassName
            // 
            this.chClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.chClassName.DataPropertyName = "ClassName";
            this.chClassName.HeaderText = "班級";
            this.chClassName.Name = "chClassName";
            this.chClassName.ReadOnly = true;
            this.chClassName.Width = 59;
            // 
            // chSeatNo
            // 
            this.chSeatNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.chSeatNo.DataPropertyName = "SeatNo";
            this.chSeatNo.HeaderText = "座號";
            this.chSeatNo.Name = "chSeatNo";
            this.chSeatNo.ReadOnly = true;
            this.chSeatNo.Width = 59;
            // 
            // chName
            // 
            this.chName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.chName.DataPropertyName = "Name";
            this.chName.HeaderText = "姓名";
            this.chName.Name = "chName";
            this.chName.ReadOnly = true;
            this.chName.Width = 59;
            // 
            // chStudentNumber
            // 
            this.chStudentNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.chStudentNumber.DataPropertyName = "StudentNumber";
            this.chStudentNumber.HeaderText = "學號";
            this.chStudentNumber.Name = "chStudentNumber";
            this.chStudentNumber.ReadOnly = true;
            this.chStudentNumber.Width = 59;
            // 
            // p0
            // 
            this.p0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.p0.DataPropertyName = "Period0";
            this.p0.HeaderText = "早/升";
            this.p0.Name = "p0";
            this.p0.ReadOnly = true;
            this.p0.Width = 64;
            // 
            // p1
            // 
            this.p1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.p1.DataPropertyName = "Period1";
            this.p1.HeaderText = "一";
            this.p1.Name = "p1";
            this.p1.ReadOnly = true;
            this.p1.Width = 46;
            // 
            // p2
            // 
            this.p2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.p2.DataPropertyName = "Period2";
            this.p2.HeaderText = "二";
            this.p2.Name = "p2";
            this.p2.ReadOnly = true;
            this.p2.Width = 46;
            // 
            // p3
            // 
            this.p3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.p3.DataPropertyName = "Period3";
            this.p3.HeaderText = "三";
            this.p3.Name = "p3";
            this.p3.ReadOnly = true;
            this.p3.Width = 46;
            // 
            // p4
            // 
            this.p4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.p4.DataPropertyName = "Period4";
            this.p4.HeaderText = "四";
            this.p4.Name = "p4";
            this.p4.ReadOnly = true;
            this.p4.Width = 46;
            // 
            // p5
            // 
            this.p5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.p5.DataPropertyName = "Period5";
            this.p5.HeaderText = "午休";
            this.p5.Name = "p5";
            this.p5.ReadOnly = true;
            this.p5.Width = 59;
            // 
            // p6
            // 
            this.p6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.p6.DataPropertyName = "Period6";
            this.p6.HeaderText = "五";
            this.p6.Name = "p6";
            this.p6.ReadOnly = true;
            this.p6.Width = 46;
            // 
            // p7
            // 
            this.p7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.p7.DataPropertyName = "Period7";
            this.p7.HeaderText = "六";
            this.p7.Name = "p7";
            this.p7.ReadOnly = true;
            this.p7.Width = 46;
            // 
            // p8
            // 
            this.p8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.p8.DataPropertyName = "Period8";
            this.p8.HeaderText = "七";
            this.p8.Name = "p8";
            this.p8.ReadOnly = true;
            this.p8.Width = 46;
            // 
            // p9
            // 
            this.p9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.p9.DataPropertyName = "Period9";
            this.p9.HeaderText = "八";
            this.p9.Name = "p9";
            this.p9.ReadOnly = true;
            this.p9.Width = 46;
            // 
            // p10
            // 
            this.p10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.p10.DataPropertyName = "Period10";
            this.p10.HeaderText = "九";
            this.p10.Name = "p10";
            this.p10.ReadOnly = true;
            this.p10.Width = 46;
            // 
            // ReadCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(895, 499);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.intValue);
            this.Controls.Add(this.btnBeginRead);
            this.Controls.Add(this.dgvAttendance);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.intSemester);
            this.Controls.Add(this.intSchoolYear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.Name = "ReadCardForm";
            this.Text = "/";
            this.Load += new System.EventHandler(this.ReadCardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.intSchoolYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSemester)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.Editors.IntegerInput intSchoolYear;
        private DevComponents.Editors.IntegerInput intSemester;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvAttendance;
		private DevComponents.DotNetBar.ButtonX btnBeginRead;
		private DevComponents.DotNetBar.ButtonItem btnAbsence;
        private DevComponents.DotNetBar.ButtonItem btnLeave;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.IntegerInput intValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn chClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chSeatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chStudentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn p0;
        private System.Windows.Forms.DataGridViewTextBoxColumn p1;
        private System.Windows.Forms.DataGridViewTextBoxColumn p2;
        private System.Windows.Forms.DataGridViewTextBoxColumn p3;
        private System.Windows.Forms.DataGridViewTextBoxColumn p4;
        private System.Windows.Forms.DataGridViewTextBoxColumn p5;
        private System.Windows.Forms.DataGridViewTextBoxColumn p6;
        private System.Windows.Forms.DataGridViewTextBoxColumn p7;
        private System.Windows.Forms.DataGridViewTextBoxColumn p8;
        private System.Windows.Forms.DataGridViewTextBoxColumn p9;
        private System.Windows.Forms.DataGridViewTextBoxColumn p10;
    }
}