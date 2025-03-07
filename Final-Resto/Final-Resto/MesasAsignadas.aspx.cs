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


                pedidoNegocio.CerrarPedido(idMesa, idMozo);

                lblMensaje.Text = "Mesa cerrada con Exito";


            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cerrar el pedido" + ex.Message;
            }

        }


        protected void btnAgregarPedido_Click(object sender, EventArgs e)
        {

        }




    }
}
