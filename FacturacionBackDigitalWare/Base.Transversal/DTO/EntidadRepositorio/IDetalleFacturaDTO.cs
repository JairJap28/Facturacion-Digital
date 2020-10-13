namespace Base.Transversal.DTO.EntidadRepositorio
{
    public interface IDetalleFacturaDTO
    {
        int IdDetalleFactura { get; set; }
        int? IdFactura { get; set; }
        int? IdProducto { get; set; }
        decimal? Precio { get; set; }
        string Observaciones { get; set; }
    }
}
