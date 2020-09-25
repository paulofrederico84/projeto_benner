import { TabelaPrecosComponent } from './tabelaPrecos/tabelaPrecos.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './Nav/Nav.component';
import { PerfilComponent } from './perfil/perfil.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { TituloComponent } from './titulo/titulo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { HttpClientModule } from '@angular/common/http';
import { VeiculosComponent } from './veiculos/veiculos.component';
import { EstacionamentosComponent } from './estacionamentos/estacionamentos.component';


@NgModule({
  declarations: [
    AppComponent,
      EstacionamentosComponent,
      VeiculosComponent,
      NavComponent,
      PerfilComponent,
      DashboardComponent,
      TituloComponent,
      TabelaPrecosComponent

   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
