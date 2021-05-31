using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalwareTest.Controllers.Request
{
    public class MovimientoRequest
    {
        public class CrearMovimientoRequest
        {
            [Range(1, int.MaxValue, ErrorMessage = "Valor requerido")]       
            public int clienteId { get; set; }
            [Required]
            [MinLength(1)]
            public List<Producto> productos { get; set; }

            public class Producto
            {
                [Range(1, int.MaxValue, ErrorMessage = "Valor requerido")]
                public int productoId { get; set; }
                [Range(1, int.MaxValue, ErrorMessage = "Valor requerido")]
                public int cantidad { get; set; }
            }

        }
    }
}
