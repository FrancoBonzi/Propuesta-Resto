using System;
using System.Globalization;
using System.Web.UI;
using Negocio;
using Dominio;

namespace Final_Resto
{
    public partial class Menu : Page
    {
        ProductoNegocio productoNegocio = new ProductoNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                formProducto.Visible = false;
                CargarProductos();
            }
        }

        protected void btnMostrarForm_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            formProducto.Visible = true;
            formModificacion.Visible = false;

        }

     

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto nuevo = new Producto
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Categoria = txtCategoria.Text.Trim(),
                Precio = decimal.Parse(txtPrecio.Text.Trim(), CultureInfo.InvariantCulture),
                StockActual = int.Parse(txtStockActual.Text),
                StockMinimo = int.Parse(txtStockMinimo.Text)
            };

            productoNegocio.AgregarProducto(nuevo);
            lblMensaje.Text = "Producto agregado correctamente.";
            LimpiarFormulario();
            CargarProductos();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int idProducto;
            if (int.TryParse(txtIdProducto.Text, out idProducto))
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                Producto prod = productoNegocio.ObtenerProducto(idProducto);


                TextBox1.Text = prod.Nombre;
                TextBox2.Text = prod.Descripcion;
                TextBox3.Text = prod.Categoria;
                TextBox4.Text = prod.Precio.ToString();
                TextBox5.Text = prod.StockActual.ToString();
                TextBox6.Text = prod.StockMinimo.ToString();

                formModificacion.Visible = true;
                formProducto.Visible = false; }

            else
            {
                lblMensaje.Text = "El id no existe";
                formModificacion.Visible = false;
            }
            
        }

            protected void btnGuardarModificacion_Click(object sender, EventArgs e)
            {
                try
                {

                     Producto modificar = new Producto
                    {
                        IdProducto = int.Parse(txtIdProducto.Text),
                        Nombre = TextBox1.Text.Trim(),
                        Descripcion = TextBox2.Text.Trim(),
                        Categoria = TextBox3.Text.Trim(),
                        Precio = decimal.Parse(TextBox4.Text.Trim()),
                        StockActual = int.Parse(TextBox5.Text),
                        StockMinimo = int.Parse(TextBox6.Text)
                    };

                    ProductoNegocio productoNegocio = new ProductoNegocio();
                    productoNegocio.ModificarProducto(modificar);

                    lblMensaje.Text = "Producto modificado correctamente.";

                    formModificacion.Visible = false;
                    LimpiarFormulario();
                    CargarProductos();
               }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al modificar el producto: " + ex.Message;
                }
            }

      
              



            protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idProducto = int.Parse(txtIdProducto.Text);
            productoNegocio.EliminarProducto(idProducto);
            lblMensaje.Text = "Producto eliminado.";
            LimpiarFormulario();
            CargarProductos();
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }


        private void LimpiarFormulario()
        {
            txtIdProducto.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtCategoria.Text = "";
            txtPrecio.Text = "";
            txtStockActual.Text = "";
            txtStockMinimo.Text = "";

            formProducto.Visible = false;
        }



        private void CargarProductos()
        {
            gvProductos.DataSource = productoNegocio.ListarProductos();
            gvProductos.DataBind();
        }




    }
}
