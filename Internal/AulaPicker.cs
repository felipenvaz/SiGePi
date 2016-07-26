using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaDeNegocios;

namespace Internal
{
    public partial class AulaPicker : UserControl
    {
        public string Texto 
        { 
            get { return ckDia.Text; }
            set { ckDia.Text = value; }  
        }
        public bool Checked
        {
            get { return ckDia.Checked; }
            set { ckDia.Checked = value; }
        }

        public DateTimeInterval Interval
        {
            get { return new DateTimeInterval(dtpInicio.Value, dtpFim.Value); }
            set { dtpInicio.Value = value.Start; dtpFim.Value = value.End; }
        }

        public bool Ativado
        {
            set { ckDia.Enabled = dtpInicio.Enabled = dtpFim.Enabled = value; }
        }

        public AulaPicker()
        {
            InitializeComponent();
            dtpInicio.Value = new DateTime(2013, 10, 1, 0, 0, 0, 0);
            dtpFim.Value = new DateTime(2013, 10, 1, 0, 0, 0, 0);
            dtpInicio.Enabled = dtpFim.Enabled = false;
        }

        private void ckDia_CheckedChanged(object sender, EventArgs e)
        {
            dtpInicio.Enabled = dtpFim.Enabled = ckDia.Checked;
        }
    }
}
