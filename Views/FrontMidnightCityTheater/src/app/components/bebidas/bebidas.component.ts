import { Component, OnInit } from '@angular/core';
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
  formulario: any;
  tituloFormulario: string = '';

  tamanhos = [
    { Tamanho: 'Pequeno' },
    { Tamanho: 'Medio' },
    { Tamanho: 'Grande' }
  ]

  constructor(private bebidasService: BebidasService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Adicionar Bebidas';

    this.formulario = new FormGroup({
      IdBebida: new FormControl(null),
      Sabor: new FormControl(null),
      Tamanho: new FormControl(null),
      Preco: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    const bebida: Bebida = this.formulario.value;
    const observer: Observer<Bebida> = {
      next(_result): void {
        alert('Modelo salvo com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao salvar!');
      },
      complete(): void {
      },
    };
    if (bebida.IdBebida && !isNaN(Number(bebida.IdBebida))) {
      this.bebidasService.alterar(bebida).subscribe(observer);
    } else {
      this.bebidasService.cadastrar(bebida).subscribe(observer);
    }
  }
}
