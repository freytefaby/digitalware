using DigitalwareTest.Entity;
using DigitalwareTest.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DigitalwareTest.Controllers.Request.MovimientoRequest;
using static DigitalwareTest.Dto.MovimientoDto;

namespace DigitalwareTest.Servicios
{
    public class MovimientoService: IMovimientoService
    {
        private readonly DigitalWareContext _context;

        public MovimientoService(DigitalWareContext context)
        {
            _context = context;
        }

        public async Task<List<ListarMovimientosDto>> ListarMovimientos()
        {
           
            var movimientos = await  (from m in _context.movimiento
                                      join c in _context.cliente on m.clienteId equals c.Id
                                      join p in _context.producto on m.productoId equals p.Id
                                      select new ListarMovimientosDto()
                                      {
                                           movimientoId = m.Id,
                                           clienteId = c.Id,
                                           productoId = p.Id,
                                           cliente = $"{c.nombre} {c.apellido}",
                                           edad_cliente = c.edad,
                                           producto = p.descripcion,
                                           precio = m.precio,
                                           cantidad = m.cantidad,
                                           fecha = m.fecha
                                      }).ToListAsync();

            return movimientos;
        }



        public int InsertarMovimiento(CrearMovimientoRequest request)
        {
           using(var transaccion = _context.Database.BeginTransaction())
           {
                try
                {
                    request.productos.ForEach(item =>
                    {
                        var producto = _context.producto.Where(p => p.Id == item.productoId).FirstOrDefault();
                        if(producto != null)
                        {
                            _context.movimiento.Add(new Movimiento()
                            {
                                productoId = item.productoId,
                                clienteId = request.clienteId,
                                cantidad = item.cantidad,
                                precio = producto.precio * item.cantidad,
                                fecha = DateTime.Now
                            });

                            _context.inventario.Add(new Inventario()
                            {
                                productoId = item.productoId,
                                cantidad = item.cantidad,
                                precio = producto.precio * item.cantidad,
                                tipo = Tipo.salida,
                                fecha = DateTime.Now
                            });
                        }
                        else
                        {
                            throw new Exception();
                        }
                       
                    });
                    _context.SaveChanges();
                    transaccion.Commit();
                    return 1;
                }
                catch
                {
                    transaccion.Rollback();
                    return 0;
                }
               
           }

           
        }

        public int EliminarMovimiento(int clienteId)
        {
            var Movimientos = _context.movimiento.Where(x => x.clienteId == clienteId).ToList();
            if(Movimientos.Count > 0)
            {
                using(var transaccion = _context.Database.BeginTransaction())
                {
                    try
                    {
                        Movimientos.ForEach(item =>
                        {
                            _context.movimiento.Remove(item);
                            _context.inventario.Add(new Inventario()
                            {
                                productoId = item.productoId,
                                cantidad = item.cantidad,
                                precio = item.precio,
                                tipo = Tipo.entrada,
                                fecha = DateTime.Now
                            });

                           
                        });

                        _context.SaveChanges();
                        transaccion.Commit();
                        return 1;


                    }
                    catch
                    {
                        transaccion.Rollback();
                        return 0;
                    }
                }
            }
            return 0;

        }

    }
}
