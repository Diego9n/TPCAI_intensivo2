using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorCRUDPersonal
    {
        List<ProfesorResponse> profesores = new List<ProfesorResponse>();
        ProfesorPersistencia ProfesorPersistencia = new ProfesorPersistencia();
        public ProfesorDto BuscarProfesorID(int IdPersonal)
        {
            ProfesorDto profesorDto = new ProfesorDto();
            foreach (var profesor in ObtenerProfesores())
            {
                if (profesor.Id == IdPersonal)
                {
                    profesorDto.Id = (int)profesor.Id;
                    profesorDto.Nombre = profesor.Nombre;
                    profesorDto.Apellido = profesor.Apellido;
                    profesorDto.Cuit = profesor.Cuit;
                    profesorDto.Dni = profesor.Dni;
                    profesorDto.Antiguedad = profesor.Antiguedad;
                    profesorDto.Tipo = profesor.Tipo;
                    break; // Salir del bucle una vez encontrado
                }
            }
            return profesorDto;
        }
        public List<ProfesorDto> ObtenerProfesores()
        {

            var listaResponse = ProfesorPersistencia.buscarDatosUsuario();
            List<ProfesorDto> listaDTO = new List<ProfesorDto>();
            foreach (var profesor in listaResponse)
            {
                listaDTO.Add(new ProfesorDto
                {
                    Id = (int)profesor.Id,
                    Nombre = profesor.Nombre,
                    Apellido = profesor.Apellido,
                    Cuit = profesor.Cuit,
                    Dni = profesor.Dni,
                    Antiguedad = profesor.Antiguedad,
                    Tipo = profesor.Tipo
                });
            }
            return listaDTO;
        }
        public void ModificarPersonal(PersonalDtoRequest personalRequest, int Idpersonal)

        {
            
            var personalRequestDatos = new Datos.PersonalRequest
            {
                nombre = personalRequest.Nombre,
                apellido = personalRequest.Apellido,
                cuit = personalRequest.Cuit,
                dni = personalRequest.Dni,
                tipo = personalRequest.Tipo,
                cursos = personalRequest.Cursos
            };

            ProfesorPersistencia.ModificarPersonal(personalRequestDatos, Idpersonal);
        }
        public void CrearPersonaL(PersonalDtoRequest personalRequest)
        {
            var personalRequestDatos = new Datos.PersonalRequest
            {
                nombre = personalRequest.Nombre,
                apellido = personalRequest.Apellido,
                cuit = personalRequest.Cuit,
                dni = personalRequest.Dni,
                tipo = personalRequest.Tipo,
                cursos = personalRequest.Cursos
            };
            ProfesorPersistencia.CrearPersonal(personalRequestDatos);
        }

        public void EliminarPersonal(int IdPersonal)
        {
            ProfesorPersistencia.EliminarPersonal(IdPersonal);
        }
    }
}
