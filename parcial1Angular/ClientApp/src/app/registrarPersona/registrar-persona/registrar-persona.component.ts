import { Component, OnInit } from '@angular/core';
import { Persona } from 'src/app/models/persona';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-registrar-persona',
  templateUrl: './registrar-persona.component.html',
  styleUrls: ['./registrar-persona.component.css']
})
export class RegistrarPersonaComponent implements OnInit {
  public persona: Persona;
  constructor(private personaService: PersonaService) { }

  ngOnInit() {
    this.persona = new Persona;
  }
  agregar(){
    this.personaService.post(this.persona).subscribe(p => {
      if (p != null) {
        alert("Se ha guardado. ");
      }
    })
  }

}
