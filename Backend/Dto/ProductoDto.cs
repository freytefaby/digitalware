using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalwareTest.Dto
{
    public class ProductoDto
    {
        public class ListarProductoDto
        {
            public int Id { get; set; }
            public double precio { get; set; }
            public string descripcion { get; set; }
        }
    }
}
