using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalwareTest.Dto
{
    public class ClienteDto
    {
        public class ListarClienteDto
        {
            public int Id { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public int edad { get; set; }
        }
    }
}
