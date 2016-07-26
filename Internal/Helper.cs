using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Internal
{
    public static class Helper
    {
        public static DialogResult DiscartarMudancas()
        {
            return MessageBox.Show("Deseja descartar as mudanças?", "Descartar Mudanças", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
