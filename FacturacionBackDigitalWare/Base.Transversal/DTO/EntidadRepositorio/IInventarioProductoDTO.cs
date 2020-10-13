namespace Base.Transversal.DTO.EntidadRepositorio
{
    public interface IInventarioProductoDTO
    {
        int IdInventario { get; set; }
        int IdProducto { get; set; }
        int? Cantidad { get; set; }
    }
}
