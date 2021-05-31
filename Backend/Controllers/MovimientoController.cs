using DigitalwareTest.Controllers.Helpers;
using DigitalwareTest.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static DigitalwareTest.Controllers.Request.MovimientoRequest;

namespace DigitalwareTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientoController: ControllerBase
    {
        private readonly IMovimientoService _movimiento;
        public MovimientoController(IMovimientoService movimiento)
        {
            _movimiento = movimiento;
        }

        [HttpGet("")]
        public async Task<ActionResult> ListarMovimientos()
        {
            var movimientos = await _movimiento.ListarMovimientos();
            return RespuestasHttp.ok("Movimientos", movimientos);
        }

        [HttpPost("")]
        public ActionResult CrearMovimiento([FromBody] CrearMovimientoRequest request)
        {
            int crearMovimiento = _movimiento.InsertarMovimiento(request);
            if (crearMovimiento == 1)
                return RespuestasHttp.ok("Successfull");
            else
                return RespuestasHttp.InternalError("No se pudo procesar los datos");
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarMovimiento([Range(1, int.MaxValue)] int id)
        {
            int eliminarMovimiento = _movimiento.EliminarMovimiento(id);
            if (eliminarMovimiento == 1)
                return RespuestasHttp.ok("Successfull");
            else
                return RespuestasHttp.InternalError("No se pudo procesar los datos");
            
        }
    }
}
