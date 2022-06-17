import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCartModalComponent } from './add-cart-modal.component';

describe('AddCartModalComponent', () => {
  let component: AddCartModalComponent;
  let fixture: ComponentFixture<AddCartModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCartModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCartModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
