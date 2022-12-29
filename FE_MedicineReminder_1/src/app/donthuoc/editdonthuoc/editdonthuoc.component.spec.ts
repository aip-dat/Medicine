import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditdonthuocComponent } from './editdonthuoc.component';

describe('EditdonthuocComponent', () => {
  let component: EditdonthuocComponent;
  let fixture: ComponentFixture<EditdonthuocComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditdonthuocComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditdonthuocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
