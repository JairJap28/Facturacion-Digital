import { DetalleFactura } from './DetalleFactura';
export interface Factura {
  idFactura: number,
  idCliente: number,
  nombreCliente: string,
  fecha: Date,
  cantidadProductos: number,
  valorTotal: number,
  listaDetalle: DetalleFactura[]
}
