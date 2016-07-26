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
using System.Windows.Forms.DataVisualization.Charting;

namespace Internal
{
    public partial class Faturamento : Form
    {
        public EMes Mes { get { return _Mes; } }
        public int Ano { get { return _Ano; } }

        private Controle _Controle;
        private EMes _Mes;
        private int _Ano;
        private List<Despesa> _DespesasList;
        private List<Pagamento> _Pagamentos;
        private Dictionary<string, int> _Receitas; // Jan2013
        private Dictionary<string, int> _Despesas;

        public Faturamento(Controle controle) : this(controle, DateTime.Now.Month, DateTime.Now.Year) { }

        public Faturamento(Controle controle, int mes, int ano)
        {
            InitializeComponent();
            _Controle = controle;
            _Controle.BusyChanged += new EventHandler(Busy_Changed);
            this.Text = "Faturamento ";
            _Mes = (EMes)mes;
            _Ano = ano;
            #region ComboBox Mês
            List<Tuple<string, EMes>> meses = new List<Tuple<string, EMes>>();
            foreach (var m in Enum.GetValues(typeof(EMes)))
                meses.Add(new Tuple<string, EMes>(((EMes)m).GetDescription(), (EMes)m));
            meses.RemoveAt(0);
            cbMes.DataSource = meses;
            cbMes.DisplayMember = "Item1";
            cbMes.ValueMember = "Item2";
            cbMes.SelectedValue = (EMes)mes;
            #endregion
            txtAno.Text = ano.ToString();

            #region grafico
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 6;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.Series.Add("2");
            chart1.Series.Add("3");
            #endregion
        }

        protected override void OnLoad(EventArgs e)
        {
            _LoadData();
            base.OnLoad(e);
        }

        private void _LoadData()
        {
            _Controle.Ocupar();
            bwLoadData.RunWorkerAsync();
        }

        #region Operators
        public static bool operator ==(Faturamento A, Faturamento B)
        {
            return A.Ano == B.Ano && A.Mes == B.Mes;
        }

        public static bool operator !=(Faturamento A, Faturamento B)
        {
            return A.Ano != B.Ano || A.Mes != B.Mes;
        }

        public override bool Equals(object obj)
        {
            if (obj is Faturamento)
                return this == (Faturamento)obj;
            return false;
        } 
        #endregion

        private void _Refresh()
        {
            bool livre = !_Controle.IsBusy();

            cbMes.Enabled = txtAno.Enabled = livre;
        }

