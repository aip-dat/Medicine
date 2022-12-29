import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EdittaikhoanComponent } from './edittaikhoan.component';

describe('EdittaikhoanComponent', () => {
  let component: EdittaikhoanComponent;
  let fixture: ComponentFixture<EdittaikhoanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EdittaikhoanComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EdittaikhoanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
