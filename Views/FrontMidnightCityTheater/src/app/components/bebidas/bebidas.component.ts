import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Bebida } from 'src/app/Bebida';
import { BebidasService } from 'src/app/bebidas.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-bebidas',
  templateUrl: './bebidas.component.html',
  styleUrls: ['./bebidas.component.css']
})

export class BebidasComponent implements OnInit {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  formulario: any;
  ListBebidas: Bebida[] = [];
  formularioBuscar: any;
  ObjBuscado: Bebida | null = null;
  tamanhos = [
    { Tamanho: 'Pequeno' },
    { Tamanho: 'Medio' },
    { Tamanho: 'Grande' }
  ]
  constructor(private bebidasService: BebidasService, private titleService: Title) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      idBebida: new FormControl(null),
      sabor: new FormControl(null),
      tamanho: new FormControl(null),
      preco: new FormControl(null),
    });
    this.formularioBuscar = new FormGroup({
      idBebida: new FormControl(null)
    });
    this.titleService.setTitle('Bebida MidnightCity');
  }

  listar(): void {
    this.bebidasService.listar().subscribe(
      (bebidas: Bebida[]) => {
        this.ListBebidas = bebidas;
      },
      (error) => {
        console.error(error);
        alert('Erro ao carregar a lista de Bebidas!');
      }
    );
  }

  buscar(): void {
    const id: number = this.formularioBuscar.get('idBebida').value;
    if (id) {
      this.bebidasService.buscar(id).subscribe(
        (resultadoBusca: any) => {
          this.formularioBuscar.get('idBebida')?.setValue(resultadoBusca.idBebida);
          this.ObjBuscado = resultadoBusca;
        },
        (error) => {
          console.error(error);
          alert('Erro, bebida não encontrado!');
        }
      );
    } else {
      alert('Por favor, insira um ID válido para buscar.');
    }
  }

  cadastrar(): void {
    const bebida: Bebida = this.formulario.value;
    if (!bebida.idBebida) { bebida.idBebida = 0 }
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
  }

  alterar(): void {
    const bebida: Bebida = this.formulario.value;
    if (!bebida.sabor) { bebida.sabor = "string" }
    if (!bebida.tamanho) { bebida.tamanho = "string" }
    if (!bebida.preco || isNaN(bebida.preco)) { bebida.preco = 0; }

    const observer: Observer<Bebida> = {
      next(_result): void {
        alert('Bebida alterada com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao alterar!');
      },
      complete(): void { },
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
    this.bebidasService.excluir(bebida.idBebida).subscribe(observer);
  }

  reloadPage(): void {
    window.location.reload();
  }
}