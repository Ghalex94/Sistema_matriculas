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
            // CARGAR EN LOS DATA DOWN LIST
            if (IsPostBack == false)
            {
                //CARGAR ALUMNOS
                SqlConnection cnx = new SqlConnection("data source = RYZEN5; initial catalog = bdmatricula; user id = sa; password = Aa123456");
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbEstudiante", cnx);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
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



            // CARGAR EN LA TABLA



        }

        protected void btnMatricular_Click(object sender, EventArgs e)
        {
            string id_alumno = ddlAlumno.SelectedValue;
            string id_curso = ddlCurso.SelectedValue;

            DateTime fechaHoy = DateTime.Now;

            SqlConnection cnx = new SqlConnection("data source = RYZEN5; initial catalog = bdmatricula; user id = sa; password = Aa123456");
            cnx.Open();

            string command = $@"INSERT INTO tbMatricula(id_estudiante, id_Curso, fecha_matricula)
                                 values('{id_alumno}','{id_curso}','{fechaHoy}')";
            SqlCommand cmd = new SqlCommand(command, cnx);
            cmd.ExecuteNonQuery();
        }
    }
}