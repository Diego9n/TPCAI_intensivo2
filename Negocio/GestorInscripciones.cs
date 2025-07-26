using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;

namespace Negocio
{
    public class GestorInscripciones
    {
        CarreraPersistencia CarreraPersistencia = new CarreraPersistencia();
        ProfesorPersistencia ProfesorPersistencia = new ProfesorPersistencia();
        AlumnoPersistencia AlumnoPersistencia = new AlumnoPersistencia();
        List<CarreraResponse> carreras = new List<CarreraResponse>();
        List<ProfesorResponse> profesores = new List<ProfesorResponse>();
        MateriaPersistencia materiaPersistencia = new MateriaPersistencia();
        List<MateriaResponse> materias = new List<MateriaResponse>();

        public List<MateriaDto> ObtenerMaterias(int idcarrera)
        {
           
            var listaResponse = materiaPersistencia.buscarDatosUsuario(idcarrera);
            List<MateriaDto> listaDTO = new List<MateriaDto>();
            foreach (var materia in listaResponse)
            {
                listaDTO.Add(new MateriaDto
                {
                    id = (int)materia.id,
                    nombre = materia.nombre,
                    horassemanales = materia.horassemanales,

            });
            }

            return listaDTO;
        }

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
        public List<AlumnoCondicionDto> ObtenerAlumnoCondicion(int idalummno)
        {
          
            var listaResponse = AlumnoPersistencia.BuscarConddiconAlumno(idalummno);
            List<AlumnoCondicionDto> listaDTO = new List<AlumnoCondicionDto>();
            foreach (var Acondicion in listaResponse)
            {
                listaDTO.Add(new AlumnoCondicionDto
                {
                    id = (int)Acondicion.id,
                    nombre = Acondicion.nombre,
                    condicion = Acondicion.condicion,
                    nota = Acondicion.nota ?? 0 // Asignar 0 si nota es null

                });
            }



            return listaDTO; }
        public List<MateriaDto> MateriasRestantes(int idcarrera,int idalumno)
        {
            List<MateriaDto> listaDTO = new List<MateriaDto>(); 
            List<AlumnoCondicionResponse> listaCondicion = new List<AlumnoCondicionResponse>();
            List<MateriaDto> listaMaterias = new List<MateriaDto>();
            listaDTO = ObtenerMaterias(idcarrera);  
            listaCondicion = AlumnoPersistencia.BuscarConddiconAlumno(idalumno);  
            
           foreach (var listM in listaDTO)
            {
               bool Aprobada = false;
               
               foreach (var condicion in listaCondicion)
                {
                    if (condicion.id == listM.id)
                    {
                        string estado = condicion.condicion?.ToUpper(); // seguridad por si viene null

                        if (estado == "APROBADO" || estado == "FINAL" || estado == "INSCRIPTO")
                        {
                            Aprobada = true;
                            break;
                        }
                    }
                }

                if (!Aprobada)
               {
                    listaMaterias.Add(listM);
               }


                


            }


            return listaMaterias;    
        }
    }
}
