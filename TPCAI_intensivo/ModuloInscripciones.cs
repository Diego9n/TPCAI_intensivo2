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
    public partial class ModuloInscripciones : Form
    {
        GestorInscripciones gestorInscripciones = new GestorInscripciones();
        UsuarioDto usuarioalumno = new UsuarioDto();
        List<int> idsMateriasSeleccionadas = new List<int>();
        List<int> idsCursosSeleccionados = new List<int>();
        public ModuloInscripciones(UsuarioDto usuario)
        {
            InitializeComponent();
            UsuarioDto usuarioAlumno = usuario;
            usuarioalumno = usuarioAlumno;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ModuloInscripciones_Load(object sender, EventArgs e)
        {
            List<CarreraDto> carreras = gestorInscripciones.ObtenerCarreras();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = carreras;

            label1.Text = "Carreras";
            label3.Text = "N RANKING : " + gestorInscripciones.ObtenerRanking((int)usuarioalumno.Id).ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModuloLogin moduloLogin = new ModuloLogin();
            moduloLogin.Show();
            this.Hide();
        }

       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        
       

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {

                textBox1.Clear();
                int idCarrera = (int)comboBox1.SelectedValue;


                List<MateriaDto> materias = gestorInscripciones.ObtenerMateriasHabilitadas(idCarrera, (int)usuarioalumno.Id);

                comboBox2.DataSource = materias;
                comboBox2.DisplayMember = "Nombre";
                comboBox2.ValueMember = "Id";
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int idCurso = (int)comboBox2.SelectedValue;
            GestorMaterias gestorMaterias = new GestorMaterias();
            List<CursoResponseDto> cursos = gestorMaterias.ObtenerCursos(idCurso);
            cursos = gestorMaterias.ObtenerCursos(idCurso);
            comboBox3.DataSource = cursos;
            comboBox3.ValueMember = "ID";
            textBox1.Clear();
            foreach (var curso in cursos)
            {

                textBox1.AppendText("ID Curso: " + curso.id + Environment.NewLine);
                textBox1.AppendText("Profesor: " + curso.profesorNombre + Environment.NewLine);
                textBox1.AppendText("Días: " + string.Join(", ", curso.dias) + Environment.NewLine);

                foreach (var horario in curso.horarios)
                {
                    textBox1.AppendText("Horario: " + horario.horaInicio + " - " + horario.horaFin + Environment.NewLine);
                }

                textBox1.AppendText("------------------------" + Environment.NewLine);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            int idMateriaSeleccionada = (int)comboBox2.SelectedValue;
            int idCursoSeleccionado = (int)comboBox3.SelectedValue;
            var cursos = comboBox3.DataSource as List<CursoResponseDto>;

            List<string> mensajesError = new List<string>();

            if (idsCursosSeleccionados.Contains(idCursoSeleccionado))
            {
                MessageBox.Show("El alumno ya está inscripto en el curso seleccionado.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else if (idsMateriasSeleccionadas.Contains(idMateriaSeleccionada))
            {

                MessageBox.Show("El alumno ya está inscripto en la materia seleccionada.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            idsCursosSeleccionados.Add(idCursoSeleccionado);
            idsMateriasSeleccionadas.Add(idMateriaSeleccionada);
            CursoResponseDto cursoSeleccionado = null;
            foreach (var curso in cursos)
            {
                if (curso.id == idCursoSeleccionado)
                { 
                   
                    cursoSeleccionado = curso;
                    break;
                }
            }

            if (cursoSeleccionado != null)
            {
                textBox2.AppendText("Curso ID: " + cursoSeleccionado.id + Environment.NewLine);
                textBox2.AppendText("Profesor: " + cursoSeleccionado.profesorNombre + Environment.NewLine);
                textBox2.AppendText("Días: " + string.Join(", ", cursoSeleccionado.dias) + Environment.NewLine);

                foreach (var horario in cursoSeleccionado.horarios)
                {
                    textBox2.AppendText("Horario: " + horario.horaInicio + " - " + horario.horaFin + Environment.NewLine);
                }

                textBox2.AppendText("------------------------" + Environment.NewLine);
            }
            else

                MessageBox.Show("Inscripción realizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    }



