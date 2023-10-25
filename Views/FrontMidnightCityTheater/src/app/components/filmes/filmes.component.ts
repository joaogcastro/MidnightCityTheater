import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { FilmesService } from 'src/app/filmes.service';
import { Filme } from 'src/app/Filme';

@Component({
  selector: 'app-filmes',
  templateUrl: './filmes.component.html',
  styleUrls: ['./filmes.component.css']
})
export class FilmesComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  
  constructor(private filmesService : FilmesService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Filme';
    this.formulario = new FormGroup({
      nomefilme: new FormControl(null),
      duracao: new FormControl(null),
      classificacao: new FormControl(null),
      diretor: new FormControl(null),
      categoria: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const filme : Filme = this.formulario.value;
    this.filmesService.cadastrar(filme).subscribe(result => {
      alert('Filme inserido com sucesso.');
    })
  } 
}
