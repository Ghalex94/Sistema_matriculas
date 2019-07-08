using CapaLogicaNegocios;
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
            if (!IsPostBack)
            {
                cargarCombos();
                cargarMatriculas();
            }
        }

        public void cargarCombos()
        {
            // CARGAR EN LOS DATA DOWN LIST
            if (IsPostBack == false)
            {
                //CARGAR ALUMNOS
                EstudianteBL estudianteBL = new EstudianteBL();
           
                ddlAlumno.DataSource = estudianteBL.GetEstudiantes();
                ddlAlumno.DataTextField = "nombre_estudiante";  // FieldName of Table in DataBase
                ddlAlumno.DataValueField = "id";
                ddlAlumno.DataBind();

                //CARGAR CURSOS

                CursoBL cursoBL = new CursoBL();
                ddlCurso.DataSource = cursoBL.GetCursos();
                ddlCurso.DataTextField = "nombre_curso";  // FieldName of Table in DataBase
                ddlCurso.DataValueField = "id";
                ddlCurso.DataBind();
            }
        }

        public void cargarMatriculas()
        {
            // CARGAR EN LA TABLA
            MatriculaBL bl = new MatriculaBL();
            gvMatriculas.DataSource = bl.getMatriculas();
            gvMatriculas.DataBind();
        }
        protected void btnMatricular_Click(object sender, EventArgs e)
        {
            string id_alumno = ddlAlumno.SelectedValue;
            string id_curso = ddlCurso.SelectedValue;
            DateTime fechaHoy = DateTime.Now;
            MatriculaBL bl = new MatriculaBL();
            bl.Matricular(id_alumno, id_curso, fechaHoy);
            cargarMatriculas();
        }

        protected void gvMatriculas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            short id = short.Parse(e.CommandArgument.ToString());
            if (e.CommandName.ToString() == "eliminar")
            {
                MatriculaBL bl = new MatriculaBL();
                bl.Deletematricula(id);
                cargarMatriculas();
            }
        }
    }
}