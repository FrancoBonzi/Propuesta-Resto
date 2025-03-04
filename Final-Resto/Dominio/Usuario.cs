using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Final_Resto
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UsuarioNombre { get; set; }

        [DisplayName("Contraseña")]
        public string Contrasena { get; set; }
        public string Rol { get; set; } 

    }
}