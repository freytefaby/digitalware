using DigitalwareTest.Entity;
using DigitalwareTest.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DigitalwareTest.Dto.ClienteDto;

namespace DigitalwareTest.Servicios
{
    public class ClienteService : IClienteService
    {
        private readonly DigitalWareContext _context;

        public ClienteService(DigitalWareContext context)
        {
            _context = context;
        }
        public async Task<List<ListarClienteDto>> ListarUsuarios()
        {
            var Clientes =  await _context.cliente.ToListAsync();
            return Clientes.Select(x => new ListarClienteDto()
            {
                Id = x.Id,
                nombre = x.nombre,
                apellido = x.apellido,
                edad = x.edad
            }).ToList();
            
        }
    }
}
