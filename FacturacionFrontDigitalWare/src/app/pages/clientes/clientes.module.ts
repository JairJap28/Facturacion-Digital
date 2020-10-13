import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

// Modules
import { DevextremeModule } from '../../shared/devextreme/devextreme.module';

// Components
import { ClientesComponent } from './clientes.component';

@NgModule({
  declarations: [ClientesComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    DevextremeModule
  ],
  providers: [],
  bootstrap: [ClientesComponent]
})
export class ClientesModule { }
