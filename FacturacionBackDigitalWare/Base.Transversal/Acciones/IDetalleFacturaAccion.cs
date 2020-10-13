namespace Base.Transversal.Acciones
{
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadConsulta;
    using Base.Transversal.DTO.EntidadRepositorio;
    using System.Threading.Tasks;
    public interface IDetalleFacturaAccion
    {
        Task<Respuesta<IDetalleFacturaCompuestoDTO>> ConsultarDetalleFactura(IFacturaDTO factura);
        Task<Respuesta<IDetalleFacturaCompuestoDTO>> ActualizarDetalleFactura(IDetalleFacturaCompuestoDTO factura);
    }
}
