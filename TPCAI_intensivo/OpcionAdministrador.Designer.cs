namespace TPCAI_intensivo
{
    partial class OpcionAdministrador
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
            this.btnEgresados = new System.Windows.Forms.Button();
            this.btnDocentes = new System.Windows.Forms.Button();
            this.btnAlumno = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEgresados
            // 
            this.btnEgresados.Location = new System.Drawing.Point(251, 83);
            this.btnEgresados.Name = "btnEgresados";
            this.btnEgresados.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEgresados.Size = new System.Drawing.Size(184, 23);
            this.btnEgresados.TabIndex = 0;
            this.btnEgresados.Text = "Generar reporte de Graduados";
            this.btnEgresados.UseVisualStyleBackColor = true;
            // 
            // btnDocentes
            // 
            this.btnDocentes.Location = new System.Drawing.Point(252, 124);
            this.btnDocentes.Name = "btnDocentes";
            this.btnDocentes.Size = new System.Drawing.Size(182, 28);
            this.btnDocentes.TabIndex = 1;
            this.btnDocentes.Text = "Administracion de docentes";
            this.btnDocentes.UseVisualStyleBackColor = true;
            this.btnDocentes.Click += new System.EventHandler(this.btnDocentes_Click);
            // 
            // btnAlumno
            // 
            this.btnAlumno.Location = new System.Drawing.Point(252, 171);
            this.btnAlumno.Name = "btnAlumno";
            this.btnAlumno.Size = new System.Drawing.Size(183, 23);
            this.btnAlumno.TabIndex = 2;
            this.btnAlumno.Text = "Administracion de alumnos";
            this.btnAlumno.UseVisualStyleBackColor = true;
            this.btnAlumno.Click += new System.EventHandler(this.btnAlumno_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(307, 313);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(251, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Desbloquear usuarios";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // OpcionAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAlumno);
            this.Controls.Add(this.btnDocentes);
            this.Controls.Add(this.btnEgresados);
            this.Name = "OpcionAdministrador";
            this.Text = "ut";
            this.Load += new System.EventHandler(this.OpcionAdministrador_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEgresados;
        private System.Windows.Forms.Button btnDocentes;
        private System.Windows.Forms.Button btnAlumno;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button button1;
    }
}