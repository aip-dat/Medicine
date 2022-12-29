import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { donthuoc } from '../models/donthuoc';

@Injectable({
  providedIn: 'root'
})
export class DonthuocService {

  private url = "DetailPrescription";

  constructor(private http : HttpClient) { }

  public get() : Observable<donthuoc[]>{
    return this.http.get<donthuoc[]>(`${environment.apiUrl}/${this.url}`);
  }

  public them(tmp : donthuoc) : Observable<donthuoc[]>{
    return this.http.post<donthuoc[]>(`${environment.apiUrl}/${this.url}`, tmp);
  }

  public sua(tmp:donthuoc) : Observable<donthuoc[]>{
    return this.http.put<donthuoc[]>(`${environment.apiUrl}/${this.url}/${tmp.idDetailPrescription}`, tmp);
  }

  public xoa(tmp:donthuoc) : Observable<donthuoc[]>{
    return this.http.delete<donthuoc[]>(`${environment.apiUrl}/${this.url}/${tmp.idDetailPrescription}`);
  }
}
