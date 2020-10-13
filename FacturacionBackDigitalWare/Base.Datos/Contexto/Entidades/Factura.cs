namespace Base.Datos.Contexto.Entidades
{
    using System;
    using System.Collections.Generic;
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public int? IdCliente { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
