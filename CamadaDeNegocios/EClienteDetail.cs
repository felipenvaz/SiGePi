using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeNegocios
{
    [Flags]
    public enum EClienteDetail
    {
        Nenhum = 0x0,
        Geral = 0x1,
        Aulas = 0x2,
        Pagamentos = 0x4,
        Telefones = 0x8,
    }
}
