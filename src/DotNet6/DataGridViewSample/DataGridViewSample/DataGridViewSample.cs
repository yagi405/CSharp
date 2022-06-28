using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewSample
{
    public partial class DataGridViewSample : Form
    {
        private DataTable _dataTable;
        public DataGridViewSample()
        {
            _dataTable = new DataTable();
            InitializeComponent();
        }

        private string GetConnectionString()
        {
            var builder = new SqlConnectionStringBuilder()
            {
                DataSource = "",
                InitialCatalog = "sample_db",
                UserID = "sa",
                Password = "Pws12345",
                TrustServerCertificate = true,
            };

            return builder.ToString();
        }

        private void DataGridViewSample_Load(object sender, EventArgs e)
        {

            var cmdText = @"
select
    *
from
    社員
order by
    社員番号
";

            using var ada = new SqlDataAdapter(cmdText, GetConnectionString());
            ada.Fill(_dataTable);

            dgvSample.AutoGenerateColumns = false;
            dgvSample.DataSource = _dataTable;
        }

        private void dgvSample_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var rowIndex = e.RowIndex;
            //var columnIndex = e.ColumnIndex;

            //MessageBox.Show($"Row = {rowIndex} Column = {columnIndex}");

            //var dgvRow = dgvSample.Rows[0];
            //MessageBox.Show(dgvRow.Cells[1].Value.ToString());

            if (e.ColumnIndex == 2)
            {
                var dgvRow = dgvSample.Rows[e.RowIndex];
                var id = dgvRow.Cells[0].Value.ToString();
                var name = dgvRow.Cells[1].Value.ToString();
                MessageBox.Show(string.Join(" - ",id,name));
            }
        }

        private void btnRowFilter_Click(object sender, EventArgs e)
        {
            _dataTable.DefaultView.RowFilter = "部門番号 = 10";
        }
    }
}
