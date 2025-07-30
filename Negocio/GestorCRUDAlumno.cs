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
               carrerasIds = alumnoRequest.carrerasIds
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
            bool encontrado= false;
            List<AlumnoDto> listaAlumnos = ObtenerAlumnos();
            foreach (var alumno in listaAlumnos)
            {
                if (alumno.Id == id)
                {
                    alumnoDto.Id = (int)alumno.Id;
                    alumnoDto.Nombre = alumno.Nombre;
                    alumnoDto.Apellido = alumno.Apellido;
                    alumnoDto.Dni = alumno.Dni;
                    alumnoDto.CarrerasIds = alumno.CarrerasIds;
                    encontrado= true;   
                    break; 
                } 
               
            }
            if (!encontrado)
            {

               alumnoDto = null;
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
                    Id = alumno.Id,
                    Nombre = alumno.Nombre,
                    Apellido = alumno.Apellido,
                    Dni = alumno.Dni,
                    CarrerasIds = alumno.CarrerasIds
                });
            }
            return listaDTO;
        }
        public void ModificarAlumno(AlumnoDtoRequest alumnoRequest, int idalumno)
        {
            AlumnoPersistencia alumnopersistencia = new AlumnoPersistencia();
            var alumnorequestdatos = new Datos.AlumnoRequest
            {
                id = alumnoRequest.id,
                nombre = alumnoRequest.nombre,
                apellido = alumnoRequest.apellido,
                dni = alumnoRequest.dni,
                carrerasIds = alumnoRequest.carrerasIds
            };
            alumnopersistencia.ModificarAlumno(idalumno, alumnorequestdatos);
        }
    }
}

