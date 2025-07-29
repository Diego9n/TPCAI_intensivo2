using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AlumnoDtoRequest
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public List<int> carreras { get; set; }


    }
}
