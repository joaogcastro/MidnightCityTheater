import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pipoca } from './Pipoca';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class PipocasService {
  apiUrl = 'http://localhost:5000/Pipoca';
  constructor(private http: HttpClient) { }
  listar(): Observable<Pipoca[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Pipoca[]>(url);
  }
  buscar(idPipoca: number): Observable<Pipoca> {
    const url = `${this.apiUrl}/buscar/${idPipoca}`;
    return this.http.get<Pipoca>(url);
  }
  cadastrar(pipoca: Pipoca): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Pipoca>(url, pipoca, httpOptions);
  }
  alterar(pipoca: Pipoca): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Pipoca>(url, pipoca, httpOptions);
  }
  excluir(idPipoca: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${idPipoca}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
