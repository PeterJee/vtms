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
    public partial class RecordForm : BaseForm
    {
        #region 窗口初始化事件
        /// <summary>
        /// 窗口初始化事件，初始化时启动摄像头
        /// </summary>
        public RecordForm()
        {
            InitializeComponent();
            base.FunctionBtn.Text = "合同备案";
        }
        #endregion

        protected override void SetVehicleInfo(Vehicle vehicle)
        {
            base.SetVehicleInfo(vehicle);
            if (vehicle.Isrecorded)
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
            vehicle.Isrecorded = true;
            vehicle.RecordDate = DateTime.ParseExact(VehicleDao.GetCurrentTimestamp(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            vehicle.Recorder = LoginForm.user;
            return vehicle;
        }
    }
}
