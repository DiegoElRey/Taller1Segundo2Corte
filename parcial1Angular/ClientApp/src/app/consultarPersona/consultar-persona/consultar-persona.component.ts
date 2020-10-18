import { DecimalPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../../models/persona';
@Component({
  selector: 'app-consultar-persona',
  templateUrl: './consultar-persona.component.html',
  styleUrls: ['./consultar-persona.component.css']
})
export class ConsultarPersonaComponent implements OnInit {
personas : Persona[]
total: string;
  constructor(private personaService: PersonaService) { }

  ngOnInit() {
    this.get();
    this.Total();
  }
  get(){
    this.personaService.get().subscribe(result=>{
      this.personas = result;
    });
  }
  Total(){
    this.personaService.Total().subscribe(result => {
      this.total = result.toString();
    })
  }
}
