import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Pipoca } from 'src/app/Pipoca';
import { PipocasService } from 'src/app/pipocas.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-pipocas',
  templateUrl: './pipocas.component.html',
  styleUrls: ['./pipocas.component.css']
})

export class PipocasComponent {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  formulario: any;
  ListPipocas: Pipoca[] = [];
  formularioBuscar: any;
  ObjBuscado: Pipoca | null = null;
  tamanhos = [
    { Tamanho: 'Pequeno' },
    { Tamanho: 'Medio' },
    { Tamanho: 'Grande' }
  ]
  constructor(private pipocasService: PipocasService, private titleService: Title) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      idPipoca: new FormControl(null),
      sabor: new FormControl(null),
      tamanho: new FormControl(null),
      preco: new FormControl(null),
    });
    this.formularioBuscar = new FormGroup({
      idPipoca: new FormControl(null)
    });
    this.titleService.setTitle('Pipoca MidnightCity');
  }

  listar(): void {
    this.pipocasService.listar().subscribe(
      (pipocas: Pipoca[]) => {
        this.ListPipocas = pipocas;
      },
      (error) => {
        console.error(error);
        alert('Erro ao carregar a lista de Pipocas!');
      }
    );
  }

  buscar(): void {
    const id: number = this.formularioBuscar.get('idPipoca').value;
    if (id) {
      this.pipocasService.buscar(id).subscribe(
        (resultadoBusca: any) => {
          this.formularioBuscar.get('idPipoca')?.setValue(resultadoBusca.idPipoca);
          this.ObjBuscado = resultadoBusca;
        },
        (error) => {
          console.error(error);
          alert('Erro, pipoca não encontrado!');
        }
      );
    } else {
      alert('Por favor, insira um ID válido para buscar.');
    }
  }

  cadastrar(): void {
    const pipoca: Pipoca = this.formulario.value;
    if (!pipoca.idPipoca) { pipoca.idPipoca = 0 }
    const observer: Observer<Pipoca> = {
      next(_result): void {
        alert('Pipoca cadastrada com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao cadastrar!');
      },
      complete(): void {
      },
    };
    this.pipocasService.cadastrar(pipoca).subscribe(observer);
  }

  alterar(): void {
    const pipoca: Pipoca = this.formulario.value;
    if (!pipoca.sabor) { pipoca.sabor = "string" }
    if (!pipoca.tamanho) { pipoca.tamanho = "string" }
    if (!pipoca.preco || isNaN(pipoca.preco)) { pipoca.preco = 0; }

    const observer: Observer<Pipoca> = {
      next(_result): void {
        alert('Pipoca alterada com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao alterar!');
      },
      complete(): void { },
    };
    this.pipocasService.alterar(pipoca).subscribe(observer);
  }

  excluir(): void {
    const pipoca: Pipoca = this.formulario.value;
    const observer: Observer<Pipoca> = {
      next(_result): void {
        alert('Pipoca excluída com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao excluir!');
      },
      complete(): void {
      },
    };
    this.pipocasService.excluir(pipoca.idPipoca).subscribe(observer);
  }

  reloadPage(): void {
    window.location.reload();
  }
}
