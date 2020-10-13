namespace Base.API.Controllers
{
    using AutoMapper;
    using Base.API.Entidades.ClienteControl;
    using Base.Negocio.BL;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadRepositorio;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;


    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController
    {
        private readonly ClienteBL clienteBL;
        private readonly IMapper mapper;

        public ClienteController(ClienteBL clienteBL, IMapper mapper)
        {
            this.clienteBL = clienteBL;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("ConsultarCliente")]
        public async Task<Respuesta<ClienteControlador>> ConsultarCliente(int cedulaCliente)
        {
            return mapper.Map<Respuesta<ClienteControlador>>(await clienteBL.LeerCliente(mapper.Map<IClienteDTO>(new ClienteControlador { Cedula = cedulaCliente })));
        }

        [HttpGet]
        [Route("ConsultarClientes")]
        public async Task<Respuesta<ClienteControlador>> ConsultarClientes()
        {
            return mapper.Map<Respuesta<ClienteControlador>>(await clienteBL.LeerClientes());
        }

        [HttpPost]
        [Route("CrearCliente")]
        public async Task<Respuesta<ClienteControlador>> CrearCliente(ClienteControlador cliente)
        {
            return mapper.Map<Respuesta<ClienteControlador>>(await clienteBL.CrearCliente(mapper.Map<IClienteDTO>(cliente)));
        }

        [HttpPut]
        [Route("ActualizarCliente")]
        public async Task<Respuesta<ClienteControlador>> ActualizarCliente(ClienteControlador cliente)
        {
            return mapper.Map<Respuesta<ClienteControlador>>(await clienteBL.ActualizarCliente(mapper.Map<IClienteDTO>(cliente)));
        }

        [HttpDelete]
        [Route("EliminarCliente")]
        public async Task<Respuesta<ClienteControlador>> EliminarCliente(int idCliente)
        {
            return mapper.Map<Respuesta<ClienteControlador>>(
                await clienteBL.EliminarCliente(mapper.Map<IClienteDTO>(new ClienteControlador() {
                    IdCliente = idCliente 
                    }))
                );
        }
    }
}
