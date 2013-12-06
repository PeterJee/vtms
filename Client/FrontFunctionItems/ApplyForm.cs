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
    public partial class ApplyForm : ResizableForm
    {
        #region 初始化参数
        private bool isUpdate;
        Apply apply;
        ErrorProvider categoryErrorProvider = new ErrorProvider();
        #endregion

        #region 窗口初始化
        /// <summary>
        /// 窗口初始化
        /// </summary>
        public ApplyForm()
        {
            InitializeComponent();
        }
        private void ApplyForm_Load(object sender, EventArgs e)
        {
            this.category.SelectedIndex = 0;
            //将所有控件设置为只读状态
            this.setControlReadOnly(true);
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
            this.plateRenew.Enabled = !flag; 
            this.plateChange.Enabled = !flag;
            this.driverRenew.Enabled = !flag;
            this.driverChange.ReadOnly = flag; 
            this.licenseApply.ReadOnly = flag;
            this.licenseRenew.Enabled = !flag;
            this.licenseChange.ReadOnly = flag;
            this.signApply.Enabled = !flag;
            this.signRenew.Enabled = !flag;
            this.signChange.ReadOnly = flag;
            this.ownerName.ReadOnly = flag;
            this.ownerAddress.ReadOnly = flag;
            this.ownerPostcode.ReadOnly = flag;
            this.ownerPhone.ReadOnly = flag;
            this.ownerEmail.ReadOnly = flag;
            this.ownerMobile.ReadOnly = flag;
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
            this.plateRenew.Text = "";
            this.plateChange.Text = "";
            this.driverRenew.Text = "";
            this.driverChange.Text = "";
            this.licenseApply.Text = "";
            this.licenseRenew.Text = "";
            this.licenseChange.Text = "";
            this.signApply.Text = "";
            this.signRenew.Text = "";
            this.signChange.Text = "";
            this.ownerName.Text = "";
            this.ownerAddress.Text = "";
            this.ownerPostcode.Text = "";
            this.ownerPhone.Text = "";
            this.ownerEmail.Text = "";
            this.ownerMobile.Text = "";
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
                apply = new Apply();

                this.serial.Text = ApplyDao.GetLatestSerial();

                this.setControlReadOnly(false);

                this.category.Focus();

                this.isUpdate = false;
            }
            else
            {
                apply = ApplyDao.GetBySerial(this.serial.Text);

                if (apply != null)
                {
                    this.setControlReadOnly(false);

                    this.isUpdate = true;

                    setApplyInfo(apply);

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
        /// <param name="apply"></param>
        private void setApplyInfo(Apply apply)
        {
            this.category.Text = apply.Category;
            this.license.Text = apply.License;
            this.plateRenew.Text = apply.PlateRenew;
            this.plateChange.Text = apply.PlateChange;
            this.driverRenew.Text = apply.DriverRenew;
            this.driverChange.Text = apply.DriverChange;
            this.licenseApply.Text = apply.LicenseApply;
            this.licenseRenew.Text = apply.LicenseRenew;
            this.licenseChange.Text = apply.LicenseChange;
            this.signApply.Text = apply.SignApply;
            this.signRenew.Text = apply.SignRenew;
            this.signChange.Text = apply.SignChange;
            this.ownerName.Text = apply.OwnerName;
            this.ownerAddress.Text = apply.OwnerAddress;
            this.ownerPostcode.Text = apply.OwnerPostcode;
            this.ownerPhone.Text = apply.OwnerPhone;
            this.ownerEmail.Text = apply.OwnerEmail;
            this.ownerMobile.Text = apply.OwnerMobile;
            this.agentName.Text = apply.AgentName;
            this.agentPhone.Text = apply.AgentPhone;
            this.agentPostcode.Text = apply.AgentPostcode;
            this.agentAddress.Text = apply.AgentAddress;
            this.agentEmail.Text = apply.AgentEmail;
            this.handlerName.Text = apply.HandlerName;
            this.handlerPhone.Text = apply.HandlerPhone;
        }
        #endregion

        #region 获取控件内容
        /// <summary>
        /// 获取控件内容，并设置保存时间和打印时间等信息
        /// </summary>
        /// <returns></returns>
        private Apply getApplyInfo()
        {
            if (!this.isUpdate)
            {
                apply.Saver = LoginForm.user.UsersId;

                apply.SaveDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            }

            apply.Serial = this.serial.Text;
            apply.Category = this.category.Text;
            apply.License = this.license.Text;
            apply.PlateRenew = this.plateRenew.Text;
            apply.PlateChange= this.plateChange.Text;
            apply.DriverRenew=this.driverRenew.Text;
            apply.DriverChange=this.driverChange.Text;
            apply.LicenseApply=this.licenseApply.Text;
            apply.LicenseRenew=this.licenseRenew.Text;
            apply.LicenseChange=this.licenseChange.Text;
            apply.SignApply=this.signApply.Text;
            apply.SignRenew=this.signRenew.Text;
            apply.SignChange=this.signChange.Text;
            apply.OwnerName=this.ownerName.Text;
            apply.OwnerAddress=this.ownerAddress.Text;
            apply.OwnerPostcode=this.ownerPostcode.Text;
            apply.OwnerPhone=this.ownerPhone.Text;
            apply.OwnerEmail=this.ownerEmail.Text;
            apply.OwnerMobile=this.ownerMobile.Text;
            apply.AgentName=this.agentName.Text;
            apply.AgentPhone=this.agentPhone.Text;
            apply.AgentPostcode=this.agentPostcode.Text;
            apply.AgentAddress=this.agentAddress.Text;
            apply.AgentEmail=this.agentEmail.Text;
            apply.HandlerName=this.handlerName.Text;
            apply.HandlerPhone=this.handlerPhone.Text;

            return apply;
        }
        private Apply getPrintInfo()
        {
            if (!this.isUpdate)
            {
                apply.Saver = LoginForm.user.UsersId;

                apply.SaveDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            }

            apply.Serial = this.serial.Text;
            apply.Category = this.category.Text;
            apply.License = this.license.Text;
            apply.PlateRenew = this.plateRenew.Text;
            apply.PlateChange = this.plateChange.Text;
            apply.DriverRenew = this.driverRenew.Text;
            apply.DriverChange = this.driverChange.Text;
            apply.LicenseApply = this.licenseApply.Text;
            apply.LicenseRenew = this.licenseRenew.Text;
            apply.LicenseChange = this.licenseChange.Text;
            apply.SignApply = this.signApply.Text;
            apply.SignRenew = this.signRenew.Text;
            apply.SignChange = this.signChange.Text;
            apply.OwnerName = this.ownerName.Text;
            apply.OwnerAddress = this.ownerAddress.Text;
            apply.OwnerPostcode = this.ownerPostcode.Text;
            apply.OwnerPhone = this.ownerPhone.Text;
            apply.OwnerEmail = this.ownerEmail.Text;
            apply.OwnerMobile = this.ownerMobile.Text;
            apply.AgentName = this.agentName.Text;
            apply.AgentPhone = this.agentPhone.Text;
            apply.AgentPostcode = this.agentPostcode.Text;
            apply.AgentAddress = this.agentAddress.Text;
            apply.AgentEmail = this.agentEmail.Text;
            apply.HandlerName = this.handlerName.Text;
            apply.HandlerPhone = this.handlerPhone.Text;

            apply.PrintDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            apply.Printer = LoginForm.user.UsersId;

            return apply;
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

            saveInfo();

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
            Apply apply = getPrintInfo();
            try
            {
                if (this.isUpdate)
                {
                    ApplyDao.Update(apply);
                }
                else
                {
                    object id = ApplyDao.Add(apply);
                    MessageBox.Show("当前流水号为 " + id); ApplyDao.Add(apply);
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

                m_objBook = m_objExcel.Workbooks.Open(Dir.FullName + "/Templete/Apply.xls", oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                m_objSheets = (Microsoft.Office.Interop.Excel.Sheets)m_objBook.Worksheets;

                m_objSheet = (Microsoft.Office.Interop.Excel._Worksheet)(m_objSheets.get_Item(1));

                // 号牌种类
                m_objRange = m_objSheet.get_Range("D8", oMissing);
                m_objRange.Value = this.category.Text;

                // 号牌号码
                m_objRange = m_objSheet.get_Range("I8", oMissing);
                m_objRange.Value = "辽B" + this.license.Text;

                // 行驶证换领原因
                m_objRange = m_objSheet.get_Range("D13", oMissing);
                m_objRange.Value = this.driverChange.Text;

                // 登记证书申领原因
                m_objRange = m_objSheet.get_Range("D14", oMissing);
                m_objRange.Value = this.licenseApply.Text; 

                // 登记证书换领原因
                m_objRange = m_objSheet.get_Range("D16", oMissing);
                m_objRange.Value = this.licenseChange.Text;

                // 检验合格标志换领
                m_objRange = m_objSheet.get_Range("D19", oMissing);
                m_objRange.Value = this.signChange.Text;

                // 机动车所有人姓名/名称
                m_objRange = m_objSheet.get_Range("E3", oMissing);
                m_objRange.Value = this.ownerName.Text;

                // 机动车所有人邮寄地址
                m_objRange = m_objSheet.get_Range("E4", oMissing);
                m_objRange.Value = this.ownerAddress.Text;

                // 机动车所有人邮政编码
                m_objRange = m_objSheet.get_Range("I3", oMissing);
                m_objRange.Value = this.ownerPostcode.Text;

                // 机动车所有人固定电话
                m_objRange = m_objSheet.get_Range("I5", oMissing);
                m_objRange.Value = this.ownerPhone.Text;

                // 机动车所有人移动电话
                m_objRange = m_objSheet.get_Range("E5", oMissing);
                m_objRange.Value = this.ownerMobile.Text;

                // 代理人姓名、名称
                m_objRange = m_objSheet.get_Range("E6", oMissing);
                m_objRange.Value = this.agentName.Text;

                // 代理人联系电话
                m_objRange = m_objSheet.get_Range("H6", oMissing);
                m_objRange.Value = this.agentPhone.Text;

                // 办理日期
                m_objRange = m_objSheet.get_Range("F21", oMissing);
                m_objRange.Value = DateTime.Today.Year + "         " + DateTime.Today.Month + "          " + DateTime.Today.Day + "            ";
                

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
            this.ValidateChildren(ValidationConstraints.Enabled & ValidationConstraints.TabStop & ValidationConstraints.Selectable);
            if (!VTMS.ControlLib.ValidatorManager.ValidateControls(this))
            {
                MessageBox.Show("控件内容不合法");
                return;
            }
            Apply apply = getApplyInfo();
            try
            {
                if (this.isUpdate)
                {
                    ApplyDao.Update(apply);
                }
                else
                {
                    object id = ApplyDao.Add(apply);
                    MessageBox.Show("当前流水号为 " + id);
                }
                this.isUpdate = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        #endregion

    }
}
