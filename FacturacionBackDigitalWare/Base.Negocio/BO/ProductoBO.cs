namespace Base.Negocio.BO
{
    using Base.Transversal.DTO.EntidadRepositorio;
    public class ProductoBO : IProductoDTO
    {
        public int IdProducto { get; set; }
        public int? IdCategoria { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
