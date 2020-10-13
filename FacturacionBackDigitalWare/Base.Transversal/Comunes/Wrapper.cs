namespace Base.Transversal.Comunes
{
    using Base.Transversal.Recursos;
    using System;
    using System.Threading.Tasks;
    public class Wrapper<T>
    {
        public async Task<Respuesta<T>> EjecutarTransaccionAsync(Func<Task<Respuesta<T>>> ejecutar)
        {
            return await EjecutarTransaccionAsync(ejecutar, null);
        }
        public async Task<Respuesta<T>> EjecutarTransaccionAsync(Func<Task<Respuesta<T>>> ejecutar, Func<Task<Respuesta<T>>> hacerEnError)
        {
            try
            {
                return await ejecutar();
            }
            catch (Exception e)
            {
                /* Se podría crear auditoria en caso de fallo */
                if(hacerEnError == null)
                {
                    return await FabricaRespuesta<T>.RespuestaFallida(Mensajes.RespuestaFallida);
                }
                return await hacerEnError();
            }
        }
    }
}
