import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CopagoConsultaComponent } from './copago/copago-consulta/copago-consulta.component';
import { CopagoRegistroComponent } from './copago/copago-registro/copago-registro.component';

const routes: Routes = [
    {
    path: 'copagoConsulta',
    component: CopagoConsultaComponent
    },
    {
      path: 'copagoRegistro',
      component: CopagoRegistroComponent
    }
  ];
  

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]

})
export class AppRoutingModule { }
