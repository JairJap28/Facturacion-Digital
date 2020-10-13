namespace Base.API.Entidades.FacturaControl
{
    using Base.Transversal.DTO.EntidadConsulta;
    using System;
    using System.Collections.Generic;

    public class FacturaCompuestaControl : IFacturaCompuestaDTO
    {
        public string NombreCliente { get; set; }
        public int IdFactura { get; set; }
        public int? IdCliente { get; set; }
        public DateTime? Fecha { get; set; }
        public int CantidadProductos { get; set; }
        public float ValorTotal { get; set; }
        public List<IDetalleFacturaCompuestoDTO> listaDetalle { get; set; }
    }
}
