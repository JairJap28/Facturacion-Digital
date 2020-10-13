namespace Base.Datos.Entidades.DAL
{
    using AutoMapper;
    using Base.Datos.Contexto;
    using Base.Transversal.Acciones;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadRepositorio;
    using Base.Transversal.Recursos;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class CategoriaDAL : ICategoriaAccion
    {
        private readonly ContextoFacturacion contexto;
        private readonly IMapper mapper;
        public CategoriaDAL(ContextoFacturacion contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        public async Task<Respuesta<ICategoriaDTO>> ActualizarCategoria(ICategoriaDTO categoria)
        {
            return await new Wrapper<ICategoriaDTO>().EjecutarTransaccionAsync(async () =>
            {
                contexto.Entry(mapper.Map<Categoria>(categoria)).State = EntityState.Modified;
                await contexto.SaveChangesAsync();
                return FabricaRespuesta<ICategoriaDTO>.RespuestaEdicionExitosa(new List<ICategoriaDTO> { categoria });
            }, async () => await FabricaRespuesta<ICategoriaDTO>.RespuestaFallida(Mensajes.ErrorEnEdición));
        }

        public async Task<Respuesta<ICategoriaDTO>> CrearCategoria(ICategoriaDTO categoria)
        {
            return await new Wrapper<ICategoriaDTO>().EjecutarTransaccionAsync(async () =>
            {
                Categoria nuevaCategoria = mapper.Map<Categoria>(categoria);
                contexto.Add(nuevaCategoria);
                await contexto.SaveChangesAsync();
                return FabricaRespuesta<ICategoriaDTO>.RespuestaCreacionExitosa(new List<ICategoriaDTO> { nuevaCategoria });
            }, async () => await FabricaRespuesta<ICategoriaDTO>.RespuestaFallida(Mensajes.ErrorEnCreacion));
        }

        public async Task<Respuesta<ICategoriaDTO>> EliminarCategoria(ICategoriaDTO categoria)
        {
            return await new Wrapper<ICategoriaDTO>().EjecutarTransaccionAsync(async () =>
            {
                int categoriaId = await contexto.Categoria.Select(cat => cat.IdCategoria)
                    .FirstOrDefaultAsync(x => x == categoria.IdCategoria);

                if (categoriaId == default) return FabricaRespuesta<ICategoriaDTO>.RespuestaEliminacionFallida();
                else
                {
                    contexto.Categoria.Remove(new Categoria { IdCategoria =  categoriaId});
                    await contexto.SaveChangesAsync();
                    return FabricaRespuesta<ICategoriaDTO>.RespuestaEliminacionExitosa();
                }
            }, async () => await FabricaRespuesta<ICategoriaDTO>.RespuestaFallida(Mensajes.ErrorEnEliminacion));
        }

        public async Task<Respuesta<ICategoriaDTO>> LeerCategoria(ICategoriaDTO categoriaIn)
        {
            return await new Wrapper<ICategoriaDTO>().EjecutarTransaccionAsync(async () =>
            {
                Categoria categoria = await contexto.Categoria
                    .FirstOrDefaultAsync(cat => cat.IdCategoria == categoriaIn.IdCategoria);

                if (categoria == null) return FabricaRespuesta<ICategoriaDTO>.RespuestaSinDatos();
                return FabricaRespuesta<ICategoriaDTO>.RespuestaConDatos(new List<ICategoriaDTO> { categoria });
            });
        }

        public async Task<Respuesta<ICategoriaDTO>> LeerCategorias()
        {
            return await new Wrapper<ICategoriaDTO>().EjecutarTransaccionAsync(async () =>
            {
                List<ICategoriaDTO> categorias = mapper.Map<List<ICategoriaDTO>>(await contexto.Categoria.ToListAsync());
                if (categorias != null && categorias.Count > 0) return FabricaRespuesta<ICategoriaDTO>.RespuestaConDatos(categorias);
                else return FabricaRespuesta<ICategoriaDTO>.RespuestaSinDatos();
            });
        }
    }
}
