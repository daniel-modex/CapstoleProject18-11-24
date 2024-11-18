import { RouterModule, Routes } from '@angular/router';
import { UserHomePageComponent } from './Pages/user page/user-home-page/user-home-page.component';
import { TutorServicePageComponent } from './Pages/user page/tutor-service-page/tutor-service-page.component';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { PlumberServicePageComponent } from './Pages/user page/plumber-service-page/plumber-service-page.component';
import { ElectricianServicePageComponent } from './Pages/user page/electrician-service-page/electrician-service-page.component';
import { AdminHomePageComponent } from './Pages/Admin/admin-home-page/admin-home-page.component';
import { RegLoginPageComponent } from './Pages/Registeration/reg-login-page/reg-login-page.component';
import { UserNavBarComponent } from './Pages/user page/user-nav-bar/user-nav-bar.component';
import { AdminListUserDetailsComponent } from './Pages/Admin/admin-list-user-details/admin-list-user-details.component';
import { AdminListProfessionalDetailsComponent } from './Pages/Admin/admin-list-professional-details/admin-list-professional-details.component';
import { AdmiSummaryComponent } from './Pages/Admin/admi-summary/admi-summary.component';
import { UserProfilePageComponent } from './Pages/user page/user-profile-page/user-profile-page.component';
import { RegisterPageComponent } from './Pages/Registeration/register-page/register-page.component';
import { ProfHomePageComponent } from './Pages/Professionals/prof-home-page/prof-home-page.component';
import { ProfProfilePageComponent } from './Pages/Professionals/prof-profile-page/prof-profile-page.component';
import { ProfCangeStatusComponent } from './Pages/Professionals/prof-cange-status/prof-cange-status.component';
import { ProfSummaryComponent } from './Pages/Professionals/prof-summary/prof-summary.component';
import { BookingStatusComponent } from './Pages/user page/booking-status/booking-status.component';

export const routes: Routes =
    [
        { path: "", redirectTo: "register", pathMatch: 'full' },
        { path: "register", component: RegisterPageComponent },
        { path: "nav", component: UserNavBarComponent },
        { path: 'user', component: UserHomePageComponent },
        { path: "tutor", component: TutorServicePageComponent },
        { path: "plumber", component: PlumberServicePageComponent },
        { path: "electrician", component: ElectricianServicePageComponent },
        { path: "profile", component: UserProfilePageComponent },
        { path : "status" , component: BookingStatusComponent },

        {
            path: "admin", component: AdminHomePageComponent,
            children: [
                {
                    path: "aduser", component: AdminListUserDetailsComponent
                },
                {
                    path: "adproffesional", component: AdminListProfessionalDetailsComponent
                },
                {
                    path: "adsummary", component: AdmiSummaryComponent
                }
            ]
        },

        {
            path: "professionals", component: ProfHomePageComponent,
            children:
                [
                    {
                        path: "profprofile", component: ProfProfilePageComponent
                    },
                    {
                        path: "profstatus", component: ProfCangeStatusComponent
                    },
                    {
                        path: "profsummary", component: ProfSummaryComponent
                    }
                ]
        }

    ];

