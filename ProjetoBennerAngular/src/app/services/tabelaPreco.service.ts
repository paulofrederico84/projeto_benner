import { TabelaPreco } from './../models/TabelaPreco';
import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TabelaPrecoService {

  baseUrl = `${environment.mainUrlAPI}tabelaPreco`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<TabelaPreco[]> {
    return this.http.get<TabelaPreco[]>(this.baseUrl);
  }

  put(tabelaPreco: TabelaPreco) {
    return this.http.put(`${this.baseUrl}/tabelaPrecoId=${tabelaPreco.id}`, tabelaPreco);
  }

  post(tabelaPreco: TabelaPreco) {
    return this.http.post(this.baseUrl, tabelaPreco);

  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/tabelaPrecoId=${id}`);
  }
}
