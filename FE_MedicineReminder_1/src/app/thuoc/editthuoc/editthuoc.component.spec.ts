import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditthuocComponent } from './editthuoc.component';

describe('EditthuocComponent', () => {
  let component: EditthuocComponent;
  let fixture: ComponentFixture<EditthuocComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditthuocComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditthuocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
