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
    public partial class EditarCliente : Form
    {
        private EMomentoTela _Momento;
        private Cliente _Cliente;
        private int _IdCliente;
        private Controle _Controle;
        private List<Pagamento> _Pagamentos;

        public int IdCliente { get { return _IdCliente; } }

        public EditarCliente(Controle controle)
            : this(0, EMomentoTela.Editar, controle)
        { }
        public EditarCliente(int IdCliente, Controle controle)
            : this(IdCliente, EMomentoTela.Visualizar, controle)
        { }
        public EditarCliente(int IdCliente, EMomentoTela momento, Controle controle)
        {
            InitializeComponent();
            _Controle = controle;
            _Controle.BusyChanged += new EventHandler(_OnBusyChanged);
            _Controle.EsconderProgressBar();
            _IdCliente = IdCliente;

            _Momento = momento;
            _FillComboBoxes();
            _Refresh();
        }

        private void _FillComboBoxes()
        {
            #region Pés
            {
                List<Tuple<string, EPes>> tuplas = new List<Tuple<string, EPes>>();
                Tuple<string, EPes> tupla = new Tuple<string, EPes>("", EPes.Nenhum);
                tuplas.Add(tupla);
                tupla = new Tuple<string, EPes>("Varo", EPes.Varo);
                tuplas.Add(tupla);
                tupla = new Tuple<string, EPes>("Valgo", EPes.Valgo);
                tuplas.Add(tupla);

                cbPes.DataSource = tuplas;
                cbPes.DisplayMember = "Item1";
                cbPes.ValueMember = "Item2";
            }
            #endregion
            #region Joelhos
            {
                List<Tuple<string, EJoelhos>> tuplas2 = new List<Tuple<string, EJoelhos>>();
                Tuple<string, EJoelhos> tupla2 = new Tuple<string, EJoelhos>("", EJoelhos.Nenhum);
                tuplas2.Add(tupla2);
                tupla2 = new Tuple<string, EJoelhos>("Genuflexum", EJoelhos.Genuflexum);
                tuplas2.Add(tupla2);
                tupla2 = new Tuple<string, EJoelhos>("Genurecurvatum", EJoelhos.Genurecurvatum);
                tuplas2.Add(tupla2);
                tupla2 = new Tuple<string, EJoelhos>("Genuvalgum", EJoelhos.Genuvalgum);
                tuplas2.Add(tupla2);
                tupla2 = new Tuple<string, EJoelhos>("Genuvarum", EJoelhos.Genuvarum);
                tuplas2.Add(tupla2);

                cbJoelhos.DataSource = tuplas2;
                cbJoelhos.DisplayMember = "Item1";
                cbJoelhos.ValueMember = "Item2";
            }
            #endregion
            #region Pelve
            {
                List<Tuple<string, EPelve>> tuplas = new List<Tuple<string, EPelve>>();
                Tuple<string, EPelve> tupla = new Tuple<string, EPelve>("", EPelve.Nenhum);
                tuplas.Add(tupla);
                tupla = new Tuple<string, EPelve>("Anteversão", EPelve.Anteversao);
                tuplas.Add(tupla);
                tupla = new Tuple<string, EPelve>("Retroversão", EPelve.Retroversao);
                tuplas.Add(tupla);
                tupla = new Tuple<string, EPelve>("Rotação", EPelve.Rotacao);
                tuplas.Add(tupla);

                cbPelve.DataSource = tuplas;
                cbPelve.DisplayMember = "Item1";
                cbPelve.ValueMember = "Item2";
            }
            #endregion
            #region Coluna
            {
                List<Tuple<string, EColuna>> tuplas = new List<Tuple<string, EColuna>>();
                Tuple<string, EColuna> tupla = new Tuple<string, EColuna>("", EColuna.Nenhum);
                tuplas.Add(tupla);
                tupla = new Tuple<string, EColuna>("Cifose Torácica", EColuna.CifoseToracica);
                tuplas.Add(tupla);
                tupla = new Tuple<string, EColuna>("Escoliose", EColuna.Escoliose);
                tuplas.Add(tupla);
                tupla = new Tuple<string, EColuna>("Hiperlordose lombar", EColuna.HiperlordoseLombar);
                tuplas.Add(tupla);
                tupla = new Tuple<string, EColuna>("Retificação da cervical", EColuna.RetificacaoDaCervical);
                tuplas.Add(tupla);

                cbColuna.DataSource = tuplas;
                cbColuna.DisplayMember = "Item1";
                cbColuna.ValueMember = "Item2";
            }
            #endregion
            #region Ombros
            {
                List<Tuple<string, EOmbros>> tuplas = new List<Tuple<string, EOmbros>>();
                Tuple<string, EOmbros> tupla = new Tuple<string, EOmbros>("", EOmbros.Nenhum);
                tuplas.Add(tupla);
                tupla = new Tuple<string, EOmbros>("Horizontal", EOmbros.Horizontal);
                tuplas.Add(tupla);
                tupla = new Tuple<string, EOmbros>("Ombros Pontusos", EOmbros.OmbrosPontusos);
                tuplas.Add(tupla);
                tupla = new Tuple<string, EOmbros>("Vertical", EOmbros.Vertical);
                tuplas.Add(tupla);

                cbOmbros.DataSource = tuplas;
                cbOmbros.DisplayMember = "Item1";
                cbOmbros.ValueMember = "Item2";
            }
            #endregion
            #region Cabeca
            {
                List<Tuple<string, ECabeca>> tuplas = new List<Tuple<string, ECabeca>>();
                Tuple<string, ECabeca> tupla = new Tuple<string, ECabeca>("", ECabeca.Nenhum);
                tuplas.Add(tupla);
                tupla = new Tuple<string, ECabeca>("Anteriorizada", ECabeca.Anteriorizada);
                tuplas.Add(tupla);
                tupla = new Tuple<string, ECabeca>("Posteriorizada", ECabeca.Posteriorizada);
                tuplas.Add(tupla);
                tupla = new Tuple<string, ECabeca>("Retificada", ECabeca.Retificada);
                tuplas.Add(tupla);

                cbCabeca.DataSource = tuplas;
                cbCabeca.DisplayMember = "Item1";
                cbCabeca.ValueMember = "Item2";
            }
            #endregion
        }

        private Cliente _ConstruirCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Id = _IdCliente;
            cliente.Nome = txtNome.Text;
            cliente.Cpf = mtxtCPF.Text;
            cliente.Endereco = txtEndereco.Text;
            #region Telefones
            if (txtTelefone1.Text != string.Empty)
                cliente.Telefone1 = txtTelefone1.Text;
            if (txtTelefone2.Text != string.Empty)
                cliente.Telefone2 = txtTelefone2.Text;
            #endregion
            cliente.Email = txtEmail.Text;
            cliente.DataNascimento = dtpDataNascimento.Value;
            cliente.Profissao = txtProfissao.Text;
            cliente.QuemIndicou = txtQuemIndicou.Text;

            cliente.ComoConheceu = EComoConheceu.Nenhum;
            if (ckInternet.Checked)
                cliente.ComoConheceu |= EComoConheceu.Internet;
            if (ckFolder.Checked)
                cliente.ComoConheceu |= EComoConheceu.Folder;
            if (ckAmigos.Checked)
                cliente.ComoConheceu |= EComoConheceu.Amigos;

            cliente.PraticaAtividade = txtAtividade.Text;
            cliente.Medicacao = txtMedicacao.Text;

            cliente.Riscos = ERiscos.Nenhum;
            if (cbFuma.Checked)
                cliente.Riscos |= ERiscos.Fuma;
            if (cbBebe.Checked)
                cliente.Riscos |= ERiscos.Bebe;
            if (cbHipertensao.Checked)
                cliente.Riscos |= ERiscos.Hipertensao;

            cliente.Doenca = txtDoenca.Text;
            cliente.Dor = txtDor.Text;
            cliente.Objetivo = txtObjetivo.Text;

            cliente.Pes = ((Tuple<string, EPes>)(cbPes.SelectedItem)).Item2;
            cliente.Joelhos = ((Tuple<string, EJoelhos>)(cbJoelhos.SelectedItem)).Item2;
            cliente.Pelve = ((Tuple<string, EPelve>)(cbPelve.SelectedItem)).Item2;
            cliente.Coluna = ((Tuple<string, EColuna>)(cbColuna.SelectedItem)).Item2;
            cliente.Ombros = ((Tuple<string, EOmbros>)(cbOmbros.SelectedItem)).Item2;
            cliente.Cabeca = ((Tuple<string, ECabeca>)(cbCabeca.SelectedItem)).Item2;

            cliente.ExamesComplementares = txtExames.Text;
            cliente.Observacao = txtObservacao.Text;

            cliente.Aulas = new Dictionary<EDias, DateTimeInterval>();
            if (apSegunda.Checked)
                cliente.Aulas[EDias.Segunda] = apSegunda.Interval;
            if (apTerca.Checked)
                cliente.Aulas[EDias.Terca] = apTerca.Interval;
            if (apQuarta.Checked)
                cliente.Aulas[EDias.Quarta] = apQuarta.Interval;
            if (apQuinta.Checked)
                cliente.Aulas[EDias.Quinta] = apQuinta.Interval;
            if (apSexta.Checked)
                cliente.Aulas[EDias.Sexta] = apSexta.Interval;

            cliente.Pagamentos = _Pagamentos;

            return cliente;
        }

        private void _Refresh()
        {
            bool editar = _Momento == EMomentoTela.Editar;
            bool livre = !_Controle.IsBusy();

            btnCancelar.Enabled = editar && livre && _IdCliente > 0;
            btnSalvar.Enabled = editar && livre;
            btnIniciarAlteracao.Enabled = !editar && livre;

            txtEmail.Enabled = txtEndereco.Enabled = txtNome.Enabled =
                txtProfissao.Enabled = txtDoenca.Enabled = txtTelefone1.Enabled =
                txtTelefone2.Enabled = dtpDataNascimento.Enabled = cbBebe.Enabled =
                cbFuma.Enabled = cbHipertensao.Enabled = apSegunda.Ativado =
                apTerca.Ativado = apQuarta.Ativado = apQuinta.Ativado =
                apSexta.Ativado = ckAmigos.Enabled = ckFolder.Enabled = ckInternet.Enabled = ckPlaca.Enabled =
                txtDor.Enabled = txtMedicacao.Enabled = txtAtividade.Enabled = txtObjetivo.Enabled =
                cbPes.Enabled = cbColuna.Enabled = cbJoelhos.Enabled = cbOmbros.Enabled =
                cbPelve.Enabled = cbCabeca.Enabled = txtExames.Enabled = txtObservacao.Enabled =
                txtQuemIndicou.Enabled = mtxtCPF.Enabled =
                editar && livre;


        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _LoadData();
        }

        private void _LoadData()
        {
            if (_IdCliente > 0)
            {
                _Controle.Ocupar();
                bwLoad.RunWorkerAsync(_IdCliente);
            }
        }
        private void _CarregarCliente()
        {
            _Pagamentos = _Cliente.Pagamentos;
            _CarregarClienteAux();
        }
        private void _CarregarCliente(List<Pagamento> pagamentos)
        {
            _Pagamentos = pagamentos;
            _CarregarClienteAux();
        }
        private void _CarregarClienteAux()
        {
            if (_Cliente != null)
            {
                this.Parent.Text = _Cliente.Nome.Substring(0, _Cliente.Nome.Length > 20 ? 20 : _Cliente.Nome.Length);
                txtNome.Text = _Cliente.Nome;
                mtxtCPF.Text = _Cliente.Cpf;
                txtEndereco.Text = _Cliente.Endereco;
                txtTelefone1.Text = _Cliente.Telefone1;
                txtTelefone2.Text = _Cliente.Telefone2;
                txtEmail.Text = _Cliente.Email;
                if (_Cliente.DataNascimento != DateTime.MinValue)
                    dtpDataNascimento.Value = _Cliente.DataNascimento;
                txtProfissao.Text = _Cliente.Profissao;
                txtQuemIndicou.Text = _Cliente.QuemIndicou;

                if ((_Cliente.ComoConheceu & EComoConheceu.Amigos) == EComoConheceu.Amigos)
                    ckAmigos.Checked = true;
                if ((_Cliente.ComoConheceu & EComoConheceu.Internet) == EComoConheceu.Internet)
                    ckInternet.Checked = true;
                if ((_Cliente.ComoConheceu & EComoConheceu.Folder) == EComoConheceu.Folder)
                    ckFolder.Checked = true;
                if ((_Cliente.ComoConheceu & EComoConheceu.Placa) == EComoConheceu.Placa)
                    ckPlaca.Checked = true;

                #region Exames
                txtAtividade.Text = _Cliente.PraticaAtividade;
                txtMedicacao.Text = _Cliente.Medicacao;

                if ((_Cliente.Riscos & ERiscos.Bebe) == ERiscos.Bebe)
                    cbBebe.Checked = true;
                if ((_Cliente.Riscos & ERiscos.Fuma) == ERiscos.Fuma)
                    cbFuma.Checked = true;
                if ((_Cliente.Riscos & ERiscos.Hipertensao) == ERiscos.Hipertensao)
                    cbHipertensao.Checked = true;

                txtDoenca.Text = _Cliente.Doenca;
                txtDor.Text = _Cliente.Dor;
                txtObjetivo.Text = _Cliente.Objetivo;
                txtExames.Text = _Cliente.ExamesComplementares;
                txtObservacao.Text = _Cliente.Observacao;

                string s = ((List<Tuple<string, EPes>>)cbPes.DataSource).Find
                        (t => t.Item2 == _Cliente.Pes).Item1;

                cbPes.SelectedValue = _Cliente.Pes;
                cbJoelhos.SelectedValue = _Cliente.Joelhos;
                cbPelve.SelectedValue = _Cliente.Pelve;
                cbColuna.SelectedValue = _Cliente.Coluna;
                cbOmbros.SelectedValue = _Cliente.Ombros;
                cbCabeca.SelectedValue = _Cliente.Cabeca;
                #endregion

                #region Aulas
                if (!_Cliente.Aulas.IsNullOrEmpty())
                {
                    if (_Cliente.Aulas.ContainsKey(EDias.Segunda))
                    {
                        apSegunda.Checked = true;
                        apSegunda.Interval = _Cliente.Aulas[EDias.Segunda];
                    }
                    if (_Cliente.Aulas.ContainsKey(EDias.Terca))
                    {
                        apTerca.Checked = true;
                        apTerca.Interval = _Cliente.Aulas[EDias.Terca];
                    }
                    if (_Cliente.Aulas.ContainsKey(EDias.Quarta))
                    {
                        apQuarta.Checked = true;
                        apQuarta.Interval = _Cliente.Aulas[EDias.Quarta];
                    }
                    if (_Cliente.Aulas.ContainsKey(EDias.Quinta))
                    {
                        apQuinta.Checked = true;
                        apQuinta.Interval = _Cliente.Aulas[EDias.Quinta];
                    }
                    if (_Cliente.Aulas.ContainsKey(EDias.Sexta))
                    {
                        apSexta.Checked = true;
                        apSexta.Interval = _Cliente.Aulas[EDias.Sexta];
                    }
                }
                #endregion

                #region Pagamentos
                if (!_Pagamentos.IsNullOrEmpty())
                {
                    _Pagamentos = _Cliente.Pagamentos;

                    _Pagamentos = _Pagamentos.OrderByDescending(p => p.Data).ToList();

                    List<Label> labels = new List<Label>() { lblPag1, lblPag2, lblPag3, lblPag4, lblPag5 };
                    for (int i = 0; i < labels.Count; i++)
                        if (i < _Pagamentos.Count)
                        {
                            labels[i].Visible = true;
                            labels[i].Text = "R$" + _Pagamentos[i].Valor + " - " + _Pagamentos[i].Data.ToShortDateString();
                        }
                        else
                            labels[i].Visible = false;

                    if (DateTime.Now > (_Pagamentos[0].Data.AddMonths(1)).AddDays(1))
                    {
                        pbUltimoPagamento.Image = Properties.Resources.error;

                        lblUltimoPagamento.Text = "Já passou a data do novo pagamento!";
                        lblUltimoPagamento2.Text = "";
                    }
                    else
                    {
                        TimeSpan time = _Pagamentos[0].Data.AddMonths(1) - DateTime.Now;
                        if (time.Days <= 5)
                        {
                            pbUltimoPagamento.Image = Properties.Resources.alert_icon;
                            lblUltimoPagamento.Text = "Faltam " + time.Days + " dias para a";
                            lblUltimoPagamento2.Text = "data do próximo pagamento.";
                        }
                        else
                        {
                            pbUltimoPagamento.Image = Properties.Resources.ok;
                            lblUltimoPagamento.Text = "Faltam " + time.Days + " dias para a";
                            lblUltimoPagamento2.Text = "data do próximo pagamento.";
                        }
                    }
                }
                else
                {
                    pbUltimoPagamento.Image = Properties.Resources.alert_icon;
                    lblUltimoPagamento.Text = "Não há nenhum pagamento registrado!";
                    lblUltimoPagamento2.Text = "";
                    List<Label> labels = new List<Label>() { lblPag1, lblPag2, lblPag3, lblPag4, lblPag5 };
                    foreach (var l in labels)
                        l.Visible = false;
                }
                #endregion
            }
        }

        private void _LoadException(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        private void _SalvarPagamentos(List<Pagamento> pagamentos)
        {
            _Pagamentos = pagamentos;
            _Salvar();
        }
        private void _Salvar()
        {
            if (!string.IsNullOrEmpty(txtNome.Text))
            {
                Cliente cliente = _ConstruirCliente();
                _Controle.Ocupar();
                bwCommit.RunWorkerAsync(cliente);
            }
            else
                MessageBox.Show("Não se pode cadastrar um cliente sem nome!", "Cliente sem nome", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region Eventos
        private void _OnBusyChanged(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void EditarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Momento == EMomentoTela.Editar)
                if (Helper.DiscartarMudancas() == DialogResult.No)
                    e.Cancel = true;
        }

        private void bwCommit_DoWork(object sender, DoWorkEventArgs e)
        {
            Cliente cliente = (Cliente)e.Argument;

            using (ServicesProvider clientProv = new ServicesProvider())
            {
                if (_IdCliente <= 0)
                    _IdCliente = clientProv.InserirCliente(cliente);
                else
                    clientProv.AtualizarCliente(cliente);
            }

            _Cliente = cliente;
            _Cliente.Id = _IdCliente;
        }

        private void bwCommit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                _Momento = EMomentoTela.Visualizar;
                _Controle.Desocupar();
                _LoadData();
            }
        }

        private void bwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            int id = (int)e.Argument;

            using (ServicesProvider clientProv = new ServicesProvider())
            {
                List<Cliente> clientes = clientProv.GetClientes(id, EClienteDetail.Geral | EClienteDetail.Aulas | EClienteDetail.Pagamentos | EClienteDetail.Telefones);
                e.Result = clientes;
            }
        }

        private void bwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                List<Cliente> clientes = (List<Cliente>)e.Result;
                if (!clientes.IsNullOrEmpty())
                    _Cliente = clientes[0];
                _CarregarCliente();
                _Controle.Desocupar();
            }

        }

        #region Buttons
        private void iniciarAlteracaoBtn_Click(object sender, EventArgs e)
        {
            this._Momento = EMomentoTela.Editar;
            _Refresh();
        }

        private void salvarBtn_Click(object sender, EventArgs e)
        {
            _Salvar();
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            if (Helper.DiscartarMudancas() == DialogResult.Yes)
            {
                _Momento = EMomentoTela.Visualizar;
                _LoadData();
            }
        }

        private void btnRegistrarPagamento_Click(object sender, EventArgs e)
        {
            if (_Momento == EMomentoTela.Visualizar)
            {
                if (_IdCliente > 0)
                {
                    RegistrarPagamento frm = new RegistrarPagamento(_IdCliente);
                    frm.ShowDialog();
                    if (frm.Pagamento != null)
                    {
                        if (_Pagamentos == null)
                            _Pagamentos = new List<Pagamento>();

                        _Pagamentos.Add(frm.Pagamento);

                        _Salvar();
                    }
                }
                else
                    MessageBox.Show("Cadastre o cliente antes de registrar um pagamento.", "Cliente não cadastrado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Salve o cliente antes de registrar um pagamento.", "Impossível inserir pagamento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnTodosPagamentos_Click(object sender, EventArgs e)
        {
            if (_IdCliente > 0)
            {
                TodosPagamentos frm = new TodosPagamentos(_Cliente);
                frm.Salvar = _SalvarPagamentos;
                frm.ShowDialog();
            }
        }
        #endregion
        #endregion

        public static bool operator ==(EditarCliente A, EditarCliente B)
        {
            return A.IdCliente == B.IdCliente;
        }
        public static bool operator !=(EditarCliente A, EditarCliente B)
        {
            return A.IdCliente != B.IdCliente;
        }
    }
}
