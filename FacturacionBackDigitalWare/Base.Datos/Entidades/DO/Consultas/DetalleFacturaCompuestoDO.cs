namespace Base.Datos.Entidades.DO.Consultas
{
    using Base.Transversal.DTO.EntidadConsulta;
    public class DetalleFacturaCompuestoDO : IDetalleFacturaCompuestoDTO
    {
        public string NombreProducto { get; set; }
        public int IdDetalleFactura { get; set; }
        public int? IdFactura { get; set; }
        public int? IdProducto { get; set; }
        public decimal? Precio { get; set; }
        public string Observaciones { get; set; }
    }
}
