using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestorProfesores
    {
        ProfesorPersistencia ProfesorPersistencia = new ProfesorPersistencia();
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
    }
}
