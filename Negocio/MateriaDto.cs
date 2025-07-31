using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MateriaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int HorasSemanales { get; set; }
        public List<MateriaDto> Correlativas { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}