import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Respuesta } from '../../../core/models/Respuesta/Respuesta';
import { Cliente } from '../models/Cliente';
import { header } from '../../../core/utils/Configuracion/configuracion';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  constructor(private _httpCliente: HttpClient) { }

  getClients(): Observable<any> {
    return this._httpCliente.get(`${environment.apiUrlBase}${environment.apiUrlConsultarClientes}`);
  }

  updateClient(cliente: Cliente): Observable<Respuesta<Cliente>> {
    return this._httpCliente.put<Respuesta<Cliente>>(`${environment.apiUrlBase}${environment.apiUrlEditarCliente}`, cliente);
  }

  addClient(cliente: Cliente): Observable<Respuesta<Cliente>> {
    return this._httpCliente.post<Respuesta<Cliente>>(`${environment.apiUrlBase}${environment.apiUrlCrearCliente}`, cliente);
  }

  deleteClient(cliente: Cliente): Observable<Respuesta<Cliente>> {
    return this._httpCliente.delete<Respuesta<Cliente>>(`${environment.apiUrlBase}${environment.apiUrlEliminarCliente}?idCliente=${cliente.idCliente}`);
  }
}
