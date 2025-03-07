using System;
using System.Web.UI;
using Negocio;
using Dominio;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Globalization;

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
                formMesa.Visible = false;
            }
        }

        private void CargarMesas()
        {
            gvMesa.DataSource = negocio.listarMesa();
            gvMesa.DataBind();
        }

        protected void btnAgregarMesa_Click(object sender, EventArgs e)
        {
            formMesa.Visible = true;

        }
        


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Mesa nuevo = new Mesa
            {

                CapacidadMesa = int.Parse(txtCapacidad.Text),
                NumeroMesa = int.Parse(txtNumeroMesa.Text)
            };

            negocio.AgregarMesa(nuevo);
            lblMensaje.Text = "Mesa agregado correctamente.";
            CargarMesas();

        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            formMesa.Visible = false;

        }
        
       


        protected void btnEliminarMesa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdMesa.Text))
            {
                negocio.EliminarMesa(int.Parse(txtIdMesa.Text));
                txtIdMesa.Text = "";
                CargarMesas();
            }
            else { lblMensaje.Text = "Debe seleccionar un ID Mesa."; }
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
