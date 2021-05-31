using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalwareTest.Entity
{
    public class Movimiento
    {
        public int Id { get; set; }
        public int productoId { get; set; }
        public int clienteId { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
        public DateTime fecha { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual Producto producto { get; set; }


    }
}
