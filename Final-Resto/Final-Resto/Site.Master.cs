using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Resto
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Verifica si el usuario tiene sesión activa
                if (Session["Rol"] != null)
                {
                    btnLogout.Visible = true;
                    string rolUsuario = Session["Rol"].ToString();
                


                    if (rolUsuario != "Gerente")
                    {
                        
                    }
                }
                else
                {
                    btnLogout.Visible = false;
                }

            }
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Default.aspx"); 
        }


    }
}

