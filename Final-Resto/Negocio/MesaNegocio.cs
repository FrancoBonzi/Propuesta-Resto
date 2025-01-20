using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MesaNegocio
    {
        public List<Mesa> listar()
        {
            List<Mesa> lista = new List<Mesa>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdMesa,IdMozo,Numero,Capacidad,Disponible FROM Mesas");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesa aux = new Mesa();

                    aux.IdMesa = (int)datos.Lector["IdMesa"];
                    aux.IdMozo = (int)datos.Lector["IdMozo"];
                    aux.NumeroMesa = (int)datos.Lector["NumeroMesa"];
                    aux.CapacidadMesa = (int)datos.Lector["CapacidadMesa"];
                    aux.Disponible = (int)datos.Lector["Disponible"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al listar las mesas: "+ex.Message);
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
            catch(Exception ex)
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

                datos.EjecutarLectura();
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
