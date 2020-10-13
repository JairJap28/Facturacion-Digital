namespace Base.Datos.Contexto
{
    using System;
    using System.Collections.Generic;
    public partial class InventarioProducto
    {
        public int IdInventario { get; set; }
        public int IdProducto { get; set; }
        public int? Cantidad { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
    }
}
