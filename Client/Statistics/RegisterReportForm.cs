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
using VTMS.Model.Entities;
using VTMS.Access;

namespace VTMS.Statistics
{
    public partial class RegisterReportForm : Form
    {
        public RegisterReportForm()
        {
            InitializeComponent();
            this.dataGridView.AutoGenerateColumns = false;
            this.startDate.Value = DateTime.Today;
            this.endDate.Value = DateTime.Today;
            this.condition.DataSource = new string[] { "日统计", "月统计", "年统计" };
        }
        #region 统计按钮点击
        /// <summary>
        /// 开始统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void caculate_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Today, end = DateTime.Today;
            if (condition.Text == "日统计")
            {
                start = this.startDate.Value.Date.AddMilliseconds(-1);
                end = this.endDate.Value.Date.AddDays(1).AddMilliseconds(-1);
            }
            else if (condition.Text == "月统计")
            {
                start = this.startDate.Value.Date.AddDays(1 - this.startDate.Value.Date.Day).AddMilliseconds(-1);
                end = this.endDate.Value.Date.AddDays(1 - this.endDate.Value.Date.Day).AddMonths(1).AddMilliseconds(-1);
            }
            else
            {
                start = this.startDate.Value.Date.AddMonths(1-this.startDate.Value.Month).AddDays(1 - this.startDate.Value.Date.Day).AddMilliseconds(-1);
                end = this.endDate.Value.Date.AddYears(1).AddMonths(1 - this.startDate.Value.Month).AddDays(1 - this.endDate.Value.Date.Day).AddMilliseconds(-1);
            }
            this.dataGridView.DataSource = RegisterDao.CaculateRegisterReport(start, end, this.condition.Text);
        }
        #endregion

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

                e.Graphics.DrawString(v_Line, e.InheritedRowStyle.Font, v_SolidBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 1);

            }
            catch (Exception ex)
            {
                //MessageBox.Show("添加行号时发生错误，错误信息：" + ex.Message, "操作失败");
            }
        }
        #endregion

        private void condition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (condition.Text == "日统计")
            {
                this.startDate.CustomFormat = "yyyy/MM/dd";
                this.endDate.CustomFormat = "yyyy/MM/dd";
            }
            else if (condition.Text == "月统计")
            {
                this.startDate.CustomFormat = "yyyy/MM";
                this.endDate.CustomFormat = "yyyy/MM";
            }
            else
            {
                this.startDate.CustomFormat = "yyyy";
                this.endDate.CustomFormat = "yyyy";
            }
        }
    }
}
