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
    public partial class wfrmMatricular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarMatriculas();
        }

        public void cargarMatriculas()
        {
            SqlConnection cnx = new SqlConnection("data source = LENOVO_X230; initial catalog = bdmatricula; user id = sa; password = Aa123456");
            cnx.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM tbCurso", cnx);

            SqlDataReader dr = cmd.ExecuteReader();
            List<Curso> listaCursos = new List<Curso>();
            while (dr.Read())
            {
                var curso = new Curso()
                {
                    id = dr.GetInt32(0),
                    nombre_curso = dr.GetString(1),
                    semestre = dr.GetInt16(2),
                    carrera = dr.GetString(3)
                };
                listaCursos.Add(curso);
            }
            gvMatriculas.DataSource = listaCursos;
            gvMatriculas.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string semestre = txtSemestre.Text;
            string carrera = txtCarrera.Text;

            SqlConnection cnx = new SqlConnection("data source = LENOVO_X230; initial catalog = bdmatricula; user id = sa; password = Aa123456");
            cnx.Open();

            string command = $@"INSERT INTO tbCurso(semestre, carrera)
                                 values('{semestre}','{carrera}')";
            SqlCommand cmd = new SqlCommand(command, cnx);
            cmd.ExecuteNonQuery();
            cargarMatriculas();
        }
    }
}