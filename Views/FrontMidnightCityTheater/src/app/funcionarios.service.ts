import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Funcionario } from './funcionarios';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class FuncionariosService {
  apiUrl = 'http://localhost:5000/Funcionario';
  constructor(private http: HttpClient) { }
  listar(): Observable<Funcionario[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Funcionario[]>(url);
  }
  buscar(idfuncionario: number): Observable<Funcionario> {
    const url = `${this.apiUrl}/buscar/${idfuncionario}`;
    return this.http.get<Funcionario>(url);
  }
  cadastrar(funcionario: Funcionario): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Funcionario>(url, funcionario, httpOptions);
  }
  alterar(funcionario: Funcionario): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Funcionario>(url, funcionario, httpOptions);
  }
  excluir(idfuncionario: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${idfuncionario}`;
    return this.http.delete<string>(url, httpOptions);
  }
}