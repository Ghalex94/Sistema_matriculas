
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
    public partial class wfrmAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { 
                cargarEstudiantes();
            }
        }

        public void cargarEstudiantes() {
            EstudianteBL bl = new EstudianteBL();
            gvEstudiantes.DataSource = bl.GetEstudiantes();;
            gvEstudiantes.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text;
            string nombre_estudiante = txtNombre.Text;
            string apellido_paterno = txtApePaterno.Text;
            string apellido_materno = txtApeMaterno.Text;
            DateTime fecha_nacimiento = dpFechaNac.SelectedDate;
            string estado_civil = radioEstadoCivil.SelectedValue;
            Estudiante estudiante = new Estudiante()
            {
                id = Convert.ToInt32(hdIdAlumno.Value),
                dni = dni,
                nombre_estudiante = nombre_estudiante,
                apellido_paterno = apellido_paterno,
                apellido_materno = apellido_materno,
                fecha_nacimiento = fecha_nacimiento,
                estado_civil = estado_civil
            };
            EstudianteBL bl = new EstudianteBL();
            bl.SaveEstudiante(estudiante);
            cargarEstudiantes();
            limpiar();
        }

        public void limpiar()
        {
            hdIdAlumno.Value = "0";
            txtDni.Text = null;
            txtNombre.Text = null;
            txtApePaterno.Text = null;
            txtApeMaterno.Text = null;
            dpFechaNac.SelectedDates.Clear();
            radioEstadoCivil.SelectedValue = null;
            txtDni.Focus();
        }
        
        protected void gvEstudiantes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            short idalumno = short.Parse(e.CommandArgument.ToString());
            EstudianteBL bl = new EstudianteBL();
            
            if (e.CommandName.ToString() == "editar")
            {
                Estudiante estudiante = bl.GetEstudianteByID(idalumno);

                hdIdAlumno.Value = estudiante.id.ToString();
                txtDni.Text = estudiante.dni;
                txtNombre.Text = estudiante.nombre_estudiante;
                txtApePaterno.Text = estudiante.apellido_paterno;
                txtApeMaterno.Text = estudiante.apellido_materno;
                dpFechaNac.SelectedDate = estudiante.fecha_nacimiento;
                radioEstadoCivil.SelectedValue = estudiante.estado_civil;
               
            }
            if (e.CommandName.ToString() == "eliminar")
            {
                bl.DeleteEstudiante(idalumno);
                cargarEstudiantes();
            }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}