namespace Internal
{
    partial class Faturamento
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.txtAno = new System.Windows.Forms.MaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDespesa = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bwLoadData = new System.ComponentModel.BackgroundWorker();
            this.btnTodasDespesas = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(3, 3);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(60, 21);
            this.cbMes.TabIndex = 0;
            this.cbMes.SelectedValueChanged += new System.EventHandler(this.cbMes_SelectedValueChanged);
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(69, 4);
            this.txtAno.Mask = "0000";
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(29, 20);
            this.txtAno.TabIndex = 1;
            this.txtAno.TextChanged += new System.EventHandler(this.txtAno_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTodasDespesas);
            this.panel1.Controls.Add(this.btnDespesa);
            this.panel1.Controls.Add(this.cbMes);
            this.panel1.Controls.Add(this.txtAno);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(508, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(101, 404);
            this.panel1.TabIndex = 2;
            // 
            // btnDespesa
            // 
            this.btnDespesa.Location = new System.Drawing.Point(14, 30);
            this.btnDespesa.Name = "btnDespesa";
            this.btnDespesa.Size = new System.Drawing.Size(75, 36);
            this.btnDespesa.TabIndex = 2;
            this.btnDespesa.Text = "Cadastrar Despesa";
            this.btnDespesa.UseVisualStyleBackColor = true;
            this.btnDespesa.Click += new System.EventHandler(this.btnDespesa_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(508, 404);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            this.chart1.Customize += new System.EventHandler(this.chart1_Customize);
            // 
            // bwLoadData
            // 
            this.bwLoadData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwLoadData_DoWork);
            this.bwLoadData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwLoadData_RunWorkerCompleted);
            // 
            // btnTodasDespesas
            // 
            this.btnTodasDespesas.Location = new System.Drawing.Point(14, 72);
            this.btnTodasDespesas.Name = "btnTodasDespesas";
            this.btnTodasDespesas.Size = new System.Drawing.Size(75, 36);
            this.btnTodasDespesas.TabIndex = 3;
            this.btnTodasDespesas.Text = "Despesas";
            this.btnTodasDespesas.UseVisualStyleBackColor = true;
            this.btnTodasDespesas.Click += new System.EventHandler(this.btnTodasDespesas_Click);
            // 
            // Faturamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 404);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Name = "Faturamento";
            this.Text = "Faturamento";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.MaskedTextBox txtAno;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnDespesa;
        private System.ComponentModel.BackgroundWorker bwLoadData;
        private System.Windows.Forms.Button btnTodasDespesas;
    }
}