import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ElectricianServicePageComponent } from './electrician-service-page.component';

describe('ElectricianServicePageComponent', () => {
  let component: ElectricianServicePageComponent;
  let fixture: ComponentFixture<ElectricianServicePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ElectricianServicePageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ElectricianServicePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
