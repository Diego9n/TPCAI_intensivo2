using Datos;
using Newtonsoft.Json;
using Persistencia.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            public void ModificarPersonal(PersonalRequest personalRequest, int Idpersonal)
            {
                PersonalRequest personalRequest2 = new PersonalRequest
                {
                    nombre = personalRequest.nombre,
                    apellido = personalRequest.apellido,
                    cuit = personalRequest.cuit,
                    dni = personalRequest.dni,
                    tipo = personalRequest.tipo,
                    cursos = personalRequest.cursos
                };

                string jsonData = JsonConvert.SerializeObject(personalRequest2);

                string url = $"tpIntensivo/docentes/{Idpersonal}";

                HttpResponseMessage response = WebHelper.Put(url, jsonData);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    Console.WriteLine("Detalle del error del servidor:");
                    Console.WriteLine(errorContent);
                    throw new Exception("Error al intentar modificar el personal.");
                }
            }
            public void CrearPersonal(PersonalRequest personalRequest)
            {
                PersonalRequest personalRequest2 = new PersonalRequest
                {
                    nombre = personalRequest.nombre,
                    apellido = personalRequest.apellido,
                    cuit = personalRequest.cuit,
                    dni = personalRequest.dni,
                    tipo = personalRequest.tipo,
                    cursos = personalRequest.cursos
                };

                string jsonData = JsonConvert.SerializeObject(personalRequest2);
                HttpResponseMessage response = WebHelper.Post("tpIntensivo/docentes", jsonData);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    Console.WriteLine("Detalle del error del servidor:");
                    Console.WriteLine(errorContent);
                    throw new Exception("Error al intentar crear el personal.");
                }
            }
            public void EliminarPersonal(int ideliminar)
            {
                HttpResponseMessage response = WebHelper.Delete($"tpIntensivo/docentes/{ideliminar}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show($"Error al eliminar el usuario. Código: {response.StatusCode}");
                }


            }
    }

}
