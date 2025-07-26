using Datos;
using Newtonsoft.Json;
using Persistencia.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class MateriaPersistencia
    {

        public List<MateriaResponse> buscarDatosUsuario(int idcarrera)
        {
            int idCarrera = idcarrera;
            List<MateriaResponse> materias = new List<MateriaResponse>();

            HttpResponseMessage response = WebHelper.Get($"tpIntensivo/materias/{idCarrera}");

            if (response.IsSuccessStatusCode)
            {
                var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result);
                string json = reader.ReadToEnd();

                materias = JsonConvert.DeserializeObject<List<MateriaResponse>>(json);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                throw new Exception("Error al momento de buscar las materias");
            }

            return materias;


        }
    }
}
    