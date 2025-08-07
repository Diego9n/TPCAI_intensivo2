using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPCAI_intensivo
{
    public partial class ModuloInscripciones : Form
    {
        private List<MateriaDto> materias;
        GestorInscripciones gestorInscripciones = new GestorInscripciones();
        UsuarioDto usuarioalumno = new UsuarioDto();
        List<int> idsMateriasSeleccionadas = new List<int>();
        List<int> idsCursosSeleccionados = new List<int>();
        List<CursoResponseDto> CursosAgregados = new List<CursoResponseDto>();
        List<AlumnoCondicionDto> finalesinscriptos = new List<AlumnoCondicionDto>();
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
            cmbModalidad.Text = "seleccione la modalidad a inscribirse";
            comboBox2.Enabled = false;
            comboBox1.Enabled = false;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = carreras;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            button2.Enabled = false;
            button5.Enabled = false;
            cmbModalidad.Items.Add("inscripcion a cursada Normal");
            cmbModalidad.Items.Add("Inscripcion a finales");



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
                var carreraSeleccionada = (CarreraDto)comboBox1.SelectedItem;

                materias = gestorInscripciones.ObtenerMateriasHabilitadas(carreraSeleccionada.Id, (int)usuarioalumno.Id);

                comboBox2.DataSource = materias;
                comboBox2.DisplayMember = "Nombre";
                comboBox2.ValueMember = "Id";

                double ranking = gestorInscripciones.ObtenerRanking(
                    (int)usuarioalumno.Id, carreraSeleccionada);
                label3.Text = "N RANKING : " + ranking.ToString("0.00");
            }
            else
            {
                label3.Text = "Seleccioná una carrera.";
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int idCurso = (int)comboBox2.SelectedValue;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
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
            textBox1.SelectionStart = 0;
            textBox1.ScrollToCaret();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            CursoResponseDto cursoDto = new CursoResponseDto();
            button2.Enabled = true;
            bool horario2 = false;
            int idMateriaSeleccionada = (int)comboBox2.SelectedValue;
            int idCursoSeleccionado = (int)comboBox3.SelectedValue;
            var cursos = comboBox3.DataSource as List<CursoResponseDto>;
            GestorInscripciones gestorInscripciones = new GestorInscripciones();
            ;

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
            horario2 = gestorInscripciones.HorariosCursos(cursos, CursosAgregados, idCursoSeleccionado);
            if (horario2 == true)
            {
                MessageBox.Show("El alumno ya está inscripto en un curso con horarios solapados.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    CursosAgregados.Add(curso);
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



        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbModalidad.SelectedItem != null)
            {
                if (cmbModalidad.SelectedItem.ToString() == "inscripcion a cursada Normal")
                {
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                    button1.Enabled = true;
                    button2.Enabled = false;
                    button5.Enabled = true;

                }
                else if (cmbModalidad.SelectedItem.ToString() == "Inscripcion a finales")
                {
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = true;
                    groupBox2.Enabled = false;
                    groupBox3.Enabled = false;
                    button2.Enabled = true;
                    button1.Enabled = false;
                    button5.Enabled = false;
                    Finales();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una modalidad de inscripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Finales()
        {
            List<AlumnoCondicionDto> finales = new List<AlumnoCondicionDto>();


            finales = gestorInscripciones.ObtenerMateriasFinales((int)usuarioalumno.Id);
            comboBox2.DataSource = finales;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "Id";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool AceptarIsncripcion = false;
            if (textBox2 == null)
            {
                MessageBox.Show("No hay cursos seleccionados para inscribir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult resultado = MessageBox.Show("¿Confirma Inscripcion?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == resultado)
            {
                if (cmbModalidad.Text == "inscripcion a cursada Normal")
                {
                    MessageBox.Show("Inscripcion Aceptada");
                    try
                    {
                        GestorInscripciones gestorInscripciones = new GestorInscripciones();
                        gestorInscripciones.InscribirAlumno((int)usuarioalumno.Id, idsCursosSeleccionados);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    limpiarDatos();
                }
                else if (cmbModalidad.Text == "Inscripcion a finales")
                {

                    AlumnoCondicionDto materiaSeleccionada = (AlumnoCondicionDto)comboBox2.SelectedItem;
                    AceptarIsncripcion = gestorInscripciones.ValidarFinal(materiaSeleccionada, finalesinscriptos);
                    if (AceptarIsncripcion == true)
                    {
                        MessageBox.Show("La materia seleccionada ya se encuentra inscripta para rendir el final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (AceptarIsncripcion == false)
                    {
                        finalesinscriptos.Add(materiaSeleccionada);

                        MessageBox.Show("Inscripcion a final Aceptada");
                        limpiarDatos();
                    }
                }
                else if (DialogResult.No == resultado)
                {
                    MessageBox.Show("Inscripción cancelada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }





                limpiarDatos();

            }
        }


        private void limpiarDatos()
        {

            cmbModalidad.Text = "Seleccionseleccione la modalidad a inscribirse";
            textBox1.Clear();
            textBox2.Clear();
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            button2.Enabled = false;
            button5.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            button1.Enabled = false;
            idsMateriasSeleccionadas.Clear();
            idsCursosSeleccionados.Clear();
            CursosAgregados.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Confirma Cancelacion , borrara todos los datos ingresados?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado.Equals(DialogResult.Yes))
            {
                limpiarDatos();


            }
        }
    }

}


