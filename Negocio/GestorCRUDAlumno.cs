using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorCRUDAlumno
    {
        public void CrearAlumno(AlumnoDtoRequest alumnoRequest)
        {
           AlumnoPersistencia alumnopersistencia = new AlumnoPersistencia();

           var alumnorequestdatos = new Datos.AlumnoRequest
           {
               nombre = alumnoRequest.nombre,
               apellido = alumnoRequest.apellido,
               dni = alumnoRequest.dni,
               carreras = alumnoRequest.carreras
           };
            alumnopersistencia.CrearAlumno(alumnorequestdatos);
        }   
        public void EliminarAlumno(int ideliminar)
        {
            AlumnoPersistencia alumnopersistencia = new AlumnoPersistencia();
            alumnopersistencia.EliminarAlumno(ideliminar);
        }   
     
        public AlumnoDto BuscarAlumnoID(int id) 
        {
            AlumnoDto alumnoDto = new AlumnoDto();  
            foreach (var alumno in ObtenerAlumnos())
            {
                if (alumno.id == id)
                {
                    alumnoDto.id = (int)alumno.id;
                    alumnoDto.Nombre = alumno.Nombre;
                    alumnoDto.Apellido = alumno.Apellido;
                    alumnoDto.Dni = alumno.Dni;
                    alumnoDto.CarrerasIds = alumno.CarrerasIds;
                    break; // Salir del bucle una vez encontrado
                }
            }
            
         
            return alumnoDto;

        }
        public List<AlumnoDto> ObtenerAlumnos()
        {
            AlumnoPersistencia alumnoPersistencia = new AlumnoPersistencia();
            var listaResponse = alumnoPersistencia.buscarDatosUsuario();
            List<AlumnoDto> listaDTO = new List<AlumnoDto>();
            foreach (var alumno in listaResponse)
            {
                listaDTO.Add(new AlumnoDto
                {
                    Nombre = alumno.Nombre,
                    Apellido = alumno.Apellido,
                    Dni = alumno.Dni,
                    CarrerasIds = alumno.CarrerasIds
                });
            }
            return listaDTO;
        }
    }
}
