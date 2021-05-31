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
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _producto;
        public ProductoController(IProductoService producto)
        {
            _producto = producto;
        }

        [HttpGet("")]
        public async Task<ActionResult> ListarProductos()
        {
            var productos = await  _producto.ListarProductos();
            return RespuestasHttp.ok("Productos", productos);
        }
    }
}
