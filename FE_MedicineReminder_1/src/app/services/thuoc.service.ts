import { thuoc } from './../models/thuoc';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ThuocService {

  private url = "Medicines";

  constructor(private http : HttpClient) { }

  public get() : Observable<thuoc[]>{
    return this.http.get<thuoc[]>(`${environment.apiUrl}/${this.url}`);
  }

  public them(tmp : thuoc) : Observable<thuoc[]>{
    return this.http.post<thuoc[]>(`${environment.apiUrl}/${this.url}`, tmp);
  }

  public sua(tmp:thuoc) : Observable<thuoc[]>{
    return this.http.put<thuoc[]>(`${environment.apiUrl}/${this.url}/${tmp.idMedicine}`, tmp);
  }

  public xoa(tmp:thuoc) : Observable<thuoc[]>{
    return this.http.delete<thuoc[]>(`${environment.apiUrl}/${this.url}/${tmp.idMedicine}`);
  }
}
