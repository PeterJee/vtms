using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using VTMS.Common;
using VTMS.Access;
namespace VTMS.SystemManagement
{
    public partial class PasswordForm : Office2007Form
    {
        ErrorProvider ep = new ErrorProvider();
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            this.ValidateChildren(ValidationConstraints.Enabled & ValidationConstraints.TabStop & ValidationConstraints.Selectable);
            if (!VTMS.ControlLib.ValidatorManager.ValidateControls(this))
            {
                MessageBox.Show("控件内容不合法");
                return;
            }
            if (this.currentPwd.Text.Equals(this.reCurrentPwd.Text))
            {
                ep.Clear();
                if (Utilities.Md5Encrypt(this.originPwd.Text).Equals(LoginForm.user.Password))
                {
                    LoginForm.user.Password = Utilities.Md5Encrypt(this.reCurrentPwd.Text);
                    UsersDao.Update(LoginForm.user);
                    MessageUtil.ShowTips("密码已经更新成功，下次登录时将生效。");
                    this.Close();
                }
                else
                {
                    ep.SetError(this.originPwd, "密码不正确");
                    this.originPwd.SelectAll();
                }
            }
            else
            {
                ep.SetError(this.reCurrentPwd, "两次输入的密码不一致");
                this.reCurrentPwd.SelectAll();
            }
        }

        private void cancleBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
