using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
  public class MateriaDto
    {
        public  int id { get; set; }
        public string nombre { get; set; }
        public int horassemanales { get; set; }
        public List<MateriaDto> correlativas { get; set; }

        public override string ToString()
        {
            return nombre;
        }
    }

}
