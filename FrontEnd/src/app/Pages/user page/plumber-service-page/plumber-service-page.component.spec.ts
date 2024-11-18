import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlumberServicePageComponent } from './plumber-service-page.component';

describe('PlumberServicePageComponent', () => {
  let component: PlumberServicePageComponent;
  let fixture: ComponentFixture<PlumberServicePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlumberServicePageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlumberServicePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
