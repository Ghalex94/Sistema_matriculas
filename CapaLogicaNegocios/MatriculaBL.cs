using CapaAccesoDatos;
using CapaDominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocios
{
    public class MatriculaBL
    {
        private Conexion cnx { get; set; }
        public MatriculaBL()
        {
            cnx = new Conexion();
        }
        public List<Matricula> getMatriculas()
        {
            cnx.OpenConexion();
            SqlCommand cmd = new SqlCommand($@"SELECT m.id,
                                           m.id_estudiante,
                                           e.nombre_estudiante,
                                           m.id_Curso,
                                           c.nombre_curso, 
                                           m.fecha_matricula 
                                            
                                           FROM tbMatricula as m 
                                           INNER JOIN tbEstudiante as e on e.id = m.id_estudiante 
                                           INNER JOIN tbCurso as c on c.id = m.id_Curso; ",
                                           this.cnx._CurrentConexion);

            SqlDataReader dr = cmd.ExecuteReader();
            List<Matricula> ListMatriculas = new List<Matricula>();
            while (dr.Read())
            {
                var matricula = new Matricula()
                {
                    id = dr.GetInt32(0),
                    id_estudiante = dr.GetInt32(1),
                    nombre_estudiante = dr.GetString(2),
                    id_curso = dr.GetInt32(3),
                    nombre_curso = dr.GetString(4),
                    fecha_matricula = dr.GetDateTime(5)
                };
                ListMatriculas.Add(matricula);
            }
            cnx.CloseConexion();
            return ListMatriculas;
        }

        public void Matricular(string id_alumno, string id_curso, DateTime fechaHoy) {
            cnx.OpenConexion();
            string command = $@"INSERT INTO tbMatricula(id_estudiante, id_Curso, fecha_matricula)
                                 values('{id_alumno}',
                                 '{id_curso}',
                                '{fechaHoy}')";
            SqlCommand cmd = new SqlCommand(command, cnx._CurrentConexion);
            cmd.ExecuteNonQuery();
            cnx.CloseConexion();
        }

        public void Deletematricula(short idMatricula)
        {
            cnx.OpenConexion();
            string command = $@"DELETE FROM tbMatricula WHERE id=" + idMatricula;
            SqlCommand cmd = new SqlCommand(command, cnx._CurrentConexion);
            cmd.ExecuteNonQuery();
            cnx.CloseConexion();
        }
    }
}
