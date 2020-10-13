namespace Base.Datos.Contexto
{
    using Base.Datos.Contexto.Entidades;
    public partial class DetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public int? IdFactura { get; set; }
        public int? IdProducto { get; set; }
        public decimal? Precio { get; set; }
        public string Observaciones { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
