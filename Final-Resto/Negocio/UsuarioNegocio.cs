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
