import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Sala } from './Sala';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class SalasService {
  apiUrl = 'http://localhost:5000/Sala';
  constructor(private http: HttpClient) { }
  listar(): Observable<Sala[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Sala[]>(url);
  }
  buscar(idSala: number): Observable<Sala> {
    const url = `${this.apiUrl}/buscar/${idSala}`;
    return this.http.get<Sala>(url);
  }
  cadastrar(sala: Sala): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Sala>(url, sala, httpOptions);
  }
  alterar(sala: Sala): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Sala>(url, sala, httpOptions);
  }
  excluir(idSala: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${idSala}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
