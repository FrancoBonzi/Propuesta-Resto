using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Final_Resto
{
    public partial class Menu : Page
    {
        ProductoNegocio negocio = new ProductoNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            gvProductos.DataSource = negocio.ListarProductos();
            gvProductos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto nuevo = new Producto
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Categoria = txtCategoria.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                StockMinimo = int.Parse(txtStockMinimo.Text),
                StockActual = int.Parse(txtStockActual.Text)
            };

            negocio.AgregarProducto(nuevo);
            lblMensaje.Text = "Producto agregado correctamente.";
            CargarProductos();
            LimpiarCampos();
        }



        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Producto modificado = new Producto
            {
                IdProducto = (int)ViewState["IdProducto"],
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Categoria = txtCategoria.Text,
                Precio = decimal.Parse(txtPrecio.Text),
                StockMinimo = int.Parse(txtStockMinimo.Text),
                StockActual = int.Parse(txtStockActual.Text)
            };

            negocio.ModificarProducto(modificado);
            lblMensaje.Text = "Producto modificado correctamente.";
            CargarProductos();
            LimpiarCampos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtCategoria.Text = "";
            txtPrecio.Text = "";
            txtStockMinimo.Text = "";
            txtStockActual.Text = "";

            btnAgregar.Visible = true;
            btnModificar.Visible = false;
            btnCancelar.Visible = false;
        }
    }
}
