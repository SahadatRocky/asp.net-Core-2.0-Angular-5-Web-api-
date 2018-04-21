import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';

import { JOB_ROUTES } from "../app/jobroutes/jobRoutes";
import { AddjobComponent } from "../app/components/addjob/addjob.component";
import { Greeter } from "../app/services/Greeter";

import { FormGroup, FormControl, FormBuilder, Validators, ReactiveFormsModule } from "@angular/forms";
import { JobDataService } from "../app/services/job.dataservice";
import { ViewjobComponent } from "../app/components/viewjob/viewjob.component";
import { TimeSince } from "../app/pipes/timesince";
import { EditjobComponent } from "./components/editjob/editjob.component";



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        AddjobComponent,
        ViewjobComponent,
        TimeSince,
        EditjobComponent


        
    ],
    providers: [JobDataService],
    imports: [
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        HttpModule,
        RouterModule.forRoot(JOB_ROUTES)
    ]
   
})
export class AppModuleShared {
}
