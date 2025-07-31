using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CursoResponse
    {
    public   int id { get; set; }
     public  string  profesorNombre { get; set; }
     public  List<string> dias { get; set; }
        public  List<HorariosResponse> horarios { get; set; }

      public List<int> idDocentes { get; set; }  
    }
}
