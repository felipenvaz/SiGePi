namespace Internal
{
    partial class Controle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controle));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabel,
            this.tsProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 2);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(675, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsLabel
            // 
            this.tsLabel.Image = ((System.Drawing.Image)(resources.GetObject("tsLabel.Image")));
            this.tsLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsLabel.Name = "tsLabel";
            this.tsLabel.Size = new System.Drawing.Size(527, 17);
            this.tsLabel.Spring = true;
            this.tsLabel.Text = "Texto de Teste";
            this.tsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // Controle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Name = "Controle";
            this.Size = new System.Drawing.Size(675, 24);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsLabel;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
    }
}
