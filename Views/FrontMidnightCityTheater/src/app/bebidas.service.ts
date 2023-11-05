import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bebida } from './Bebida';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class BebidasService {
  apiUrl = 'http://localhost:5000/Bebida';
  constructor(private http: HttpClient) { }
  listar(): Observable<Bebida[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Bebida[]>(url);
  }
  buscar(idBebida: number): Observable<Bebida> {
    const url = `${this.apiUrl}/buscar/${idBebida}`;
    return this.http.get<Bebida>(url);
  }
  cadastrar(bebida: Bebida): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Bebida>(url, bebida, httpOptions);
  }
  alterar(bebida: Bebida): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Bebida>(url, bebida, httpOptions);
  }
  excluir(idBebida: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${idBebida}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
