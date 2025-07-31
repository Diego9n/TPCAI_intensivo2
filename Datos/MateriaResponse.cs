using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MateriaResponse
    {
        int id;
        string nombre;
        int horasSemanales;
        List<MateriaResponse> correlativas;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int HorasSemanales { get => horasSemanales; set => horasSemanales = value; }
        public List<MateriaResponse> Correlativas { get => correlativas; set => correlativas = value; }
    }
}
