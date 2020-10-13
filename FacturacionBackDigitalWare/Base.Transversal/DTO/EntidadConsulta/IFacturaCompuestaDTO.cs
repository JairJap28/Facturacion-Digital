namespace Base.Transversal.DTO.EntidadConsulta
{
    using Base.Transversal.DTO.EntidadRepositorio;
    using System.Collections.Generic;

    public interface IFacturaCompuestaDTO : IFacturaDTO
    {
        public string NombreCliente { get; set; }
        public int CantidadProductos { get; set; }
        public float ValorTotal { get; set; }
        public List<IDetalleFacturaCompuestoDTO> listaDetalle { get; set; }
    }
}
