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
        public List<Pedido> listar()
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"SELECT  
                                    p.IdPedido,
                                    m.IdMesa,
                                    u.Id,
                                    p.FechaHora,
                                    p.FechaHoraCierre,
                                    p.Total
                                    FROM Pedidos p
                                    INNER JOIN Mesas m ON p.IdMesa=m.IdMesa
                                    INNER JOIN Usuarios u ON p.IdMozo=u.Id
                                    ");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido
                    {
                        IdPedido = (int)datos.Lector["IdPedido"],
                        FechaHora = (DateTime)datos.Lector["FechaHora"],
                        FechaHoraCierre = (DateTime)datos.Lector["FechaHoraCierre"],
                        Total = (Decimal)datos.Lector["Total"],

                        mesa = new Mesa
                        {
                            IdMesa = datos.Lector["IdMesa"] != DBNull.Value ? (int)datos.Lector["IdMesa"] : 0
                        }
                    };

                    aux.usuario = new Usuario
                    {
                        Id = datos.Lector["Id"] != DBNull.Value ? (int)datos.Lector["Id"] : 0
                    };

                    lista.Add(aux);
                   
                }
                return lista;
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

        public void AgregarPedido(Pedido nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"INSERT INTO Pedidos (IdMesa,IdMozo,FechaHora,FechaHoraCierre,Total) VALUES (@IdMesa,@Id,@FechaHora,@FechaHoraCierra,@Total");

                datos.setearParametro("@IdMesa", nuevo.mesa?.IdMesa ?? (object)DBNull.Value);
                datos.setearParametro("@id", nuevo.usuario?.Id ?? (object)DBNull.Value);
                datos.setearParametro("@FechaHora", nuevo.FechaHora);
                datos.setearParametro("@FechaHoraCierre", nuevo.FechaHoraCierre);
                datos.setearParametro("@Total", nuevo.Total);

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


        public void ModificarPedido(Pedido modificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Pedidos SET IdMesa=@IdMesa,IdMozo=@Id,FechaHora=@FechaHora,@FechaHoraCierre,Total=@Total WHERE IdPedido=@IdPedido");

                datos.setearParametro("@IdMesa", modificar.mesa?.IdMesa ?? (object)DBNull.Value);
                datos.setearParametro("@Id", modificar.usuario?.Id ?? (object)DBNull.Value);
                datos.setearParametro("@FechaHora", modificar.FechaHora);
                datos.setearParametro("@FechaHoraCierre", modificar.FechaHoraCierre);
                datos.setearParametro("@Total", modificar.Total);

                datos.ejecutarAccion();

            }
            catch(Exception ex)
            {
                throw ex;
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
    }
}
