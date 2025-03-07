using Final_Resto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mesa
    {
        public int IdMesa { get; set; }

        public int NumeroMesa { get; set; }

        public string Estado { get; set; }
        public int IdMozo { get; set; } 
       
        public Usuario usuarioNombre { get; set; }

        public int Disponible { get; set; }

        public int CapacidadMesa { get; set; }
    }
}
