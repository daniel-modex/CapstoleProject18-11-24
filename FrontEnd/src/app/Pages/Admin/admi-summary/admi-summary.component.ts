import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { timeout } from 'rxjs';

@Component({
  selector: 'app-admi-summary',
  standalone: true,
  imports: [],
  templateUrl: './admi-summary.component.html',
  styleUrl: './admi-summary.component.css'
})
export class AdmiSummaryComponent implements OnInit {
  noOfTutors: any;
  noOfElectrician: any;
  noOfPlumber: any;
  ngOnInit(): void {
   
    this.totalTutorBooking()

   
  }

  // noOfPlumbers:any = ''
  // noOfTutors: any = ''
  // noOfElectricians: any = ''



  http = inject(HttpClient)

  totalTutorBooking() {
    this.http.get("https://localhost:7025/api/Summary/ServiceSummary/Tutor").subscribe((res: any) => {
      console.log(res) 
    if (res.isSuccessful) {
        console.log(res.result.count)
        this.noOfTutors = res.result.count
        
      }
    })

    this.http.get("https://localhost:7025/api/Summary/ServiceSummary/Electrician").subscribe((res: any) => {
      if (res.isSuccessful) {
        this.noOfElectrician = res.result.count
       
      }
    })

    this.http.get("https://localhost:7025/api/Summary/ServiceSummary/Plumber").subscribe((res: any) => {
      if (res.isSuccessful) {
        this.noOfPlumber = res.result.count
       
      }
    })
  }

  totalElectricianBooking() {
    
  }

  totalPlumberBooking() {
   
  }

}
