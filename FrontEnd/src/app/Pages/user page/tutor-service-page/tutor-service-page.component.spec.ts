import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TutorServicePageComponent } from './tutor-service-page.component';

describe('TutorServicePageComponent', () => {
  let component: TutorServicePageComponent;
  let fixture: ComponentFixture<TutorServicePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TutorServicePageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TutorServicePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
