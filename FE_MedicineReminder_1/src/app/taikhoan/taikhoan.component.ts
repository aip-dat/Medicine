import { TaikhoanService } from './../services/taikhoan.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { taikhoan } from '../models/taikhoan';

@Component({
  selector: 'app-taikhoan',
  templateUrl: './taikhoan.component.html',
  styleUrls: ['./taikhoan.component.css']
})
export class TaikhoanComponent implements OnInit {

  datas: taikhoan[] = [];
  @Output() chinhsua = new EventEmitter<taikhoan>();
  suadoi?: taikhoan;

  constructor(private Services : TaikhoanService) { }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(){
    this.Services.get().subscribe((result: taikhoan[]) => (
      this.datas = result
    ));
  }

  capnhat(tam: taikhoan[]){
    this.datas = tam;
    this.Services.get().subscribe((result: taikhoan[]) => (this.datas = result));
  }

  init(){
    this.suadoi = new taikhoan();
  }

  sua(tam: taikhoan){
    this.suadoi = tam;
  }
}
