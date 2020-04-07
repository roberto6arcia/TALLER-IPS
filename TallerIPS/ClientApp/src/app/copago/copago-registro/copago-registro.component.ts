import { Component, OnInit } from '@angular/core';
import { Copago } from '../models/copago';
import { CopagoService } from 'src/app/services/copago.service';

@Component({
  selector: 'app-copago-registro',
  templateUrl: './copago-registro.component.html',
  styleUrls: ['./copago-registro.component.css']
})
export class CopagoRegistroComponent implements OnInit {

  copago: Copago;
  constructor(private copagoService: CopagoService) { }

  ngOnInit() {
    this.copago= new Copago();
  }

  add() {
    this.copagoService.post(this.copago).subscribe(p => {
      if (p != null) {
        alert('Guardado con exito!');
        this.copago = p;
      }
    });
  }


}
