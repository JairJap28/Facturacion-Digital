import { Component, OnInit, ViewChild } from '@angular/core';

// Services
import { FacturasService } from './service/facturas.service';

// Models
import { Factura } from './models/Factura';
import { Respuesta } from '../../core/models/Respuesta/Respuesta';

// DevExtreme
import { DxDataGridComponent } from 'devextreme-angular';
import notify from 'devextreme/ui/notify';
import { DetalleFactura } from './models/DetalleFactura';

@Component({
  selector: 'app-facturas',
  templateUrl: './facturas.component.html',
  styleUrls: ['./facturas.component.css']
})
export class FacturasComponent implements OnInit {
  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent;
  showHeaderFilter: boolean = true;
  showFilterRow: boolean = true;
  allMode: string;
  checkBoxesMode: string;
  loadingVisible = true;

  facturas: Factura[] = [];

  constructor(private facturaService: FacturasService) {
    this.getFacturas();
  }

  ngOnInit(): void {
  }

  getFacturas() {
    this.facturaService.getFacturas()
      .subscribe((data: Respuesta<Factura>) => {
        this.facturas = data.entidades;
        this.loadingVisible = false;
      },  () => notify({ message: "Ha ocurrido un error al consultar las facturas"}, "error"));
  }

  onRowUpdated(event) {
    this.facturaService.updateDetalleFactura(event.data)
      .subscribe((data: Respuesta<DetalleFactura>) => {
        notify({ message: data.mensajes[0], width: 500 },data.resultado ? "success": "error");
      }, () => notify({ message: "Ha ocurrido un error al actualizar el detalle"}, "error"));
  }
}
