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
using System.Collections;
namespace VTMS.CarTradeItems
{
    public partial class PrintInfoForm : ResizableForm
    {        
        private Vehicle vehicle;

        #region 窗口初始化事件
        /// <summary>
        /// 窗口初始化事件，初始化时启动摄像头
        /// </summary>
        public PrintInfoForm()
        {
            InitializeComponent();

            InitComboBox();

            this.setControlReadOnly(true);
            this.serial.Text = VehicleDao.GetCurrentDate();
            this.serial.Select(this.serial.Text.Length, 0);
        }
        public void InitComboBox()
        {
            this.vehicleType.DataSource = VehicletypeDao.LoadAll();
            this.vehicleType.DisplayMember = "Name";
            this.vehicleType.ValueMember = "Id";

            this.company.DataSource = CompanyDao.LoadAll();
            this.company.DisplayMember = "Name";
            this.company.ValueMember = "Id";
        }
        #endregion

        #region 重置控件内容
        private void resetControlContent()
        {
            this.originId.Text = string.Empty;
            this.originName.Text = string.Empty;
            this.originPhone.Text = string.Empty;
            this.originAddress.Text = string.Empty;
            this.originPic.Image = global::VTMS.Properties.Resources.NoneImage;

            this.currentId.Text = string.Empty;
            this.currentName.Text = string.Empty;
            this.currentPhone.Text = string.Empty;
            this.currentAddress.Text = string.Empty;
            this.currentPic.Image = global::VTMS.Properties.Resources.NoneImage;

            this.serial.Text = VehicleDao.GetCurrentDate();
            this.invoice.Text = string.Empty;
            this.license.Text = string.Empty;
            this.vin.Text = string.Empty;
            this.vehicleType.SelectedValue = "01";
            this.brand.Text = string.Empty;
            this.certificate.Text = string.Empty;
            this.register.Text = string.Empty;
            this.certification.Text = string.Empty;
            this.actual.Text = string.Empty;
            this.transactions.Text = string.Empty;
            this.department.Text = "车管所";
            this.company.SelectedValue = "00";
            this.pictureBox1.Image = null;
            this.pictureBox2.Image = null;
            this.pictureBox3.Image = null;
            this.pictureBox4.Image = null;

            this.Isrecorded.Checked = false;
            this.Ischarged.Checked = false;
            this.Isprstringed.Checked = false;
            this.Isrefund.Checked = false;
            this.Isgrant.Checked = false;

            this.vehicle = null;
        }
        #endregion

        #region 设置控件可读状态
        /// <summary>
        /// 窗口初始化时，除了流水号之外所有控件均为只读
        /// </summary>
        /// <param name="isEnable"></param>
        private void setControlReadOnly(bool isEnable)
        {
            this.serial.ReadOnly = !isEnable;

            this.originId.ReadOnly = isEnable;
            this.originName.ReadOnly = isEnable;
            this.originPhone.ReadOnly = isEnable;
            this.originAddress.ReadOnly = isEnable;

            this.currentId.ReadOnly = isEnable;
            this.currentName.ReadOnly = isEnable;
            this.currentPhone.ReadOnly = isEnable;
            this.currentAddress.ReadOnly = isEnable;

            this.invoice.ReadOnly = isEnable;
            this.license.ReadOnly = isEnable;
            this.vin.ReadOnly = isEnable;
            this.vehicleType.Enabled = !isEnable;
            this.brand.ReadOnly = isEnable;
            this.certificate.ReadOnly = isEnable;
            this.register.ReadOnly = isEnable;
            this.certification.ReadOnly = isEnable;
            this.actual.ReadOnly = isEnable;
            this.transactions.ReadOnly = isEnable;
            this.department.ReadOnly = isEnable;
            this.company.Enabled = !isEnable;
            this.printBtn.Enabled = !isEnable;
            this.saveBtn.Enabled = !isEnable;
            this.dealInfoBtn.Enabled = !isEnable;
        }
        #endregion

