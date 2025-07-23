using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPCAI_intensivo
{
    public partial class ModuloInscripciones : Form
    {
        public ModuloInscripciones(UsuarioDto usuario)
        {
            InitializeComponent();
            UsuarioDto usuarioAlumno = usuario; 

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ModuloInscripciones_Load(object sender, EventArgs e)
        {

            GestorInscripciones gestorInscripciones = new GestorInscripciones();
           

            List<CarreraDto> carreras =gestorInscripciones.ObtenerCarreras();
            label1.Text = "Carreras";

            foreach (var carrera in carreras)
            {
                comboBox1.Items.Add(" ID:  " + carrera.Id + "  Nombre:  " + carrera.Nombre);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModuloLogin moduloLogin = new ModuloLogin();
            moduloLogin.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
