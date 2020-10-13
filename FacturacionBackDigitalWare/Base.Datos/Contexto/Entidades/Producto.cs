namespace Base.Datos.Contexto
{
    using System.Collections.Generic;
    public partial class Producto
    {
        public Producto()
        {
            InventarioProducto = new HashSet<InventarioProducto>();
        }

        public int IdProducto { get; set; }
        public int? IdCategoria { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
        public virtual ICollection<InventarioProducto> InventarioProducto { get; set; }
    }
}
