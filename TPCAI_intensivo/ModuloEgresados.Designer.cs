namespace TPCAI_intensivo
{
    partial class ModuloEgresados
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.comboBoxCarrera = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTodosLosEgresados = new System.Windows.Forms.DataGridView();
            this.dgvTitulosHonorificos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodosLosEgresados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitulosHonorificos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(611, 18);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(154, 26);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // comboBoxCarrera
            // 
            this.comboBoxCarrera.FormattingEnabled = true;
            this.comboBoxCarrera.Location = new System.Drawing.Point(280, 20);
            this.comboBoxCarrera.Name = "comboBoxCarrera";
            this.comboBoxCarrera.Size = new System.Drawing.Size(325, 21);
            this.comboBoxCarrera.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Carrera:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Egresados de la carrera:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Titulos honorificos:";
            // 
            // dgvTodosLosEgresados
            // 
            this.dgvTodosLosEgresados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodosLosEgresados.Location = new System.Drawing.Point(27, 81);
            this.dgvTodosLosEgresados.Name = "dgvTodosLosEgresados";
            this.dgvTodosLosEgresados.ReadOnly = true;
            this.dgvTodosLosEgresados.Size = new System.Drawing.Size(352, 317);
            this.dgvTodosLosEgresados.TabIndex = 5;
            // 
            // dgvTitulosHonorificos
            // 
            this.dgvTitulosHonorificos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTitulosHonorificos.Location = new System.Drawing.Point(385, 81);
            this.dgvTitulosHonorificos.Name = "dgvTitulosHonorificos";
            this.dgvTitulosHonorificos.ReadOnly = true;
            this.dgvTitulosHonorificos.Size = new System.Drawing.Size(505, 317);
            this.dgvTitulosHonorificos.TabIndex = 7;
            // 
            // ModuloEgresados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 416);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTitulosHonorificos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTodosLosEgresados);
            this.Controls.Add(this.comboBoxCarrera);
            this.Controls.Add(this.btnAceptar);
            this.Name = "ModuloEgresados";
            this.Text = "ModuloEgresados";
            this.Load += new System.EventHandler(this.ModuloEgresados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodosLosEgresados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitulosHonorificos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox comboBoxCarrera;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvTodosLosEgresados;
        private System.Windows.Forms.DataGridView dgvTitulosHonorificos;
    }
}