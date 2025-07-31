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
        public void ConfigurarDataGridView()
        {
            dgvTodosLosEgresados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTitulosHonorificos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void ModuloEgresados_Load(object sender, EventArgs e)
        {
            CargarCarrerasEnComboBox();
            ConfigurarDataGridView();
        }
        public void CargarCarrerasEnComboBox()
        {
            try
            {
                comboBoxCarrera.DataSource = gestorNegocio.ObtenerCarreras();
                comboBoxCarrera.DisplayMember = "Nombre";
                comboBoxCarrera.ValueMember = "Id";
                comboBoxCarrera.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de carreras: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void btnAceptar_Click(object sender, EventArgs e)
        {
            if (comboBoxCarrera.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione una carrera.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dgvTodosLosEgresados.DataSource = null;
                dgvTitulosHonorificos.DataSource = null;

                int idCarreraSeleccionada = (int)comboBoxCarrera.SelectedValue;

                List<MateriaDto> materiasRequeridas = gestorNegocio.ObtenerMateriasPorCarrera(idCarreraSeleccionada);
                List<AlumnoDto> todosLosAlumnos = gestorNegocio.ObtenerAlumnos();

                if (materiasRequeridas == null || !materiasRequeridas.Any())
                {
                    MessageBox.Show("No se pudo obtener el plan de estudios o la carrera no tiene materias cargadas.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var listaDeEgresados = new List<EgresadoReporte>();

                foreach (var alumno in todosLosAlumnos)
                {
                    if (alumno.CarrerasIds != null && alumno.CarrerasIds.Contains(idCarreraSeleccionada))
                    {
                        List<MateriaAlumnoDto> materiasDelAlumno = gestorNegocio.ObtenerMateriasDeAlumno(alumno.Id);
                        if (EsEgresado(materiasRequeridas, materiasDelAlumno))
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

                if (!listaDeEgresados.Any())
                {
                    MessageBox.Show("No se encontraron egresados para la carrera seleccionada (ningún alumno ha aprobado todas las materias).", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvTodosLosEgresados.DataSource = listaDeEgresados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + ex.Message, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public bool EsEgresado(List<MateriaDto> materiasRequeridas, List<MateriaAlumnoDto> materiasCursadas)
        {
            if (materiasCursadas == null) return false;

            var idsMateriasRequeridas = materiasRequeridas.Select(m => m.Id).ToHashSet();

            var idsMateriasAprobadas = materiasCursadas
                .Where(m => m.Condicion != null && m.Condicion.Trim().Equals("APROBADO", StringComparison.OrdinalIgnoreCase))
                .Select(m => m.Id)
                .ToHashSet();

            return idsMateriasRequeridas.IsSubsetOf(idsMateriasAprobadas);
        }
    }
    public class EgresadoReporte
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
    }
}

