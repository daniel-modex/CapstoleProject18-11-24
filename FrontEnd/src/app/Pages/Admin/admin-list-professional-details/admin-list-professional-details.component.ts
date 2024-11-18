import { Component, OnInit, inject } from '@angular/core';
import { APIService } from '../../../Service/user.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-admin-list-professional-details',
  standalone: true,
  imports: [],
  templateUrl: './admin-list-professional-details.component.html',
  styleUrl: './admin-list-professional-details.component.css'
})
export class AdminListProfessionalDetailsComponent implements OnInit {
  APIService = inject(APIService);
  ProfessionalList:any[]=[];
  ngOnInit(): void {
    this.loadProfessionals();
  }
  loadProfessionals(){
    this.APIService.getProfessionals().subscribe((res:any) =>{
      console.log(res.result)
      this.ProfessionalList=res.result;
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
    this.http.delete("https://localhost:7057/api/Services/" + id).subscribe((res: any) => {
      
      alert("Professional record successfully Deleted!");
      window.location.reload()
    })
  }

  onShow(id:any){
    localStorage.setItem('DetailsById',id)
  }
}