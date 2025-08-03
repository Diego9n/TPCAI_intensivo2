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
        UsuarioDto UsuarioDto;
        public OpcionAdministrador(UsuarioDto usuario)
        {
            InitializeComponent();
            UsuarioDto = usuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModuloLogin moduloLogin = new ModuloLogin();
            moduloLogin.Show();
            this.Hide();
        }

        private void OpcionAdministrador_Load(object sender, EventArgs e)
        {
            label1.Text = "Usuario :  " + UsuarioDto.Id + " Perfil :  " + UsuarioDto.PerfilUsuario;
        }

        private void btnAlumno_Click(object sender, EventArgs e)
        {
           ModuloAdministracionAlumno moduloAdministracionAlumno = new ModuloAdministracionAlumno(UsuarioDto);
            moduloAdministracionAlumno.Show();
            this.Hide();
        }

        private void btnDocentes_Click(object sender, EventArgs e)
        {
            ModuloAdministracionPersonal moduloAdministracionPersonal = new ModuloAdministracionPersonal(UsuarioDto);
            moduloAdministracionPersonal.Show();    
            this.Hide();

        }

        private void btnEgresados_Click(object sender, EventArgs e)
        {
            ModuloEgresados formEgresados = new ModuloEgresados(this);
            formEgresados.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ModuloDesbloquearUsuario moduloDesbloquearUsuario = new ModuloDesbloquearUsuario(UsuarioDto);
            moduloDesbloquearUsuario.Show();
            this.Hide();
        }
    }
}
