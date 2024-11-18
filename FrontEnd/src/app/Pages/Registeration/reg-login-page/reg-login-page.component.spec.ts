import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegLoginPageComponent } from './reg-login-page.component';

describe('RegLoginPageComponent', () => {
  let component: RegLoginPageComponent;
  let fixture: ComponentFixture<RegLoginPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegLoginPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegLoginPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
