﻿using Datos;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Persistencia.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        public void CrearAlumno (AlumnoRequest alumnoRequest)
        {
            string jsonData = JsonConvert.SerializeObject(alumnoRequest);
            HttpResponseMessage response = WebHelper.Post("tpIntensivo/alumno", jsonData);

            if (!response.IsSuccessStatusCode)
            {
                string errorContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                Console.WriteLine("Detalle del error del servidor:");
                Console.WriteLine(errorContent);
                throw new Exception("Error al intentar crear el alumno.");
            }
        }
        public void EliminarAlumno(int ideliminar)
        {
            HttpResponseMessage response = WebHelper.Delete($"tpIntensivo/alumno/{ideliminar}");

            if (!response.IsSuccessStatusCode)
            {
                string errorContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                Console.WriteLine("Detalle del error del servidor:");
                Console.WriteLine(errorContent);
                throw new Exception("Error al intentar eliminar el alumno.");
            }


        }
        public void ModificarAlumno(int idalumno, AlumnoRequest alumnoRequest)
        {
            AlumnoRequest alumno = new AlumnoRequest();
            alumno.id = alumnoRequest.id;   
            alumno.nombre = alumnoRequest.nombre;
            alumno.dni = alumnoRequest.dni;
            alumno.apellido = alumnoRequest.apellido;
            alumno.carrerasIds = alumnoRequest.carrerasIds;   

            // Convert the data to a JSON string
            var jsonData = JsonConvert.SerializeObject(alumno);

            HttpResponseMessage response = WebHelper.Put($"tpIntensivo/alumno/{idalumno}" , jsonData);

            if (!response.IsSuccessStatusCode)
            {
                string errorContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                Console.WriteLine("Detalle del error del servidor:");
                Console.WriteLine(errorContent);
                throw new Exception("Error al intentar eliminar el alumno.");
            }


        }



        public List<MateriaAlumnoResponse> ObtenerMateriasDeAlumno(int alumnoId)
        {
            HttpResponseMessage response = WebHelper.Get($"tpIntensivo/alumno/{alumnoId}/materias");

            if (response.IsSuccessStatusCode)
            {
                var contentStream = response.Content.ReadAsStringAsync().Result;
                List<MateriaAlumnoResponse> listaMaterias = JsonConvert.DeserializeObject<List<MateriaAlumnoResponse>>(contentStream);

                return listaMaterias;
            }
            else
            {
                throw new Exception($"Error al buscar las materias del alumno. Código de estado: {response.StatusCode}");
            }
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

