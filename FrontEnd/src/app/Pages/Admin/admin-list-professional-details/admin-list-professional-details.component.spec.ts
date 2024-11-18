import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminListProfessionalDetailsComponent } from './admin-list-professional-details.component';

describe('AdminListProfessionalDetailsComponent', () => {
  let component: AdminListProfessionalDetailsComponent;
  let fixture: ComponentFixture<AdminListProfessionalDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminListProfessionalDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminListProfessionalDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
