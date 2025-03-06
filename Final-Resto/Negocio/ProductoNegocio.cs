using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
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
                datos.setearConsulta("SELECT IdProducto,Nombre,Descripcion, Categoria, Precio,StockActual,StockMinimo FROM Productos");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Categoria = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.StockActual = (int)datos.Lector["StockActual"];
                    aux.StockMinimo = (int)datos.Lector["StockMinimo"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al querer listar los Productos..."+ex.Message);
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
                datos.setearProcedimiento("AltaProductos");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@StockActual", nuevo.StockActual);
                datos.setearParametro("@StockMinimo", nuevo.StockMinimo);

                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al agregar el nuevo Producto:"+ ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ModificarProducto(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("ModificarProductos");

                datos.setearParametro("@IdProducto", nuevo.IdProducto);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@StockActual", nuevo.StockActual);
                datos.setearParametro("@StockMinimo", nuevo.StockMinimo);

                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
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
                datos.setearProcedimiento("EliminarProductos");
                datos.setearParametro("Id", id);

                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
