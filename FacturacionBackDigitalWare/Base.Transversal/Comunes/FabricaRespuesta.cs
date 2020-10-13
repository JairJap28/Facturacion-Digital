namespace Base.Transversal.Comunes
{
    using Base.Transversal.Recursos;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    public class FabricaRespuesta<T>
    {
        public static Task<Respuesta<T>> RespuestaFallida(string mensaje)
        {
            return Task.Run(() => new Respuesta<T>
                            {
                                Resultado = false,
                                Mensajes = new List<string> { mensaje }
                            });
        }

        public static Respuesta<T> RespuestaSinDatos()
        {
            return new Respuesta<T>
            {
                Resultado = true,
                Mensajes = new List<string> { Mensajes.RespuestaVacia },
                Entidades = new List<T>()
            };
        }

        public static Respuesta<T> RespuestaConDatos(List<T> entidades)
        {
            return new Respuesta<T>
            {
                Resultado = true,
                Mensajes = new List<string> { Mensajes.RespuestaConData },
                Entidades = entidades
            };
        }

        public static Respuesta<T> RespuestaCreacionExitosa(List<T> entidades)
        {
            return new Respuesta<T>
            {
                Resultado = true,
                Mensajes = new List<string> { Mensajes.CreacionExitosa },
                Entidades = entidades
            };
        }

        public static Respuesta<T> RespuestaEdicionExitosa(List<T> entidades)
        {
            return new Respuesta<T>
            {
                Resultado = true,
                Mensajes = new List<string> { Mensajes.EdicionExitosa },
                Entidades = entidades
            };
        }

        public static Respuesta<T> RespuestaEliminacionExitosa()
        {
            return new Respuesta<T>
            {
                Resultado = true,
                Mensajes = new List<string> { Mensajes.EliminacionExitosa },
                Entidades = new List<T>()
            };
        }

        public static Respuesta<T> RespuestaEliminacionFallida()
        {
            return new Respuesta<T>
            {
                Resultado = true,
                Mensajes = new List<string> { Mensajes.EliminacionFallida },
                Entidades = new List<T>()
            };
        }
    }
}
