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
    public partial class RegisterForm : ResizableForm
    {
        #region 初始化参数
        private bool isUpdate;
        private Register register;
        ErrorProvider applyErrorProvider = new ErrorProvider();
        ErrorProvider categoryErrorProvider = new ErrorProvider();
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
            this.apply.Enabled = !flag; 
            this.revoke.Enabled = !flag; 
            this.brand.ReadOnly = flag;
            this.vin.ReadOnly = flag;
            this.obtain.Enabled = !flag; 
            this.purpose.Enabled = !flag; 
            this.ownerName.ReadOnly = flag;
            this.ownerAddress.ReadOnly = flag;
            this.ownerPostcode.ReadOnly = flag;
            this.ownerPhone.ReadOnly = flag;
            this.ownerEmail.ReadOnly = flag;
            this.ownerMobile.ReadOnly = flag;
            this.province.ReadOnly = flag;
            this.department.ReadOnly = flag;
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

        #region 流水号离开事件
        /// <summary>
        /// 当光标焦点至于流水号时，用户回车产生新的流水号或获取流水号对应数据信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_Leave(object sender, EventArgs e)
        {
            if (this.serial.ReadOnly || (this.serial.Text.Length != 11 && this.serial.Text.Length != 0))
                return;

            //InitComboBox();

            if (Utilities.IsNullOrEmpty(this.serial.Text))
            {
                register = new Register();

                this.serial.Text = RegisterDao.GetLatestSerial();

                this.setControlReadOnly(false);

                this.category.Focus();

                this.isUpdate = false;
            }
            else
            {
                register = RegisterDao.GetBySerial(this.serial.Text); 

                if (register != null)
                {
                    this.setControlReadOnly(false);

                    this.isUpdate = true;

                    setRegisterInfo(register);

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
        /// <param name="register"></param>
        private void setRegisterInfo(Register register)
        {
            this.category.Text = register.Category;
            this.license.Text = register.License;
            this.apply.Text = register.Apply;
            this.revoke.Text = register.Revoke;
            this.brand.Text = register.Brand;
            this.vin.Text = register.Vin;
            this.obtain.Text = register.Obtain;
            this.purpose.Text = register.Purpose;
            this.ownerName.Text = register.OwnerName;
            this.ownerAddress.Text = register.OwnerAddress;
            this.ownerPostcode.Text = register.OwnerPostcode;
            this.ownerPhone.Text = register.OwnerPhone;
            this.ownerEmail.Text = register.OwnerEmail;
            this.ownerMobile.Text = register.OwnerMobile;
            this.province.Text = register.Province;
            this.department.Text = register.Department;
            this.agentName.Text = register.AgentName;
            this.agentPhone.Text = register.AgentPhone;
            this.agentPostcode.Text = register.AgentPostcode;
            this.agentAddress.Text = register.AgentAddress;
            this.agentEmail.Text = register.AgentEmail;
            this.handlerName.Text = register.HandlerName;
            this.handlerPhone.Text = register.HandlerPhone;
        }
        #endregion

        #region 获取控件内容
        /// <summary>
        /// 获取控件内容，并设置保存时间和打印时间等信息
        /// </summary>
        /// <returns></returns>
        private Register getRegisterInfo()
        {
            if (!this.isUpdate)
            {
                register.Saver = LoginForm.user.UsersId;

                register.SaveDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            }

            register.Serial = this.serial.Text;
            register.Category = this.category.Text;
            register.License = this.license.Text;
            register.Apply = this.apply.Text;
            register.Revoke = this.revoke.Text;
            register.Brand = this.brand.Text;
            register.Vin = this.vin.Text;
            register.Obtain = this.obtain.Text;
            register.Purpose = this.purpose.Text;
            register.OwnerName = this.ownerName.Text;
            register.OwnerAddress = this.ownerAddress.Text;
            register.OwnerPostcode = this.ownerPostcode.Text;
            register.OwnerPhone = this.ownerPhone.Text;
            register.OwnerEmail = this.ownerEmail.Text;
            register.OwnerMobile = this.ownerMobile.Text;
            register.Province = this.province.Text;
            register.Department = this.department.Text;
            register.AgentName = this.agentName.Text;
            register.AgentPhone = this.agentPhone.Text;
            register.AgentPostcode = this.agentPostcode.Text;
            register.AgentAddress = this.agentAddress.Text;
            register.AgentEmail = this.agentEmail.Text;
            register.HandlerName = this.handlerName.Text;
            register.HandlerPhone = this.handlerPhone.Text;

            return register;
        }
        private Register getPrintInfo()
        {
            if (!this.isUpdate)
            {
                register.Saver = LoginForm.user.UsersId;

                register.SaveDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            }

            register.Serial = this.serial.Text;
            register.Category = this.category.Text;
            register.License = this.license.Text;
            register.Apply = this.apply.Text;
            register.Revoke = this.revoke.Text;
            register.Brand = this.brand.Text;
            register.Vin = this.vin.Text;
            register.Obtain = this.obtain.Text;
            register.Purpose = this.purpose.Text;
            register.OwnerName = this.ownerName.Text;
            register.OwnerAddress = this.ownerAddress.Text;
            register.OwnerPostcode = this.ownerPostcode.Text;
            register.OwnerPhone = this.ownerPhone.Text;
            register.OwnerEmail = this.ownerEmail.Text;
            register.OwnerMobile = this.ownerMobile.Text;
            register.Province = this.province.Text;
            register.Department = this.department.Text;
            register.AgentName = this.agentName.Text;
            register.AgentPhone = this.agentPhone.Text;
            register.AgentPostcode = this.agentPostcode.Text;
            register.AgentAddress = this.agentAddress.Text;
            register.AgentEmail = this.agentEmail.Text;
            register.HandlerName = this.handlerName.Text;
            register.HandlerPhone = this.handlerPhone.Text;

            register.PrintDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            register.Printer = LoginForm.user.UsersId;

            return register;
        }
        #endregion

        #region 窗口初始化
        /// <summary>
        /// 窗口初始化
        /// </summary>
        public RegisterForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.category.SelectedIndex = 0;
            //将所有控件设置为只读状态
            this.setControlReadOnly(true);
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

        #region 清除所有控件内容
        /// <summary>
        /// 清除控件内容
        /// </summary>
        private void clearControlContent()
        {
            this.serial.Text = "";
            this.category.Text = "";
            this.license.Text = "";
            this.apply.Text = "";
            this.revoke.Text = "";
            this.brand.Text = "";
            this.vin.Text = "";
            this.obtain.Text = "";
            this.purpose.Text = "";
            this.ownerName.Text = "";
            this.ownerAddress.Text = "";
            this.ownerPostcode.Text = "";
            this.ownerPhone.Text = "";
            this.ownerEmail.Text = "";
            this.ownerMobile.Text = "";
            this.province.Text = "";
            this.department.Text = "";
            this.agentName.Text = "";
            this.agentPhone.Text = "";
            this.agentPostcode.Text = "";
            this.agentAddress.Text = "";
            this.agentEmail.Text = "";
            this.handlerName.Text = "";
            this.handlerPhone.Text = "";
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
            clearControlContent();
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
            if (!VTMS.ControlLib.ValidatorManager.ValidateControls(this) || (Utilities.IsNullOrEmpty(apply.Text) && apply.Enabled))
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
            Register register = getPrintInfo();
            try
            {
                if (this.isUpdate)
                {
                    RegisterDao.Update(register);
                }
                else
                {
                    object id = RegisterDao.Add(register);
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

                m_objBook = m_objExcel.Workbooks.Open(Dir.FullName + "/Templete/Register.xls", oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                m_objSheets = (Microsoft.Office.Interop.Excel.Sheets)m_objBook.Worksheets;

                m_objSheet = (Microsoft.Office.Interop.Excel._Worksheet)(m_objSheets.get_Item(1));

                // 号牌种类
                m_objRange = m_objSheet.get_Range("D11", oMissing);
                m_objRange.Value = this.category.Text;

                // 号牌号码
                m_objRange = m_objSheet.get_Range("H11", oMissing);
                m_objRange.Value = "辽B" + this.license.Text;

                // 品牌型号
                m_objRange = m_objSheet.get_Range("D12", oMissing);
                m_objRange.Value = this.brand.Text;

                //车辆识别代号
                m_objRange = m_objSheet.get_Range("H12", oMissing);
                m_objRange.Value = this.vin.Text; 

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

                // 省（自治县、直辖市)
                m_objRange = m_objSheet.get_Range("D10", oMissing);
                m_objRange.Value = "                          " + this.province.Text + "                            " + this.department.Text;

                // 代理人姓名、名称
                m_objRange = m_objSheet.get_Range("E6", oMissing);
                m_objRange.Value = this.agentName.Text;

                // 代理人联系电话
                m_objRange = m_objSheet.get_Range("H6", oMissing);
                m_objRange.Value = this.agentPhone.Text;

                // 办理日期
                m_objRange = m_objSheet.get_Range("F18", oMissing);
                m_objRange.Value = DateTime.Today.Year + "        " + DateTime.Today.Month + "        " + DateTime.Today.Day ;


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

        #region 联动事件
        /// <summary>
        /// 申请事项控件验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void apply_Validating(object sender, CancelEventArgs e)
        {
            ComboBoxEx cb = sender as ComboBoxEx;

            if (Utilities.IsNullOrEmpty(cb.Text) && cb.Enabled)
            {
                applyErrorProvider.SetError(cb, "不能为空！");
            }
            else
            {
                applyErrorProvider.Clear();
            }
        }
        /// <summary>
        /// 注销登记与申请事项联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void apply_TextChanged(object sender, EventArgs e)
        {
            if (this.apply.Text.Equals("注销登记"))
            {
                this.revoke.Enabled = true;
            }
            else
            {
                this.revoke.Enabled = false;
                this.revoke.Text = "";
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
            if (Utilities.IsNullOrEmpty(apply.Text) && apply.Enabled)
            {
                applyErrorProvider.SetError(apply, "不能为空！");
            }
            else
            {
                applyErrorProvider.Clear();
            }
            if (!VTMS.ControlLib.ValidatorManager.ValidateControls(this))
            {
                MessageBox.Show("控件内容不合法");
                return;
            }
            Register register = getRegisterInfo();
            try
            {
                if (this.isUpdate)
                {
                    RegisterDao.Update(register);
                }
                else
                {
                    object id = RegisterDao.Add(register);
                    MessageBox.Show("当前流水号为 " + id);
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
