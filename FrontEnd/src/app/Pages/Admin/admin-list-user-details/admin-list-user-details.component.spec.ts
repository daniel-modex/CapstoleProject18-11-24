import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminListUserDetailsComponent } from './admin-list-user-details.component';

describe('AdminListUserDetailsComponent', () => {
  let component: AdminListUserDetailsComponent;
  let fixture: ComponentFixture<AdminListUserDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminListUserDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminListUserDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
