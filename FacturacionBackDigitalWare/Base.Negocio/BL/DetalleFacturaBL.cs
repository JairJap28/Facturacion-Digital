namespace Base.Negocio.BL
{
    using Base.Datos.Entidades.DAL;
    using Base.Transversal.Acciones;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadConsulta;
    using Base.Transversal.DTO.EntidadRepositorio;
    using System.Threading.Tasks;
    public class DetalleFacturaBL : IDetalleFacturaAccion
    {
        private readonly DetalleFacturaDAL detalleFacturaDAL;
        public DetalleFacturaBL(DetalleFacturaDAL detalleFacturaDAL)
        {
            this.detalleFacturaDAL = detalleFacturaDAL;
        }

        public async Task<Respuesta<IDetalleFacturaCompuestoDTO>> ActualizarDetalleFactura(IDetalleFacturaCompuestoDTO factura)
        {
            return await detalleFacturaDAL.ActualizarDetalleFactura(factura);
        }

        public async Task<Respuesta<IDetalleFacturaCompuestoDTO>> ConsultarDetalleFactura(IFacturaDTO factura)
        {
            return await detalleFacturaDAL.ConsultarDetalleFactura(factura);
        }
    }
}
