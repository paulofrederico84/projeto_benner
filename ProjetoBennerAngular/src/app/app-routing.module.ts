import { TabelaPrecosComponent } from './tabelaPrecos/tabelaPrecos.component';
import { EstacionamentosComponent } from './estacionamentos/estacionamentos.component';
import { VeiculosComponent } from './veiculos/veiculos.component';
import { PerfilComponent } from './perfil/perfil.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard' , pathMatch: 'full'},
  { path: 'dashboard' , component: DashboardComponent},
  { path: 'veiculos' , component: VeiculosComponent},
  { path: 'estacionamentos' , component: EstacionamentosComponent},
  { path: 'tabelaPrecos' , component: TabelaPrecosComponent},
  { path: 'perfil' , component: PerfilComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
