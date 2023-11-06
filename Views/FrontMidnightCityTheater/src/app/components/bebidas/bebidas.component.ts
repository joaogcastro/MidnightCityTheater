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
      Preco: new FormControl(null)
    });
  }

  cadastrar(): void {
    const bebida: Bebida = this.formulario.value;
    if (!bebida.IdBebida) {bebida.IdBebida=0}
    const observer: Observer<Bebida> = {
      next(_result): void {
        alert('Bebida cadastrada com sucesso.' + bebida.IdBebida + bebida.Sabor + bebida.Tamanho + bebida.Preco);
      },
      error(error): void {
        console.error(error);
        alert('Erro ao cadastrar!');
      },
      complete(): void {
      },
    };
    this.bebidasService.cadastrar(bebida).subscribe(observer);
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
  }

  reloadPage(): void {
    window.location.reload();
  }
}