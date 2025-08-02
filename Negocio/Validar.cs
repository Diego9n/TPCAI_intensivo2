using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Datos;
using System.Windows.Forms;



namespace Negocio
{
    public class Validar
    {
        CarreraPersistencia CarreraPersistencia = new CarreraPersistencia();
        ProfesorPersistencia ProfesorPersistencia = new ProfesorPersistencia();
        List<CarreraResponse> carreras = new List<CarreraResponse>();
        List<ProfesorResponse> profesores = new List<ProfesorResponse>();

        public List<CarreraDto> ObtenerCarreras()
        {
            var listaResponse = CarreraPersistencia.buscarDatosUsuario();

            // Convertir CarreraResponse a CarreraDTO para manejar datos
            // de forma más sencilla en la interfaz de usuario.
            List<CarreraDto> listaDTO = new List<CarreraDto>();
            foreach (var carrera in listaResponse)
            {
                listaDTO.Add(new CarreraDto
                {
                    Id = (int)carrera.Id,
                    Nombre = carrera.Nombre
                });
            }

            return listaDTO;
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

        public int validarcredenciales(string nombreusuario)
        {
            int aceptar_tipo = 0;
            return aceptar_tipo;
        }
        public List<MateriaDto> ObtenerMateriasPorCarrera(int carreraId)
        {
            var persistencia = new CarreraPersistencia();
            List<MateriaResponse> materiasResponse = persistencia.ObtenerMateriasPorCarrera(carreraId);
            var listaDto = new List<MateriaDto>();

            foreach (var materiaResponse in materiasResponse)
            {
                listaDto.Add(new MateriaDto
                {
                    Id = materiaResponse.Id,
                    Nombre = materiaResponse.Nombre
                });
            }
            return listaDto;
        }
        public List<MateriaAlumnoDto> ObtenerMateriasDeAlumno(int alumnoId)
        {
            var persistencia = new AlumnoPersistencia();
            List<MateriaAlumnoResponse> materiasResponse = persistencia.ObtenerMateriasDeAlumno(alumnoId);

            var listaDto = new List<MateriaAlumnoDto>();
            foreach (var materiaResponse in materiasResponse)
            {
                listaDto.Add(new MateriaAlumnoDto
                {
                    Id = materiaResponse.Id,
                    Nombre = materiaResponse.Nombre,
                    Condicion = materiaResponse.Condicion,
                    Nota = materiaResponse.Nota
                });
            }
            return listaDto;
        }
    }
}
