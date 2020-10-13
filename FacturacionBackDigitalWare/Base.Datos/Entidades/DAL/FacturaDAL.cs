namespace Base.Datos.Entidades.DAL
{
    using AutoMapper;
    using Base.Datos.Contexto;
    using Base.Datos.Contexto.Entidades;
    using Base.Datos.Entidades.DO.Consultas;
    using Base.Transversal.Acciones;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadConsulta;
    using Base.Transversal.DTO.EntidadRepositorio;
    using Base.Transversal.Recursos;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class FacturaDAL : IFacturaAccion
    {
        private readonly ContextoFacturacion contexto;
        private readonly IMapper mapper;
        public FacturaDAL(ContextoFacturacion contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        public async Task<Respuesta<IFacturaDTO>> ActualizarFactura(IFacturaDTO factura)
        {
            return await new Wrapper<IFacturaDTO>().EjecutarTransaccionAsync(async () =>
            {
                contexto.Entry(mapper.Map<Factura>(factura)).State = EntityState.Modified;
                await contexto.SaveChangesAsync();
                return FabricaRespuesta<IFacturaDTO>.RespuestaEdicionExitosa(new List<IFacturaDTO> { factura });
            }, async () => await FabricaRespuesta<IFacturaDTO>.RespuestaFallida(Mensajes.ErrorEnEdición));
        }

        public async Task<Respuesta<IFacturaDTO>> CrearFactura(IFacturaDTO factura)
        {
            return await new Wrapper<IFacturaDTO>().EjecutarTransaccionAsync(async () =>
            {
                Factura nuevaFactura = mapper.Map<Factura>(factura);
                contexto.Add(nuevaFactura);
                await contexto.SaveChangesAsync();
                return FabricaRespuesta<IFacturaDTO>.RespuestaCreacionExitosa(new List<IFacturaDTO> { nuevaFactura });
            }, async () => await FabricaRespuesta<IFacturaDTO>.RespuestaFallida(Mensajes.ErrorEnCreacion));
        }

        public async Task<Respuesta<IFacturaDTO>> EliminarFactura(IFacturaDTO factura)
        {
            return await new Wrapper<IFacturaDTO>().EjecutarTransaccionAsync(async () =>
            {
                int facturaId = await contexto.Factura.Select(fac => fac.IdFactura)
                    .FirstOrDefaultAsync(x => x == factura.IdFactura);

                if (facturaId == default) return FabricaRespuesta<IFacturaDTO>.RespuestaEliminacionFallida();
                else
                {
                    contexto.Factura.Remove(new Factura { IdFactura = facturaId });
                    await contexto.SaveChangesAsync();
                    return FabricaRespuesta<IFacturaDTO>.RespuestaEliminacionExitosa();
                }
            }, async () => await FabricaRespuesta<IFacturaDTO>.RespuestaFallida(Mensajes.ErrorEnEliminacion));
        }

        public async Task<Respuesta<IFacturaCompuestaDTO>> LeerFactura(IFacturaDTO facturaIn)
        {
            return await new Wrapper<IFacturaCompuestaDTO>().EjecutarTransaccionAsync(async () =>
            {
                IFacturaCompuestaDTO factura = await contexto.Factura
                            .Include(x => x.IdClienteNavigation)
                            .Include(x => x.DetalleFactura)
                            .Where(x => x.IdFactura == facturaIn.IdFactura)
                            .Select(x => new FacturaCompuestaDO
                            {
                                IdFactura = x.IdFactura,
                                IdCliente = x.IdCliente,
                                NombreCliente = $"{x.IdClienteNavigation.PrimerNombre} {x.IdClienteNavigation.PrimerApellido}",
                                Fecha = x.Fecha
                            }).FirstOrDefaultAsync<IFacturaCompuestaDTO>();
                if (factura == null) return FabricaRespuesta<IFacturaCompuestaDTO>.RespuestaSinDatos();
                return FabricaRespuesta<IFacturaCompuestaDTO>.RespuestaConDatos(new List<IFacturaCompuestaDTO> { factura });
            });
        }

        public async Task<Respuesta<IFacturaCompuestaDTO>> LeerFacturas()
        {
            return await new Wrapper<IFacturaCompuestaDTO>().EjecutarTransaccionAsync(async () =>
            {
                List<IFacturaCompuestaDTO> facturas = await contexto.Factura
                            .Include(x => x.IdClienteNavigation)
                            .Include(x => x.DetalleFactura)
                            .Select(x => new FacturaCompuestaDO
                            {
                                IdFactura = x.IdFactura,
                                IdCliente = x.IdCliente,
                                NombreCliente = $"{x.IdClienteNavigation.PrimerNombre} {x.IdClienteNavigation.PrimerApellido}",
                                Fecha = x.Fecha,
                                CantidadProductos = x.DetalleFactura.Count,
                                ValorTotal = (float) x.DetalleFactura.Sum(x => x.Precio),
                                listaDetalle =  x.DetalleFactura
                                                .Select(det => new DetalleFacturaCompuestoDO { 
                                                    IdDetalleFactura = det.IdDetalleFactura,
                                                    IdFactura = det.IdFactura,
                                                    IdProducto = det.IdProducto,
                                                    NombreProducto = det.IdProductoNavigation.Nombre,
                                                    Observaciones = det.Observaciones,
                                                    Precio = det.Precio
                                                }).ToList<IDetalleFacturaCompuestoDTO>()
                            }).ToListAsync<IFacturaCompuestaDTO>();


                return FabricaRespuesta<IFacturaCompuestaDTO>.RespuestaConDatos(facturas);
            });
        }
    }
}
