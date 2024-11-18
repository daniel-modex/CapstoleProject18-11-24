import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { timer } from 'rxjs';

@Component({
  selector: 'app-register-page',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './register-page.component.html',
  styleUrl: './register-page.component.css'
})
export class RegisterPageComponent {
  passwordError:boolean=false;
  emailError:boolean=false;

  constructor(private toastr:ToastrService){

  }
registerObj:any={
  userName:"",
  email:"",
  phone:"",
  password:"",
  name:"",
  role:"user"
}
loginObj:any={
  userName:"",
  password:""
}
ischeck:boolean=false
http=inject(HttpClient)
router = inject(Router)

onRegister(){
  console.log(this.registerObj)
  if (this.ischeck) {
    this.registerObj.role="provider"
  }
  if (this.passwordError && this.emailError) {
    this.http.post("https://localhost:7001/api/AuthApi/Register",this.registerObj).subscribe((res:any)=>{
      console.log(res)
      if(res.isSuccessful){
        if (this.registerObj.role=='user') {
          this.http.post("https://localhost:5002/api/UserApi",this.registerObj).subscribe((user:any)=>{
            console.log(user)
            if (user.result) {
              // alert("Successfully registered User")
              this.toastr.success("Successfully registered as User")
              timer(2000).subscribe(() => {
                window.location.reload()
              });
            }
            
          })
        }
        if (this.registerObj.role=='provider') {
          this.http.post("https://localhost:7057/api/Services/Register",this.registerObj).subscribe((user:any)=>{
            console.log(user)
            if (user.result) {
              // alert("Successfully registered Service Provider")
              this.toastr.success("Successfully registered as Service Provider")
              timer(2000).subscribe(() => {
                window.location.reload()
              });
            }
          })
        }
        
        
        
        
        
      }
     else{
      alert("Something went wrong")
     }
    })
  }
  
}

onLogin(){
  this.http.post("https://localhost:7001/api/AuthApi/Login",this.loginObj).subscribe((res:any)=>{
    localStorage.setItem('userName',res.username)
    localStorage.setItem('token',res.token)
    localStorage.setItem('role',res.role)
    console.log(res)
  if (res) {
    
    if(res.role=="user") {
      this.toastr.success("Successfully Logged in as User")
      // this.router.navigateByUrl('user')
      timer(2000).subscribe(() => {
        this.router.navigateByUrl('user');
      });
      
    }
    if (res.role=="provider") {
      this.toastr.success("Successfully Logged in as Service Provider")
      timer(2000).subscribe(() => {
        this.router.navigateByUrl('professionals');
      });
      
    }
    if(res.role=="admin"){
      this.toastr.success("Successfully Logged in as Admin")
      timer(2000).subscribe(() => {
        this.router.navigateByUrl('admin');
      });
      
    }
  }
  
  })
}

onEmailChange(email: string) {
  if (email) {
    this.validateEmail(email);
  }
}

validateEmail(email: string): void {
  const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
  if (!emailPattern.test(email)) {
    this.toastr.error('Invalid email format');
  }
}

validatePassword(): void {
  const password = this.registerObj.password;

  if (!password) {
    this.toastr.error('Password is required.');
  } else if (password.length < 6) {
    this.toastr.error('Password must be at least 6 characters long.');
  } else if (!/[A-Z]/.test(password)) {
    this.toastr.error(
      'Password must contain at least one uppercase letter.');
  } else if (!/[a-z]/.test(password)) {
    this.toastr.error(
      'Password must contain at least one lowercase letter.');
  } else if (!/\d/.test(password)) {
    this.toastr.error('Password must contain at least one number.');
  } else if (!/[@$!%*?&]/.test(password)) {
    this.toastr.error(
      'Password must contain at least one special character.');
  } else {
    this.passwordError = true; // No errors
  }
}

}
