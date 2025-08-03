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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace TPCAI_intensivo
{
    public partial class VerPersonal : Form
    {
        UsuarioDto UsuarioDto;
        public VerPersonal(UsuarioDto usuarioDto)
        {
            InitializeComponent();
            UsuarioDto = usuarioDto;
        }

        private void VerPersonal_Load(object sender, EventArgs e)
        {
            comboBox5.Items.Add("Modificar Personal");
            comboBox5.Items.Add("Eliminar Personal");
            groupBox2.Enabled = false;  
            groupBox1.Enabled = false;
            groupBox4.Enabled = false;

        }


  

        private void button2_Click_1(object sender, EventArgs e)
        {
            int idProfesor;
            idProfesor = int.Parse(textBox1.Text);
            GestorCRUDPersonal gestorCRUDPersonal = new GestorCRUDPersonal();
            PersonalDtoRequest profesorDtoRequest = new PersonalDtoRequest();
            profesorDtoRequest.Nombre = txtNombre.Text;
            profesorDtoRequest.Apellido = txtDni.Text;
            profesorDtoRequest.Dni = txtApellido.Text;
            profesorDtoRequest.Cuit = txtCuit.Text;
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
                    MessageBox.Show("Se encontró el profesor con ID: " + idprofesor, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox4.Enabled = true;
                    if (comboBox5.Text == "Modificar Personal")
                    {
                        PrepararModificar();
                    }
                    else if (comboBox5.Text == "Eliminar Personal")
                    {
                        PrepararEliminar();
                    }
                    txtNombre.Text = profesor.Nombre;
                    txtDni.Text = profesor.Apellido;
                    txtApellido.Text = profesor.Dni;
                    txtCuit.Text = profesor.Cuit;
                    comboBox1.Text = profesor.Tipo;
                    txtAntiguedad.Text = profesor.Antiguedad.ToString();
                }
                else if (profesor == null)
                {
                    MessageBox.Show("No se encontró un profesor con ese ID: " + idprofesor,"Informacion", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    limpiarDatos();
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
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que querés eliminar al personal con ID " + eliminarId + "?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    try {
                        GestorCRUDPersonal gestorCRUDPersonal = new GestorCRUDPersonal();
                        gestorCRUDPersonal.EliminarPersonal(eliminarId);
                        MessageBox.Show("Personal eliminado exitosamente.");
                        limpiarDatos();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (resultado == DialogResult.No)
                {
                    MessageBox.Show("Eliminación cancelada.");
                }

            }
           
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string accionSeleccionada = comboBox5.SelectedItem.ToString();
            if (accionSeleccionada == "Modificar Personal")
            {
                limpiarDatos();
                PrepararModificar();

            }
            else if (accionSeleccionada == "Eliminar Personal")
            {
                limpiarDatos();
                PrepararEliminar();  
            }
            else
            {
                MessageBox.Show("Seleccione una acción válida.");
            }
        }
    

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        void limpiarDatos()
        {
        
            comboBox5.Text = "Seleccione Modificar o eliminar";
            textBox1.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtCuit.Clear();
            comboBox1.Items.Clear();
            txtAntiguedad.Clear();  
            groupBox4.Enabled = false;  
        }
        void PrepararModificar() 
        {
            groupBox4.Text = "Datos a modificar";
            comboBox1.Items.Clear();    
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            txtAntiguedad.ReadOnly = false;
            txtCuit.ReadOnly = false;
            txtNombre.ReadOnly = false;
            txtApellido.ReadOnly = false;
            txtDni.ReadOnly = false;
            comboBox1.Enabled = true;

            button3.Hide();
            button2.Show();

        }
        void PrepararEliminar()
        {
            groupBox4.Text = "Datos a eliminar";
            comboBox1.Items.Clear();    
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            txtAntiguedad.ReadOnly = true;
            txtCuit.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            txtDni.ReadOnly = true;
            comboBox1.Enabled = false;

            button2.Hide();
            button3.Show();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpcionAdministrador opcionAdministrador = new OpcionAdministrador(UsuarioDto);
            opcionAdministrador.Show();
            this.Hide();

        }
    }
}
