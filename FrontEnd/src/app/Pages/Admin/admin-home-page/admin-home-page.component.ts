import { Component, inject } from '@angular/core';
import { AdminListUserDetailsComponent } from '../admin-list-user-details/admin-list-user-details.component';
import { AdminListProfessionalDetailsComponent } from '../admin-list-professional-details/admin-list-professional-details.component';
import { AdmiSummaryComponent } from '../admi-summary/admi-summary.component';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-admin-home-page',
  standalone: true,
  imports: [AdminListUserDetailsComponent,RouterOutlet,RouterLink, RouterLinkActive,AdminListProfessionalDetailsComponent,AdmiSummaryComponent],
  templateUrl: './admin-home-page.component.html',
  styleUrl: './admin-home-page.component.css'
})
export class AdminHomePageComponent {
  router = inject(Router)
onlogOut(){
  localStorage.clear()
  this.router.navigateByUrl('register')
}
}
