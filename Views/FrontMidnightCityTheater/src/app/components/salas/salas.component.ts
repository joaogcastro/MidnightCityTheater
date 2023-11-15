import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Title } from '@angular/platform-browser';
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
  formulario: any;
  formularioBuscar: any;
  ListSalas: Sala[] = [];
  nomeSalaEncontrado: Sala | null = null;

  constructor(private salasService: SalasService, private titleService: Title) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      idSala: new FormControl(null),
      capacidade: new FormControl(null),
      tipoSala: new FormControl(null)
    });
    this.listar();
    this.formularioBuscar = new FormGroup({
      idSala: new FormControl(null),
    });
    this.titleService.setTitle('Funcionario MidnightCity');
  }

  cadastrar(): void {
    const sala: Sala = this.formulario.value;
    if (!sala.idSala) {
      sala.idSala = 0;
    }
    const observer: Observer<Sala> = {
      next(_result): void {
        alert('Sala cadastrada com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro de cadastro, verifique se todos os campos foram preenchidos corretamente.');
      },
      complete(): void {},
    };
    this.salasService.cadastrar(sala).subscribe(observer);
  }

  listar(): void {
    this.salasService.listar().subscribe(
      (salas: Sala[]) => {
        this.ListSalas = salas;
      },
      (error) => {
        console.error(error);
        alert('Erro ao carregar a lista de salas!');
      }
    );
  }

  buscar(): void {
    const idSala: number = this.formularioBuscar.get('idSala').value;
    
    if (idSala) {
      this.salasService.buscar(idSala).subscribe(
        (salaEncontrado: any) => {
          console.log(salaEncontrado);
          this.formularioBuscar.get('idSala')?.setValue(salaEncontrado.idSala);
          this.nomeSalaEncontrado = salaEncontrado;    
        },
        (error) => {
          console.error(error);
          alert('Erro ao buscar sala!');
        }
      );
    } else {
      alert('Por favor, insira um ID válido para buscar.');
    }
  }

  alterar(): void {
    const sala: Sala = this.formulario.value;
    if (sala.idSala === null) {
      alert('Por favor, busque uma sala antes de tentar alterar.');
      return;
    }
    if (!sala.capacidade) {
      sala.capacidade = 'string';
    }
    if (!sala.tipoSala) {
      sala.tipoSala = 'string';
    }
  
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

  excluir(): void {
    const idSala: number = this.formulario.get('idSala').value;
  
    if (idSala) {
      if (confirm('Tem certeza que deseja excluir a sala?')) {
        this.salasService.excluir(idSala).subscribe(
          () => {
            alert('Sala excluída com sucesso.');
            this.reloadPage();
          },
          (error) => {
            console.error(error);
            alert('Erro ao excluir sala!');
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