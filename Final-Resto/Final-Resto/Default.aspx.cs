using System;
using System.Web.UI;
using Negocio;
using Dominio;

namespace Final_Resto
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = negocio.ObtenerUsuario(username);

            if (usuario != null && usuario.Contrasena == password) // En producción, usa encriptación
            {
                // Guardar en sesión
                Session["Usuario"] = usuario.UsuarioNombre;
                Session["Rol"] = usuario.Rol;

                if (usuario.Rol == "Gerente")
                    Response.Redirect("Home.aspx");
                else
                    Response.Redirect("MesasAsignadas.aspx");
            }
            else
            {
                lblMessage.Text = "Usuario o contraseña incorrectos.";
            }
        }
    }
}
