import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Filme } from './Filme';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class FilmesService {
  apiUrl = 'http://localhost:5000/Filme';
  constructor(private http: HttpClient) { }
  listar(): Observable<Filme[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Filme[]>(url);
  }
  buscar(nomefilme: string): Observable<Filme> {
    const url = `${this.apiUrl}/buscar/${nomefilme}`;
    return this.http.get<Filme>(url);
  }
  cadastrar(filme: Filme): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Filme>(url, filme, httpOptions);
  }
  alterar(filme: Filme): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Filme>(url, filme, httpOptions);
  }
  excluir(nomefilme: string): Observable<any> {
    const url = `${this.apiUrl}/buscar/${nomefilme}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
