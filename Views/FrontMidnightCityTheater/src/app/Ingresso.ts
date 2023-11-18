import { Filme } from "./Filme";

export class Ingresso {
    idIngresso: number = 0;
    tipoIngresso: string = "";
    precoIng: number = 0;
    filme: Filme | null = null;
}