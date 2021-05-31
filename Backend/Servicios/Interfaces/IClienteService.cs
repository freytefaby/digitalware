using DigitalwareTest.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DigitalwareTest.Dto.ClienteDto;

namespace DigitalwareTest.Servicios.Interfaces
{
    public interface IClienteService
    {
        public Task<List<ListarClienteDto>> ListarUsuarios();
    }
}
