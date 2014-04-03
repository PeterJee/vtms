using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevComponents.DotNetBar;
using VTMS.Common;
using VTMS.Model.Entities;
using VTMS.Access;
namespace VTMS.Statistics
{
    public partial class TaxReportForm : Office2007Form
    {
        /// <summary>
        /// 窗口初始化
        /// </summary>
        public TaxReportForm()
        {
            InitializeComponent(); this.dataGridView.AutoGenerateColumns = false;
            this.startDate.Value = DateTime.Today;
            this.endDate.Value = DateTime.Today;
        }

        #region 统计按钮点击
        /// <summary>
        /// 开始统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void caculate_Click(object sender, EventArgs e)
        {
            this.dataGridView.DataSource = VehicleDao.CaculateTaxReport(this.startDate.Value.Date.AddMilliseconds(-1), this.endDate.Value.Date.AddDays(1).AddMilliseconds(-1)).Tables[0];
        }
        #endregion

        #region 添加行号
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

        #region 格式化数据
        /// <summary>
        /// 格式化输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "SaveDateColumn")
            {
                e.Value = DateTime.Parse(e.Value.ToString()).ToString("yyyy年MM月dd日");
            }
            else if (dataGridView.Columns[e.ColumnIndex].Name == "RegisterColumn")
            {
                e.Value = DateTime.ParseExact(e.Value.ToString(), "yyyyMM", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy年MM月");
            }
        }
        #endregion

        #region 导出数据
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportButton_Click(object sender, EventArgs e)
        {
            #region   验证可操作性
            //定义表格内数据的行数和列数      
            int rowscount = dataGridView.Rows.Count;
            int colscount = dataGridView.Columns.Count;
            //行数必须大于0      
            if (rowscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数必须大于0      
            if (colscount <= 0)
            {
                MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //行数不可以大于65536      
            if (rowscount > 65536)
            {
                MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //列数不可以大于255      
            if (colscount > 255)
            {
                MessageBox.Show("数据记录行数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //申明保存对话框      
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀      
            dlg.DefaultExt = "xls ";
            //文件后缀列表      
            dlg.Filter = "Excel文件(*.XLS)|*.xls ";
            //打开保存对话框      
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            //返回文件路径      
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效      
            if (fileNameString.Trim() == " ")
            {
                return;
            }

            //验证以fileNameString命名的文件是否存在，如果存在删除它      
            FileInfo file = new FileInfo(fileNameString);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            #endregion
            Microsoft.Office.Interop.Excel.Application objExcel = null;
            Microsoft.Office.Interop.Excel.Workbook objWorkbook = null;
            Microsoft.Office.Interop.Excel.Worksheet objsheet = null;
            try
            {
                //申明对象      
                objExcel = new Microsoft.Office.Interop.Excel.Application();
                objWorkbook = objExcel.Workbooks.Add();
                objsheet = (Microsoft.Office.Interop.Excel.Worksheet)objWorkbook.ActiveSheet;
                //设置Microsoft.Office.Interop.Excel不可见      
                objExcel.Visible = false;

                //向Microsoft.Office.Interop.Excel中写入表格的表头      
                int displayColumnsCount = 1;
                for (int i = 0; i <= dataGridView.ColumnCount - 1; i++)
                {
                    if (dataGridView.Columns[i].Visible == true)
                    {
                        objsheet.Cells[1, displayColumnsCount] = dataGridView.Columns[i].HeaderText.Trim();
                        displayColumnsCount++;
                    }
                }
                //向Microsoft.Office.Interop.Excel中逐行逐列写入表格中的数据      
                for (int row = 0; row <= dataGridView.RowCount - 1; row++)
                {
                    displayColumnsCount = 1;
                    for (int col = 0; col < colscount; col++)
                    {
                        if (dataGridView.Columns[col].Visible == true)
                        {
                            try
                            {
                                if (col == 0)
                                    objsheet.Cells[row + 2, displayColumnsCount] = DateTime.Parse(dataGridView.Rows[row].Cells[col].Value.ToString()).ToString("yyyy年MM月dd日");
                                else if (col == 3)
                                    objsheet.Cells[row + 2, displayColumnsCount] = DateTime.ParseExact(dataGridView.Rows[row].Cells[col].Value.ToString(), "yyyyMM", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy年MM月");
                                else
                                    objsheet.Cells[row + 2, displayColumnsCount] = dataGridView.Rows[row].Cells[col].Value.ToString();
                                displayColumnsCount++;
                            }
                            catch (Exception)
                            {

                            }

                        }
                    }
                }

                objsheet.get_Range("A:G").NumberFormatLocal = "@";
                //保存文件      
                objsheet.SaveAs(fileNameString);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                //关闭Microsoft.Office.Interop.Excel应用      
                if (objWorkbook != null)
                {
                    objWorkbook.Close(System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objWorkbook);
                }
                if (objExcel.Workbooks != null)
                {
                    objExcel.Workbooks.Close();
                    objExcel.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel);
                }

                objsheet = null;
                objWorkbook = null;
                objExcel = null;
                GC.Collect();
            }
            MessageBox.Show("导出成功! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

    }
}
