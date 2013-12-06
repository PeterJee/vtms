using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using VTMS.Common;
using VTMS.Model.Entities;
using VTMS.Access;

namespace VTMS.SystemManagement
{
    public partial class VehicleTypeForm : Office2007Form
    {
        Vehicletype vehicleType;
        public VehicleTypeForm()
        {
            InitializeComponent();
            this.dataGridView.AutoGenerateColumns = false;
        }

        private void VehicleTypeForm_Load(object sender, EventArgs e)
        {
            this.dataGridView.DataSource = VehicletypeDao.Load();
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            string id = this.dataGridView.Rows[e.RowIndex].Cells["IdColumn"].Value.ToString();
            string button = this.dataGridView.Columns[e.ColumnIndex].HeaderText;
            if (button.Equals("激活"))
            {
                Vehicletype vehicleType = VehicletypeDao.Get(id);
                vehicleType.Isactive = true;

                VehicletypeDao.UpdateVehicletype(vehicleType);
            }
            else if (button.Equals("删除"))
            {
                Vehicletype vehicleType = VehicletypeDao.Get(id);
                vehicleType.Isactive = false;

                VehicletypeDao.UpdateVehicletype(vehicleType);
            }
            else
            {
                return;
            }
            this.dataGridView.DataSource = VehicletypeDao.Load();
        }

        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id = this.dataGridView.Rows[e.RowIndex].Cells["IdColumn"].Value.ToString();
            vehicleType = VehicletypeDao.Get(id);
            this.name.Text = vehicleType.Name;
            this.id.Text = id;
        }

        private void clear()
        {
            vehicleType = null;
            this.name.Text = "";
            this.id.Text = "";
            this.id.Focus();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (Utilities.IsNullOrEmpty(this.id.Text) || Utilities.IsNullOrEmpty(this.name.Text))
            {
                MessageUtil.ShowWarning("控件内容不合法！");
                return;
            }
            if (vehicleType != null)
            {
                vehicleType.Name = this.name.Text;
                VehicletypeDao.UpdateVehicletype(vehicleType);
            }
            else
            {
                vehicleType = new Vehicletype();
                vehicleType.Name = this.name.Text;
                vehicleType.Isactive = true;

                VehicletypeDao.AddVehicletype(vehicleType);
            }
            this.dataGridView.DataSource = VehicletypeDao.Load();
            this.clear();
        }

        private void id_Leave(object sender, EventArgs e)
        {
            if (Utilities.IsNullOrEmpty(this.id.Text))
            {
                this.id.Text = VehicletypeDao.GetLatestId();
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.clear();
        }
        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                //添加行号 
                SolidBrush v_SolidBrush = new SolidBrush(dataGridView.RowHeadersDefaultCellStyle.ForeColor);

                int v_LineNo = e.RowIndex + 1;

                string v_Line = v_LineNo.ToString();

                e.Graphics.DrawString(v_Line, e.InheritedRowStyle.Font, v_SolidBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);

            }
            catch (Exception ex)
            {
                //MessageBox.Show("添加行号时发生错误，错误信息：" + ex.Message, "操作失败");
            }
        }
    }
}
