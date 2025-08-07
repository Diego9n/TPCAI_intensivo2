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
                    return profesorDto; 
                   
                }
            }
            return null;
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
        public List<int> CursosPersonal(int profesorid)
        {
            List<int> cursosContados = new List<int>();
            GestorCarreras gestorCarreras = new GestorCarreras();
            GestorMaterias gestorMaterias = new GestorMaterias();
            SueldoPersonal sueldoPersonal = new SueldoPersonal();
            GestorProfesores gestorProfesores = new GestorProfesores();
            List<ProfesorDto> listaProfesores = gestorProfesores.ObtenerProfesores();
            List<CarreraDto> ListaCarreras = gestorCarreras.ObtenerCarreras();

            foreach (var carreras in ListaCarreras)
            {
                List<MateriaDto> listaMaterias = gestorMaterias.ObtenerMaterias(carreras.Id);

                foreach (var materias in listaMaterias)
                {
                    List<CursoResponseDto> listaCursos = gestorMaterias.ObtenerCursos(materias.Id);
                    foreach (var cursos in listaCursos)
                    {
                        if (cursosContados.Contains(cursos.id))
                            continue;
                        foreach (var listaprofesores in cursos.idDocentes)
                        {
                            if (profesorid == listaprofesores)
                            {

                                cursosContados.Add(cursos.id);
                                break;
                            }


                        }


                    }


                }
            }
            return cursosContados;
        }
    }
}
