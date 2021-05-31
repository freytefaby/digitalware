using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DigitalwareTest.Controllers.Request.MovimientoRequest;
using static DigitalwareTest.Dto.MovimientoDto;

namespace DigitalwareTest.Servicios.Interfaces
{
    public interface IMovimientoService
    {
        public Task<List<ListarMovimientosDto>> ListarMovimientos();
        public int InsertarMovimiento(CrearMovimientoRequest request);
        public int EliminarMovimiento(int clienteId);
    }
}
