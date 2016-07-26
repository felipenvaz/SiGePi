using CamadaDeNegocios;
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
    public partial class RegistrarPagamento : Form
    {
        public Pagamento Pagamento { get; set; }

        public RegistrarPagamento(int idCliente)
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int valor;

            if (int.TryParse(mtxtValor.Text, out valor))
            {
                Pagamento = new Pagamento() { Valor = valor, Data = dateTimePicker1.Value };
                this.Close();
            }
            else
                label1.ForeColor = Color.Red;
            
        }
    }
}
