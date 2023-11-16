import { Cliente } from "./Cliente";
import { Ingresso } from "./Ingresso";
import { Snack } from "./Snack";

export class Venda {
    idVenda: number = 0;
    data: Date = new Date();
    cliente: Cliente = new Cliente();
    ingresso: Ingresso = new Ingresso();
    snack: Snack = new Snack();
    precoTotal: number = 0;
}