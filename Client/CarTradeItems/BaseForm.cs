using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using VTMS.Access;
using VTMS.Common;
using VTMS.Model.Entities;
using DevComponents.DotNetBar;
using System.Collections;
namespace VTMS.CarTradeItems
{
    public partial class BaseForm : ResizableForm
    {
        protected Vehicle vehicle;

        #region 窗口初始化事件
        /// <summary>
        /// 窗口初始化事件，初始化时启动摄像头
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();
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

        #region 窗口加载事件
        /// <summary>
        /// 窗口加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BaseForm_Load(object sender, EventArgs e)
        {
            this.setControlReadOnly(true);
            this.serial.Text = LoginForm.user.LoginDate;
            this.serial.Select(this.serial.Text.Length, 0);
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
            this.vehicleType.SelectedValue = "00";
            this.brand.Text = string.Empty;
            this.certificate.Text = string.Empty;
            this.register.Text = string.Empty;
            this.certification.Text = string.Empty;
            this.actual.Text = string.Empty;
            this.transactions.Text = string.Empty;
            this.department.Text = string.Empty;
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
            this.FunctionBtn.Enabled = !isEnable;
        }
        #endregion

        #region 将数据库中的信息呈现到界面上
        /// <summary>
        /// 设置卖主信息
        /// </summary>
        /// <param name="originCustomer"></param>
        public void SetOriginCustomer(Customer originCustomer)
        {
            this.originId.Text = originCustomer.UserId.ToString();
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
        protected virtual void SetVehicleInfo(Vehicle vehicleInfo)
        {
            this.originId.Text = vehicleInfo.OriginCustomer.UserId;
            if (vehicleInfo.Originpic != null)
                this.originPic.Image = Utilities.ConvertBytes2Image(vehicleInfo.Originpic);
            this.currentId.Text = vehicleInfo.OriginCustomer.UserId;
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
        }
        #endregion

        #region 获取界面信息
        protected virtual Vehicle GetVehicleInfo()
        {
            return null;
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
                InitComboBox();

                SetVehicleInfo(vehicle);

                this.SetOriginCustomer(vehicle.OriginCustomer);

                this.SetCurrentCustomer(vehicle.CurrentCustomer);
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
            this.serial.Focus();
            this.serial.Select(this.serial.Text.Length, 0);
        }
        #endregion

        #region 提交点击事件
        /// <summary>
        /// 提交点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FunctionBtn_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = GetVehicleInfo();
            try
            {
                VehicleDao.UpdateVehicle(vehicle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

    }
}
