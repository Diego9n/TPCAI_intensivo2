using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AlumnoDto
    {
      public int Id { get; set; }
      public string Nombre { get; set; }
      public string Apellido { get; set; }
      public string Dni { get; set; }
      public List<int> CarrerasIds { get; set; }
    }
}
