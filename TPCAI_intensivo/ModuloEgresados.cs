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
    public partial class ModuloEgresados : Form
    {
        private Validar gestorNegocio = new Validar();
        public ModuloEgresados()
        {
            InitializeComponent();
        }

        private void ModuloEgresados_Load(object sender, EventArgs e)
        {
            CargarCarrerasEnComboBox();
            ConfigurarDataGridView();
        }
        private void CargarCarrerasEnComboBox()
        {
            try
            {
                List<CarreraDto> listaDeCarreras = gestorNegocio.ObtenerCarreras();
                comboBoxCarrera.DataSource = listaDeCarreras;
                comboBoxCarrera.DisplayMember = "Nombre";
                comboBoxCarrera.ValueMember = "Id";
                comboBoxCarrera.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de carreras: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (comboBoxCarrera.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione una carrera de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int idCarreraSeleccionada = (int)comboBoxCarrera.SelectedValue;
                List<AlumnoDto> todosLosAlumnos = gestorNegocio.ObtenerAlumnos();
                List<MateriaDto> materiasDeLaCarrera = gestorNegocio.ObtenerMateriasPorCarrera(idCarreraSeleccionada);
                var listaDeEgresados = new List<EgresadoReporte>();

                foreach (var alumno in todosLosAlumnos)
                {
                    if (alumno.CarrerasIds.Contains(idCarreraSeleccionada))
                    {
                        List<MateriaAlumnoDto> materiasDelAlumno = gestorNegocio.ObtenerMateriasDeAlumno(alumno.Id);

                        if (EsEgresado(materiasDeLaCarrera, materiasDelAlumno))
                        {
                            listaDeEgresados.Add(new EgresadoReporte
                            {
                                Nombre = alumno.Nombre,
                                Apellido = alumno.Apellido,
                                DNI = alumno.Dni
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + ex.Message, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool EsEgresado(List<MateriaDto> materiasRequeridas, List<MateriaAlumnoDto> materiasCursadas)
        {
            return materiasRequeridas.All(materiaRequerida =>
            materiasCursadas.Any(materiaCursada =>
            materiaCursada.Id == materiaRequerida.Id && materiaCursada.Condicion == "APROBADO"));
        }
        private void ConfigurarDataGridView()
        {
            dgvTodosLosEgresados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTodosLosEgresados.ReadOnly = true;
            dgvTodosLosEgresados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
    public class EgresadoReporte
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
    }
}

