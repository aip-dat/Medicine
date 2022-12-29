import { ThuocService } from './../../services/thuoc.service';
import { DonthuocService } from './../../services/donthuoc.service';
import { donthuoc } from './../../models/donthuoc';
import { thuoc } from './../../models/thuoc';
import { DonviService } from './../../services/donvi.service';
import { donvi } from './../../models/donvi';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-editdonvi',
  templateUrl: './editdonvi.component.html',
  styleUrls: ['./editdonvi.component.css']
})
export class EditdonviComponent implements OnInit {

  @Input() data?: donvi;
  @Output() chinhsua = new EventEmitter<donvi[]>();
  datas: donvi[] = [];

  
  constructor(private services : DonviService) { }

  ngOnInit(): void {
  }

  them(tam:donvi){
    this.services.them(tam)
    .subscribe((datas: donvi[]) => this.chinhsua.emit(datas));
  }

  sua(tam:donvi){
    this.services.sua(tam)
    .subscribe((datas: donvi[]) => this.chinhsua.emit(datas));
  }

  xoa(tam:donvi){
    if (confirm('Bạn chắc chắn muốn xóa?')){
      this.services.xoa(tam)
      .subscribe((datas: donvi[]) => this.chinhsua.emit(datas));
    }
  }
}
