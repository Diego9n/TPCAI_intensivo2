using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProfesorDto
    {
        long _id;
        String _nombre;
        string _apellido;
        string _cuit;
        string _dni;
        int _antiguedad;
        string _tipo;

        public long Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Cuit { get => _cuit; set => _cuit = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public int Antiguedad { get => _antiguedad; set => _antiguedad = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
    }
}
