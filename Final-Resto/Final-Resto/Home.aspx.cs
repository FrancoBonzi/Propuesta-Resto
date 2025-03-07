using System;
using System.Web.UI;

namespace Final_Resto
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {



                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Default.aspx");
                }


                else if(Session["Rol"] != null && Session["Rol"].ToString() != "Gerente")
                {
                    Response.Redirect("MesasAsignadas.aspx");

                }

            }
        }

        protected void btnRegistroUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroUsuarios.aspx");
        }

        protected void btnReportes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }

        protected void btnAsingarMesas_Click(object sender, EventArgs e)
        {
            Response.Redirect("MesasAsignadas.aspx");
        }

        protected void btnGestionarMesas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mesas.aspx");
        }
        protected void btnGestionarMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

    }
}
