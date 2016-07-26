using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeNegocios
{
    public enum EMes
    {
        Nenhum = 0,

        [DescriptionAttribute("Jan")]
        Janeiro = 1,
        [DescriptionAttribute("Fev")]
        Fevereiro = 2,
        [DescriptionAttribute("Mar")]
        Marco = 3,
        [DescriptionAttribute("Abr")]
        Abril = 4,
        [DescriptionAttribute("Mai")]
        Maio = 5,
        [DescriptionAttribute("Jun")]
        Junho = 6,
        [DescriptionAttribute("Jul")]
        Julho = 7,
        [DescriptionAttribute("Ago")]
        Agosto = 8,
        [DescriptionAttribute("Set")]
        Setembro = 9,
        [DescriptionAttribute("Out")]
        Outubro = 10,
        [DescriptionAttribute("Nov")]
        Novembro = 11,
        [DescriptionAttribute("Dez")]
        Dezembro = 12,
    }
}
