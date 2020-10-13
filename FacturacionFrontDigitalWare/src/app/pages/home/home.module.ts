import { CommonModule } from '@angular/common';
import { NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// Modules
import { DevextremeModule } from '../../shared/devextreme/devextreme.module';

// Components
import { HomeComponent } from './home.component';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    DevextremeModule
  ],
  bootstrap: [HomeComponent]
})
export class HomeModule { }
