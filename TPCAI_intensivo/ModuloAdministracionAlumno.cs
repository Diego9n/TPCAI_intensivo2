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
    
    public partial class ModuloAdministracionAlumno : Form
    {
        UsuarioDto UsuarioDto;
        public ModuloAdministracionAlumno(UsuarioDto usuarioDto)
        {
            InitializeComponent();
            UsuarioDto = usuarioDto;    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearAlumno crearAlumno = new CrearAlumno(UsuarioDto);
            crearAlumno.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerAlumno verAlumno = new VerAlumno(UsuarioDto);
            verAlumno.Show();
            this.Hide();
        }

        private void ModuloAdministracionAlumno_Load(object sender, EventArgs e)
        {
            label1.Text = "Usuario :  " + UsuarioDto.Id + "\n" +
                          "Perfil :  " + UsuarioDto.PerfilUsuario;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpcionAdministrador opcionAdministrador = new OpcionAdministrador(UsuarioDto);
            opcionAdministrador.Show();
            this.Hide();    
        }
    }
}
