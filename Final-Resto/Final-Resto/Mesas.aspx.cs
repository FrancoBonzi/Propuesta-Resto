using System;
using System.Web.UI;
using Negocio;
using Dominio;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Final_Resto
{
    public partial class Mesas : Page
    {
        MesaNegocio negocio = new MesaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMozos();
                CargarMesas();
            }
        }

        private void CargarMesas()
        {
            gvMesa.DataSource = negocio.listarMesa();
            gvMesa.DataBind();
        }



        protected void btnEliminarMesa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdMesa.Text))
            {
                negocio.EliminarMesa(int.Parse(txtIdMesa.Text));
                txtIdMesa.Text = "";
                CargarMesas();
            }
        }

        private void CargarMozos()
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Usuario> mozos = usuarioNegocio.listarUsuariosPorRol("Mesero");

            ddlMozos.DataSource = mozos;
            ddlMozos.DataTextField = "Nombre"; 
            ddlMozos.DataValueField = "Id"; 
            ddlMozos.DataBind();

        }

        protected void btnAsignarMozo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdMesa.Text) && ddlMozos.SelectedValue != "0")
            {
                Mesa mesa = new Mesa
                {
                    IdMesa = int.Parse(txtIdMesa.Text),
                    Disponible = 0
                };

                int idMozo = int.Parse(ddlMozos.SelectedValue);

                MesaNegocio negocio = new MesaNegocio();
                negocio.AsignarMozo(mesa, idMozo);

                lblMensaje.Text = "Mozo asignado correctamente.";
                CargarMesas();
            }
            else
            {
                lblMensaje.Text = "Seleccione un mozo y una mesa válida";
            }
        }

    }
}
