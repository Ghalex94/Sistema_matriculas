using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Estudiante
    {
        public int id { get; set; }
        public string dni { get; set; }
        public string nombre_estudiante { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string estado_civil { get; set; }
    }
}
