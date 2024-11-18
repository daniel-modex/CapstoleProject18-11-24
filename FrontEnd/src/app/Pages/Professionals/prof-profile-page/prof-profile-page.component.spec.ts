import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfProfilePageComponent } from './prof-profile-page.component';

describe('ProfProfilePageComponent', () => {
  let component: ProfProfilePageComponent;
  let fixture: ComponentFixture<ProfProfilePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProfProfilePageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProfProfilePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
