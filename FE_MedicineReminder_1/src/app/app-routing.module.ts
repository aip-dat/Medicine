import { DonviComponent } from './donvi/donvi.component';
import { ThuocComponent } from './thuoc/thuoc.component';
import { TaikhoanComponent } from './taikhoan/taikhoan.component';
import { DsdonthuocComponent } from './dsdonthuoc/dsdonthuoc.component';
import { DonthuocComponent } from './donthuoc/donthuoc.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DangnhapComponent } from './dangnhap/dangnhap.component';


const routes: Routes = [
  {path: '', component: DonthuocComponent},
  {path: 'dsdonthuoc', component: DsdonthuocComponent},
  {path: 'taikhoan', component: TaikhoanComponent},
  {path: 'dangnhap', component: DangnhapComponent},
  {path: 'thuoc', component: ThuocComponent},
  {path: 'donvi', component: DonviComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
