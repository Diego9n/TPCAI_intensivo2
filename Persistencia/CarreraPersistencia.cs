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
            HttpResponseMessage response = WebHelper.Get($"tpIntensivo/materias/{carreraId}");
            if (response.IsSuccessStatusCode)
            {
                var contentStream = response.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    Error = (sender, args) =>
                    {
                        args.ErrorContext.Handled = true;
                    }
                };
                var listaMaterias = JsonConvert.DeserializeObject<List<MateriaResponse>>(contentStream, settings);
                foreach (var materia in listaMaterias)
                {
                    if (materia.Correlativas == null)
                    {
                        materia.Correlativas = new List<string>();
                    }
                }
                return listaMaterias;
            }
            else
            {
                throw new Exception($"Error al buscar las materias de la carrera. Código de estado: {response.StatusCode}");
            }
        }
    }
}
