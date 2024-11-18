import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { UserHomePageComponent } from "../user-home-page/user-home-page.component";
import { UserProfilePageComponent } from '../user-profile-page/user-profile-page.component';
import { ElectricianServicePageComponent } from '../electrician-service-page/electrician-service-page.component';
import { PlumberServicePageComponent } from '../plumber-service-page/plumber-service-page.component';
import { TutorServicePageComponent } from '../tutor-service-page/tutor-service-page.component';

@Component({
  selector: 'app-user-nav-bar',
  standalone: true,
  imports: [RouterLink, RouterOutlet, UserHomePageComponent ,UserProfilePageComponent,ElectricianServicePageComponent,PlumberServicePageComponent,TutorServicePageComponent],
  templateUrl: './user-nav-bar.component.html',
  styleUrl: './user-nav-bar.component.css'
})
export class UserNavBarComponent {
profileName = localStorage.getItem('userName')
}
