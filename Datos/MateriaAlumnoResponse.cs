﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MateriaAlumnoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Condicion { get; set; }
        public int? Nota { get; set; }
    }
}
