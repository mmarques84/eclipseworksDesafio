﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eclipseworksDesafio.Application.Dtos.Usuario
{
    public class UsuarioCreateDTO
    {
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public bool Ativo { get; set; }
    }
}
