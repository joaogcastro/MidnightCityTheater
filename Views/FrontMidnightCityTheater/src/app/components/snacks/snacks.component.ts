import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Snack } from 'src/app/Snack';
import { SnacksService} from 'src/app/snacks.service';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-snacks',
  templateUrl: './snacks.component.html',
  styleUrls: ['./snacks.component.css']
})

export class SnacksComponent {
  calcularPrecoSnacks (snack: Snack): number {
    let precoTotalSnacks=0;

    // Somando os preços das pipocas
  for (const pipoca of snack.pipocas) {
    precoTotalSnacks += pipoca.preco;
  }

  // Somando os preços das bebidas
  for (const bebida of snack.bebidas) {
    precoTotalSnacks += bebida.preco;
  }

  // Somando os preços dos doces
  for (const doce of snack.doces) {
    precoTotalSnacks += doce.preco;
  }
    return precoTotalSnacks;
  }
}
