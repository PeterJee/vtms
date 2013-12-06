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
    public partial class GrantForm : BaseForm
    {
        #region 窗口初始化事件
        /// <summary>
        /// 窗口初始化事件，初始化时启动摄像头
        /// </summary>
        public GrantForm()
        {
            InitializeComponent();
            base.FunctionBtn.Text = "授权更改";
        }
        #endregion
        protected override void SetVehicleInfo(Vehicle vehicle)
        {
            base.SetVehicleInfo(vehicle);
            if (vehicle.Isgrant || !vehicle.Isprinted)
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
            vehicle.Isgrant = true;
            vehicle.GrantDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            vehicle.Granter = LoginForm.user;
            return vehicle;
        }
    }
}
