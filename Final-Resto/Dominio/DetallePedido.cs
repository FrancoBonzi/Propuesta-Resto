using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class DetallePedido
    {

       public int IdDetalle { get; set; }


       public int IdPedido{ get; set; }

       public int IdProducto { get; set; }

       public DateTime Cantidad { get; set; }

       public DateTime PrecioUnitario { get; set; }

       public Decimal Subtotal { get; set; }
    }
}
