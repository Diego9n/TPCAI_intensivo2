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
    public partial class ModuloDesbloquearUsuario : Form
    {
        UsuarioDto UsuarioDto;
        public ModuloDesbloquearUsuario(UsuarioDto usuarioDto)
        {
            InitializeComponent();
            UsuarioDto = usuarioDto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || !int.TryParse(textBox1.Text,out int id)   )
            {
                MessageBox.Show("Debe ingresar un ID de usuario valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try { 
                 GestorLogin login = new GestorLogin();
                 login.DesbloquearUsuario(int.Parse(textBox1.Text));
                 MessageBox.Show("Usuario desbloqueado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);  
            }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpcionAdministrador opcionAdministrador = new OpcionAdministrador(UsuarioDto);
            opcionAdministrador.Show();
            this.Hide();
        }
    }
}