        private void _LoadException(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        private void _RedrawChart()
        {
            EMes mes = (EMes)cbMes.SelectedValue;
            int ano = Convert.ToInt32(txtAno.Text);
            List<EMes> valores = Enum.GetValues(typeof(EMes)).Cast<EMes>().ToList();

            if (!_Receitas.IsNullOrEmpty())
            {
                Series serie = chart1.Series[0];
                serie.Name = "Receita";
                serie.Points.Clear();
                serie.IsValueShownAsLabel = true;

                int mesInt = (int)mes;
                int anoInt = ano;
                mesInt -= 4;
                if (mesInt < 1)
                {
                    mesInt = 12 + mesInt;
                    anoInt--;
                }

                string key = ((EMes)mesInt).GetDescription() + anoInt;
                for (int i = 1; i < 6; i++)
                {
                    if (_Receitas.ContainsKey(key))
                        serie.Points.AddXY(i, _Receitas[key]);
                    else
                        serie.Points.AddXY(i, 0);

                    if (mesInt == valores.Count - 1)
                    {
                        mesInt = 1; anoInt++;
                    }
                    else
                        mesInt++;

                    key = ((EMes)mesInt).GetDescription() + anoInt;
                }
            }
            if (!_Despesas.IsNullOrEmpty())
            {
                Series serie = chart1.Series[1];
                serie.Name = "Despesa";
                serie.Points.Clear();
                serie.IsValueShownAsLabel = true;
                serie.Color = Color.Green;

                int mesInt = (int)mes;
                int anoInt = ano;
                mesInt -= 4;
                if (mesInt < 1)
                {
                    mesInt = 12 + mesInt;
                    anoInt--;
                }

                string key = ((EMes)mesInt).GetDescription() + anoInt;
                for (int i = 1; i < 6; i++)
                {
                    if (_Despesas.ContainsKey(key))
                        serie.Points.AddXY(i, _Despesas[key]);
                    else
                        serie.Points.AddXY(i, 0);

                    if (mesInt == valores.Count - 1)
                    {
                        mesInt = 1; anoInt++;
                    }
                    else
                        mesInt++;

                    key = ((EMes)mesInt).GetDescription() + anoInt;
                }
            }

            if (!_Despesas.IsNullOrEmpty() || !_Receitas.IsNullOrEmpty())
            {
                Series serie = chart1.Series[2];
                serie.Name = "Lucro";
                serie.Points.Clear();
                serie.IsValueShownAsLabel = true;
                serie.Color = Color.Red;

                int mesInt = (int)mes;
                int anoInt = ano;
                mesInt -= 4;
                if (mesInt < 1)
                {
                    mesInt = 12 + mesInt;
                    anoInt--;
                }

                string key = ((EMes)mesInt).GetDescription() + anoInt;
                int lucro = 0;
                for (int i = 1; i < 6; i++)
                {
                    if (_Despesas.ContainsKey(key))
                        lucro -= _Despesas[key];
                    if (_Receitas.ContainsKey(key))
                        lucro += _Receitas[key];

                    serie.Points.AddXY(i, lucro);
                    lucro = 0;

                    if (mesInt == valores.Count - 1)
                    {
                        mesInt = 1; anoInt++;
                    }
                    else
                        mesInt++;

                    key = ((EMes)mesInt).GetDescription() + anoInt;
                }
            }
        }

        private void _OrganizarDicionarios()
        {
            _Receitas = new Dictionary<string, int>();
            string key;
            if (!_Pagamentos.IsNullOrEmpty())
                foreach (var pag in _Pagamentos)
                {
                    key = ((EMes)pag.Data.Month).GetDescription() + pag.Data.Year;

                    if (_Receitas.ContainsKey(key))
                        _Receitas[key] += pag.Valor;
                    else
                        _Receitas[key] = pag.Valor;
                }

            _Despesas = new Dictionary<string, int>();
            if (!_DespesasList.IsNullOrEmpty())
                foreach (var des in _DespesasList)
                {
                    key = ((EMes)des.Data.Month).GetDescription() + des.Data.Year;

                    if (_Despesas.ContainsKey(key))
                        _Despesas[key] += Convert.ToInt32(des.Valor);
                    else
                        _Despesas[key] = Convert.ToInt32(des.Valor);
                }
        }

        #region Events
        private void txtAno_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtAno.Text) && Convert.ToInt32(txtAno.Text) > 2000)
                _RedrawChart();
        }

        private void cbMes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAno.Text) && Convert.ToInt32(txtAno.Text) > 2000)
                _RedrawChart();
        }

        private void chart1_Customize(object sender, EventArgs e)
        {
            List<EMes> valores = Enum.GetValues(typeof(EMes)).Cast<EMes>().ToList();

            string[] range = new string[5];
            int ano = Convert.ToInt32(txtAno.Text.Substring(2, 2));
            int mes = (int)cbMes.SelectedValue;
            mes -= 4;
            if (mes < 1)
            {
                mes = 12 + mes;
                ano--;
            }

            for (int i = 0; i < range.Length; i++)
            {
                range[i] = valores[mes].GetDescription() + "/" + ano;
                if (mes == valores.Count - 1)
                {
                    mes = 1; ano++;
                }
                else
                    mes++;
            }

            for (int i = 0; i < chart1.ChartAreas[0].AxisX.CustomLabels.Count; i++ )
            {
                if (i == 0 || i == chart1.ChartAreas[0].AxisX.CustomLabels.Count - 1)
                    chart1.ChartAreas[0].AxisX.CustomLabels[i].Text = "";
                else
                    chart1.ChartAreas[0].AxisX.CustomLabels[i].Text = range[i - 1];
            }
        }

        private void btnDespesa_Click(object sender, EventArgs e)
        {
            CadastrarDespesa frm = new CadastrarDespesa();
            frm.ShowDialog();
            _LoadData();
        }

        private void btnTodasDespesas_Click(object sender, EventArgs e)
        {
            TodasDespesas frm = new TodasDespesas(_DespesasList);
            frm.ShowDialog();
            _LoadData();
        }

        private void Busy_Changed(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void bwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            using (ServicesProvider prov = new ServicesProvider())
            {
                _DespesasList = prov.GetDespesas();
                e.Result = prov.GetClientes(EClienteDetail.Geral | EClienteDetail.Pagamentos);
            }
        }

        private void bwLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                List<Cliente> clientes = (List<Cliente>)e.Result;

                _Pagamentos = new List<Pagamento>();
                if (!clientes.IsNullOrEmpty())
                    foreach (var c in clientes)
                        if (!c.Pagamentos.IsNullOrEmpty())
                            _Pagamentos.AddRange(c.Pagamentos);
                _OrganizarDicionarios();
                _RedrawChart();
            }
            else
                _LoadException(e.Error);

            _Controle.Desocupar();
        } 
        #endregion
    }
}
