using CamadaDeDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeNegocios.Impl
{
    public class ServicesProvider : IDisposable
    {
        #region Cliente
        public int InserirCliente(Cliente cliente)
        {
            int id;
            using (ClienteDataProvider prov = new ClienteDataProvider())
                id = prov.InserirCliente(cliente);

            return id;
        }

        public void RemoverCliente(int idCliente)
        {
            using (ClienteDataProvider prov = new ClienteDataProvider())
                prov.RemoverCliente(idCliente);
        }

        public List<Cliente> GetClientes(EClienteDetail filtro)
        {
            List<Cliente> clientes;

            using (ClienteDataProvider prov = new ClienteDataProvider())
                clientes = prov.GetClientes(filtro);

            return clientes;
        }

        public List<Cliente> GetClientes(int id, EClienteDetail filtro)
        {
            List<Cliente> clientes;

            using (ClienteDataProvider prov = new ClienteDataProvider())
                clientes = prov.GetClientes(id, filtro);

            return clientes;
        }

        public void AtualizarCliente(Cliente cliente)
        {
            using (ClienteDataProvider prov = new ClienteDataProvider())
                prov.AtualizarCliente(cliente);
        } 
        #endregion
        #region Despesas
        public int InserirDespesa(Despesa despesa)
        {
            int id;

            using (FaturamentoDataProvider prov = new FaturamentoDataProvider())
                id = prov.InserirDespesa(despesa);

            return id;
        }
        public void RemoverDespesa(int id)
        {
            using (FaturamentoDataProvider prov = new FaturamentoDataProvider())
                prov.RemoverDespesa(id);
        }
        public List<Despesa> GetDespesas()
        {
            List<Despesa> despesas;

            using (FaturamentoDataProvider prov = new FaturamentoDataProvider())
                despesas = prov.GetDespesas();

            return despesas;
        }
        #endregion
        public void Dispose()
        {

        }
    }
}
