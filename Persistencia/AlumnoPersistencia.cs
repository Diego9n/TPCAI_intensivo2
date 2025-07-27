using Datos;
using Newtonsoft.Json;
using Persistencia.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class AlumnoPersistencia
    {
        public List<AlumnoResponse> buscarDatosUsuario()
        {
            List<AlumnoResponse> alumnos = new List<AlumnoResponse>();

            HttpResponseMessage response = WebHelper.Get("tpIntensivo/alumnos");

            if (response.IsSuccessStatusCode)
            {
                var contentStream = response.Content.ReadAsStringAsync().Result;
                List<AlumnoResponse> listadoClientes = JsonConvert.DeserializeObject<List<AlumnoResponse>>(contentStream);
                return listadoClientes;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                throw new Exception("Error al momento de buscar los usuarios");
            }

            return alumnos;
        }
        public List<MateriaAlumnoResponse> ObtenerMateriasDeAlumno(int alumnoId)
        {
            HttpResponseMessage response = WebHelper.Get($"tpIntensivo/alumno/{alumnoId}/materias");

            if (response.IsSuccessStatusCode)
            {
                var contentStream = response.Content.ReadAsStringAsync().Result;
                List<MateriaAlumnoResponse> listaMaterias = JsonConvert.DeserializeObject<List<MateriaAlumnoResponse>>(contentStream);

                return listaMaterias;
            }
            else
            {
                throw new Exception($"Error al buscar las materias del alumno. Código de estado: {response.StatusCode}");
            }
        }
    }
}
