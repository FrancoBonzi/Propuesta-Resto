using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Resto
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "password123")
            {
                Response.Redirect("About.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(),"alert","alert ('Usuario o contraseña incorrectas')"); 
            }

        }
    }
}