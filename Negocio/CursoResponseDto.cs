using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CursoResponseDto
    {
        public int id { get; set; }
        public string profesorNombre { get; set; }
        public List<string> dias { get; set; }
        public List<HorariosResponseDtocs> horarios { get; set; }

        public List<int> idDocentes { get; set; }
        public override string ToString()
        {
            return $"ID: {id}  ";
        }
    }
}
