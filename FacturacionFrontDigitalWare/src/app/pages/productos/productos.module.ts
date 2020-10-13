import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

// Modules
import { DevextremeModule } from '../../shared/devextreme/devextreme.module';

// Components
import { ProductosComponent } from './productos.component';

@NgModule({
  declarations: [ProductosComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    DevextremeModule
  ],
  bootstrap: [ProductosComponent]
})
export class ProductosModule { }
