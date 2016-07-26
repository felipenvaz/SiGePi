using Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CeGePi
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            controle1.TabControl = tabControl1;
            controle1.EsconderProgressBar();
            controle1.Controles = new List<Control>() { novoClienteBtn, fazerConsultaBtn, faturamentoBtn, btnCloseTab, tabControl1 };
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void novoClienteButton_Click(object sender, EventArgs e)
        {
            EditarCliente frm = new EditarCliente(controle1);
            frm.Text = "Novo Cliente";
            controle1.AddTab(frm);
        }

        private void fazerConsultaButton_Click(object sender, EventArgs e)
        {
            TodosClientes consult = new TodosClientes(controle1);
            controle1.AddTab(consult);
        }

        private void faturamentoButton_Click(object sender, EventArgs e)
        {
            Faturamento frm = new Faturamento(controle1);
            controle1.AddTab(frm);
        }

        private void btnCloseTab_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage != null && e.TabPage.Controls[0] is TodosClientes)
                ((TodosClientes)e.TabPage.Controls[0]).RefreshData();
        }
    }
}
