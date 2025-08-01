﻿using System;
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool validaringresousuario = false; 
            bool validarcontraseña = false;
            GestorLogin gestorLogin = new GestorLogin();
            Validaciones validaciones = new Validaciones();
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text; 
            try {
               
                validaringresousuario = validaciones.ValidarIngresoUsuario(usuario); 
                validarcontraseña = validaciones.ValidarIngresoContraseña(contraseña); 
                if (validaringresousuario == true && validarcontraseña ==true)
                     { 
                         UsuarioDto tipoPerfil = gestorLogin.Validarcredenciales(usuario, contraseña);
               

                         if (tipoPerfil == null) 
                         {
                                  MessageBox.Show("Usuario o contraseña incorrectos", "Error de autenticación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 return;
                         }else if (tipoPerfil.PerfilUsuario == "PERSONAL") 
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
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error de credenciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }
    }
}