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
        public List<AlumnoCondicionResponse> BuscarConddiconAlumno(int idalumno)
        {
           
            List<AlumnoCondicionResponse> alumnoCondicion = new List<AlumnoCondicionResponse>();

            HttpResponseMessage response = WebHelper.Get($"tpIntensivo/alumno/{idalumno}/materias");

            if (response.IsSuccessStatusCode)
            {
                var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result);
                string json = reader.ReadToEnd();

                alumnoCondicion = JsonConvert.DeserializeObject<List<AlumnoCondicionResponse>>(json);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                throw new Exception("Error al momento de buscar las materias");
            }

            return alumnoCondicion;


        }
    }
}
