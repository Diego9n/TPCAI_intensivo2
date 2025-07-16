using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Persona
    {
        string nombre;
        string apellido;
        string DNI;
        string Domicilio;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string DNI1 { get => DNI; set => DNI = value; }
        public string Domicilio1 { get => Domicilio; set => Domicilio = value; }
    }
}
