import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { taikhoan } from '../models/taikhoan';

@Injectable({
  providedIn: 'root'
})
export class TaikhoanService {
  private url = "DrUsers";

  constructor(private http : HttpClient) { }

  public get() : Observable<taikhoan[]>{
    return this.http.get<taikhoan[]>(`${environment.apiUrl}/${this.url}`);
  }

  public them(tmp : taikhoan) : Observable<taikhoan[]>{
    return this.http.post<taikhoan[]>(`${environment.apiUrl}/${this.url}`, tmp);
  }

  public sua(tmp:taikhoan) : Observable<taikhoan[]>{
    return this.http.put<taikhoan[]>(`${environment.apiUrl}/${this.url}/${tmp.idDrUser}`, tmp);
  }

  public xoa(tmp:taikhoan) : Observable<taikhoan[]>{
    return this.http.delete<taikhoan[]>(`${environment.apiUrl}/${this.url}/${tmp.idDrUser}`);
  }
}
