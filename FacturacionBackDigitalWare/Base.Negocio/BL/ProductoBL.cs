namespace Base.Negocio.BL
{
    using Base.Datos.DAL;
    using Base.Transversal.Acciones;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadConsulta;
    using Base.Transversal.DTO.EntidadRepositorio;
    using System.Threading.Tasks;
    public class ProductoBL : IProductoAccion
    {
        private readonly ProductoDAL productoDAL;

        public ProductoBL(ProductoDAL productoDAL)
        {
            this.productoDAL = productoDAL;
        }

        public async Task<Respuesta<IProductoCompuestoDTO>> ActualizarProducto(IProductoCompuestoDTO producto)
        {
            return await productoDAL.ActualizarProducto(producto);
        }

        public async Task<Respuesta<IProductoCompuestoDTO>> CrearProducto(IProductoCompuestoDTO producto)
        {
            return await productoDAL.CrearProducto(producto);
        }

        public async Task<Respuesta<IProductoDTO>> EliminarProducto(IProductoDTO producto)
        {
            return await productoDAL.EliminarProducto(producto);
        }

        public async Task<Respuesta<IProductoCompuestoDTO>> LeerProducto(IProductoDTO producto)
        {
            return await productoDAL.LeerProducto(producto);
        }

        public async Task<Respuesta<IProductoCompuestoDTO>> LeerProductos()
        {
            return await productoDAL.LeerProductos();
        }
    }
}
