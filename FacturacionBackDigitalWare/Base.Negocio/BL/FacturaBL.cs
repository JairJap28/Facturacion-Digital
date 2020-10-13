namespace Base.Negocio.BL
{
    using Base.Datos.Entidades.DAL;
    using Base.Transversal.Acciones;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadConsulta;
    using Base.Transversal.DTO.EntidadRepositorio;
    using System.Threading.Tasks;
    public class FacturaBL : IFacturaAccion
    {
        private readonly FacturaDAL facturaDAL;
        public FacturaBL(FacturaDAL facturaDAL)
        {
            this.facturaDAL = facturaDAL;
        }

        public async Task<Respuesta<IFacturaDTO>> ActualizarFactura(IFacturaDTO factura)
        {
            return await facturaDAL.ActualizarFactura(factura);
        }

        public async Task<Respuesta<IFacturaDTO>> CrearFactura(IFacturaDTO factura)
        {
            return await facturaDAL.CrearFactura(factura);
        }

        public async Task<Respuesta<IFacturaDTO>> EliminarFactura(IFacturaDTO factura)
        {
            return await facturaDAL.EliminarFactura(factura);
        }

        public async Task<Respuesta<IFacturaCompuestaDTO>> LeerFactura(IFacturaDTO factura)
        {
            return await facturaDAL.LeerFactura(factura);
        }

        public async Task<Respuesta<IFacturaCompuestaDTO>> LeerFacturas()
        {
            return await facturaDAL.LeerFacturas();
        }
    }
}
