import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { FilmesService } from 'src/app/filmes.service';
import { Filme } from 'src/app/Filme';
import { SalasService } from 'src/app/salas.service';
import { Sala } from 'src/app/Sala';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-filmes',
  templateUrl: './filmes.component.html',
  styleUrls: ['./filmes.component.css']
})
export class FilmesComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  salas: Array<Sala> | undefined;
  
  constructor(private filmesService : FilmesService, private salasService: SalasService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Filme';
    this.salasService.listar().subscribe((salas: Sala[] | undefined) => {
      this.salas = salas;
      if (this.salas && this.salas.length > 0) {
      this.formulario.get('salaId')?.setValue(this.salas[0].idsala);
      }
      });
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
    const observer: Observer<Filme> = {
      next(_result: any): void{
        alert('Filme salvo com sucesso.');
      },
      error(_error: any): void {
        alert('Erro ao salvar!');
      },
      complete():void{
      },
    };
    if (filme.idfilme && !isNaN(Number(filme.idfilme))){
      this.filmesService.alterar(filme).subscribe(observer);
    } else {
      this.filmesService.cadastrar(filme).subscribe(observer);
    }
  } 
}
