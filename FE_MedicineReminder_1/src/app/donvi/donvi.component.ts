import { DonviService } from './../services/donvi.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { donvi } from '../models/donvi';

@Component({
  selector: 'app-donvi',
  templateUrl: './donvi.component.html',
  styleUrls: ['./donvi.component.css']
})
export class DonviComponent implements OnInit {

  datas: donvi[] = [];
  @Output() chinhsua = new EventEmitter<donvi>();
  suadoi?: donvi;

  constructor(private Services : DonviService) { }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(){
    this.Services.get().subscribe((result: donvi[]) => (
      this.datas = result
    ));
  }

  capnhat(tam: donvi[]){
    this.datas = tam;
    this.Services.get().subscribe((result: donvi[]) => (this.datas = result));
  }

  init(){
    this.suadoi = new donvi();
  }

  sua(tam: donvi){
    this.suadoi = tam;
  }
}
