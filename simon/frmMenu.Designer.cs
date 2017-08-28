namespace Simon
{
    partial class frmMenu
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFacil = new System.Windows.Forms.Button();
            this.btnMedio = new System.Windows.Forms.Button();
            this.btnDificil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNombre = new System.Windows.Forms.ComboBox();
            this.btnProbar = new System.Windows.Forms.Button();
            this.txtDificultad = new System.Windows.Forms.TextBox();
            this.btnPuntaje = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFacil
            // 
            this.btnFacil.BackColor = System.Drawing.SystemColors.Control;
            this.btnFacil.Location = new System.Drawing.Point(96, 82);
            this.btnFacil.Margin = new System.Windows.Forms.Padding(4);
            this.btnFacil.Name = "btnFacil";
            this.btnFacil.Size = new System.Drawing.Size(433, 42);
            this.btnFacil.TabIndex = 0;
            this.btnFacil.Text = "Facil";
            this.btnFacil.UseVisualStyleBackColor = true;
            this.btnFacil.Click += new System.EventHandler(this.btnFacil_Click);
            // 
            // btnMedio
            // 
            this.btnMedio.Location = new System.Drawing.Point(96, 159);
            this.btnMedio.Margin = new System.Windows.Forms.Padding(4);
            this.btnMedio.Name = "btnMedio";
            this.btnMedio.Size = new System.Drawing.Size(433, 42);
            this.btnMedio.TabIndex = 1;
            this.btnMedio.Text = "Medio";
            this.btnMedio.UseVisualStyleBackColor = true;
            this.btnMedio.Click += new System.EventHandler(this.btnMedio_Click);
            // 
            // btnDificil
            // 
            this.btnDificil.Location = new System.Drawing.Point(96, 230);
            this.btnDificil.Margin = new System.Windows.Forms.Padding(4);
            this.btnDificil.Name = "btnDificil";
            this.btnDificil.Size = new System.Drawing.Size(433, 42);
            this.btnDificil.TabIndex = 2;
            this.btnDificil.Text = "Dificil";
            this.btnDificil.UseVisualStyleBackColor = true;
            this.btnDificil.Click += new System.EventHandler(this.btnDificil_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre y apellido";
            // 
            // cmbNombre
            // 
            this.cmbNombre.FormattingEnabled = true;
            this.cmbNombre.Location = new System.Drawing.Point(245, 36);
            this.cmbNombre.Name = "cmbNombre";
            this.cmbNombre.Size = new System.Drawing.Size(297, 24);
            this.cmbNombre.TabIndex = 4;
            // 
            // btnProbar
            // 
            this.btnProbar.Location = new System.Drawing.Point(203, 306);
            this.btnProbar.Margin = new System.Windows.Forms.Padding(4);
            this.btnProbar.Name = "btnProbar";
            this.btnProbar.Size = new System.Drawing.Size(326, 42);
            this.btnProbar.TabIndex = 5;
            this.btnProbar.Text = "Voy a probar...";
            this.btnProbar.UseVisualStyleBackColor = true;
            this.btnProbar.Click += new System.EventHandler(this.btnProbar_Click);
            // 
            // txtDificultad
            // 
            this.txtDificultad.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDificultad.Location = new System.Drawing.Point(96, 307);
            this.txtDificultad.Name = "txtDificultad";
            this.txtDificultad.Size = new System.Drawing.Size(100, 41);
            this.txtDificultad.TabIndex = 6;
            // 
            // btnPuntaje
            // 
            this.btnPuntaje.Location = new System.Drawing.Point(96, 371);
            this.btnPuntaje.Margin = new System.Windows.Forms.Padding(4);
            this.btnPuntaje.Name = "btnPuntaje";
            this.btnPuntaje.Size = new System.Drawing.Size(433, 42);
            this.btnPuntaje.TabIndex = 7;
            this.btnPuntaje.Text = "Ver Puntaje";
            this.btnPuntaje.UseVisualStyleBackColor = true;
            this.btnPuntaje.Click += new System.EventHandler(this.btnPuntaje_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.btnPuntaje);
            this.Controls.Add(this.txtDificultad);
            this.Controls.Add(this.btnProbar);
            this.Controls.Add(this.cmbNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDificil);
            this.Controls.Add(this.btnMedio);
            this.Controls.Add(this.btnFacil);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione Dificultad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFacil;
        private System.Windows.Forms.Button btnMedio;
        private System.Windows.Forms.Button btnDificil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNombre;
        private System.Windows.Forms.Button btnProbar;
        private System.Windows.Forms.TextBox txtDificultad;
        private System.Windows.Forms.Button btnPuntaje;
    }
}

