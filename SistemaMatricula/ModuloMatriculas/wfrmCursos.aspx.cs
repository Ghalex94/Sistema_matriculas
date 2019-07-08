using CapaDominio;
using CapaLogicaNegocios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatricula.ModuloMatriculas
{
    public partial class wfrmCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarCursos();
            }
        }

        public void cargarCursos()
        {
            CursoBL bl = new CursoBL();
            gvCursos.DataSource = bl.GetCursos();
            gvCursos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre_curso = txtNombreCurso.Text;
            string semestre = txtSemestre.Text;
            string carrera = txtCarrera.Text;
            Curso curso = new Curso()
            {
                id = Convert.ToInt32(hdIdCurso.Value),
                nombre_curso = nombre_curso,
                semestre = Convert.ToInt16(semestre),
                carrera = carrera
            };
            CursoBL bl = new CursoBL();
            bl.SaveCurso(curso);
            cargarCursos();
            limpiar();
        }

        protected void gvCursos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            short idCurso = short.Parse(e.CommandArgument.ToString());
            CursoBL bl = new CursoBL();

            if (e.CommandName.ToString() == "editar")
            {
                Curso curso = bl.GetCursoByID(idCurso);

                hdIdCurso.Value = curso.id.ToString();
                txtNombreCurso.Text = curso.nombre_curso;
                txtSemestre.Text = curso.semestre.ToString();
                txtCarrera.Text = curso.carrera;

            }
            if (e.CommandName.ToString() == "eliminar")
            {
                bl.DeleteCurso(idCurso);
                cargarCursos();
            }
        }
        public void limpiar()
        {
            hdIdCurso.Value = "0";
            txtNombreCurso.Text = string.Empty;
            txtSemestre.Text = string.Empty;
            txtCarrera.Text = string.Empty;
            txtNombreCurso.Focus();
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}