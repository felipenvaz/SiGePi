namespace Internal
{
    partial class AulaPicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ckDia = new System.Windows.Forms.CheckBox();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ckDia
            // 
            this.ckDia.AutoSize = true;
            this.ckDia.Location = new System.Drawing.Point(3, 3);
            this.ckDia.Name = "ckDia";
            this.ckDia.Size = new System.Drawing.Size(80, 17);
            this.ckDia.TabIndex = 0;
            this.ckDia.Text = "checkBox1";
            this.ckDia.UseVisualStyleBackColor = true;
            this.ckDia.CheckedChanged += new System.EventHandler(this.ckDia_CheckedChanged);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpInicio.Location = new System.Drawing.Point(89, 2);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.ShowUpDown = true;
            this.dtpInicio.Size = new System.Drawing.Size(66, 20);
            this.dtpInicio.TabIndex = 1;
            // 
            // dtpFim
            // 
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFim.Location = new System.Drawing.Point(185, 2);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.ShowUpDown = true;
            this.dtpFim.Size = new System.Drawing.Size(66, 20);
            this.dtpFim.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "às";
            // 
            // AulaPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFim);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.ckDia);
            this.Name = "AulaPicker";
            this.Size = new System.Drawing.Size(269, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckDia;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.Label label1;
    }
}
