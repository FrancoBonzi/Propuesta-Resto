using Dominio;
using Final_Resto;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DetallePedidoNegocio
    {
        public List<DetallePedido> ObtenerDetallePedido(int idPedido)
        {
            List<DetallePedido> lista = new List<DetallePedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"SELECT d.IdDetalle, d.IdPedido, d.IdProducto, p.Nombre as NombreProducto, d.Cantidad, d.PrecioUnitario, d.Subtotal 
                               FROM DetallePedidos d
                               INNER JOIN Productos p ON d.IdProducto = p.IdProducto
                               WHERE d.IdPedido = @IdPedido");
                datos.setearParametro("@IdPedido", idPedido);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    DetallePedido aux = new DetallePedido
                    {
                        IdDetalle = (int)datos.Lector["IdDetalle"],
                        IdPedido = (int)datos.Lector["IdPedido"],
                        IdProducto = (int)datos.Lector["IdProducto"],
                        Cantidad = (int)datos.Lector["Cantidad"],
                        PrecioUnitario = (Decimal)datos.Lector["PrecioUnitario"],
                        Subtotal = (Decimal)datos.Lector["Subtotal"],


                        producto = new Producto
                        {
                            Nombre = datos.Lector["NombreProducto"].ToString()

                        }
                    };

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los detalles del pedido: " + ex.Message);
            }
        }



        public void AgregarDetallePedido(DetallePedido detalle)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"INSERT INTO DetallePedidos (IdPedido, IdProducto, Cantidad, PrecioUnitario) 
                                       VALUES (@IdPedido, @IdProducto, @Cantidad, @PrecioUnitario)");

                datos.setearParametro("@IdPedido", detalle.IdPedido);
                datos.setearParametro("@IdProducto", detalle.IdProducto);
                datos.setearParametro("@Cantidad", detalle.Cantidad);
                datos.setearParametro("@PrecioUnitario", detalle.PrecioUnitario);

                datos.ejecutarAccion();



            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto al pedido: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }







        public int ObtenerPedidoAbierto(int idMesa)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"SELECT IdPedido FROM Pedidos WHERE IdMesa = @IdMesa AND Estado = 'Abierto'");
                datos.setearParametro("@IdMesa", idMesa);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    return Convert.ToInt32(datos.Lector["IdPedido"]); 
                }
                return -1; 
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener el pedido abierto");
            }
            finally
            {
                datos.cerrarConexion(); 
            }
        }

    }
}