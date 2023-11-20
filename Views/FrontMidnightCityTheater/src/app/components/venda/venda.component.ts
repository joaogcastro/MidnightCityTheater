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
import { FilmesService } from 'src/app/filmes.service';
import { Bebida } from 'src/app/Bebida';
import { Pipoca } from 'src/app/Pipoca';
import { Doce } from 'src/app/Doce';
import { BebidasService } from 'src/app/bebidas.service';
import { DocesService } from 'src/app/doces.service';
import { PipocasService } from 'src/app/pipocas.service';

@Component({
  selector: 'app-venda',
  templateUrl: './venda.component.html',
  styleUrls: ['./venda.component.css']
})
export class VendaComponent implements OnInit {
  @ViewChild('cancelarButton') cancelarButton!: ElementRef;
  @ViewChild('addButton') addButton!: ElementRef;
  formulario: any;
  formularioBuscar: any;
  ListVenda: Venda[] = [];
  ListFilmes: Filme[] = [];
  ListSalas: Sala[] = [];
  ListBebidas: Bebida[] = [];
  bebidas: Bebida[] = [];
  ListPipocas: Pipoca[] = [];
  pipocas: Pipoca[] = [];
  ListDoces: Doce[] = [];
  doces: Doce[] = [];
  nomeVendaEncontrado: Venda | null = null;
  tiposingresso = [
    { tipoIngresso: 'Meia' },
    { tipoIngresso: 'Inteira' }
  ]
  clientesComponent: any;
  filmeSelecionado: Filme | null = null;

  constructor(private vendaService: VendaService, private bebidasService: BebidasService, private docesService: DocesService, private pipocasService: PipocasService, private filmesService: FilmesService, private titleService: Title, private snackSerive: SnacksService, private clientesService: ClientesService) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      idVenda: new FormControl(null),
      cpfCliente: new FormControl(null),
      filme: new FormControl(null),
      bebida: new FormControl(null),
      doce: new FormControl(null),
      pipoca: new FormControl(null),
      tipoIngresso: new FormControl(null),
      data: new FormControl(this.getCurrentDateTime()),
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
      }
    );
    this.bebidasService.listar().subscribe(
      (bebidas: Bebida[]) => {
        this.ListBebidas = bebidas;
      },
    );
    this.docesService.listar().subscribe(
      (doces: Doce[]) => {
        this.ListDoces = doces;
      },
    );
    this.pipocasService.listar().subscribe(
      (pipocas: Pipoca[]) => {
        this.ListPipocas = pipocas;
      },
    );
  }

  cadastrar(): void {
    const venda: Venda = new Venda();
    venda.idVenda = 0;
    venda.ingresso.filme = this.filmeSelecionado;
    venda.snack.pipocas = [...this.pipocas];
    venda.snack.bebidas = [...this.bebidas];
    venda.snack.doces = [...this.doces];

    const observer: Observer<Venda> = {
      next(_result): void {
        alert('Venda cadastrada com sucesso.');
      },
      error(error): void {
        console.error(error);
        alert('Erro de cadastro, verifique se todos os campos foram preenchidos corretamente.');
      },
      complete(): void { },
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

  adicionarPipoca(): void {
    const idPipocaSelecionada: number = this.formulario.get('pipoca').value;
    // Busque a pipoca correspondente na lista ListPipocas pelo ID
    const pipoca: Pipoca | undefined = this.ListPipocas.find(p => p.idPipoca == idPipocaSelecionada);
    // Verifique se a pipoca foi encontrada antes de adicioná-la à lista
    if (pipoca) {
      this.pipocas.push(pipoca);
      alert("Pipoca adicionada!")
      console.log(this.pipocas)
    } else {
      console.error('Erro: Pipoca não encontrada na lista ListPipocas.');
    }
  }

  adicionarBebida(): void {
    const idBebidaSelecionada: number = this.formulario.get('bebida').value;
    // Verifica se a bebida já está na lista de bebidas
    if (!this.bebidas.some(b => b.idBebida === idBebidaSelecionada)) {
      // Busque a bebida correspondente na lista ListBebidas pelo ID
      const bebida: Bebida | undefined = this.ListBebidas.find(b => b.idBebida == idBebidaSelecionada);

      // Verifique se a bebida foi encontrada antes de adicioná-la à lista
      if (bebida) {
        this.bebidas.push({ ...bebida }); // Crie uma nova instância para evitar rastreamento do EF
        alert("Bebida adicionada!");
        console.log(this.bebidas);
      } else {
        console.error('Erro: Bebida não encontrada na lista ListBebidas.');
      }
    } else {
      alert("Essa bebida já foi adicionada!");
    }
  }

  adicionarDoce(): void {
    const idDoceSelecionado: number = this.formulario.get('doce').value;
    // Busque o doce correspondente na lista ListDoces pelo ID
    const doce: Doce | undefined = this.ListDoces.find(d => d.idDoce == idDoceSelecionado);
    // Verifique se o doce foi encontrado antes de adicioná-lo à lista
    if (doce) {
      this.doces.push(doce);
      alert("Doce adicionado!")
      console.log(this.doces);
    } else {
      console.error('Erro: Doce não encontrado na lista ListDoces.');
    }
  }

  reloadPage(): void {
    window.location.reload();
  }

}
