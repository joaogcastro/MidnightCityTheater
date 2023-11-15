import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { FilmesService } from 'src/app/filmes.service';
import { SalasService } from 'src/app/salas.service';
import { Filme } from 'src/app/Filme';
import { Title } from '@angular/platform-browser';
import { Sala } from 'src/app/Sala';

@Component({
  selector: 'app-filmes',
  templateUrl: './filmes.component.html',
  styleUrls: ['./filmes.component.css']
})

export class FilmesComponent implements OnInit {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  formulario: any;
  formularioBuscar: any;
  filmes: Filme[] = [];
  ListSalas: Array<Sala> | undefined;
  nomeFilmeEncontrado: Filme | null = null;

  constructor(private filmesService: FilmesService, private titleService: Title, private salasService : SalasService) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      idFilme: new FormControl(null),
      nomeFilme: new FormControl(null),
      duracao: new FormControl(null),
      classificacao: new FormControl(null),
      diretor: new FormControl(null),
      categoria: new FormControl(null),
      idSala: new FormControl(null), // Adicione esta linha
    });
    this.listar();
    this.salasService.listar().subscribe(salas => {
      this.ListSalas = salas;
      if (this.ListSalas && this.ListSalas.length > 0) {
        this.formulario.get('idSala')?.setValue(this.ListSalas[0].idSala);
      }
    });
    this.formularioBuscar = new FormGroup({
      idfilme: new FormControl(null)
    });
    this.titleService.setTitle('Filme MidnightCity');

  }

  cadastrar(): void {
    const filme: Filme = this.formulario.value;
    if (!filme.idFilme) {
      filme.idFilme = 0;
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

  listar(): void {
    this.filmesService.listar().subscribe(
      (filmes: Filme[]) => {
        this.filmes = filmes.map(filme => {
          // Verificar se idSala é null antes de procurar a sala correspondente
          if (filme.idSala !== null && filme.idSala !== undefined) {
            const salaEncontrada = this.ListSalas?.find(sala => sala.idSala === filme.idSala);
            // Certificar-se de que a propriedade 'sala' esteja sendo preenchida
            return {
              ...filme,
              sala: salaEncontrada ?? null,
            } as Filme; // Assegurar que o tipo seja Filme
          } else {
            // Se idSala for null, manter a propriedade 'sala' como null
            return {
              ...filme,
              sala: null,
            } as Filme; // Assegurar que o tipo seja Filme
          }
        });
      },
      (error) => {
        console.error(error);
        alert('Erro ao listar filmes!');
      }
    );
  }

  buscar(): void {
    const idFilme: number = this.formularioBuscar.get('idfilme')?.value;
  
    if (idFilme) {
      this.filmesService.buscar(idFilme).subscribe(
        (filme: Filme) => {
          // Verificar se idSala é null antes de procurar a sala correspondente
          if (filme.idSala !== null && filme.idSala !== undefined) {
            const salaEncontrada = this.ListSalas?.find(sala => sala.idSala === filme.idSala);
            // Certificar-se de que a propriedade 'sala' esteja sendo preenchida
            this.nomeFilmeEncontrado = {
              ...filme,
              sala: salaEncontrada ?? null,
            } as Filme; // Assegurar que o tipo seja Filme
          } else {
            // Se idSala for null, manter a propriedade 'sala' como null
            this.nomeFilmeEncontrado = {
              ...filme,
              sala: null,
            } as Filme; // Assegurar que o tipo seja Filme
          }
        },
        (error) => {
          console.error(error);
          alert('Erro ao buscar filme por ID!');
        }
      );
    } else {
      alert('Por favor, insira um ID válido para buscar.');
    }
  }

  alterar(): void {
    const filme: Filme = this.formulario.value;
  
    // Se o valor da sala selecionada não for nulo, atribua ao filme
    const idSalaSelecionada: number | null = this.formulario.get('idSala')?.value;
    if (idSalaSelecionada !== null) {
      filme.idSala = idSalaSelecionada;
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
    const idFilme: number = this.formulario.get('idFilme').value;

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