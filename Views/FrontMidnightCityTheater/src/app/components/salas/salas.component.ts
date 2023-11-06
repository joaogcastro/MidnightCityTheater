import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Sala } from 'src/app/Sala';
import { SalasService } from 'src/app/salas.service';

@Component({
  selector: 'app-salas',
  templateUrl: './salas.component.html',
  styleUrls: ['./salas.component.css']
})
export class SalasComponent implements OnInit {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  formulario!: FormGroup;
  salas: Sala[] = [];
  novaSala: Sala = new Sala(); // Adicione uma nova instância de Sala

  constructor(private salasService: SalasService) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      Idsala: new FormControl(null),
      Sabor: new FormControl(null),
      Tamanho: new FormControl(null),
      Preco: new FormControl(null)
    });
  }

  cadastrarSala(): void {
    const sala: Sala = this.novaSala; // Use novaSala em vez de this.formulario.value
    if (!sala.idsala) {
      sala.idsala = 0;
    }
    const observer: Observer<Sala> = {
      next(_result): void {
        alert('Sala cadastrada com sucesso.' + sala.idsala + sala.capacidade + sala.tiposala);
      },
      error(error): void {
        console.error(error);
        alert('Erro ao cadastrar!');
      },
      complete(): void {
      },
    };
    this.salasService.cadastrar(sala).subscribe(observer);
  }

  editarSala(sala: Sala): void {
    const sala1: Sala = this.formulario.value;
    if (!sala1.capacidade) {sala1.capacidade = "string"}
    if (!sala1.tiposala) {sala1.tiposala = "string"}
  
    const observer: Observer<Sala> = {
      next(_result): void {
        alert('Sala alterada com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao alterar!');
      },
      complete(): void {},
    };
    this.salasService.alterar(sala).subscribe(observer);
  }

  excluirSala(idSala: number): void {
    const sala: Sala = this.formulario.value;
    const observer: Observer<Sala> = {
      next(_result): void {
        alert('Sala excluída com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao excluir!');
      },
      complete(): void {
      },
    };
    this.salasService.excluir(sala.idsala).subscribe(observer);
  }

  reloadPage(): void {
    window.location.reload();
  }
}