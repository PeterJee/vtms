namespace VTMS.SystemManagement
{
    partial class UsersForm
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
            this.dataGridView = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.UsersId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsersName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsersEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsersIsactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.advTree1 = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.activeBtn = new DevComponents.DotNetBar.ButtonX();
            this.resetPwdBtn = new DevComponents.DotNetBar.ButtonX();
            this.clearBtn = new DevComponents.DotNetBar.ButtonX();
            this.delBtn = new DevComponents.DotNetBar.ButtonX();
            this.saveBtn = new DevComponents.DotNetBar.ButtonX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.userName = new VTMS.ControlLib.TextBoxExt();
            this.userEmail = new VTMS.ControlLib.TextBoxExt();
            this.userId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label = new DevComponents.DotNetBar.LabelX();
            this.lable2 = new DevComponents.DotNetBar.LabelX();
            this.lable1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).BeginInit();
            this.panelEx4.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.dataGridView);
            this.panelEx1.Controls.Add(this.panelEx2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(923, 554);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UsersId,
            this.UsersName,
            this.UsersEmail,
            this.UsersIsactive});
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
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(472, 554);
            this.dataGridView.TabIndex = 102;
            this.dataGridView.TabStop = false;
            this.dataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_RowHeaderMouseClick);
            // 
            // UsersId
            // 
            this.UsersId.DataPropertyName = "UsersId";
            this.UsersId.FillWeight = 80F;
            this.UsersId.HeaderText = "帐号";
            this.UsersId.Name = "UsersId";
            this.UsersId.ReadOnly = true;
            // 
            // UsersName
            // 
            this.UsersName.DataPropertyName = "UsersName";
            this.UsersName.FillWeight = 110F;
            this.UsersName.HeaderText = "姓名";
            this.UsersName.Name = "UsersName";
            this.UsersName.ReadOnly = true;
            // 
            // UsersEmail
            // 
            this.UsersEmail.DataPropertyName = "UsersEmail";
            this.UsersEmail.FillWeight = 160F;
            this.UsersEmail.HeaderText = "邮箱";
            this.UsersEmail.Name = "UsersEmail";
            this.UsersEmail.ReadOnly = true;
            // 
            // UsersIsactive
            // 
            this.UsersIsactive.DataPropertyName = "UsersIsactive";
            this.UsersIsactive.FillWeight = 80F;
            this.UsersIsactive.HeaderText = "激活";
            this.UsersIsactive.Name = "UsersIsactive";
            this.UsersIsactive.ReadOnly = true;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.advTree1);
            this.panelEx2.Controls.Add(this.panelEx4);
            this.panelEx2.Controls.Add(this.panelEx3);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEx2.Location = new System.Drawing.Point(472, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(451, 554);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 101;
            // 
            // advTree1
            // 
            this.advTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree1.AllowDrop = true;
            this.advTree1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree1.Location = new System.Drawing.Point(0, 82);
            this.advTree1.Name = "advTree1";
            this.advTree1.NodesConnector = this.nodeConnector1;
            this.advTree1.NodeStyle = this.elementStyle1;
            this.advTree1.PathSeparator = ";";
            this.advTree1.Size = new System.Drawing.Size(451, 411);
            this.advTree1.Styles.Add(this.elementStyle1);
            this.advTree1.TabIndex = 3;
            this.advTree1.Text = "advTree1";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.Class = "";
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.activeBtn);
            this.panelEx4.Controls.Add(this.resetPwdBtn);
            this.panelEx4.Controls.Add(this.clearBtn);
            this.panelEx4.Controls.Add(this.delBtn);
            this.panelEx4.Controls.Add(this.saveBtn);
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx4.Location = new System.Drawing.Point(0, 493);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(451, 61);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 2;
            // 
            // activeBtn
            // 
            this.activeBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.activeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.activeBtn.AutoSize = true;
            this.activeBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.activeBtn.Location = new System.Drawing.Point(234, 17);
            this.activeBtn.Name = "activeBtn";
            this.activeBtn.Size = new System.Drawing.Size(75, 30);
            this.activeBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.activeBtn.TabIndex = 13;
            this.activeBtn.Text = "激活";
            this.activeBtn.Click += new System.EventHandler(this.activeBtn_Click);
            // 
            // resetPwdBtn
            // 
            this.resetPwdBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.resetPwdBtn.AutoSize = true;
            this.resetPwdBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resetPwdBtn.Location = new System.Drawing.Point(127, 17);
            this.resetPwdBtn.Name = "resetPwdBtn";
            this.resetPwdBtn.Size = new System.Drawing.Size(78, 30);
            this.resetPwdBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.resetPwdBtn.TabIndex = 12;
            this.resetPwdBtn.Text = "重置密码";
            this.resetPwdBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.clearBtn.AutoSize = true;
            this.clearBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clearBtn.Location = new System.Drawing.Point(26, 17);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 30);
            this.clearBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.clearBtn.TabIndex = 11;
            this.clearBtn.Text = "清空";
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.delBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delBtn.AutoSize = true;
            this.delBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.delBtn.Location = new System.Drawing.Point(234, 17);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(75, 30);
            this.delBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.delBtn.TabIndex = 10;
            this.delBtn.Text = "删除";
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.AutoSize = true;
            this.saveBtn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveBtn.Location = new System.Drawing.Point(354, 17);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 30);
            this.saveBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "保存";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.userName);
            this.panelEx3.Controls.Add(this.userEmail);
            this.panelEx3.Controls.Add(this.userId);
            this.panelEx3.Controls.Add(this.label);
            this.panelEx3.Controls.Add(this.lable2);
            this.panelEx3.Controls.Add(this.lable1);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(451, 82);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 0;
            // 
            // userName
            // 
            // 
            // 
            // 
            this.userName.Border.Class = "TextBoxBorder";
            this.userName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.userName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userName.Location = new System.Drawing.Point(238, 9);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(103, 29);
            this.userName.TabIndex = 2;
            // 
            // userEmail
            // 
            // 
            // 
            // 
            this.userEmail.Border.Class = "TextBoxBorder";
            this.userEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.userEmail.ControlType = VTMS.ControlLib.TextBoxExt.RegexType.Email;
            this.userEmail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userEmail.Location = new System.Drawing.Point(75, 44);
            this.userEmail.Name = "userEmail";
            this.userEmail.Size = new System.Drawing.Size(266, 29);
            this.userEmail.TabIndex = 3;
            // 
            // userId
            // 
            // 
            // 
            // 
            this.userId.Border.Class = "TextBoxBorder";
            this.userId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.userId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userId.Location = new System.Drawing.Point(75, 9);
            this.userId.Name = "userId";
            this.userId.ReadOnly = true;
            this.userId.Size = new System.Drawing.Size(82, 29);
            this.userId.TabIndex = 1;
            this.userId.Leave += new System.EventHandler(this.userId_Leave);
            // 
            // label
            // 
            this.label.AutoSize = true;
            // 
            // 
            // 
            this.label.BackgroundStyle.Class = "";
            this.label.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.label.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label.Location = new System.Drawing.Point(14, 11);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(57, 26);
            this.label.TabIndex = 5;
            this.label.Text = "帐号：";
            // 
            // lable2
            // 
            this.lable2.AutoSize = true;
            // 
            // 
            // 
            this.lable2.BackgroundStyle.Class = "";
            this.lable2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lable2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable2.Location = new System.Drawing.Point(14, 46);
            this.lable2.Name = "lable2";
            this.lable2.Size = new System.Drawing.Size(57, 26);
            this.lable2.TabIndex = 2;
            this.lable2.Text = "邮箱：";
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            // 
            // 
            // 
            this.lable1.BackgroundStyle.Class = "";
            this.lable1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lable1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable1.Location = new System.Drawing.Point(176, 11);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(57, 26);
            this.lable1.TabIndex = 0;
            this.lable1.Text = "姓名：";
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 554);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "UsersForm";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree1)).EndInit();
            this.panelEx4.ResumeLayout(false);
            this.panelEx4.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.panelEx3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsersId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsersName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsersEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsersIsactive;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.AdvTree.AdvTree advTree1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.ButtonX activeBtn;
        private DevComponents.DotNetBar.ButtonX resetPwdBtn;
        private DevComponents.DotNetBar.ButtonX clearBtn;
        private DevComponents.DotNetBar.ButtonX delBtn;
        private DevComponents.DotNetBar.ButtonX saveBtn;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private ControlLib.TextBoxExt userName;
        private ControlLib.TextBoxExt userEmail;
        private DevComponents.DotNetBar.Controls.TextBoxX userId;
        private DevComponents.DotNetBar.LabelX label;
        private DevComponents.DotNetBar.LabelX lable2;
        private DevComponents.DotNetBar.LabelX lable1;
    }
}