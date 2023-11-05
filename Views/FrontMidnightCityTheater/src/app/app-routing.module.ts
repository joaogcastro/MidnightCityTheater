import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilmesComponent } from './components/filmes/filmes.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { BebidasComponent } from './components/bebidas/bebidas.component';
import { DocesComponent } from './components/doces/doces.component';
import { PipocasComponent } from './components/pipocas/pipocas.component';
import { SnacksComponent } from './components/snacks/snacks.component';

const routes: Routes = [
  {path: 'filmes', component:FilmesComponent},
  {path: 'Clientes', component:ClientesComponent},
  {path: 'Bebidas', component: BebidasComponent},
  {path: 'Doces', component: DocesComponent},
  {path: 'Pipocas', component: PipocasComponent},
  {path: 'Snacks', component: SnacksComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }