import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'; 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule} from 'ngx-bootstrap/modal';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FilmesService } from './filmes.service';
import { FilmesComponent } from './components/filmes/filmes.component';
import { ClientesService } from './clientes.service';
import { ClientesComponent } from './components/clientes/clientes.component';
import { BebidasService } from './bebidas.service';
import { BebidasComponent } from './components/bebidas/bebidas.component';
import { DocesService } from './doces.service';
import { DocesComponent } from './components/doces/doces.component';
import { PipocasService } from './pipocas.service';
import { PipocasComponent } from './components/pipocas/pipocas.component';
import { SnacksService } from './snacks.service';
import { SnacksComponent } from './components/snacks/snacks.component';
import { SalasService } from './salas.service';
import { SalasComponent } from './components/salas/salas.component';
import { IngressosService } from './ingressos.service';
import { IngressosComponent } from './components/ingressos/ingressos.component';
import { FuncionariosComponent } from './components/funcionarios/funcionarios.component';

@NgModule({
  declarations: [
    AppComponent,
    FilmesComponent,
    ClientesComponent,
    BebidasComponent,
    DocesComponent,
    PipocasComponent,
    SnacksComponent,
    SalasComponent,
    IngressosComponent,
    FuncionariosComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [
  HttpClientModule, 
  FilmesService, 
  ClientesService,
  BebidasService,
  DocesService,
  PipocasService,
  SnacksService,
  SalasService,
  IngressosService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }