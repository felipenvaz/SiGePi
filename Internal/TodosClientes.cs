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
    public partial class TodosClientes : Form, IRefreshable
    {
        private DataTable _DataTable;
        private DataGridViewRow _SelectedRow;
        private Controle _Controle;

        public TodosClientes(Controle controle)
        {
            InitializeComponent();
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _Controle = controle;
            _Controle.EsconderProgressBar();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _LoadData();
        }
        
        public void RefreshData()
        {
            _LoadData();
        }

        private void _LoadData()
        {
            _Controle.Ocupar();
            if(!bwLoad.IsBusy)
                bwLoad.RunWorkerAsync();
        }

        private void _CreateDataTable()
        {
            if (_DataTable == null)
            {
                _DataTable = new DataTable("Clientes");
                _DataTable.Columns.Add("Id", typeof(int));
                _DataTable.Columns.Add("Nome", typeof(string));
            }
            else
                _DataTable.Clear();

            grid.DataSource = _DataTable;

            grid.Columns["Id"].Visible = false;
        }

        private void _FillDataTable(List<Cliente> clientes)
        {
            _DataTable.BeginLoadData();

            if (clientes != null)
                foreach (var c in clientes)
                    _DataTable.Rows.Add(new object[] { c.Id, c.Nome });


            _DataTable.EndLoadData();
        }

        private void _MostrarCliente(DataGridViewRow row)
        {
            _MostrarCliente(row, EMomentoTela.Visualizar);
        }
        private void _MostrarCliente(DataGridViewRow row, EMomentoTela momento)
        {
            EditarCliente showCliente = new EditarCliente((int)row.Cells["Id"].Value, momento, this._Controle);
            _Controle.AddTab(showCliente);
        }

        private void _LoadException(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_SelectedRow != null)
                _MostrarCliente(_SelectedRow);
        }

        private void bwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            using (ServicesProvider clientProv = new ServicesProvider())
                e.Result = clientProv.GetClientes(EClienteDetail.Geral);
        }

        private void bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Cliente> clientes = (List<Cliente>)e.Result;

            if (e.Error == null)
            {
                _CreateDataTable();
                _FillDataTable(clientes);
                _Controle.Desocupar();
            }
            else
                _LoadException(e.Error);
        }

        private void detalharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _MostrarCliente(_SelectedRow);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _MostrarCliente(_SelectedRow, EMomentoTela.Editar);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            editarToolStripMenuItem.Enabled = detalharToolStripMenuItem.Enabled = tsmiRemover.Enabled = _SelectedRow != null;
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

        private void tsmiRemover_Click(object sender, EventArgs e)
        {
            _Controle.Ocupar();
            bwRemover.RunWorkerAsync(_SelectedRow.Cells["Id"].Value);
        }

        private void bwRemover_DoWork(object sender, DoWorkEventArgs e)
        {
            int idCliente = (int)e.Argument;
            using (ServicesProvider clientProv = new ServicesProvider())
               clientProv.RemoverCliente(idCliente);
        }

        private void bwRemover_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                _Controle.Desocupar();
                _LoadData();
            }
            else
                _LoadException(e.Error);
        }
    }
}
