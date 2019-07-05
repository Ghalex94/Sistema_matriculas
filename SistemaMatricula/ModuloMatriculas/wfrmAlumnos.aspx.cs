using SistemaMatricula.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatricula.ModuloMatriculas
{
    public partial class wfrmAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarAlumnos();
        }

        public void cargarAlumnos() {
            SqlConnection cnx = new SqlConnection("data source = RYZEN5; initial catalog = bdmatricula; user id = sa; password = Aa123456");
            cnx.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM tbEstudiante", cnx);

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
            cnx.Close();
            gvEstudiantes.DataSource = ListaEstudiantes;
            gvEstudiantes.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text;
            string nombre_estudiante = txtNombre.Text;
            string apellido_paterno = txtApePaterno.Text;
            string apellido_materno = txtApeMaterno.Text;
            string fecha_nacimiento = dpFechaNac.SelectedDate.ToString();
            string estado_civil = radioEstadoCivil.SelectedValue;

            SqlConnection cnx = new SqlConnection("data source = RYZEN5; initial catalog = bdmatricula; user id = sa; password = Aa123456");
            cnx.Open();

            string command = $@"INSERT INTO tbEstudiante(dni, nombre_estudiante, apellido_paterno, apellido_materno, fecha_nacimiento, estado_civil)
                                 values('{dni}','{nombre_estudiante}','{apellido_paterno}','{apellido_materno}','{fecha_nacimiento}','{estado_civil}')";
            SqlCommand cmd = new SqlCommand(command, cnx);
            cmd.ExecuteNonQuery();
            cargarAlumnos();
        }

        protected void gvEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvEstudiantes_SeectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}