import { Component, OnInit, inject } from '@angular/core';
import { UserHomePageComponent } from '../user-home-page/user-home-page.component';
import { RouterLink, RouterOutlet} from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-tutor-service-page',
  standalone: true,
  imports: [RouterLink,RouterOutlet],
  templateUrl: './tutor-service-page.component.html',
  styleUrl: './tutor-service-page.component.css'
})
export class TutorServicePageComponent  implements OnInit {

  // Array of services to be displayed on the page
  services = [
    { 
      id: 1, 
      name: 'Electrician Service', 
      price: 50, 
      imageUrl: 'https://via.placeholder.com/300x200' 
    },
    { 
      id: 2, 
      name: 'Electrician Service', 
      price: 75, 
      rating: 5, 
      imageUrl: 'https://via.placeholder.com/300x200' 
    },
    { 
      id: 3, 
      name: 'Electrician Service', 
      price: 100, 
      rating: 3, 
      imageUrl: 'https://via.placeholder.com/300x200' 
    },
    { 
      id: 4, 
      name: 'Electrician Service', 
      price: 40, 
      rating: 4, 
      imageUrl: 'https://via.placeholder.com/300x200' 
    },
    { 
      id: 5, 
      name: 'Electrician Service', 
      price: 150, 
      rating: 5, 
      imageUrl: 'https://via.placeholder.com/300x200' 
    },
    { 
      id: 6, 
      name: 'Electrician Service', 
      price: 80, 
      rating: 4, 
      imageUrl: 'https://via.placeholder.com/300x200' 
    },
  ];

  ProfileName:any =""
http = inject(HttpClient)
data:any[] = []
domain:string="Tutor"
  constructor() { }

  ngOnInit(): void {
    // Fetch services from backend (C# API)
    this.fetchServicesFromBackend();
    this.ProfileName = localStorage.getItem('userName')
  }

  fetchServicesFromBackend() {
    this.http.get("https://localhost:7057/api/Services/GetProfessionalsByDomain/"+this.domain).subscribe((res:any)=>{
      console.log(res.result)
      if(res) {
        this.data=res.result
      }
    })
  }
  onLogOut(){
    localStorage.clear()
  }

  Book(){
 
  }
}
