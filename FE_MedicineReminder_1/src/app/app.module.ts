import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FooterComponent } from './footer/footer.component';
import { DonthuocComponent } from './donthuoc/donthuoc.component';
import { DsdonthuocComponent } from './dsdonthuoc/dsdonthuoc.component';
import { ThuocComponent } from './thuoc/thuoc.component';
import { TaikhoanComponent } from './taikhoan/taikhoan.component';
import { DangnhapComponent } from './dangnhap/dangnhap.component';
import { DangxuatComponent } from './dangxuat/dangxuat.component';
import { DonviComponent } from './donvi/donvi.component';
import { EditdonthuocComponent } from './donthuoc/editdonthuoc/editdonthuoc.component';
import { EdittaikhoanComponent } from './taikhoan/edittaikhoan/edittaikhoan.component';
import { EditdonviComponent } from './donvi/editdonvi/editdonvi.component';
import { EditdsComponent } from './dsdonthuoc/editds/editds.component';
import { EditthuocComponent } from './thuoc/editthuoc/editthuoc.component';
import { FormsModule } from '@angular/forms';
import { QRCodeModule } from 'angularx-qrcode';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SidebarComponent,
    FooterComponent,
    DonthuocComponent,
    DsdonthuocComponent,
    ThuocComponent,
    TaikhoanComponent,
    DangnhapComponent,
    DangxuatComponent,
    DonviComponent,
    EditdonthuocComponent,
    EdittaikhoanComponent,
    EditdonviComponent,
    EditdsComponent,
    EditthuocComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    QRCodeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
