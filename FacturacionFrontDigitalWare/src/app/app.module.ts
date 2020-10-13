import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DevextremeModule } from './shared/devextreme/devextreme.module';

// Modules
import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from './core/core.module';
import { HomeModule } from './pages/home/home.module';
import { ClientesModule } from './pages/clientes/clientes.module';
import { FacturasModule } from './pages/facturas/facturas.module';
import { ProductosModule } from './pages/productos/productos.module';

// Components
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    CoreModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    DevextremeModule,
    HomeModule,
    ClientesModule,
    FacturasModule,
    ProductosModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
