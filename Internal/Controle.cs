using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Internal.Properties;
using System.Resources;
using CamadaDeNegocios;

namespace Internal
{
    public partial class Controle : UserControl
    {
        public string FREE = "Realize operações.";
        public string BUSY = "Aguarde, realizando operação.";
        private EStatus _Status;

        public EventHandler BusyChanged { get; set; }
        public TabControl TabControl { get; set; }
        public List<Control> Controles { get; set; }

        public Controle()
        {
            InitializeComponent();
            _Status = EStatus.Livre;
            tsLabel.Text = FREE;
        }

        public void Ocupar()
        {
            _Status = EStatus.Ocupado;
            if (BusyChanged != null)
                BusyChanged(this, null);
            tsLabel.Text = BUSY;
            Application.UseWaitCursor = true;
            tsLabel.Image = Properties.Resources.busy4;
            _ChangeControlsLock(false);
        }
        private void _ChangeControlsLock(bool enabled)
        {
            if (!Controles.IsNullOrEmpty())
                foreach (var c in Controles)
                    c.Enabled = enabled;
        }
        public void Desocupar()
        {
            _Status = EStatus.Livre;
            if (BusyChanged != null)
                BusyChanged(this, null);
            tsLabel.Text = FREE;
            Application.UseWaitCursor = false;
            tsLabel.Image = Properties.Resources.info;
            _ChangeControlsLock(true);
        }
        public void IncrementarProgressBar(int i)
        {
            int resta = (tsProgressBar.Maximum - tsProgressBar.Value);
            tsProgressBar.Value = resta >= i ? tsProgressBar.Value + i : tsProgressBar.Value + resta;
        }
        public void EsconderProgressBar()
        {
            tsProgressBar.Visible = false;
        }
        public void MostrarProgressBar()
        {
            tsProgressBar.Visible = true;
        }
        public void ResetarProgressBar()
        {
            tsProgressBar.Value = 0;
        }
        public bool IsBusy()
        {
            return _Status == EStatus.Ocupado;
        }
        public void AddTab(Form frm)
        {
            if (TabControl != null)
            {
                TabPage oldPage = null;

                if (frm is TodosClientes)
                {
                    if (!TabControl.TabPages.IsNullOrEmpty())
                        foreach (TabPage pag in TabControl.TabPages)
                            if (pag.Controls[0] is TodosClientes)
                                oldPage = pag;
                            
                }
                else if (frm is EditarCliente)
                {
                    if (!TabControl.TabPages.IsNullOrEmpty())
                        foreach (TabPage pag in TabControl.TabPages)
                            if (pag.Controls[0] is EditarCliente && ((EditarCliente)frm).IdCliente == ((EditarCliente)pag.Controls[0]).IdCliente)
                                oldPage = pag;
                }
                else if (frm is Faturamento)
                {
                    if (!TabControl.TabPages.IsNullOrEmpty())
                        foreach (TabPage pag in TabControl.TabPages)
                            if (pag.Controls[0] is Faturamento && ((Faturamento)frm) == ((Faturamento)pag.Controls[0]))
                                oldPage = pag;
                }

                if (oldPage == null)
                {
                    frm.TopLevel = false;
                    frm.Visible = true;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Dock = DockStyle.Fill;
                    frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    TabPage page = new TabPage(frm.Text);
                    page.Controls.Add(frm);
                    TabControl.TabPages.Add(page);
                    TabControl.SelectedTab = page;
                }
                else
                    TabControl.SelectedTab = oldPage;
            }
        }
    }

    public enum EStatus
    {
        Livre = 1,
        Ocupado = 2
    }
}
