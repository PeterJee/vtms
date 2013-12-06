using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Configuration;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;
using VTMS.Common;
using VTMS.Model.Entities;
using VTMS.Access;
using DevComponents.AdvTree;
namespace VTMS.SystemManagement
{
    public partial class UsersForm : Office2007Form
    {
        Dictionary<Node, List<Node>> list = new Dictionary<Node, List<Node>>();
        Users user;

        public UsersForm()
        {
            InitializeComponent();
            this.dataGridView.AutoGenerateColumns = false;
        }

        #region 数据列表头点击
        /// <summary>
        /// 点击列表头时，数据自动填充
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dataGridView.Rows.Count > 0)
            {
                DataGridViewRow currentRow = this.dataGridView.Rows[e.RowIndex];
                this.userId.Text = currentRow.Cells["UsersId"].Value.ToString();
                this.userName.Text = currentRow.Cells["UsersName"].Value.ToString();
                this.userEmail.Text = currentRow.Cells["UsersEmail"].Value.ToString();

                user = UsersDao.GetById(this.userId.Text);

                SetPrivilege();

                if (user.UsersIsactive)
                {
                    this.delBtn.Visible = true;
                    this.activeBtn.Visible = false;
                    this.resetPwdBtn.Enabled = true;
                    this.saveBtn.Enabled = true;
                }
                else
                {
                    this.delBtn.Visible = false;
                    this.activeBtn.Visible = true;
                    this.resetPwdBtn.Enabled = false;
                    this.saveBtn.Enabled = false;
                }
            }
        }
        #endregion

        #region 界面信息初始化
        /// <summary>
        /// 界面信息初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsersForm_Load(object sender, EventArgs e)
        {
            Dictionary<RibbonBar, Dictionary<string, string>> controls = MainForm.GetControls();
            foreach (KeyValuePair<RibbonBar, Dictionary<string, string>> kv in controls)
            {
                Node parent = new Node();
                parent.NodeClick += new EventHandler(parent_NodeClick);
                parent.NodeDoubleClick += new EventHandler(parent_NodeClick);
                parent.Expanded = true;
                parent.CheckBoxVisible = true;
                parent.Text = kv.Key.Text;
                parent.Name = kv.Key.Name;

                List<Node> childList = new List<Node>();
                foreach (KeyValuePair<string, string> childKV in kv.Value)
                {
                    Node child = new Node();
                    child.CheckBoxVisible = true;
                    child.Name = childKV.Key;
                    child.Text = childKV.Value;
                    parent.Nodes.Add(child);
                    
                    childList.Add(child);
                }
                list.Add(parent, childList);
                this.advTree1.Nodes.Add(parent);
            }
            LoadGridView();

            this.resetPwdBtn.Enabled = false;
            this.delBtn.Visible = false;
            this.activeBtn.Visible = false;
            this.saveBtn.Enabled = false;

            this.userId.Focus();
        }
        private void LoadGridView()
        {
            this.dataGridView.DataSource = UsersDao.GetAllUsers();
        }
        private void parent_NodeClick(object sender, EventArgs e)
        {
            Node parent = sender as Node;
            
            if (parent.Checked)
            {
                foreach (Node child in parent.Nodes)
                {
                    child.Checked = true;
                }
            }
            else
            {
                foreach (Node child in parent.Nodes)
                {
                    child.Checked = false;
                }
            }
        }
        #endregion

        #region 用户帐号焦点离开事件
        /// <summary>
        /// 用户帐号焦点离开事件，获取用户信息或者取得最新帐号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userId_Leave(object sender, EventArgs e)
        {
            if (VTMS.Common.Utilities.IsNullOrEmpty(this.userId.Text))
            {
                this.userId.Text = UsersDao.GenerateId();

                this.delBtn.Visible = false;

                user = null;

                this.saveBtn.Enabled = true;
            }
        }
        #endregion

        #region 设置权限信息
        /// <summary>
        /// 根据用户id设置权限列表
        /// </summary>
        /// <param name="userId"></param>
        private void SetPrivilege()
        {
            foreach (KeyValuePair<Node, List<Node>> kv in list)
            {
                foreach (Node node in kv.Value)
                {
                    node.Checked = false;
                }
                foreach (Privilege privilege in user.Privileges)
                {
                    foreach (Node node in kv.Value)
                    {
                        if (node.Name.Equals(privilege.Itmename))
                        {
                            node.Checked = privilege.Isactive;
                        }
                    }
                }
            }
        }
        #endregion

        #region 获取用户权限信息
        /// <summary>
        /// 从界面上获取用户权限信息
        /// </summary>
        /// <returns></returns>
        private IList<Privilege> GetPrivilege()
        {
            List<Privilege> listP = new List<Privilege>();
            foreach (KeyValuePair<Node, List<Node>> kv in list)
            {
                if (user.Privileges != null && user.Privileges.Count > 0)
                {

                    foreach (Node node in kv.Value)
                    {
                        bool exist = false;
                        foreach (Privilege privilege in user.Privileges)
                        {
                            if (node.Name.Equals(privilege.Itmename))
                            {
                                privilege.Isactive = node.Checked;
                                listP.Add(privilege);
                                exist = true;
                                continue;
                            }
                        }
                        if (exist == false)
                        {
                            Privilege privilege = new Privilege();
                            privilege.User = user;
                            privilege.Itmename = node.Name;
                            privilege.ParentName = kv.Key.Name;
                            privilege.Isactive = node.Checked;

                            listP.Add(privilege);
                        }
                    }
                }
                else
                {

                    foreach (Node node in kv.Value)
                    {
                        Privilege privilege = new Privilege();
                        privilege.User = user;
                        privilege.Itmename = node.Name;
                        privilege.ParentName = kv.Key.Name;
                        privilege.Isactive = node.Checked;

                        listP.Add(privilege);
                    }
                }
            }
            return listP;
        }
        #endregion

        #region 删除按钮点击事件
        /// <summary>
        /// 删除按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delBtn_Click(object sender, EventArgs e)
        {
            user.UsersIsactive = false;
            UsersDao.Update(user);
            LoadGridView();
            ClearControlContent();
        }
        #endregion

        #region 保存按钮点击事件
        /// <summary>
        /// 保存用户信息和权限信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.ValidateChildren(ValidationConstraints.Enabled & ValidationConstraints.TabStop & ValidationConstraints.Selectable);
            if (!VTMS.ControlLib.ValidatorManager.ValidateControls(this))
            {
                MessageBox.Show("控件内容不合法");
                return;
            }
            string password = VTMS.Common.Utilities.GeneratePassword();
            if (user == null)
            {
                user = new Users();
                user.UsersId = this.userId.Text;
                user.Password = VTMS.Common.Utilities.Md5Encrypt(password);
                user.UsersName = this.userName.Text;
                user.UsersEmail = this.userEmail.Text;
                user.UsersIsactive = true;

                VTMS.Common.Utilities.sendEmail(user.UsersEmail, password);

                UsersDao.AddUser(user);
            }
            else
            {
                user.UsersId = this.userId.Text;
                user.UsersName = this.userName.Text;
                user.UsersEmail = this.userEmail.Text;

                UsersDao.Update(user);
            }

            PrivilegeDao.SavePrivileges(GetPrivilege());
            LoadGridView();
            ClearControlContent();
        }
        #endregion

        #region 回车后跳到下一控件
        /// <summary>
        /// 回车转TAB
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (keyData == Keys.Enter && !(this.ActiveControl is Button))
            {

                return base.ProcessDialogKey(Keys.Tab);

            }

            return base.ProcessDialogKey(keyData);

        }
        #endregion

        #region 清空按钮点击事件
        /// <summary>
        /// 清空按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearControlContent();
        }
        #endregion

        #region 清空控件内容
        /// <summary>
        /// 清空控件内容
        /// </summary>
        private void ClearControlContent()
        {
            user = null;
            this.userId.Text = "";
            this.userName.Text = "";
            this.userEmail.Text = "";

            foreach (Node node in this.advTree1.Nodes)
            {
                node.Checked = false;
                foreach (Node child in node.Nodes)
                {
                    child.Checked = false;
                }
            }
            this.resetPwdBtn.Enabled = false;
            this.delBtn.Visible = false;
            this.activeBtn.Visible = false;
            this.saveBtn.Enabled = false;
            this.userId.Focus();
        }
        #endregion

        #region 激活按钮点击事件
        /// <summary>
        /// 激活按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void activeBtn_Click(object sender, EventArgs e)
        {
            user.UsersIsactive = true;
            UsersDao.Update(user);
            ClearControlContent();
            LoadGridView();
        }
        #endregion

        #region 重置密码按钮点击事件
        /// <summary>
        /// 重置密码按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetPwdBtn_Click(object sender, EventArgs e)
        {
            string password = VTMS.Common.Utilities.GeneratePassword();
            user.Password = VTMS.Common.Utilities.Md5Encrypt(password);

            try
            {
                UsersDao.Update(user);

                VTMS.Common.Utilities.sendEmail(user.UsersEmail, password);

                MessageUtil.ShowTips("密码重置成功！");
            }
            catch (Exception ex)
            {
                MessageUtil.ShowTips("密码重置失败！错误信息为：" + ex.Message);
            }

            ClearControlContent();
        }
        #endregion
    }
}
