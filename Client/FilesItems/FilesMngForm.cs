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
    public partial class FilesMngForm : Office2007Form
    {
        public FilesMngForm()
        {
            InitializeComponent();
            this.dataGridView.AutoGenerateColumns = false;
            this.process.DataSource = new string[] { "申档中", "申档完", "退档" };
        }

        private void FilesMngForm_Load(object sender, EventArgs e)
        {
            this.dataGridView.DataSource = ArchivesDao.Load();
        }

        private void process_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.process.Text == "退档")
            {
                this.reason.Enabled = true;
            }
            else
            {
                this.reason.Enabled = false;
                this.reason.Text = "";
            }
        }
        #region 生成行号
        /// <summary>
        /// 添加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                //添加行号 
                SolidBrush v_SolidBrush = new SolidBrush(dataGridView.RowHeadersDefaultCellStyle.ForeColor);

                int v_LineNo = e.RowIndex + 1;

                string v_Line = v_LineNo.ToString();

                e.Graphics.DrawString(v_Line, e.InheritedRowStyle.Font, v_SolidBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);

            }
            catch (Exception ex)
            {
                //MessageBox.Show("添加行号时发生错误，错误信息：" + ex.Message, "操作失败");
            }
        }
        #endregion

        #region 格式化输出
        /// <summary>
        /// 格式化输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Archives vehicle = dataGridView.Rows[e.RowIndex].DataBoundItem as Archives;
            if (dataGridView.Columns[e.ColumnIndex].Name == "DateColumn")
            {
                e.Value = vehicle.SaveDate.ToString("yyyy年MM月dd日");
            }
        }
        #endregion

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (this.license.Text.Length != 5)
            {
                MessageUtil.ShowError("号牌号码输入不正确！");
                return;
            }
            Archives archive = new Archives();
            archive.License = this.license.Text;
            archive.Process = this.process.Text;
            archive.Reason = this.reason.Text;

            archive.Saver = LoginForm.user.UsersId;

            archive.SaveDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);

            try
            {
                ArchivesDao.AddArchives(archive);
            }
            catch (Exception ex)
            {
                MessageUtil.ShowError("保存档案时出错，错误信息为：" + ex.Message);
            }
            this.dataGridView.DataSource = ArchivesDao.Load();
            this.clear();
        }

        private void license_Leave(object sender, EventArgs e)
        {
            Archives archive = ArchivesDao.Get(this.license.Text);
            if (archive != null)
            {
                this.process.Text = archive.Process;
                this.reason.Text = archive.Reason;
            }
        }
        private void clear()
        {
            this.license.Text = "";
            this.process.SelectedIndex = 0;
            this.reason.Text = "";
            this.license.Focus();
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
    }
}
