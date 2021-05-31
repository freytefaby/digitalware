using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DigitalwareTest.Dto.ProductoDto;

namespace DigitalwareTest.Servicios.Interfaces
{
    public interface IProductoService
    {
        public Task<List<ListarProductoDto>> ListarProductos();
    }
}
