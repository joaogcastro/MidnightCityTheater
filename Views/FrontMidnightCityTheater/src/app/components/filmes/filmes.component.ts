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
  filmes: Filme[] = [];
  nomeFilmeEncontrado: string = '';

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
    this.listar();

  }

  cadastrar(): void {
    const filme: Filme = this.formulario.value;
    if (!filme.idFilme) {filme.idFilme=0}
    const observer: Observer<Filme> = {
      next(_result): void {
        alert('Filme cadastrado com sucesso.' + filme.idFilme + filme.nomeFilme + filme.duracao + filme.classificacao + filme.diretor + filme.categoria);
      },
      error(error): void {
        alert('Erro de cadastro.' + filme.idFilme + filme.nomeFilme + filme.duracao + filme.classificacao + filme.diretor + filme.categoria);
        console.error(error);
        
        alert('Erro ao cadastrar!');
      },
      complete(): void {
      },
    };
    this.filmesService.cadastrar(filme).subscribe(observer);
  }

  listar(): void {
    this.filmesService.listar().subscribe(
      (filmes: Filme[]) => {
        this.filmes = filmes;
        console.log(filmes);
      },
      (error) => {
        console.error(error);
        alert('Erro ao carregar a lista de filmes!');
      }
    );
  }

  buscar(): void {
    const idFilme: number = this.formulario.get('idfilme').value;

    if (idFilme) {
      this.filmesService.buscar(idFilme).subscribe(
        (filmeEncontrado: Filme) => {
          if (filmeEncontrado) {
            this.formulario.patchValue(filmeEncontrado);
            this.nomeFilmeEncontrado = filmeEncontrado.nomeFilme;
            alert('Filme encontrado: ' + this.nomeFilmeEncontrado);
          } else {
            this.nomeFilmeEncontrado = '';
            alert('Filme não encontrado.');
          }
        },
        (error) => {
          console.error(error);
          alert('Erro ao buscar filme!');
        }
      );
    } else {
      this.nomeFilmeEncontrado = '';
      alert('Por favor, insira um ID válido para buscar.');
    }
  }

  alterar(): void {
    const filme: Filme = this.formulario.value;
    if (!filme.nomeFilme) {filme.nomeFilme = "string"}
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
    const idFilme: number = this.formulario.get('idfilme').value;
  
    if (idFilme) {
      if (confirm('Tem certeza que deseja excluir o filme?')) {
        this.filmesService.excluir(idFilme).subscribe(
          () => {
            alert('Filme excluído com sucesso.');
            this.reloadPage();
          },
          (error) => {
            console.error(error);
            alert('Erro ao excluir filme!');
          }
        );
      }
    } else {
      alert('Por favor, insira um ID válido para excluir.');
    }
  }

  reloadPage(): void {
    window.location.reload();
  }
}