using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using VTMS.Access;
using VTMS.Model.Entities;
using VTMS.Common;
using DevComponents.DotNetBar.Controls;

namespace VTMS.FrontFunctionItems
{
    public partial class AlterForm : ResizableForm
    {
        #region 初始化参数
        private bool isUpdate;
        Alter alter;
        ErrorProvider categoryErrorProvider = new ErrorProvider();
        #endregion

        #region 窗口初始化
        /// <summary>
        /// 窗口初始化
        /// </summary>
        public AlterForm()
        {
            InitializeComponent();
        }
        private void AlterForm_Load(object sender, EventArgs e)
        {
            this.category.SelectedIndex = 0;
            setControlReadOnly(true);
        }
        #endregion

        #region 设置控件可读状态
        /// <summary>
        /// 设置控件可读状态
        /// </summary>
        /// <param name="flag"></param>
        private void setControlReadOnly(bool flag)
        {
            this.serial.ReadOnly = !flag;
            this.category.Enabled = !flag;
            this.license.ReadOnly = flag;
            this.ownerName.ReadOnly = flag;
            this.purpose.Enabled = !flag;
            this.owner.ReadOnly = flag;
            this.newAddress.ReadOnly = flag;
            this.postAddress.ReadOnly = flag;
            this.postcode.ReadOnly = flag;
            this.email.ReadOnly = flag;
            this.phone.ReadOnly = flag;
            this.mobile.ReadOnly = flag;
            this.province.ReadOnly = flag;
            this.department.ReadOnly = flag;
            this.engine.Enabled = !flag;
            this.body.Enabled = !flag;
            this.color.Enabled = !flag;
            this.whole.Enabled = !flag;
            this.engineCode.Enabled = !flag;
            this.vin.Enabled = !flag;
            this.idCode.Enabled = !flag;
            this.information.ReadOnly = flag;
            this.agentName.ReadOnly = flag;
            this.agentPhone.ReadOnly = flag;
            this.agentPostcode.ReadOnly = flag;
            this.agentAddress.ReadOnly = flag;
            this.agentEmail.ReadOnly = flag;
            this.handlerName.ReadOnly = flag;
            this.handlerPhone.ReadOnly = flag;
            this.printBtn.Enabled = !flag;
        }
        #endregion

        #region 清除所有控件内容
        /// <summary>
        /// 清除控件内容
        /// </summary>
        private void clearControlContent()
        {
            this.serial.Text = "";
            this.category.Text = "";
            this.license.Text = "";
            this.ownerName.Text = "";
            this.purpose.Text = "";
            this.owner.Text = "";
            this.newAddress.Text = "";
            this.postAddress.Text = "";
            this.postcode.Text = "";
            this.email.Text = "";
            this.phone.Text = "";
            this.mobile.Text = "";
            this.province.Text = "";
            this.department.Text = "";
            this.engine.Checked = false;
            this.body.Checked = false;
            this.color.Checked = false;
            this.whole.Checked = false;
            this.engineCode.Checked = false;
            this.vin.Checked = false;
            this.idCode.Checked = false;
            this.information.Text = "";
            this.agentName.Text = "";
            this.agentPhone.Text = "";
            this.agentPostcode.Text = "";
            this.agentAddress.Text = "";
            this.agentEmail.Text = "";
            this.handlerName.Text = "";
            this.handlerPhone.Text = "";
        }
        #endregion

        #region 流水号离开事件
        /// <summary>
        /// 当光标焦点至于流水号时，用户回车产生新的流水号或获取流水号对应数据信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_Leave(object sender, EventArgs e)
        {
            if (this.serial.ReadOnly || (this.serial.Text.Length != 11 && this.serial.Text.Length != 0))
            {
                return;
            }

            //InitComboBox();

            if (Utilities.IsNullOrEmpty(this.serial.Text))
            {
                alter = new Alter();

                this.serial.Text = AlterDao.GetLatestSerial();

                this.setControlReadOnly(false);

                this.category.Focus();

                this.isUpdate = false;
            }
            else
            {
                alter = AlterDao.GetBySerial(this.serial.Text);

                if (alter != null)
                {
                    this.setControlReadOnly(false);

                    this.isUpdate = true;

                    setAlterInfo(alter);

                    this.category.Focus();
                }
                else
                {
                    this.serial.Focus();
                }
            }
        }
        #endregion

