using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Final_Resto
{
    public partial class MesasAsignadas : Page
    {
        MesaNegocio negocio = new MesaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMesas();
            }
        }

        private void CargarMesas()
        {
            if (Session["Usuario"] == null)
            {
                lblMensaje.Text = "Debe iniciar sesión para ver sus mesas asignadas.";
                return;
            }

            string usuario = Session["Usuario"].ToString();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario mozo = usuarioNegocio.ObtenerUsuario(usuario);

            if (mozo == null || mozo.Rol != "Mesero")
            {
                lblMensaje.Text = "No tienes mesas asignadas.";
                return;
            }

            List<Mesa> lista = negocio.ListaPorMozo(mozo.Id);
            gvMesa.DataSource = lista;
            gvMesa.DataBind();
        }

        protected void gvMesa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idMesa = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "AbrirMesa")
            {
                negocio.AbrirMesa(idMesa);
                lblMensaje.Text = "Mesa abierta correctamente.";




            }
            else if (e.CommandName == "CerrarMesa")
            {
                negocio.CerrarMesa(idMesa);
                lblMensaje.Text = "Mesa cerrada correctamente.";
            }
            else if (e.CommandName == "AgregarPedido")
            {
                Response.Redirect("AgregarPedido.aspx?IdMesa=" + idMesa);
            }

            CargarMesas(); // Refrescar la lista de mesas
        }
    }
}
