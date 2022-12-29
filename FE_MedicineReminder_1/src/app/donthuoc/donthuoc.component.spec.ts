import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DonthuocComponent } from './donthuoc.component';

describe('DonthuocComponent', () => {
  let component: DonthuocComponent;
  let fixture: ComponentFixture<DonthuocComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DonthuocComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DonthuocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
