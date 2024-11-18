import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { RouterLink, RouterOutlet} from '@angular/router';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-user-profile-page',
  standalone: true,
  imports: [RouterLink,RouterOutlet,FormsModule],
  templateUrl: './user-profile-page.component.html',
  styleUrl: './user-profile-page.component.css'
})
export class UserProfilePageComponent implements OnInit {
  userName:any = ""
  ProfileName:any =""
  ngOnInit(): void {
    this.ProfileName = localStorage.getItem('userName')
    this.userName = localStorage.getItem('userName')
    this.getDetails(this.userName)
    console.log(this.userName)
  }
  
  updateObj: any = {
    // "id": 0,
    // "name": "",
    "email": "",
    "phone": "",
    "gender": "",
    "address": "",
    "dob": "",
    "profilePic": "",
    // "userName": "",
    "city": ""
  }
  UserObj: any = {
    id: 0,
    name: "",
    email: "",
    phone: "",
    gender: "",
    address: "",
    city: "",
    dob: "",
    profilePic: "",
    userName: "",
    // password:"",
    role: ""
  }

  http = inject(HttpClient)

  getDetails(name: string) {
    this.http.get("https://localhost:5002/api/UserApi/ByUserName/" +name ).subscribe((res: any) => {
      console.log(res)
      if(res.isSuccessful){
        this.UserObj=res.result
        console.log(this.UserObj)
      }
    })
  }

  onSubmit() {
    this.updateObj = Object.keys(this.updateObj).reduce((updated, key) => {
      if (key in this.UserObj) {
        updated[key] = this.UserObj[key as keyof typeof this.UserObj];
      }
      return updated;
    }, { ...this.updateObj }); // Initialize with current updateObj values
  
    console.log(this.updateObj);

    this.http.put("https://localhost:5002/api/UserApi"+this.UserObj.id,this.updateObj).subscribe((res:any)=>{
      console.log(res)
      if (res.isSuccessful) {
        this.UserObj=res.result
      }
    })
  }
  onLogOut(){
    localStorage.clear()
  }
}
