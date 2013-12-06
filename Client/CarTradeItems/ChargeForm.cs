using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using VTMS.Access;
using VTMS.Model.Entities;
using VTMS.Common;
namespace VTMS.CarTradeItems
{
    public partial class ChargeForm : BaseForm
    {
        #region 窗口初始化事件
        /// <summary>
        /// 窗口初始化事件，初始化时启动摄像头
        /// </summary>
        public ChargeForm()
        {
            InitializeComponent();
            base.FunctionBtn.Text = "缴交易费";
        }
        #endregion

        protected override void SetVehicleInfo(Vehicle vehicle)
        {
            base.SetVehicleInfo(vehicle);
            if (vehicle.Ischarged)
            {
                base.FunctionBtn.Text = "退费";
            }
            else
            {
                base.FunctionBtn.Text = "缴费";
            }
            if (vehicle.Charger != null && vehicle.Refunder != null)
            {
                base.FunctionBtn.Enabled = false;
            }
            else
            {
                base.FunctionBtn.Enabled = true;
            }
        }
        protected override Vehicle GetVehicleInfo()
        {
            vehicle = VehicleDao.GetBySerial(vehicle.Serial);
            if (base.FunctionBtn.Text == "缴费")
            {
                vehicle.Ischarged = true;
                vehicle.Isrefund = false;
                vehicle.ChargeDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                vehicle.Charger = LoginForm.user;
                return vehicle;
            }
            else
            {
                vehicle.Isrefund = true;
                vehicle.Ischarged = false;
                vehicle.RefundDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                vehicle.Refunder = LoginForm.user;
                return vehicle;
            }
        }
    }
}