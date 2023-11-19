import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Observer } from 'rxjs';
import { Funcionario } from 'src/app/funcionarios';
import { FuncionariosService } from 'src/app/funcionarios.service';

@Component({
  selector: 'app-funcionarios',
  templateUrl: './funcionarios.component.html',
  styleUrls: ['./funcionarios.component.css']
})
export class FuncionariosComponent implements OnInit {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  formulario: any;
  formularioBuscar: any;
  Funcionarios: Funcionario[] = [];
  nomeFuncionarioEncontrado: Funcionario | null = null;

  constructor(private funcionariosService: FuncionariosService, private titleService: Title) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      idFuncionario: new FormControl(null),
      cpFfunc: new FormControl(null),
      nomeFunc: new FormControl(null),
      emailFunc: new FormControl(null),
      telefoneFunc: new FormControl(null)
    });
    this.formularioBuscar = new FormGroup({
      idFuncionario: new FormControl(null),
    });
    this.titleService.setTitle('Funcionários MidnightCity');

  }

  cadastrar(): void {
    const funcionario: Funcionario = this.formulario.value;
    if (!funcionario.idFuncionario) {
      funcionario.idFuncionario = 0;
    }
    const observer: Observer<Funcionario> = {
      next(_result): void {
        alert('Funcionário cadastrado com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao cadastrar!');
      },
      complete(): void {},
    };
    this.funcionariosService.cadastrar(funcionario).subscribe(observer);
  }

  listar(): void {
    this.funcionariosService.listar().subscribe(
      (funcionarios: Funcionario[]) => {
        this.Funcionarios = funcionarios;
        console.log(funcionarios);
        console.log(this.Funcionarios);
      },
      (error) => {
        console.error(error);
        alert('Erro ao carregar a lista de funcionários!');
      }
    );
  }

  buscar(): void {
    const idFuncionario: number = this.formularioBuscar.get('idFuncionario').value;
    
    if (idFuncionario) {
      this.funcionariosService.buscar(idFuncionario).subscribe(
        (funcionarioEncontrado: any) => {
          console.log(funcionarioEncontrado);
            this.formularioBuscar.get('idFuncionario')?.setValue(funcionarioEncontrado.idFuncionario);
            this.nomeFuncionarioEncontrado = funcionarioEncontrado
        },
        (error) => {
          console.error(error);
          alert('Erro ao buscar funcionario!');
        }
      );
    } else {
      alert('Por favor, insira um ID válido para buscar.');
    }
  }

  alterar(): void {
    const funcionario: Funcionario = this.formulario.value;
    if (!funcionario.nomeFunc) {funcionario.nomeFunc = "string"}
    if (!funcionario.cpFfunc) {funcionario.cpFfunc = "string"}
    if (!funcionario.emailFunc) {funcionario.emailFunc = "string"}
    if (!funcionario.telefoneFunc) {funcionario.telefoneFunc = "string"}
  
    const observer: Observer<Funcionario> = {
      next(_result): void {
        alert('Funcionario alterado com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao alterar!');
      },
      complete(): void {},
    };
    this.funcionariosService.alterar(funcionario).subscribe(observer);
  }  

  excluir(): void {
    const IdFuncionario: number = this.formulario.get('IdFuncionario').value;
  
    if (IdFuncionario) {
      if (confirm('Tem certeza que deseja excluir o funcionario?')) {
        this.funcionariosService.excluir(IdFuncionario).subscribe(
          () => {
            alert('Funcionario excluído com sucesso.');
            this.reloadPage();
          },
          (error) => {
            console.error(error);
            alert('Erro ao excluir funcionario!');
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
