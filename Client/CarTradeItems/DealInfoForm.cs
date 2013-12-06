using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VTMS.Model.Entities;
namespace VTMS.CarTradeItems
{
    public partial class DealInfoForm : ResizableForm
    {
        public DealInfoForm()
        {
            InitializeComponent();
        }
        public DealInfoForm(Vehicle vehicle)
        {
            InitializeComponent();
            if (vehicle == null)
                return;
            if (vehicle.Saver != null)
            {
                this.saver.Text = vehicle.Saver.UsersName;
                this.saveDate.Text = vehicle.SaveDate.ToString("yyyy年MM月dd日");
            }

            if (vehicle.Recorder != null)
            {
                this.recorder.Text = vehicle.Recorder.UsersName;
                this.recordDate.Text = vehicle.RecordDate.ToString("yyyy年MM月dd日");
            }

            if (vehicle.Charger != null)
            {
                this.charger.Text = vehicle.Charger.UsersName;
                this.chargeDate.Text = vehicle.ChargeDate.ToString("yyyy年MM月dd日");
            }

            if (vehicle.Refunder != null)
            {
                this.refunder.Text = vehicle.Refunder.UsersName;
                this.refundDate.Text = vehicle.RefundDate.ToString("yyyy年MM月dd日");
            }

            if (vehicle.Printer != null)
            {
                this.printer.Text = vehicle.Printer.UsersName;
                this.printDate.Text = vehicle.PrintDate.ToString("yyyy年MM月dd日");
            }

            if (vehicle.Granter != null)
            {
                this.granter.Text = vehicle.Granter.UsersName;
                this.grantDate.Text = vehicle.GrantDate.ToString("yyyy年MM月dd日");
            }
        }

        private void DealInfoForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