        #region 设置控件内容
        /// <summary>
        /// 根据获得的注册信息设置控件内容
        /// </summary>
        /// <param name="alter"></param>
        private void setAlterInfo(Alter alter)
        {
            this.category.Text = alter.Category;
            this.license.Text = alter.License;
            this.ownerName.Text = alter.OwnerName;
            this.purpose.Text = alter.Purpose;
            this.owner.Text = alter.Owner;
            this.newAddress.Text = alter.NewAddress;
            this.postAddress.Text = alter.PostAddress;
            this.postcode.Text = alter.Postcode;
            this.email.Text = alter.Email;
            this.phone.Text = alter.Phone;
            this.mobile.Text = alter.Mobile;
            this.province.Text = alter.Province;
            this.department.Text = alter.Department;
            this.engine.Checked = alter.Engine;
            this.body.Checked = alter.Body;
            this.color.Checked = alter.Color;
            this.whole.Checked = alter.Whole;
            this.engineCode.Checked = alter.EngineCode;
            this.vin.Checked = alter.Vin;
            this.idCode.Checked = alter.IdCode;
            this.information.Text = alter.Information;
            this.agentName.Text = alter.AgentName;
            this.agentPhone.Text = alter.AgentPhone;
            this.agentPostcode.Text = alter.AgentPostcode;
            this.agentAddress.Text = alter.AgentAddress;
            this.agentEmail.Text = alter.AgentEmail;
            this.handlerName.Text = alter.HandlerName;
            this.handlerPhone.Text = alter.HandlerPhone;
        }
        #endregion

        #region 获取控件内容
        /// <summary>
        /// 获取控件内容，并设置保存时间和打印时间等信息
        /// </summary>
        /// <returns></returns>
        private Alter getAlterInfo()
        {
            if (!this.isUpdate)
            {
                alter.Saver = LoginForm.user.UsersId;

                alter.SaveDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            }

            alter.Serial = this.serial.Text;
            alter.Category = this.category.Text;
            alter.License = this.license.Text;
            alter.OwnerName = this.ownerName.Text;
            alter.Purpose = this.purpose.Text;
            alter.Owner = this.owner.Text;
            alter.NewAddress = this.newAddress.Text;
            alter.PostAddress = this.postAddress.Text;
            alter.Postcode = this.postcode.Text;
            alter.Email = this.email.Text;
            alter.Phone = this.phone.Text;
            alter.Mobile = this.mobile.Text;
            alter.Province = this.province.Text;
            alter.Department = this.department.Text;
            alter.Engine = this.engine.Checked;
            alter.Body = this.body.Checked;
            alter.Color = this.color.Checked;
            alter.Whole = this.whole.Checked;
            alter.EngineCode = this.engineCode.Checked;
            alter.Vin = this.vin.Checked;
            alter.IdCode = this.idCode.Checked;
            alter.Information = this.information.Text;
            alter.AgentName = this.agentName.Text;
            alter.AgentPhone = this.agentPhone.Text;
            alter.AgentPostcode = this.agentPostcode.Text;
            alter.AgentAddress = this.agentAddress.Text;
            alter.AgentEmail = this.agentEmail.Text;
            alter.HandlerName = this.handlerName.Text;
            alter.HandlerPhone = this.handlerPhone.Text;

            return alter;
        }
        private Alter getPrintInfo()
        {
            if (!this.isUpdate)
            {
                alter.Saver = LoginForm.user.UsersId;

                alter.SaveDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            }

            alter.Serial = this.serial.Text;
            alter.Category = this.category.Text;
            alter.License = this.license.Text;
            alter.OwnerName = this.ownerName.Text;
            alter.Purpose = this.purpose.Text;
            alter.Owner = this.owner.Text;
            alter.NewAddress = this.newAddress.Text;
            alter.PostAddress = this.postAddress.Text;
            alter.Postcode = this.postcode.Text;
            alter.Email = this.email.Text;
            alter.Phone = this.phone.Text;
            alter.Mobile = this.mobile.Text;
            alter.Province = this.province.Text;
            alter.Department = this.department.Text;
            alter.Engine = this.engine.Checked;
            alter.Body = this.body.Checked;
            alter.Color = this.color.Checked;
            alter.Whole = this.whole.Checked;
            alter.EngineCode = this.engineCode.Checked;
            alter.Vin = this.vin.Checked;
            alter.IdCode = this.idCode.Checked;
            alter.Information = this.information.Text;
            alter.AgentName = this.agentName.Text;
            alter.AgentPhone = this.agentPhone.Text;
            alter.AgentPostcode = this.agentPostcode.Text;
            alter.AgentAddress = this.agentAddress.Text;
            alter.AgentEmail = this.agentEmail.Text;
            alter.HandlerName = this.handlerName.Text;
            alter.HandlerPhone = this.handlerPhone.Text;

            alter.PrintDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            alter.Printer = LoginForm.user.UsersId;

            return alter;
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

        #region 控件验证与联动事件
        /// <summary>
        /// 号牌种类控件验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void category_Validating(object sender, CancelEventArgs e)
        {
            ComboBoxEx cb = sender as ComboBoxEx;

            if (Utilities.IsNullOrEmpty(cb.Text) && cb.Enabled)
            {
                categoryErrorProvider.SetError(cb, "不能为空！");
                e.Cancel = true;
            }
            else
            {
                categoryErrorProvider.Clear();
                e.Cancel = false;
            }
        }
        #endregion

        #region 清空按钮点击事件
        /// <summary>
        /// 清空按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.clearControlContent();
            this.setControlReadOnly(true);
            this.serial.Focus();
        }
        #endregion

