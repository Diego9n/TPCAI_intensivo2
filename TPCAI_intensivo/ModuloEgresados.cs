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
        }
    }
}
