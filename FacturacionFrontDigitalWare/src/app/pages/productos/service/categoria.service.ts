import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

// Models
import { Respuesta } from '../../../core/models/Respuesta/Respuesta';
import { Categoria } from '../models/Categoria';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

  constructor(private _httpCliente: HttpClient) { }

  getCategories(): Observable<Respuesta<Categoria>> {
    return this._httpCliente.get<Respuesta<Categoria>>(`${environment.apiUrlBase}${environment.apiUrlConsultarCategorias}`);
  }
}
