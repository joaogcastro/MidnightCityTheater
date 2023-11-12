import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilmesComponent } from './components/filmes/filmes.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { BebidasComponent } from './components/bebidas/bebidas.component';
import { DocesComponent } from './components/doces/doces.component';
import { PipocasComponent } from './components/pipocas/pipocas.component';
import { SnacksComponent } from './components/snacks/snacks.component';
import { SalasComponent } from './components/salas/salas.component';
import { IngressosComponent } from './components/ingressos/ingressos.component';
import { FuncionariosComponent } from './components/funcionarios/funcionarios.component';

const routes: Routes = [
  {path: 'filmes', component:FilmesComponent},
  {path: 'Funcionario', component:FuncionariosComponent},
  {path: 'Clientes', component:ClientesComponent},
  {path: 'Bebidas', component: BebidasComponent},
  {path: 'Doces', component: DocesComponent},
  {path: 'Pipocas', component: PipocasComponent},
  {path: 'Snacks', component: SnacksComponent},
  {path: 'Salas', component: SalasComponent},
  {path: 'Ingressos', component: IngressosComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }