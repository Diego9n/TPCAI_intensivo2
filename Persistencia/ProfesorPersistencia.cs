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
    public class ProfesorPersistencia
    {

        public List<ProfesorResponse> buscarDatosUsuario()
        {
            List<ProfesorResponse> Profesores = new List<ProfesorResponse>();

            HttpResponseMessage response = WebHelper.Get("tpIntensivo/docentes");

            if (response.IsSuccessStatusCode)
            {
                var contentStream = response.Content.ReadAsStringAsync().Result;
                List<ProfesorResponse> listadoClientes = JsonConvert.DeserializeObject<List<ProfesorResponse>>(contentStream);
                return listadoClientes;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                throw new Exception("Error al momento de buscar los usuarios");
            }

            return Profesores;
        }
    }
}
