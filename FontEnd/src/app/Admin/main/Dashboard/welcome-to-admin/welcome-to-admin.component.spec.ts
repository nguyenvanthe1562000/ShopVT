import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WelcomeToAdminComponent } from './welcome-to-admin.component';

describe('WelcomeToAdminComponent', () => {
  let component: WelcomeToAdminComponent;
  let fixture: ComponentFixture<WelcomeToAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WelcomeToAdminComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WelcomeToAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
