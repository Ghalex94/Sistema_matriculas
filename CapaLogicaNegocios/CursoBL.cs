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
    public class CursoBL
    {
        private Conexion cnx { get; set; }
        public CursoBL()
        {
            cnx = new Conexion();
        }

        public Curso GetCursoByID(int idCurso)
        {
            cnx.OpenConexion();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbCurso where id = " + idCurso, this.cnx._CurrentConexion);

            SqlDataReader dr = cmd.ExecuteReader();
            List<Curso> ListaCursos = new List<Curso>();
            while (dr.Read())
            {
                var curso = new Curso()
                {
                    id = dr.GetInt32(0),
                    nombre_curso = dr.GetString(1),
                    semestre = dr.GetInt16(2),
                    carrera = dr.GetString(3)
                };
                ListaCursos.Add(curso);
            }
            cnx.CloseConexion();
            return ListaCursos.FirstOrDefault();
        }

        public List<Curso> GetCursos()
        {
            cnx.OpenConexion();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbCurso", this.cnx._CurrentConexion);

            SqlDataReader dr = cmd.ExecuteReader();
            List<Curso> ListaCursos = new List<Curso>();
            while (dr.Read())
            {
                var curso = new Curso()
                {
                    id = dr.GetInt32(0),
                    nombre_curso = dr.GetString(1),
                    semestre = dr.GetInt16(2),
                    carrera = dr.GetString(3)
                };
                ListaCursos.Add(curso);
            }
            cnx.CloseConexion();
            return ListaCursos;
        }

        public void SaveCurso(Curso curso)
        {
            cnx.OpenConexion();
            if (curso.id != 0)
            {
                string command = $@"UPDATE tbCurso SET 
                                        nombre_curso='{curso.nombre_curso}',
                                        semestre='{curso.semestre}',
                                        carrera='{curso.carrera}'
                                    WHERE id=" + curso.id;
                SqlCommand cmd = new SqlCommand(command, cnx._CurrentConexion);
                cmd.ExecuteNonQuery();
                cnx.CloseConexion();
            }
            else
            {
                string command = $@"INSERT INTO tbCurso(nombre_curso, semestre, carrera)
                                      values('{curso.nombre_curso}',
                                       '{curso.semestre}',
                                       '{curso.carrera}')";
                SqlCommand cmd = new SqlCommand(command, cnx._CurrentConexion);
                cmd.ExecuteNonQuery();
                cnx.CloseConexion();
            }

        }

        public void DeleteCurso(int idCurso)
        {
            cnx.OpenConexion();
            string command = $@"DELETE FROM tbCurso WHERE id=" + idCurso;
            SqlCommand cmd = new SqlCommand(command, cnx._CurrentConexion);
            cmd.ExecuteNonQuery();
            cnx.CloseConexion();
        }
    }
}
