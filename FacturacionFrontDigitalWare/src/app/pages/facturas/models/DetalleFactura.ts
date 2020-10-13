export interface DetalleFactura {
  idDetalleFactura: number,
  idFactura: number,
  idProducto: number,
  nombreProducto: string,
  precio: number,
  observaciones: string
}
