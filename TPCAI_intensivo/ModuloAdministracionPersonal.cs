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
    public partial class ModuloAdministracionPersonal : Form
    { 
        UsuarioDto UsuarioDto { get; set; }
        public ModuloAdministracionPersonal(UsuarioDto usuarioDto)

        {
            InitializeComponent();
            UsuarioDto = usuarioDto;
        }

        private void ModuloAdministracionPersonas_Load(object sender, EventArgs e)
        {




        }

        private void button1_Click(object sender, EventArgs e)
        {


        }


        private void button2_Click(object sender, EventArgs e)
        {
            VerPersonal verPersonal = new VerPersonal();
            verPersonal.Show();
            this.Hide();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            CrearPersonal crearPersonal = new CrearPersonal(UsuarioDto);
            crearPersonal.Show();
            this.Hide();
        }
    }
}
