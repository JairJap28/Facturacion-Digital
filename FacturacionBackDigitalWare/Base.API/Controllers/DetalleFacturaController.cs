namespace Base.API.Controllers
{
    using AutoMapper;
    using Base.API.Entidades.DetalleFactura;
    using Base.API.Entidades.FacturaControl;
    using Base.Negocio.BL;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadRepositorio;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;


    [Route("api/[controller]")]
    [ApiController]
    public class DetalleFacturaController
    {
        private readonly DetalleFacturaBL detalleFacturaBL;
        private readonly IMapper mapper;

        public DetalleFacturaController(DetalleFacturaBL detalleFacturaBL, IMapper mapper)
        {
            this.detalleFacturaBL = detalleFacturaBL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("ConsultarDetalleFactura")]
        public async Task<Respuesta<DetalleFacturaCompuestoControlador>> ConsultarCliente(int idFactura)
        {
            return mapper.Map<Respuesta<DetalleFacturaCompuestoControlador>>(
                await detalleFacturaBL.ConsultarDetalleFactura(mapper.Map<IFacturaDTO>(
                        new FacturaControlador { IdFactura = idFactura })
                    )
                );
        }

        [HttpPut]
        [Route("ActualizarDetalleFactura")]
        public async Task<Respuesta<DetalleFacturaCompuestoControlador>> ActualizarDetalle(DetalleFacturaCompuestoControlador detalle)
        {
            return mapper.Map<Respuesta<DetalleFacturaCompuestoControlador>>(
                    await detalleFacturaBL.ActualizarDetalleFactura(detalle)
                );
        }
    }
}
