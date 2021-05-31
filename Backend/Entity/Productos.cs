using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalwareTest.Entity
{
    public class Producto
    {
        public int Id { get; set; }
        public double precio { get; set; }
        public string descripcion { get; set; }
        public virtual ICollection<Movimiento> movimientos { get; set; }
        public virtual ICollection<Inventario> inventarios { get; set; }
    }
}
