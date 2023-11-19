import { Cliente } from "./Cliente";
import { Filme } from "./Filme";
import { Ingresso } from "./Ingresso";
import { Snack } from "./Snack";

export class Venda {
    idVenda: number = 0;
    data: Date = new Date();
    cliente: Cliente = new Cliente();
    ingresso: Ingresso = new Ingresso();
    filmes: Array<Filme> = [];
    snack: Snack = new Snack();
    precoTotalVenda: number = 0;
}