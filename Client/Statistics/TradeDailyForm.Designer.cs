﻿namespace VTMS.Statistics
{
    partial class TradeDailyForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.caculate = new DevComponents.DotNetBar.ButtonX();
            this.dailyCondition = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.endDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.startDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.totalMoney = new DevComponents.DotNetBar.LabelX();
            this.totalCars = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.dataGridView = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.SaveDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDate)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.caculate);
            this.panelEx1.Controls.Add(this.dailyCondition);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.endDate);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.startDate);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1008, 44);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 3;
            // 
            // caculate
            // 
            this.caculate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.caculate.AutoSize = true;
            this.caculate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.caculate.Location = new System.Drawing.Point(780, 7);
            this.caculate.Name = "caculate";
            this.caculate.Size = new System.Drawing.Size(75, 30);
            this.caculate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.caculate.TabIndex = 7;
            this.caculate.Text = "统计";
            this.caculate.Click += new System.EventHandler(this.caculate_Click);
            // 
            // dailyCondition
            // 
            this.dailyCondition.DisplayMember = "Text";
            this.dailyCondition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dailyCondition.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dailyCondition.FormattingEnabled = true;
            this.dailyCondition.ItemHeight = 23;
            this.dailyCondition.Location = new System.Drawing.Point(542, 8);
            this.dailyCondition.Name = "dailyCondition";
            this.dailyCondition.Size = new System.Drawing.Size(121, 29);
            this.dailyCondition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dailyCondition.TabIndex = 6;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(449, 9);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(90, 26);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "统计内容：";
            // 
            // endDate
            // 
            this.endDate.AutoSelectDate = true;
            // 
            // 
            // 
            this.endDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.endDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.endDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.endDate.ButtonDropDown.Visible = true;
            this.endDate.CustomFormat = "yyyy/MM/dd";
            this.endDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.endDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.endDate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.endDate.IsPopupCalendarOpen = false;
            this.endDate.Location = new System.Drawing.Point(276, 8);
            // 
            // 
            // 
            this.endDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.endDate.MonthCalendar.BackgroundStyle.Class = "";
            this.endDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.endDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.endDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.endDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.endDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.endDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.endDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.endDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.endDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.endDate.MonthCalendar.DisplayMonth = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.endDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.endDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.endDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.endDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.endDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.endDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.endDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.endDate.MonthCalendar.TodayButtonVisible = true;
            this.endDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(145, 29);
            this.endDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.endDate.TabIndex = 4;
            this.endDate.Value = new System.DateTime(2013, 1, 25, 16, 41, 56, 0);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(251, 9);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(24, 26);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "～";
            // 
            // startDate
            // 
            this.startDate.AutoSelectDate = true;
            // 
            // 
            // 
            this.startDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.startDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.startDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.startDate.ButtonDropDown.Visible = true;
            this.startDate.CustomFormat = "yyyy/MM/dd";
            this.startDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.startDate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.startDate.IsPopupCalendarOpen = false;
            this.startDate.Location = new System.Drawing.Point(106, 8);
            // 
            // 
            // 
            this.startDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.startDate.MonthCalendar.BackgroundStyle.Class = "";
            this.startDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.startDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.startDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.startDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.startDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.startDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.startDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.startDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.startDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.startDate.MonthCalendar.DisplayMonth = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.startDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.startDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.startDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.startDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.startDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.startDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.startDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.startDate.MonthCalendar.TodayButtonVisible = true;
            this.startDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(145, 29);
            this.startDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.startDate.TabIndex = 1;
            this.startDate.Value = new System.DateTime(2013, 1, 25, 16, 41, 30, 0);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(12, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(90, 26);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "日期范围：";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.totalMoney);
            this.panelEx2.Controls.Add(this.totalCars);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.labelX6);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 571);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1008, 41);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 5;
            // 
            // totalMoney
            // 
            this.totalMoney.AutoSize = true;
            // 
            // 
            // 
            this.totalMoney.BackgroundStyle.Class = "";
            this.totalMoney.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.totalMoney.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.totalMoney.Location = new System.Drawing.Point(803, 7);
            this.totalMoney.Name = "totalMoney";
            this.totalMoney.Size = new System.Drawing.Size(47, 26);
            this.totalMoney.TabIndex = 7;
            this.totalMoney.Text = "(元）";
            // 
            // totalCars
            // 
            this.totalCars.AutoSize = true;
            // 
            // 
            // 
            this.totalCars.BackgroundStyle.Class = "";
            this.totalCars.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.totalCars.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.totalCars.Location = new System.Drawing.Point(494, 7);
            this.totalCars.Name = "totalCars";
            this.totalCars.Size = new System.Drawing.Size(37, 26);
            this.totalCars.TabIndex = 6;
            this.totalCars.Text = "(辆)";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(707, 7);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(90, 26);
            this.labelX4.TabIndex = 5;
            this.labelX4.Text = "交易金额：";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX6.Location = new System.Drawing.Point(385, 7);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(90, 26);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "交易辆数：";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaveDateColumn,
            this.Column1,
            this.RegisterColumn,
            this.ActualColumn,
            this.CompanyColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridView.Location = new System.Drawing.Point(0, 44);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1008, 527);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView_RowPostPaint);
            // 
            // SaveDateColumn
            // 
            this.SaveDateColumn.DataPropertyName = "SaveDate";
            this.SaveDateColumn.HeaderText = "日期";
            this.SaveDateColumn.Name = "SaveDateColumn";
            this.SaveDateColumn.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Serial";
            this.Column1.HeaderText = "流水号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // RegisterColumn
            // 
            this.RegisterColumn.DataPropertyName = "License";
            this.RegisterColumn.FillWeight = 80F;
            this.RegisterColumn.HeaderText = "车牌号";
            this.RegisterColumn.Name = "RegisterColumn";
            this.RegisterColumn.ReadOnly = true;
            // 
            // ActualColumn
            // 
            this.ActualColumn.DataPropertyName = "Actual";
            this.ActualColumn.HeaderText = "实收金额";
            this.ActualColumn.Name = "ActualColumn";
            this.ActualColumn.ReadOnly = true;
            // 
            // CompanyColumn
            // 
            this.CompanyColumn.DataPropertyName = "Company";
            this.CompanyColumn.FillWeight = 120F;
            this.CompanyColumn.HeaderText = "经济公司";
            this.CompanyColumn.Name = "CompanyColumn";
            this.CompanyColumn.ReadOnly = true;
            // 
            // TradeDailyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 612);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Name = "TradeDailyForm";
            this.Text = "交易日统计";
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDate)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX caculate;
        private DevComponents.DotNetBar.Controls.ComboBoxEx dailyCondition;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput endDate;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput startDate;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.LabelX totalMoney;
        private DevComponents.DotNetBar.LabelX totalCars;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaveDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyColumn;
    }
}