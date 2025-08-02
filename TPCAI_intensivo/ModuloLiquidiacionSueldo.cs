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
            label1.Text = " Usuario :  " + usuariodto.Id  +  "\n" +
                          " Perfil :  " + usuariodto.PerfilUsuario;
            usuarioDto.Id = usuariodto.Id;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Cargando datos, por favor espere...";
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents(); 
            long profesorid;
            profesorid = usuarioDto.Id; 
            GestorDeSueldos gestorDeSueldos = new GestorDeSueldos();
            SueldoPersonal sueldo = new SueldoPersonal();
            sueldo = gestorDeSueldos.CalcularSueldo(profesorid);

            if (sueldo.Sueldo != 0)
            {
                label1.Font = new Font(label1.Font.FontFamily, 12, label1.Font.Style);
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
                label1.Font =  new Font(label1.Font.FontFamily, 9, label1.Font.Style);
                label1.Text = sueldo.Mensaje;

            }
            this.Cursor = Cursors.Default;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            ModuloLogin moduloLogin = new ModuloLogin();
            moduloLogin.Show();
            this.Hide();

        }
    }
}
