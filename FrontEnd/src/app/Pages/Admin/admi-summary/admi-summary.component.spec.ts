import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmiSummaryComponent } from './admi-summary.component';

describe('AdmiSummaryComponent', () => {
  let component: AdmiSummaryComponent;
  let fixture: ComponentFixture<AdmiSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdmiSummaryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdmiSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
