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
    public partial class OpcionAdministrador : Form
    {
        UsuarioDto usuarioDto { get; set; }
        public OpcionAdministrador(UsuarioDto usuario)
        {
            InitializeComponent();
            UsuarioDto usuarioDto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModuloLogin moduloLogin = new ModuloLogin();
            moduloLogin.Show();
            this.Hide();
        }

        private void OpcionAdministrador_Load(object sender, EventArgs e)
        {

        }

        private void btnAlumno_Click(object sender, EventArgs e)
        {
            CrearAlumno crearAlumno = new CrearAlumno();
            crearAlumno.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }


        private void btnDocentes_Click(object sender, EventArgs e)
        {
            ModuloAdministracionPersonal moduloAdministracionPersonal = new ModuloAdministracionPersonal(usuarioDto);
            moduloAdministracionPersonal.Show();    
            this.Hide();

        }
    }
}
