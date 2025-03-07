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

        private void Rendimiento(string FechaCierre = null, string nombre = null)
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

             
                    if (!string.IsNullOrWhiteSpace(FechaCierre))
                    {
                        query += " AND CONVERT(VARCHAR, p.FechaHoraCierre, 23) = @FechaCierre";
                        datos.setearParametro("@FechaPedido", FechaCierre);
                    }

                    if (!string.IsNullOrWhiteSpace(nombre))
                    {
                        query += " AND u.Nombre LIKE '%' + @Nombre + '%'";
                        datos.setearParametro("@Nombre", nombre);
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


            Rendimiento(fechaPedido, nombreMesero);
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFechaPedido.Text = string.Empty;
            txtNombre.Text = string.Empty;


            Rendimiento();
        }
    }
}
