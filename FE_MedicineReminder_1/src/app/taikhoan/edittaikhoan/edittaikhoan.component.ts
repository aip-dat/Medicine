import { taikhoan } from './../../models/taikhoan';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TaikhoanService } from 'src/app/services/taikhoan.service';

@Component({
  selector: 'app-edittaikhoan',
  templateUrl: './edittaikhoan.component.html',
  styleUrls: ['./edittaikhoan.component.css']
})
export class EdittaikhoanComponent implements OnInit {

  @Input() data?: taikhoan;
  @Output() chinhsua = new EventEmitter<taikhoan[]>();
  datas: taikhoan[] = [];

  constructor(private services : TaikhoanService) { }

  ngOnInit(): void {
  }

  them(tam:taikhoan){
    this.services.them(tam)
    .subscribe((datas: taikhoan[]) => this.chinhsua.emit(datas));
  }

  sua(tam:taikhoan){
    this.services.sua(tam)
    .subscribe((datas: taikhoan[]) => this.chinhsua.emit(datas));
  }

  xoa(tam:taikhoan){
    if (confirm('Bạn chắc chắn muốn xóa?')){
      this.services.xoa(tam)
      .subscribe((datas: taikhoan[]) => this.chinhsua.emit(datas));
    }
  }
}
