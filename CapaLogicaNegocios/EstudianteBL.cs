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
    public class EstudianteBL
    {
        private Conexion cnx { get; set; }
        public EstudianteBL()
        {
            cnx = new Conexion();
        }

        public Estudiante GetEstudiantesByID(int idAlumno)
        {
            cnx.OpenConexion();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbEstudiante where id = " + idAlumno, this.cnx._CurrentConexion);

            SqlDataReader dr = cmd.ExecuteReader();
            List<Estudiante> ListaEstudiantes = new List<Estudiante>();
            while (dr.Read())
            {
                var estudiante = new Estudiante()
                {
                    id = dr.GetInt32(0),
                    dni = dr.GetString(1),
                    nombre_estudiante = dr.GetString(2),
                    apellido_paterno = dr.GetString(3),
                    apellido_materno = dr.GetString(4),
                    fecha_nacimiento = dr.GetDateTime(5),
                    estado_civil = dr.GetString(6),
                };
                ListaEstudiantes.Add(estudiante);
            }
            cnx.CloseConexion();
            return ListaEstudiantes.FirstOrDefault();
        }

        public List<Estudiante> GetEstudiantes()
        {
            cnx.OpenConexion();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbEstudiante", this.cnx._CurrentConexion);

            SqlDataReader dr = cmd.ExecuteReader();
            List<Estudiante> ListaEstudiantes = new List<Estudiante>();
            while (dr.Read())
            {
                var estudiante = new Estudiante()
                {
                    id = dr.GetInt32(0),
                    dni = dr.GetString(1),
                    nombre_estudiante = dr.GetString(2),
                    apellido_paterno = dr.GetString(3),
                    apellido_materno = dr.GetString(4),
                    fecha_nacimiento = dr.GetDateTime(5),
                    estado_civil = dr.GetString(6),
                };
                ListaEstudiantes.Add(estudiante);
            }
            cnx.CloseConexion();
            return ListaEstudiantes;
        }

        public void SaveEstudiante(Estudiante estudiante)
        {
            cnx.OpenConexion();
            if (estudiante.id != 0)
            {
                string command = $@"UPDATE tbEstudiante SET 
                                        nombre_estudiante='{estudiante.nombre_estudiante}',
                                        apellido_paterno='{estudiante.apellido_paterno}',
                                        apellido_materno='{estudiante.apellido_materno}', 
                                        fecha_nacimiento='{estudiante.fecha_nacimiento}',
                                        estado_civil='{estudiante.estado_civil}' 
                                    WHERE id=" + estudiante.id;
                SqlCommand cmd = new SqlCommand(command, cnx._CurrentConexion);
                cmd.ExecuteNonQuery();
                cnx.CloseConexion();
            }
            else
            {
                string command = $@"INSERT INTO tbEstudiante(dni, nombre_estudiante, apellido_paterno, apellido_materno, fecha_nacimiento, estado_civil)
                                     values('{estudiante.dni}',
                                     '{estudiante.nombre_estudiante}',
                                     '{estudiante.apellido_paterno}',
                                     '{estudiante.apellido_materno}',
                                     '{estudiante.fecha_nacimiento}',
                                     '{estudiante.estado_civil}')";
                SqlCommand cmd = new SqlCommand(command, cnx._CurrentConexion);
                cmd.ExecuteNonQuery();
                cnx.CloseConexion();
            }

        }

        public void DeleteEstudiante(int idAlumno)
        {
            cnx.OpenConexion();
            string command = $@"DELETE FROM tbEstudiante WHERE id=" + idAlumno;
            SqlCommand cmd = new SqlCommand(command, cnx._CurrentConexion);
            cmd.ExecuteNonQuery();
            cnx.CloseConexion();
        }
    }
}
