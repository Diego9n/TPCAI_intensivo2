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
    public class CarreraPersistencia
    {

        public List<CarreraResponse> buscarDatosUsuario()
        {
            List<CarreraResponse> carreras = new List<CarreraResponse>();

            HttpResponseMessage response = WebHelper.Get("tpIntensivo/carreras");

            if (response.IsSuccessStatusCode)
            {
                var contentStream = response.Content.ReadAsStringAsync().Result;
                List<CarreraResponse> listadoClientes = JsonConvert.DeserializeObject<List<CarreraResponse>>(contentStream);
                return listadoClientes;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                throw new Exception("Error al momento de buscar los usuarios");
            }

            return carreras;
        }
        public List<MateriaResponse> ObtenerMateriasPorCarrera(int carreraId)
        {
            try
            {
                // Hacemos la llamada a la API
                HttpResponseMessage response = WebHelper.Get($"tpIntensivo/materias/{carreraId}");

                if (!response.IsSuccessStatusCode)
                {
                    return new List<MateriaResponse>();
                }

                var contentStream = response.Content.ReadAsStringAsync().Result;
                var listaMaterias = JsonConvert.DeserializeObject<List<MateriaResponse>>(contentStream);

                if (listaMaterias == null)
                {
                    return new List<MateriaResponse>();
                }

                return listaMaterias;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener/deserializar materias: {ex.Message}");
                return new List<MateriaResponse>();
            }

        }
    }
}
