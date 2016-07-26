using CamadaDeNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados
{
    public class ClienteDataProvider : GeneralDataProvider
    {
        public int InserirCliente(Cliente cliente)
        {
            int id = 0;
            SqlConnection conec = _GetConexao();
            try
            {
                conec.Open();
                id = _InserirCliente(cliente, _GetCmd(conec));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conec.Close();
            }

            return id;
        }
        private int _InserirCliente(Cliente cliente, SqlCommand cmd)
        {
            cmd.CommandText = "InserirCliente";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            #region Parametros
            SqlParameter param = new SqlParameter("@Nome", cliente.Nome);
            cmd.Parameters.Add(param);
            if (!string.IsNullOrEmpty(cliente.Cpf))
            {
                param = new SqlParameter("@Cpf", cliente.Cpf);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Endereco))
            {
                param = new SqlParameter("@Endereco", cliente.Endereco);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Email))
            {
                param = new SqlParameter("@Email", cliente.Email);
                cmd.Parameters.Add(param);
            }
            if (cliente.DataNascimento != DateTime.MinValue)
            {
                param = new SqlParameter("@DataNascimento", cliente.DataNascimento);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Profissao))
            {
                param = new SqlParameter("@Profissao", cliente.Profissao);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.QuemIndicou))
            {
                param = new SqlParameter("@QuemIndicou", cliente.QuemIndicou);
                cmd.Parameters.Add(param);
            }

            param = new SqlParameter("@ComoConheceu", cliente.ComoConheceu);
            cmd.Parameters.Add(param);

            if (!string.IsNullOrEmpty(cliente.PraticaAtividade))
            {
                param = new SqlParameter("@PraticaAtividade", cliente.PraticaAtividade);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Medicacao))
            {
                param = new SqlParameter("@Medicacao", cliente.Medicacao);
                cmd.Parameters.Add(param);
            }

            param = new SqlParameter("@Riscos", cliente.Riscos);
            cmd.Parameters.Add(param);

            if (!string.IsNullOrEmpty(cliente.Doenca))
            {
                param = new SqlParameter("@Doenca", cliente.Doenca);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Dor))
            {
                param = new SqlParameter("@Dor", cliente.Dor);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Objetivo))
            {
                param = new SqlParameter("@Objetivo", cliente.Objetivo);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.ExamesComplementares))
            {
                param = new SqlParameter("@ExamesComplementares", cliente.ExamesComplementares);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Observacao))
            {
                param = new SqlParameter("@Observacao", cliente.Observacao);
                cmd.Parameters.Add(param);
            }

            param = new SqlParameter("@Pes", (int)cliente.Pes);
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Joelhos", (int)cliente.Joelhos);
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Pelve", (int)cliente.Pelve);
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Coluna", (int)cliente.Coluna);
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Ombros", (int)cliente.Ombros);
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Cabeca", (int)cliente.Cabeca);
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Id", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            #endregion

            cmd.ExecuteNonQuery();

            int id = (int)(param.Value);

            _UpdateTelefones(cmd, cliente, id);
            _UpdateAulas(cmd, cliente, id);
            _UpdatePagamentos(cmd, id, cliente.Pagamentos);

            return id;
        }
        private void _UpdateAulas(SqlCommand cmd, Cliente cliente)
        {
            _UpdateAulas(cmd, cliente, cliente.Id);
        }
        private void _UpdateAulas(SqlCommand cmd, Cliente cliente, int id)
        {
            cmd.CommandText = "UpdateAulas";
            cmd.Parameters.Clear();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@Id", id);
            cmd.Parameters.Add(param);

            #region Segunda
            if (cliente.Aulas.ContainsKey(EDias.Segunda))
            {
                param = new SqlParameter("@Segunda", true);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@SegIn", cliente.Aulas[EDias.Segunda].Start);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@SegFim", cliente.Aulas[EDias.Segunda].End);
                cmd.Parameters.Add(param);
            }
            else
            {
                param = new SqlParameter("@Segunda", false);
                cmd.Parameters.Add(param);
            }
            #endregion
            #region Terca
            if (cliente.Aulas.ContainsKey(EDias.Terca))
            {
                param = new SqlParameter("@Terca", true);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@TerIn", cliente.Aulas[EDias.Terca].Start);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@TerFim", cliente.Aulas[EDias.Terca].End);
                cmd.Parameters.Add(param);
            }
            else
            {
                param = new SqlParameter("@Terca", false);
                cmd.Parameters.Add(param);
            }
            #endregion
            #region Quarta
            if (cliente.Aulas.ContainsKey(EDias.Quarta))
            {
                param = new SqlParameter("@Quarta", true);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@QuaIn", cliente.Aulas[EDias.Quarta].Start);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@QuaFim", cliente.Aulas[EDias.Quarta].End);
                cmd.Parameters.Add(param);
            }
            else
            {
                param = new SqlParameter("@Quarta", false);
                cmd.Parameters.Add(param);
            }
            #endregion
            #region Quinta
            if (cliente.Aulas.ContainsKey(EDias.Quinta))
            {
                param = new SqlParameter("@Quinta", true);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@QuiIn", cliente.Aulas[EDias.Quinta].Start);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@QuiFim", cliente.Aulas[EDias.Quinta].End);
                cmd.Parameters.Add(param);
            }
            else
            {
                param = new SqlParameter("@Quinta", false);
                cmd.Parameters.Add(param);
            }
            #endregion
            #region Sexta
            if (cliente.Aulas.ContainsKey(EDias.Sexta))
            {
                param = new SqlParameter("@Sexta", true);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@SexIn", cliente.Aulas[EDias.Sexta].Start);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@SexFim", cliente.Aulas[EDias.Sexta].End);
                cmd.Parameters.Add(param);
            }
            else
            {
                param = new SqlParameter("@Sexta", false);
                cmd.Parameters.Add(param);
            }
            #endregion

            cmd.ExecuteNonQuery();
        }
        private void _UpdateTelefones(SqlCommand cmd, Cliente cliente)
        {
            _UpdateTelefones(cmd, cliente, cliente.Id);
        }
        private void _UpdateTelefones(SqlCommand cmd, Cliente cliente, int id)
        {
            cmd.CommandText = "UpdateTelefones";
            cmd.Parameters.Clear();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@Id", id);
            cmd.Parameters.Add(param);

            if (!string.IsNullOrEmpty(cliente.Telefone1))
            {
                param = new SqlParameter("@Telefone1", cliente.Telefone1);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Telefone2))
            {
                param = new SqlParameter("@Telefone2", cliente.Telefone2);
                cmd.Parameters.Add(param);
            }

            cmd.ExecuteNonQuery();
        }
        public List<Cliente> GetClientes(EClienteDetail filtro)
        {
            return this.GetClientes(0, filtro);
        }
        public List<Cliente> GetClientes(int idCliente, EClienteDetail filtro)
        {
            List<Cliente> clientes = null;
            SqlConnection conec = _GetConexao();

            try
            {
                conec.Open();
                clientes = _GetClientes(_GetCmd(conec), idCliente, filtro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conec.Close();
            }

            return clientes;
        }
        private List<Cliente> _GetClientes(SqlCommand cmd, int idCliente, EClienteDetail filtro)
        {
            List<Cliente> clientes = new List<Cliente>();

            cmd.CommandText = "GetClientes";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param;
            if (idCliente > 0)
            {
                param = new SqlParameter("@Id", idCliente);
                cmd.Parameters.Add(param);
            }

            param = new SqlParameter("@filtro", (int)filtro);
            cmd.Parameters.Add(param);

            using (SqlDataReader reader = cmd.ExecuteReader())
                if (reader.HasRows)
                {
                    #region Indexers
                    int IDX_ID = reader.GetOrdinal("Id");
                    int IDX_NOME = reader.GetOrdinal("Nome");
                    int IDX_CPF = reader.GetOrdinal("Cpf");
                    int IDX_Endereco = reader.GetOrdinal("Endereco");
                    int IDX_Email = reader.GetOrdinal("Email");

                    int IDX_DataNascimento = reader.GetOrdinal("DataNascimento");

                    int IDX_Profissao = reader.GetOrdinal("Profissao");
                    int IDX_QuemIndicou = reader.GetOrdinal("QuemIndicou");

                    int IDX_ComoConheceu = reader.GetOrdinal("ComoConheceu");

                    int IDX_PraticaAtividade = reader.GetOrdinal("PraticaAtividade");
                    int IDX_Medicacao = reader.GetOrdinal("Medicacao");

                    int IDX_Riscos = reader.GetOrdinal("Riscos");

                    int IDX_Doenca = reader.GetOrdinal("Doenca");
                    int IDX_Dor = reader.GetOrdinal("Dor");
                    int IDX_Objetivo = reader.GetOrdinal("Objetivo");
                    int IDX_ExamesComplementares = reader.GetOrdinal("ExamesComplementares");
                    int IDX_Observacao = reader.GetOrdinal("Observacao");

                    int IDX_Pes = reader.GetOrdinal("Pes");
                    int IDX_Joelhos = reader.GetOrdinal("Joelhos");
                    int IDX_Pelve = reader.GetOrdinal("Pelve");
                    int IDX_Coluna = reader.GetOrdinal("Coluna");
                    int IDX_Ombros = reader.GetOrdinal("Ombros");
                    int IDX_Cabeca = reader.GetOrdinal("Cabeca");
                    #endregion

                    while (reader.Read())
                    {
                        #region Geral
                        Cliente cliente = new Cliente();
                        cliente.Id = reader.GetInt32(IDX_ID);
                        cliente.Nome = reader.GetString(IDX_NOME);

                        if (!reader.IsDBNull(IDX_CPF))
                            cliente.Cpf = reader.GetString(IDX_CPF);

                        if (!reader.IsDBNull(IDX_Endereco))
                            cliente.Endereco = reader.GetString(IDX_Endereco);
                        if (!reader.IsDBNull(IDX_Email))
                            cliente.Email = reader.GetString(IDX_Email);

                        if (!reader.IsDBNull(IDX_DataNascimento))
                            cliente.DataNascimento = reader.GetDateTime(IDX_DataNascimento);

                        if (!reader.IsDBNull(IDX_Profissao))
                            cliente.Profissao = reader.GetString(IDX_Profissao);
                        if (!reader.IsDBNull(IDX_QuemIndicou))
                            cliente.QuemIndicou = reader.GetString(IDX_QuemIndicou);

                        cliente.ComoConheceu = reader.GetFieldValue<EComoConheceu>(IDX_ComoConheceu);

                        if (!reader.IsDBNull(IDX_PraticaAtividade))
                            cliente.PraticaAtividade = reader.GetString(IDX_PraticaAtividade);
                        if (!reader.IsDBNull(IDX_Medicacao))
                            cliente.Medicacao = reader.GetString(IDX_Medicacao);

                        cliente.Riscos = reader.GetFieldValue<ERiscos>(IDX_Riscos);

                        if (!reader.IsDBNull(IDX_Doenca))
                            cliente.Doenca = reader.GetString(IDX_Doenca);
                        if (!reader.IsDBNull(IDX_Dor))
                            cliente.Dor = reader.GetString(IDX_Dor);
                        if (!reader.IsDBNull(IDX_Objetivo))
                            cliente.Objetivo = reader.GetString(IDX_Objetivo);
                        if (!reader.IsDBNull(IDX_ExamesComplementares))
                            cliente.ExamesComplementares = reader.GetString(IDX_ExamesComplementares);
                        if (!reader.IsDBNull(IDX_Observacao))
                            cliente.Observacao = reader.GetString(IDX_Observacao);

                        cliente.Pes = reader.GetFieldValue<EPes>(IDX_Pes);
                        cliente.Joelhos = reader.GetFieldValue<EJoelhos>(IDX_Joelhos);
                        cliente.Pelve = reader.GetFieldValue<EPelve>(IDX_Pelve);
                        cliente.Coluna = reader.GetFieldValue<EColuna>(IDX_Coluna);
                        cliente.Ombros = reader.GetFieldValue<EOmbros>(IDX_Ombros);
                        cliente.Cabeca = reader.GetFieldValue<ECabeca>(IDX_Cabeca);

                        clientes.Add(cliente);
                        #endregion
                    }

                    Cliente c1;

                    if (((filtro & EClienteDetail.Aulas) == EClienteDetail.Aulas)
                        && reader.NextResult())
                    {
                        #region Aulas
                        int IDX_IdCliente = reader.GetOrdinal("IdCliente");
                        int IDX_Dia = reader.GetOrdinal("Dia");
                        int IDX_Inicio = reader.GetOrdinal("Inicio");
                        int IDX_Fim = reader.GetOrdinal("Fim");

                        while (reader.Read())
                        {
                            int IdCliente = reader.GetInt32(IDX_IdCliente);
                            c1 = clientes.Find(c => c.Id == IdCliente);
                            if (c1.Aulas == null)
                                c1.Aulas = new Dictionary<EDias, DateTimeInterval>();
                            c1.Aulas[reader.GetFieldValue<EDias>(IDX_Dia)] =
                                new DateTimeInterval(reader.GetDateTime(IDX_Inicio), reader.GetDateTime(IDX_Fim));
                        }
                        #endregion
                    }
                    if (((filtro & EClienteDetail.Pagamentos) == EClienteDetail.Pagamentos)
                    && reader.NextResult())
                    {
                        #region Pagamentos
                        int IDX_IdCliente = reader.GetOrdinal("IdCliente");
                        int IDX_IdPagamento = reader.GetOrdinal("Id");
                        int IDX_Data = reader.GetOrdinal("Data");
                        int IDX_Valor = reader.GetOrdinal("Valor");

                        while (reader.Read())
                        {
                            int IdCliente = reader.GetInt32(IDX_IdCliente);
                            c1 = clientes.Find(c => c.Id == IdCliente);
                            if (c1.Pagamentos == null)
                                c1.Pagamentos = new List<Pagamento>();
                            c1.Pagamentos.Add(new Pagamento() { Id = reader.GetInt32(IDX_IdPagamento), Data = reader.GetDateTime(IDX_Data), Valor = reader.GetInt32(IDX_Valor) });
                        }
                        #endregion
                    }
                    if (((filtro & EClienteDetail.Telefones) == EClienteDetail.Telefones)
                        && reader.NextResult())
                    {
                        #region Telefones
                        while (reader.Read())
                        {
                            int IDX_IdCliente = reader.GetOrdinal("IdCliente");
                            int IDX_Ordem = reader.GetOrdinal("Ordem");
                            int IDX_Telefone = reader.GetOrdinal("Telefone");

                            int IdCliente = reader.GetInt32(IDX_IdCliente);

                            if (reader.GetInt32(IDX_Ordem) == 1)
                                clientes.Find(c => c.Id == IdCliente).Telefone1 = reader.GetString(IDX_Telefone);
                            else
                                clientes.Find(c => c.Id == IdCliente).Telefone2 = reader.GetString(IDX_Telefone);
                        }
                        #endregion
                    }
                }


            return clientes;
        }
        public void AtualizarCliente(Cliente cliente)
        {
            SqlConnection conec = _GetConexao();
            try
            {
                conec.Open();
                _AtualizarCliente(cliente, _GetCmd(conec));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conec.Close();
            }
        }
        private void _AtualizarCliente(Cliente cliente, SqlCommand cmd)
        {
            cmd.CommandText = "AtualizarCliente";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            #region Parametros
            SqlParameter param = new SqlParameter("@Nome", cliente.Nome);
            cmd.Parameters.Add(param);
            if (!string.IsNullOrEmpty(cliente.Cpf))
            {
                param = new SqlParameter("@Cpf", cliente.Cpf);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Endereco))
            {
                param = new SqlParameter("@Endereco", cliente.Endereco);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Email))
            {
                param = new SqlParameter("@Email", cliente.Email);
                cmd.Parameters.Add(param);
            }
            if (cliente.DataNascimento != DateTime.MinValue)
            {
                param = new SqlParameter("@DataNascimento", cliente.DataNascimento);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Profissao))
            {
                param = new SqlParameter("@Profissao", cliente.Profissao);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.QuemIndicou))
            {
                param = new SqlParameter("@QuemIndicou", cliente.QuemIndicou);
                cmd.Parameters.Add(param);
            }

            param = new SqlParameter("@ComoConheceu", cliente.ComoConheceu);
            cmd.Parameters.Add(param);

            if (!string.IsNullOrEmpty(cliente.PraticaAtividade))
            {
                param = new SqlParameter("@PraticaAtividade", cliente.PraticaAtividade);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Medicacao))
            {
                param = new SqlParameter("@Medicacao", cliente.Medicacao);
                cmd.Parameters.Add(param);
            }

            param = new SqlParameter("@Riscos", cliente.Riscos);
            cmd.Parameters.Add(param);

            if (!string.IsNullOrEmpty(cliente.Doenca))
            {
                param = new SqlParameter("@Doenca", cliente.Doenca);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Dor))
            {
                param = new SqlParameter("@Dor", cliente.Dor);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Objetivo))
            {
                param = new SqlParameter("@Objetivo", cliente.Objetivo);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.ExamesComplementares))
            {
                param = new SqlParameter("@ExamesComplementares", cliente.ExamesComplementares);
                cmd.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(cliente.Observacao))
            {
                param = new SqlParameter("@Observacao", cliente.Observacao);
                cmd.Parameters.Add(param);
            }

            param = new SqlParameter("@Pes", (int)cliente.Pes);
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Joelhos", (int)cliente.Joelhos);
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Pelve", (int)cliente.Pelve);
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Coluna", (int)cliente.Coluna);
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Ombros", (int)cliente.Ombros);
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Cabeca", (int)cliente.Cabeca);
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Id", cliente.Id);
            cmd.Parameters.Add(param);
            #endregion

            cmd.ExecuteNonQuery();

            _UpdateAulas(cmd, cliente);
            _UpdateTelefones(cmd, cliente);
            _UpdatePagamentos(cmd, cliente.Id, cliente.Pagamentos);
        }
        public void RemoverCliente(int idCliente)
        {
            SqlConnection conec = _GetConexao();

            try
            {
                conec.Open();
                _RemoverCliente(_GetCmd(conec), idCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conec.Close();
            }
        }
        private void _RemoverCliente(SqlCommand cmd, int idCliente)
        {
            List<Cliente> clientes = new List<Cliente>();

            cmd.CommandText = "RemoverCliente";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@Id", idCliente);
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }
        public void UpdatePagamentos(int idCliente, List<Pagamento> pagamentos)
        {
            SqlConnection conec = _GetConexao();

            try
            {
                conec.Open();
                _UpdatePagamentos(_GetCmd(conec), idCliente, pagamentos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conec.Close();
            }
        }
        private void _UpdatePagamentos(SqlCommand cmd, int idCliente, List<Pagamento> pagamentos)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "UpdatePagamentos";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@IdCliente", idCliente);
            cmd.Parameters.Add(param);

            if (!pagamentos.IsNullOrEmpty())
            {
                StringBuilder str = new StringBuilder();
                foreach (var pag in pagamentos)
                {
                    str.Append(pag.Data.Year + "-" + pag.Data.Month + "-" + pag.Data.Day + " " + pag.Data.ToLongTimeString() + "|");
                    str.Append(pag.Valor.ToString() + "|");
                }
                param = new SqlParameter("@Dados", str.ToString());
                cmd.Parameters.Add(param);
            }

            cmd.ExecuteNonQuery();
        }
    }
}
