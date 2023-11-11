import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { DocesService } from 'src/app/doces.service';
import { Doce } from 'src/app/Doce';

@Component({
  selector: 'app-doces',
  templateUrl: './doces.component.html',
  styleUrls: ['./doces.component.css']
})

export class DocesComponent implements OnInit {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  formulario: any;
  ListDoces: Doce[] = [];

  constructor(private docesService: DocesService) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      IdDoce: new FormControl(null),
      Nome: new FormControl(null),
      Preco: new FormControl(null),
    });
    this.listar();
  }

  listar(): void {
    this.docesService.listar().subscribe(
      (doces: Doce[]) => {
        this.ListDoces = doces;
        console.log("Array Back:",doces);
        console.log("Array Front:",this.ListDoces);
      },
      (error) => {
        console.error(error);
        alert('Erro ao carregar a lista de Doces!');
      }
    );
  }

  /*buscar(): void {
    const id: number = this.formulario.get('IdBebida').value;
    if (id) {
      this.bebidasService.buscar(id).subscribe(
        (resultadoBusca: Bebida) => {
          if (resultadoBusca) {
            this.formulario.patchValue(resultadoBusca);
            alert('Filme encontrado: ' + resultadoBusca.IdBebida);
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
    const doce: Doce = this.formulario.value;
    if (!doce.IdDoce) {doce.IdDoce=0}
    const observer: Observer<Doce> = {
      next(_result): void {
        alert('Doce cadastrado com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao cadastrar!');
      },
      complete(): void {
      },
    };
    this.docesService.cadastrar(doce).subscribe(observer);
    this.reloadPage()
  }

  alterar(): void {
    const doce: Doce = this.formulario.value;
    if (!doce.Nome) {doce.Nome = "string"}
    if (!doce.Preco || isNaN(doce.Preco)) {doce.Preco = 0;}
  
    const observer: Observer<Doce> = {
      next(_result): void {
        alert('Doce alterado com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao alterar!');
      },
      complete(): void {},
    };
    this.docesService.alterar(doce).subscribe(observer);
    this.reloadPage();
  }  

  excluir(): void {
    const doce: Doce = this.formulario.value;
    const observer: Observer<Doce> = {
      next(_result): void {
        alert('Doce excluído com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao excluir!');
      },
      complete(): void {
      },
    };
    this.docesService.excluir(doce.IdDoce).subscribe(observer);
    this.reloadPage()
  }

  reloadPage(): void {
    window.location.reload();
  }
}