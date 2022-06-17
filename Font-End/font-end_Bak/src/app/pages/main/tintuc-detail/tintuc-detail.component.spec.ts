import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TintucDetailComponent } from './tintuc-detail.component';

describe('TintucDetailComponent', () => {
  let component: TintucDetailComponent;
  let fixture: ComponentFixture<TintucDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TintucDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TintucDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
