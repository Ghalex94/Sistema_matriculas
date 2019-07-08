using SistemaMatricula.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatricula.ModuloMatriculas
{
    public partial class wfrmMatricular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarMatriculas();
        }

        public void cargarMatriculas()
        {
            cargarTabla();            

            // CARGAR EN LOS DATA DOWN LIST
            if (IsPostBack == false)
            {
                //CARGAR ALUMNOS
                SqlConnection cnx = new SqlConnection("data source = LENOVO_X230; initial catalog = bdmatricula; user id = sa; password = Aa123456");
                cnx.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM tbEstudiante", cnx);
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ddlAlumno.DataSource = ds;
                ddlAlumno.DataTextField = "nombre_estudiante";  // FieldName of Table in DataBase
                ddlAlumno.DataValueField = "id";
                ddlAlumno.DataBind();
                cnx.Close();

                //CARGAR CURSOS
                
                cnx.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM tbCurso", cnx);
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                sda2.Fill(ds2);
                ddlCurso.DataSource = ds2;
                ddlCurso.DataTextField = "nombre_curso";  // FieldName of Table in DataBase
                ddlCurso.DataValueField = "id";
                ddlCurso.DataBind();
                cnx.Close();
            }
        }

        public void cargarTabla()
        {
            // CARGAR EN LA TABLA
            SqlConnection cnx = new SqlConnection("data source = LENOVO_X230; initial catalog = bdmatricula; user id = sa; password = Aa123456");
            cnx.Open();
            SqlCommand cmd = new SqlCommand("select m.id, m.id_estudiante, e.nombre_estudiante, m.id_Curso, c.nombre_curso, m.fecha_matricula from tbMatricula as m inner join tbEstudiante as e on e.id = m.id_estudiante inner join tbCurso as c on c.id = m.id_Curso; ", cnx);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Matricula> listaMatricula = new List<Matricula>();
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
                listaMatricula.Add(matricula);
            }
            gvMatriculas.DataSource = listaMatricula;
            gvMatriculas.DataBind();
            cnx.Close();
        }
        protected void btnMatricular_Click(object sender, EventArgs e)
        {
            string id_alumno = ddlAlumno.SelectedValue;
            string id_curso = ddlCurso.SelectedValue;
            DateTime fechaHoy = DateTime.Now;
            SqlConnection cnx = new SqlConnection("data source = LENOVO_X230; initial catalog = bdmatricula; user id = sa; password = Aa123456");
            cnx.Open();
            string command = $@"INSERT INTO tbMatricula(id_estudiante, id_Curso, fecha_matricula)
                                 values('{id_alumno}','{id_curso}','{fechaHoy}')";
            SqlCommand cmd = new SqlCommand(command, cnx);
            cmd.ExecuteNonQuery();
            cargarTabla();
        }

        protected void gvMatriculas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            short id = short.Parse(e.CommandArgument.ToString());
            if (e.CommandName.ToString() == "eliminar")
            {
                SqlConnection cnx = new SqlConnection("data source = LENOVO_X230; initial catalog = bdmatricula; user id = sa; password = Aa123456");
                cnx.Open();
                string command = $@"DELETE FROM tbMatricula WHERE id=" + id;
                SqlCommand cmd = new SqlCommand(command, cnx);
                cmd.ExecuteNonQuery();
                cnx.Close();
                cargarMatriculas();
            }
        }
    }
}