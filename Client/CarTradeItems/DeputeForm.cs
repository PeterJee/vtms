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

namespace VTMS.CarTradeItems
{
    public partial class DeputeForm : ResizableForm
    {
        #region 初始化参数
        private bool isUpdate;
        private Depute vehicle;
        #endregion

        #region 窗口初始化事件
        /// <summary>
        /// 窗口初始化事件，初始化时启动摄像头
        /// </summary>
        public DeputeForm()
        {
            InitializeComponent();
        }
        private void ReTradeForm_Load(object sender, EventArgs e)
        {
            //this.StartVideo();
            this.setControlReadOnly(true);
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

            this.serial.Text = string.Empty;
            this.reserial.Text = string.Empty;
            this.license.Text = string.Empty;
            this.vin.Text = string.Empty;
            this.vehicleType.SelectedValue = "00";
            this.brand.Text = string.Empty;
            this.certificate.Text = string.Empty;
            this.register.Text = string.Empty;
            this.certification.Text = string.Empty;
            this.department.Text = "车管所";
            this.company.SelectedValue = "00";

            this.pictureBox1.Image = null;
            this.pictureBox2.Image = null;
            this.pictureBox3.Image = null;
            this.pictureBox4.Image = null;
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

            this.license.ReadOnly = isEnable;
            this.vin.ReadOnly = isEnable;
            this.vehicleType.Enabled = !isEnable;
            this.brand.ReadOnly = isEnable;
            this.certificate.ReadOnly = isEnable;
            this.register.ReadOnly = isEnable;
            this.certification.ReadOnly = isEnable;
            this.department.ReadOnly = isEnable;
            this.company.Enabled = !isEnable;
            this.retradeBtn.Enabled = !isEnable;
            this.saveBtn.Enabled = !isEnable;
            this.uploadBtn1.Enabled = !isEnable;
            this.uploadBtn2.Enabled = !isEnable;
            this.uploadBtn3.Enabled = !isEnable;
            this.uploadBtn4.Enabled = !isEnable;
            this.deleteBtn1.Enabled = !isEnable;
            this.deleteBtn2.Enabled = !isEnable;
            this.deleteBtn3.Enabled = !isEnable;
            this.deleteBtn4.Enabled = !isEnable;
        }
        #endregion

        #region 将数据库中的信息呈现到界面上
        /// <summary>
        /// 设置卖主信息
        /// </summary>
        /// <param name="originCustomer"></param>
        public void SetOriginCustomer(Customer originCustomer)
        {
            if (originCustomer != null)
            {
                this.originId.Text = originCustomer.UserId;
                this.originName.Text = originCustomer.Name;
                this.originPhone.Text = originCustomer.Phone;
                this.originAddress.Text = originCustomer.Address;
            }
        }
        /// <summary>
        /// 设置买主信息
        /// </summary>
        /// <param name="currentCustomer"></param>
        public void SetCurrentCustomer(Customer currentCustomer)
        {
            if (currentCustomer != null)
            {
                this.currentId.Text = currentCustomer.UserId;
                this.currentName.Text = currentCustomer.Name;
                this.currentPhone.Text = currentCustomer.Phone;
                this.currentAddress.Text = currentCustomer.Address;
            }
        }
        /// <summary>
        /// 设置车辆信息
        /// </summary>
        /// <param name="vehicle"></param>
        public void SetDeputeInfo(Depute vehicle)
        {
            this.reserial.Text = vehicle.Reserial;
            this.originId.Text = vehicle.OriginCustomer.UserId;
            if(vehicle.Originpic != null)
                this.originPic.Image = Utilities.ConvertBytes2Image(vehicle.Originpic);
            this.currentId.Text = vehicle.CurrentCustomer.UserId;
            if (vehicle.Currentpic != null)
                this.currentPic.Image = Utilities.ConvertBytes2Image(vehicle.Currentpic);
            this.license.Text = vehicle.License;
            this.vin.Text = vehicle.Vin;
            this.vehicleType.SelectedValue = vehicle.Vehicletype.Id;
            this.brand.Text = vehicle.Brand;
            this.certificate.Text = vehicle.Certificate;
            this.register.Text = vehicle.Register;
            this.certification.Text = vehicle.Certification;
            this.department.Text = vehicle.Department;
            if(vehicle.Company.Id != null)
                this.company.SelectedValue = vehicle.Company.Id;
            if (vehicle.Firstpic != null)
                this.pictureBox1.Image = Utilities.ConvertBytes2Image(vehicle.Firstpic);
            if (vehicle.Secondpic != null)
                this.pictureBox2.Image = Utilities.ConvertBytes2Image(vehicle.Secondpic);
            if (vehicle.Thirdpic != null)
                this.pictureBox3.Image = Utilities.ConvertBytes2Image(vehicle.Thirdpic);
            if (vehicle.Forthpic != null)
                this.pictureBox4.Image = Utilities.ConvertBytes2Image(vehicle.Forthpic);
            if (vehicle.Istraded)
            {
                this.retradeBtn.Enabled = false;
                this.saveBtn.Enabled = false;
            }
        }
        #endregion

