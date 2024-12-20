import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfHomePageComponent } from './prof-home-page.component';

describe('ProfHomePageComponent', () => {
  let component: ProfHomePageComponent;
  let fixture: ComponentFixture<ProfHomePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProfHomePageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProfHomePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
