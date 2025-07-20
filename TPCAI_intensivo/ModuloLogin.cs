using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using System.Windows.Forms;

namespace TPCAI_intensivo
{
    public partial class ModuloLogin : Form
    {
        public ModuloLogin()
        {
            InitializeComponent();
        }

        private void ModuloLogin_Load(object sender, EventArgs e)
        {
            CargarCarreras();
            CargarProfesores();

        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void CargarCarreras()
        {
            Validar validador = new Validar();
            List<CarreraDto> carreras = validador.ObtenerCarreras();
            label1.Text = "Carreras";

            foreach (var carrera in carreras)
            {
                comboBox1.Items.Add(" ID:  " + carrera.Id + "  Nombre:  " + carrera.Nombre);
            }

        }
        private void CargarProfesores()
        {
            Validar validador = new Validar();
            List<ProfesorDto> profesores = validador.ObtenerProfesores();
            label2.Text = "Profesores";
            foreach (var profesor in profesores)
            {
                comboBox2.Items.Add("ID:  " + profesor.Id + "   Nombre:  " + profesor.Nombre + "  Apellido:  " + profesor.Apellido + " Cuit:  " + profesor.Cuit + " DNI:   " + profesor.Dni + " Antiguedad:   " + profesor.Antiguedad + " Tipo:  " + profesor.Tipo);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            validarususario();
            Validar validador = new Validar();
            List<ProfesorDto> profesores = validador.ObtenerProfesores();
            ProfesorDto profesor = new ProfesorDto();
            

          

        }
        public void validarususario()
        {

            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Debe ingresar un usuario");
                return;
            }


        }

    }
}