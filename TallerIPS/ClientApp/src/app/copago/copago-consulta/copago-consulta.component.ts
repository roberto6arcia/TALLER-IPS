import { Component, OnInit } from '@angular/core';
import { CopagoService } from 'src/app/services/copago.service';
import { Copago } from '../models/copago';

@Component({
  selector: 'app-copago-consulta',
  templateUrl: './copago-consulta.component.html',
  styleUrls: ['./copago-consulta.component.css']
})
export class CopagoConsultaComponent implements OnInit {

  copagos:Copago[];
  constructor(private copagoSevice: CopagoService) { }

  ngOnInit() {
    this.copagoSevice.get().subscribe(result=> {
      this.copagos = result;
    });
  }

}
