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
    public partial class CompanyReportForm : Office2007Form
    {
        #region 界面初始化
        /// <summary>
        /// 界面初始化，设置起止日期等
        /// </summary>
        public CompanyReportForm()
        {
            InitializeComponent();
            this.dataGridView.AutoGenerateColumns = false;
            this.startDate.Value = DateTime.Today;
            this.endDate.Value = DateTime.Today;
        }
        #endregion

        #region 加载经济公司下拉菜单
        /// <summary>
        /// 加载经济公司下拉菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompanyReportForm_Load(object sender, EventArgs e)
        {
            InitComboBox();
        }
        public void InitComboBox()
        {
            this.company.DataSource = CompanyDao.LoadAll();
            this.company.DisplayMember = "Name";
            this.company.ValueMember = "Id";
        }
        #endregion

        #region 统计按钮点击
        /// <summary>
        /// 开始统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void caculate_Click(object sender, EventArgs e)
        {
            this.dataGridView.DataSource = VehicleDao.CaculateCompanyReport(this.startDate.Value.Date.AddMilliseconds(-1), this.endDate.Value.Date.AddDays(1).AddMilliseconds(-1), this.company.SelectedValue.ToString()).Tables[0];
        }
        #endregion

        #region 生成行号
        /// <summary>
        /// 生成行号
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

        #region 格式化输出
        /// <summary>
        /// 格式化输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "RegisterColumn")
            {
                e.Value = DateTime.ParseExact(e.Value.ToString(), "yyyyMM", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy年MM月");
            }
        }
        #endregion
    }
}
