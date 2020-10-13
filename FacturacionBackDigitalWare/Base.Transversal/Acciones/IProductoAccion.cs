namespace Base.Transversal.Acciones
{
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadConsulta;
    using Base.Transversal.DTO.EntidadRepositorio;
    using System.Threading.Tasks;
    public interface IProductoAccion
    {
        Task<Respuesta<IProductoCompuestoDTO>> CrearProducto(IProductoCompuestoDTO producto);
        Task<Respuesta<IProductoCompuestoDTO>> LeerProducto(IProductoDTO producto);
        Task<Respuesta<IProductoCompuestoDTO>> ActualizarProducto(IProductoCompuestoDTO producto);
        Task<Respuesta<IProductoDTO>> EliminarProducto(IProductoDTO producto);
        Task<Respuesta<IProductoCompuestoDTO>> LeerProductos();
    }
}
