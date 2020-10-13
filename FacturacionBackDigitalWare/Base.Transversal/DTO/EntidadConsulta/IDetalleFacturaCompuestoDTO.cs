namespace Base.Transversal.DTO.EntidadConsulta
{
    using Base.Transversal.DTO.EntidadRepositorio;

    public interface IDetalleFacturaCompuestoDTO
    {
        public string NombreProducto { get; set; }
        int IdDetalleFactura { get; set; }
        int? IdFactura { get; set; }
        int? IdProducto { get; set; }
        decimal? Precio { get; set; }
        string Observaciones { get; set; }
    }
}
