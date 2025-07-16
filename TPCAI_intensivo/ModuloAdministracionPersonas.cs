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
    public partial class ModuloAdministracionPersonas : Form
    {
        public ModuloAdministracionPersonas()
        {
            InitializeComponent();
        }

        private void ModuloAdministracionPersonas_Load(object sender, EventArgs e)
        {

           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            persona.Nombre = txtNombre.Text;    
            label1.Text = "Nombre: " + persona.Nombre;  

        }
    }
}
