using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaMatricula
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "user" && txtPassword.Text == "1234")
            {
                Session["login"] = true;
                Response.Redirect("/Default.aspx");
            }
            else {
                Session["login"] = null;
            }
        }
    }
}