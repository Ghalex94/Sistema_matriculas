using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Matricula
    {
        public int id { get; set; }
        public int id_estudiante { get; set; }
        public string nombre_estudiante { get; set; }
        public int id_curso { get; set; }
        public string nombre_curso { get; set; }
        public DateTime fecha_matricula { get; set; }
    }
}
