import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfSummaryComponent } from './prof-summary.component';

describe('ProfSummaryComponent', () => {
  let component: ProfSummaryComponent;
  let fixture: ComponentFixture<ProfSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProfSummaryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProfSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
