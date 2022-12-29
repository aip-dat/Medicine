import { DonthuocService } from './../services/donthuoc.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { donthuoc } from '../models/donthuoc';

@Component({
  selector: 'app-donthuoc',
  templateUrl: './donthuoc.component.html',
  styleUrls: ['./donthuoc.component.css']
})
export class DonthuocComponent implements OnInit {

  datas: donthuoc[] = [];
  @Output() chinhsua = new EventEmitter<donthuoc>();
  suadoi?: donthuoc;

  constructor(private Services : DonthuocService) { }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(){
    this.Services.get().subscribe((result: donthuoc[]) => (
      this.datas = result
    ));
  }

  capnhat(tam: donthuoc[]){
    this.datas = tam;
    this.Services.get().subscribe((result: donthuoc[]) => (this.datas = result));
  }

  init(){
    this.suadoi = new donthuoc();
  }

  sua(tam: donthuoc){
    this.suadoi = tam;
  }
}
