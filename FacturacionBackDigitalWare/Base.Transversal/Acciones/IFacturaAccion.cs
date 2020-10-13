namespace Base.Transversal.Acciones
{
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadConsulta;
    using Base.Transversal.DTO.EntidadRepositorio;
    using System.Threading.Tasks;
    public interface IFacturaAccion
    {
        Task<Respuesta<IFacturaDTO>> CrearFactura(IFacturaDTO Factura);
        Task<Respuesta<IFacturaCompuestaDTO>> LeerFactura(IFacturaDTO Factura);
        Task<Respuesta<IFacturaDTO>> ActualizarFactura(IFacturaDTO Factura);
        Task<Respuesta<IFacturaDTO>> EliminarFactura(IFacturaDTO Factura);
        Task<Respuesta<IFacturaCompuestaDTO>> LeerFacturas();
    }
}
