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
    public partial class VerPersonal : Form
    {
        public VerPersonal()
        {
            InitializeComponent();
        }

        private void VerPersonal_Load(object sender, EventArgs e)
        {

        }


  

        private void button2_Click_1(object sender, EventArgs e)
        {
            int idProfesor;
            idProfesor = int.Parse(textBox1.Text);
            GestorCRUDPersonal gestorCRUDPersonal = new GestorCRUDPersonal();
            PersonalDtoRequest profesorDtoRequest = new PersonalDtoRequest();
            profesorDtoRequest.Nombre = textBox2.Text;
            profesorDtoRequest.Apellido = textBox3.Text;
            profesorDtoRequest.Dni = textBox4.Text;
            profesorDtoRequest.Cuit = textBox5.Text;
            profesorDtoRequest.Tipo = textBox6.Text;
            profesorDtoRequest.Cursos = new List<int>(); // Asumiendo que no se modifican los cursos en este ejemplo    


            gestorCRUDPersonal.ModificarPersonal(profesorDtoRequest, idProfesor);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GestorCRUDPersonal gestorCRUDPersonal = new GestorCRUDPersonal();
            if (int.TryParse(textBox1.Text, out int idprofesor))
            {
                ProfesorDto profesor = gestorCRUDPersonal.BuscarProfesorID(idprofesor);

                if (profesor != null)
                {
                    textBox2.Text = profesor.Nombre;
                    textBox3.Text = profesor.Apellido;
                    textBox4.Text = profesor.Dni;
                    textBox5.Text = profesor.Cuit;
                    textBox6.Text = profesor.Tipo;
                }
                else
                {
                    MessageBox.Show("No se encontró un profesor con ese ID.");
                }
            }
            else
            {

                MessageBox.Show("Por favor, ingrese un número válido.");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int eliminarId;
            if (int.TryParse(textBox1.Text, out eliminarId))
            {
                GestorCRUDPersonal gestorCRUDPersonal = new GestorCRUDPersonal();
                gestorCRUDPersonal.EliminarPersonal(eliminarId);
                MessageBox.Show("Alumno eliminado exitosamente.");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID válido para eliminar.");
            }
        }
    }
}
