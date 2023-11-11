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
  buscar(idFilme: number): Observable<Filme> {
    const url = `${this.apiUrl}/buscar/${idFilme}`;
    return this.http.get<Filme>(url);
  }
  cadastrar(filme: Filme): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Filme>(url, filme, httpOptions);
  }
  alterar(filme: Filme): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Filme>(url, filme, httpOptions);
  }
  excluir(idFilme: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${idFilme}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
