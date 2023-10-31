import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilmesComponent } from './components/filmes/filmes.component';
import { ClientesComponent } from './components/clientes/clientes.component';

const routes: Routes = [
  {path: 'filmes', component:FilmesComponent},
  {path: 'Clientes', component:ClientesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }