using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Curso
    {
        public int id { get; set; }
        public string nombre_curso { get; set; }
        public short semestre { get; set; }
        public string carrera { get; set; }
    }
}
