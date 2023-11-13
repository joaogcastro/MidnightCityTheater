import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { DocesService } from 'src/app/doces.service';
import { Doce } from 'src/app/Doce';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-doces',
  templateUrl: './doces.component.html',
  styleUrls: ['./doces.component.css']
})

export class DocesComponent implements OnInit {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  formulario: any;
  ListDoces: Doce[] = [];
  formularioBuscar: any;
  ObjBuscado: Doce | null = null;
  constructor(private docesService: DocesService, private titleService: Title) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      idDoce: new FormControl(null),
      nome: new FormControl(null),
      preco: new FormControl(null),
    });
    this.formularioBuscar = new FormGroup({
      idDoce: new FormControl(null)
    });
    this.titleService.setTitle('Doce MidnightCity');
  }

  listar(): void {
    this.docesService.listar().subscribe(
      (doces: Doce[]) => {
        this.ListDoces = doces;
      },
      (error) => {
        console.error(error);
        alert('Erro ao carregar a lista de Doces!');
      }
    );
  }

  buscar(): void {
    const id: number = this.formularioBuscar.get('idDoce').value;
    if (id) {
      this.docesService.buscar(id).subscribe(
        (resultadoBusca: any) => {
          console.log(resultadoBusca);
          this.formularioBuscar.get('idDoce')?.setValue(resultadoBusca.idDoce);
          this.ObjBuscado = resultadoBusca;
        },
        (error) => {
          console.error(error);
          alert('Erro, doce não encontrado!');
        }
      );
    } else {
      alert('Por favor, insira um ID válido para buscar.');
    }
  }

  cadastrar(): void {
    const doce: Doce = this.formulario.value;
    if (!doce.idDoce) { doce.idDoce = 0 }
    const observer: Observer<Doce> = {
      next(_result): void {
        alert('Doce cadastrado com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao cadastrar, verifique se todos os campos estão preenchidos corretamente!');
      },
      complete(): void {
      },
    };
    this.docesService.cadastrar(doce).subscribe(observer);
  }

  alterar(): void {
    const doce: Doce = this.formulario.value;
    if (!doce.nome) { doce.nome = "string" }
    if (!doce.preco || isNaN(doce.preco)) { doce.preco = 0; }

    const observer: Observer<Doce> = {
      next(_result): void {
        alert('Doce alterado com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao alterar!');
      },
      complete(): void { },
    };
    this.docesService.alterar(doce).subscribe(observer);
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
    this.docesService.excluir(doce.idDoce).subscribe(observer);
  }

  reloadPage(): void {
    window.location.reload();
  }
}