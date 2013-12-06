using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Configuration;
using VTMS.ControlLib;
using VTMS.Model.Entities;
using VTMS.Access;
using VTMS.Common;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;
using VTMS.Properties;

namespace VTMS
{
    public partial class LoginForm : Office2007Form
    {
        Settings settings = Settings.Default;
        public static Users user;
        public LoginForm()
        {
            InitializeComponent();

            LoadConfig();
        }

        #region 加载用户登录信息
        /// <summary>
        /// 加载配置信息
        /// </summary>
        private void LoadConfig()
        {
            userId.Text = settings.UserId;
            password.Text = Utilities.Base64Dencrypt(settings.Password);

            server.Text = settings.ServerUrl;
            pwdCBox.Checked = settings.PwdCBox;

            this.styleManager.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), settings.Theme);
        }
        #endregion

        #region 验证密码，取得用户权限
        /// <summary>
        /// 检查用户名密码,取得用户信息
        /// </summary>
        /// <returns></returns>
        private bool CheckPrivilege()
        {
            try
            {
                //取得用户信息
                if(user == null)
                    user = UsersDao.GetById(this.userId.Text);
            }
            catch(Exception e)
            {
                return false;
            }

            //验证密码
            string pwd = Utilities.Md5Encrypt(this.password.Text);
            if (LoginForm.user != null)
            {
                if (!user.UsersIsactive)
                {
                    MessageBox.Show("用户已锁定，请联系管理员重新激活！");
                    return false;
                }
                if (user.Password.Equals(Utilities.Md5Encrypt(this.password.Text)))
                {
                    LoginForm.user.LoginDate = VehicleDao.GetCurrentDate();
                    LoginForm.user.LoginServer = server.Text;
                    return true;
                }
                else
                {
                    MessageBox.Show("密码错误，请重试！");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("用户名不存在！");
                this.userName.Text = "";
            }
            return false;
        }
        #endregion

        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren(ValidationConstraints.Enabled & ValidationConstraints.TabStop & ValidationConstraints.Selectable))
            {
                MessageBox.Show("控件内容不合法");
                return;
            }
            SaveLoginInfo();
            if (CheckPrivilege())
            {
                MainForm mainForm = new MainForm();
                this.Hide();
                if (mainForm.ShowDialog() != DialogResult.OK)
                    this.Close();
            }
        }

        /// <summary>
        /// 保存登录信息
        /// </summary>
        private void SaveLoginInfo()
        {
            settings.UserId = userId.Text;

            if (pwdCBox.Checked)
            {
                settings.PwdCBox = pwdCBox.Checked;

                settings.Password = Utilities.Base64Encrypt(password.Text);
            }
            else
            {
                settings.PwdCBox = pwdCBox.Checked;

                settings.Password = "";
            }

            settings.ServerUrl = server.Text;

            settings.Save();
        }
        
        /// <summary>
        /// 取消关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.userId.Text))
                return;
            if (string.IsNullOrWhiteSpace(this.server.Text))
            {
                return;
            }
            user = UsersDao.GetById(this.userId.Text);
            if (user != null)
            {
                this.userName.Text = user.UsersName;
            }
            else
            {
                MessageBox.Show("用户名不存在！");
                this.userName.Text = "";
            }
        }
    }
}
