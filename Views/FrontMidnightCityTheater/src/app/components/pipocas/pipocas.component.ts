import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Pipoca } from 'src/app/Pipoca';
import { PipocasService } from 'src/app/pipocas.service';

@Component({
  selector: 'app-pipocas',
  templateUrl: './pipocas.component.html',
  styleUrls: ['./pipocas.component.css']
})
export class PipocasComponent {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  formulario: any;
  ListPipocas: Pipoca[] = [];

  tamanhos = [
    { Tamanho: 'Pequeno' },
    { Tamanho: 'Medio' },
    { Tamanho: 'Grande' }
  ]

  constructor(private pipocasService: PipocasService) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      IdPipoca: new FormControl(null),
      Sabor: new FormControl(null),
      Tamanho: new FormControl(null),
      Preco: new FormControl(null),
    });
    this.listar();
  }

  listar(): void {
    this.pipocasService.listar().subscribe(
      (pipocas: Pipoca[]) => {
        this.ListPipocas = pipocas;
        console.log("Array Back pipocas;:", pipocas);
        console.log("Array Front pipocas:", this.ListPipocas);
      },
      (error) => {
        console.error(error);
        alert('Erro ao carregar a lista de Pipocas!');
      }
    );
  }

  /*buscar(): void {
    const id: number = this.formulario.get('Idpipoca').value;
    if (id) {
      this.pipocasService.buscar(id).subscribe(
        (resultadoBusca: pipoca) => {
          if (resultadoBusca) {
            this.formulario.patchValue(resultadoBusca);
            alert('Filme encontrado: ' + resultadoBusca.Idpipoca);
          } else {
            alert('Id não encontrado.');
          }
        },
        (error) => {
          console.error(error);
          alert('Erro na busca!');
        }
      );
    } else {
      alert('Por favor, insira um ID válido para buscar.');
    }
  }
*/
  cadastrar(): void {
    const pipoca: Pipoca = this.formulario.value;
    if (!pipoca.IdPipoca) { pipoca.IdPipoca = 0 }
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
    this.reloadPage()
  }

  alterar(): void {
    const pipoca: Pipoca = this.formulario.value;
    if (!pipoca.Sabor) { pipoca.Sabor = "string" }
    if (!pipoca.Tamanho) { pipoca.Tamanho = "string" }
    if (!pipoca.Preco || isNaN(pipoca.Preco)) { pipoca.Preco = 0; }

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
    this.reloadPage();
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
    this.pipocasService.excluir(pipoca.IdPipoca).subscribe(observer);
    this.reloadPage()
  }

  reloadPage(): void {
    window.location.reload();
  }
}
