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




        public void AsignarMozo(Mesa mesa)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("AsignarMozo");

                datos.setearParametro("@IdMesa", mesa.IdMesa);
                datos.setearParametro("@IdMozo", mesa.IdMozo);
                datos.setearParametro("@Disponible", mesa.Disponible);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Mesa> ListaPorMozo()
        {
            List<Mesa> lista = new List<Mesa>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdMesa,IdMozo,Numero,Capacidad,Disponible FROM Mesas WHERE Disponible=0");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesa aux = new Mesa();

                    aux.IdMesa = (int)datos.Lector["IdMesa"];
                    aux.NumeroMesa = (int)datos.Lector["NumeroMesa"];
                    aux.IdMozo = (int)datos.Lector["IdMozo"];
                    aux.Disponible = (int)datos.Lector["Disponible"];
                    aux.CapacidadMesa = (int)datos.Lector["CapacidadMesa"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al querer listar las mesas " + ex.Message);
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
                datos.setearProcedimiento("AltaMesas");
                datos.setearParametro("@NumeroMesa", nuevo.NumeroMesa);
                datos.setearParametro("@Capacidad", nuevo.CapacidadMesa);
                datos.setearParametro("@Disponible", nuevo.Disponible);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la mesa " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ModificarMesa(Mesa nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("ModificarMesas");

                datos.setearParametro("@IdMesa", nuevo.IdMesa);
                datos.setearParametro("@NumeroMesa", nuevo.NumeroMesa);
                datos.setearParametro("@IdMozo", nuevo.IdMozo);
                datos.setearParametro("@Disponible", nuevo.Disponible);
                datos.setearParametro("@Capacidad", nuevo.CapacidadMesa);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
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
                datos.setearProcedimiento("EliminarMesas");
                datos.setearParametro("@IdMesa", id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
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
                datos.setearConsulta("SELECT IdMesa, IdMozo, Numero, Capacidad, Disponible FROM Mesas WHERE IdMozo = @IdMozo");
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
                        Disponible = Convert.ToInt32(datos.Lector["Disponible"])
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



        public void CerrarMesa(int idMesa)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Mesas SET Disponible = 1 WHERE IdMesa = @IdMesa");
                datos.setearParametro("@IdMesa", idMesa);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la mesa: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AbrirMesa(int idMesa)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Mesas SET Disponible = 0 WHERE IdMesa = @IdMesa");
                datos.setearParametro("@IdMesa", idMesa);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la mesa: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}

    
