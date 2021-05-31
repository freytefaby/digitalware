using DigitalwareTest.Entity;
using DigitalwareTest.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DigitalwareTest.Dto.ProductoDto;

namespace DigitalwareTest.Servicios
{
    public class ProductoService : IProductoService
    {
        private readonly DigitalWareContext _context;

        public ProductoService(DigitalWareContext context)
        {
            _context = context;
        }

        public async Task<List<ListarProductoDto>> ListarProductos()
        {
            var productos = await _context.producto.ToListAsync();
            return productos.Select(p => new ListarProductoDto()
            {
                Id = p.Id,
                precio = p.precio,
                descripcion = p.descripcion

            }).ToList();
        }
    }
}
