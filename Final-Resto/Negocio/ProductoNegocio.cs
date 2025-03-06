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
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdArticulo,Nombre,Descripcion,Precio,StockActual,StockMinimo FROM Articulos");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.StockActual = (int)datos.Lector["Stock Actual"];
                    aux.StockMinimo = (int)datos.Lector["Stock Minimo"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al querer listar los articulos..."+ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AgregarArticulo(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("AltaArticulos");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@StockActual", nuevo.StockActual);
                datos.setearParametro("@StockMinimo", nuevo.StockMinimo);

                datos.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw new Exception("Error al agregar el nuevo articulo:"+ ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ModificarArticulo(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("ModificarArticulos");

                datos.setearParametro("@IdArticulo", nuevo.IdArticulo);
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

        public void EliminarArticulo(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("EliminarArticulos");
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
