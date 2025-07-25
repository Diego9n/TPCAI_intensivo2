using System;
using System.Collections.Generic;
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
        List<CarreraResponse> carreras = new List<CarreraResponse>();
        List<ProfesorResponse> profesores = new List<ProfesorResponse>();
        MateriaPersistencia materiaPersistencia = new MateriaPersistencia();
        List<MateriaResponse> materias = new List<MateriaResponse>();

        public List<MateriaDto> ObtenerMaterias()
        {
            // Cambiar MateriaPersistencia a materiaPersistencia para usar la instancia de objeto
            var listaResponse = materiaPersistencia.buscarDatosUsuario();

            // Convertir CarreraResponse a CarreraDTO para manejar datos
            // de forma más sencilla en la interfaz de usuario.
            List<MateriaDto> listaDTO = new List<MateriaDto>();
            foreach (var materia in listaResponse)
            {
                listaDTO.Add(new MateriaDto
                {
                    id = (int)materia.id,
                    nombre = materia.nombre,
                    horassemanales = materia.horassemanales,
                    foreach(var correlativa in materia.correlativas)
                {
                    // Asumiendo que correlativa es un objeto con una propiedad 'id'
                    if (materia.correlativas != null)
                    {
                        listaDTO.Last().correlativas.Add(new MateriaDto { id = (int)correlativa.id, nombre = correlativa.nombre });
                    }
                }

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
    }
}
