using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using System.Windows.Forms;
using System.Security.Policy;
using System.Linq.Expressions;

namespace TPCAI_intensivo
{
    public partial class ModuloLogin : Form
    {
        public ModuloLogin()
        {
            InitializeComponent();
        }

        private void ModuloLogin_Load(object sender, EventArgs e)
        {
            CargarCarreras();
            CargarProfesores();
            CargarAlumnos();

        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void CargarAlumnos()
        {
            Validar validador = new Validar();
            List<AlumnoDto> alumnos = validador.ObtenerAlumnos();
            label3.Text = "Alumnos";

            foreach (var alumno in alumnos)
            {
                string carrerasTexto = string.Join(", ", alumno.CarrerasIds);
                string linea = $"Nombre: {alumno.Nombre}  Apellido: {alumno.Apellido}  DNI: {alumno.Dni}  Carreras: {carrerasTexto}";

                comboBox3.Items.Add(linea);
            }
        }
        private void CargarCarreras()
        {
            Validar validador = new Validar();
            List<CarreraDto> carreras = validador.ObtenerCarreras();
            label1.Text = "Carreras";

            foreach (var carrera in carreras)
            {
                comboBox1.Items.Add(" ID:  " + carrera.Id + "  Nombre:  " + carrera.Nombre);
            }

        }
        private void CargarProfesores()
        {
            Validar validador = new Validar();
            List<ProfesorDto> profesores = validador.ObtenerProfesores();
            label2.Text = "Profesores";
            foreach (var profesor in profesores)
            {
                comboBox2.Items.Add("ID:  " + profesor.Id + "   Nombre:  " + profesor.Nombre + "  Apellido:  " + profesor.Apellido + " Cuit:  " + profesor.Cuit + " DNI:   " + profesor.Dni + " Antiguedad:   " + profesor.Antiguedad + " Tipo:  " + profesor.Tipo);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool validaringresousuario = false; 
            bool validarcontraseña = false; // para validar si el usuario y la contraseña son correctos
            GestorLogin gestorLogin = new GestorLogin(); // para manejar la clase GestorLogin que se encuentra en la capa de negocio
            Validaciones validaciones = new Validaciones(); //para manejar la clase de validaciones que se encuentra en la capa de negocio
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text; 
            try {
               
                validaringresousuario = validaciones.ValidarIngresoUsuario(usuario); // llama al metodo que se encuentra en la capa de negocio : Validaciones
                validarcontraseña = validaciones.ValidarIngresoContraseña(contraseña); // llama al metodo que se encuentra en la capa de negocio : Validaciones
                if (validaringresousuario == true && validarcontraseña ==true)
                     { 
                              UsuarioDto tipoPerfil = gestorLogin.Validarcredenciales(usuario, contraseña); // llama al metodo que se encuentra en la capa de negocio : GestorLogin
               

                         if (tipoPerfil == null) // verifica si no hay coincidencias da mensaje de error
                         {
                                  MessageBox.Show("Usuario o contraseña incorrectos", "Error de autenticación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 return;
                         }else if (tipoPerfil.PerfilUsuario == "PERSONAL") // dependiendo el perfil direcciona al formulario correspondiente
                         {
                             MessageBox.Show("Bienvenido profesor");
                             ModuloLiquidiacionSueldo moduloLiquidiacionSueldo = new ModuloLiquidiacionSueldo(tipoPerfil);
                             moduloLiquidiacionSueldo.Show();
                             this.Hide();
                         }
                         else if (tipoPerfil.PerfilUsuario == "ADMIN")
                         {
                             MessageBox.Show("Bienvenido Administrador " + usuario);
                             OpcionAdministrador opcionAdministrador = new OpcionAdministrador(tipoPerfil);
                             opcionAdministrador.Show();
                             this.Hide();
                          }
                          else if (tipoPerfil.PerfilUsuario == "ALUMNO")
                          {
                             MessageBox.Show("Bienvenido Alumno " + usuario);
                             ModuloInscripciones moduloInscripciones = new ModuloInscripciones(tipoPerfil);
                             moduloInscripciones.Show();
                             this.Hide();
                          }
                     }
            }
            catch (Exception ex) // captura las excepciones que puedan surgir al momento de validar las credenciales
            {
                MessageBox.Show(ex.Message, "Error de credenciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}