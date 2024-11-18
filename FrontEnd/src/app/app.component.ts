import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { UserHomePageComponent } from "./Pages/user page/user-home-page/user-home-page.component";
import { UserNavBarComponent } from "./Pages/user page/user-nav-bar/user-nav-bar.component";
import { ElectricianServicePageComponent } from './Pages/user page/electrician-service-page/electrician-service-page.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, UserHomePageComponent, RouterLink, UserNavBarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ProjectUI';
}


