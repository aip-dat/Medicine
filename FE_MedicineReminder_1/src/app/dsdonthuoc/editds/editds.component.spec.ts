import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditdsComponent } from './editds.component';

describe('EditdsComponent', () => {
  let component: EditdsComponent;
  let fixture: ComponentFixture<EditdsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditdsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditdsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
