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
            this.btnAceptar.Location = new System.Drawing.Point(815, 22);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(205, 32);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // comboBoxCarrera
            // 
            this.comboBoxCarrera.FormattingEnabled = true;
            this.comboBoxCarrera.Location = new System.Drawing.Point(373, 25);
            this.comboBoxCarrera.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxCarrera.Name = "comboBoxCarrera";
            this.comboBoxCarrera.Size = new System.Drawing.Size(432, 24);
            this.comboBoxCarrera.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Carrera:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Egresados de la carrera:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(509, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Titulos honorificos:";
            // 
            // dgvTodosLosEgresados
            // 
            this.dgvTodosLosEgresados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodosLosEgresados.Location = new System.Drawing.Point(36, 100);
            this.dgvTodosLosEgresados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTodosLosEgresados.Name = "dgvTodosLosEgresados";
            this.dgvTodosLosEgresados.ReadOnly = true;
            this.dgvTodosLosEgresados.RowHeadersWidth = 51;
            this.dgvTodosLosEgresados.Size = new System.Drawing.Size(469, 390);
            this.dgvTodosLosEgresados.TabIndex = 5;
            // 
            // dgvTitulosHonorificos
            // 
            this.dgvTitulosHonorificos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTitulosHonorificos.Location = new System.Drawing.Point(513, 100);
            this.dgvTitulosHonorificos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTitulosHonorificos.Name = "dgvTitulosHonorificos";
            this.dgvTitulosHonorificos.ReadOnly = true;
            this.dgvTitulosHonorificos.RowHeadersWidth = 51;
            this.dgvTitulosHonorificos.Size = new System.Drawing.Size(777, 390);
            this.dgvTitulosHonorificos.TabIndex = 7;
            // 
            // ModuloEgresados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 512);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTitulosHonorificos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTodosLosEgresados);
            this.Controls.Add(this.comboBoxCarrera);
            this.Controls.Add(this.btnAceptar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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