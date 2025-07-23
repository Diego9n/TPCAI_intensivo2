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

        public List<MateriaResponse> ObtenerMaterias(int idcarrera)
        {
            List<MateriaResponse> materias = new List<MateriaResponse>();
            try
            {
                // Adjusted to handle the return type correctly
                MateriaResponse materia = materiaPersistencia.materias(idcarrera);
                if (materia != null)
                {
                    materias.Add(materia);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las materias: {ex.Message}");
            }
            return materias;
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
