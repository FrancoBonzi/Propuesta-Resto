using System;
using System.Web.UI;
using Negocio;
using Dominio;

namespace Final_Resto
{
    public partial class RegistroUsuarios : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();
            string rol = ddlRol.SelectedValue;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena) || string.IsNullOrEmpty(rol))
            {
                lblMensaje.Text = "Todos los campos son obligatorios.";
                return;
            }

            try
            {
                Usuario nuevoUsuario = new Usuario
                {
                    Nombre = nombre,
                    UsuarioNombre = usuario,
                    Contrasena = contrasena,
                    Rol = rol
                };

                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.AgregarUsuario(nuevoUsuario);

                lblMensaje.CssClass = "text-success";
                lblMensaje.Text = "Usuario registrado correctamente.";
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            ddlRol.SelectedIndex = 0;
        }
    }
}
