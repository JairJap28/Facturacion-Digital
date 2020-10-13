import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

// Modules
import { DevextremeModule } from '../../shared/devextreme/devextreme.module';

// Components
import { FacturasComponent } from './facturas.component';

@NgModule({
  declarations: [FacturasComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    DevextremeModule
  ],
  bootstrap: [FacturasComponent]
})
export class FacturasModule { }
