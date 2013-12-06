using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Diagnostics;
using System.IO;
using AForge.Video;
using AForge.Video.DirectShow;
using VTMS.Access;
using VTMS.Model.Entities;
using VTMS.Common;
using VTMS.ControlLib;

namespace VTMS.FilesItems
{
    public partial class FilesSearchForm : ResizableForm
    {
        public FilesSearchForm()
        {
            InitializeComponent();
        }
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

        private void license_Leave(object sender, EventArgs e)
        {
            this.setContent();
        }

        private void inputBtn_Click(object sender, EventArgs e)
        {
            if (this.license.Text.Length < 5)
            {
                ButtonX btn = sender as ButtonX;
                this.license.Text = this.license.Text + btn.Text;
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.clear();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            this.setContent();
        }

        private void setContent()
        {
            if (this.license.Text.Length == 5)
            {
                System.Collections.IList list = ArchivesDao.SearchArchive(this.license.Text);

                if (list.Count > 0)
                {
                    object[] o = (object[])list[0];


                    this.userName.Text = o[1].ToString();

                    string id = o[2].ToString();
                    if (id.Length > 7)
                    {
                        string tmp = new String('*', id.Length - 7);
                        id = id.Replace(id.Substring(3, id.Length - 7), tmp);
                    }
                    this.userId.Text = id;
                    this.process.Text = o[3].ToString();
                    this.reason.Text = o[4].ToString();
                    this.saveDate.Text = o[5].ToString();
                }
                else
                {
                    this.clear();
                }
            }
        }

        private void clear()
        {
            this.license.Text = "";
            this.userName.Text = "";
            this.userId.Text = "";
            this.process.Text = "";
            this.reason.Text = "";
            this.saveDate.Text = "";
        }
    }
}
