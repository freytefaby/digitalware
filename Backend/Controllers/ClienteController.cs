using DigitalwareTest.Controllers.Helpers;
using DigitalwareTest.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalwareTest.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _cliente;
        public ClienteController(IClienteService cliente)
        {
            _cliente = cliente;
        }
        [HttpGet("")]
        public async Task<ActionResult> ListarCliente()
        {
            var Clientes = await _cliente.ListarUsuarios();
            return RespuestasHttp.ok("Clientes", Clientes);
          
            
        }
        
    }
}
