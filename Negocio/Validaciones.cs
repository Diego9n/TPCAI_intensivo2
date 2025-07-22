using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class Validaciones
    {
        public bool ValidarIngresoUsuario(string usuario)
        {
            if (usuario.Length != 8)
            {
                MessageBox.Show("El usuario debe tener 8 caracteres", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool ValidarIngresoContraseña(string contraseña)
        {
            if (contraseña.Length < 7)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres", "Error de validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
