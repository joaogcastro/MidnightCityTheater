import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Observer } from 'rxjs';
import { Ingresso } from 'src/app/Ingresso';
import { IngressosService } from 'src/app/ingressos.service';
import { Sala } from 'src/app/Sala';
import { SalasService } from 'src/app/salas.service';
import { Filme } from 'src/app/Filme';
import { FilmesService } from 'src/app/filmes.service';

@Component({
  selector: 'app-ingressos',
  templateUrl: './ingressos.component.html',
  styleUrls: ['./ingressos.component.css']
})
export class IngressosComponent implements OnInit {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  formulario: any;
  formularioBuscar: any;
  ListSalas: Sala[] = [];
  ListIngressos: Ingresso[] = [];
  ListFilmes: Filme[] = [];
  nomeIngressoEncontrado: Sala | null = null;

  constructor(private ingressosService: IngressosService, private titleService: Title) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      idIngresso: new FormControl(null),
      tipoIngresso: new FormControl(null),
      precoIng: new FormControl(null),
      idSala: new FormControl(null),
      idFilme: new FormControl(null)
    });
    this.listar();
    this.formularioBuscar = new FormGroup({
      idIngresso: new FormControl(null),
    });
    this.titleService.setTitle('Ingressos MidnightCity');
  }

  cadastrar(): void {
    const ingresso: Ingresso = this.formulario.value;
    if (!ingresso.idIngresso) {
      ingresso.idIngresso = 0;
    }
    const observer: Observer<Sala> = {
      next(_result): void {
        alert('Ingresso cadastrado com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro de cadastro, verifique se todos os campos foram preenchidos corretamente.');
      },
      complete(): void {},
    };
    this.ingressosService.cadastrar(ingresso).subscribe(observer);
  }

  listar(): void {
    this.ingressosService.listar().subscribe(
      (ingressos: Ingresso[]) => {
        this.ListIngressos = ingressos;
      },
      (error) => {
        console.error(error);
        alert('Erro ao carregar a lista de ingressos!');
      }
    );
  }

  buscar(): void {
    const idIngresso: number = this.formularioBuscar.get('idIngresso').value;
    
    if (idIngresso) {
      this.ingressosService.buscar(idIngresso).subscribe(
        (ingressoEncontrado: any) => {
          console.log(ingressoEncontrado);
          this.formularioBuscar.get('idIngresso')?.setValue(ingressoEncontrado.idSala);
          this.nomeIngressoEncontrado = ingressoEncontrado;    
        },
        (error) => {
          console.error(error);
          alert('Erro ao buscar ingresso!');
        }
      );
    } else {
      alert('Por favor, insira um ID válido para buscar.');
    }
  }

  alterar(): void {
    const ingresso: Ingresso = this.formulario.value;
    if (ingresso.idIngresso === null) {
      alert('Por favor, busque um ingresso antes de tentar alterar.');
      return;
    }
    if (!ingresso.tipoIngresso) {
      ingresso.tipoIngresso = 'string';
    }
    if (!ingresso.precoIng || isNaN(ingresso.precoIng)) { ingresso.precoIng = 0; }
  
    const observer: Observer<Ingresso> = {
      next(_result): void {
        alert('Ingresso alterado com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao alterar!');
      },
      complete(): void {},
    };
    this.ingressosService.alterar(ingresso).subscribe(observer);
  }  

  excluir(): void {
    const idIngresso: number = this.formulario.get('idIngresso').value;
  
    if (idIngresso) {
      if (confirm('Tem certeza que deseja excluir a sala?')) {
        this.ingressosService.excluir(idIngresso).subscribe(
          () => {
            alert('Ingresso excluído com sucesso.');
            this.reloadPage();
          },
          (error) => {
            console.error(error);
            alert('Erro ao excluir ingresso!');
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