        #region 将数据库中的信息呈现到界面上
        /// <summary>
        /// 设置卖主信息
        /// </summary>
        /// <param name="originCustomer"></param>
        public void SetOriginCustomer(Customer originCustomer)
        {
            this.originId.Text = originCustomer.UserId;
            this.originName.Text = originCustomer.Name;
            this.originPhone.Text = originCustomer.Phone;
            this.originAddress.Text = originCustomer.Address;
        }
        /// <summary>
        /// 设置买主信息
        /// </summary>
        /// <param name="currentCustomer"></param>
        public void SetCurrentCustomer(Customer currentCustomer)
        {
            this.currentId.Text = currentCustomer.UserId;
            this.currentName.Text = currentCustomer.Name;
            this.currentPhone.Text = currentCustomer.Phone;
            this.currentAddress.Text = currentCustomer.Address;
        }
        /// <summary>
        /// 设置车辆信息
        /// </summary>
        /// <param name="vehicleInfo"></param>
        public void SetVehicleInfo(Vehicle vehicleInfo)
        {
            this.originId.Text = vehicleInfo.OriginCustomer.UserId;
            if (vehicleInfo.Originpic != null)
                this.originPic.Image = Utilities.ConvertBytes2Image(vehicleInfo.Originpic);
            this.currentId.Text = vehicleInfo.CurrentCustomer.UserId;
            if (vehicleInfo.Currentpic != null)
                this.currentPic.Image = Utilities.ConvertBytes2Image(vehicleInfo.Currentpic);
            this.invoice.Text = vehicleInfo.Invoice;
            this.license.Text = vehicleInfo.License;
            this.vin.Text = vehicleInfo.Vin;
            this.vehicleType.SelectedValue = vehicleInfo.Vehicletype.Id;
            this.brand.Text = vehicleInfo.Brand;
            this.certificate.Text = vehicleInfo.Certificate;
            this.register.Text = vehicleInfo.Register;
            this.certification.Text = vehicleInfo.Certification;
            this.actual.Text = vehicleInfo.Actual;
            this.transactions.Text = vehicleInfo.Transactions;
            this.department.Text = vehicleInfo.Department;
            if (vehicleInfo.Company != null)
                this.company.SelectedValue = vehicleInfo.Company.Id;
            this.Isrecorded.Checked = vehicleInfo.Isrecorded;
            this.Ischarged.Checked = vehicleInfo.Ischarged;
            this.Isprstringed.Checked = vehicleInfo.Isprinted;
            this.Isrefund.Checked = vehicleInfo.Isrefund;
            this.Isgrant.Checked = vehicleInfo.Isgrant;
            if (vehicleInfo.Firstpic != null)
                this.pictureBox1.Image = Utilities.ConvertBytes2Image(vehicleInfo.Firstpic);
            if (vehicleInfo.Secondpic != null)
                this.pictureBox2.Image = Utilities.ConvertBytes2Image(vehicleInfo.Secondpic);
            if (vehicleInfo.Thirdpic != null)
                this.pictureBox3.Image = Utilities.ConvertBytes2Image(vehicleInfo.Thirdpic);
            if (vehicleInfo.Forthpic != null)
                this.pictureBox4.Image = Utilities.ConvertBytes2Image(vehicleInfo.Forthpic);
            if (this.Isrecorded.Checked && this.Ischarged.Checked)
            {
                if (vehicleInfo.Isprinted)
                {
                    if (vehicleInfo.Isgrant)
                    {
                        this.printBtn.Enabled = true;
                        this.saveBtn.Enabled = true;
                    }
                    else
                    {
                        this.printBtn.Enabled = false;
                        this.saveBtn.Enabled = false;
                    }
                }
                else
                {
                    this.printBtn.Enabled = true;
                    this.saveBtn.Enabled = true;
                }
            }
            else
            {
                this.printBtn.Enabled = false;
            }
            this.dealInfoBtn.Enabled = true;
        }
        #endregion

