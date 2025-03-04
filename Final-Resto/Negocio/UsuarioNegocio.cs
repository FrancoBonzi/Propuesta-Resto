using Dominio;
using Final_Resto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
                datos.setearConsulta("SELECT * FROM Usuarios");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.UsuarioNombre = (string)datos.Lector["Usuario"];
                    aux.Contrasena = (string)datos.Lector["Contrasena"];
                    aux.Rol = (string)datos.Lector["Rol"];

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

        public Usuario ObtenerUsuario(string UsuarioNombre)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario aux = null; 

            try
            {
                datos.setearConsulta("SELECT * FROM Usuarios WHERE Usuario = @Usuario");
                datos.setearParametro("@Usuario", UsuarioNombre);
                datos.EjecutarLectura();

                if (datos.Lector.Read()) 
                {
                    aux = new Usuario
                    {
                        Id = Convert.ToInt32(datos.Lector["Id"]),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        UsuarioNombre = datos.Lector["Usuario"].ToString(),
                        Contrasena = datos.Lector["Contrasena"].ToString(),
                        Rol = datos.Lector["Rol"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }

            return aux; 
        }











        public void AgregarUsuario(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("INSERT INTO Usuarios (Nombre, Usuario, Contrasena, Rol) VALUES (@Nombre, @Usuario, @Contrasena, @Rol)");

                datos.setearParametro("@Id", nuevo.Id);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Usuario", nuevo.UsuarioNombre);
                datos.setearParametro("@Contrasena", nuevo.Contrasena);
                datos.setearParametro("@Rol", nuevo.Rol);

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

