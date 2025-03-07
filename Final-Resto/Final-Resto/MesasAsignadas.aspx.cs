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

        PedidoNegocio pedido = new PedidoNegocio();

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

        protected void btnAbrirPedido_Click(object sender, EventArgs e)
        {
            try
            {

                int idMesa = int.Parse(txtMesa.Text); 
                int idMozo = (int)Session["Id"]; 

   
                Pedido nuevoPedido = new Pedido
                {
                    mesa = new Mesa { IdMesa = idMesa },
                    usuario = new Usuario { Id = idMozo },
                    Estado = "Abierto"
                };

  
                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                
                if (!pedidoNegocio.AbrirPedido(nuevoPedido))
                {
                    lblMensaje.Text = "Esta mesa se encuentra abierta";}


                else
                {
                    DetallePedidoNegocio obtenerid = new DetallePedidoNegocio();
                    int idPedido = obtenerid.ObtenerPedidoAbierto(idMesa);

                    Session["idPedido"] = idPedido;
                    CargarMesas();

                    Response.Redirect("DetallePedidos.aspx"); }

            }
            catch (Exception)
            {
                lblMensaje.Text = "Error al abrir el pedido";
            }
        }



        protected void btnCerrarPedido_Click(object sender, EventArgs e)
        {
            try
            {

                int idMesa = int.Parse(txtMesa.Text);
                int idMozo = (int)Session["Id"];


                PedidoNegocio pedidoNegocio = new PedidoNegocio();

                DetallePedidoNegocio obtenerid = new DetallePedidoNegocio();
                int idPedido = obtenerid.ObtenerPedidoAbierto(idMesa);

                if ( !pedidoNegocio.CerrarPedido(idMesa, idMozo, idPedido))

                { lblMensaje.Text = "No se encontro la mesa para cerrar"; }
               else { lblMensaje.Text = "Mesa cerrada con Exito"; }
                CargarMesas();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cerrar el pedido" + ex.Message;
            }

        }


        protected void btnAgregarPedido_Click(object sender, EventArgs e)
        {


            int idMesa;

            if (string.IsNullOrWhiteSpace(txtMesa.Text) || !int.TryParse(txtMesa.Text, out idMesa ))
            {
                lblMensaje.Text = "Ingrese un número de mesa válido.";
                lblMensaje.CssClass = "text-danger";
                return;
            }


            int idMozo = (int)Session["Id"];

            if (idMesa == 0) { lblMensaje.Text = "Ingrese una mesa"; }
            else
            {

                DetallePedidoNegocio obtenerid = new DetallePedidoNegocio();
                int idPedido = obtenerid.ObtenerPedidoAbierto(idMesa);

                Session["idPedido"] = idPedido;

                if (idPedido == -1)

                { lblMensaje.Text = "Esta mesa no se encuentra abierta"; }

                else { Response.Redirect("DetallePedidos.aspx"); }

            }
        }

    }

}
