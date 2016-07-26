using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeNegocios
{
    public enum EPes
    {
        Nenhum = 0,
        Varo = 1,
        Valgo = 2
    }
    public enum EJoelhos
    {
        Nenhum = 0,
        Genuvarum = 1,
        Genuvalgum = 2,
        Genurecurvatum = 3,
        Genuflexum = 4
    }
    public enum EPelve
    {
        Nenhum = 0,
        Rotacao = 1,
        Retroversao = 2,
        Anteversao = 3
    }
    public enum EColuna
    {
        Nenhum = 0,
        HiperlordoseLombar = 1,
        CifoseToracica = 2,
        RetificacaoDaCervical = 3,
        Escoliose = 4
    }
    public enum EOmbros
    {
        Nenhum = 0,
        Vertical = 1,
        Horizontal = 2,
        OmbrosPontusos = 3
    }
    public enum ECabeca
    {
        Nenhum = 0,
        Anteriorizada = 1,
        Posteriorizada = 2,
        Retificada = 3
    }
}
