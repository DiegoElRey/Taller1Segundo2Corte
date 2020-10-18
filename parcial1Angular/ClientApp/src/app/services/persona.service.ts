import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Persona } from '../../app/models/persona';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { catchError, map, tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handdleErrorService: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }

  post(persona: Persona): Observable<Persona> {
    return this.http.post<Persona>(this.baseUrl + 'api/Persona', persona).pipe(
      tap(_ => this.handdleErrorService.log('datos enviados')),
      catchError(this.handdleErrorService.handleError<Persona>('Registrar Persona', null))
    );
  }
  get(): Observable<Persona[]> {
    return this.http.get<Persona[]>(this.baseUrl + 'api/Persona').pipe(
      tap(_ => this.handdleErrorService.log('Datos')),
      catchError(this.handdleErrorService.handleError<Persona[]>('Consulta Persona', null))
    );
  }
  Total() : Observable<number> {
    return this.http.get<number> (this.baseUrl + 'Api/TotalAyudas').pipe (
        tap (_ => this.handdleErrorService.log ('Datos')),
        catchError (this.handdleErrorService.handleError<number> ('Consulta Persona', null))
    );
}
}
