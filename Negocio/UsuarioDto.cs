﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioDto
    {
        private long _id;
        private String _perfilUsuario;

        public long Id { get => _id; set => _id = value; }
        public string PerfilUsuario { get => _perfilUsuario; set => _perfilUsuario = value; }
    }
}
