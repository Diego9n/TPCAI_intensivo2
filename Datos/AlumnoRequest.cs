﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AlumnoRequest
    {
        public int id { get; set; }    
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; } 
        public List<int> carrerasIds { get; set; }   
    }
}
