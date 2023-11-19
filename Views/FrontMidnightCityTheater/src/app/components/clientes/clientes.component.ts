import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { ClientesService } from 'src/app/clientes.service';
import { Cliente } from 'src/app/Cliente';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  formulario: any;
  ListClientes: Cliente[] = [];
  formularioBuscar: any;
  formularioBuscar2: any;
  ObjBuscado: Cliente | null = null;
  ObjBuscado2: Cliente | null = null;

  constructor(private clientesService: ClientesService, private titleService: Title) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      idCliente: new FormControl(null),
      cpf: new FormControl(null),
      nome: new FormControl(null),
      email: new FormControl(null),
      telefone: new FormControl(null),
    });
    this.formularioBuscar = new FormGroup({
      idCliente: new FormControl(null)
    });
    this.formularioBuscar2 = new FormGroup({
      cpf: new FormControl(null)
    });
    this.titleService.setTitle('Pipoca MidnightCity');
  }

  listar(): void {
    this.clientesService.listar().subscribe(
      (cliente: Cliente[]) => {
        this.ListClientes = cliente;
      },
      (error) => {
        console.error(error);
        alert('Erro ao carregar a lista de Clientes!');
      }
    );
  }

  buscar(): void {
    const id: number = this.formularioBuscar.get('idCliente').value;
    if (id) {
      this.clientesService.buscar(id).subscribe(
        (resultadoBusca: any) => {
          console.log(resultadoBusca);
          this.formularioBuscar.get('idCliente')?.setValue(resultadoBusca.idCliente);
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

  buscar2(): void {
    var cpf: string = this.formularioBuscar2.get('cpf').value;
    if (cpf) {
      this.clientesService.buscar2(cpf).subscribe(
        (resultadoBusca: any) => {
          this.formularioBuscar2.get('cpf')?.setValue(resultadoBusca.cpf);
          this.ObjBuscado2 = resultadoBusca;
        },
        (error) => {
          console.error(error);
          alert('Erro, cliente não encontrado!');
        }
      );
    } else {
      alert('Por favor, insira um ID válido para buscar.');
    }
  }

  buscarCPFVenda(cpf: string): Cliente {
    let cliente: Cliente | null = null;
  
    if (cpf) {
      this.clientesService.buscar2(cpf).subscribe(
        (resultadoBusca: any) => {
          this.formularioBuscar2.get('cpf')?.setValue(resultadoBusca.cpf);
          cliente = resultadoBusca;
        },
        (error) => {
          console.error(error);
          alert('Erro, cliente não encontrado!');
        }
      );
    } else {
      alert('Por favor, insira um CPF válido para buscar.');
    }
  
    // Verifica se a variável cliente foi atribuída antes de retorná-la
    if (cliente !== null) {
      return cliente;
    } else {
      // Ou, se preferir, você pode lançar um erro, retornar null ou fazer algo mais apropriado ao seu caso.
      throw new Error('Cliente não encontrado ou operação não concluída.');
    }
  }  

  cadastrar(): void {
    const cliente: Cliente = this.formulario.value;
    if (!cliente.idCliente) { cliente.idCliente = 0; }
    const observer: Observer<Cliente> = {
      next(_result): void {
        alert('Cliente cadastrado com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao cadastrar cliente!');
      },
      complete(): void {
      },
    };

    this.clientesService.cadastrar(cliente).subscribe(observer);
  }

  alterar(): void {
    const cliente: Cliente = this.formulario.value;
    if (!cliente.cpf) { cliente.cpf = "string"; }
    if (!cliente.nome) { cliente.nome = "string"; }
    if (!cliente.email) { cliente.email = "string"; }
    if (!cliente.telefone) { cliente.telefone = "string"; }

    const observer: Observer<Cliente> = {
      next(_result): void {
        alert('Cliente alterado com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao alterar cliente!');
      },
      complete(): void { },
    };
    this.clientesService.alterar(cliente).subscribe(observer);
  }

  excluir(): void {
    const cliente: Cliente = this.formulario.value;
    const observer: Observer<Cliente> = {
      next(_result): void {
        alert('Cliente excluído com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro ao excluir cliente!');
      },
      complete(): void {
      },
    };
    this.clientesService.excluir(cliente.idCliente).subscribe(observer);
  }

  reloadPage(): void {
    window.location.reload();
  }
}