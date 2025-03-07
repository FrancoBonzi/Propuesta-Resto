using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Resto
{

    public partial class DetallePedidos : Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
                CargarDetallePedido();
            }
        }


        protected void btnMisMesas_Click(object sender, EventArgs e)
        {
            Response.Redirect("MesasAsignadas.aspx");
        }




        private void CargarProductos()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<Producto> productos = productoNegocio.ListarProductosConStock();

            ddlProductos.DataSource = productos;
            ddlProductos.DataTextField = "Nombre";
            ddlProductos.DataValueField = "IdProducto";
            ddlProductos.DataBind();
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                int idPedido = int.Parse(Session["idPedido"].ToString());
                int idProducto = int.Parse(ddlProductos.SelectedValue);
                int cantidad = int.Parse(txtCantidad.Text);

                ProductoNegocio productoNegocio = new ProductoNegocio();
                Producto producto = productoNegocio.ObtenerProducto(idProducto);

                DetallePedido detalle = new DetallePedido
                {

                    IdPedido = idPedido, 
                    IdProducto = idProducto,
                    Cantidad = cantidad,
                    PrecioUnitario = producto.Precio,
                 //   Subtotal = cantidad * producto.Precio
                };

                DetallePedidoNegocio pedidoNegocio = new DetallePedidoNegocio();
                pedidoNegocio.AgregarDetallePedido(detalle);

                lblMensaje.Text = "Producto agregado correctamente.";
                lblMensaje.CssClass = "text-success";

                CargarDetallePedido();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.CssClass = "text-danger";
            }
        }

        private void CargarDetallePedido()
        {


            if (Session["idPedido"] == null || !int.TryParse(Session["idPedido"].ToString(), out int idPedido))
            {
                lblMensaje.Text = "Error: No hay un pedido seleccionado.";
                lblMensaje.CssClass = "text-danger";
                return;
            }

            DetallePedidoNegocio pedidoNegocio = new DetallePedidoNegocio();
            List<DetallePedido> detalles = pedidoNegocio.ObtenerDetallePedido(idPedido);

            gvDetallePedido.DataSource = detalles;
            gvDetallePedido.DataBind();
        }


    }
}