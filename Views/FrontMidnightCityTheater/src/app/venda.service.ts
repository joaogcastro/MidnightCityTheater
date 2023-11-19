import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Venda } from './Venda';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class VendaService {
  apiUrl = 'http://localhost:5000/Venda';
  constructor(private http: HttpClient) { }
  listar(): Observable<Venda[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Venda[]>(url);
  }
  buscar(idVenda: number): Observable<Venda> {
    const url = `${this.apiUrl}/buscar/${idVenda}`;
    return this.http.get<Venda>(url);
  }
  cadastrar(venda: Venda): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Venda>(url, venda, httpOptions);
  }
  excluir(idVenda: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${idVenda}`;
    return this.http.delete<string>(url, httpOptions);
  }
}