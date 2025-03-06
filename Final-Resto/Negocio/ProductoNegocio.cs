using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdProducto, Nombre, Descripcion, Categoria, Precio, StockActual, StockMinimo FROM Productos");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto
                    {
                        IdProducto = Convert.ToInt32(datos.Lector["IdProducto"]),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                        Categoria = datos.Lector["Categoria"].ToString(),
                        Precio = Convert.ToDecimal(datos.Lector["Precio"]),
                        StockActual = Convert.ToInt32(datos.Lector["StockActual"]),
                        StockMinimo = Convert.ToInt32(datos.Lector["StockMinimo"])
                    };

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los productos: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AgregarProducto(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"INSERT INTO Productos (Nombre, Descripcion, Categoria, Precio, StockActual, StockMinimo) 
                                       VALUES (@Nombre, @Descripcion, @Categoria, @Precio, @StockActual, @StockMinimo)");

                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Categoria", nuevo.Categoria);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@StockActual", nuevo.StockActual);
                datos.setearParametro("@StockMinimo", nuevo.StockMinimo);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ModificarProducto(Producto modificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Productos SET " +
                                     "Nombre = @Nombre, " +
                                     "Descripcion = @Descripcion, " +
                                     "Categoria = @Categoria, " +
                                     "Precio = @Precio, " +
                                     "StockMinimo = @StockMinimo, " +
                                     "StockActual = @StockActual " +
                                     "WHERE IdProducto = @IdProducto");

                datos.setearParametro("@Nombre", modificar.Nombre);
                datos.setearParametro("@Descripcion", modificar.Descripcion);
                datos.setearParametro("@Categoria", modificar.Categoria);
                datos.setearParametro("@Precio", modificar.Precio);
                datos.setearParametro("@StockMinimo", modificar.StockMinimo);
                datos.setearParametro("@StockActual", modificar.StockActual);
                datos.setearParametro("@IdProducto", modificar.IdProducto);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el producto: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void ModificarStockProducto(Producto modificarstock)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Productos SET " +
                                     "StockMinimo = @StockMinimo, " +
                                     "StockActual = @StockActual " +
                                     "WHERE IdProducto = @IdProducto");

                datos.setearParametro("@IdProducto", modificarstock.IdProducto);
                datos.setearParametro("@StockActual", modificarstock.StockActual);
                datos.setearParametro("@StockMinimo", modificarstock.StockMinimo);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el stock del producto: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void EliminarProducto(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Productos WHERE IdProducto = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Producto ObtenerProducto(int idProducto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdProducto, Nombre, Descripcion, Categoria, Precio, StockActual, StockMinimo FROM Productos WHERE IdProducto = @IdProducto");
                datos.setearParametro("@IdProducto", idProducto);
                datos.EjecutarLectura();

                Producto aux = null;

                if (datos.Lector.Read())
                {
                    aux = new Producto
                    {
                        IdProducto = Convert.ToInt32(datos.Lector["IdProducto"]),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                        Categoria = datos.Lector["Categoria"].ToString(),
                        Precio = Convert.ToDecimal(datos.Lector["Precio"]),
                        StockActual = Convert.ToInt32(datos.Lector["StockActual"]),
                        StockMinimo = Convert.ToInt32(datos.Lector["StockMinimo"])
                    };
                }

                return aux;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el producto: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
