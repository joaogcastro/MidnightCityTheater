import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { FilmesService } from 'src/app/filmes.service';
import { Filme } from 'src/app/Filme';

@Component({
  selector: 'app-filmes',
  templateUrl: './filmes.component.html',
  styleUrls: ['./filmes.component.css']
})

export class FilmesComponent implements OnInit {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  formulario: any;

  tamanhos = [
    { Tamanho: 'Pequeno' },
    { Tamanho: 'Medio' },
    { Tamanho: 'Grande' }
  ]

  constructor(private filmesService: FilmesService) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      idfilme: new FormControl(null),
      nomefilme: new FormControl(null),
      duracao: new FormControl(null),
      classificacao: new FormControl(null),
      diretor: new FormControl(null),
      categoria: new FormControl(null)
    });
  }

  cadastrar(): void {
    const filme: Filme = this.formulario.value;
    if (!filme.idfilme) {filme.idfilme=0}
    const observer: Observer<Filme> = {
      next(_result): void {
        alert('Filme cadastrado com sucesso.' + filme.idfilme + filme.nomefilme + filme.duracao + filme.classificacao + filme.diretor + filme.categoria);
      },
      error(error): void {
        alert('DEU ERRO CORNO.' + filme.idfilme + filme.nomefilme + filme.duracao + filme.classificacao + filme.diretor + filme.categoria);
        console.error(error);
        
        alert('Erro ao cadastrar!');
      },
      complete(): void {
      },
    };
    this.filmesService.cadastrar(filme).subscribe(observer);
  }

  alterar(): void {
    const filme: Filme = this.formulario.value;
    if (!filme.nomefilme) {filme.nomefilme = "string"}
    if (!filme.duracao) {filme.duracao = "string"}
    if (!filme.classificacao) {filme.classificacao = "string"}
    if (!filme.diretor) {filme.diretor = "string"}
    if (!filme.categoria) {filme.categoria = "string"}
  
    const observer: Observer<Filme> = {
      next(_result): void {
        alert('Filme alterado com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao alterar!');
      },
      complete(): void {},
    };
    this.filmesService.alterar(filme).subscribe(observer);
  }  

  excluir(): void {
    const filme: Filme = this.formulario.value;
    const observer: Observer<Filme> = {
      next(_result): void {
        alert('Filme excluído com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao excluir!');
      },
      complete(): void {
      },
    };
    this.filmesService.excluir(filme.idfilme).subscribe(observer);
  }

  reloadPage(): void {
    window.location.reload();
  }
}