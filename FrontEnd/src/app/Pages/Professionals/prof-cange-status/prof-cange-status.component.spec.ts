import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfCangeStatusComponent } from './prof-cange-status.component';

describe('ProfCangeStatusComponent', () => {
  let component: ProfCangeStatusComponent;
  let fixture: ComponentFixture<ProfCangeStatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProfCangeStatusComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProfCangeStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
