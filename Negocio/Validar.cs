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

            // Convertir CarreraResponse a CarreraDTO  
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

        public int validarcredenciales(string nombreusuario)
        {
            int aceptar_tipo = 0;   



            return aceptar_tipo;
        }
    }
}
