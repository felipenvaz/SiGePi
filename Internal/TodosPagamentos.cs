using CamadaDeNegocios;
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
    public partial class TodosPagamentos : Form
    {
        private DataGridViewRow _SelectedRow;
        private DataTable _Table;
        private List<Pagamento> _Pagamentos;

        public Action<List<Pagamento>> Salvar;

        public TodosPagamentos(Cliente cliente)
        {
            InitializeComponent();
            if (!cliente.Pagamentos.IsNullOrEmpty())
            {
                _CreateTable(cliente.Pagamentos);
                _Pagamentos = cliente.Pagamentos;
            }
        }
        private void _CreateTable(List<Pagamento> pagamentos)
        {
            if (_Table == null)
            {
                _Table = new DataTable();
                _Table.Columns.Add("Id", typeof(int));
                _Table.Columns.Add("Data", typeof(string));
                _Table.Columns.Add("Valor", typeof(string));
            }
            else
                _Table.Clear();

            //_Table.BeginLoadData();
            if (!pagamentos.IsNullOrEmpty())
                foreach (var pag in pagamentos)
                    _Table.Rows.Add(new object[] { pag.Id, pag.Data.ToShortDateString(), "R$ " + pag.Valor.ToString() });

            //_Table.EndLoadData();

            grid.DataSource = _Table;
            grid.Columns["Id"].Visible = false;

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

        private void TodosPagamentos_MouseDown(object sender, MouseEventArgs e)
        {
            _SelectedRow = null;
        }

        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_SelectedRow != null)
            {
                int id = (int)_SelectedRow.Cells["Id"].Value;
                _Pagamentos.RemoveAll(p => p.Id == id);
                if (Salvar != null)
                    Salvar(_Pagamentos);

                _CreateTable(_Pagamentos);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            removerToolStripMenuItem.Enabled = _SelectedRow != null;
        }

    }
}
