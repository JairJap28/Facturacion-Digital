namespace Base.Negocio.BL
{
    using Base.Datos.Entidades.DAL;
    using Base.Transversal.Acciones;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadRepositorio;
    using System.Threading.Tasks;
    public class CategoriaBL : ICategoriaAccion
    {

        private readonly CategoriaDAL categoriaDAL;
        public CategoriaBL(CategoriaDAL categoriaDAL)
        {
            this.categoriaDAL = categoriaDAL;
        }

        public async Task<Respuesta<ICategoriaDTO>> ActualizarCategoria(ICategoriaDTO categoria)
        {
            return await categoriaDAL.ActualizarCategoria(categoria);
        }

        public async Task<Respuesta<ICategoriaDTO>> CrearCategoria(ICategoriaDTO categoria)
        {
            return await categoriaDAL.CrearCategoria(categoria);
        }

        public async Task<Respuesta<ICategoriaDTO>> EliminarCategoria(ICategoriaDTO categoria)
        {
            return await categoriaDAL.EliminarCategoria(categoria);
        }

        public async Task<Respuesta<ICategoriaDTO>> LeerCategoria(ICategoriaDTO categoria)
        {
            return await categoriaDAL.LeerCategoria(categoria);
        }

        public async Task<Respuesta<ICategoriaDTO>> LeerCategorias()
        {
            return await categoriaDAL.LeerCategorias();
        }
    }
}
