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
        List<int> cursosSeleccionadosIds = new List<int>();
        List<int> cursosAmodificar = new List<int>();
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
            label11.Hide();
        }


  

        private void button2_Click_1(object sender, EventArgs e)
        { 
                    
            try { 
            int idProfesor;
            idProfesor = int.Parse(textBox1.Text);
            GestorCRUDPersonal gestorCRUDPersonal = new GestorCRUDPersonal();
            PersonalDtoRequest profesorDtoRequest = new PersonalDtoRequest();
                profesorDtoRequest.Cursos = new List<int>();
                profesorDtoRequest.Nombre = txtNombre.Text;
            profesorDtoRequest.Apellido = txtDni.Text;
            profesorDtoRequest.Dni = txtApellido.Text;
            profesorDtoRequest.Cuit = txtCuit.Text;
            profesorDtoRequest.Tipo = comboBox1.Text;
                foreach (var curso in cursosAmodificar)
                {
                    profesorDtoRequest.Cursos.Add(curso);
                }


                gestorCRUDPersonal.ModificarPersonal(profesorDtoRequest, idProfesor);
                limpiarDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiarDatos();
                return;
           
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label11.Text = "Espere a que se carguen los datos ...... (esto se debe a que se tiene que buscar los cursos en todos los cursos de todas las carreras)";
            label11.Show();
            textBox7.Clear();
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            if (!int.TryParse(textBox1.Text, out int idProfesor))
            {
                MessageBox.Show("Ingrese un número válido para el ID del profesor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetEstado();
                return;
            }

            try
            {
                GestorCRUDPersonal gestor = new GestorCRUDPersonal();
                ProfesorDto profesor = gestor.BuscarProfesorID(idProfesor);

                if (profesor == null)
                {
                    MessageBox.Show("No se encontró un profesor con ese ID: " + idProfesor, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiarDatos();
                    ResetEstado();
                    return;
                }

                MessageBox.Show("Se encontró el profesor con ID: " + idProfesor, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombre.Text = profesor.Nombre;
                txtDni.Text = profesor.Apellido;
                txtApellido.Text = profesor.Dni;
                txtCuit.Text = profesor.Cuit;
                comboBox1.Text = profesor.Tipo;
                txtAntiguedad.Text = profesor.Antiguedad.ToString();


               
                List<int> cursosPersonal = gestor.CursosPersonal(idProfesor);
                cursosAmodificar.Clear();
                foreach (var curso in cursosPersonal)
                {
                    textBox7.AppendText("ID Curso: " + curso + Environment.NewLine);
                    cursosAmodificar.Add(curso);
                }

               
                groupBox4.Enabled = true;
                if (comboBox5.Text == "Modificar Personal")
                {
                    PrepararModificar();
                }
                else if (comboBox5.Text == "Eliminar Personal")
                {
                    PrepararEliminar();
                }

                ResetEstado(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetEstado();
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
            textBox1.Clear();
            comboBox2.SelectedIndex = -1;
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            textBox6.Clear();
            textBox7.Clear();
            txtDni.Clear();
            txtCuit.Clear();
            comboBox1.Items.Clear();
            txtAntiguedad.Clear();  
            groupBox4.Enabled = false;  
        }
        void PrepararModificar() 
        {
            GestorCarreras gestorCarreras = new GestorCarreras();
            List<CarreraDto> carreras = gestorCarreras.ObtenerCarreras();
            foreach (var carrera in carreras)
            {
                comboBox2.Items.Add(carrera);
            }
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GestorMaterias gestorMaterias = new GestorMaterias();
            comboBox3.Items.Clear();
            comboBox3.Text = "Seleccione una materia";
            comboBox4.Items.Clear();
            comboBox4.Text = "Seleccione un curso";

            if (comboBox2.SelectedItem != null)
            {
                CarreraDto carreraSeleccionada = (CarreraDto)comboBox2.SelectedItem;
                int idCarrera = carreraSeleccionada.Id;

                var materias = gestorMaterias.ObtenerMaterias(idCarrera);

                foreach (var materia in materias)
                {

                    comboBox3.Items.Add(materia);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GestorMaterias gestorMaterias = new GestorMaterias();
            comboBox4.Items.Clear();
            comboBox4.Text = "Seleccione un curso";

            if (comboBox3.SelectedItem != null)
            {
                MateriaDto materiaSeleccionada = (MateriaDto)comboBox3.SelectedItem;
                int idMateria = materiaSeleccionada.Id;
                var cursos = gestorMaterias.ObtenerCursos(idMateria);
                foreach (var curso in cursos)
                {
                    comboBox4.Items.Add(curso);
                    string dias = string.Join(", ", curso.dias);

                    string horarios = "";
                    foreach (var h in curso.horarios)
                    {
                        horarios += h.horaInicio + " - " + h.horaFin + "; ";
                    }

                    string info = $"ID: {curso.id}\r\n" +
                                  $"Días: {dias}\r\n" +
                                  $"Horarios: {horarios.Trim()}\r\n" +
                                  "------------------------------\r\n";

                    textBox6.AppendText(info);
                }
                textBox1.SelectionStart = 0;
                textBox1.ScrollToCaret();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un curso.");
                return;
            }

            CursoResponseDto cursoSeleccionado = (CursoResponseDto)comboBox4.SelectedItem;

            // Verificamos que no esté ya en la lista
            bool yaAgregado = cursosSeleccionadosIds.Contains(cursoSeleccionado.id);

            if (!yaAgregado)
            {
                cursosSeleccionadosIds.Add(cursoSeleccionado.id);

                string dias = string.Join(", ", cursoSeleccionado.dias);

                string horarios = "";
                foreach (var h in cursoSeleccionado.horarios)
                {
                    horarios += $"{h.dia}: {h.horaInicio} - {h.horaFin}; ";
                }

                string info = $"ID Curso: {cursoSeleccionado.id}\r\n" ;

                textBox7.AppendText(info);

                MessageBox.Show("Curso agregado con éxito.");
                cursosAmodificar.Add(cursoSeleccionado.id);
            }
            else
            {
                MessageBox.Show("El curso ya fue agregado.");
            }
        }
        private void ResetEstado()
        {
            this.Cursor = Cursors.Default;
            label11.Hide();
        }
    }
}
