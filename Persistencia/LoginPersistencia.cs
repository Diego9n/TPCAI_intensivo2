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
using System.Windows.Forms;

namespace Persistencia
{
    public class LoginPersistencia
    {
        public LoginResponse login(String username, String password)
        {

            LoginRequest datos = new LoginRequest();
            datos.user = username;
            datos.password = password;

            // Convert the data to a JSON string
            var jsonData = JsonConvert.SerializeObject(datos);

            HttpResponseMessage response = WebHelper.Post("tpIntensivo/login", jsonData);

            LoginResponse loginResponse = null;

            if (response.IsSuccessStatusCode)
            {
                var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result);
                loginResponse = JsonConvert.DeserializeObject<LoginResponse>(reader.ReadToEnd());
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                if (response.StatusCode.Equals(401))
                {
                    throw new Exception("Usuario bloqueado");
                }

                datos.user ="" ;
                datos.password = "";    
            }

            return loginResponse;
        }
    }
}
