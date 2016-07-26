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
    public partial class CadastrarDespesa : Form
    {
        public CadastrarDespesa()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                button1.Enabled = textBox1.Enabled = maskedTextBox1.Enabled = dateTimePicker1.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ServicesProvider prov = new ServicesProvider();
            prov.InserirDespesa(new Despesa() { Descricao = textBox1.Text, Data = dateTimePicker1.Value, Valor = Convert.ToInt32(maskedTextBox1.Text) });
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
