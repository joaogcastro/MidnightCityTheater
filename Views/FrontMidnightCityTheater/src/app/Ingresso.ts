import { Filme } from "./Filme";
import { Sala } from "./Sala";

export class Ingresso {
    IdIngresso: number = 0;
    TipoIngresso: string = "";
    Data: string = "";
    Filmes: Array<Filme> = [];
    Salas: Array<Sala> = [];
    Preco: number = 0;
}