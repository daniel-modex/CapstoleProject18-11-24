import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-prof-profile-page',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './prof-profile-page.component.html',
  styleUrl: './prof-profile-page.component.css'
})
export class ProfProfilePageComponent implements OnInit {
userName:any = ""
  ngOnInit(): void {
    this.userName = localStorage.getItem('userName')
    this.getDetails(this.userName)
    console.log(this.userName)
  }
  updateObj: any = {
    name: "",
    gender: "",
    address: "",
    dob: "2024-11-15",
    profilePic: "",
    basePay: 0,
    documentPath: "",
    domain: "",
    city: ""
  }
  providerObj: any = {
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
    rating: 0,
    isAvailable: false,
    basePay: 0,
    isConfirmed: false,
    domain: "",
    documentPath: "",
    cummilativeRating: 0,
    totalReviews: 0
  }

  http = inject(HttpClient)

  getDetails(name: string) {
    this.http.get("https://localhost:7057/api/Services/GetProfessionalByUserName/" +name ).subscribe((res: any) => {
      console.log(res)
      if(res.isSuccessful){
        this.providerObj=res.result
        console.log(this.providerObj)
      }
    })
  }

  onSubmit() {
    this.updateObj = Object.keys(this.updateObj).reduce((updated, key) => {
      if (key in this.providerObj) {
        updated[key] = this.providerObj[key as keyof typeof this.providerObj];
      }
      return updated;
    }, { ...this.updateObj }); // Initialize with current updateObj values
  
    console.log(this.updateObj);

    this.http.put("https://localhost:7057/api/Services/updateProfile/"+this.providerObj.id,this.updateObj).subscribe((res:any)=>{
      console.log(res)
      if (res.isSuccessful) {
        this.providerObj=res.result
      }
    })
  }

}
