using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SfDataGridDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.sfDataGrid1.AutoGenerateColumns = true;
            DataTable dt = new DataTable();
            dt.Columns.Add("IsShipped", typeof(bool));
            dt.Columns["IsShipped"].ColumnName = "Is Shipped";
            dt.Columns.Add("Country", typeof(string));
            dt.Columns.Add("Locked", typeof(bool));

            dt.Rows.Add(new object[] { true, "Germany", false });
            dt.Rows.Add(new object[] { false, "Mexico", false });
            dt.Rows.Add(new object[] { false, "Sweden", true });
            dt.Rows.Add(new object[] { false, "UK", false });
            dt.Rows.Add(new object[] { true, "London", true });
            this.sfDataGrid1.QueryCheckBoxCellStyle += new Syncfusion.WinForms.DataGrid.Events.QueryCheckBoxCellStyleEventHandler(this.SfDataGrid1_QueryCheckBoxCellStyle);
            sfDataGrid1.DataSource = dt;

            sfDataGrid1.CellCheckBoxClick += SfDataGrid1_CellCheckBoxClick;
            sfDataGrid1.Columns["Locked"].Visible = false; ;
        }

        private void SfDataGrid1_CellCheckBoxClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellCheckBoxClickEventArgs e)
        {
            if (e.Column.MappingName == "IsShipped")
            {
                DataRow row = (e.Record as DataRowView).Row;
                e.Cancel = !EnabledCheckRow(row);
            }
        }

        private bool EnabledCheckRow(System.Data.DataRow row)
        {
            if (row == null)
                return false;
            else
                return !Convert.ToBoolean(row["Locked"]);
        }
        private void SfDataGrid1_QueryCheckBoxCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCheckBoxCellStyleEventArgs e)
        {
            var uncheckedHoverBackColor = e.Style.GetType().GetProperty("UncheckedHoverBackColor", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            uncheckedHoverBackColor.SetValue(e.Style, Color.Red);
            var uncheckedHoverBorderColor = e.Style.GetType().GetProperty("UncheckedHoverBorderColor", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            uncheckedHoverBorderColor.SetValue(e.Style, Color.Red);            
        }
    }
}
