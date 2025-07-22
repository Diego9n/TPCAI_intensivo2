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
        public ModuloDesbloquearUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestorLogin login = new GestorLogin();
            login.DesbloquearUsuario(int.Parse(textBox1.Text)); 
        }
    }
}