        #region 打印事件
        /// <summary>
        /// 打印按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printBtn_Click(object sender, EventArgs e)
        {
            this.ValidateChildren(ValidationConstraints.Enabled & ValidationConstraints.TabStop & ValidationConstraints.Selectable);
            if (!VTMS.ControlLib.ValidatorManager.ValidateControls(this))
            {
                MessageBox.Show("控件内容不合法");
                return;
            }

            printInfo();

            clearControlContent();
            setControlReadOnly(true);
            this.serial.Focus();
        }
        /// <summary>
        /// 保存
        /// </summary>
        private void saveInfo()
        {
            Alter alter = getPrintInfo();
            try
            {
                if (this.isUpdate)
                {
                    AlterDao.Update(alter);
                }
                else
                {
                    object id = AlterDao.Add(alter);

                    MessageBox.Show("当前流水号为 " + id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        private void printInfo()
        {
            Object oMissing = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Excel.Application m_objExcel = null;

            Microsoft.Office.Interop.Excel._Workbook m_objBook = null;

            Microsoft.Office.Interop.Excel.Sheets m_objSheets = null;

            Microsoft.Office.Interop.Excel._Worksheet m_objSheet = null;

            Microsoft.Office.Interop.Excel.Range m_objRange = null;

            try
            {

                m_objExcel = new Microsoft.Office.Interop.Excel.Application();

                DirectoryInfo Dir = new DirectoryInfo(".");

                m_objBook = m_objExcel.Workbooks.Open(Dir.FullName + "/Templete/Alter.xls", oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                m_objSheets = (Microsoft.Office.Interop.Excel.Sheets)m_objBook.Worksheets;

                m_objSheet = (Microsoft.Office.Interop.Excel._Worksheet)(m_objSheets.get_Item(1));

                // 号牌种类
                m_objRange = m_objSheet.get_Range("D2", oMissing);
                m_objRange.Value = this.category.Text;

                // 号牌号码
                m_objRange = m_objSheet.get_Range("H2", oMissing);
                m_objRange.Value = "辽B" + this.license.Text;

                // 变更机动车所有人姓名/名称
                m_objRange = m_objSheet.get_Range("D4", oMissing);
                m_objRange.Value = this.ownerName.Text;

                //共同所有的机动车变更所有人
                m_objRange = m_objSheet.get_Range("D5", oMissing);
                m_objRange.Value = this.owner.Text; 

                // 住所在车辆管理所辖区内迁移
                m_objRange = m_objSheet.get_Range("D6", oMissing);
                m_objRange.Value = this.newAddress.Text;

                // 邮寄地址
                m_objRange = m_objSheet.get_Range("D7", oMissing);
                m_objRange.Value = "          " + this.postAddress.Text;

                // 邮政编码
                m_objRange = m_objSheet.get_Range("D8", oMissing);
                m_objRange.Value = "          " + this.postcode.Text;

                // 电子信箱
                m_objRange = m_objSheet.get_Range("D9", oMissing);
                m_objRange.Value = "          " + this.email.Text;

                // 固定电话
                m_objRange = m_objSheet.get_Range("H8", oMissing);
                m_objRange.Value = "    " + this.phone.Text;

                // 移动电话
                m_objRange = m_objSheet.get_Range("H9", oMissing);
                m_objRange.Value = "    " + this.mobile.Text;

                // 省（自治县、直辖市)
                m_objRange = m_objSheet.get_Range("D10", oMissing);
                m_objRange.Value = "      " + this.province.Text;

                // 车辆管理所
                m_objRange = m_objSheet.get_Range("H10", oMissing);
                m_objRange.Value = this.department.Text;

                // 变更后的信息
                m_objRange = m_objSheet.get_Range("D15", oMissing);
                m_objRange.Value = this.information.Text;

                // 代理人姓名、名称
                m_objRange = m_objSheet.get_Range("C21", oMissing);
                m_objRange.Value = this.agentName.Text;

                // 代理人邮寄地址
                m_objRange = m_objSheet.get_Range("C22", oMissing);
                m_objRange.Value = this.agentAddress.Text;

                // 代理人邮政编码
                m_objRange = m_objSheet.get_Range("C23", oMissing);
                m_objRange.Value = this.agentPostcode.Text;

                // 代理人联系电话
                m_objRange = m_objSheet.get_Range("F23", oMissing);
                m_objRange.Value = this.agentPhone.Text;

                // 代理人电子信箱
                m_objRange = m_objSheet.get_Range("C24", oMissing);
                m_objRange.Value = this.agentEmail.Text;

                // 经办人电话
                m_objRange = m_objSheet.get_Range("C25", oMissing);
                m_objRange.Value = this.handlerName.Text;

                // 经办人联系电话
                m_objRange = m_objSheet.get_Range("F25", oMissing);
                m_objRange.Value = this.handlerPhone.Text;

                // 办理日期
                m_objRange = m_objSheet.get_Range("H20", oMissing);
                m_objRange.Value = DateTime.Today.Year + "       " + DateTime.Today.Month + "       " + DateTime.Today.Day + "   ";

                m_objRange = m_objSheet.get_Range("H25", oMissing);
                m_objRange.Value = DateTime.Today.Year + "       " + DateTime.Today.Month + "       " + DateTime.Today.Day + "   "; ;


                m_objExcel.DisplayAlerts = false;
                m_objBook.Save();
                m_objSheet.PrintOut();
            }
            catch (Exception ex)
            {
                // 输出异常信息
                MessageBox.Show("打印失败,异常信息为：" + ex.Message);
            }
            finally
            {
                if (m_objBook != null)
                {
                    m_objBook.Close(oMissing, oMissing, oMissing);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
                }

                if (m_objExcel != null)
                {
                    m_objExcel.Workbooks.Close();
                    m_objExcel.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
                }

                m_objBook = null;

                m_objExcel = null;

                GC.Collect();
            }
        }
        #endregion

        #region 保存按钮点击事件
        /// <summary>
        /// 保存按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            Alter alter = getAlterInfo();
            try
            {
                if (this.isUpdate)
                {
                    AlterDao.Update(alter);
                }
                else
                {
                    AlterDao.Add(alter);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            this.isUpdate = true;
        }
        #endregion
    }
}
