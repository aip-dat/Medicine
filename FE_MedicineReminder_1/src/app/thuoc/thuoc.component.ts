import { ThuocService } from './../services/thuoc.service';
import { thuoc } from './../models/thuoc';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-thuoc',
  templateUrl: './thuoc.component.html',
  styleUrls: ['./thuoc.component.css']
})
export class ThuocComponent implements OnInit {
  datas: thuoc[] = [];
  @Output() chinhsua = new EventEmitter<thuoc>();
  suadoi?: thuoc;

  constructor(private Services : ThuocService) { }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(){
    this.Services.get().subscribe((result: thuoc[]) => (
      this.datas = result
    ));
  }

  capnhat(tam: thuoc[]){
    this.datas = tam;
    this.Services.get().subscribe((result: thuoc[]) => (this.datas = result));
  }

  init(){
    this.suadoi = new thuoc();
  }

  sua(tam: thuoc){
    this.suadoi = tam;
  }
}
