﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaMatricula.Models
{
    public class Curso
    {
        public int id { get; set; }
        public string nombre_curso { get; set; }
        public int semestre { get; set; }
        public string carrera { get; set; }

    }
}