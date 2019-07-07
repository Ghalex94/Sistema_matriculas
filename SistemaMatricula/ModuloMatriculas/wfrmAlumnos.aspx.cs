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
            if (!Page.IsPostBack) { 
            cargarAlumnos();
            }
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

            if (hdIdAlumno.Value != "")
            {
                string command = $@"UPDATE tbEstudiante SET nombre_estudiante='"+nombre_estudiante+"', apellido_paterno='"+apellido_paterno+"', apellido_materno='"+apellido_materno+ "', fecha_nacimiento='"+fecha_nacimiento+"', estado_civil='"+estado_civil+"' WHERE id=" + hdIdAlumno.Value;
                SqlCommand cmd = new SqlCommand(command, cnx);
                cmd.ExecuteNonQuery();
                cnx.Close();
                cargarAlumnos();
                limpiar();
            }
            else
            {
                 string command = $@"INSERT INTO tbEstudiante(dni, nombre_estudiante, apellido_paterno, apellido_materno, fecha_nacimiento, estado_civil)
                                     values('{dni}','{nombre_estudiante}','{apellido_paterno}','{apellido_materno}','{fecha_nacimiento}','{estado_civil}')";
                SqlCommand cmd = new SqlCommand(command, cnx);
                cmd.ExecuteNonQuery();
                cnx.Close();
                cargarAlumnos();
                limpiar();
            }
        }

        public void limpiar()
        {
            hdIdAlumno.Value = null;
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
            if (e.CommandName.ToString() == "editar")
            {
                SqlConnection cnx = new SqlConnection("data source = RYZEN5; initial catalog = bdmatricula; user id = sa; password = Aa123456");
                cnx.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbEstudiante where id = " + idalumno, cnx);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    hdIdAlumno.Value = dr.GetInt32(0).ToString();
                    txtDni.Text = dr.GetString(1);
                    txtNombre.Text = dr.GetString(2);
                    txtApePaterno.Text = dr.GetString(3);
                    txtApeMaterno.Text = dr.GetString(4);
                    dpFechaNac.SelectedDate = dr.GetDateTime(5);
                    radioEstadoCivil.SelectedValue = dr.GetString(6);
                }
                cnx.Close();
            }
            if (e.CommandName.ToString() == "eliminar")
            {
                SqlConnection cnx = new SqlConnection("data source = RYZEN5; initial catalog = bdmatricula; user id = sa; password = Aa123456");
                cnx.Open();
                string command = $@"DELETE FROM tbEstudiante WHERE id="+ idalumno;
                SqlCommand cmd = new SqlCommand(command, cnx);
                cmd.ExecuteNonQuery();
                cnx.Close();
                cargarAlumnos();
            }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}