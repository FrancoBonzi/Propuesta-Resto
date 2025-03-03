using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }

        }

        public AccesoDatos()
        {
            // Cadena de conexión directa en el código
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=BBDD_Resto;Integrated Security=True";

            // Conectar a la base de datos usando la cadena de conexión
            conexion = new SqlConnection(connectionString);
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType= System.Data.CommandType.Text;
            comando.CommandText= consulta;
        }

        public void setearProcedimiento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText= sp;
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int ejecutarAccionScalar()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setearParametro(string nombre,object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if(lector != null)
            {
                lector.Close();
                conexion.Close();
            }
        }

        public SqlDataReader EjecutarLectura()
        {
            conexion.Close();
            comando.Connection = conexion;
            lector = comando.ExecuteReader();
            return lector;
        }
    }
}
