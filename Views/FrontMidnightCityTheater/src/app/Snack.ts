import {Pipoca} from "./Pipoca";
import {Bebida} from "./Bebida";
import {Doce} from "./Doce";

export class Snack {
    idSnack: number = 0;
    pipocas: Array<Pipoca> = [];
    bebidas: Array<Bebida> = [];
    doces: Array<Doce> = [];
    precoTotal: number = 0;
}