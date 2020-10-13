import { Component, OnInit, ViewChild } from '@angular/core';

// DevExtreme
import { DxDataGridComponent } from 'devextreme-angular';
import notify from 'devextreme/ui/notify';

import { Respuesta } from '../../core/models/Respuesta/Respuesta';
import { Cliente } from './models/Cliente';
import { ClienteService } from './service/cliente.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {
  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent;
  showHeaderFilter: boolean = true;
  showFilterRow: boolean = true;
  loadingVisible = true;


  respuestaCliente: Cliente[] = [];

  constructor(private clienteService: ClienteService) { }

  ngOnInit() {
    this.clienteService.getClients()
      .subscribe((data: Respuesta<Cliente>) => {
        this.respuestaCliente = data.entidades;
        this.loadingVisible = false;
      }, () => notify({ message: "Ha ocurrido un error al realizar la petición"}, "error"));
  }

  onRowUpdated(event) {
    this.clienteService.updateClient(event.data)
      .subscribe((data: Respuesta<Cliente>) => {
        notify({ message: data.mensajes[0], width: 500 },data.resultado ? "success": "error");
      }, () => notify({ message: "Ha ocurrido un error al realizar la petición"}, "error"))
  }

  onRowInserted(event) {
    const indexCliente = this.respuestaCliente.findIndex(cliente => cliente.cedula == event.data.cedula);
    this.clienteService.addClient(event.data)
      .subscribe((data: Respuesta<Cliente>) => {
        this.respuestaCliente[indexCliente] = data.entidades[0];
        notify({ message: data.mensajes[0], width: 500 },data.resultado ? "success": "error");
      }, () => notify({ message: "Ha ocurrido un error al realizar la petición"}, "error"));
  }

  onRowRemoved(event) {
    const cliente = event.data;
    this.clienteService.deleteClient(event.data)
      .subscribe((data: Respuesta<Cliente>) => {
        if(!data.resultado) this.respuestaCliente.push(cliente);
        notify({ message: data.mensajes[0], width: 500 },data.resultado ? "success": "error");
      }, () => notify({ message: "Ha ocurrido un error al realizar la petición"}, "error"));
  }
}
