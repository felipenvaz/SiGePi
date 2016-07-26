namespace CeGePi
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.novoClienteBtn = new System.Windows.Forms.Button();
            this.fazerConsultaBtn = new System.Windows.Forms.Button();
            this.faturamentoBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnCloseTab = new System.Windows.Forms.Button();
            this.controle1 = new Internal.Controle();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // novoClienteBtn
            // 
            this.novoClienteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.novoClienteBtn.Location = new System.Drawing.Point(9, 14);
            this.novoClienteBtn.Name = "novoClienteBtn";
            this.novoClienteBtn.Size = new System.Drawing.Size(117, 25);
            this.novoClienteBtn.TabIndex = 1;
            this.novoClienteBtn.Text = "Cadastrar Novo Cliente";
            this.novoClienteBtn.UseVisualStyleBackColor = false;
            this.novoClienteBtn.Click += new System.EventHandler(this.novoClienteButton_Click);
            // 
            // fazerConsultaBtn
            // 
            this.fazerConsultaBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fazerConsultaBtn.Location = new System.Drawing.Point(132, 14);
            this.fazerConsultaBtn.Name = "fazerConsultaBtn";
            this.fazerConsultaBtn.Size = new System.Drawing.Size(116, 25);
            this.fazerConsultaBtn.TabIndex = 2;
            this.fazerConsultaBtn.Text = "Clientes";
            this.fazerConsultaBtn.UseVisualStyleBackColor = false;
            this.fazerConsultaBtn.Click += new System.EventHandler(this.fazerConsultaButton_Click);
            // 
            // faturamentoBtn
            // 
            this.faturamentoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.faturamentoBtn.Location = new System.Drawing.Point(254, 14);
            this.faturamentoBtn.Name = "faturamentoBtn";
            this.faturamentoBtn.Size = new System.Drawing.Size(118, 25);
            this.faturamentoBtn.TabIndex = 3;
            this.faturamentoBtn.Text = "Faturamento";
            this.faturamentoBtn.UseVisualStyleBackColor = false;
            this.faturamentoBtn.Click += new System.EventHandler(this.faturamentoButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(9, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(918, 594);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.btnCloseTab);
            this.panel1.Controls.Add(this.faturamentoBtn);
            this.panel1.Controls.Add(this.novoClienteBtn);
            this.panel1.Controls.Add(this.fazerConsultaBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 49);
            this.panel1.TabIndex = 6;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(879, 9);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(57, 13);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "versão 0.3";
            // 
            // btnCloseTab
            // 
            this.btnCloseTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCloseTab.Location = new System.Drawing.Point(378, 14);
            this.btnCloseTab.Name = "btnCloseTab";
            this.btnCloseTab.Size = new System.Drawing.Size(118, 25);
            this.btnCloseTab.TabIndex = 4;
            this.btnCloseTab.Text = "Fechar Aba";
            this.btnCloseTab.UseVisualStyleBackColor = false;
            this.btnCloseTab.Click += new System.EventHandler(this.btnCloseTab_Click);
            // 
            // controle1
            // 
            this.controle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.controle1.BusyChanged = null;
            this.controle1.Controles = null;
            this.controle1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controle1.Location = new System.Drawing.Point(0, 655);
            this.controle1.Name = "controle1";
            this.controle1.Size = new System.Drawing.Size(939, 24);
            this.controle1.TabControl = null;
            this.controle1.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(939, 679);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.controle1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "SIGePi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button novoClienteBtn;
        private System.Windows.Forms.Button fazerConsultaBtn;
        private System.Windows.Forms.Button faturamentoBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private Internal.Controle controle1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCloseTab;
        private System.Windows.Forms.Label lblVersion;
    }
}

