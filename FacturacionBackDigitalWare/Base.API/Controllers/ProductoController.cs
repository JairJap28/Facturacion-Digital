namespace Base.API.Controllers
{
    using AutoMapper;
    using Base.API.Entidades.ProductoControl;
    using Base.Negocio.BL;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadRepositorio;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController
    {
        private readonly ProductoBL productoBL;
        private readonly IMapper mapper;

        public ProductoController(ProductoBL productoBL, IMapper mapper)
        {
            this.productoBL = productoBL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("ConsultarProducto")]
        public async Task<Respuesta<ProductoCompuestoControlador>> ConsultarProdcuto(int idProducto)
        {
            return mapper.Map<Respuesta<ProductoCompuestoControlador>>(await productoBL.LeerProducto(mapper.Map<IProductoDTO>(new ProductoControlador { IdProducto = idProducto })));
        }

        [HttpGet]
        [Route("ConsultarProductos")]
        public async Task<Respuesta<ProductoCompuestoControlador>> ConsultarProductos()
        {
            return mapper.Map<Respuesta<ProductoCompuestoControlador>>(await productoBL.LeerProductos());
        }

        [HttpPost]
        [Route("CrearProducto")]
        public async Task<Respuesta<ProductoCompuestoControlador>> CrearProducto(ProductoCompuestoControlador producto)
        {
            return mapper.Map<Respuesta<ProductoCompuestoControlador>>(await productoBL.CrearProducto(producto));
        }

        [HttpPut]
        [Route("ActualizarProducto")]
        public async Task<Respuesta<ProductoCompuestoControlador>> ActualizarProducto(ProductoCompuestoControlador producto)
        {
            return mapper.Map<Respuesta<ProductoCompuestoControlador>>(await productoBL.ActualizarProducto(producto));
        }

        [HttpDelete]
        [Route("EliminarProducto")]
        public async Task<Respuesta<ProductoControlador>> EliminarProducto(ProductoControlador producto)
        {
            return mapper.Map<Respuesta<ProductoControlador>>(await productoBL.EliminarProducto(mapper.Map<IProductoDTO>(producto)));
        }
    }
}
