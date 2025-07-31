using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class PersonalRequest
    {
        string Nombre;
        string Apellido;
        string Cuit;
        string Dni;
        string Tipo;
        List<int> Cursos;

        public string nombre { get => Nombre; set => Nombre = value; }
        public string apellido { get => Apellido; set => Apellido = value; }
        public string cuit { get => Cuit; set => Cuit = value; }
        public string dni { get => Dni; set => Dni = value; }
        public string tipo { get => Tipo; set => Tipo = value; }
        public List<int> cursos { get => Cursos; set => Cursos = value; }
    }
}
