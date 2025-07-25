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
    public partial class CrearPersonal : Form
    {

        UsuarioDto UsuarioDto { get; set; }
        public CrearPersonal(UsuarioDto usuarioDto)
        {
            InitializeComponent();
            UsuarioDto = usuarioDto;
        }

        private void CrearPersonal_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("PROFESOR");
            comboBox1.Items.Add("AYUDANTE");
            comboBox1.Items.Add("AYUDANTE_AD_HONOREM");


        }


        private void btnCrearPersonal_Click_1(object sender, EventArgs e)
        {
            string cursosTexto = txtCursos.Text; // Ej: "100,101,102"
            string[] partes = cursosTexto.Split(','); // Separar por coma

            List<int> listaCursos = new List<int>();

            foreach (string parte in partes)
            {
                listaCursos.Add(int.Parse(parte.Trim())); // Convertir cada parte a int
            }

            PersonalDtoRequest personalDtoRequest = new PersonalDtoRequest
            {
                Nombre = textBox2.Text,
                Apellido = textBox3.Text,
                Dni = textBox4.Text,
                Cuit = textBox5.Text,
                Tipo = comboBox1.Text,
                Cursos = listaCursos
            };
            GestorCRUDPersonal gestorCRUDPersonal = new GestorCRUDPersonal();
            try
            {
                gestorCRUDPersonal.CrearPersonaL(personalDtoRequest);
                MessageBox.Show("Personal creado exitosamente.");
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
    }
    
}

