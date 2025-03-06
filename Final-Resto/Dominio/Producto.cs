using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        public string Categoria { get; set; }

        public decimal Precio { get; set; }

        public int StockActual { get; set; }

        public int StockMinimo { get; set; }
    }
}
