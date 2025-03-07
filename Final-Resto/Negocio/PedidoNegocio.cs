using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Final_Resto;

namespace Negocio
{
    public class PedidoNegocio
    {


        public bool AbrirPedido(Pedido nuevo)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta(@"SELECT COUNT(*) FROM Pedidos  WHERE IdMesa = @IdMesa AND Estado = 'Abierto'");

                datos.setearParametro("@IdMesa", nuevo.mesa?.IdMesa ?? (object)DBNull.Value);
                datos.EjecutarLectura();

                if (datos.Lector.Read() && Convert.ToInt32(datos.Lector[0]) > 0)
                {
                    datos.cerrarConexion();
                    return false;
                    

                }

                datos.limpiarParametros();
                datos.cerrarConexion();


                datos.setearConsulta(@"INSERT INTO Pedidos (IdMesa,IdMozo,Estado) OUTPUT INSERTED.IdPedido VALUES (@IdMesa,@IdMozo,@Estado)");

                datos.setearParametro("@IdMesa", nuevo.mesa?.IdMesa ?? (object)DBNull.Value);
                datos.setearParametro("@IdMozo", nuevo.usuario?.Id ?? (object)DBNull.Value);
                datos.setearParametro("@Estado", "Abierto");

                datos.ejecutarAccion();
                return true;
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

        public void EliminarPedido (int id)
        {
            AccesoDatos datos = new AccesoDatos ();

            try
            {
                datos.setearConsulta("DELETE FROM Pedidos WHERE IdPedido=@id");
                datos.setearParametro("@id", id);
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


        public bool CerrarPedido(int IdMesa, int idMozo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
 
                datos.setearConsulta(@"
            SELECT COUNT(*) FROM Pedidos p INNER JOIN Mesas m ON p.IdMesa = m.IdMesa WHERE p.IdMesa = @IdMesa AND m.IdMozo = @IdMozo");

                datos.setearParametro("@IdMesa", IdMesa);
                datos.setearParametro("@IdMozo", idMozo);

                datos.EjecutarLectura();


                if (datos.Lector.Read() && Convert.ToInt32(datos.Lector[0]) == 0)
                {
                    datos.cerrarConexion();
                    return false;
                }
                else
                {
                    datos.limpiarParametros();
                    datos.cerrarConexion();

                    datos.setearConsulta(@"UPDATE Pedidos SET Estado = @Estado, FechaHoraCierre = GETDATE() , Total = @Total WHERE IdMesa = @IdMesa");

                    datos.setearParametro("@IdMesa", IdMesa);
                    datos.setearParametro("@Estado", "Cerrado");
                    datos.setearParametro("@Total", 100);

                    datos.ejecutarAccion();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }







    }
}
