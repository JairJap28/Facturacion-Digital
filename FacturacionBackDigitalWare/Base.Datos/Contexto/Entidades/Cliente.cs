namespace Base.Datos.Contexto.Entidades
{
    using System;
    using System.Collections.Generic;
    public partial class Cliente
    {
        public Cliente()
        {
            Factura = new HashSet<Factura>();
        }

        public int IdCliente { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Cedula { get; set; }

        public virtual ICollection<Factura> Factura { get; set; }
    }
}
