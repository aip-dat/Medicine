import { DsdonService } from './../../services/dsdon.service';
import { DonthuocService } from './../../services/donthuoc.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { donthuoc } from 'src/app/models/donthuoc';
import { thuoc } from 'src/app/models/thuoc';
import { dsdon } from 'src/app/models/dsdon';
import { ThuocService } from 'src/app/services/thuoc.service';

@Component({
  selector: 'app-editdonthuoc',
  templateUrl: './editdonthuoc.component.html',
  styleUrls: ['./editdonthuoc.component.css']
})
export class EditdonthuocComponent implements OnInit {

  @Input() data?: donthuoc;
  @Output() chinhsua = new EventEmitter<donthuoc[]>();
  datas : donthuoc[] = [];

  listt : thuoc[] = [];
  listdsd : dsdon[] = [];
  constructor(private services : DonthuocService, private dtsv : DsdonService, private tsv : ThuocService) { }

  ngOnInit(): void {
    this.dtsv.get().subscribe((result: dsdon[]) => this.listdsd = result);
    this.tsv.get().subscribe((result: thuoc[]) => this.listt = result);
  }

  them(tam:donthuoc){
    this.services.them(tam)
    .subscribe((datas: donthuoc[]) => this.chinhsua.emit(datas));
  }

  sua(tam:donthuoc){
    this.services.sua(tam)
    .subscribe((datas: donthuoc[]) => this.chinhsua.emit(datas));
  }

  xoa(tam:donthuoc){
    if (confirm('Bạn chắc chắn muốn xóa?')){
      this.services.xoa(tam)
      .subscribe((datas: donthuoc[]) => this.chinhsua.emit(datas));
    }
  }


}
