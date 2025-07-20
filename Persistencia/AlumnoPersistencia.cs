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
    }
}
