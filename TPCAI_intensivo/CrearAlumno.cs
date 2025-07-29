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
    public partial class CrearAlumno : Form
    {
        public CrearAlumno()
        {
            InitializeComponent();
        }

        private void CrearAlumno_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlumnoDtoRequest alumnoDtoRequest = new AlumnoDtoRequest
            {
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                dni = txtDni.Text,
                carreras = new List<int> { 1, 2 } // Asignar las carreras deseadas
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
    }
}
