using CamadaDeNegocios;
using CamadaDeNegocios.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Internal
{
    public partial class TodasDespesas : Form
    {
        List<Despesa> _Despesas;
        DataTable _DataTable;
        private DataGridViewRow _SelectedRow;

        public TodasDespesas(List <Despesa> despesas)
        {
            InitializeComponent();
            _Despesas = despesas;
            _CreateDataTable();
            _FillDataTable();
        }

        private void _FillDataTable()
        {
            if (!_Despesas.IsNullOrEmpty())
            {
                _Despesas = _Despesas.OrderByDescending(d => d.Data).ToList();
                foreach (var d in _Despesas)
                    _DataTable.Rows.Add(new object[] { d.Id, d.Descricao, d.Valor + "", d.Data.ToShortDateString() });
            }
        }

        private void _CreateDataTable()
        {
            if (_DataTable == null)
            {
                _DataTable = new DataTable("Despesas");
                _DataTable.Columns.Add("Id", typeof(int));
                _DataTable.Columns.Add("Descricao", typeof(string));
                _DataTable.Columns.Add("Valor", typeof(string));
                _DataTable.Columns.Add("Data", typeof(string));
            }
            else
                _DataTable.Clear();

            grid.DataSource = _DataTable;

        }

        private void TodasDespesas_Load(object sender, EventArgs e)
        {
            grid.Columns["Id"].Visible = false;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            removerToolStripMenuItem.Enabled = _SelectedRow != null;
        }

        private void grid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
                _SelectedRow = grid.Rows[e.RowIndex];
            else
                _SelectedRow = null;
        }

        private void grid_MouseDown(object sender, MouseEventArgs e)
        {
            _SelectedRow = null;
        }

        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SelectedRow != null)
                backgroundWorker1.RunWorkerAsync(_SelectedRow);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)e.Argument;
            ServicesProvider prov = new ServicesProvider();
            prov.RemoverDespesa((int)row.Cells["Id"].Value);
            e.Result = row.Cells["Id"].Value;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _DataTable.Rows.RemoveAt((int)e.Result);
        }
    }
}
