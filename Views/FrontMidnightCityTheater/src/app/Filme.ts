import { Sala } from "./Sala";

export class Filme {
  idFilme: number = 0;
  nomeFilme: string = '';
  duracao: string = '';
  classificacao: string = '';
  diretor: string = '';
  categoria: string = '';
  sala: Sala | null = null;
}