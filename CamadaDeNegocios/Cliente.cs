using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeNegocios
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Profissao { get; set; }
        public string QuemIndicou { get; set; }
        public EComoConheceu ComoConheceu { get; set; }
        public string PraticaAtividade { get; set; }
        public string Medicacao { get; set; }
        public ERiscos Riscos { get; set; }
        public string Doenca { get; set; }
        public string Dor { get; set; }
        public string Objetivo { get; set; }
        public string ExamesComplementares { get; set; }
        public string Observacao { get; set; }

        public Dictionary<EDias, DateTimeInterval> Aulas { get; set; }

        public EPes Pes { get; set; }
        public EJoelhos Joelhos { get; set; }
        public EPelve Pelve { get; set; }
        public EColuna Coluna { get; set; }
        public EOmbros Ombros { get; set; }
        public ECabeca Cabeca { get; set; }

        public List<Pagamento> Pagamentos { get; set; }

        #region Custom
        public DateTime UltimoPagamento 
        {
            get
            {
                DateTime ultimo = DateTime.MinValue;

                if (!Pagamentos.IsNullOrEmpty())
                {
                    foreach (var pag in Pagamentos)
                        if (pag.Data > ultimo)
                            ultimo = pag.Data;
                }

                return ultimo;
            } 
        }
        #endregion
    }

    [Flags]
    public enum EComoConheceu
    { 
        Nenhum = 0x0,
        Internet = 0x1,
        Folder = 0x2,
        Amigos = 0x4,
        Placa = 0x8
    }

    [Flags]
    public enum ERiscos
    {
        Nenhum = 0x0,
        Fuma = 0x1,
        Bebe = 0x2,
        Hipertensao = 0x4,
    }

    public class ClienteWeb {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Profissao { get; set; }
        public string QuemIndicou { get; set; }
        public string PraticaAtividade { get; set; }
        public string Medicacao { get; set; }
        public string Doenca { get; set; }
        public string Dor { get; set; }
        public string Objetivo { get; set; }
        public string ExamesComplementares { get; set; }
        public string Observacao { get; set; }
    }
}
