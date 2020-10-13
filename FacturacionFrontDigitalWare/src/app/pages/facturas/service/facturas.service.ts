import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

// Models
import { Respuesta } from '../../../core/models/Respuesta/Respuesta';
import { Factura } from '../models/Factura';
import { DetalleFactura } from '../models/DetalleFactura';

@Injectable({
  providedIn: 'root'
})
export class FacturasService {

  constructor(private _httpClient: HttpClient) { }

  getFacturas(): Observable<Respuesta<Factura>> {
    return this._httpClient.get<Respuesta<Factura>>(`${environment.apiUrlBase}${environment.apiUrlConsultarFacturas}`);
  }

  getDetalleFactura(idFactura: number): Observable<Respuesta<DetalleFactura>> {
    return this._httpClient.get<Respuesta<DetalleFactura>>(`${environment.apiUrlBase}${environment.apiUrlConsultarDetalleFactura}${idFactura}`);
  }

  updateDetalleFactura(detalle: DetalleFactura): Observable<Respuesta<DetalleFactura>> {
    return this._httpClient.put<Respuesta<DetalleFactura>>(`${environment.apiUrlBase}${environment.apiUrlEditarDetalleFactura}`, detalle);
  }
}
