import { Component, OnInit } from '@angular/core';
import { RouterLink} from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { UserProfilePageComponent } from '../user-profile-page/user-profile-page.component';
import { PlumberServicePageComponent } from '../plumber-service-page/plumber-service-page.component';
import { ElectricianServicePageComponent } from '../electrician-service-page/electrician-service-page.component';
import { TutorServicePageComponent } from '../tutor-service-page/tutor-service-page.component';

@Component({
  selector: 'app-user-home-page',
  standalone: true,
  imports: [NgbModule , RouterLink,RouterModule ,UserProfilePageComponent,PlumberServicePageComponent,ElectricianServicePageComponent,TutorServicePageComponent,UserProfilePageComponent],
  templateUrl: './user-home-page.component.html',
  styleUrl: './user-home-page.component.css'
})
export class UserHomePageComponent implements OnInit  {
   ProfileName:any =""
  ngOnInit(): void {
    this.ProfileName = localStorage.getItem('userName')
  }

  onLogOut(){
    localStorage.clear()
  }

}
