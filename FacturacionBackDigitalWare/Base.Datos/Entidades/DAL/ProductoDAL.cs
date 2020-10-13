namespace Base.Datos.DAL
{
    using AutoMapper;
    using Base.Datos.Contexto;
    using Base.Datos.Entidades.DO.Consultas;
    using Base.Transversal.Acciones;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadConsulta;
    using Base.Transversal.DTO.EntidadRepositorio;
    using Base.Transversal.Recursos;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductoDAL : IProductoAccion
    {
        private readonly ContextoFacturacion contexto;
        private readonly IMapper mapper;

        public ProductoDAL(ContextoFacturacion contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        public async Task<Respuesta<IProductoCompuestoDTO>> ActualizarProducto(IProductoCompuestoDTO producto)
        {
            return await new Wrapper<IProductoCompuestoDTO>().EjecutarTransaccionAsync(async () =>
            {
                InventarioProducto inventario = await contexto.InventarioProducto
                    .FirstOrDefaultAsync(pro => pro.IdProducto == producto.IdProducto);

                inventario.Cantidad = producto.Cantidad;

                contexto.Entry(mapper.Map<Producto>(producto)).State = EntityState.Modified;
                contexto.Entry(inventario).State = EntityState.Modified;
                await contexto.SaveChangesAsync();
                return FabricaRespuesta<IProductoCompuestoDTO>.RespuestaEdicionExitosa(new List<IProductoCompuestoDTO> { producto });
            }, async () => await FabricaRespuesta<IProductoCompuestoDTO>.RespuestaFallida(Mensajes.ErrorEnEdición));
        }

        public async Task<Respuesta<IProductoCompuestoDTO>> CrearProducto(IProductoCompuestoDTO producto)
        {
            return await new Wrapper<IProductoCompuestoDTO>().EjecutarTransaccionAsync(async () =>
            {
                Producto nuevoProducto = mapper.Map<Producto>(producto);
                contexto.Add(nuevoProducto);
                await contexto.SaveChangesAsync();

                InventarioProducto inventario = new InventarioProducto()
                {
                    IdProducto = nuevoProducto.IdProducto,
                    Cantidad = producto.Cantidad
                };
                contexto.Add(inventario);
                await contexto.SaveChangesAsync();
                producto.IdInventario = inventario.IdInventario;
                producto.IdProducto = nuevoProducto.IdProducto;

                return FabricaRespuesta<IProductoCompuestoDTO>.RespuestaCreacionExitosa(new List<IProductoCompuestoDTO> { producto });
            }, async () => await FabricaRespuesta<IProductoCompuestoDTO>.RespuestaFallida(Mensajes.ErrorEnCreacion));
        }

        public async Task<Respuesta<IProductoDTO>> EliminarProducto(IProductoDTO producto)
        {
            return await new Wrapper<IProductoDTO>().EjecutarTransaccionAsync(async () =>
            {
                int IdProducto = await contexto.Producto.Select(Prod => Prod.IdProducto)
                    .FirstOrDefaultAsync(x => x == producto.IdProducto);

                if (IdProducto == default) return FabricaRespuesta<IProductoDTO>.RespuestaEliminacionFallida();
                else
                {
                    contexto.Producto.Remove(new Producto { IdProducto = IdProducto });
                    await contexto.SaveChangesAsync();
                    return FabricaRespuesta<IProductoDTO>.RespuestaEliminacionExitosa();
                }
            }, async () => await FabricaRespuesta<IProductoDTO>.RespuestaFallida(Mensajes.RespuestaFallida));
        }

        public async Task<Respuesta<IProductoCompuestoDTO>> LeerProducto(IProductoDTO productoIn)
        {
            return await new Wrapper<IProductoCompuestoDTO>().EjecutarTransaccionAsync(async () =>
            {
                IProductoCompuestoDTO producto = await contexto.Producto
                                .Include(x => x.IdCategoriaNavigation)
                                .Include(x => x.InventarioProducto)
                                .Where(x => x.IdProducto == productoIn.IdProducto)
                                .Select(x => new ProductoCompuestoDO
                                {
                                    IdProducto = x.IdProducto,
                                    IdCategoria = x.IdCategoria,
                                    Nombre = x.Nombre,
                                    Precio = x.Precio,
                                    Categoria = x.IdCategoriaNavigation.Descripcion,
                                    Cantidad = (int)x.InventarioProducto.FirstOrDefault().Cantidad,
                                    IdInventario = x.InventarioProducto.FirstOrDefault().IdInventario
                                }).FirstOrDefaultAsync<IProductoCompuestoDTO>();

                if (producto == null) return FabricaRespuesta<IProductoCompuestoDTO>.RespuestaSinDatos();
                return FabricaRespuesta<IProductoCompuestoDTO>.RespuestaConDatos(new List<IProductoCompuestoDTO> { producto });
            });
        }

        public async Task<Respuesta<IProductoCompuestoDTO>> LeerProductos()
        {
            return await new Wrapper<IProductoCompuestoDTO>().EjecutarTransaccionAsync(async () =>
            {
                List<IProductoCompuestoDTO> productos = await contexto.Producto
                                .Include(x => x.IdCategoriaNavigation)
                                .Include(x => x.InventarioProducto)
                                .Select(x => new ProductoCompuestoDO
                                {
                                    IdProducto = x.IdProducto,
                                    IdCategoria = x.IdCategoria,
                                    Nombre = x.Nombre,
                                    Precio = x.Precio,
                                    Categoria = x.IdCategoriaNavigation.Descripcion,
                                    Cantidad = (int) x.InventarioProducto.FirstOrDefault().Cantidad,
                                    IdInventario = x.InventarioProducto.FirstOrDefault().IdInventario
                                }).ToListAsync<IProductoCompuestoDTO>();

                if (productos != null && productos.Count > 0) return FabricaRespuesta<IProductoCompuestoDTO>.RespuestaConDatos(productos);
                else return FabricaRespuesta<IProductoCompuestoDTO>.RespuestaSinDatos();
            });
        }
    }
}
