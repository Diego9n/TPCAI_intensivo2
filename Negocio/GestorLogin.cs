using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorLogin
    {
        LoginPersistencia loginPersistencia = new LoginPersistencia();
        LoginResponse loginResponse = new LoginResponse();


        public UsuarioDto Validarcredenciales(string username, string password)
        {
          
            LoginResponse usuariologin = loginPersistencia.login(username, password);
            if (usuariologin.PerfilUsuario == "PERSONAL")
            {
                return new UsuarioDto
                {
                    Id = usuariologin.Id,
                    PerfilUsuario = usuariologin.PerfilUsuario
                };
            } else if (usuariologin.PerfilUsuario == "ALUMNO")
                {
                return new UsuarioDto
                {
                    Id = usuariologin.Id,
                    PerfilUsuario = usuariologin.PerfilUsuario
                };
               } else if (usuariologin.PerfilUsuario == "ADMIN")
                 {
                return new UsuarioDto
                {
                    Id = usuariologin.Id,
                    PerfilUsuario = usuariologin.PerfilUsuario
                };

            }
            return null;
        
        }
        public void DesbloquearUsuario(int id)
        {
            loginPersistencia.DesbloquearUsuario(id);
        }


    }


}
