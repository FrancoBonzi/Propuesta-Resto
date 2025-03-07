using Negocio;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Resto
{
    public partial class RendimientoMeseros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rendimiento();
            }
        }

        private void Rendimiento(string fechaPedido = null, string nombre = null, string numeroMesa = null)
        {
            AccesoDatos datos = new AccesoDatos();
            {
                DataTable dt = new DataTable();

                try
                {
                    string query = @"
                        SELECT 
                               cast(p.FechaHoraCierre as date) as FechaCierre,
                               u.Nombre as Nombre, 
                               SUM(p.Total) AS TotalRecaudado, 
                               COUNT(p.IdPedido) AS CantidadPedidos
                        FROM Pedidos p
                        INNER JOIN Usuarios u ON p.IdMozo = u.Id
                        WHERE cast(p.FechaHoraCierre as date) IS NOT NULL";

             
                    if (!string.IsNullOrWhiteSpace(fechaPedido))
                    {
                        query += " AND CONVERT(VARCHAR, p.FechaHoraCierre, 23) = @FechaPedido";
                        datos.setearParametro("@FechaPedido", fechaPedido);
                    }

                    if (!string.IsNullOrWhiteSpace(nombre))
                    {
                        query += " AND u.Nombre LIKE '%' + @Nombre + '%'";
                        datos.setearParametro("@Nombre", nombre);
                    }

                    if (!string.IsNullOrWhiteSpace(numeroMesa))
                    {
                        query += " AND p.IdMesa IN (SELECT IdMesa FROM Mesas WHERE Numero = @NumeroMesa)";
                        datos.setearParametro("@NumeroMesa", numeroMesa);
                    }

                    query += " GROUP BY cast(p.FechaHoraCierre as date), u.Nombre";

                    datos.setearConsulta(query);
                    datos.EjecutarLectura();
                    dt.Load(datos.Lector);

                    gvRendimiento.DataSource = dt;
                    gvRendimiento.DataBind();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Error al cargar datos: " + ex.Message;
                    lblError.Visible = true;
                }
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string fechaPedido = txtFechaPedido.Text.Trim();
            string nombreMesero = txtNombre.Text.Trim();
            string numeroMesa = txtNumeroMesa.Text.Trim();

            Rendimiento(fechaPedido, nombreMesero, numeroMesa);
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFechaPedido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtNumeroMesa.Text = string.Empty;

            Rendimiento();
        }
    }
}
