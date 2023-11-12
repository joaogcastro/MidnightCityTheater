import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
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
  funcionarios: Funcionario[] = [];
  nomeFuncionarioEncontrado: string = '';

  constructor(private funcionariosService: FuncionariosService) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      IdFuncionario: new FormControl(null),
      CPFfunc: new FormControl(null),
      NomeFunc: new FormControl(null),
      EmailFunc: new FormControl(null),
      TelefoneFunc: new FormControl(null)
    });
    this.listar();

  }

  cadastrar(): void {
    const funcionario: Funcionario = this.formulario.value;
    if (!funcionario.IdFuncionario) {funcionario.IdFuncionario=0}
    const observer: Observer<Funcionario> = {
      next(_result): void {
        alert('Funcionario cadastrado com sucesso.' + funcionario.IdFuncionario + funcionario.CPFfunc + funcionario.NomeFunc + funcionario.EmailFunc + funcionario.TelefoneFunc);
      },
      error(error): void {
        alert('Erro de cadastro.' + funcionario.IdFuncionario + funcionario.CPFfunc + funcionario.NomeFunc + funcionario.EmailFunc + funcionario.TelefoneFunc);
        console.error(error);
        
        alert('Erro ao cadastrar!');
      },
      complete(): void {
      },
    };
    this.funcionariosService.cadastrar(funcionario).subscribe(observer);
  }

  listar(): void {
    this.funcionariosService.listar().subscribe(
      (funcionarios: Funcionario[]) => {
        this.funcionarios = funcionarios;
        console.log(funcionarios);
      },
      (error) => {
        console.error(error);
        alert('Erro ao carregar a lista de funcionarios!');
      }
    );
  }

  buscar(): void {
    const IdFuncionario: number = this.formulario.get('IdFuncionario').value;
  
    if (IdFuncionario) {
      this.funcionariosService.buscar(IdFuncionario).subscribe(
        (funcionarioEncontrado: Funcionario) => {
          if (funcionarioEncontrado) {
            this.formulario.patchValue(funcionarioEncontrado);
            this.nomeFuncionarioEncontrado = funcionarioEncontrado.NomeFunc;
            alert('Funcionario encontrado: ' + this.nomeFuncionarioEncontrado);
          } else {
            this.nomeFuncionarioEncontrado = ''; // Limpar o nome se não encontrar
            alert('Funcionario não encontrado.');
          }
        },
        (error) => {
          console.error(error);
          alert('Erro ao buscar funcionario!');
        }
      );
    } else {
      this.nomeFuncionarioEncontrado = '';
      alert('Por favor, insira um ID válido para buscar.');
    }
  }

  alterar(): void {
    const funcionario: Funcionario = this.formulario.value;
    if (!funcionario.NomeFunc) {funcionario.NomeFunc = "string"}
    if (!funcionario.CPFfunc) {funcionario.CPFfunc = "string"}
    if (!funcionario.EmailFunc) {funcionario.EmailFunc = "string"}
    if (!funcionario.TelefoneFunc) {funcionario.TelefoneFunc = "string"}
  
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
