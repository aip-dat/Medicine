import { DonviService } from './../../services/donvi.service';
import { donvi } from './../../models/donvi';
import { ThuocService } from './../../services/thuoc.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { thuoc } from 'src/app/models/thuoc';

@Component({
  selector: 'app-editthuoc',
  templateUrl: './editthuoc.component.html',
  styleUrls: ['./editthuoc.component.css']
})
export class EditthuocComponent implements OnInit {

  @Input() data?: thuoc;
  @Output() chinhsua = new EventEmitter<thuoc[]>();
  datas: thuoc[] = [];

  list : donvi[] = [];

  constructor(private services : ThuocService, private dvs : DonviService) { }

  ngOnInit(): void {
    this.dvs.get().subscribe((result: donvi[]) => this.list = result);
  }

  them(tam:thuoc){
    this.services.them(tam)
    .subscribe((datas: thuoc[]) => this.chinhsua.emit(datas));
  }

  sua(tam:thuoc){
    this.services.sua(tam)
    .subscribe((datas: thuoc[]) => this.chinhsua.emit(datas));
  }

  xoa(tam:thuoc){
    if (confirm('Bạn chắc chắn muốn xóa?')){
      this.services.xoa(tam)
      .subscribe((datas: thuoc[]) => this.chinhsua.emit(datas));
    }
  }
}
