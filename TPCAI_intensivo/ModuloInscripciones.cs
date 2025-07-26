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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TPCAI_intensivo
{
    public partial class ModuloInscripciones : Form
    {
        GestorInscripciones gestorInscripciones = new GestorInscripciones();
        UsuarioDto usuarioalumno = new UsuarioDto();    
        public ModuloInscripciones(UsuarioDto usuario)
        {
            InitializeComponent();
            UsuarioDto usuarioAlumno = usuario;
            usuarioalumno = usuarioAlumno; 
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ModuloInscripciones_Load(object sender, EventArgs e)
        {
            List<CarreraDto> carreras = gestorInscripciones.ObtenerCarreras();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = carreras;
           
            label1.Text = "Carreras";
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModuloLogin moduloLogin = new ModuloLogin();
            moduloLogin.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int idCarrera = (int)comboBox1.SelectedValue;


                List<MateriaDto> materias = gestorInscripciones.MateriasRestantes(idCarrera , (int)usuarioalumno.Id);

                comboBox2.DataSource = materias;
                comboBox2.DisplayMember = "Nombre";
                comboBox2.ValueMember = "Id";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem is MateriaDto materia)
            {
                int idMateria = materia.id; 
               
            }


        }
    }
}
