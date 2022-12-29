import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditdonviComponent } from './editdonvi.component';

describe('EditdonviComponent', () => {
  let component: EditdonviComponent;
  let fixture: ComponentFixture<EditdonviComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditdonviComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditdonviComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
