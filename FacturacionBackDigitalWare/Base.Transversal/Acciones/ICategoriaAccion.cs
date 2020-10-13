namespace Base.Transversal.Acciones
{
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadRepositorio;
    using System.Threading.Tasks;
    public interface ICategoriaAccion 
    {
        Task<Respuesta<ICategoriaDTO>> CrearCategoria(ICategoriaDTO Categoria);
        Task<Respuesta<ICategoriaDTO>> LeerCategoria(ICategoriaDTO Categoria);
        Task<Respuesta<ICategoriaDTO>> ActualizarCategoria(ICategoriaDTO Categoria);
        Task<Respuesta<ICategoriaDTO>> EliminarCategoria(ICategoriaDTO Categoria);
        Task<Respuesta<ICategoriaDTO>> LeerCategorias();
    }
}
