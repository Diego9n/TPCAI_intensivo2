using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
  public class AlumnoResponse
  {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Dni { get; set; }
    public List<int> CarrerasIds { get; set; }
  }
}
