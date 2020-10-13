namespace Base.Transversal.DTO.EntidadRepositorio
{
    using System;
    public interface IClienteDTO
    {
        int IdCliente { get; set; }
        string PrimerNombre { get; set; }
        string SegundoNombre { get; set; }
        string PrimerApellido { get; set; }
        string SegundoApellido { get; set; }
        DateTime? FechaNacimiento { get; set; }
        int Cedula { get; set; }
    }
}
