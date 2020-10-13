namespace Base.API.Entidades.ProductoControl
{
    using Base.Transversal.DTO.EntidadRepositorio;
    public class ProductoControlador : IProductoDTO
    {
        public int IdProducto { get; set; }
        public int? IdCategoria { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
