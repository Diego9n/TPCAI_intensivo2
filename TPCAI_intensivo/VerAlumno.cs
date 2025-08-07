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
        UsuarioDto UsuarioDto;
        public VerAlumno(UsuarioDto usuarioDto)
        {
            InitializeComponent();
            UsuarioDto = usuarioDto;    
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
            try { 
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
                 MessageBox.Show("Alumno modificado exitosamente.");
                 limpiarDatos();
            }
            catch (Exception ex) {
                                    MessageBox.Show(ex.Message);
                                 }
            }

        private void txtEliminarAlumno_Click(object sender, EventArgs e)
        {
            int eliminarId;
            if (int.TryParse(txtId.Text, out eliminarId))
            { 
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que querés eliminar al alumno con ID " + eliminarId + "?","Confirmar eliminación",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                 if (resultado == DialogResult.Yes)
                 {
                    try { 
                         GestorCRUDAlumno gestorCRUDAlumno = new GestorCRUDAlumno(); 
                         gestorCRUDAlumno.EliminarAlumno(eliminarId);
                         MessageBox.Show("alumno eliminado exitosamente.");
                         limpiarDatos();
                         }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else if(resultado == DialogResult.No)
                {
                    MessageBox.Show("Eliminación cancelada.");
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {            
            if (cmbAccion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una acción.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Debe ingresar un ID de alumno.");
                return;
            }
            try { 
            GestorCarreras gestorCarreras = new GestorCarreras();
            List<CarreraDto> carreras = gestorCarreras.ObtenerCarreras();
            GestorCRUDAlumno gestorCRUDAlumno = new GestorCRUDAlumno();
            clbCarreras.Items.Clear();
            groupBox2.Enabled = true;

            if (int.TryParse(txtId.Text, out int idalumno))
            {
               AlumnoDto alumno = gestorCRUDAlumno.BuscarAlumnoID(idalumno);

                            if (alumno != null)
                            {
                                MessageBox.Show("Se encontro el Alumno ID: " + idalumno ,"Informacion" , MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                MessageBox.Show("No se encontró un alumno con el ID: " + idalumno  ,"Informacion" , MessageBoxButtons.OK , MessageBoxIcon.Exclamation);
                                limpiarDatos();
                    }              
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void VerAlumno_Load(object sender, EventArgs e)
        {
            cmbAccion.Items.Add("Modificar Alumno");
            cmbAccion.Items.Add("Elimnar Alumno");
            button2.Hide();
            button1.Enabled = true; 
            txtEliminarAlumno.Hide();
            groupBox2.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void cmbAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string accionSeleccionada = cmbAccion.SelectedItem.ToString();
            if (accionSeleccionada == "Modificar Alumno")
            {
                limpiarDatos();
                groupBox1.Enabled = true;

                textBox1.ReadOnly = true;
                txtNombre.ReadOnly = false;
                txtApellido.ReadOnly = false;
                txtDni.ReadOnly = true;
                clbCarreras.Enabled = true;
                txtEliminarAlumno.Hide();
                button2.Show();
                groupBox2.Text = "Datos a modificar del Alumno";
            }
            else if (accionSeleccionada == "Elimnar Alumno")
            {
                limpiarDatos();
                groupBox1.Enabled = true;
                textBox1.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtDni.ReadOnly = true;
                clbCarreras.Enabled = false;
                button2.Hide();
                txtEliminarAlumno.Show();
               
                groupBox2.Text = "Datos a eliminar del alummno";
            }
            else
            {
                MessageBox.Show("Seleccione una acción válida.");
            }
        }
        public void limpiarDatos ()
        {
            textBox1.Clear();
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            clbCarreras.Items.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpcionAdministrador opcionAdministrador = new OpcionAdministrador(UsuarioDto);
            opcionAdministrador.Show();
            this.Hide();
        }
    }
}
