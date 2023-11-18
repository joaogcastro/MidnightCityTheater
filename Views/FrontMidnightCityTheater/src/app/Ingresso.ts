import { Filme } from "./Filme";
import { Sala } from "./Sala";

export class Ingresso {
    idIngresso: number = 0;
    tipoIngresso: string = "";
    idFilme: number = 0;
    filme: Filme | null = null;
    idSala: number = 0;
    sala: Sala | null = null;
    precoIng: number = 0;
}