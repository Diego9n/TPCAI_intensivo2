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


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text)) 
                
            {
                MessageBox.Show("Debe completar Nombre, Apellido");
                return;
            }
            if (clbCarreras.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una carrera.");
                return; 
            }
            AlumnoDtoRequest alumnoDtoRequest = new AlumnoDtoRequest();
            GestorCRUDAlumno gestorCRUDAlumno = new GestorCRUDAlumno();
            List<int> carrerasSeleccionadas = new List<int>();

            foreach (var item in clbCarreras.CheckedItems)
            {
                CarreraDto carrera = (CarreraDto)item;
                carrerasSeleccionadas.Add(carrera.Id);
            }
            alumnoDtoRequest.nombre = txtNombre.Text;
            alumnoDtoRequest.apellido = txtApellido.Text;
            alumnoDtoRequest.dni = txtDni.Text;
            alumnoDtoRequest.carrerasIds = carrerasSeleccionadas;
            alumnoDtoRequest.id = int.Parse(txtId.Text);
            gestorCRUDAlumno.ModificarAlumno(alumnoDtoRequest,alumnoDtoRequest.id);
        }

        private void txtEliminarAlumno_Click(object sender, EventArgs e)
        {
            int eliminarId;
            if (int.TryParse(txtId.Text, out eliminarId))
            {
                GestorCRUDAlumno gestorCRUDAlumno = new GestorCRUDAlumno(); 
                gestorCRUDAlumno.EliminarAlumno(eliminarId);
                MessageBox.Show("alumno eliminado exitosamente.");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID válido para eliminar.");
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GestorCarreras gestorCarreras = new GestorCarreras();
            List<CarreraDto> carreras = gestorCarreras.ObtenerCarreras();
            GestorCRUDAlumno gestorCRUDAlumno = new GestorCRUDAlumno();
            clbCarreras.Items.Clear();
          
            if (int.TryParse(txtId.Text, out int idalumno))
            {
               AlumnoDto alumno = gestorCRUDAlumno.BuscarAlumnoID(idalumno);

                            if (alumno != null)
                            {
                                  foreach (var carrera in carreras)
                                  {
                                    clbCarreras.Items.Add(carrera, alumno.CarrerasIds.Contains(carrera.Id));
                                  }
                                textBox1.Text = alumno.Id.ToString();  
                                txtNombre.Text = alumno.Nombre;
                                txtApellido.Text = alumno.Apellido;
                                txtDni.Text = alumno.Dni;
                            }
                            else
                            {
                                MessageBox.Show("No se encontró un alumno con ese ID.");
                            }
                        

            }
        }


        private void VerAlumno_Load(object sender, EventArgs e)
        {

        }
    }
}
