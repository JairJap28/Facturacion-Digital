namespace Base.API.Controllers
{
    using AutoMapper;
    using Base.API.Entidades.CategoriaControl;
    using Base.Negocio.BL;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadRepositorio;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController
    {
        private readonly CategoriaBL CategoriaBL;
        private readonly IMapper mapper;

        public CategoriaController(CategoriaBL CategoriaBL, IMapper mapper)
        {
            this.CategoriaBL = CategoriaBL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("ConsultarCategoria")]
        public async Task<Respuesta<CategoriaControlador>> ConsultarCategoria(int idCategoria)
        {
            return mapper.Map<Respuesta<CategoriaControlador>>(await CategoriaBL.LeerCategoria(mapper.Map<ICategoriaDTO>(new CategoriaControlador { IdCategoria = idCategoria })));
        }

        [HttpGet]
        [Route("ConsultarCategorias")]
        public async Task<Respuesta<CategoriaControlador>> ConsultarCategorias()
        {
            return mapper.Map<Respuesta<CategoriaControlador>>(await CategoriaBL.LeerCategorias());
        }

        [HttpPost]
        [Route("CrearCategoria")]
        public async Task<Respuesta<CategoriaControlador>> CrearCategoria(CategoriaControlador Categoria)
        {
            return mapper.Map<Respuesta<CategoriaControlador>>(await CategoriaBL.CrearCategoria(mapper.Map<ICategoriaDTO>(Categoria)));
        }

        [HttpPut]
        [Route("ActualizarCategoria")]
        public async Task<Respuesta<CategoriaControlador>> ActualizarCategoria(CategoriaControlador Categoria)
        {
            return mapper.Map<Respuesta<CategoriaControlador>>(await CategoriaBL.ActualizarCategoria(mapper.Map<ICategoriaDTO>(Categoria)));
        }

        [HttpDelete]
        [Route("EliminarCategoria")]
        public async Task<Respuesta<CategoriaControlador>> EliminarCategoria(CategoriaControlador Categoria)
        {
            return mapper.Map<Respuesta<CategoriaControlador>>(await CategoriaBL.EliminarCategoria(mapper.Map<ICategoriaDTO>(Categoria)));
        }
    }
}
