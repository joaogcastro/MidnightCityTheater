import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { FilmesService } from 'src/app/filmes.service';
import { Filme } from 'src/app/Filme';
import { SalasService } from 'src/app/salas.service';
import { Sala } from 'src/app/Sala';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-filmes',
  templateUrl: './filmes.component.html',
  styleUrls: ['./filmes.component.css']
})
export class FilmesComponent implements OnInit {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  formulario: FormGroup;
  tituloFormulario: string = 'Novo Filme';
  salas: Sala[] = []; // Adicione o atributo para armazenar a lista de salas
  constructor(private filmesService: FilmesService, private salasService: SalasService) {
    this.formulario = new FormGroup({
      idfilme: new FormControl(null),
      categoria: new FormControl(null),
      nomefilme: new FormControl(null),
      classificacao: new FormControl(null),
      diretor: new FormControl(null),
      duracao: new FormControl(null),
      salaId: new FormControl(null) // Adicione o campo para a seleção da sala
    });
  }
  ngOnInit(): void {
    // Carregue a lista de salas ao inicializar o componente
    this.salasService.listar().subscribe((result: Sala[]) => {
      this.salas = result;
    });
  }
  cadastrar(): void {
    const filme: Filme = this.formulario.value;
    if (!filme.idfilme) {
      filme.idfilme = 0;
    }
  
    const observer: Observer<Filme> = {
      next(_result): void {
        alert('Filme cadastrado com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao cadastrar!');
      },
      complete(): void {},
    };
  
    this.filmesService.cadastrar(filme).subscribe(observer);
  }

  alterar(): void {
    const filme: Filme = this.formulario.value;
    if (!filme.categoria) {
      filme.categoria = 'string';
    }
    if (!filme.nomefilme) {
      filme.nomefilme = 'string';
    }
    if (!filme.classificacao) {
      filme.classificacao = 'string';
    }
    if (!filme.diretor) {
      filme.diretor = 'string';
    }
    if (!filme.duracao) {
      filme.duracao = 'string';
    }

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
    this.filmesService.excluir(filme.nomefilme).subscribe(observer);
  }

  reloadPage(): void {
    window.location.reload();

    
  }
}