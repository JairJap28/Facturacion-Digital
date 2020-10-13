namespace Base.Datos.DAL
{
    using AutoMapper;
    using Base.Datos.Contexto;
    using Base.Datos.Contexto.Entidades;
    using Base.Transversal.Acciones;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadRepositorio;
    using Base.Transversal.Recursos;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class ClienteDAL : IClienteAccion
    {
        private readonly ContextoFacturacion contexto;
        private readonly IMapper mapper;

        public ClienteDAL(ContextoFacturacion contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        public async Task<Respuesta<IClienteDTO>> ActualizarCliente(IClienteDTO cliente)
        {
            return await new Wrapper<IClienteDTO>().EjecutarTransaccionAsync(async () =>
            {
                contexto.Entry(mapper.Map<Cliente>(cliente)).State = EntityState.Modified;
                await contexto.SaveChangesAsync();
                return FabricaRespuesta<IClienteDTO>.RespuestaEdicionExitosa(new List<IClienteDTO> { cliente });
            }, async () => await FabricaRespuesta<IClienteDTO>.RespuestaFallida(Mensajes.ErrorEnEdición));
        }

        public async Task<Respuesta<IClienteDTO>> CrearCliente(IClienteDTO cliente)
        {
            return await new Wrapper<IClienteDTO>().EjecutarTransaccionAsync(async () =>
            {
                Cliente nuevoCliente = mapper.Map<Cliente>(cliente);
                contexto.Add(nuevoCliente);
                await contexto.SaveChangesAsync();
                return FabricaRespuesta<IClienteDTO>.RespuestaCreacionExitosa(new List<IClienteDTO> { nuevoCliente });
            }, async () => await FabricaRespuesta<IClienteDTO>.RespuestaFallida(Mensajes.ErrorEnCreacion));
        }

        public async Task<Respuesta<IClienteDTO>> EliminarCliente(IClienteDTO cliente)
        {
            return await new Wrapper<IClienteDTO>().EjecutarTransaccionAsync(async () =>
            {
                int clienteId = await contexto.Cliente
                    .Select(Cli => Cli.IdCliente)
                    .FirstOrDefaultAsync(x => x == cliente.IdCliente);

                if (clienteId == default) return FabricaRespuesta<IClienteDTO>.RespuestaEliminacionFallida();
                else
                {
                    List<Factura> facturasCliente = await contexto.Factura
                    .Include(fac => fac.DetalleFactura)
                    .Where(cli => cli.IdCliente == cliente.IdCliente)
                    .ToListAsync();

                    foreach (Factura factura in facturasCliente)
                    {
                        contexto.RemoveRange(factura.DetalleFactura);
                        await contexto.SaveChangesAsync();
                    }

                    contexto.RemoveRange(facturasCliente);
                    await contexto.SaveChangesAsync();

                    contexto.Cliente.Remove(new Cliente { IdCliente = clienteId });
                    await contexto.SaveChangesAsync();
                    return FabricaRespuesta<IClienteDTO>.RespuestaEliminacionExitosa();
                }
            }, async () => await FabricaRespuesta<IClienteDTO>.RespuestaFallida(Mensajes.ErrorEnEliminacion));
        }

        public async Task<Respuesta<IClienteDTO>> LeerCliente(IClienteDTO clienteIn)
        {
            return await new Wrapper<IClienteDTO>().EjecutarTransaccionAsync(async () =>
            {
                Cliente cliente = await contexto.Cliente.FirstOrDefaultAsync(cli => cli.Cedula == clienteIn.Cedula);
                if (cliente == null) return FabricaRespuesta<IClienteDTO>.RespuestaSinDatos();
                return FabricaRespuesta<IClienteDTO>.RespuestaConDatos(new List<IClienteDTO> { clienteIn });
            });
        }

        public async Task<Respuesta<IClienteDTO>> LeerClientes()
        {
            return await new Wrapper<IClienteDTO>().EjecutarTransaccionAsync(async () =>
            {
                List<IClienteDTO> clientes = mapper.Map<List<IClienteDTO>>(await contexto.Cliente.ToListAsync());
                if (clientes != null && clientes.Count > 0) return FabricaRespuesta<IClienteDTO>.RespuestaConDatos(clientes);
                else return FabricaRespuesta<IClienteDTO>.RespuestaSinDatos();
            });
        }
    }
}
