namespace Simon
{
    partial class frmPuntaje
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
            this.dgvVisor = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVisor
            // 
            this.dgvVisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVisor.Location = new System.Drawing.Point(0, 0);
            this.dgvVisor.Name = "dgvVisor";
            this.dgvVisor.Size = new System.Drawing.Size(264, 442);
            this.dgvVisor.TabIndex = 0;
            // 
            // frmPuntaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 442);
            this.Controls.Add(this.dgvVisor);
            this.MaximizeBox = false;
            this.Name = "frmPuntaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Puntaje";
            this.Shown += new System.EventHandler(this.frmPuntaje_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVisor;
    }
}