        #region 将界面上的信息保存在数据库中
        /// <summary>
        /// 取得卖主信息
        /// </summary>
        /// <returns></returns>
        public Customer GetOriginCustomer()
        {
            Customer originCustomer = new Customer();
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
            Customer currentCustomer = new Customer();
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
        public Depute GetDeputeInfo()
        {
            if (!this.isUpdate)
            {
                vehicle.Saver = LoginForm.user;

                vehicle.SaveDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            }
            vehicle.Serial = this.serial.Text;
            vehicle.OriginCustomer = GetOriginCustomer();
            vehicle.CurrentCustomer = GetCurrentCustomer();
            vehicle.Invoice = this.reserial.Text;
            vehicle.License = this.license.Text;
            vehicle.Vin = this.vin.Text;

            vehicle.Vehicletype = new Vehicletype();
            vehicle.Vehicletype.Id = this.vehicleType.SelectedValue.ToString();

            vehicle.Brand = this.brand.Text;
            vehicle.Certificate = this.certificate.Text;
            vehicle.Register = this.register.Text;
            vehicle.Certification = this.certification.Text;
            vehicle.Department = this.department.Text;

            vehicle.Company = new Company();
            vehicle.Company.Id = this.company.SelectedValue.ToString();
            
            vehicle.Originpic = Utilities.ConvertImage2Bytes(this.originPic.Image);
            vehicle.Currentpic = Utilities.ConvertImage2Bytes(this.currentPic.Image);

            vehicle.Firstpic = Utilities.ConvertImage2Bytes(this.pictureBox1.Image);
            vehicle.Secondpic = Utilities.ConvertImage2Bytes(this.pictureBox2.Image);
            vehicle.Thirdpic = Utilities.ConvertImage2Bytes(this.pictureBox3.Image);
            vehicle.Forthpic = Utilities.ConvertImage2Bytes(this.pictureBox4.Image);
            
            return vehicle;
        }
        #endregion

        #region 摄像头代码
        /// <summary>
        /// 摄像头启动
        /// </summary>
        public bool StartVideo()
        {
            bool result = false;
            FilterInfoCollection videoDevices;
            VideoCaptureDevice videoSource = null;
            try
            {
                // enumerate video devices
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0 || (videoDevices.Count == 1 && videoDevices[0].Name == "NewImage DocCam"))
                {
                    MessageUtil.ShowWarning("未发现任何摄像头！");
                }
                if (videoDevices.Count > 0)
                {
                    for (int i = 0; i < videoDevices.Count; i++)
                    {
                        if (videoDevices[i].Name != "NewImage DocCam")
                        {
                            videoSource = new VideoCaptureDevice(videoDevices[i].MonikerString);
                            videoSource.DesiredFrameRate = 30;

                            videoSourcePlayer.VideoSource = videoSource;
                            videoSourcePlayer.Start();

                            result = true;
                            break;
                        }
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 关闭时停止摄像头
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
            }
            base.OnClosing(e);
        }
        ///// <summary>
        ///// 获取图像，以便拍照时抓取
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="image"></param>
        //private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        //{
        //    videoImage = (Bitmap)image.Clone();
        //}
        /// <summary>
        /// 抓取卖主头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void originPicBtn_Click(object sender, EventArgs e)
        {
            originPic.Image = videoSourcePlayer.GetCurrentVideoFrame();
        }
        /// <summary>
        /// 抓取卖主头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void currentPicBtn_Click(object sender, EventArgs e)
        {
            currentPic.Image = videoSourcePlayer.GetCurrentVideoFrame();
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
            if (this.serial.ReadOnly || (this.serial.Text.Length != 11 && this.serial.Text.Length != 0))
                return;

            InitComboBox();

            if (Utilities.IsNullOrEmpty(this.serial.Text))
            {
                vehicle = new Depute();

                this.serial.Text = DeputeDao.GetLatestSerial();

                this.setControlReadOnly(false);

                this.isUpdate = false;
            }
            else
            {
                vehicle = DeputeDao.GetBySerial(this.serial.Text);
                if (vehicle != null)
                {
                    this.setControlReadOnly(false);

                    this.isUpdate = true;

                    SetDeputeInfo(vehicle);

                    this.SetOriginCustomer(vehicle.OriginCustomer);

                    this.SetCurrentCustomer(vehicle.CurrentCustomer);
                }
                else
                {
                    this.serial.Focus();
                }
            }
        }
        #endregion

        #region 根据客户号码信息设置控件内容
        /// <summary>
        /// 根据证件号码取得卖主信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void originId_Leave(object sender, EventArgs e)
        {
            if(Utilities.IsNullOrEmpty(this.originId.Text))
                return;
            
            SetOriginCustomer(CustomerDao.GetById(this.originId.Text));
        }
        /// <summary>
        /// 根据证件号码取得买主信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void currentId_Leave(object sender, EventArgs e)
        {

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
            SearchForm sf = new SearchForm();
            sf.SendMessage += new Send(Receive);
            sf.ShowDialog();
        }
        private void Receive(string serial)
        {
            this.serial.Text = serial;
            vehicle = DeputeDao.GetBySerial(serial); 
            if (vehicle != null)
            {
                this.setControlReadOnly(false);

                this.isUpdate = true;

                try
                {
                    SetDeputeInfo(vehicle);
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
        #endregion

        #region 清空按钮点击事件
        /// <summary>
        /// 点击清除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.resetControlContent();
            this.setControlReadOnly(true);
            this.ValidateChildren(ValidationConstraints.None);
            this.serial.Focus();
            //ValidatorManager.degistControls();
        }
        #endregion

        #region 保存按钮点击事件
        /// <summary>
        /// 保存按钮点击，将数据保存至数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.ValidateChildren(ValidationConstraints.Enabled & ValidationConstraints.TabStop & ValidationConstraints.Selectable);
            if (!ValidatorManager.ValidateControls(this))
            {
                MessageBox.Show("控件内容不合法");
                return;
            }
            Customer originInfo = GetOriginCustomer();
            Customer currentInfo = GetCurrentCustomer();
            Depute vehicle = GetDeputeInfo();
            if (this.isUpdate)
            {
                try
                {
                    //CustomerDao.Update(originInfo);
                    //CustomerDao.Update(currentInfo);
                    DeputeDao.UpdateDepute(vehicle);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                try
                {
                    //CustomerDao.Add(originInfo);
                    //CustomerDao.Add(currentInfo);
                    object id = DeputeDao.AddDepute(vehicle);
                    MessageBox.Show("当前流水号为 " + id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            this.resetControlContent();
            this.setControlReadOnly(true);
            this.serial.Focus();
        }
        #endregion

        #region 上传按钮点击事件
        /// <summary>
        /// 证件附件上传按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uploadBtn_Click(object sender, EventArgs e)
        {
            switch ((sender as ButtonX).Name)
            {
                case "uploadBtn1":
                    showImage(pictureBox1);
                    break;
                case "uploadBtn2":
                    showImage(pictureBox2);
                    break;
                case "uploadBtn3":
                    showImage(pictureBox3);
                    break;
                case "uploadBtn4":
                    showImage(pictureBox4);
                    break;
            }
            
        }
        #endregion

        #region 删除按钮点击事件
        /// <summary>
        /// 证件附件删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            switch ((sender as ButtonX).Name)
            {
                case "deleteBtn1":
                    this.pictureBox1.Image = null;
                    break;
                case "deleteBtn2":
                    this.pictureBox2.Image = null;
                    break;
                case "deleteBtn3":
                    this.pictureBox3.Image = null;
                    break;
                case "deleteBtn4":
                    this.pictureBox4.Image = null;
                    break;
            }
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

        #region 摄像头按钮点击事件
        /// <summary>
        /// 摄像头启动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startVediaoBtn_Click(object sender, EventArgs e)
        {
            if (this.StartVideo())
            {
                this.originPicBtn.Enabled = true;
                this.currentPicBtn.Enabled = true;
                this.startVediaoBtn.Visible = false;
                this.stopVideoBtn.Visible = true;
            }
        }/// <summary>
        /// 摄像头停止事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopVedioBtn_Click(object sender, EventArgs e)
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
            }
            this.originPicBtn.Enabled = false;
            this.currentPicBtn.Enabled = false;
            this.startVediaoBtn.Visible = true;
            this.stopVideoBtn.Visible = false;
        }
        #endregion

        #region 挂车交易按钮点击
        /// <summary>
        /// 挂车交易
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void retradeBtn_Click(object sender, EventArgs e)
        {
            this.ValidateChildren(ValidationConstraints.Enabled & ValidationConstraints.TabStop & ValidationConstraints.Selectable);
            if (!ValidatorManager.ValidateControls(this))
            {
                MessageBox.Show("控件内容不合法");
                return;
            }
            Customer originInfo = GetOriginCustomer();
            Customer currentInfo = GetCurrentCustomer();
            Depute vehicle = GetDeputeInfo();

            try
            {
                if (this.isUpdate)
                {
                    DeputeDao.UpdateDepute(vehicle);
                }
                else
                {
                    object id = DeputeDao.AddDepute(vehicle);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("保存二次过户信息时出错，错误信息为："+ex.Message);
                return;
            }

            if (vehicle.Istraded)
            {
                MessageBox.Show("此流水号挂车交易已经结束！");
            }
            
            Vehicle _vehicle = new Vehicle();

            _vehicle.OriginCustomer = GetOriginCustomer();
            _vehicle.CurrentCustomer = GetCurrentCustomer();
            _vehicle.License = this.license.Text;
            _vehicle.Vin = this.vin.Text;

            _vehicle.Vehicletype = new Vehicletype();
            _vehicle.Vehicletype.Id = this.vehicleType.SelectedValue.ToString();

            _vehicle.Brand = this.brand.Text;
            _vehicle.Certificate = this.certificate.Text;
            _vehicle.Register = this.register.Text;
            _vehicle.Certification = this.certification.Text;
            _vehicle.Department = this.department.Text;

            _vehicle.Company = new Company();
            _vehicle.Company.Id = this.company.SelectedValue.ToString();

            _vehicle.Originpic = Utilities.ConvertImage2Bytes(this.originPic.Image);
            _vehicle.Currentpic = Utilities.ConvertImage2Bytes(this.currentPic.Image);

            _vehicle.Firstpic = Utilities.ConvertImage2Bytes(this.pictureBox1.Image);
            _vehicle.Secondpic = Utilities.ConvertImage2Bytes(this.pictureBox2.Image);
            _vehicle.Thirdpic = Utilities.ConvertImage2Bytes(this.pictureBox3.Image);
            _vehicle.Forthpic = Utilities.ConvertImage2Bytes(this.pictureBox4.Image);

            _vehicle.Actual = "0";
            _vehicle.Transactions = "0";

            _vehicle.SaveDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            _vehicle.Saver = vehicle.Saver;

            try
            {
                vehicle.Reserial = VehicleDao.AddVehicle(_vehicle).ToString();
                vehicle.Istraded = true;
                DeputeDao.UpdateDepute(vehicle);
                Clipboard.SetDataObject(vehicle.Reserial);
                MessageBox.Show("过户流水号为：" + vehicle.Reserial + "。此号码已经复制在粘贴板中，可在信息录入界面按Ctrl+V粘贴使用。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("二次过户时出错，错误信息为："+ex.Message);
                return;
            }

            this.resetControlContent();
            this.setControlReadOnly(true);
            this.serial.Focus();
        }
        #endregion

        private void department_Enter(object sender, EventArgs e)
        {
            this.department.SelectionStart = 0;
        }
    }
}
