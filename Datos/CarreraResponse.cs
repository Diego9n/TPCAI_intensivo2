using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CarreraResponse
    {
      
        
            long _id;
            String _nombre;

            public long Id { get => _id; set => _id = value; }
            public string Nombre { get => _nombre; set => _nombre = value; }
        
    }
}
