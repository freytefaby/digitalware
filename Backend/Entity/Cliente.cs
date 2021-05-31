using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalwareTest.Entity
{
    public class Cliente
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public virtual ICollection<Movimiento> movimientos { get; set; }
    }
}
