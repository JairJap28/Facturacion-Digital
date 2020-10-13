import { NgModule } from '@angular/core';
import { Routes, RouterModule  } from '@angular/router';

// Modules
import { CoreModule } from './core/core.module';

// Component
import { HomeComponent } from './pages/home/home.component';
import { ClientesComponent } from './pages/clientes/clientes.component';
import { ProductosComponent } from './pages/productos/productos.component';
import { FacturasComponent } from './pages/facturas/facturas.component';

const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'clientes', component: ClientesComponent},
  {path: 'facturas', component: FacturasComponent },
  {path: 'productos', component: ProductosComponent},
  {path: '**', pathMatch: 'full', redirectTo: 'home'}
];

@NgModule({
  declarations: [],
  imports: [
    CoreModule,
    RouterModule.forRoot(routes)
  ],
  providers: [CoreModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
