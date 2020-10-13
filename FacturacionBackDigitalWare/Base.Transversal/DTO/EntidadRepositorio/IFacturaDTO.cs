namespace Base.Transversal.DTO.EntidadRepositorio
{
    using System;
    public interface IFacturaDTO
    {
        public int IdFactura { get; set; }
        public int? IdCliente { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
