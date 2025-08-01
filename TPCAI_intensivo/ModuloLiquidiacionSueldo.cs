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
    public partial class ModuloLiquidiacionSueldo : Form
    {
        UsuarioDto usuarioDto = new UsuarioDto();     

        public ModuloLiquidiacionSueldo(UsuarioDto usuariodto)
        {
            InitializeComponent();
            label1.Text = "Bienvenido " + usuariodto.PerfilUsuario + " " + usuariodto.Id;
            usuarioDto.Id = usuariodto.Id;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            long profesorid;
            profesorid = usuarioDto.Id; 
            GestorDeSueldos gestorDeSueldos = new GestorDeSueldos();
            SueldoPersonal sueldo = new SueldoPersonal();
            sueldo = gestorDeSueldos.CalcularSueldo(profesorid);

            if (sueldo.Sueldo != 0)
            {
                label1.Text =
                              "Nombre: " + sueldo.Nombre + "\n" +
                              "Apellido: " + sueldo.Apellido + "\n" +
                              "DNI: " + sueldo.Dni + "\n" +
                              "CUIT: " + sueldo.Cuit + "\n" +
                              "Antigüedad: " + sueldo.Antiguedad + " años " + "\n" +
                              "Tipo: " + sueldo.Tipo + "\n" +
                              "sueldo : $ " + sueldo.Sueldo + "\n";
            } else if (sueldo.Sueldo == 0)
            {
                label1.Text = sueldo.Mensaje;

            }
            this.Cursor = Cursors.Default;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ModuloLiquidiacionSueldo_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModuloLogin moduloLogin = new ModuloLogin();
            moduloLogin.Show();
            this.Hide();

        }
    }
}
