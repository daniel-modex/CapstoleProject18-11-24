import { Component, OnInit, inject } from '@angular/core';
import { APIService } from '../../../Service/user.service';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-admin-list-user-details',
  standalone: true,
  imports: [RouterOutlet,RouterLink,RouterLinkActive],
  templateUrl: './admin-list-user-details.component.html',
  styleUrl: './admin-list-user-details.component.css'
})
export class AdminListUserDetailsComponent implements OnInit {
  APIService = inject(APIService);
  UserList:any[]=[];
  ngOnInit(): void {
    this.loadProfessionals();
  }
  loadProfessionals(){
    this.APIService.getUsers().subscribe((res:any) =>{
      console.log(res.result)
      this.UserList=res.result;
    })
  }

  
DeleteDetail: any = {
  "id": 0,
  "name": "",
  "domain": "",
  "email": "",
}
http = inject(HttpClient)
  onDelete(id:any) {
    this.http.delete("https://localhost:5002/api/UserApi/" + id).subscribe((res: any) => {
      
      alert("User record successfully Deleted!");
      window.location.reload()
    })
  }
}