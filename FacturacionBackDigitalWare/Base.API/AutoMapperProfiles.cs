namespace Base.API.Entidades
{
    using AutoMapper;
    using Base.API.Entidades.ProductoControl;
    using Base.Transversal.Comunes;
    using Base.Transversal.DTO.EntidadRepositorio;
    using Base.Datos.Contexto.Entidades;
    using Base.API.Entidades.ClienteControl;
    using Base.Datos.Contexto;
    using Base.Transversal.DTO.EntidadConsulta;
    using Base.Datos.Entidades.DO.Consultas;
    using Base.API.Entidades.FacturaControl;
    using Base.API.Entidades.CategoriaControl;
    using Base.API.Entidades.DetalleFactura;
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            AgregarPerfilesCliente();
            AgregarPerfilesProducto();
            AgregarPerfilesFactura();
            AgregarPerfilesCategoria();
            AgregarPerfilesDetalleFactura();
        }

        private void AgregarPerfilesCliente()
        {
            CreateMap<Respuesta<ClienteControlador>, Respuesta<IClienteDTO>>().ReverseMap();
            CreateMap<ClienteControlador, IClienteDTO>().ReverseMap();
            CreateMap<Cliente, IClienteDTO>().ReverseMap();
        }
        private void AgregarPerfilesProducto()
        {
            CreateMap<Respuesta<ProductoControlador>, Respuesta<IProductoDTO>>().ReverseMap();
            CreateMap<ProductoControlador, IProductoDTO>().ReverseMap();
            CreateMap<Producto, IProductoDTO>().ReverseMap();

            // Mapeador ProductoCompuesto
            CreateMap<Respuesta<ProductoCompuestoControlador>, Respuesta<IProductoCompuestoDTO>>().ReverseMap();
            CreateMap<ProductoCompuestoControlador, IProductoCompuestoDTO>().ReverseMap();
            CreateMap<ProductoCompuestoDO, IProductoCompuestoDTO>().ReverseMap();
        }
        private void AgregarPerfilesFactura()
        {
            CreateMap<Respuesta<FacturaControlador>, Respuesta<IFacturaDTO>>().ReverseMap();
            CreateMap<FacturaControlador, IFacturaDTO>().ReverseMap();
            CreateMap<Factura, IFacturaDTO>().ReverseMap();

            // Mapeador FacturaCompuesto
            CreateMap<Respuesta<FacturaCompuestaControl>, Respuesta<IFacturaCompuestaDTO>>().ReverseMap();
            CreateMap<FacturaCompuestaControl, IFacturaCompuestaDTO>().ReverseMap();
            CreateMap<FacturaCompuestaDO, IFacturaCompuestaDTO>().ReverseMap();

            // Mapeador FaturaDetalle
            CreateMap<DetalleFacturaCompuestoDO, IDetalleFacturaCompuestoDTO>().ReverseMap();
            CreateMap<DetalleFacturaCompuestoControlador, IDetalleFacturaCompuestoDTO>().ReverseMap();
        }
        private void AgregarPerfilesCategoria()
        {
            CreateMap<Respuesta<CategoriaControlador>, Respuesta<ICategoriaDTO>>().ReverseMap();
            CreateMap<CategoriaControlador, ICategoriaDTO>().ReverseMap();
            CreateMap<Categoria, ICategoriaDTO>().ReverseMap();
        }
        private void AgregarPerfilesDetalleFactura()
        {
            CreateMap<Respuesta<DetalleFacturaCompuestoControlador>, Respuesta<IDetalleFacturaCompuestoDTO>>().ReverseMap();
            CreateMap<DetalleFacturaCompuestoControlador, IDetalleFacturaCompuestoDTO>().ReverseMap();
            CreateMap<DetalleFacturaCompuestoDO, IDetalleFacturaCompuestoDTO>().ReverseMap();
        }
    }
}
