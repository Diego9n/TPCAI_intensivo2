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
        public MateriaResponse materias(int Idmateria)
        {
            MateriaRequest materias = new MateriaRequest();
            materias.Id = Idmateria; // Error CS0122 fixed by making 'Id' property public

            // Convert the data to a JSON string
            var jsonData = JsonConvert.SerializeObject(materias);

            HttpResponseMessage response = WebHelper.Post("/tpIntensivo/materias/{carreraId}", jsonData);

            MateriaResponse MateriaResponse = null;

            if (response.IsSuccessStatusCode)
            {
                var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result);
                MateriaResponse = JsonConvert.DeserializeObject<MateriaResponse>(reader.ReadToEnd());
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                if (response.StatusCode.Equals(401))
                {
                    throw new Exception("Error al desplegar materias");
                }

             
            }

            return  MateriaResponse;
        }
    }
    public class MateriaRequest
    {
        public int Id { get; set; } // Changed 'Id' property from private to public to fix CS0122
    }
}
