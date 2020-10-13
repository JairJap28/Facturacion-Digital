namespace Base.Transversal.Acciones
{
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadRepositorio;
    using System.Threading.Tasks;
    public interface IClienteAccion
    {
        Task<Respuesta<IClienteDTO>> CrearCliente(IClienteDTO cliente);
        Task<Respuesta<IClienteDTO>> LeerCliente(IClienteDTO cliente);
        Task<Respuesta<IClienteDTO>> ActualizarCliente(IClienteDTO cliente);
        Task<Respuesta<IClienteDTO>> EliminarCliente(IClienteDTO cliente);
        Task<Respuesta<IClienteDTO>> LeerClientes();
    }
}
