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
    public partial class VerAlumno : Form
    {
        public VerAlumno()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtEliminarAlumno_Click(object sender, EventArgs e)
        {
            int eliminarId;
            if (int.TryParse(txtId.Text, out eliminarId))
            {
                GestorCRUDAlumno gestorCRUDAlumno = new GestorCRUDAlumno(); 
                gestorCRUDAlumno.EliminarAlumno(eliminarId);
                MessageBox.Show("Profesor eliminado exitosamente.");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID válido para eliminar.");
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GestorCRUDAlumno gestorCRUDAlumno = new GestorCRUDAlumno();
            /*if (int.TryParse(txtId.Text, out int idprofesor))
                        {
                            ProfesorDto profesor = gestorCRUDPersonal.BuscarProfesorID(idprofesor);

                            if (profesor != null)
                            {
                                txtNombre.Text = profesor.Nombre;
                                txtApellido.Text = profesor.Apellido;
                                txtDni.Text = profesor.Dni;
                                tx.Text = profesor.Cuit;
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

            }*/
        }

        private void VerAlumno_Load(object sender, EventArgs e)
        {

        }
    }
}
