import {Pipoca} from "./Pipoca";
import {Bebida} from "./Bebida";
import {Doce} from "./Doce";

export class Snack {
    IdSnack: number = 0;
    Pipocas: Array<Pipoca> = [];
    Bebidas: Array<Bebida> = [];
    Doces: Array<Doce> = [];
    PrecoTotal: number = 0;
}