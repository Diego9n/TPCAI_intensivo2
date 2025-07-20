using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AlumnoDto
    {
        string nombre;
        string apellido;
        string dni;
        List<int> carrerasIds;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Dni { get => dni; set => dni = value; }
        public List<int> CarrerasIds { get => carrerasIds; set => carrerasIds = value; }
    }
}
