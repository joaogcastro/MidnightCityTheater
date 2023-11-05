import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Snack } from './Snack';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class SnacksService {
  apiUrl = 'http://localhost:5000/snack';
  constructor(private http: HttpClient) { }
  listar(): Observable<Snack[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Snack[]>(url);
  }
  buscar(idSnack: number): Observable<Snack> {
    const url = `${this.apiUrl}/buscar/${idSnack}`;
    return this.http.get<Snack>(url);
  }
  cadastrar(snack: Snack): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Snack>(url, snack, httpOptions);
  }
  alterar(snack: Snack): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Snack>(url, snack, httpOptions);
  }
  excluir(idSnack: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${idSnack}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
