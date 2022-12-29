import { dsdon } from './../models/dsdon';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DsdonService {
  private url = "Prescriptions";

  constructor(private http : HttpClient) { }

  public get() : Observable<dsdon[]>{
    return this.http.get<dsdon[]>(`${environment.apiUrl}/${this.url}`);
  }

  public them(tmp : dsdon) : Observable<dsdon[]>{
    return this.http.post<dsdon[]>(`${environment.apiUrl}/${this.url}`, tmp);
  }

  public sua(tmp:dsdon) : Observable<dsdon[]>{
    return this.http.put<dsdon[]>(`${environment.apiUrl}/${this.url}/${tmp.idPrescription}`, tmp);
  }

  public xoa(tmp:dsdon) : Observable<dsdon[]>{
    return this.http.delete<dsdon[]>(`${environment.apiUrl}/${this.url}/${tmp.idPrescription}`);
  }
}
