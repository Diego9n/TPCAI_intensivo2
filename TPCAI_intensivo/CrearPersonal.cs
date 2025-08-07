using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TPCAI_intensivo
{
    public partial class CrearPersonal : Form
    {

        UsuarioDto UsuarioDto { get; set; }
        List<int> cursosSeleccionadosIds = new List<int>();

        public CrearPersonal(UsuarioDto usuarioDto)
        {
            InitializeComponent();
            UsuarioDto = usuarioDto;
        }

        private void CrearPersonal_Load(object sender, EventArgs e)
        {
         
            CargaInical();
    


        }


        private void btnCrearPersonal_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                cursosSeleccionadosIds.Count == 0 )  
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }

            if (!int.TryParse(textBox3.Text, out int dni) || textBox3.TextLength != 8  )
            {
                MessageBox.Show("Por favor ingrese solo números en el campo DNI y que sea de 8 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus(); 
                return;  
            }
            string cuitsinformato = textBox5.Text.Trim();
            if (cuitsinformato.Length != 11 || !long.TryParse(cuitsinformato, out _))
            {
                MessageBox.Show("El CUIT debe tener exactamente 11 dígitos numéricos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
                return;
            }
            if (comboBox1.SelectedIndex == -1) 
                {
                    MessageBox.Show("Debe seleccionar un tipo de personal.");
                    return;
                }
            string cuitFormateado = cuitsinformato.Insert(2, "-").Insert(11, "-");
            textBox5.Text = cuitFormateado;

            PersonalDtoRequest personalDtoRequest = new PersonalDtoRequest
            {
                Nombre = textBox2.Text,
                Apellido = textBox4.Text,
                Dni = textBox3.Text,
                Cuit = textBox5.Text,
                Tipo = comboBox1.Text,
                Cursos = cursosSeleccionadosIds
            };
            GestorCRUDPersonal gestorCRUDPersonal = new GestorCRUDPersonal();
            try
            {
                gestorCRUDPersonal.CrearPersonaL(personalDtoRequest);
                MessageBox.Show("Personal creado exitosamente.");
                CargaInical();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el personal: {ex.Message}");
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpcionAdministrador opcionAdministrador = new OpcionAdministrador(UsuarioDto);
            opcionAdministrador.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un curso.");
                return;
            }

            CursoResponseDto cursoSeleccionado = (CursoResponseDto)comboBox4.SelectedItem;

            // Verificamos que no esté ya en la lista
            bool yaAgregado = false;
            foreach (int id in cursosSeleccionadosIds)
            {
                if (id == cursoSeleccionado.id)
                {
                    yaAgregado = true;
                    break;
                }
            }

            if (!yaAgregado)
            {
                cursosSeleccionadosIds.Add(cursoSeleccionado.id);
                MessageBox.Show("Curso agregado con éxito.");
            }
            else
            {
                MessageBox.Show("El curso ya fue agregado.");
            }
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

 

   
        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            GestorMaterias gestorMaterias = new GestorMaterias();
            comboBox4.Items.Clear();
            comboBox4.Text = "Seleccione un curso"; 
            textBox1.Clear();
         
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

                    textBox1.AppendText(info);
                }
                textBox1.SelectionStart = 0;
                textBox1.ScrollToCaret();

            }
           
        }
        public void CargaInical()
        {
            GestorCarreras gestorCarreras = new GestorCarreras();
            List<CarreraDto> carreras = gestorCarreras.ObtenerCarreras();
            comboBox1.Items.Clear();
            comboBox1.Text = "Seleccione un tipo de personal";
            comboBox1.Items.Add("PROFESOR");
            comboBox1.Items.Add("AYUDANTE");
            comboBox1.Items.Add("AYUDANTE_AD_HONOREM");
            comboBox2.Text = "Seleccione una carrera";
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox2.Items.Clear();
            comboBox2.Text = "Seleccione una carrera";
            comboBox3.Items.Clear();
            comboBox3.Text = "Seleccione una materia";
            comboBox4.Items.Clear();
            comboBox4.Text = "Seleccione un curso";
            textBox1.Text = "";
            foreach (var carrera in carreras)
            {
                comboBox2.Items.Add(carrera);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
        
      
}

