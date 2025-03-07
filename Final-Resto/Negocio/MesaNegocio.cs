using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Final_Resto;

namespace Negocio
{
    public class MesaNegocio
    {
        public List<Mesa> listarMesa()
        {
            List<Mesa> lista = new List<Mesa>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT 
                m.IdMesa,
                m.Numero, 
                m.Capacidad,
                m.Disponible,
                m.Estado,
                u.Id AS IdMozo,
                u.Nombre AS NombreMozo
            FROM Mesas m
            LEFT JOIN Usuarios u ON m.IdMozo = u.Id
            ");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesa aux = new Mesa
                    {
                        IdMesa = datos.Lector["IdMesa"] != DBNull.Value ? Convert.ToInt32(datos.Lector["IdMesa"]) : 0,
                        NumeroMesa = datos.Lector["Numero"] != DBNull.Value ? Convert.ToInt32(datos.Lector["Numero"]) : 0,
                        CapacidadMesa = datos.Lector["Capacidad"] != DBNull.Value ? Convert.ToInt32(datos.Lector["Capacidad"]) : 0,
                        Disponible = datos.Lector["Disponible"] != DBNull.Value ? Convert.ToInt32(datos.Lector["Disponible"]) : 0,
                        Estado = datos.Lector["Estado"] != DBNull.Value ? datos.Lector["Estado"].ToString() : "Revisar" ,
                        IdMozo = datos.Lector["IdMozo"] != DBNull.Value ? Convert.ToInt32(datos.Lector["IdMozo"]) : 0
                    };


                    aux.usuarioNombre = new Usuario
                    {
                        Id = aux.IdMozo,
                        Nombre = datos.Lector["NombreMozo"] != DBNull.Value ? datos.Lector["NombreMozo"].ToString() : "Sin asignar"
                    };

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las mesas: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AgregarMesa(Mesa nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"INSERT INTO Mesas ( Numero, Disponible, Capacidad, Estado) VALUES ( @Numero, @Disponible, @Capacidad, @Estado)");

                datos.setearParametro("@Numero", nuevo.NumeroMesa);
                datos.setearParametro("@Disponible", 1);
                datos.setearParametro("@Capacidad", nuevo.CapacidadMesa);
                datos.setearParametro("@Estado","Cerrado");


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



        public void EliminarMesa(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Mesas WHERE IdMesa = @IdMesa");
                datos.setearParametro("@IdMesa", id);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                
            }
            finally
            {
                datos.cerrarConexion();
            }
        }




        public void AsignarMozo(Mesa mesa, int idMozo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Mesas SET IdMozo = @IdMozo, Disponible = @Disponible WHERE IdMesa = @IdMesa");

                datos.setearParametro("@IdMozo", idMozo);
                datos.setearParametro("@IdMesa", mesa.IdMesa);
                datos.setearParametro("@Disponible", mesa.Disponible);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al asignar el mozo: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        public List<Mesa> ListaPorMozo(int idMozo)
        {
            List<Mesa> lista = new List<Mesa>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdMesa, IdMozo, Numero, Capacidad, Disponible, Estado FROM Mesas WHERE IdMozo = @IdMozo");
                datos.setearParametro("@IdMozo", idMozo);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesa aux = new Mesa
                    {
                        IdMesa = Convert.ToInt32(datos.Lector["IdMesa"]),
                        IdMozo = Convert.ToInt32(datos.Lector["IdMozo"]),
                        NumeroMesa = Convert.ToInt32(datos.Lector["Numero"]),
                        CapacidadMesa = Convert.ToInt32(datos.Lector["Capacidad"]),
                        Disponible = Convert.ToInt32(datos.Lector["Disponible"]),
                        Estado = (datos.Lector["Estado"].ToString())
                    };

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las mesas del mozo: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}

    
