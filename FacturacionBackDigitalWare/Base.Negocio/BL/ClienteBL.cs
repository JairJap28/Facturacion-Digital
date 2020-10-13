namespace Base.Negocio.BL
{
    using Base.Datos.DAL;
    using Base.Transversal.Acciones;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadRepositorio;
    using System.Threading.Tasks;
    public class ClienteBL : IClienteAccion
    {
        private readonly ClienteDAL clienteDAL;

        public ClienteBL(ClienteDAL clienteDAL)
        {
            this.clienteDAL = clienteDAL;
        }

        public async Task<Respuesta<IClienteDTO>> ActualizarCliente(IClienteDTO cliente)
        {
            return await clienteDAL.ActualizarCliente(cliente);
        }

        public async Task<Respuesta<IClienteDTO>> CrearCliente(IClienteDTO cliente)
        {
            return await clienteDAL.CrearCliente(cliente);
        }

        public async Task<Respuesta<IClienteDTO>> EliminarCliente(IClienteDTO cliente)
        {
            return await clienteDAL.EliminarCliente(cliente);
        }

        public async Task<Respuesta<IClienteDTO>> LeerCliente(IClienteDTO cliente)
        {
            return await clienteDAL.LeerCliente(cliente);
        }

        public async Task<Respuesta<IClienteDTO>> LeerClientes()
        {
            return await clienteDAL.LeerClientes();
        }
    }
}
