using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalwareTest.Dto
{
    public class MovimientoDto
    {
        public class ListarMovimientosDto
        {
            public int movimientoId { get; set; }
            public int clienteId { get; set; }
            public int productoId { get; set; }
            public string cliente { get; set; }
            public int edad_cliente { get; set; }
            public string producto { get; set; }
            public double precio { get; set; }
            public int cantidad { get; set; }
            public DateTime fecha { get; set; }

        }
    }
}
