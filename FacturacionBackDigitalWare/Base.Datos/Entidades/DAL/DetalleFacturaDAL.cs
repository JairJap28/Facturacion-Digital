namespace Base.Datos.Entidades.DAL
{
    using AutoMapper;
    using Base.Datos.Contexto;
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
    public class DetalleFacturaDAL : IDetalleFacturaAccion
    {
        private readonly ContextoFacturacion contexto;
        private readonly IMapper mapper;
        public DetalleFacturaDAL(ContextoFacturacion contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        public async Task<Respuesta<IDetalleFacturaCompuestoDTO>> ActualizarDetalleFactura(IDetalleFacturaCompuestoDTO factura)
        {
            return await new Wrapper<IDetalleFacturaCompuestoDTO>().EjecutarTransaccionAsync(async () =>
            {
                DetalleFactura detalleFactura = new DetalleFactura()
                {
                    IdDetalleFactura = factura.IdDetalleFactura,
                    IdFactura = factura.IdFactura,
                    IdProducto = factura.IdProducto,
                    Observaciones = factura.Observaciones,
                    Precio = factura.Precio
                };

                contexto.Entry(detalleFactura).State = EntityState.Modified;
                await contexto.SaveChangesAsync();
                return FabricaRespuesta<IDetalleFacturaCompuestoDTO>.RespuestaEdicionExitosa(
                    new List<IDetalleFacturaCompuestoDTO> { factura }
                );
            }, async () => await FabricaRespuesta<IDetalleFacturaCompuestoDTO>.RespuestaFallida(Mensajes.ErrorEnEdición));
        }

        public async Task<Respuesta<IDetalleFacturaCompuestoDTO>> ConsultarDetalleFactura(IFacturaDTO factura)
        {
            return await new Wrapper<IDetalleFacturaCompuestoDTO>().EjecutarTransaccionAsync(async () =>
            {
                List<IDetalleFacturaCompuestoDTO> detalles = await contexto.DetalleFactura
                            .Include(x => x.IdProductoNavigation)
                            .Where(x => x.IdFactura == factura.IdFactura)
                            .Select(x => new DetalleFacturaCompuestoDO()
                            {
                                IdDetalleFactura = x.IdDetalleFactura,
                                IdFactura = x.IdFactura,
                                IdProducto = x.IdProducto,
                                NombreProducto = x.IdProductoNavigation.Nombre,
                                Observaciones = x.Observaciones,
                                Precio = x.Precio
                            }).ToListAsync<IDetalleFacturaCompuestoDTO>();

                if (detalles != null && detalles.Count > 0) return FabricaRespuesta<IDetalleFacturaCompuestoDTO>.RespuestaConDatos(detalles);
                else return FabricaRespuesta<IDetalleFacturaCompuestoDTO>.RespuestaSinDatos();
            });
        }
    }
}
