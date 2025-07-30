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
    public partial class CrearAlumno : Form
    {
        public CrearAlumno()
        {
            InitializeComponent();
        }

        private void CrearAlumno_Load(object sender, EventArgs e)
        {
            GestorCarreras gestorCarreras = new GestorCarreras();
            List<CarreraDto> carreras = gestorCarreras.ObtenerCarreras();
            clbCarreras.Items.Clear();
            foreach (var carrera in carreras)
            {
                clbCarreras.Items.Add(carrera.Nombre);
            }



        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
               string.IsNullOrWhiteSpace(txtApellido.Text) ||
               string.IsNullOrWhiteSpace(txtDni.Text))

            {
                MessageBox.Show("Debe completar Nombre, Apellido o DNI");
                return;
            }
            
            if (clbCarreras.CheckedItems.Count == 0 ) 
            {
                MessageBox.Show("Debe seleccionar una carrera.");
                return;
            } 
            List<int> idscarrerasSeleccionadas = new List<int>();
            foreach (var item in clbCarreras.CheckedItems)
            {
                if (item is CarreraDto carreraSeleccionada)
                {
                    idscarrerasSeleccionadas.Add(carreraSeleccionada.Id);
                }
            }

            AlumnoDtoRequest alumnoDtoRequest = new AlumnoDtoRequest
            {
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                dni = txtDni.Text,
                carrerasIds = idscarrerasSeleccionadas
            };
            GestorCRUDAlumno gestorCRUDAlumno = new GestorCRUDAlumno();
            try
            {
                gestorCRUDAlumno.CrearAlumno(alumnoDtoRequest);
                MessageBox.Show("Alumno creado exitosamente.");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el alumno: {ex.Message}");
            }
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
