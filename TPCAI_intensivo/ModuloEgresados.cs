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
using static Negocio.GestorEgresados;

namespace TPCAI_intensivo
{
    public partial class ModuloEgresados : Form
    {
        public Form _menuAnterior;
        public GestorEgresados _gestorEgresados = new GestorEgresados();

        public ModuloEgresados(Form menuAnterior)
        {
            InitializeComponent(); _menuAnterior = menuAnterior;
        }
        public ModuloEgresados()
        {
            InitializeComponent();
        }
        public void ModuloEgresados_Load(object sender, EventArgs e)
        {
            CargarCarrerasEnComboBox();
            ConfigurarDataGridViews();
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
                List<EgresadoReporte> listaDeEgresados = _gestorEgresados.GenerarReporteEgresados(idCarreraSeleccionada);

                if (!listaDeEgresados.Any())
                {
                    MessageBox.Show("No se encontraron egresados para la carrera seleccionada (ningún alumno ha aprobado todas las materias).", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                    return;
                }

                dgvTodosLosEgresados.DataSource = listaDeEgresados;
                dgvTodosLosEgresados.Columns["Promedio"].Visible = false;
                dgvTodosLosEgresados.Columns["TituloHonorifico"].Visible = false;

                var egresadosConHonor = listaDeEgresados.Where(egresadoh => egresadoh.TituloHonorifico != "Ninguno").ToList();
                dgvTitulosHonorificos.DataSource = egresadosConHonor;
                if (egresadosConHonor.Any())
                {
                    dgvTitulosHonorificos.Columns["Promedio"].FillWeight = 50;
                    dgvTitulosHonorificos.Columns["TituloHonorifico"].FillWeight = 150;
                    dgvTitulosHonorificos.Columns["DNI"].FillWeight = 80;
                }
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
        public void CargarCarrerasEnComboBox()
        {
            try
            {
                comboBoxCarrera.DataSource = _gestorEgresados.ObtenerCarreras();
                comboBoxCarrera.DisplayMember = "Nombre";
                comboBoxCarrera.ValueMember = "Id";
                comboBoxCarrera.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de carreras: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ConfigurarDataGridViews()
        {
            dgvTodosLosEgresados.ReadOnly = true;
            dgvTodosLosEgresados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTodosLosEgresados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTitulosHonorificos.ReadOnly = true;
            dgvTitulosHonorificos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTitulosHonorificos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _menuAnterior.Show();
            this.Close();
        }
    }
}