import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoryOrderDetailComponent } from './history-order-detail.component';

describe('HistoryOrderDetailComponent', () => {
  let component: HistoryOrderDetailComponent;
  let fixture: ComponentFixture<HistoryOrderDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HistoryOrderDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoryOrderDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
