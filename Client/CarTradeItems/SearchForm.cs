using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VTMS.Access;
using VTMS.Model.Entities;
using VTMS.Common;
namespace VTMS.CarTradeItems
{
    public delegate void Send(string info);
    public partial class SearchForm : Form
    {
        public event Send SendMessage;
        public SearchForm()
        {
            InitializeComponent();
            this.dataGridView.AutoGenerateColumns = false;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            //System.Collections.IList list = VehicleDao.GetFirst20Row();
            //DataTable dt = new DataTable();
            //if (list != null)
            //{
            //    dt.Columns.Add("Serial");
            //    dt.Columns.Add("OriginId");
            //    dt.Columns.Add("OriginName");
            //    dt.Columns.Add("CurrentId");
            //    dt.Columns.Add("CurrentName");
            //    dt.Columns.Add("VehicleType");
            //    dt.Columns.Add("License");
            //    dt.Columns.Add("Brand");
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        object[] tmp = (object[])list[i];
            //        object[] o = new object[] { tmp[0], tmp[2], tmp[3], tmp[5], tmp[6], tmp[7], tmp[8], tmp[9] };
            //        dt.Rows.Add(o);
            //    }
            //}
            this.dataGridView.DataSource = VehicleDao.GetFirst20Row().Tables[0];
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //if (Utilities.IsNullOrEmpty(this.serialSearch.Text) && Utilities.IsNullOrEmpty(this.customerId.Text) && Utilities.IsNullOrEmpty(this.license.Text) && Utilities.IsNullOrEmpty(this.customerName.Text))
            //{
            //    SearchForm_Load(sender, e);
            //}
            //System.Collections.IList list = VehicleDao.SearchResult(this.serialSearch.Text, this.customerName.Text, this.customerId.Text, this.license.Text);
            //if (list != null)
            //{
            //    dt.Columns.Add("Serial");
            //    dt.Columns.Add("OriginId");
            //    dt.Columns.Add("OriginName");
            //    dt.Columns.Add("CurrentId");
            //    dt.Columns.Add("CurrentName");
            //    dt.Columns.Add("VehicleType");
            //    dt.Columns.Add("License");
            //    dt.Columns.Add("Brand");
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        object[] tmp = (object[])list[i];
            //        object[] o = new object[] { tmp[0], tmp[2], tmp[3], tmp[5], tmp[6], tmp[7], tmp[8], tmp[9] };
            //        dt.Rows.Add(o);
            //    }
            //}
            this.dataGridView.DataSource = VehicleDao.SearchResult(this.serialSearch.Text, this.customerName.Text, this.customerId.Text, this.license.Text).Tables[0];
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

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dataGridView.Columns[e.ColumnIndex].Name == "SerialColumn")
            {
                SendMessage(dataGridView.Rows[e.RowIndex].Cells["SerialColumn"].Value.ToString());
                this.Close();
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        //        Vehicle vehicle = dataGridView.Rows[e.RowIndex].DataBoundItem as Vehicle;
        //        try
        //        {
        //            if (dataGridView.Columns[e.ColumnIndex].Name == "OriginId")
        //            {
        //                e.Value = vehicle.OriginCustomer.UserId;
        //            }
        //            else if (dataGridView.Columns[e.ColumnIndex].Name == "OriginName")
        //            {
        //                e.Value = vehicle.OriginCustomer.Name;
        //            }
        //            else if (dataGridView.Columns[e.ColumnIndex].Name == "CurrentId")
        //            {
        //                e.Value = vehicle.CurrentCustomer.UserId;
        //            }
        //            else if (dataGridView.Columns[e.ColumnIndex].Name == "CurrentName")
        //            {
        //                e.Value = vehicle.CurrentCustomer.Name;
        //            }
        //            else if (dataGridView.Columns[e.ColumnIndex].Name == "VehicleType")
        //            {
        //                e.Value = vehicle.Vehicletype.Name;
        //            }
        //        }
        //        catch
        //        {
        //            MessageUtil.ShowTips("错误" + vehicle.Serial);
        //        }
        }
    }
}
