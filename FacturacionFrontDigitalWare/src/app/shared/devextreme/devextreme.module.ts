import { NgModule } from '@angular/core';
import {
  DxPopupModule,
  DxFormModule,
  DxTextBoxModule,
  DxSelectBoxModule,
  DxResponsiveBoxModule,
  DxButtonModule,
  DxDataGridModule,
  DxTemplateModule,
  DxLoadPanelModule
} from 'devextreme-angular';



@NgModule({
  declarations: [],
  imports: [
    DxPopupModule,
    DxDataGridModule,
    DxFormModule,
    DxButtonModule,
    DxTextBoxModule,
    DxSelectBoxModule,
    DxResponsiveBoxModule,
    DxButtonModule,
    DxDataGridModule,
    DxTemplateModule,
    DxLoadPanelModule
  ],
  exports: [
    DxPopupModule,
    DxDataGridModule,
    DxFormModule,
    DxButtonModule,
    DxTextBoxModule,
    DxSelectBoxModule,
    DxResponsiveBoxModule,
    DxButtonModule,
    DxDataGridModule,
    DxTemplateModule,
    DxLoadPanelModule
  ]
})
export class DevextremeModule { }
