import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Observer } from 'rxjs';
import { Filme } from 'src/app/Filme';
import { Sala } from 'src/app/Sala';
import { Venda } from 'src/app/Venda';
import { ClientesService } from 'src/app/clientes.service';
import { SnacksService } from 'src/app/snacks.service';
import { VendaService } from 'src/app/venda.service';
import { ClientesComponent } from '../clientes/clientes.component';
import { FilmesService } from 'src/app/filmes.service';

@Component({
  selector: 'app-venda',
  templateUrl: './venda.component.html',
  styleUrls: ['./venda.component.css']
})
export class VendaComponent implements OnInit {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  formulario: any;
  formularioBuscar: any;
  ListVenda: Venda[] = [];
  ListFilmes: Filme[] = [];
  ListSalas: Sala[] = [];
  nomeVendaEncontrado: Venda | null = null;
  tiposingresso = [
    { tipoIngresso: 'Meia' },
    { tipoIngresso: 'Inteira' }
  ]
  clientesComponent: any;
  filmeSelecionado: Filme | null = null;

  constructor(private vendaService: VendaService,private filmesService: FilmesService, private titleService: Title, private snackSerive: SnacksService, /*private clienteComponent: ClientesComponent,*/ private clientesService: ClientesService) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      idVenda: new FormControl(null),
      cpfCliente: new FormControl(null),
      ingresso: new FormGroup({
        tipoIngresso: new FormControl(null),
      }),
      data: new FormControl(this.getCurrentDateTime()), // Preencher automaticamente com a data atual
      //snack: new FormControl(null),
      precoTotal: new FormControl(null)
    });
    this.formularioBuscar = new FormGroup({
      idVenda: new FormControl(null),
    });
    this.titleService.setTitle('Venda MidnightCity');
    this.filmesService.listar().subscribe(
      (filmes: Filme[]) => {
        this.ListFilmes = filmes;
      },
      (error) => {
        console.error(error);
        // Trate o erro conforme necessário
      }
    );
  
  }

  cadastrar(): void {
    const venda: Venda = new Venda();
    venda.idVenda = 0;
    console.log(this.clientesComponent.buscarCPFVenda(this.formulario.cpfCliente))
    venda.cliente = this.clientesComponent.buscarCPFVenda(this.formulario.cpfCliente);
    venda.ingresso.filme = this.filmeSelecionado;
    const observer: Observer<Venda> = {
      next(_result): void {
        alert('Venda cadastrada com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro de cadastro, verifique se todos os campos foram preenchidos corretamente.');
      },
      complete(): void {},
    };
    this.vendaService.cadastrar(venda).subscribe(observer);
  }

  listar(): void {
    this.vendaService.listar().subscribe(
      (vendas: Venda[]) => {
        this.ListVenda = vendas;
      },
      (error) => {
        console.error(error);
        alert('Erro ao carregar a lista de vendas!');
      }
    );
  }

  buscar(): void {
    const idVenda: number = this.formularioBuscar.get('idVenda').value;
    
    if (idVenda) {
      this.vendaService.buscar(idVenda).subscribe(
        (vendaEncontrado: any) => {
          console.log(vendaEncontrado);
          this.formularioBuscar.get('idVenda')?.setValue(vendaEncontrado.idVenda);
          this.nomeVendaEncontrado = vendaEncontrado;    
        },
        (error) => {
          console.error(error);
          alert('Erro ao buscar venda');
        }
      );
    } else {
      alert('Por favor, insira um ID válido para buscar.');
    }
  }

  excluir(): void {
    const idVenda: number = this.formulario.get('idVenda').value;
  
    if (idVenda) {
      if (confirm('Tem certeza que deseja excluir a sala?')) {
        this.vendaService.excluir(idVenda).subscribe(
          () => {
            alert('Sala excluída com sucesso.');
            this.reloadPage();
          },
          (error) => {
            console.error(error);
            alert('Erro ao excluir venda!');
          }
        );
      }
    } else {
      alert('Por favor, insira um ID válido para excluir.');
    }
  }

  meiaentrada(): void {
    const tipoIngresso: string = this.formulario.get('tipoIngresso').value;
    const sala: Sala | null = this.nomeVendaEncontrado?.ingresso?.filme?.sala || null;
  
    if (sala) {
      if (tipoIngresso.toLowerCase() === 'Meia') {
        this.formulario.get('precoTotal').setValue(sala.preco / 2);
      } else {
        this.formulario.get('precoTotal').setValue(sala.preco);
      }
    } else {
      console.error('Erro: Sala não encontrada para o filme associado à venda.');
    }
  }

  private getCurrentDateTime(): string {
    const now = new Date();
    const year = now.getFullYear();
    const month = (now.getMonth() + 1).toString().padStart(2, '0');
    const day = now.getDate().toString().padStart(2, '0');
    const hours = now.getHours().toString().padStart(2, '0');
    const minutes = now.getMinutes().toString().padStart(2, '0');

    return `${year}-${month}-${day}T${hours}:${minutes}`;
  }

  reloadPage(): void {
    window.location.reload();
  }
}
