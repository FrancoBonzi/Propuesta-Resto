using Final_Resto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetallePedido
    {

       public int IdDetalle { get; set; }

       public int IdPedido{ get; set; }

       public int IdProducto { get; set; }

       public Producto nombre { get; set; }

       public Pedido pedido { get; set; }

       public int Cantidad { get; set; }

       public Decimal PrecioUnitario { get; set; }

       public Decimal Subtotal { get; set; }
    }
}
