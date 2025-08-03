using Datos;
using Newtonsoft.Json;
using Persistencia.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
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
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                string errorJson = response.Content.ReadAsStringAsync().Result;

                dynamic error = JsonConvert.DeserializeObject<dynamic>(errorJson);
                string code = error.code;
                string message = error.message;

                if (code == "USER_BLOCKED")
                {
                    throw new Exception("El usuario se encuentra bloqueado.");
                }
                else if (code == "INVALID_CREDENTIALS")
                {
                    throw new Exception("Las credenciales ingresadas no son válidas.");
                }
                else
                {
                    throw new Exception("Error de autenticación: " + message);
                }
            }
            else
            {
                throw new Exception("Error inesperado: " + response.ReasonPhrase);
            }
        
        

            return loginResponse;
        }
        public void DesbloquearUsuario(int id)
        {
            DesbloquearUsuarioRequest datos = new DesbloquearUsuarioRequest
            {
                idUsuario = id
            };

            var jsonData = JsonConvert.SerializeObject(datos);
            HttpResponseMessage response = WebHelper.Post("tpIntensivo/desbloquear", jsonData);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                throw new Exception("Error al intentar desbloquear el usuario.");
            }
        }
    }
}
