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
    public class FaturamentoDataProvider : GeneralDataProvider
    {
        public List<Despesa> GetDespesas()
        {
            SqlConnection conec = _GetConexao();
            List<Despesa> despesas;
            try
            {
                conec.Open();
                despesas = _GetDespesas(_GetCmd(conec));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conec.Close();
            }

            return despesas;
        }
        private List<Despesa> _GetDespesas(SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "GetDespesas";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            List<Despesa> despesas = new List<Despesa>();
            Despesa despesa;
            using (SqlDataReader reader = cmd.ExecuteReader())
                if (reader.HasRows)
                {
                    int IDX_ID = reader.GetOrdinal("Id");
                    int IDX_DESCRICAO = reader.GetOrdinal("Descricao");
                    int IDX_VALOR = reader.GetOrdinal("Valor");
                    int IDX_DATA = reader.GetOrdinal("Data");

                    while (reader.Read())
                    {
                        despesa = new Despesa();
                        despesa.Id = reader.GetInt32(IDX_ID);
                        if(!reader.IsDBNull(IDX_DESCRICAO))
                            despesa.Descricao = reader.GetString(IDX_DESCRICAO);
                        despesa.Valor = reader.GetDecimal(IDX_VALOR);
                        despesa.Data = reader.GetDateTime(IDX_DATA);

                        despesas.Add(despesa);
                    }
                }



            return despesas;
        }
        public int InserirDespesa(Despesa despesa)
        {
            SqlConnection conec = _GetConexao();
            int id;
            try
            {
                conec.Open();
                id = _InserirDespesa(_GetCmd(conec), despesa);
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
        private int _InserirDespesa(SqlCommand cmd, Despesa despesa)
        {
            
            cmd.CommandText = "InserirDespesa";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            #region Parametros
            SqlParameter param;
            if (!string.IsNullOrEmpty(despesa.Descricao))
            {
                param = new SqlParameter("@Descricao", despesa.Descricao);
                cmd.Parameters.Add(param);
            }
            param = new SqlParameter("@Valor", despesa.Valor);
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Data", despesa.Data);
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Id", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            #endregion

            cmd.ExecuteNonQuery();

            int id = (int)(param.Value);

            return id;
        }
        public void RemoverDespesa(int id)
        {
            SqlConnection conec = _GetConexao();
            
            try
            {
                conec.Open();
                _RemoverDespesa(_GetCmd(conec), id);
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
        private void _RemoverDespesa(SqlCommand cmd, int id)
        {
            cmd.CommandText = "RemoverDespesa";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter("@Id", id);
            cmd.Parameters.Add(param);

            cmd.ExecuteNonQuery();
        }
    }
}
