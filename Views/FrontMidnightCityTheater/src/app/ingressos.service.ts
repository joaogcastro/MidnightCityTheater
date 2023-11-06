import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ingresso } from './Ingresso';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class IngressosService {
  apiUrl = 'http://localhost:5000/Ingresso';
  constructor(private http: HttpClient) { }
  listar(): Observable<Ingresso[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Ingresso[]>(url);
  }
  buscar(idIngresso: number): Observable<Ingresso> {
    const url = `${this.apiUrl}/buscar/${idIngresso}`;
    return this.http.get<Ingresso>(url);
  }
  cadastrar(ingresso: Ingresso): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Ingresso>(url, ingresso, httpOptions);
  }
  alterar(ingresso: Ingresso): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Ingresso>(url, ingresso, httpOptions);
  }
  excluir(idIngresso: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${idIngresso}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
