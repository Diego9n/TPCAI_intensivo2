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
            idcarrera = 1;
            MateriaResponse materia = new MateriaResponse();
            List<MateriaResponse> materias = new List<MateriaResponse>();


            HttpResponseMessage response = WebHelper.Get($"tpIntensivo/materias/{idcarrera}");

                if (response.IsSuccessStatusCode)
                {
               
                    var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result);
                    materia = JsonConvert.DeserializeObject<MateriaResponse>(reader.ReadToEnd());
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
    