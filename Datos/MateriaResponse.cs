using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
  public class MateriaResponse
  {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int HorasSemanales { get; set; }
    public List<MateriaResponse> Correlativas { get; set; }
  }

}
