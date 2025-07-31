using Datos;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorCarreras
    {
        CarreraPersistencia CarreraPersistencia = new CarreraPersistencia();
        List<CarreraResponse> carreras = new List<CarreraResponse>();
     
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
