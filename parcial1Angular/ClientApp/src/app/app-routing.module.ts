import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { RegistrarPersonaComponent } from './registrarPersona/registrar-persona/registrar-persona.component';
import { ConsultarPersonaComponent } from './consultarPersona/consultar-persona/consultar-persona.component';

const routes: Routes = [
  {
    path: "Registro",
    component: RegistrarPersonaComponent
  },
  {
    path: "Consulta",
    component: ConsultarPersonaComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
