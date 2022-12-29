import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DangxuatComponent } from './dangxuat.component';

describe('DangxuatComponent', () => {
  let component: DangxuatComponent;
  let fixture: ComponentFixture<DangxuatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DangxuatComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DangxuatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
