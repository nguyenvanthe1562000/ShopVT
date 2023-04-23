import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WishlishComponent } from './wishlish.component';

describe('WishlishComponent', () => {
  let component: WishlishComponent;
  let fixture: ComponentFixture<WishlishComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WishlishComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WishlishComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
