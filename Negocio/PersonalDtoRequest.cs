using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PersonalDtoRequest
    {
        string nombre;
        string apellido;
        string cuit;
        string dni;
        string tipo;
        List<int> cursos;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Cuit { get => cuit; set => cuit = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public List<int> Cursos { get => cursos; set => cursos = value; }
    }
}
