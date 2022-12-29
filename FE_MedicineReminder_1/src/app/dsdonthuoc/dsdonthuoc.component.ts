import { DsdonService } from './../services/dsdon.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { dsdon } from '../models/dsdon';

@Component({
  selector: 'app-dsdonthuoc',
  templateUrl: './dsdonthuoc.component.html',
  styleUrls: ['./dsdonthuoc.component.css']
})
export class DsdonthuocComponent implements OnInit {

  datas: dsdon[] = [];
  @Output() chinhsua = new EventEmitter<dsdon>();
  suadoi?: dsdon;

  constructor(private Services : DsdonService) { }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(){
    this.Services.get().subscribe((result: dsdon[]) => (
      this.datas = result
    ));
  }

  capnhat(tam: dsdon[]){
    this.datas = tam;
    this.Services.get().subscribe((result: dsdon[]) => (this.datas = result));
  }

  init(){
    this.suadoi = new dsdon();
  }

  sua(tam: dsdon){
    this.suadoi = tam;
  }
}
