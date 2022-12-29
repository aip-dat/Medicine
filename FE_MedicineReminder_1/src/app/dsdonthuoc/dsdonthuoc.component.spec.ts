import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DsdonthuocComponent } from './dsdonthuoc.component';

describe('DsdonthuocComponent', () => {
  let component: DsdonthuocComponent;
  let fixture: ComponentFixture<DsdonthuocComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DsdonthuocComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DsdonthuocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
