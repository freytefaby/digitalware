using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalwareTest.Entity
{
    public class Inventario
    {
        public int Id { get; set; }
        public int productoId { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
        public Tipo tipo { get; set; }

        public DateTime fecha { get; set; }

        public virtual Producto producto { get; set; }

    }

    public enum Tipo
    {
        entrada = 0,
        salida = 1
    }
}
