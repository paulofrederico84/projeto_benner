import { Veiculo } from '../models/Veiculo';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VeiculoService {

  baseUrl = `${environment.mainUrlAPI}veiculo`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Veiculo[]> {
    return this.http.get<Veiculo[]>(this.baseUrl);
  }

  getPlaca(placa: string): Observable<Veiculo> {
    return this.http.get<Veiculo >(`${this.baseUrl}/${placa}`);
  }

  put(id: number, veiculo: Veiculo) {
    return this.http.put(`${this.baseUrl}/${veiculo.id}`, veiculo);
  }

  post(veiculo: Veiculo) {
    return this.http.post(`${this.baseUrl}`, veiculo);

  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}/veiculoId=${id}`);
  }
}
