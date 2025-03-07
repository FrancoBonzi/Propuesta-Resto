using Negocio;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Resto
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPedidos();
            }
        }

        private void CargarPedidos(string fechaPedido = null, string nombre = null, string estadoPedido = null, string numeroMesa = null)
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable dt = new DataTable();

            try
            {

                string query = @"
                    SELECT p.IdPedido, p.FechaHora, p.FechaHoraCierre, p.Estado, 
                           u.Nombre AS Nombre, m.Numero AS NumeroMesa, p.Total 
                    FROM Pedidos p
                    LEFT JOIN Usuarios u ON p.IdMozo = u.Id
                    LEFT JOIN Mesas m ON p.IdMesa = m.IdMesa
                    WHERE 1=1";


                if (!string.IsNullOrWhiteSpace(fechaPedido))
                {
                    query += " AND CONVERT(VARCHAR, p.FechaHora, 23) = @FechaPedido";
                    datos.setearParametro("@FechaPedido", fechaPedido);
                }

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    query += " AND u.Nombre LIKE '%' + @Nombre + '%'";
                    datos.setearParametro("@Nombre", nombre);
                }


                if (!string.IsNullOrWhiteSpace(numeroMesa))
                {
                    query += " AND m.Numero = @NumeroMesa";
                    datos.setearParametro("@NumeroMesa", numeroMesa);
                }

                datos.setearConsulta(query);
                datos.EjecutarLectura();

                dt.Load(datos.Lector);

                gvPedidos.DataSource = dt;
                gvPedidos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar datos: " + ex.Message;
                lblError.Visible = true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string fechaPedido = txtFechaPedido.Text.Trim();
            string nombreCliente = txtNombre.Text.Trim();
            string numeroMesa = txtNumeroMesa.Text.Trim();

            CargarPedidos(fechaPedido, nombreCliente, numeroMesa);
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFechaPedido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtNumeroMesa.Text = string.Empty;

            CargarPedidos(); 
        }
    }
}
