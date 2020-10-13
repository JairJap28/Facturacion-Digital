namespace Base.Transversal.DTO.EntidadConsulta
{
    using Base.Transversal.DTO.EntidadRepositorio;
    public interface IProductoCompuestoDTO : IProductoDTO
    {
        public int IdInventario { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
    }
}
