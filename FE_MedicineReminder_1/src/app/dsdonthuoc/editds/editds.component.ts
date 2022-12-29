import { TaikhoanService } from './../../services/taikhoan.service';
import { taikhoan } from './../../models/taikhoan';
import { dsdon } from './../../models/dsdon';
import { DsdonService } from './../../services/dsdon.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-editds',
  templateUrl: './editds.component.html',
  styleUrls: ['./editds.component.css']
})
export class EditdsComponent implements OnInit {

  @Input() data?: dsdon;
  @Output() chinhsua = new EventEmitter<dsdon[]>();
  datas: dsdon[] = [];

  list : taikhoan[] = [];
  constructor(private services : DsdonService, private tksv : TaikhoanService) { }

  ngOnInit(): void {
    this.tksv.get().subscribe((result: taikhoan[]) => this.list = result);
  }

  them(tam:dsdon){
    this.services.them(tam)
    .subscribe((datas: dsdon[]) => this.chinhsua.emit(datas));
  }

  sua(tam:dsdon){
    this.services.sua(tam)
    .subscribe((datas: dsdon[]) => this.chinhsua.emit(datas));
  }

  xoa(tam:dsdon){
    if (confirm('Bạn chắc chắn muốn xóa?')){
      this.services.xoa(tam)
      .subscribe((datas: dsdon[]) => this.chinhsua.emit(datas));
    }
  }
}
