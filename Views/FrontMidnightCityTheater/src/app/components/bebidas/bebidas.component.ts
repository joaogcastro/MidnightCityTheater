import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { BebidasService } from 'src/app/bebidas.service';
import { Bebida } from 'src/app/Bebida';

@Component({
  selector: 'app-bebidas',
  templateUrl: './bebidas.component.html',
  styleUrls: ['./bebidas.component.css']
})

export class BebidasComponent implements OnInit {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  formulario: any;
  ListBebidas: Bebida[] = [];

  tamanhos = [
    { Tamanho: 'Pequeno' },
    { Tamanho: 'Medio' },
    { Tamanho: 'Grande' }
  ]

  constructor(private bebidasService: BebidasService) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      IdBebida: new FormControl(null),
      Sabor: new FormControl(null),
      Tamanho: new FormControl(null),
      Preco: new FormControl(null),
    });
    this.listar();
  }

  listar(): void {
    this.bebidasService.listar().subscribe(
      (bebidas: Bebida[]) => {
        this.ListBebidas = bebidas;
        console.log("Array Back Bebidas;:",bebidas);
        console.log("Array Front Bebidas:",this.ListBebidas);
      },
      (error) => {
        console.error(error);
        alert('Erro ao carregar a lista de Bebidas!');
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
    const bebida: Bebida = this.formulario.value;
    if (!bebida.IdBebida) {bebida.IdBebida=0}
    const observer: Observer<Bebida> = {
      next(_result): void {
        alert('Bebida cadastrada com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao cadastrar!');
      },
      complete(): void {
      },
    };
    this.bebidasService.cadastrar(bebida).subscribe(observer);
    this.reloadPage()
  }

  alterar(): void {
    const bebida: Bebida = this.formulario.value;
    if (!bebida.Sabor) {bebida.Sabor = "string"}
    if (!bebida.Tamanho) {bebida.Tamanho = "string"}
    if (!bebida.Preco || isNaN(bebida.Preco)) {bebida.Preco = 0;}
  
    const observer: Observer<Bebida> = {
      next(_result): void {
        alert('Bebida alterada com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao alterar!');
      },
      complete(): void {},
    };
    this.bebidasService.alterar(bebida).subscribe(observer);
    this.reloadPage();
  }  

  excluir(): void {
    const bebida: Bebida = this.formulario.value;
    const observer: Observer<Bebida> = {
      next(_result): void {
        alert('Bebida excluída com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao excluir!');
      },
      complete(): void {
      },
    };
    this.bebidasService.excluir(bebida.IdBebida).subscribe(observer);
    this.reloadPage()
  }

  reloadPage(): void {
    window.location.reload();
  }
}