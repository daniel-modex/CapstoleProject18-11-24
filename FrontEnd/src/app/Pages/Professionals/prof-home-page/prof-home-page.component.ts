import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { ProfProfilePageComponent } from "../prof-profile-page/prof-profile-page.component";

@Component({
  selector: 'app-prof-home-page',
  standalone: true,
  imports: [RouterLink, RouterOutlet, ProfProfilePageComponent],
  templateUrl: './prof-home-page.component.html',
  styleUrl: './prof-home-page.component.css'
})
export class ProfHomePageComponent {

}
