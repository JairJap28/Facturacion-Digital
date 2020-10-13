namespace Base.Transversal.DTO.EntidadRepositorio
{
    public interface IProductoDTO
    {
        int IdProducto { get; set; }
        int? IdCategoria { get; set; }
        string Nombre { get; set; }
        decimal Precio { get; set; }
    }
}
