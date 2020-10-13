namespace Base.Datos.Entidades.DO.Consultas
{
    using Base.Transversal.DTO.EntidadConsulta;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ProductoCompuestoDO : IProductoCompuestoDTO
    {
        public string Categoria { get; set; }
        public int IdProducto { get; set; }
        public int? IdCategoria { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int IdInventario { get; set; }
    }
}
