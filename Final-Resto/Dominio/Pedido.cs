using Final_Resto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int IdPedido { get; set; }


        public Mesa mesa { get; set; }

        public Usuario usuario { get; set; }

        public DateTime FechaHora { get; set; }

        public DateTime FechaHoraCierre { get; set; }

        public Decimal Total { get; set; }
    }
}
