namespace VTMS.CarTradeItems
{
    partial class SearchForm
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
            this.customerName = new VTMS.ControlLib.TextBoxExt();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.serialSearch = new VTMS.ControlLib.TextBoxExt();
            this.license = new VTMS.ControlLib.TextBoxExt();
            this.searchBtn = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.customerId = new VTMS.ControlLib.TextBoxExt();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dataGridView = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.SerialColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.OriginId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.customerName);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.serialSearch);
            this.panelEx1.Controls.Add(this.license);
            this.panelEx1.Controls.Add(this.searchBtn);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.customerId);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(945, 51);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // customerName
            // 
            // 
            // 
            // 
            this.customerName.Border.Class = "TextBoxBorder";
            this.customerName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.customerName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerName.Location = new System.Drawing.Point(278, 15);
            this.customerName.Name = "customerName";
            this.customerName.NotNull = false;
            this.customerName.Size = new System.Drawing.Size(109, 25);
            this.customerName.TabIndex = 14;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(198, 17);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(74, 21);
            this.labelX5.TabIndex = 13;
            this.labelX5.Text = "车主姓名：";
            // 
            // serialSearch
            // 
            // 
            // 
            // 
            this.serialSearch.Border.Class = "TextBoxBorder";
            this.serialSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.serialSearch.ControlType = VTMS.ControlLib.TextBoxExt.RegexType.Number;
            this.serialSearch.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialSearch.Location = new System.Drawing.Point(74, 15);
            this.serialSearch.MaxLength = 11;
            this.serialSearch.Name = "serialSearch";
            this.serialSearch.NotNull = false;
            this.serialSearch.Size = new System.Drawing.Size(118, 25);
            this.serialSearch.TabIndex = 9;
            // 
            // license
            // 
            // 
            // 
            // 
            this.license.Border.Class = "TextBoxBorder";
            this.license.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.license.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.license.ControlType = VTMS.ControlLib.TextBoxExt.RegexType.MixChar;
            this.license.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.license.Location = new System.Drawing.Point(764, 15);
            this.license.MaxLength = 5;
            this.license.Name = "license";
            this.license.NotNull = false;
            this.license.Size = new System.Drawing.Size(67, 25);
            this.license.TabIndex = 11;
            // 
            // searchBtn
            // 
            this.searchBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.searchBtn.AutoSize = true;
            this.searchBtn.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.Location = new System.Drawing.Point(848, 15);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 25);
            this.searchBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.searchBtn.TabIndex = 12;
            this.searchBtn.Text = "检索";
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(732, 17);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(29, 21);
            this.labelX4.TabIndex = 5;
            this.labelX4.Text = "辽B";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(656, 17);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(74, 21);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "车辆号牌：";
            // 
            // customerId
            // 
            // 
            // 
            // 
            this.customerId.Border.Class = "TextBoxBorder";
            this.customerId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.customerId.ControlType = VTMS.ControlLib.TextBoxExt.RegexType.MixChar;
            this.customerId.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerId.Location = new System.Drawing.Point(496, 15);
            this.customerId.Name = "customerId";
            this.customerId.NotNull = false;
            this.customerId.Size = new System.Drawing.Size(147, 25);
            this.customerId.TabIndex = 10;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(393, 17);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(101, 21);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "车主证件号码：";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(12, 17);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 21);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "流水号：";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialColumn,
            this.OriginId,
            this.OriginName,
            this.CurrentId,
            this.CurrentName,
            this.VehicleType,
            this.Column7,
            this.Column8});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridView.Location = new System.Drawing.Point(0, 51);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(945, 476);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView_RowPostPaint);
            // 
            // SerialColumn
            // 
            this.SerialColumn.DataPropertyName = "Serial";
            this.SerialColumn.FillWeight = 80F;
            this.SerialColumn.HeaderText = "流水号";
            this.SerialColumn.Name = "SerialColumn";
            this.SerialColumn.ReadOnly = true;
            // 
            // OriginId
            // 
            this.OriginId.DataPropertyName = "OriginId";
            this.OriginId.FillWeight = 150F;
            this.OriginId.HeaderText = "原车主证件号码";
            this.OriginId.Name = "OriginId";
            this.OriginId.ReadOnly = true;
            this.OriginId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // OriginName
            // 
            this.OriginName.DataPropertyName = "OriginName";
            this.OriginName.HeaderText = "原车主";
            this.OriginName.Name = "OriginName";
            this.OriginName.ReadOnly = true;
            // 
            // CurrentId
            // 
            this.CurrentId.DataPropertyName = "CurrentId";
            this.CurrentId.FillWeight = 150F;
            this.CurrentId.HeaderText = "新车主证件号码";
            this.CurrentId.Name = "CurrentId";
            this.CurrentId.ReadOnly = true;
            // 
            // CurrentName
            // 
            this.CurrentName.DataPropertyName = "CurrentName";
            this.CurrentName.HeaderText = "新车主";
            this.CurrentName.Name = "CurrentName";
            this.CurrentName.ReadOnly = true;
            // 
            // VehicleType
            // 
            this.VehicleType.DataPropertyName = "VehicleType";
            this.VehicleType.FillWeight = 120F;
            this.VehicleType.HeaderText = "车辆类型";
            this.VehicleType.Name = "VehicleType";
            this.VehicleType.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "License";
            this.Column7.FillWeight = 80F;
            this.Column7.HeaderText = "车辆号牌";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Brand";
            this.Column8.FillWeight = 120F;
            this.Column8.HeaderText = "厂牌";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // SearchForm
            // 
            this.AcceptButton = this.searchBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 527);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelEx1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(861, 470);
            this.Name = "SearchForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "检索";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private ControlLib.TextBoxExt customerId;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX searchBtn;
        private ControlLib.TextBoxExt license;
        private ControlLib.TextBoxExt serialSearch;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridView;
        private ControlLib.TextBoxExt customerName;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.DataGridViewLinkColumn SerialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}