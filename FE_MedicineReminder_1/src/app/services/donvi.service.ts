import { donvi } from './../models/donvi';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DonviService {
  private url = "Types";

  constructor(private http : HttpClient) { }

  public get() : Observable<donvi[]>{
    return this.http.get<donvi[]>(`${environment.apiUrl}/${this.url}`);
  }

  public them(tmp : donvi) : Observable<donvi[]>{
    return this.http.post<donvi[]>(`${environment.apiUrl}/${this.url}`, tmp);
  }

  public sua(tmp:donvi) : Observable<donvi[]>{
    return this.http.put<donvi[]>(`${environment.apiUrl}/${this.url}/${tmp.idType}`, tmp);
  }

  public xoa(tmp:donvi) : Observable<donvi[]>{
    return this.http.delete<donvi[]>(`${environment.apiUrl}/${this.url}/${tmp.idType}`);
  }
}
