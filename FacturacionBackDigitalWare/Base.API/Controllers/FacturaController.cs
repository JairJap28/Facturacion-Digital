namespace Base.API.Controllers
{
    using AutoMapper;
    using Base.API.Entidades.FacturaControl;
    using Base.Negocio.BL;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadRepositorio;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController
    {
        private readonly FacturaBL FacturaBL;
        private readonly IMapper mapper;

        public FacturaController(FacturaBL FacturaBL, IMapper mapper)
        {
            this.FacturaBL = FacturaBL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("ConsultarFactura")]
        public async Task<Respuesta<FacturaCompuestaControl>> ConsultarFactura(int idFactura)
        {
            return mapper.Map<Respuesta<FacturaCompuestaControl>>(await FacturaBL.LeerFactura(mapper.Map<IFacturaDTO>(new FacturaControlador { IdFactura = idFactura })));
        }

        [HttpGet]
        [Route("ConsultarFacturas")]
        public async Task<Respuesta<FacturaCompuestaControl>> ConsultarFacturas()
        {
            return mapper.Map<Respuesta<FacturaCompuestaControl>>(await FacturaBL.LeerFacturas());
        }

        [HttpPost]
        [Route("CrearFactura")]
        public async Task<Respuesta<FacturaControlador>> CrearFactura(FacturaDetalleControlador factura)
        {
            return mapper.Map<Respuesta<FacturaControlador>>(await FacturaBL.CrearFactura(factura));
        }

        [HttpPut]
        [Route("ActualizarFactura")]
        public async Task<Respuesta<FacturaControlador>> ActualizarFactura(FacturaDetalleControlador factura)
        {
            return mapper.Map<Respuesta<FacturaControlador>>(await FacturaBL.ActualizarFactura(factura));
        }

        [HttpDelete]
        [Route("EliminarFactura")]
        public async Task<Respuesta<FacturaControlador>> EliminarFactura(FacturaControlador factura)
        {
            return mapper.Map<Respuesta<FacturaControlador>>(await FacturaBL.EliminarFactura(mapper.Map<IFacturaDTO>(factura)));
        }
    }
}
