namespace Base.Negocio.BO
{
    using Base.Transversal.DTO.EntidadRepositorio;
    using System;
    public class ClienteBO : IClienteDTO
    {
        public int IdCliente { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Cedula { get; set; }
    }
}
