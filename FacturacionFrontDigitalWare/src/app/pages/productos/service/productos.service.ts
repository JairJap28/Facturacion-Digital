import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

// Models
import { Respuesta } from '../../../core/models/Respuesta/Respuesta';
import { Producto } from '../models/Producto';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

  constructor(private _httpCliente: HttpClient) { }

  getProducts(): Observable<Respuesta<Producto>> {
    return this._httpCliente.get<Respuesta<Producto>>(`${environment.apiUrlBase}${environment.apiUrlConsultarProductos}`);
  }

  addProduct(producto: Producto): Observable<Respuesta<Producto>> {
    return this._httpCliente.post<Respuesta<Producto>>(`${environment.apiUrlBase}${environment.apiUrlCrearProducto}`, producto);
  }

  updateProduct(producto: Producto): Observable<Respuesta<Producto>> {
    return this._httpCliente.put<Respuesta<Producto>>(`${environment.apiUrlBase}${environment.apiUrlEditarProducto}`, producto);
  }
}
