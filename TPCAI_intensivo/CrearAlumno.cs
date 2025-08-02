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
        UsuarioDto UsuarioDto;  
        public CrearAlumno(UsuarioDto usuarioDto)
        {
            InitializeComponent();
            UsuarioDto = usuarioDto;
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
            if (string.IsNullOrWhiteSpace(txtNombre.Text) )
                {
                MessageBox.Show("Debe completar el campo Nombre.");
                txtNombre.Focus();
                return;
                }
            if(string.IsNullOrWhiteSpace(txtApellido.Text) )
               {
                MessageBox.Show("Debe completar el campo Apellido.");
                txtApellido.Focus();
                return;
                }

            if (txtDni.TextLength != 8 || !int.TryParse(txtDni.Text, out _) || string.IsNullOrWhiteSpace(txtDni.Text) )
            {
                MessageBox.Show("Por favor ingrese un DNI válido de 8 dígitos numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDni.Focus();
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
            try
            {
                AlumnoDtoRequest alumnoDtoRequest = new AlumnoDtoRequest
                {
                    nombre = txtNombre.Text,
                    apellido = txtApellido.Text,
                    dni = txtDni.Text,
                    carrerasIds = idscarrerasSeleccionadas
                };
                GestorCRUDAlumno gestorCRUDAlumno = new GestorCRUDAlumno();
                gestorCRUDAlumno.CrearAlumno(alumnoDtoRequest);
                MessageBox.Show("Alumno creado exitosamente.");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpcionAdministrador opcionAdministrador = new OpcionAdministrador(UsuarioDto);
            opcionAdministrador.Show();
            this.Hide();

        }
    }
}
