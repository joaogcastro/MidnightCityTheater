import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ClientesService } from 'src/app/clientes.service';
import { Cliente } from 'src/app/Cliente';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  
  constructor(private clientesService : ClientesService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Cliente';
    this.formulario = new FormGroup({
      CPF: new FormControl(null),
      Nome: new FormControl(null),
      Email: new FormControl(null),
      Telefone: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const cliente : Cliente = this.formulario.value;
    this.clientesService.cadastrar(cliente).subscribe(result => {
      alert('Cliente inserido com sucesso.');
    })
  } 
}
