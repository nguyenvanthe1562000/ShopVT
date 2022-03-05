import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCartSectionComponent } from './add-cart-section.component';

describe('AddCartSectionComponent', () => {
  let component: AddCartSectionComponent;
  let fixture: ComponentFixture<AddCartSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCartSectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCartSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
