namespace VTMS.SystemManagement
{
    partial class PasswordForm
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.cancleBtn = new DevComponents.DotNetBar.ButtonX();
            this.reCurrentPwd = new VTMS.ControlLib.TextBoxExt();
            this.currentPwd = new VTMS.ControlLib.TextBoxExt();
            this.originPwd = new VTMS.ControlLib.TextBoxExt();
            this.confirmBtn = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.cancleBtn);
            this.panelEx1.Controls.Add(this.reCurrentPwd);
            this.panelEx1.Controls.Add(this.currentPwd);
            this.panelEx1.Controls.Add(this.originPwd);
            this.panelEx1.Controls.Add(this.confirmBtn);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(299, 190);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // cancleBtn
            // 
            this.cancleBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancleBtn.AutoSize = true;
            this.cancleBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancleBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancleBtn.Location = new System.Drawing.Point(28, 146);
            this.cancleBtn.Name = "cancleBtn";
            this.cancleBtn.Size = new System.Drawing.Size(75, 30);
            this.cancleBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancleBtn.TabIndex = 14;
            this.cancleBtn.Text = "取消";
            this.cancleBtn.Click += new System.EventHandler(this.cancleBtn_Click);
            // 
            // reCurrentPwd
            // 
            // 
            // 
            // 
            this.reCurrentPwd.Border.Class = "TextBoxBorder";
            this.reCurrentPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reCurrentPwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reCurrentPwd.Location = new System.Drawing.Point(106, 104);
            this.reCurrentPwd.MaxLength = 20;
            this.reCurrentPwd.Name = "reCurrentPwd";
            this.reCurrentPwd.PasswordChar = '#';
            this.reCurrentPwd.Size = new System.Drawing.Size(148, 29);
            this.reCurrentPwd.TabIndex = 3;
            // 
            // currentPwd
            // 
            // 
            // 
            // 
            this.currentPwd.Border.Class = "TextBoxBorder";
            this.currentPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.currentPwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentPwd.Location = new System.Drawing.Point(106, 61);
            this.currentPwd.MaxLength = 20;
            this.currentPwd.Name = "currentPwd";
            this.currentPwd.PasswordChar = '#';
            this.currentPwd.Size = new System.Drawing.Size(148, 29);
            this.currentPwd.TabIndex = 2;
            // 
            // originPwd
            // 
            // 
            // 
            // 
            this.originPwd.Border.Class = "TextBoxBorder";
            this.originPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.originPwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.originPwd.Location = new System.Drawing.Point(106, 21);
            this.originPwd.MaxLength = 20;
            this.originPwd.Name = "originPwd";
            this.originPwd.PasswordChar = '#';
            this.originPwd.Size = new System.Drawing.Size(148, 29);
            this.originPwd.TabIndex = 1;
            // 
            // confirmBtn
            // 
            this.confirmBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.confirmBtn.AutoSize = true;
            this.confirmBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirmBtn.Location = new System.Drawing.Point(188, 146);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 30);
            this.confirmBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.confirmBtn.TabIndex = 13;
            this.confirmBtn.Text = "确定";
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
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
            this.labelX3.Location = new System.Drawing.Point(28, 105);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(50, 24);
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "重复：";
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
            this.labelX2.Location = new System.Drawing.Point(28, 62);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(66, 24);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "新密码：";
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
            this.labelX1.Location = new System.Drawing.Point(28, 18);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(66, 24);
            this.labelX1.TabIndex = 7;
            this.labelX1.Text = "原密码：";
            // 
            // PasswordForm
            // 
            this.AcceptButton = this.confirmBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancleBtn;
            this.ClientSize = new System.Drawing.Size(299, 190);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(315, 228);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(315, 228);
            this.Name = "PasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改密码";
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX confirmBtn;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private ControlLib.TextBoxExt originPwd;
        private ControlLib.TextBoxExt reCurrentPwd;
        private ControlLib.TextBoxExt currentPwd;
        private DevComponents.DotNetBar.ButtonX cancleBtn;

    }
}