        #region 将界面上的信息保存在数据库中
        /// <summary>
        /// 取得卖主信息
        /// </summary>
        /// <returns></returns>
        public Customer GetOriginCustomer()
        {
            Customer originCustomer = null;
            if (!Utilities.IsNullOrEmpty(this.originId.Text))
                originCustomer = CustomerDao.GetById(this.originId.Text);
            if (originCustomer == null)
                originCustomer = new Customer();
            originCustomer.UserId = this.originId.Text;
            originCustomer.Name = this.originName.Text;
            originCustomer.Phone = this.originPhone.Text;
            originCustomer.Address = this.originAddress.Text;

            return originCustomer;
        }
        /// <summary>
        /// 取得买主信息
        /// </summary>
        /// <returns></returns>
        public Customer GetCurrentCustomer()
        {
            Customer currentCustomer = null;
            if (!Utilities.IsNullOrEmpty(this.currentId.Text))
                currentCustomer = CustomerDao.GetById(this.currentId.Text);
            if (currentCustomer == null)
                currentCustomer = new Customer();
            currentCustomer.UserId = this.currentId.Text;
            currentCustomer.Name = this.currentName.Text;
            currentCustomer.Phone = this.currentPhone.Text;
            currentCustomer.Address = this.currentAddress.Text;

            return currentCustomer;
        }
        /// <summary>
        /// 取得车辆信息
        /// </summary>
        /// <returns></returns>
        public Vehicle GetVehicleInfo()
        {
            vehicle.Serial = this.serial.Text;
            vehicle.Invoice = this.invoice.Text;
            vehicle.License = this.license.Text;
            vehicle.Vin = this.vin.Text;

            vehicle.Vehicletype = new Vehicletype();
            vehicle.Vehicletype.Id = this.vehicleType.SelectedValue.ToString();

            vehicle.Brand = this.brand.Text;
            vehicle.Certificate = this.certificate.Text;
            vehicle.Register = this.register.Text;
            vehicle.Certification = this.certification.Text;
            vehicle.Actual = this.actual.Text;
            vehicle.Transactions = this.transactions.Text;
            vehicle.Department = this.department.Text;

            vehicle.Company = new Company();
            vehicle.Company.Id = this.company.SelectedValue.ToString();

            vehicle.Originpic = Utilities.ConvertImage2Bytes(this.originPic.Image);
            vehicle.Currentpic = Utilities.ConvertImage2Bytes(this.currentPic.Image);

            vehicle.Firstpic = Utilities.ConvertImage2Bytes(this.pictureBox1.Image);
            vehicle.Secondpic = Utilities.ConvertImage2Bytes(this.pictureBox2.Image);
            vehicle.Thirdpic = Utilities.ConvertImage2Bytes(this.pictureBox3.Image);
            vehicle.Forthpic = Utilities.ConvertImage2Bytes(this.pictureBox4.Image);

            vehicle.PrintDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            vehicle.Printer = LoginForm.user;

            return vehicle;
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

        #region 流水号焦点离开事件
        /// <summary>
        /// 流水号失去焦点后，如果用户输入了流水号，则根据输入的流水号进行查找，否则生成流水号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serial_Leave(object sender, EventArgs e)
        {
            if (this.serial.ReadOnly || this.serial.Text.Length != 11)
                return;
            vehicle = VehicleDao.GetBySerial(this.serial.Text); ;
            if (vehicle != null)
            {
                this.setControlReadOnly(false);

                InitComboBox();

                SetVehicleInfo(vehicle);

                this.SetOriginCustomer(CustomerDao.GetById(vehicle.OriginCustomer.UserId));

                this.SetCurrentCustomer(CustomerDao.GetById(vehicle.CurrentCustomer.UserId));
            }
            else
            {
                MessageBox.Show("无此数据：流水号" + this.serial.Text);
                this.serial.Focus();
                this.serial.Text = VehicleDao.GetCurrentDate();
                this.serial.Select(this.serial.Text.Length, 0);
            }
        }
        #endregion

        #region 检索按钮点击事件
        /// <summary>
        /// 检索按钮点击时检索保存过的车辆信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBtn_Click(object sender, EventArgs e)
        {
            MessageUtil.ShowTips("本版本暂未开通此功能，请购买正式版本！");
        }
        #endregion

        #region 清空按钮点击事件
        /// <summary>
        /// 点击清除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.setControlReadOnly(true);
            this.ValidateChildren(ValidationConstraints.None);
            this.resetControlContent();
            this.serial.Text = VehicleDao.GetCurrentDate() ;
            this.serial.Focus();
            this.serial.Select(this.serial.Text.Length, 0);
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool saveInfo()
        {
            vehicle = VehicleDao.GetBySerial(this.serial.Text);
            this.ValidateChildren(ValidationConstraints.Enabled & ValidationConstraints.TabStop & ValidationConstraints.Selectable);
            if (!ValidatorManager.ValidateControls(this))
            {
                MessageBox.Show("控件内容不合法");
                return false;
            }
            Customer originInfo = GetOriginCustomer();
            Customer currentInfo = GetCurrentCustomer();
            vehicle = GetVehicleInfo();
            try
            {
                originInfo.Id = vehicle.OriginCustomer.Id;
                currentInfo.Id = vehicle.CurrentCustomer.Id;
                CustomerDao.Update(originInfo);
                CustomerDao.Update(currentInfo);

                vehicle.OriginCustomer = originInfo;
                vehicle.CurrentCustomer = currentInfo;
                VehicleDao.UpdateVehicle(vehicle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        #region 打印按钮点击事件
        /// <summary>
        /// 打印交易票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printBtn_Click(object sender, EventArgs e)
        {
            try
            {
                vehicle = VehicleDao.GetBySerial(this.serial.Text);
                vehicle.Isprinted = true;
                vehicle.Isgrant = false;
                VehicleDao.UpdateVehicle(vehicle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

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

                m_objBook = m_objExcel.Workbooks.Open(Dir.FullName + "/Templete/Input.xls", oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                m_objSheets = (Microsoft.Office.Interop.Excel.Sheets)m_objBook.Worksheets;

                m_objSheet = (Microsoft.Office.Interop.Excel._Worksheet)(m_objSheets.get_Item(1));

                // 开票日期
                m_objRange = m_objSheet.get_Range("B1", oMissing);

                m_objRange.Value = DateTime.ParseExact(VehicleDao.GetCurrentDate(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy/MM/dd");

                // 开票人
                m_objRange = m_objSheet.get_Range("K19", oMissing);

                m_objRange.Value = LoginForm.user.UsersName;

                // 买 方 单 位 /个人
                m_objRange = m_objSheet.get_Range("C5", oMissing);

                m_objRange.Value = this.currentName.Text;

                // 单位代码/身份证号码

                m_objRange = m_objSheet.get_Range("K5", oMissing);

                m_objRange.Value = this.currentId.Text;

                // 买方单位/个人住址
                m_objRange = m_objSheet.get_Range("C6", oMissing);

                m_objRange.Value = this.currentAddress.Text;

                // 电话
                m_objRange = m_objSheet.get_Range("L6", oMissing);

                m_objRange.Value = this.currentPhone.Text;

                // 卖 方 单 位/ 个人

                m_objRange = m_objSheet.get_Range("C7", oMissing);

                m_objRange.Value = this.originName.Text;

                // 单位代码/身份证号码
                m_objRange = m_objSheet.get_Range("K7", oMissing);

                m_objRange.Value = this.originId.Text;

                // 卖方单位/个人住址
                m_objRange = m_objSheet.get_Range("C8", oMissing);

                m_objRange.Value = this.originAddress.Text;

                // 电话
                m_objRange = m_objSheet.get_Range("L8", oMissing);

                m_objRange.Value = this.originPhone.Text;

                // 车   牌   照   号
                m_objRange = m_objSheet.get_Range("C9", oMissing);

                m_objRange.Value = "辽B." + this.license.Text;

                // 登记证号
                m_objRange = m_objSheet.get_Range("E9", oMissing);

                m_objRange.Value = this.certificate.Text;

                // 车 辆 类 型
                m_objRange = m_objSheet.get_Range("L9", oMissing);

                m_objRange.Value = this.vehicleType.Text;

                // 车架号/车辆识别代码
                m_objRange = m_objSheet.get_Range("C10", oMissing);

                m_objRange.Value = this.vin.Text;

                // 厂牌型号
                m_objRange = m_objSheet.get_Range("E10", oMissing);

                m_objRange.Value = this.brand.Text;

                // 转入地车辆管理所名称
                m_objRange = m_objSheet.get_Range("L10", oMissing);

                m_objRange.Value = this.department.Text;

                // 车价 合 计（大写）
                m_objRange = m_objSheet.get_Range("C11", oMissing);

                m_objRange.Value = this.transactions.Text;

                // 车价 合 计（小写）
                m_objRange = m_objSheet.get_Range("L11", oMissing);

                m_objRange.Value = this.transactions.Text;

                m_objExcel.DisplayAlerts = false;
                m_objSheet.PrintOut();
            }

            catch (Exception ex)
            {
                MessageBox.Show("打印失败，请检查打印机设置。错误信息：" + ex.Message);
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

            this.resetControlContent();
            this.setControlReadOnly(true);
            this.serial.Focus();
            this.serial.Select(this.serial.Text.Length, 0);
        }
        #endregion

        #region 双击附件时浏览图片
        /// <summary>
        /// 打开上传文件对话框，上传证件附件
        /// </summary>
        /// <returns></returns>
        private void showImage(PictureBox pb)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "图像文件(*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read);

                byte[] imageByte = new byte[fs.Length];
                fs.Read(imageByte, 0, imageByte.Length);

                fs.Dispose();
                fs.Close();

                pb.Image = Utilities.ConvertBytes2Image(imageByte);
            }
        }
        /// <summary>
        /// 预览证件附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void view_Image(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;

            //如果未上传证件附件
            if (pb.Image == null)
                return;
            //保存在本地
            FileStream fs = new FileStream("temp.jpg", FileMode.Create);
            byte[] image = Utilities.ConvertImage2Bytes(pb.Image);
            fs.Write(image, 0, image.Length);

            fs.Flush();
            fs.Close();
            //启动图片预览
            ProcessStartInfo psi = new ProcessStartInfo(@"temp.jpg");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }
        #endregion

        private void department_Enter(object sender, EventArgs e)
        {
            this.department.SelectionStart = 0;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.saveInfo();
        }

        private void searchBtn_Click_1(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm();
            sf.SendMessage += new Send(Receive);
            sf.ShowDialog();
        }
        private void Receive(string serial)
        {
            this.serial.Text = serial;
            vehicle = VehicleDao.GetBySerial(serial);
            if (vehicle != null)
            {
                this.setControlReadOnly(false);
                
                try
                {
                    SetVehicleInfo(vehicle);
                }
                catch
                {
                    MessageUtil.ShowWarning("发生错误！");
                }

                this.SetOriginCustomer(vehicle.OriginCustomer);

                this.SetCurrentCustomer(vehicle.CurrentCustomer);
            }
            else
            {
                this.serial.Focus();
            }
        }

        private void dealInfoBtn_Click(object sender, EventArgs e)
        {
            new DealInfoForm(vehicle).ShowDialog();
        }
    }
}
