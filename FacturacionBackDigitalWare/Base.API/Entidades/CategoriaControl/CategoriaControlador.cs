namespace Base.API.Entidades.CategoriaControl
{
    using Base.Transversal.DTO.EntidadRepositorio;
    public class CategoriaControlador : ICategoriaDTO
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
    }
}
