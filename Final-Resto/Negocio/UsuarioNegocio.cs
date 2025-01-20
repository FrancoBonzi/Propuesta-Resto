using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> lista = new List<Usuario>();

            try
            {
                datos.setearConsulta("SELECT IdUsuario,Contrasenia,Nombre,Apellido,Email,Dni FROM Usuarios");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.Contrasenia = (string)datos.Lector["Contrasenia"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dni = (string)datos.Lector["DNI"];

                    lista.Add(aux);
                }
                return lista;
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

        public Usuario ObtenerUsuario(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdUsuario,Contrasenia,Nombre,Email,Dni FROM Usuarios WHERE IdUsuario=@Id");
                datos.setearParametro("@Id", Id);
                datos.EjecutarLectura();

                Usuario aux = new Usuario();

                while (datos.Lector.Read())
                {
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.Contrasenia = (string)datos.Lector["Contraseña"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dni = (string)datos.Lector["DNI"];
                }
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("AltaUsuarios");
                datos.setearParametro("@Contrasenia", nuevo.Contrasenia);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Dni", nuevo.Dni);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el usuario " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ModificarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("ModificarUsuarios");

                datos.setearParametro("@IdUsuario", nuevo.IdUsuario);
                datos.setearParametro("@Contrasenia", nuevo.Contrasenia);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@DNI", nuevo.Dni);

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

        public void EliminarUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("EliminarUsuarios");

                datos.setearParametro("@IdUsuario", idUsuario);

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
    }

}

